<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MiSalud.aspx.vb" Inherits="MiSalud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="Data" />
    <h2 class="text-center">Mi salud</h2>
    <p class="text-center">Este apartado tiene como objetivo llevar un registro de tus salud. Te recomendamos que actualices este apartado una vez al día</p>

    <div class="bg-light" id="Data">
        <div class="row justify-content-center">
            <asp:Panel runat="server" ID="pnlShareLink" CssClass="col-12">
                <fieldset>
                    <legend>Compartir</legend>
                    <div class="d-flex justify-content-center">
                        <asp:TextBox runat="server" ID="txtCopy" CssClass="form-control js-copytextarea"></asp:TextBox>
                        <telerik:RadButton runat="server" ID="btnCopy" AutoPostBack="false" CssClass="bg-primary text-white border-0" Text="Copiar link" OnClientClicked="copyToClipboard"></telerik:RadButton>
                    </div>
                </fieldset>
            </asp:Panel>
            <fieldset class="col-md-5 mx-1">
                <legend>Glucosa</legend>
                <asp:Panel runat="server" ID="pnlAddGlucosa" CssClass="row">
                    <p>Se recomienda hacerse las pruebas en ayunas</p>
                    <div class="col-6">
                        <label>Añadir registro:</label>
                        <telerik:RadNumericTextBox runat="server" ID="txtGlucosa" MinValue="0" EmptyMessage="mg/dl" Width="100%">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" DecimalSeparator="." GroupSizes="5" />
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="col-6">
                        <br />
                        <asp:Button runat="server" ID="btnAddGlucosa" Text="+ Añadir" CssClass="btn btn-success" />
                    </div>

                </asp:Panel>
                <telerik:RadHtmlChart runat="server" ID="chartGlucosa">
                    <ChartTitle Text="Glucosa (mg/dl)"></ChartTitle>
                    <PlotArea>
                        <XAxis DataLabelsField="FECHA">
                            <LabelsAppearance RotationAngle="-45"></LabelsAppearance>
                        </XAxis>
                        <YAxis>
                            <PlotBands>
                                <telerik:PlotBand From="70" To="100" Color="#4ad970" Alpha="190" /> 
                            </PlotBands>
                        </YAxis>
                        <Series>
                            <telerik:AreaSeries DataFieldY="VALOR" ColorField="COLOR"></telerik:AreaSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>


            </fieldset>
            <fieldset class="col-md-5 mx-1">
                <legend>Peso</legend>
                <asp:Panel runat="server" ID="pnlAddPeso" CssClass="row">
                    <div class="col-6">
                        <label>Añadir registro:</label>
                        <telerik:RadNumericTextBox runat="server" ID="txtPeso" MinValue="0" EmptyMessage="Kg" Width="100%">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" DecimalSeparator="." GroupSizes="5" />
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="col-6">
                        <br />
                        <asp:Button runat="server" ID="btnAddPeso" Text="+ Añadir" CssClass="btn btn-success" />
                    </div>
                </asp:Panel>
                <telerik:RadHtmlChart runat="server" ID="chartPeso">
                    <ChartTitle Text="Peso (Kg)"></ChartTitle>
                    <PlotArea>
                        <XAxis DataLabelsField="FECHA">
                            <LabelsAppearance RotationAngle="-45"></LabelsAppearance>
                        </XAxis>
                        <Series>
                            <telerik:AreaSeries DataFieldY="VALOR"></telerik:AreaSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>
            </fieldset>
            <fieldset class="col-md-5 mx-1">
                <legend>Presión arterial</legend>
                <asp:Panel runat="server" ID="pnlAddPresion" CssClass="row">
                    <div class="col-12">
                        <p>Anota tu presión sistólica</p>
                    </div>
                    <div class="col-6">
                        <label>Añadir registro:</label>
                        <telerik:RadNumericTextBox runat="server" ID="txtPresion" MinValue="0" EmptyMessage="mmHg" Width="100%">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" DecimalSeparator="." GroupSizes="5" />
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="col-6">
                        <br />
                        <asp:Button runat="server" ID="AddPresion" Text="+ Añadir" CssClass="btn btn-success" />
                    </div>

                </asp:Panel>
                <telerik:RadHtmlChart runat="server" ID="chartPresion">
                    <ChartTitle Text="Presión arterial (mmHg)"></ChartTitle>
                    <PlotArea>
                        <XAxis DataLabelsField="FECHA">
                            <LabelsAppearance RotationAngle="-45"></LabelsAppearance>
                        </XAxis>
                        <YAxis>
                            <PlotBands>
                                <telerik:PlotBand From="0" To="120" Color="GREEN" Alpha="190" /> 
                                <telerik:PlotBand From="120" To="130" Color="YELLOW" Alpha="190" /> 
                                <telerik:PlotBand From="130" To="140" Color="ORANGE" Alpha="190" /> 
                                <telerik:PlotBand From="140" To="160" Color="RED" Alpha="190" /> 
                            </PlotBands>
                        </YAxis>
                        <Series>
                            <telerik:AreaSeries DataFieldY="VALOR" ColorField="COLOR"></telerik:AreaSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>
            </fieldset>
        </div>
    </div>

    <script>
        function copyToClipboard(a, b) {
            var copyTextarea = document.querySelector('.js-copytextarea');
            copyTextarea.focus();
            copyTextarea.select();

            try {
                var successful = document.execCommand('copy');
                var msg = successful ? 'successful' : 'unsuccessful';
                console.log('Copying text command was ' + msg);
            } catch (err) {
                console.log('Oops, unable to copy');
            }
        }
    </script>
</asp:Content>

