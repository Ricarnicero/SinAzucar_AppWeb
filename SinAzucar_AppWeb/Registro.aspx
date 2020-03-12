<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Registro.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxPanel runat="server" ID="pnlRegistro">
        <div class="text-center">
            <h2>Registro</h2>
            <p>¿Ya tienes una cuenta? <a href="Login.aspx">Inicia sesión</a></p>
        </div>
        <div class="row">
            <div class="col-md">
                <div class="input-group mb-3 w-100">
                    <div class="input-group-prepend w-50">
                        <span class="input-group-text w-100">Nombre</span>
                    </div>
                    <telerik:RadTextBox runat="server" ID="txtNombre" placeholder="Nombre" Width="50%" InputType="Text" autocomplete="name"></telerik:RadTextBox>
                </div>
            </div>
            <div class="col-md">
                <div class="input-group mb-3 w-100">
                    <div class="input-group-prepend w-50">
                        <span class="input-group-text w-100">Correo</span>
                    </div>
                    <telerik:RadTextBox runat="server" ID="txtCorreo" placeholder="Correo" Width="50%" InputType="Text" autocomplete="email"></telerik:RadTextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md">
                <div class="input-group mb-3 w-100">
                    <div class="input-group-prepend w-50">
                        <span class="input-group-text w-100">Contraseña</span>
                    </div>
                    <telerik:RadTextBox runat="server" ID="txtPwd" placeholder="Contraseña" Width="50%" TextMode="Password" onkeyup="demo.checkPasswordMatch()" PasswordStrengthSettings-IndicatorWidth="0px" autocomplete="new-password">
                        <PasswordStrengthSettings ShowIndicator="true" TextStrengthDescriptions="Débil ):;Puede mejorar :/;Segura :);Muy segura :D"
                            IndicatorElementBaseStyle="Base" TextStrengthDescriptionStyles="bg-light;badge badge-danger;badge badge-warning;badge badge-primary;badge badge-success"
                            IndicatorElementID="CustomIndicator"></PasswordStrengthSettings>
                    </telerik:RadTextBox>
                    <div class="d-flex justify-content-end">
                        <span id="CustomIndicator">&nbsp;</span>
                    </div>
                </div>
            </div>
            <div class="col-md">
                <div class="input-group mb-3 w-100">
                    <div class="input-group-prepend w-50">
                        <span class="input-group-text w-100">Repite contraseña</span>
                    </div>
                    <telerik:RadTextBox runat="server" ID="txtPwd2" placeholder="Repite contraseña" Width="50%" TextMode="Password" onkeyup="demo.checkPasswordMatch()" autocomplete="new-password"></telerik:RadTextBox>
                    <div class="d-flex justify-content-between">
                        <span id="PasswordRepeatedIndicator">&nbsp;</span>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button runat="server" ID="btnLogin" class="btn btn-lg btn-primary btn-block w-50 mx-auto" Text="Registrarse" />
        <telerik:RadNotification ID="Notificacion" runat="server" Position="Center" Width="330" Height="160" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true" Style="z-index: 100000">
        </telerik:RadNotification>
    </telerik:RadAjaxPanel>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function pageLoad() {
                demo.textBox1 = $find("<%=txtPwd.ClientID %>");
                demo.textBox2 = $find("<%=txtPwd2.ClientID %>");
                demo.panel = $find("<%=pnlRegistro.ClientID %>");
            }
            ; (function () {
                var demo = window.demo = {};
                function sleep(ms) {
                    return new Promise(resolve => setTimeout(resolve, ms));
                }
                demo.RegistroExitoso =async function () {
                    await sleep(500);
                    demo.panel.get_element().innerHTML = "<div class='text-center'><h2 class='text-success'>¡Registro exitoso!</h2>" +
                        "<p class='text-muted'>Ahora puedes iniciar sesión con tu correo y contraseña.<br/>" +
                        "Redireccionando al inicio de sesion en <span id='countdown'>10</span>" +
                        "<br/> O puedes hacer click <a href='Login.aspx'>aquí</a> para regresar al Login</p>"
                    setInterval(() => {
                        $get("countdown").innerHTML -= 1;
                        if ($get("countdown").innerHTML == 0) window.location = 'Login.aspx';
                    }, 1000)


                }

                demo.CalculatingStrength = function myfunction(sender, args) {
                    if (args.get_passwordText() == "Enter Password") {
                        //Manually set strength Score depending on the input text.
                        args.set_indicatorText("Custom text");
                        args.set_strengthScore(0);
                    }
                    else {
                        var calculatedScore = args.get_strengthScore();
                        //Changing the indicator text depending on the calculated score.
                        args.set_indicatorText("Score: (" + calculatedScore + "/100)");
                    }
                }

                demo.checkPasswordMatch = function () {
                    var text1 = demo.textBox1.get_textBoxValue();
                    var text2 = demo.textBox2.get_textBoxValue();

                    if (text2 == "") {
                        $get("PasswordRepeatedIndicator").innerHTML = "";
                        $get("PasswordRepeatedIndicator").className = "";
                    }
                    else if (text1 == text2) {
                        $get("PasswordRepeatedIndicator").innerHTML = "Coinciden";
                        $get("PasswordRepeatedIndicator").className = "badge badge-success";
                    }
                    else {
                        $get("PasswordRepeatedIndicator").innerHTML = "No coinciden";
                        $get("PasswordRepeatedIndicator").className = "badge badge-danger";
                    }
                }
            })();
        </script>
    </telerik:RadCodeBlock>
</asp:Content>

