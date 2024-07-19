Imports System.Data.SqlClient

Public Class DALTermosEnvio
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM TermosEnvio", conn)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Function ObterTermosPorPessoa(ByVal pessoaId As Integer) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM TermosEnvio WHERE NUM = @PESSOA_ID", conn)
            cmd.Parameters.AddWithValue("@PESSOA_ID", pessoaId)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Function Obter(ByVal Id As Integer) As TermosEnvio
        Dim termosEnvio As New TermosEnvio()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM TERMOSENVIO WHERE NUM=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", Id)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    termosEnvio.NUM = Convert.ToInt32(reader("ID"))
                    termosEnvio.TOKEN = reader("TOKEN").ToString()
                    termosEnvio.DATAENVIO = If(IsDBNull(reader("DATA_ENVIO")), Nothing, Convert.ToDateTime(reader("DATA_ENVIO")))
                    termosEnvio.STATUS = If(IsDBNull(reader("STATUS")), String.Empty, reader("STATUS").ToString())
                    termosEnvio.DATARETORNO = If(IsDBNull(reader("DATA_RETORNO")), Nothing, Convert.ToDateTime(reader("DATA_RETORNO")))
                    termosEnvio.NUM = Convert.ToInt32(reader("PESSOA_ID"))
                Else
                    termosEnvio = Nothing
                End If
            End Using
        End Using
        Return termosEnvio
    End Function

    Public Sub Incluir(termosEnvio As TermosEnvio)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO TermosEnvio (TOKEN, DATAENVIO, STATUS, DATARETORNO, NUM, TERMO) VALUES (@TOKEN, @DATA_ENVIO, @STATUS, @DATA_RETORNO, @PESSOA_ID, @TERMO)", conn)
            cmd.Parameters.AddWithValue("@PESSOA_ID", termosEnvio.NUM)
            cmd.Parameters.AddWithValue("@TOKEN", termosEnvio.TOKEN)
            cmd.Parameters.AddWithValue("@DATA_ENVIO", If(termosEnvio.DATAENVIO Is Nothing, DBNull.Value, termosEnvio.DATAENVIO))
            cmd.Parameters.AddWithValue("@STATUS", termosEnvio.STATUS)
            cmd.Parameters.AddWithValue("@DATA_RETORNO", If(termosEnvio.DATARETORNO Is Nothing, DBNull.Value, termosEnvio.DATARETORNO))
            cmd.Parameters.AddWithValue("@TERMO", If(termosEnvio.TERMO Is Nothing, "", termosEnvio.TERMO))
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Atualizar(termosEnvio As TermosEnvio)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE TermosEnvio SET TOKEN=@TOKEN, DATAENVIO=@DATA_ENVIO, STATUS=@STATUS, DATARETORNO=@DATA_RETORNO, NUM=@PESSOA_ID WHERE NUM=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", termosEnvio.NUM)
            cmd.Parameters.AddWithValue("@TOKEN", termosEnvio.TOKEN)
            cmd.Parameters.AddWithValue("@DATA_ENVIO", If(termosEnvio.DATAENVIO Is Nothing, DBNull.Value, termosEnvio.DATAENVIO))
            cmd.Parameters.AddWithValue("@STATUS", termosEnvio.STATUS)
            cmd.Parameters.AddWithValue("@DATA_RETORNO", If(termosEnvio.DATARETORNO Is Nothing, DBNull.Value, termosEnvio.DATARETORNO))
            cmd.Parameters.AddWithValue("@PESSOA_ID", termosEnvio.NUM)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Deletar(id As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("DELETE FROM TermosEnvio WHERE NUM=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", id)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
