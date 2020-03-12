<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddReceta.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel runat="server" ID="pnlLoading"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel runat="server" LoadingPanelID="pnlLoading">
        <telerik:RadWizard runat="server" ID="wizardReceta" ClickActiveStep="false">
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
                            <label>Descripcion</label>
                            <telerik:RadTextBox runat="server" ID="txtDescripcion" EmptyMessage="Breve descripcion de la receta" TextMode="MultiLine" Width="100%"></telerik:RadTextBox>
                        </div>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Ingredientes" Enabled="false">
                    <div class="container">
                        <p>Describe los ingredientes que se usarán para la receta</p>
                        <div class="row mb-2">
                            <div class="col-md">
                                <label>Cantidad</label>
                            </div>
                            <div class="col-md">
                                <label>Medida</label>
                            </div>
                            <div class="col-md">
                                <label>Ingrediente</label>
                            </div>
                        </div>
                        <div class="text-center my-2">
                            <asp:Button runat="server" ID="btnAddIngrediente" Text="Agregar" CssClass="btn btn-primary mx-auto" />
                        </div>
                        <telerik:RadListBox runat="server" ID="lbIngredientes" AllowDelete="true" AllowReorder="true" AllowTransfer="false" AutoPostBackOnDelete="true" EmptyMessage="Añade ingredietnes" Width="100%" Height="450px"></telerik:RadListBox>
                    </div>
                </telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Pasos" Enabled="false"></telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Step" Title="Imagenes" Enabled="false"></telerik:RadWizardStep>
                <telerik:RadWizardStep AllowReturn="false" StepType="Finish" Title="Resumen" Enabled="false"></telerik:RadWizardStep>
            </WizardSteps>
        </telerik:RadWizard>
    </telerik:RadAjaxPanel>
</asp:Content>

