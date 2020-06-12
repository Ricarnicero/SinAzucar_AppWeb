<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfirmarRecetas.aspx.vb" Inherits="ConfirmarRecetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="text-center">
        <h1>Revisión de recetas</h1>
        <p>
            Revisa que las recetas que sean para diabeticos. No puedes revisar las recetas que tu hayas subido.
        </p>
    </div>
    <telerik:RadGrid runat="server" ID="gridConfirmacion" AutoGenerateColumns="false" AllowPaging="true" PageSize="5">
        <MasterTableView EditMode="PopUp">
            <Columns>
                <telerik:GridButtonColumn ButtonType="PushButton" ButtonCssClass="bg-success text-white rounded border-0" Text="Ver" HeaderText="Mostrar contenido" CommandName="Edit"></telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="ID" Display="false"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Descripción de la receta">
                    <ItemTemplate>
                        <div class="media">
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%# IIf(DataBinder.Eval(Container.DataItem, "FOTO") IsNot DBNull.Value, DataBinder.Eval(Container.DataItem, "FOTO"), New System.Byte(-1) {})%>'
                                AutoAdjustImageControlSize="false" ToolTip='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Foto de {0}") %>'
                                AlternateText='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Ups! No podemos mostrar la foto de {0}") %>' Style="width: 64px; height: 64px;" />
                            <div class="media-body">
                                <h5 class="mt-0"><b><%# DataBinder.Eval(Container.DataItem, "NOMBRE") %></b>&nbsp;<span style="font-size: .5em"><%# DataBinder.Eval(Container.DataItem, "FECHA").ToString.Substring(0, 10) %></span></h5>
                                <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "DESCRIPCION") %></p>
                                <span>Dificultad: <%# GetFaceDificult(DataBinder.Eval(Container.DataItem, "DIFICULTAD"))%> </span>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <NoRecordsTemplate>
                <div class="text-center">
                    Todas las recetas han sido validadas
                </div>
            </NoRecordsTemplate>
            <EditFormSettings EditFormType="WebUserControl" UserControlName="ConfirmarReceta.ascx">
                <PopUpSettings CloseButtonToolTip="true" KeepInScreenBounds="true" Height="90%" Width="90%" Modal="true" ScrollBars="Auto" />
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
    <div class="text-center my-2">
        <h3>Estatus de mis recetas</h3>
        <p>En este apartado puedes ver el estatus de tus recetas que has subido</p>
        <telerik:RadGrid runat="server" ID="gridMisRecetas" AutoGenerateColumns="false" AllowPaging="true" PageSize="5">
        <MasterTableView>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="Estatus">
                    <ItemTemplate>
                        <label class='<%# DataBinder.Eval(Container.DataItem, "CSS") %>'>
                            <%# DataBinder.Eval(Container.DataItem, "ESTATUS") %>
                        </label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Descripción de la receta">
                    <ItemTemplate>
                        <div class="media">
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%# IIf(DataBinder.Eval(Container.DataItem, "FOTO") IsNot DBNull.Value, DataBinder.Eval(Container.DataItem, "FOTO"), New System.Byte(-1) {})%>'
                                AutoAdjustImageControlSize="false" ToolTip='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Foto de {0}") %>'
                                AlternateText='<%#DataBinder.Eval(Container.DataItem, "NOMBRE", "Ups! No podemos mostrar la foto de {0}") %>' Style="width: 64px; height: 64px;" />
                            <div class="media-body">
                                <h5 class="mt-0"><b><%# DataBinder.Eval(Container.DataItem, "NOMBRE") %></b>&nbsp;<span style="font-size: .5em"><%# DataBinder.Eval(Container.DataItem, "FECHA").ToString.Substring(0, 10) %></span></h5>
                                <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "DESCRIPCION") %></p>
                                <span>Dificultad: <%# GetFaceDificult(DataBinder.Eval(Container.DataItem, "DIFICULTAD"))%> </span>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <NoRecordsTemplate>
                <div class="text-center">
                    No has subido recetas
                </div>
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
    </div>
    <telerik:RadNotification runat="server" ID="rn1" KeepOnMouseOver="true" AutoCloseDelay="3000" Position="Center" ShowCloseButton="true"></telerik:RadNotification>
</asp:Content>

