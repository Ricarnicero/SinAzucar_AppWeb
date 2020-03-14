<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Recetas.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Recetas</h2>
    <telerik:RadListView runat="server" ID="lvRecetas" ItemPlaceholderID="lvContainer">
        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="lvContainer"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-10 mx-auto my-2" id="<%# Eval("ID") %>">
                <div class="card text-warning" style="width: 100%; max-height: 350px">
                    <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%# IIf(Eval("FOTO") IsNot DBNull.Value, Eval("FOTO"), New System.Byte(-1) {})%>'
                        AutoAdjustImageControlSize="false" ToolTip='<%#Eval("NOMBRE", "Photo of {0}") %>'
                        AlternateText='<%#Eval("NOMBRE", "Photo of {0}") %>' Style="width: 100%; height: 350px; object-fit: cover;" CssClass="card-img-bottom rounded" />
                    <div class="card-img-overlay">
                        <h4 class="card-title"><b><%# Eval("NOMBRE") %></b><small><%# Eval("FECHA") %></small></h4>
                        <p class="card-text"><%# Eval("DESCRIPCION") %></p>
                        Dificultad : <%# Eval("DIFICULTAD") %>/5
                        <br />
                        Comentarios: <%# Eval("COMENTARIOS") %>
                        <br />
                        <a href="<%# "VisorReceta.aspx?id=" & Eval("ID") %>" class="btn btn-primary">¡A cocinar!</a>
                    </div>

                </div>




            </div>
        </ItemTemplate>
    </telerik:RadListView>
</asp:Content>
