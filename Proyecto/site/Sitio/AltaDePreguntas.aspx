<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="AltaDePreguntas.aspx.cs" Inherits="AltaDePreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            height: 29px;
        }
        .style5
        {
            height: 31px;
        }
        .style6
        {
            width: 425px;
        }
        .style7
        {
            height: 29px;
            width: 425px;
        }
        .style8
        {
            height: 31px;
            width: 425px;
        }
        .style9
        {
            width: 148px;
        }
        .style10
        {
            height: 29px;
            width: 148px;
        }
        .style11
        {
            height: 31px;
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                Codigo de pregunta</td>
            <td class="style6">
                <asp:Label ID="lblCodigoPregunta" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                Puntaje</td>
            <td class="style6">
                <asp:RadioButtonList ID="rblPuntaje" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Texto de pregunta</td>
            <td class="style7">
                <asp:TextBox ID="txtTextoPregunta" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td class="style4">
                </td>
        </tr>
        <tr>
            <td class="style9">
                Respuesta 1</td>
            <td class="style6">
                <asp:TextBox ID="txtRespuestaUno" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                Respuesta 2</td>
            <td class="style6">
                <asp:TextBox ID="txtRespuestaDos" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                Respuesta 3</td>
            <td class="style6">
                <asp:TextBox ID="txtRespuestaTres" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                Respuesta correcta</td>
            <td class="style6">
                <asp:RadioButtonList ID="rblRespuestaCorrecta" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLimpiarFormulario" runat="server" 
                    onclick="btnLimpiarFormulario_Click" Text="Limpiar formulario" Width="230px" />
            </td>
        </tr>
        <tr>
            <td class="style9">
                Categoria</td>
            <td class="style6">
                <asp:RadioButtonList ID="rblCategorias" runat="server" DataValueField="Codigo" 
                    BorderColor="Black" BorderStyle="Solid" 
                    BorderWidth="1px" RepeatColumns="3" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="btnAgregarPregunta" runat="server" 
                    onclick="btnAgregarPregunta_Click" Text="Agregar pregunta" Width="230px" />
            </td>
        </tr>
        <tr>
            <td class="style11">
                </td>
            <td class="style8">
            </td>
            <td class="style5">
                </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6" style="text-align: center">
                <asp:Label ID="lblError" runat="server" style="text-align: center"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

