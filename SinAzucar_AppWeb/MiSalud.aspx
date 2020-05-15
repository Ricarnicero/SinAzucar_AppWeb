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



            </fieldset>
            <fieldset class="col-md-5 mx-1">
                <legend>Peso</legend>
                <asp:Panel runat="server" ID="Panel1" CssClass="row">
                    <div class="col-6">
                        <label>Añadir registro:</label>
                        <telerik:RadNumericTextBox runat="server" ID="RadNumericTextBox1" MinValue="0" EmptyMessage="Kg" Width="100%">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" DecimalSeparator="." GroupSizes="5" />
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="col-6">
                        <br />
                        <asp:Button runat="server" ID="Button1" Text="+ Añadir" CssClass="btn btn-success" />
                    </div>

                </asp:Panel>
            </fieldset>
            <fieldset class="col-md-5 mx-1">
                <legend>Presión arterial</legend>
                <asp:Panel runat="server" ID="Panel2" CssClass="row">
                    <div class="col-6">
                        <label>Añadir registro:</label>
                        <telerik:RadNumericTextBox runat="server" ID="RadNumericTextBox2" MinValue="0" EmptyMessage="mmHg" Width="100%">
                            <NumberFormat AllowRounding="false" DecimalDigits="2" DecimalSeparator="." GroupSizes="5" />
                        </telerik:RadNumericTextBox>
                    </div>
                    <div class="col-6">
                        <br />
                        <asp:Button runat="server" ID="Button2" Text="+ Añadir" CssClass="btn btn-success" />
                    </div>

                </asp:Panel>
            </fieldset>
        </div>
    </div>

</asp:Content>

