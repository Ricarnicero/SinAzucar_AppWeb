<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPnlGeneral" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server">
        <h2 class="text-center">Inicia sesión</h2>
        <p class="text-center">¿No tienes una cuenta? <a href="Registro.aspx">Registrate</a></p>
        <hr />
        <!-- Login -->
        <div id="divLogin" class="w-75 mx-auto">
            <div class="row">
                <div class="col-md-6">
                    <label>Correo</label>
                    <telerik:RadTextBox runat="server" type="text" ID="txtUsr" CssClass="form-control" placeholder="Correo" autocomplete="email" Width="100%"></telerik:RadTextBox>
                </div>
                <div class="col-md-6">
                    <label>Contraseña</label>
                    <telerik:RadTextBox runat="server" ID="txtPwd" CssClass="form-control" placeholder="Contraseña" autocomplete="current-password" Width="100%" TextMode="Password"></telerik:RadTextBox>
                </div>
            </div>
            <br />
            <asp:Button runat="server" ID="btnLogin" class="btn btn-lg btn-primary btn-block w-50 mx-auto" Text="Iniciar sesión" />
        </div>
    <telerik:RadNotification ID="Notificacion" runat="server" Position="Center" Width="330" Height="160" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true" Style="z-index: 100000">
    </telerik:RadNotification>
    </telerik:RadAjaxPanel>
    <script type="text/javascript" lang="js">
        $("#divLogin").keypress(function () {
            if (arguments[0].key == "Enter") {
                __doPostBack('btnLogin', '')
            }
        });
    </script>
</asp:Content>

