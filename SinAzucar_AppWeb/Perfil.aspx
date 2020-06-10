<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Perfil.aspx.vb" Inherits="Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel runat="server" ID="pnlLoading"></telerik:RadAjaxLoadingPanel>
    <telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="pnlGeneral" />
    <div id="pnlGeneral" class="bg-light ">
        <fieldset>
            <legend>Mi perfil</legend>
            <div class="container">
                <div class="row">
                    <div class="col-md-2 text-center">
                        <img src="Imagenes/UsuarioAnonimo.jpg" alt="Perfil" class="img-fluid " />
                        <br />
                        <asp:Button runat="server" ID="btnCerrarSesion" Text="Cerrar Sesión" CssClass="btn btn-danger" />
                    </div>
                    <div class="col-md-10">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>
                                        Nombre
                                    </label>
                                    <telerik:RadTextBox runat="server" ID="txtNombre" Width="100%" ReadOnly="true"></telerik:RadTextBox>
                                </div>
                                <div class="col-md-6">
                                    <label>Correo</label>
                                    <telerik:RadTextBox runat="server" ID="txtEmail" Width="100%" ReadOnly="true"></telerik:RadTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Fecha de Nacimiento</label>
                                    <telerik:RadDatePicker runat="server" ID="txtFechaNac" Width="100%"></telerik:RadDatePicker>
                                </div>
                                <div class="col-md-3">
                                    <label>Edad</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtEdad" Width="100%" NumberFormat-DecimalDigits="0" MinValue="0" MaxValue="99" IncrementSettings-Step="1" AutoCompleteType="None"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Altura (metros)</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtAltura" Width="100%" NumberFormat-DecimalDigits="2" NumberFormat-DecimalSeparator="." MinValue="0" MaxValue="2.5" IncrementSettings-Step=".05" AutoCompleteType="None"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Peso (Kg)</label>
                                    <telerik:RadNumericTextBox runat="server" ID="txtPeso" Width="100%" NumberFormat-DecimalDigits="2" NumberFormat-DecimalSeparator="." MinValue="0" MaxValue="200" AutoCompleteType="None"></telerik:RadNumericTextBox>
                                </div>
                                <div class="col-12">
                                    <telerik:RadAjaxPanel runat="server">
                                        <label>Ingredientes a <u>evitar</u></label>
                                        <telerik:RadAutoCompleteBox runat="server" ID="acbIngredientes" EmptyMessage="Selecciona Ingredientes" InputType="Token" AllowCustomEntry="false" HighlightFirstMatch="true" TokensSettings-AllowTokenEditing="false" Delimiter="," MaxResultCount="5" Width="100%" AutoPostBack="true">
                                        </telerik:RadAutoCompleteBox>
                                    </telerik:RadAjaxPanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="text-center my-2">
                    <telerik:RadButton runat="server" ID="btnguardarPerfil" Text="Actualizar perfil" CssClass="bg-success text-white border-0" />
                </div>
            </div>
        </fieldset>
        <fieldset>
            <legend>
                Seguridad de la cuenta
            </legend>
            <div class="container">
                <h3>Cambiar contraseña</h3>
                <div class="row">
                    <div class="col-md-4">
                        <label>Contraseña actual</label>
                        <telerik:RadTextBox runat="server" ID="txtContrasenaActual" TextMode="Password" autocomplete="current-password" Width="100%"></telerik:RadTextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Nueva contraseña</label>
                        <telerik:RadTextBox runat="server" ID="txtNuevacontrasena" TextMode="Password" autocomplete="new-password" Width="100%"></telerik:RadTextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Confirmar contraseña</label>
                        <telerik:RadTextBox runat="server" ID="txtConfirmarContrasena" TextMode="Password" autocomplete="new-password" Width="100%"></telerik:RadTextBox>
                    </div>
                </div>
                <div class="text-center my-2">
                    <telerik:RadButton runat="server" ID="btnActualizarContrasena" Text="Actualizar contraseña" CssClass="bg-success text-white border-0" />
                </div>
            </div>
        </fieldset>
    </div>
    <telerik:RadNotification runat="server" ID="RN1" AutoCloseDelay="3000" KeepOnMouseOver="true" Position="Center" ShowCloseButton="true"></telerik:RadNotification>
</asp:Content>

