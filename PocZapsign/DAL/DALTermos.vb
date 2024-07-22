Imports System.CodeDom
Imports System.Data.SqlClient

Public Class DALTermos
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Public Function Listar() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM Termos", conn)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Function ObterTermosPorIntegrante(ByVal IdIntegrante As Integer) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM Termos WHERE NUM = @NUM", conn)
            cmd.Parameters.AddWithValue("@NUM", IdIntegrante)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Sub Incluir(termos As Termos)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO Termos (TOKEN,NUM, TERMOENVIADO, TERMOLINKEMBRANCO,DATAENVIO) VALUES (@TOKEN, @PESSOA_ID, @TERMOENVIADO, @TERMOLINKEMBRANCO,@DATA_ENVIO)", conn)
            cmd.Parameters.AddWithValue("@PESSOA_ID", termos.NUM)
            cmd.Parameters.AddWithValue("@TOKEN", termos.TOKEN)
            cmd.Parameters.AddWithValue("@DATA_ENVIO", If(termos.DATAENVIO Is Nothing, DBNull.Value, termos.DATAENVIO))
            cmd.Parameters.AddWithValue("@DATA_RETORNO", If(termos.DATAASSINATURA Is Nothing, DBNull.Value, termos.DATAASSINATURA))
            cmd.Parameters.Add("@TERMOENVIADO", SqlDbType.VarBinary, -1).Value = If(termos.TERMOENVIADO, DBNull.Value)
            cmd.Parameters.AddWithValue("@TERMOLINKEMBRANCO", If(termos.TERMOLINKEMBRANCO Is Nothing, "", termos.TERMOLINKEMBRANCO))
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Atualizar(termos As Termos)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE Termos SET 
                                  TOKEN = @TOKEN,                                 
                                  TERMOLINKASSINADO = @TERMOLINKASSINADO,                                   
                                  TERMOLINKEMBRANCO = @TERMOLINKEMBRANCO,
                                  DATAASSINATURA = @DATAASSINATURA,
                                  TERMOENVIADO=@TERMOENVIADO,
                                  TERMOASSINADO=@TERMOASSINADO       
                                  WHERE NUM = @ID", conn)

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = termos.NUM
            cmd.Parameters.Add("@TOKEN", SqlDbType.NVarChar, 255).Value = termos.TOKEN
            cmd.Parameters.Add("@TERMOLINKASSINADO", SqlDbType.NVarChar, 255).Value = If(termos.TERMOLINKASSINADO Is Nothing, String.Empty, termos.TERMOLINKASSINADO)
            cmd.Parameters.Add("@TERMOLINKEMBRANCO", SqlDbType.NVarChar, 255).Value = If(termos.TERMOLINKEMBRANCO Is Nothing, String.Empty, termos.TERMOLINKEMBRANCO)
            cmd.Parameters.Add("@DATAASSINATURA", SqlDbType.DateTime).Value = If(termos.DATAASSINATURA Is Nothing, DBNull.Value, termos.DATAASSINATURA)
            cmd.Parameters.Add("@TERMOENVIADO", SqlDbType.VarBinary, -1).Value = If(termos.TERMOENVIADO, DBNull.Value)
            cmd.Parameters.Add("@TERMOASSINADO", SqlDbType.VarBinary, -1).Value = If(termos.TERMOASSINADO, DBNull.Value)

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub


    Public Sub Deletar(id As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("DELETE FROM Termos WHERE NUM=@ID", conn)
            cmd.Parameters.AddWithValue("@ID", id)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class
