<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CadPessoa.aspx.vb" Inherits="PocZapsign.CadPessoa" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Pessoas</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="../estilos/generico.css" />
    <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../Scripts/generico.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Cadastro de Pessoas</h2>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtCPF" class="col-sm-2 col-form-label">CPF:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtRG" class="col-sm-2 col-form-label">RG:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtRG" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtNome" class="col-sm-2 col-form-label">Nome:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtApelido" class="col-sm-2 col-form-label">Apelido:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtApelido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtEndereco" class="col-sm-2 col-form-label">Endereço:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtNumero" class="col-sm-2 col-form-label">Número:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtComplemento" class="col-sm-2 col-form-label">Complemento:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtBairro" class="col-sm-2 col-form-label">Bairro:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtCidade" class="col-sm-2 col-form-label">Cidade:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtUF" class="col-sm-2 col-form-label">UF:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtUF" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtCEP" class="col-sm-2 col-form-label">CEP:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtTelCel" class="col-sm-2 col-form-label">Telefone Celular:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtTelCel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <label for="txtEmail" class="col-sm-2 col-form-label">Email:</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3" style="margin-top: 1rem;">
                <div class="col-sm-10 offset-sm-2">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClientClick=""/>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../Scripts/Modulos/CadPessoa.js"></script>
</body>
</html>

