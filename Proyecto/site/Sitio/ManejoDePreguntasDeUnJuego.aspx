<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdministrador.master" AutoEventWireup="true" CodeFile="ManejoDePreguntasDeUnJuego.aspx.cs" Inherits="ManejoDePreguntasDeUnJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 162px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        Seleccione codigo del Juego</p>
    <p>
        <asp:DropDownList ID="ddlJuego" runat="server" AutoPostBack="True" onselectedindexchanged="ddlJuego_SelectedIndexChanged" 
            >
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width:100%;">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
        <asp:GridView ID="gvPreguntas" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gvPreguntas_SelectedIndexChanged" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" Font-Size="X-Small">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Texto" DataField="TextoPregunta" />
                <asp:BoundField HeaderText="Puntaje" DataField="Puntaje" />
                <asp:CommandField ButtonType="Button" SelectText="Desvincular" 
                    ShowSelectButton="True" HeaderText="Desvincular Pregunta" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="gvPreguntasNoVinculadas" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" 
                        onselectedindexchanged="gvPreguntasNoVinculadas_SelectedIndexChanged" Font-Size="X-Small" 
                       >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TextoPregunta" HeaderText="Texto" />
                            <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                            <asp:CommandField ButtonType="Button" SelectText="Vincular" 
                                ShowSelectButton="True" HeaderText="Vincular Pregunta" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style4">
        <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblErrorAgregarPreguntas" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

