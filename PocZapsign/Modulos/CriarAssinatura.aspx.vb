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
            Dim selectedIntegranteId As Integer = Convert.ToInt32(DdlPessoas.SelectedValue)
            Dim selectedPessoaItem As ListItem = DdlPessoas.SelectedItem
            Dim objBLTermoS As New BLTermos

            Dim objTermos = objBLTermoS.ObterTermosPorIntegrante(selectedIntegranteId)

            If selectedIntegranteId = 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Seleciona um usuário!'); hideLoader();", True)
            ElseIf objTermos.NUM > 0 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('O usuário: {selectedPessoaItem.Text}\nJá possui um documento enviado!'); hideLoader();", True)
            Else
                Response.Redirect("AceitaTermosImp.aspx?id=" + selectedIntegranteId.ToString)
            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Erro ao gerar a assinatura!\n{ex.Message}'); hideLoader();", True)
        End Try
    End Sub

End Class