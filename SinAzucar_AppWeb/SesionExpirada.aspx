<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SesionExpirada.aspx.vb" Inherits="SesionExpirada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Fin de sesión</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Estilos/Modulos.css" rel="stylesheet" />
    <link href="Estilos/General.css" rel="stylesheet" />
    <link href="Estilos/w3.css" rel="stylesheet" />
    <link href="Estilos/bootstrap.min.css" rel="stylesheet" />

</head>
<body onkeypress="window.location.href = 'Login.aspx'">
    <form id="form1" runat="server">
        <div class="row w3-padding" style="height: 60px">
            <div class="col-2 w3-hide-small">
                <img src="Imagenes/ImgLogo_Cliente.png" alt="MC Collect S.A. de C.V." class="img-fluid" style="max-height: 50px;" />
            </div>
            <div class="col-7 w3-xlarge w3-center">
                <span class="font-weight-light">Su Sesión Ha Caducado</span>
            </div>
            <div class="col-2">
                <asp:Button runat="server" ID="btnCerrarSesion" Text="Aceptar" CssClass="w3-green w3-text-white btn w3-hover-shadow"></asp:Button>
            </div>
            <div class="col-1 w3-hide-small">
                <img src="Imagenes/ImgLogo_Mc.png" alt="MC Collect S.A. de C.V." style="max-height: 50px;" class="img-fluid w3-right" />
            </div>
        </div>
    </form>
</body>
</html>
