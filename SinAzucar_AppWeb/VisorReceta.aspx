<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VisorReceta.aspx.vb" Inherits="VisorReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        img {
            color: red;
            -webkit-mask-image: -webkit-gradient(linear, left top, right bottom, from(rgba(0,0,0,.6)), to(rgba(0,0,0,1)));
            max-width:100%!important;

        }
    </style>
    <div class="card" style="width: 100%">
        <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1"
            AutoAdjustImageControlSize="false" AlternateText="Error al cargar la foto" Style="width: 100%; height: 350px; object-fit: cover;" />
        <div class="card-img-overlay text-white" style="text-shadow: 1px 1px 2px black;">
            <h4 class="card-title">
                <b>
                    <asp:Label runat="server" ID="lblTitulo"></asp:Label></b>
                &nbsp;
                            <span style="font-size: .5em">
                                <asp:Label runat="server" ID="lblFecha"></asp:Label>
                            </span>

            </h4>
            <p class="card-text">
                <asp:Label runat="server" ID="lblDescripcion"></asp:Label></p>
            <span>Dificultad:
                <asp:Label runat="server" ID="lblDificultad"></asp:Label></span>
        </div>
    </div>

    <asp:PlaceHolder runat="server" ID="phPasos"></asp:PlaceHolder>
</asp:Content>

