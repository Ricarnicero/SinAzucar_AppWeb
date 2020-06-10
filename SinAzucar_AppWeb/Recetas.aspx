<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Recetas.aspx.vb" Inherits="Recetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .text-box {
            margin: 0px;
            background-color: rgba(183, 252, 179, 0.3);
            border: 0px solid black;
            width: 100%;
        }

        img {
            color: red;
            -webkit-mask-image: -webkit-gradient(linear, left top, right bottom, from(rgba(0,0,0,.6)), to(rgba(0,0,0,1)));
        }
    </style>
    <telerik:RadSearchBox runat="server" ID="sbRecetas" HighlightFirstMatch="true" EmptyMessage="Buscar receta" Width="100%" ShowSearchButton="true">
        <SearchContext ShowDefaultItem="false">
            <Items>
                <telerik:SearchContextItem Text="Nombre" Key="0" />
                <telerik:SearchContextItem Text="Dificultad" Key="1" />
                <telerik:SearchContextItem Text="Ingrediente" Key="2" />
            </Items>
        </SearchContext>
        <DropDownSettings>
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
        </DropDownSettings>
    </telerik:RadSearchBox>
    <h2 class="text-center">Recetas</h2>
    <telerik:RadListView runat="server" ID="lvRecetas" ItemPlaceholderID="lvContainer">
        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="lvContainer"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-10 mx-auto my-2 p-0 border-0 bg-white" id="<%# Eval("ID") %>" onclick="RecetaClick(this)">
                <div class="card" style="width: 100%">
                    <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%# IIf(Eval("FOTO") IsNot DBNull.Value, Eval("FOTO"), New System.Byte(-1) {})%>'
                        AutoAdjustImageControlSize="false" ToolTip='<%#Eval("NOMBRE", "Foto de {0}") %>'
                        AlternateText='<%#Eval("NOMBRE", "Ups! No podemos mostrar la foto de {0}") %>' Style="width: 100%; height: 350px; object-fit: cover;" />
                    <div class="card-img-overlay text-white" style="text-shadow: 1px 1px 2px black;">
                        <h4 class="card-title"><b><%# Eval("NOMBRE") %></b>&nbsp;<span style="font-size: .5em"><%# Eval("FECHA").ToString.Substring(0, 10) %></span></h4>
                        <p class="card-text"><%# Eval("DESCRIPCION") %></p>
                        <span>Dificultad: <%# GetFaceDificult(Eval("DIFICULTAD"))%> </span>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </telerik:RadListView>
    <script type="text/javascript">
        function RecetaClick(e) {
            window.location.href = "VisorReceta.aspx?id=" + e.id
        }
    </script>
</asp:Content>
