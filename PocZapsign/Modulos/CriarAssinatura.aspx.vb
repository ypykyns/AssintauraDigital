Public Class CriarAssinatura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PreencherComboBoxPessoas()
        End If
    End Sub

    Private Sub PreencherComboBoxPessoas()
        Try
            Dim objBLPessoa As New BLPessoa()
            objBLPessoa.ListarPessoasDropDown(DdlPessoas)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Erro ao carregar os usuários!\n{ex.Message}');", True)
        End Try
    End Sub

    Protected Sub BtnGerarAssinatura_Click(sender As Object, e As EventArgs) Handles BtnGerarAssinatura.Click
        Try
            Dim selectedPessoaId As Integer = Convert.ToInt32(DdlPessoas.SelectedValue)
            Dim selectedPessoaItem As ListItem = DdlPessoas.SelectedItem
            Dim objBLTermosEnvio As New BLTermosEnvio

            Dim objTermosEnvio = objBLTermosEnvio.ObterTermosPorPessoa(selectedPessoaId)

            If selectedPessoaId = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Seleciona um usuário!'); hideLoader();", True)
            ElseIf objTermosEnvio.NUM > 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('O usuário: {selectedPessoaItem.Text}\nJá possui um documento enviado!'); hideLoader();", True)
            Else
                ''Abrir Documento para assinar
                'Dim novoTermosEnvio As New TermosEnvio() With {
                '    .TOKEN = "abc123",
                '    .DATA_ENVIO = DateTime.Now,
                '    .STATUS = "0",
                '    .DATA_RETORNO = Nothing,
                '    .PESSOA_ID = selectedPessoaId
                '}
                'objBLTermosEnvio.Incluir(novoTermosEnvio)
                Response.Redirect("AceitaTermosImp.aspx?id=" + selectedPessoaId.ToString)
            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Erro ao gerar a assinatura!\n{ex.Message}'); hideLoader();", True)
        End Try
    End Sub

End Class