Imports Newtonsoft.Json

Public Class TermosEnviados
    Inherits System.Web.UI.Page
    Dim objBLPessoa As PocZapsign.BLPessoa
    Dim objBLTermoEnviado As PocZapsign.BLTermosEnvio

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

        Dim objBLTermoEnviado As New BLTermosEnvio()
        Dim ddl_num = DdlPessoas.SelectedValue
        Dim objBLZap As New BLZapsign
        Dim termoEnviado = objBLTermoEnviado.ObterTermosPorPessoa(ddl_num)

        Dim retorno = objBLZap.SendGetRequest(termoEnviado.TOKEN)

        Console.WriteLine(retorno)

    End Sub

End Class