Public Class BLTermosEnvio
    Private ReadOnly dal As New DALTermosEnvio()

    Public Function Listar() As DataTable
        Return dal.Listar()
    End Function

    Public Function ObterTermosPorPessoa(ByVal pessoaId As Integer) As TermosEnvio
        Dim dtDoc As DataTable = dal.ObterTermosPorPessoa(pessoaId)
        Dim objTermosEnvio As New TermosEnvio()

        If dtDoc.Rows.Count > 0 Then
            Dim row As DataRow = dtDoc.Rows(0)
            objTermosEnvio.NUM = Convert.ToInt32(row("NUM"))
            objTermosEnvio.TOKEN = row("TOKEN").ToString()
            objTermosEnvio.STATUS = row("STATUS").ToString()
        End If

        Return objTermosEnvio
    End Function

    Public Sub Incluir(termosEnvio As TermosEnvio)
        dal.Incluir(termosEnvio)
    End Sub

    Public Sub Atualizar(termosEnvio As TermosEnvio)
        dal.Atualizar(termosEnvio)
    End Sub

    Public Sub Deletar(id As Integer)
        dal.Deletar(id)
    End Sub
End Class
