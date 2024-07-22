Imports Newtonsoft.Json
Imports Org.BouncyCastle.Bcpg
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports PocZapsign.Utils

Public Class TermosEnviados
    Inherits System.Web.UI.Page
    Dim objBLPessoa As PocZapsign.BLPessoa
    Dim objBLTermoEnviado As PocZapsign.BLTermos
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Dim utils As New Utils

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PreencherComboBoxPessoas()
        End If
    End Sub

    Private Sub PreencherComboBoxPessoas()
        Try
            Dim objBLPessoa As New BLPessoa()
            objBLPessoa.ListarPessoasDropDownEnviados(DdlPessoas)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Erro ao carregar os usuários!\n{ex.Message}');", True)
        End Try
    End Sub

    Protected Sub BtnConsultarTermoEnviado_Click(sender As Object, e As EventArgs) Handles BtnConsultarTermoEnviado.Click

        Dim objBLTermo As New BLTermos()
        Dim ddl_num = DdlPessoas.SelectedValue
        Dim objBLZap As New BLZapsign
        Dim termoEnviado = objBLTermo.ObterTermosPorIntegrante(ddl_num)
        Dim docAssinado As Boolean = False
        Dim objTermo As New Termos
        Dim retorno = objBLZap.SendGetRequest(termoEnviado.TOKEN)

        Dim consultaTermo As ConsultaTermo = JsonConvert.DeserializeObject(Of ConsultaTermo)(retorno)

        ' verifica o status do documento para ver se já está assinado.
        docAssinado = consultaTermo IsNot Nothing AndAlso consultaTermo.status = "signed"

        ' se o documento estiver assinado, pego os dados e gravo no banco o link do doc, a base 64 do doc e também o status de assinado.
        If docAssinado Then

            'link pra visualizar o termo sem assinatura
            If Not String.IsNullOrEmpty(consultaTermo.original_file) Then
                objTermo.TERMOLINKEMBRANCO = consultaTermo.original_file
            Else
                objTermo.TERMOLINKEMBRANCO = String.Empty
            End If

            'link para visualizar o termo assinado
            If Not String.IsNullOrEmpty(consultaTermo.signed_file) Then
                objTermo.TERMOLINKASSINADO = consultaTermo.signed_file
            Else
                objTermo.TERMOLINKASSINADO = String.Empty
            End If

            If consultaTermo.signers IsNot Nothing AndAlso consultaTermo.signers.Count > 0 Then
                objTermo.DATAASSINATURA = utils.ConvertDateTime(consultaTermo.signers(0).signed_at)
            Else
                objTermo.DATAASSINATURA = Nothing
            End If

            If Not String.IsNullOrEmpty(consultaTermo.token) Then
                objTermo.TOKEN = consultaTermo.token
            Else
                objTermo.TOKEN = String.Empty
            End If

            If Not String.IsNullOrEmpty(ddl_num) Then
                objTermo.NUM = ddl_num
            Else
                objTermo.NUM = String.Empty
            End If

            'termo original sem a assinatura, em base 64
            If Not String.IsNullOrEmpty(consultaTermo.original_file) Then
                objTermo.TERMOENVIADO = DownloadPdf(consultaTermo.original_file)
            Else
                objTermo.TERMOENVIADO = Nothing
            End If

            'termo assinado, em base 64
            If Not String.IsNullOrEmpty(consultaTermo.signed_file) Then
                objTermo.TERMOASSINADO = DownloadPdf(consultaTermo.signed_file)
            Else
                objTermo.TERMOASSINADO = Nothing
            End If

            ' ATUALIZA OS DADOS DO TERMO NO BANCO DE DADOS
            objBLTermo.Atualizar(objTermo)

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "AvisoDocumentoAssinado", "alert('Documento assinado!');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "AvisoDocumentoPendente", "alert('Documento aguardando assinatura!');", True)
        End If

        If docAssinado Then
            btnTermoAssinado.Visible = True
            btnTermoAssinado.Style("display") = "inline"

            btnTermoEnviado.Visible = True
            btnTermoEnviado.Style("display") = "inline"
        Else
            btnTermoEnviado.Visible = True
            btnTermoEnviado.Style("display") = "inline"

            btnTermoAssinado.Visible = False
            btnTermoAssinado.Style("display") = "block"
        End If

    End Sub
    Protected Sub DownloadPdfTermoEnviado(ddlPessoa As Integer)
        Dim fileName As String = "TermoEnviado.pdf"
        Dim pdfData As Byte() = Nothing

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT TERMOENVIADO FROM Termos WHERE NUM = @ID", conn)
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ddlPessoa

            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    pdfData = If(reader("TERMOENVIADO") Is DBNull.Value, Nothing, CType(reader("TERMOENVIADO"), Byte()))
                End If
            End Using
        End Using

        If pdfData IsNot Nothing Then
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
            Response.BinaryWrite(pdfData)
            Response.End()
        Else
            Response.Write("Nenhum documento encontrado.")
        End If
    End Sub

    Protected Sub DownloadPdfTermoAssinado(ddlPessoa As Integer)
        Dim fileName As String = "TermoAssinado.pdf"
        Dim pdfData As Byte() = Nothing

        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT TERMOASSINADO FROM Termos WHERE NUM = @ID", conn)
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ddlPessoa

            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    pdfData = If(reader("TERMOASSINADO") Is DBNull.Value, Nothing, CType(reader("TERMOASSINADO"), Byte()))
                End If
            End Using
        End Using

        If pdfData IsNot Nothing Then
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
            Response.BinaryWrite(pdfData)
            Response.End()
        Else
            Response.Write("Nenhum documento encontrado.")
        End If
    End Sub

    Function DownloadPdf(pdfUrl As String) As Byte()
        Try
            Using client As New WebClient()
                Return client.DownloadData(pdfUrl)
            End Using
        Catch ex As Exception
            ' Log do erro para depuração
            Console.WriteLine("Erro ao baixar o PDF: " & ex.Message)
            Return Nothing
        End Try
    End Function


    Protected Sub btnTermoAssinado_Click(sender As Object, e As EventArgs) Handles btnTermoAssinado.Click

        If DdlPessoas.SelectedValue = "0" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "AvisoDownload", "alert('Selecione um termo para baixar!');", True)
            Exit Sub
        End If


        DownloadPdfTermoAssinado(DdlPessoas.SelectedValue)
        ' Redireciona para a mesma página para forçar um refresh
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub btnTermoEnviado_Click(sender As Object, e As EventArgs) Handles btnTermoEnviado.Click

        If DdlPessoas.SelectedValue = "0" Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "AvisoDownload", "alert('Selecione um termo para baixar!');", True)
            Exit Sub
        End If

        DownloadPdfTermoEnviado(DdlPessoas.SelectedValue)
        ' Redireciona para a mesma página para forçar um refresh
        Response.Redirect(Request.RawUrl)
    End Sub


End Class