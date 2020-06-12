<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConfirmarReceta.ascx.vb" Inherits="ConfirmarReceta" %>
<telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="Receta" />
<div class="p-3">
    <style>
        img {
            max-width: 100%;
            max-height: 350px;
            object-fit: cover;
        }
    </style>
    <div class="text-center">
        <asp:Label runat="server" ID="lblTitulo" CssClass="h2 text-center"></asp:Label>
        <br />
        <span>Dificultad:
                <asp:Label runat="server" ID="lblDificultad"></asp:Label>
            / 5</span>

    </div>
    <div class="card" style="width: 100%">
        <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1"
            AutoAdjustImageControlSize="false" AlternateText="Error al cargar la foto" Style="width: 100%; height: 350px; object-fit: cover;" CssClass="rounded-lg shadow-sm border-0" />
    </div>
    <div class="text-right">
        <asp:Label runat="server" ID="lblFecha"></asp:Label>
    </div>
    <br />
    <div id="Receta" class="container">
        <fieldset>
            <legend>Descripción</legend>
            <asp:Label runat="server" ID="lblDescripcion"></asp:Label>

        </fieldset>


        <div class="row">
            <div class="col-md-6">
                <fieldset>
                    <legend>Ingredientes</legend>
                    <telerik:RadListView runat="server" ID="lvIngredientes" ItemPlaceholderID="phPasos">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="phPasos"></asp:PlaceHolder>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <%#Eval("CANTIDAD") & " " & Eval("MEDIDA") & " de " & Eval("INGREDIENTE")%>
                            </li>
                        </ItemTemplate>
                    </telerik:RadListView>
                </fieldset>
            </div>
            <div class="col-md-6">
                <fieldset>
                    <legend>Pasos a seguir</legend>
                    <asp:PlaceHolder runat="server" ID="phPasos"></asp:PlaceHolder>
                </fieldset>
            </div>
        </div>
    </div>
    <hr />
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-3">
                <telerik:RadButton ID="btnInsert" Text="Aprobar receta" runat="server" CommandName="Aprobar" CommandArgument='<%# DataItem("ID") %>' AutoPostBack="true" CssClass="bg-success text-white border-0">
                </telerik:RadButton>
            </div>
            <div class="col-3">
                <telerik:RadButton ID="RBtnCacelar" runat="server" Text="Rechazar receta" CommandName="Rechazar" CausesValidation="false" CssClass="bg-danger text-white border-0"></telerik:RadButton>

            </div>
        </div>
    </div>

</div>
