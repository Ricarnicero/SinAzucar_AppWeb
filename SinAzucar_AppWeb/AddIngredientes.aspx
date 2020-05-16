<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddIngredientes.aspx.vb" Inherits="AddIngredientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel runat="server">
        <p class="text-muted">Consejo: Puedes agregar varios ingredientes a la vez si los separas por una coma. Por ejemplo: ingrediente1, ingrediente2, ingrediente3, ...</p>
        <telerik:RadTextBox runat="server" ID="txtIngredeiente" EmptyMessage="Ingresa un ingrediente" Label="Ingrediente" Width="100%" TextMode="MultiLine" ></telerik:RadTextBox>
        <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary my-3" Text="Agregar" />
        <telerik:RadGrid runat="server" ID="gridIngredientes" AutoGenerateColumns="true" AllowPaging="true" PageSize="10">
            <MasterTableView Caption="">
            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Content>

