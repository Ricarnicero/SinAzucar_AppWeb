<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VisorReceta.aspx.vb" Inherits="VisorReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="Receta" />

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
    <div class="container">
        <div class="row justify-content-lg-between justify-content-center mb-3">
            <div class="col-md-3">
                <asp:Label runat="server" ID="lblFecha"></asp:Label>
            </div>
            <div class="col-md-2">
                <telerik:RadSocialShare ID="ssOptions" runat="server">
                    <MainButtons>
                        <telerik:RadSocialButton SocialNetType="ShareOnFacebook"></telerik:RadSocialButton>
                        <telerik:RadSocialButton SocialNetType="ShareOnTwitter"></telerik:RadSocialButton>
                        <telerik:RadSocialButton SocialNetType="MailTo"></telerik:RadSocialButton>
                    </MainButtons>
                </telerik:RadSocialShare>
            </div>
        </div>
    </div>
    <div id="Receta" class="bg-light">
        <fieldset>
            <legend>Descripción</legend>
            <asp:Label runat="server" ID="lblDescripcion"></asp:Label>

        </fieldset>

        <div class="container">
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
    </div>
    <hr />
    <telerik:RadAjaxPanel runat="server" CssClass="container">
        <div runat="server" id="divCalificacion" class="my-2">
            <label>¿Te gustó esta receta? Calificala</label>
            <telerik:RadRating runat="server" ID="txtDificultad" Width="100%" Precision="Half" SelectionMode="Continuous" AutoPostBack="true"></telerik:RadRating>
        </div>
        <h3>Comentarios</h3>
        <asp:Panel runat="server" ID="pnlAddComentario">
            <label>Agrega un comentario</label>
            <telerik:RadTextBox runat="server" ID="txtComentario" TextMode="MultiLine" Width="100%" Height="100px" EmptyMessage="Escribe un comentario"></telerik:RadTextBox>
            <telerik:RadButton runat="server" ID="btnAddComentario" Text="Publicar" CssClass="bg-primary text-white border-0 my-2"></telerik:RadButton>
        </asp:Panel>
        <telerik:RadListView runat="server" ID="lvComentarios" ItemPlaceholderID="phComentarios">
            <LayoutTemplate>
                <ul class="list-unstyled">
                    <asp:PlaceHolder runat="server" ID="phComentarios"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li class="media my-2 border rounded bg-white p-2 ">
                    <img src="Imagenes/comentario.png" style="width: 64px; height: auto;" />
                    <div class="media-body">
                        <h5 class="mt-0 mb-1"><%#Eval("USUARIO")%> <span class="text-muted" style="font-size: .6em"><%#Eval("FECHA")%></span></h5>

                        <%#Eval("COMENTARIO")%>
                    </div>
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                ¡Sé el primero en comentar!
            </EmptyDataTemplate>
        </telerik:RadListView>
    </telerik:RadAjaxPanel>
</asp:Content>

