<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmarRecetas.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadGrid runat="server" ID="gridConfirmacion" AutoGenerateColumns="false">
        <MasterTableView>
            <Columns>
                <telerik:GridButtonColumn ButtonType="PushButton" ButtonCssClass="bg-success text-white rounded border-0" Text="Ver"></telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="ID"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%# IIf(DataBinder.Eval(Container.DataItem, "FOTO") IsNot DBNull.Value, DataBinder.Eval(Container.DataItem, "FOTO"), New System.Byte(-1) {})%>'
                            AutoAdjustImageControlSize="false" ToolTip='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Foto de {0}") %>'
                            AlternateText='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Ups! No podemos mostrar la foto de {0}") %>' Style="width: 64px; height: 64px;" />
                        <div class="media-body">
                            <h5 class="mt-0"><b><%# DataBinder.Eval(Container.DataItem, "NOMBRE") %></b>&nbsp;<span style="font-size: .5em"><%# DataBinder.Eval(Container.DataItem, "FECHA").ToString.Substring(0, 10) %></span></h5>
                            <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "DESCRIPCION") %></p>
                            <span>Dificultad: <%# GetFaceDificult(DataBinder.Eval(Container.DataItem, "DIFICULTAD"))%> </span>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>

