
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class ConfirmarRecetas
    Inherits System.Web.UI.Page

    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property

    Private Sub gridConfirmacion_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles gridConfirmacion.NeedDataSource
        gridConfirmacion.DataSource = SP.CONFIRMACION_RECETAS(V_BANDERA:=0, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"))
    End Sub

    Private Sub _Default_Init(sender As Object, e As EventArgs) Handles Me.Init
        If tmpUSUARIO Is Nothing Then
            Response.Redirect("Login.aspx")
        ElseIf tmpUSUARIO("CAT_LO_ROL").ToString >= 2 Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Private Sub gridConfirmacion_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles gridConfirmacion.ItemCommand
        If e.CommandName = "Aprobar" Then
            SP.ADD_RECETA(v_bandera:=13, V_RECETA_ID:=e.CommandArgument)
            Funciones.showModal(rn1, "ok", "Confirmada", "La receta se ha confirmado y se muestra a los usuarios")
            gridConfirmacion.Rebind()
        ElseIf e.CommandName = "Edit" Then
            Session("Visualizar") = True
        End If
    End Sub

    Private Sub gridMisRecetas_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles gridMisRecetas.NeedDataSource
        gridMisRecetas.DataSource = SP.CONFIRMACION_RECETAS(V_BANDERA:=1, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"))
    End Sub

    Public Function GetFaceDificult(dificultado As String) As String
        Dim number As Decimal = Decimal.Parse(dificultado)
        Dim html As String = ""
        If dificultado <= 1 Then
            html = "Muy fácil :D"
        ElseIf dificultado <= 2 Then
            html = "Fácil :)"
        ElseIf dificultado <= 3 Then
            html = "Intermedio :|"
        ElseIf dificultado <= 4 Then
            html = "Difícil :O"
        ElseIf dificultado <= 5 Then
            html = "Muy Difícil D:"
        End If
        Return html
    End Function
End Class
