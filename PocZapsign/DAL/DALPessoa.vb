Imports System.Data.SqlClient

Public Class DALPessoa
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Public Function ListarPessoasDropDown() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT NUM, NOME FROM Integrantes", conn)
            conn.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using
        End Using
        Return dt
    End Function

    Public Function Obter(ByVal Id As Integer) As Pessoa
        Dim pessoa As New Pessoa()
        Dim query As String = "SELECT * FROM Integrantes WHERE NUM=@ID"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", Id)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        pessoa.ID = Convert.ToInt32(reader("NUM"))
                        pessoa.CPF = reader("CPF").ToString()
                        pessoa.RG = If(IsDBNull(reader("RG")), String.Empty, reader("RG").ToString())
                        pessoa.Nome = reader("NOME").ToString()
                        pessoa.Apelido = If(IsDBNull(reader("APELIDO")), String.Empty, reader("APELIDO").ToString())
                        pessoa.Endereco = If(IsDBNull(reader("ENDERECO")), String.Empty, reader("ENDERECO").ToString())
                        pessoa.Numero = If(IsDBNull(reader("NUMERO")), String.Empty, reader("NUMERO").ToString())
                        pessoa.Complemento = If(IsDBNull(reader("COMPLEMENTO")), String.Empty, reader("COMPLEMENTO").ToString())
                        pessoa.Bairro = If(IsDBNull(reader("BAIRRO")), String.Empty, reader("BAIRRO").ToString())
                        pessoa.Cidade = If(IsDBNull(reader("CIDADE")), String.Empty, reader("CIDADE").ToString())
                        pessoa.UF = If(IsDBNull(reader("UF")), String.Empty, reader("UF").ToString())
                        pessoa.CEP = If(IsDBNull(reader("CEP")), String.Empty, reader("CEP").ToString())
                        pessoa.TelCel = If(IsDBNull(reader("TELCEL")), String.Empty, reader("TELCEL").ToString())
                        pessoa.Email = If(IsDBNull(reader("EMAIL")), String.Empty, reader("EMAIL").ToString())
                    Else
                        pessoa = Nothing
                    End If
                End Using
            End Using
        End Using
        Return pessoa
    End Function

    Public Sub Incluir(pessoa As Pessoa)
        Dim query As String = "INSERT INTO Integrantes (CPF, RG, NOME, APELIDO, ENDERECO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, UF, CEP, TELCEL, EMAIL) VALUES (@CPF, @RG, @NOME, @APELIDO, @ENDERECO, @NUMERO, @COMPLEMENTO, @BAIRRO, @CIDADE, @UF, @CEP, @TELCEL, @EMAIL)"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@CPF", pessoa.CPF)
                cmd.Parameters.AddWithValue("@RG", pessoa.RG)
                cmd.Parameters.AddWithValue("@NOME", pessoa.Nome)
                cmd.Parameters.AddWithValue("@APELIDO", pessoa.Apelido)
                cmd.Parameters.AddWithValue("@ENDERECO", pessoa.Endereco)
                cmd.Parameters.AddWithValue("@NUMERO", pessoa.Numero)
                cmd.Parameters.AddWithValue("@COMPLEMENTO", pessoa.Complemento)
                cmd.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro)
                cmd.Parameters.AddWithValue("@CIDADE", pessoa.Cidade)
                cmd.Parameters.AddWithValue("@UF", pessoa.UF)
                cmd.Parameters.AddWithValue("@CEP", pessoa.CEP)
                cmd.Parameters.AddWithValue("@TELCEL", pessoa.TelCel)
                cmd.Parameters.AddWithValue("@EMAIL", pessoa.Email)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Atualizar(pessoa As Pessoa)
        Dim query As String = "UPDATE Integrantes SET CPF=@CPF, RG=@RG, NOME=@NOME, APELIDO=@APELIDO, ENDERECO=@ENDERECO, NUMERO=@NUMERO, COMPLEMENTO=@COMPLEMENTO, BAIRRO=@BAIRRO, CIDADE=@CIDADE, UF=@UF, CEP=@CEP, TELCEL=@TELCEL, EMAIL=@EMAIL WHERE ID=@ID"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", pessoa.ID)
                cmd.Parameters.AddWithValue("@CPF", pessoa.CPF)
                cmd.Parameters.AddWithValue("@RG", pessoa.RG)
                cmd.Parameters.AddWithValue("@NOME", pessoa.Nome)
                cmd.Parameters.AddWithValue("@APELIDO", pessoa.Apelido)
                cmd.Parameters.AddWithValue("@ENDERECO", pessoa.Endereco)
                cmd.Parameters.AddWithValue("@NUMERO", pessoa.Numero)
                cmd.Parameters.AddWithValue("@COMPLEMENTO", pessoa.Complemento)
                cmd.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro)
                cmd.Parameters.AddWithValue("@CIDADE", pessoa.Cidade)
                cmd.Parameters.AddWithValue("@UF", pessoa.UF)
                cmd.Parameters.AddWithValue("@CEP", pessoa.CEP)
                cmd.Parameters.AddWithValue("@TELCEL", pessoa.TelCel)
                cmd.Parameters.AddWithValue("@EMAIL", pessoa.Email)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Excluir(id As Integer)
        Dim query As String = "DELETE FROM Integrantes WHERE ID=@ID"
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
