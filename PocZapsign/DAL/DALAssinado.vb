Imports System.Data.SqlClient

Public Class DALDocAssinado
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Public Function ListarDocsAssinados() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT Id, FkPessoas, TokenZap, DocAssinado FROM DocsAssinado", conn)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Sub IncluirDocAssinado(fkPessoas As Integer, tokenZap As String, docAssinado As String)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO DocsAssinado (FkPessoas, TokenZap, DocAssinado) VALUES (@FkPessoas, @TokenZap, @DocAssinado)", conn)
            cmd.Parameters.AddWithValue("@FkPessoas", fkPessoas)
            cmd.Parameters.AddWithValue("@TokenZap", tokenZap)
            cmd.Parameters.AddWithValue("@DocAssinado", docAssinado)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub AtualizarDocAssinado(id As Integer, fkPessoas As Integer, tokenZap As String, docAssinado As String)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE TermosEnvio SET Status = 1, WHERE Id = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", id)
            cmd.Parameters.AddWithValue("@FkPessoas", fkPessoas)
            cmd.Parameters.AddWithValue("@TokenZap", tokenZap)
            cmd.Parameters.AddWithValue("@DocAssinado", docAssinado)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub DeletarDocAssinado(id As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("DELETE FROM DocsAssinado WHERE Id = @Id", conn)
            cmd.Parameters.AddWithValue("@Id", id)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
