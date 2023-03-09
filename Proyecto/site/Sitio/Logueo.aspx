<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #txtUsuario
        {
            width: 174px;
        }
        #txtPass
        {
            width: 172px;
        }
        .style1
        {
            text-align: right;
        }
        .style2
        {
            width: 257px;
        }
        .style3
        {
            width: 395px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    Logueo de usuario</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Usuario</td>
                <td class="style2">
                    <asp:TextBox ID="txtUsuario" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Contraseña</td>
                <td class="style2">
                    <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" 
                        onclick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
