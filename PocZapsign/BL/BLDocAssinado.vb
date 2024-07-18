Public Class BLDocAssinado
    Private ReadOnly dal As New DALDocAssinado()

    Public Function ListarDocsAssinados() As DataTable
        Return dal.ListarDocsAssinados()
    End Function

    Public Sub IncluirDocAssinado(fkPessoas As Integer, tokenZap As String, docAssinado As String)
        dal.IncluirDocAssinado(fkPessoas, tokenZap, docAssinado)
    End Sub

    Public Sub AtualizarDocAssinado(id As Integer, fkPessoas As Integer, tokenZap As String, docAssinado As String)
        dal.AtualizarDocAssinado(id, fkPessoas, tokenZap, docAssinado)
    End Sub

    Public Sub DeletarDocAssinado(id As Integer)
        dal.DeletarDocAssinado(id)
    End Sub
End Class
