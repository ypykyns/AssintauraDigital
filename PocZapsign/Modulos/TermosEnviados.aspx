<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TermosEnviados.aspx.vb" Inherits="PocZapsign.TermosEnviados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Termos Enviados</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="../estilos/generico.css" />
    <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../Scripts/generico.js"></script>
    <script type="text/javascript">
    function verificaTermoSelecionado() {
        var ddl = document.getElementById("DdlPessoas");
             
        if (ddl.value === "0") {
            alert("Selecione um termo para consultar!");
            return false;
        }       
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="mt-5">Verificar Termos Enviados</h1>
                    <div class="form-group">
                        <label for="cmbPessoas">Selecione um usuário:</label>
                        <asp:DropDownList ID="DdlPessoas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div align="left">
                <asp:Button ID="BtnConsultarTermoEnviado" runat="server" OnClientClick="return verificaTermoSelecionado();" Text="Consultar Termo" Width="196px" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>

    <div id="divLoadingFitBank" runat="server" style="display: none; width: 100%; height: 100%">
        <div class="divMensagemLoadingFitBank">
            <img src="/imagens/loading-dentalis.png" alt="loading" /><br />
            <br />
            <span></span>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</body>
</html>

