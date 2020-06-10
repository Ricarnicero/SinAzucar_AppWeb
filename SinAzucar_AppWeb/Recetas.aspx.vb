
Imports Telerik.Web.UI

Partial Class Recetas
    Inherits System.Web.UI.Page
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property
    Private Sub lvRecetas_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles lvRecetas.NeedDataSource
        If tmpUSUARIO Is Nothing Then
            lvRecetas.DataSource = SP.DISPLAY_RECETAS(1)
        Else
            lvRecetas.DataSource = SP.DISPLAY_RECETAS(v_bandera:=1, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"))
        End If
    End Sub

    Private Sub sbRecetas_DataSourceSelect(sender As Object, e As SearchBoxDataSourceSelectEventArgs) Handles sbRecetas.DataSourceSelect

        Dim searchString As String = e.FilterString
        Dim TipoBusqueda As String = e.SelectedContextItem.Key
        Dim usuario_id As Integer = Nothing
        If tmpUSUARIO IsNot Nothing Then
            usuario_id = tmpUSUARIO("CAT_LO_ID")
        End If
        sbRecetas.DataSource = SP.BUSCAR_RECETAS(V_FILTER_STRING:=searchString, V_TIPO_BUSQUEDA:=TipoBusqueda, V_USUARIO_ID:=usuario_id)
        sbRecetas.DataTextField = "NOMBRE"
        sbRecetas.DataValueField = "ID"
        sbRecetas.DataBind()
    End Sub

    Private Sub sbRecetas_Search(sender As Object, e As SearchBoxEventArgs) Handles sbRecetas.Search
        If e.Value <> "" Then
            Response.Redirect("visorReceta.aspx?id=" & e.Value)
        End If
    End Sub

    Private Sub Recetas_Load(sender As Object, e As EventArgs) Handles Me.Load
        sbRecetas.DataSource = SP.DISPLAY_RECETAS(1)
        sbRecetas.DataTextField = "NOMBRE"
        sbRecetas.DataValueField = "ID"
        sbRecetas.DataBind()
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
