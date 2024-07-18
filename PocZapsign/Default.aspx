<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="PocZapsign._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        validarEmail = function ()  {
            const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            const input = document.getElementById('<%= txtEmail.ClientID %>');
            return regex.test(input.value);
        }

        validaArquivo = function ()  {
            const input = document.getElementById('<%= FileUpload1.ClientID %>');
            const file = input.files[0];

            if (file) {
                const fileName = file.name;
                const fileExtension = fileName.split('.').pop().toLowerCase();

                if (fileExtension !== 'pdf') {
                    alert('Por favor, selecione um arquivo PDF.');
                    input.value = '';
                    return false;
                }
                return true;
            } else {
                alert('Por favor, selecione um arquivo.');
                return false;
            }
        }

        validate = function () {
            
            if (!validarEmail()) {
                alert('Informe um email.');
                return false;
            }
            if (!validaArquivo()) {
                return false;
            }

            return true;
        }
    </script>
    <style>
        .divBotoes {
            text-align: center;
            margin: 10px 0;
        }

        .buttonPadraoGravar {
            background-color: var(--laranja) !important;
        }

        .blocoCad {
            border-radius: 2px;
            background-color: #f8f8f9;
            margin: 5px auto;
            margin-bottom: 15px;
            padding: 15px 10px;
            box-sizing: border-box;
            width: 100%;
            /* box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 2px 1px -2px rgba(0, 0, 0, 0.2), 0 1px 5px 0 rgba(0, 0, 0, 0.12); */
            text-align: left;
            border-collapse: inherit;
        }

        .forminput, .forminput2, .forminputOdoGrid, .forminputcurrency, .forminputespecial, .forminputNotaFisca, .forminputOrange {
            font-size: var(--tamanho-letra-padrao-input);
            font-family: var(--fonte-padrao);
            color: #333333;
            border: 1px solid #d4d4d4;
            background-color: #FFFFFF;
            margin: 2px;
            border-radius: 5px;
            padding: 8px 1px 6px 3px;
        }

        [type=button]:not(:disabled), [type=reset]:not(:disabled), [type=submit]:not(:disabled), button:not(:disabled) {
            cursor: pointer;
        }

        .btnVoltar, .formbutton, input.formbutton30, input.formbutton50, input.formbutton100, input.formbutton110, input.formbutton150, input.formbutton170 {
            background-color: var(--verde);
            border-radius: 2px;
            border: 0;
            font: 13px verdana;
            color: #FFFFFF;
            cursor: pointer;
            padding: 8px 14px;
            text-decoration: none;
        }

        [type=button], [type=reset], [type=submit], button {
            -webkit-appearance: button;
        }

        .buttonPadraoGravar {
            background-color: var(--laranja) !important;
        }

        button, input, optgroup, select, textarea {
            margin: 0;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
        }

        *, ::after, ::before {
            box-sizing: border-box;
        }

        *, ::before, ::after {
            box-sizing: border-box;
        }

        folha de estilo do user agent
        input[type="submit" i] {
            appearance: auto;
            user-select: none;
            align-items: flex-start;
            text-align: center;
            cursor: default;
            box-sizing: border-box;
            background-color: buttonface;
            color: buttontext;
            white-space: pre;
            padding-block: 1px;
            padding-inline: 6px;
            border-width: 2px;
            border-style: outset;
            border-color: buttonborder;
            border-image: initial;
        }

        :root {
            --azul-marinho: #0f0c35;
            --azul-marinho-transparente: #0f0c3596;
            --laranja: #f29100;
            --laranja-transparente: #f291008c;
            --preto20: #dadad9;
            --preto50: #9e9e9b;
            --turquesa: #00a099;
            --turquesa-transparente: #00a0997a;
            --vermelho: #e53328;
            --vermelho-transparente: #e5332882;
            --verde: #00b493;
            --verde-transparente: #00b4938f;
            --letra-clara: #ffffff;
            --letra-escura: #777777;
            --fonte-montserrat: 'Montserrat', sans-serif;
            --fonte-product-sans: 'Product Sans';
            --cor-fundo-interno: #ffffff;
            --cor-fundo: #ffffff;
            --cor-obrigatorio: #DBEEF4;
            --tamanho-letra-padrao-label: 14px;
            --tamanho-letra-padrao-input: 13px;
            --fonte-padrao: Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
        }
    </style>

    <div class="jumbotron">
        <h1>POC Zapsign</h1>
        <p class="lead">Teste de integração com a API de assinatura digital.</p>
    </div>

    <div class="jumbotron">
        <table border="0" width="90%" runat="server" class="blocoCad">
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:FileUpload  style="width: 370px"  ID="FileUpload1" runat="server" accept="application/pdf" onchange="validaArquivo()" />
                </td>
                <td rowspan="4"></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td align="right">
                    <asp:Label ID="lblEmail" runat="server" CssClass="textoverde10">E-Mail</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="forminput" Width="370px" name="txtNome"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div id="divBotoes" class="divBotoes">
            <asp:Button ID="btnEnviar" runat="server" CssClass="formbutton50 buttonPadraoGravar" Text="Enviar" OnClientClick="return validate();"></asp:Button>

            <asp:Button ID="btnCancelar" runat="server" CssClass="formbutton50" Text="Voltar" Visible="false"></asp:Button>
        </div>

    </div>
    <div class="divBotoes">
        <asp:TextBox  Rows="10" Columns="150" TextMode="MultiLine" runat="server" ID="textRetorno"></asp:TextBox>
    </div>
</asp:Content>
