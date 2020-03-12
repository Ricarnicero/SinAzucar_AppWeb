<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddIngredientes.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadAjaxPanel runat="server" >
    <telerik:RadTextBox runat="server" ID="txtIngredeiente" EmptyMessage="Ingresa un ingrediente" Label="Ingrediente" Width="300px"></telerik:RadTextBox>
    <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary my-3" Text="Agregar"/>
    <telerik:RadGrid runat="server" ID="gridIngredientes" AutoGenerateColumns="true" AllowPaging="true" PageSize="10">
        <MasterTableView Caption="">
        </MasterTableView>
    </telerik:RadGrid>
        </telerik:RadAjaxPanel>
</asp:Content>

