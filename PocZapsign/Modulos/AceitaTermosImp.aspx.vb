Imports System.IO
Imports iText.Html2pdf
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports Newtonsoft.Json
Imports PocZapsign.TermoEnvio
Imports PocZapsign.BLPessoa
Imports PocZapsign

Public Class AceitaTermosImp
    Inherits System.Web.UI.Page
    Dim objBLPessoa As PocZapsign.BLPessoa

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ajax.Utility.RegisterTypeForAjax(GetType(AceitaTermosImp), Me.Page)

        If IsPostBack Then
            Exit Sub
        End If

        Dim pessoaId As String = UCase(Request("id"))

        If Not IsNumeric(pessoaId) Then
            Response.Redirect("CriarAssinatura.aspx")
            Exit Sub
        End If

        objBLPessoa = New BLPessoa

        Dim objPessoa = objBLPessoa.Obter(pessoaId)

        If IsNothing(objPessoa) Then
            Response.Redirect("CriarAssinatura.aspx")
            Exit Sub
        End If

        numero.Text = pessoaId & " - " & objPessoa.Apelido
        Nome.Text = objPessoa.Nome
        cpf.Text = objPessoa.CPF
        nome1.Text = objPessoa.Nome
        cpf1.Text = objPessoa.CPF
        cidade.Text = objPessoa.Cidade
        data.Text = Format(Now(), "dd/MM/yyyy")
        rg.Text = objPessoa.RG
        email.Text = objPessoa.Email
        telefone.Text = objPessoa.TelCel
        endereco.Text = objPessoa.Endereco & ", número: " & objPessoa.Numero & ", complemento: " & objPessoa.Complemento & ", bairro: " & objPessoa.Bairro & ", cidade: " & objPessoa.Cidade & ", UF.: " & objPessoa.UF & ", CEP.: " & objPessoa.CEP

        'BtnEnviarAssinatura.Attributes.Add("OnClick", "EnviarAssinaturaDigital(); return false;")
    End Sub

    Protected Sub BtnEnviarAssinatura_Click(sender As Object, e As EventArgs) Handles BtnEnviarAssinatura.Click
        Dim base64 = ExportarPDF()

        Dim objBLZap As New BLZapsign
        Dim objBLTermosEnvio As New BLTermosEnvio
        objBLPessoa = New BLPessoa

        Dim pessoaId As String = UCase(Request("id"))

        Dim objPessoa = objBLPessoa.Obter(pessoaId)

        Dim retorno = objBLZap.SendPostRequest(objPessoa, base64)

        Dim objRetorno As RetornoAssinatura = JsonConvert.DeserializeObject(Of RetornoAssinatura)(retorno)
        Dim objTermosEnvio As New TermosEnvio With {
            .NUM = pessoaId,
            .TOKEN = objRetorno.token,
            .DATAENVIO = Date.Now,
            .STATUS = Convert.ToString(PocZapsign.TermoEnvio.StatusTermoEnvio.ENVIADO),
            .TERMO = objRetorno.original_file
        }

        objBLTermosEnvio.Incluir(objTermosEnvio)

        Response.Redirect("CriarAssinatura.aspx")
    End Sub

    Protected Function ExportarPDF() As String
        Dim contentHtml As String = RenderControlToHtml(Panel1)

        Return GeneratePDFBase64(contentHtml)
    End Function

    Private Function GeneratePDFBase64(contentHtml As String) As String
        Using ms As New MemoryStream()
            Dim writer As New PdfWriter(ms)
            Dim pdf As New PdfDocument(writer)
            Dim document As New Document(pdf)

            HtmlConverter.ConvertToPdf(New MemoryStream(System.Text.Encoding.UTF8.GetBytes(contentHtml)), pdf, New ConverterProperties())

            document.Close()
            Dim pdfBytes As Byte() = ms.ToArray()

            ' Converte o byte array em uma string base64
            Dim base64String As String = Convert.ToBase64String(pdfBytes)

            Return base64String
        End Using
    End Function

    Private Function RenderControlToHtml(ctrl As Control) As String
        Using sw As New StringWriter()
            Using tw As New HtmlTextWriter(sw)
                ctrl.RenderControl(tw)
                Return sw.ToString()
            End Using
        End Using
    End Function

    <Ajax.AjaxMethod()>
    Public Sub EnviarAssinatura(ByVal pessoaId As String, ByVal base64 As String)

        Dim objBLZap As New BLZapsign
        Dim objBLTermosEnvio As New BLTermosEnvio
        objBLPessoa = New BLPessoa
        Dim decPessoaId = Convert.ToDecimal(pessoaId)
        Dim objPessoa = objBLPessoa.Obter(Convert.ToDecimal(decPessoaId))

        Dim retorno = objBLZap.SendPostRequest(objPessoa, base64)

        Dim objRetorno As RetornoAssinatura = JsonConvert.DeserializeObject(Of RetornoAssinatura)(retorno)
        Dim objTermosEnvio As New TermosEnvio With {
           .NUM = pessoaId,
            .TOKEN = objRetorno.token,
            .DATAENVIO = Date.Now,
            .STATUS = Convert.ToString(PocZapsign.TermoEnvio.StatusTermoEnvio.ENVIADO)
        }

        objBLTermosEnvio.Incluir(objTermosEnvio)

        Response.Redirect("CriarAssinatura.aspx")
    End Sub


End Class