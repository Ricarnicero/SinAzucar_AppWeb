<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MiSalud.aspx.vb" Inherits="MiSalud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadFormDecorator runat="server" DecoratedControls="Fieldset" DecorationZoneID="Data" />
    <h2 class="text-center">Mi salud</h2>
    <p class="text-center">Este apartado tiene como objetivo llevar un registro de tus salud. Te recomendamos que actualices este apartado una vez al día</p>

    <div class="bg-light" id="Data">
        <div class="row justify-content-center">
            <fieldset class="col-md-5 mx-1">
                <legend>Glucosa</legend>
                <asp:Panel runat="server" ID="pnlAddGlucosa" CssClass="row">
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
                        <Series>
                            <telerik:AreaSeries DataFieldY="VALOR"></telerik:AreaSeries>
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
                        <Series>
                            <telerik:AreaSeries DataFieldY="VALOR"></telerik:AreaSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>
            </fieldset>
        </div>
    </div>

</asp:Content>

