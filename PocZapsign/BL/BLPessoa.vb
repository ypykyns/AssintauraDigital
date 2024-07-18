Public Class BLPessoa
    Private ReadOnly dal As New DALPessoa()

    Public Sub ListarPessoasDropDown(ByRef ddl As DropDownList)
        Dim dtPessoas As DataTable = dal.ListarPessoasDropDown()

        ddl.Items.Clear()

        For Each row As DataRow In dtPessoas.Rows
            Dim listItem As New ListItem With {
                .Text = row("NOME").ToString(),
                .Value = row("NUM").ToString()
            }

            ddl.Items.Add(listItem)
        Next

        ddl.Items.Insert(0, New ListItem("Selecione um usuário", "0"))
    End Sub

    Public Function Obter(id As Integer) As Pessoa
        Return dal.Obter(id)
    End Function

    Public Sub Incluir(pessoa As Pessoa)
        dal.Incluir(pessoa)
    End Sub

    Public Sub Atualizar(pessoa As Pessoa)
        dal.Atualizar(pessoa)
    End Sub

    Public Sub Excluir(id As Integer)
        dal.Excluir(id)
    End Sub
End Class
