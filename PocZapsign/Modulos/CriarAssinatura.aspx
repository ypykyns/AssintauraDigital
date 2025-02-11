﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CriarAssinatura.aspx.vb" Inherits="PocZapsign.CriarAssinatura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Assinatura Digital</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="../estilos/generico.css" />
    <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="../Scripts/generico.js"></script>
    <script type="text/javascript">
        function verificarEnviado() {
            var ddl = document.getElementById("cmbPessoas");
            var selectedOption = ddl.options[ddl.selectedIndex];
            var enviado = selectedOption.getAttribute("data-enviado");

            if (enviado === "true") {
                alert("O documento já foi enviado para este usuário.");
                return false;
            }

            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 d-flex justify-content-between align-items-center">
                    <h2 class="mt-5">Assinatura Digital</h2>
                    <asp:Button ID="BtnTermosEnviados" runat="server" CssClass="btn btn-secondary" Text="Consultar Termos Enviados" PostBackUrl="TermosEnviados.aspx"/>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="cmbPessoas">Selecione um usuário:</label>
                        <asp:DropDownList ID="DdlPessoas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnGerarAssinatura" runat="server" CssClass="btn btn-primary" OnClientClick="showLoader(); return verificarEnviado();" Text="Gerar Assinatura" />
                    </div>
                </div>
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
