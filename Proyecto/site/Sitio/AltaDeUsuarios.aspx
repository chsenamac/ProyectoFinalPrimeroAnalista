<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="AltaDeUsuarios.aspx.cs" Inherits="AltaDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 238px;
        }
        .style5
        {
            width: 238px;
            height: 26px;
        }
        .style6
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td style="text-align: center">
                ALTA DE USUARIO ADMINISTRADOR</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Nombre de usuario</td>
            <td>
                <asp:TextBox ID="txtNombreUsuario" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Nombre completo</td>
            <td>
                <asp:TextBox ID="txtNombreCompleto" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Contraseña</td>
            <td>
                <asp:TextBox ID="txtPassUsuario" runat="server" Width="300px" 
                    TextMode="Password"></asp:TextBox>
                <asp:CheckBox ID="chkPassAdmin" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkPassAdmin_CheckedChanged" Text="Mostrar contraseña" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Confirmación de contraseña</td>
            <td>
                <asp:TextBox ID="txtConfPassUsuario" runat="server" Width="300px" 
                    TextMode="Password"></asp:TextBox>
                <asp:CheckBox ID="chkConfPassAdmin" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkConfPassAdmin_CheckedChanged" 
                    Text="Mostrar confirmacion" />
            </td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

