<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddReceta.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel runat="server" ID="pnlLoading"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server" LoadingPanelID="pnlLoading">
        <telerik:RadWizard runat="server" ID="wizardReceta" ClickActiveStep="false" RenderedSteps="Active">
            <Localization Next="Siguiente" Cancel="Cancelar" Finish="Publicar" Previous="Regresar" />
            <WizardSteps>
                <telerik:RadWizardStep AllowReturn="false" StepType="Start" Title="Nueva receta" Active="true">
                    <div class="container">
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
                            <telerik:RadTextBox runat="server" ID="txtDescripcion" EmptyMessage="Breve descripcion de la receta" TextMode="MultiLine" Width="100%"></telerik:RadTextBox>
                        </div>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Ingredientes" Enabled="false">
                    <div class="container">
                        <h2>Ingredientes a utilizar</h2>
                        <p>Describe uno a uno los ingredientes que se usarán para la receta</p>
                        <div class="row mb-2">
                            <div class="col-md">
                                <label>Cantidad</label>
                                <telerik:RadAutoCompleteBox runat="server" ID="txtCantidad" EmptyMessage="Cantidad" Width="100%" AllowCustomEntry="true" HighlightFirstMatch="true" MaxResultCount="10" InputType="Text" EnableDirectionDetection="true" TextSettings-SelectionMode="Single"></telerik:RadAutoCompleteBox>
                            </div>
                            <div class="col-md">
                                <label>Medida</label>
                                <telerik:RadComboBox runat="server" ID="txtMedida" EmptyMessage="Seleccione" Width="100%" EnableLoadOnDemand="true" AllowCustomText="false" MarkFirstMatch="true" ItemsPerRequest="5">
                                </telerik:RadComboBox>
                            </div>
                            <div class="col-md">
                                <label>Ingrediente</label>
                                <telerik:RadAutoCompleteBox runat="server" ID="txtIngrediente" EmptyMessage="Cantidad" Width="100%" AllowCustomEntry="true" HighlightFirstMatch="true" MaxResultCount="10" InputType="Text" EnableDirectionDetection="true" TextSettings-SelectionMode="Single"></telerik:RadAutoCompleteBox>
                            </div>
                        </div>
                        <div class="text-center my-2">
                            <asp:Button runat="server" ID="btnAddIngrediente" Text="Agregar" CssClass="btn btn-primary mx-auto" />
                        </div>
                        <telerik:RadListBox runat="server" ID="lbIngredientes" AllowDelete="true" AllowReorder="true" AllowTransfer="false" AutoPostBackOnDelete="true" EmptyMessage="Añade ingredientes" Width="100%" Height="350px"></telerik:RadListBox>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Pasos" Enabled="false">
                    <h2>Pasos para cocinar la receta</h2>
                    <p>Describe detalladamente cada paso para hacer que tu receta se logre con éxito</p>
                    <telerik:RadLabel runat="server" ID="ContadorPasos"></telerik:RadLabel>
                    <telerik:RadTextBox runat="server" ID="txtPasoNuevo" TextMode="MultiLine" Width="100%"></telerik:RadTextBox>
                    <asp:Button runat="server" ID="btnAddPaso" Text="Siguiente paso" CssClass="btn btn-primary m-2" />
                    <hr />
                    Estos son los pasos que has añadido recientemente. Puedes cambiar el orden o eliminar algun paso con los botones a un costado.
                    <telerik:RadListBox runat="server" ID="lbPasos" Width="100%" Height="450px" AllowDelete="true" AllowReorder="true">
                        <ItemTemplate>
                            <div class="bg-light border rounded p-2 text-wrap">
                                <%# DataBinder.Eval(Container, "Text") %>
                            </div>
                        </ItemTemplate>
                    </telerik:RadListBox>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Imagenes" Enabled="false">
                    <h2>Imagenes</h2>
                    <p>Puedes agregar imagenes del procedimiento para tu receta o de cómo quedó tu platillo. ¡Sé creativo!</p>
                    <p class="text-muted">
                        <b>Nota: </b>Las imagenes deben estar en formato jpg o png. Haz click en "Subir imagenes" para validar tus imagenes.
                    </p>
                    <telerik:RadAsyncUpload runat="server" ID="uploadedImages" AllowedFileExtensions=".jpg,.png" MaxFileInputsCount="5" PostbackTriggers="btnProcessImages"></telerik:RadAsyncUpload>
                    <asp:Button runat="server" ID="btnProcessImages" Text="Subir imagenes" CssClass="btn btn-primary my-2" />
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Finish" Title="Resumen" Enabled="false">
                    <h2>Resumen de la Receta</h2>
                    <telerik:RadDockLayout runat="server" ID="dockLayout">
                        <div class="row">
                            <div class="col-md">
                                <telerik:RadDockZone runat="server" Orientation="Vertical" Width="100%" MinHeight="150px" CssClass="border-0">
                                    <telerik:RadDock runat="server" ID="dockInfoGral" Title="Información"></telerik:RadDock>
                                </telerik:RadDockZone>
                            </div>
                            <div class="col-md">
                                <telerik:RadDockZone runat="server" Orientation="Vertical" Width="100%" MinHeight="150px" CssClass="border-0">
                                    <telerik:RadDock runat="server" ID="dockIngredientes" Title="Ingredientes">
                                        <ContentTemplate>
                                            <telerik:RadGrid runat="server" ID="gridIngredientes" AllowPaging="true" PageSize="5"></telerik:RadGrid>
                                        </ContentTemplate>
                                    </telerik:RadDock>
                                </telerik:RadDockZone>
                            </div>
                            <div class="col-md">
                                <telerik:RadDockZone runat="server" Orientation="Vertical" Width="100%" MinHeight="150px" CssClass="border-0">
                                    <telerik:RadDock runat="server" ID="dockPasos" Title="Pasos">
                                        <ContentTemplate>
                                            <telerik:RadGrid runat="server" ID="gridPasos" AllowPaging="true" PageSize="3"></telerik:RadGrid>
                                        </ContentTemplate>
                                    </telerik:RadDock>
                                </telerik:RadDockZone>
                            </div>
                        </div>
                        <h4>Imagenes</h4>
                        <telerik:RadRotator RenderMode="Lightweight" runat="server" ID="RadRotator1" ScrollDuration="2000" FrameDuration="2000" ScrollDirection="Left, Right" Width="100%" RotatorType="AutomaticAdvance">
                            <ItemTemplate>
                                <div class="w3-display-container" style="height: 100%">
                                    <asp:Image ID="CustomerImage" runat="server" AlternateText="Customer image" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImgURL")%>' class="img-fluid"></asp:Image>
                                </div>
                            </ItemTemplate>
                        </telerik:RadRotator>

                    </telerik:RadDockLayout>
                </telerik:RadWizardStep>
            </WizardSteps>
        </telerik:RadWizard>
        <telerik:RadNotification runat="server" ID="Notificacion" Position="Center" Animation="Fade" AutoCloseDelay="10000" KeepOnMouseOver="true" ShowCloseButton="true"></telerik:RadNotification>
    </telerik:RadAjaxPanel>
</asp:Content>

