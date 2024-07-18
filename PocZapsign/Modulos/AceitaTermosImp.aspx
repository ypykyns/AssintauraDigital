<%@ Page Language="VB" Title="Termo de Aceite" AutoEventWireup="false" CodeFile="AceitaTermosImp.aspx.vb" Inherits="AceitaTermosImp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script type="text/javascript" src="../Scripts/generico.js"></script>
        <link rel="stylesheet" type="text/css" href="../estilos/generico.css" />
    <title>Teste</title>
    <style type="text/css">
        @media print {
            #BtnEnviarAssinatura {
                display: none;
            }
        }

        p.MsoNormal {
            margin-bottom: .0001pt;
            text-align: justify;
            text-justify: inter-ideograph;
            font-family: 'Times New Roman';
            font-size: 10pt;
            margin-left: 0pt;
            margin-right: 0pt;
            margin-top: 0pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width: 95%; margin: 0 auto; padding: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); background-color: #f9f9f9;">
        <asp:Panel ID="Panel1" runat="server">
            <div>
                <div style="display: inline-block;">
                    <img align="left" src="data:image/png;base64, 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" alt="Red dot" style="height: 80px; width: 64px" />
                </div>
                <div style="display: inline-block; float: right;">
                    <img align="right" src="data:image/png;base64, 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" alt="Red dot" style="height: 80px; width: 64px" />
                </div>
                <br />
                <center><b><font size="5">INSANOS MC</font></b></center>
                <br />
                <font size="2">
                    <center><b>Termo de Aceite – Uso de Itens da Marca INSANOS MC (1 a 5) - Uso de Imagem (6) - Uso de dados pessoais Lei 13.709 Lei Geral de Proteção de Dados (7)</b></center>
                </font>
                <center>
                    <asp:Label ID="numero" runat="server" Font-Bold="True" Font-Size="12"></asp:Label>
                </center>
                <font size="2">
                    <asp:Label ID="Nome" runat="server" Font-Bold="True"></asp:Label>
                    , regularmente inscrito no CPF sob nº
                    <asp:Label ID="cpf" runat="server"></asp:Label>
                    , RG sob nº
                    <asp:Label ID="rg" runat="server"></asp:Label>
                    , residente a
                    <asp:Label ID="endereco" runat="server"></asp:Label>
                    , e-mail:
                    <asp:Label ID="email" runat="server"></asp:Label>
                    , telefone
                    <asp:Label ID="telefone" runat="server"></asp:Label>
                    , está ciente que, de acordo com o presente Termo de Aceite, quanto ao uso da marca <b>INSANOS MC</b>, de propriedade da Associação de Motociclistas <b>Insanos Moto Clube – INSANOS MC</b>, regularmente inscrito no CNPJ sob nº 32.197.906/0001-34, assumi o compromisso de manter a guarda pessoal sobre todos os itens de uso exclusivo para Integrantes do <b>INSANOS MC</b>.
                    <br />
                    <br />
                    Para representar a marca <b>INSANOS MC</b>, o integrante obrigatoriamente deverá fazê-lo com as devidas vestimentas, seguindo o padrão normatizado, qual seja, o colete e camisetas oficiais que serão disponibilizados pelo clube mediante ao pagamento de uma taxa de uso da marca. Ao receber o colete e camisetas oficiais dos <b>INSANOS MC</b>, fica o integrante responsável por:<br />
                    <br />
                    1. Adequada utilização, de acordo com o Regimento Disciplinar Interno.
                    <br />
                    2. Comprometer-se a não conceder empréstimo ou confiar a outra pessoa.<br />
                    3. Comunicar, imediatamente ao <b>INSANOS MC</b>, qualquer incidente e ocorrência com os itens sobre sua guarda e responsabilidade.<br />
                    4. Os danos causados por negligência de sua ação ou omissão, como má utilização, guarda inadequada, desleixo ou outro dano que possa ocorrer com os itens, será de sua responsabilidade o reparo ou a reposição.
                    <br />
                    5. Declaro ainda, estar ciente que:
                    <br />
                    &nbsp;&nbsp; 5.1 Todos os itens oficiais de integrantes do <b>INSANOS MC</b>, terão os integrantes apenas o direito de gozo e uso da marca.
                    <br />
                    &nbsp;&nbsp; 5.2 Aceito e concordo que, em caso de desligamento, todos os itens cedidos com a identificação <b>INSANOS MC</b> e <b>EXCLUSIVOS SOMENTE PARA INTEGRANTES</b> deverão, <b>OBRIGATORIAMENTE</b>, serem devolvidos.
                    <br />
                    &nbsp;&nbsp; 5.3 Igualmente estou de acordo que a devolução dos itens será sem ônus para o <b>INSANOS MC.</b><br />
                    &nbsp;&nbsp; 5.4 A não devolução voluntária implicará em multa equivalente a um salário mínimo vigente a época além de serem tomadas medidas legais cabíveis.
                    <br />
                    6. <b>AUTORIZO o INSANOS MC</b>, o uso de minha imagem, sem qualquer ônus e em caráter definitivo. A presente autorização abrangendo inclusive a licença a terceiros, de forma direta ou indireta, e a inserção em materiais para toda e qualquer finalidade, seja para uso comercial, de publicidade, jornalístico, editorial, didático e outros que existam ou venham a existir no futuro, para veiculação/distribuição em território nacional e internacional, por prazo indeterminado. Por esta ser a expressão da minha vontade, declaro que autorizo o uso acima descrito, sem que nada haja a ser reclamado a título de direitos conexos à imagem ora autorizada ou a qualquer outro.
                    <br />
                    7. <b>AUTORIZO o INSANOS MC</b>, em conformidade com a Lei nº 13.709 – Lei Geral de Proteção de Dados Pessoais (LGPD), a tomar decisões e/ou realizar tratamentos referentes aos meus dados pessoais, envolvendo operações como as que se referem a coleta, produção, recepção, classificação, utilização, acesso, reprodução, transmissão, distribuição, processamento, arquivamento, armazenamento, eliminação, avaliação ou controle da informação, modificação, comunicação, transferência, difusão ou extração. O <b>INSANOS MC</b> fica autorizado a compartilhar meus dados para parceiros comerciais ou sociais.
           
                    <br />
                    <div align="left">
                        <asp:Label ID="cidade" runat="server"></asp:Label>
                        ,
                        <asp:Label ID="data" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div id="assinaturaPrincipal" style="text-align: center; margin: 20px auto;">
                        ______________________________________________    
                        <br />
                        Assinatura, Igual ao Documento de Identidade Anexado          
                        <br />
                        Nome:<asp:Label ID="nome1" runat="server"></asp:Label>
                        Cpf:
                        <asp:Label ID="cpf1" runat="server"></asp:Label>
                    </div>
                    <br />
                    Testemunha:
                    <br />
                    Assinatura&nbsp; :______________________________ Nome Completo(Legível): ___________________________________<br />
                    <br />
                    CPF: ___________________ N. no Sistema: ____________ Cargo/Divisão: ____________________________________<br />
                </font>
            </div>
        </asp:Panel>
        <br />
        <div align="center">
            <asp:Button ID="BtnEnviarAssinatura" runat="server" OnClientClick="showLoader();" Text="Enviar Para Assinatura" Width="196px" CssClass="btn btn-primary" />
        </div>
        <div id="divLoadingFitBank" runat="server" style="display: none; width: 100%; height: 100%">
            <div class="divMensagemLoadingFitBank">
                <img src="/imagens/loading-dentalis.png" alt="loading" /><br />
                <br />
                <span></span>
            </div>
        </div>
    </form>
</body>
</html>
