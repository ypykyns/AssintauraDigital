Public Class BLTermos
    Private ReadOnly dal As New DALTermos()

    Public Function Listar() As DataTable
        Return dal.Listar()
    End Function

    Public Function ObterTermosPorIntegrante(ByVal IdIntegrante As Integer) As Termos
        Dim dtDoc As DataTable = dal.ObterTermosPorIntegrante(IdIntegrante)
        Dim objTermo As New Termos()

        If dtDoc.Rows.Count > 0 Then
            Dim row As DataRow = dtDoc.Rows(0)
            objTermo.NUM = Convert.ToInt32(row("NUM"))
            objTermo.TOKEN = row("TOKEN").ToString()
        End If

        Return objTermo
    End Function

    Public Sub Incluir(termo As Termos)
        dal.Incluir(termo)
    End Sub

    Public Sub Atualizar(termo As Termos)
        dal.Atualizar(termo)
    End Sub

    Public Sub Deletar(id As Integer)
        dal.Deletar(id)
    End Sub
End Class
