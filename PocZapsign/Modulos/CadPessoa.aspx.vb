Public Class CadPessoa
    Inherits System.Web.UI.Page

    Private ReadOnly objBlPessoa As New BLPessoa()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pessoaID As String = Request.QueryString("id")
            If Not String.IsNullOrEmpty(pessoaID) Then
                Dim id As Integer
                If Integer.TryParse(pessoaID, id) Then
                    CarregarPessoa(id)
                End If
            End If
        End If
    End Sub

    Protected Sub BtnSalvar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalvar.Click
        Try

            Dim pessoa As New Pessoa With {
            .CPF = txtCPF.Text,
            .RG = txtRG.Text,
            .Nome = txtNome.Text,
            .Apelido = txtApelido.Text,
            .Endereco = txtEndereco.Text,
            .Numero = txtNumero.Text,
            .Complemento = txtComplemento.Text,
            .Bairro = txtBairro.Text,
            .Cidade = txtCidade.Text,
            .UF = txtUF.Text,
            .CEP = txtCEP.Text,
            .TelCel = txtTelCel.Text,
            .Email = txtEmail.Text
        }

            If Not ValidaCPF(pessoa.CPF) Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Informe um CPF valido!');", True)
            ElseIf pessoa.Nome.Length < 3 Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Informe um Nome!');", True)
            ElseIf Not ValidaEmail(pessoa.Email) Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Informe um e-mail valido!');", True)
            Else
                Dim pessoaID As String = Request.QueryString("id")
                If Not String.IsNullOrEmpty(pessoaID) Then
                    Dim id As Integer
                    If Integer.TryParse(pessoaID, id) Then
                        pessoa.ID = id
                        objBlPessoa.Atualizar(pessoa)
                        ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Cadastro Atualizado com sucesso!');", True)
                    End If
                Else
                    objBlPessoa.Incluir(pessoa)
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Cadastro Incluido com sucesso!');", True)
                End If

                Response.Redirect("CriarAssinatura.aspx")
            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Erro ao gravar a pessoa!\n" & ex.Message & "');", True)
        End Try
    End Sub

    Private Function ValidaCPF(cpf As String) As Boolean
        cpf = cpf.Replace(".", "").Replace("-", "")

        If cpf.Length <> 11 OrElse cpf.All(Function(c) c = cpf(0)) Then Return False

        Dim add As Integer = 0
        For i As Integer = 0 To 8
            add += CInt(cpf(i).ToString()) * (10 - i)
        Next

        Dim rev As Integer = 11 - (add Mod 11)
        If rev = 10 Or rev = 11 Then rev = 0
        If rev <> CInt(cpf(9).ToString()) Then Return False

        add = 0
        For i As Integer = 0 To 9
            add += CInt(cpf(i).ToString()) * (11 - i)
        Next

        rev = 11 - (add Mod 11)
        If rev = 10 Or rev = 11 Then rev = 0
        If rev <> CInt(cpf(10).ToString()) Then Return False

        Return True
    End Function

    Private Sub CarregarPessoa(id As Integer)
        Dim pessoa As Pessoa = objBlPessoa.Obter(id)
        If pessoa IsNot Nothing Then
            txtCPF.Text = pessoa.CPF
            txtRG.Text = pessoa.RG
            txtNome.Text = pessoa.Nome
            txtApelido.Text = pessoa.Apelido
            txtEndereco.Text = pessoa.Endereco
            txtNumero.Text = pessoa.Numero
            txtComplemento.Text = pessoa.Complemento
            txtBairro.Text = pessoa.Bairro
            txtCidade.Text = pessoa.Cidade
            txtUF.Text = pessoa.UF
            txtCEP.Text = pessoa.CEP
            txtTelCel.Text = pessoa.TelCel
            txtEmail.Text = pessoa.Email
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Cadastro não encontrado!');", True)
            Response.Redirect(Request.Url.GetLeftPart(UriPartial.Path), True)
        End If
    End Sub

    Private Function ValidaEmail(email As String) As Boolean
        ' Expressão regular para validar o formato do email.
        Dim emailPattern As String = "^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$"
        ' Verifica se o email corresponde ao padrão especificado.
        Return Regex.IsMatch(email, emailPattern)
    End Function

End Class