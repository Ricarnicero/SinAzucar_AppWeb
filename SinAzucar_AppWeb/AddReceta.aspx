<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddReceta.aspx.vb" Inherits="AddReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Estilos/EditorTools.css" rel="stylesheet" />
    <telerik:RadAjaxLoadingPanel runat="server" ID="pnlLoading"></telerik:RadAjaxLoadingPanel>
    <telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="Data" />
    <telerik:RadAjaxPanel runat="server" LoadingPanelID="pnlLoading" CssClass="container">
        <div id="Data" class="bg-light">
            <h1>Nueva Receta</h1>
            <fieldset>
                <legend>Datos principales</legend>
                <div class="row">
                    <div class="col-md">
                        <label>Nombre de la receta</label>
                        <telerik:RadTextBox runat="server" ID="txtNombre" EmptyMessage="Nombre" Width="100%"></telerik:RadTextBox>
                    </div>
                    <div class="col-md">
                        <label>Video</label>
                        <telerik:RadTextBox runat="server" ID="txtLink" EmptyMessage="Link del vídeo" Width="100%"></telerik:RadTextBox>
                    </div>
                    <div class="col-md">
                        <label>Dificultad</label>
                        <telerik:RadRating runat="server" ID="txtDificultad" Width="100%" Precision="Half" SelectionMode="Continuous"></telerik:RadRating>
                    </div>
                </div>
                <div class="container mt-3">
                    <label>Cuentanos más sobre tu receta. (¿A qué tipo de personas se la recomiendas? ¿Hay que ser precavidos? ¿Existen ingredientes opcionales? etc...)</label>
                    <telerik:RadTextBox runat="server" ID="txtDescripcion" EmptyMessage="Breve descripción de la receta" TextMode="MultiLine" Width="100%"></telerik:RadTextBox>
                </div>
            </fieldset>

            <fieldset>
                <legend>Ingredientes a utilizar</legend>
                <p>Describe uno a uno los ingredientes que se usarán para la receta</p>
                <div class="row mb-2">
                    <div class="col-md-6 my-1">
                        <div class="d-block ">
                            <label>Cantidad <span class="text-muted" style="font-size:.8em">* Obligatorio</span></label>
                            <telerik:RadAutoCompleteBox runat="server" ID="txtCantidad" EmptyMessage="Cantidad" Width="100%" AllowCustomEntry="true" MaxResultCount="10" InputType="Text" EnableDirectionDetection="true" TextSettings-SelectionMode="Single"></telerik:RadAutoCompleteBox>
                        </div>
                        <div class="d-block ">
                            <label>Medida <span class="text-muted" style="font-size:.8em">(Opcional)</span></label>
                            <telerik:RadAutoCompleteBox runat="server" ID="txtMedida" EmptyMessage="Medida" Width="100%" AllowCustomEntry="true" MaxResultCount="10" InputType="Text" EnableDirectionDetection="true" TextSettings-SelectionMode="Single"></telerik:RadAutoCompleteBox>
                            <%--<telerik:RadComboBox runat="server" ID="txtMedida" EmptyMessage="Seleccione" Width="100%" EnableLoadOnDemand="true" AllowCustomText="true" MarkFirstMatch="true" ItemsPerRequest="5">
                            </telerik:RadComboBox>--%>
                        </div>
                        <div class="d-block ">
                            <label>Ingrediente <span class="text-muted" style="font-size:.8em">* Obligatorio</span></label>
                            <telerik:RadAjaxPanel runat="server">
                                <telerik:RadAutoCompleteBox runat="server" ID="txtIngrediente" EmptyMessage="Ingrediente" Width="100%" AllowCustomEntry="true" HighlightFirstMatch="true" MaxResultCount="10" InputType="Token" EnableDirectionDetection="true" TextSettings-SelectionMode="Single" AutoPostBack="true"></telerik:RadAutoCompleteBox>
                            </telerik:RadAjaxPanel>
                        </div>
                        <div class="text-center my-2">
                            <asp:Button runat="server" ID="btnAddIngrediente" Text="Agregar" CssClass="btn btn-primary mx-auto btn-block" />
                        </div>
                    </div>
                    <div class="col-md-6 my-1">
                        <telerik:RadListBox runat="server" ID="lbIngredientes" AllowDelete="true" AllowReorder="true" AllowTransfer="false" AutoPostBackOnDelete="true" EmptyMessage="Añade ingredientes" Width="100%" Height="350px"></telerik:RadListBox>

                    </div>

                </div>

            </fieldset>
            <fieldset>
                <legend>Foto de portada</legend>
                <p>
                    Elige una foto de portada para tu receta. ¡Sé creativo!
                    <br />
                    <small class="text-muted">Extensiones permitidas: jpg, png. Max 10 MB.</small>
                </p>
                <telerik:RadAsyncUpload runat="server" ID="asyncPhoto" RenderMode="Lightweight" PostbackTriggers="btnGuardar" AllowedFileExtensions="jpg,png"></telerik:RadAsyncUpload>
            </fieldset>
            <fieldset>
                <legend>Descripcion de la receta</legend>
                <p>A continuación describe detalladamente los pasos a seguir para elaborar la receta. Puedes agregar fotos si deseas.</p>
                <telerik:RadEditor  runat="server" ID="editor" Width="100%" Height="600px" ToolbarMode="RibbonBar" EnableComments="true" ToolsFile="Estilos/word-like-tools.xml" EditModes="Design, Preview, HTML" SkinID="WordLikeExperience" Language="es-ES">
                    <CssFiles>
                        <telerik:EditorCssFile Value="./Estilos/bootstrap.min.css" />
                    </CssFiles>
                    <ImageManager EnableAsyncUpload="true" MaxUploadFileSize="1048576" UploadPaths="~/Recetas/Imagenes/" DeletePaths="~/Recetas/Imagenes/" ViewPaths="~/Recetas/Imagenes/" />
                </telerik:RadEditor>
            </fieldset>
            <div class="container text-right mt-3 ">
                <asp:Button runat="server" ID="btnGuardar" Text="Subir receta" CssClass="btn btn-success" />
            </div>
        </div>
        <telerik:RadNotification runat="server" ID="Notificacion" Position="Center" Animation="Fade" AutoCloseDelay="10000" KeepOnMouseOver="true" ShowCloseButton="true"></telerik:RadNotification>
    </telerik:RadAjaxPanel>
</asp:Content>

