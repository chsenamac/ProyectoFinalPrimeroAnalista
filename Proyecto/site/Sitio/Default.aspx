<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="resources/css/general.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Logueo.aspx" CssClass="style2">Login</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                BIENVENIDOS AL JUEGO DE PREGUNTAS Y RESPUESTAS
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:ImageButton ID="imgButtonJugar" runat="server" Height="65px" ImageUrl="~/resources/images/btnJugar.png"
                    OnClick="imgButtonJugar_Click" Width="147px" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvJugadas" runat="server" Width="625px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        </table>
        <table class="Pie">
        <tr>
            <td>
                Proyecto final de primer año - Cristian Capretti - Christiams Sena - Año 2022 - 2023</td>
        </tr>
    </table>

    </form>
</body>
</html>
