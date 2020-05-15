
Imports Telerik.Web.UI

Partial Class Recetas
    Inherits System.Web.UI.Page

    Private Sub lvRecetas_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles lvRecetas.NeedDataSource
        lvRecetas.DataSource = SP.DISPLAY_RECETAS(1)
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
