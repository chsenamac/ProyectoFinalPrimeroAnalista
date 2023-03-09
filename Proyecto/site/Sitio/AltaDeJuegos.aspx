<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="AltaDeJuegos.aspx.cs" Inherits="AltaDeJuegos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                Alta de juegos</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Dificultad</td>
            <td>
                <asp:DropDownList ID="ddlDificultad" runat="server" Width="230px">
                    <asp:ListItem>Facil</asp:ListItem>
                    <asp:ListItem>Medio</asp:ListItem>
                    <asp:ListItem>Dificil</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAltaJuego" runat="server" onclick="btnAltaJuego_Click" 
                    Text="Agregar Juego" Width="230px" />
            </td>
        </tr>
        <tr>
            <td>
                Creador</td>
            <td>
                <asp:Label ID="lblAdministrador" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnAsociarPreguntas" runat="server" Text="Asociar preguntas" 
                    Width="230px" onclick="btnAsociarPreguntas_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLimpiarFormulario" runat="server" Text="Limpiar formulario" 
                    Width="230px" onclick="btnLimpiarFormulario_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

