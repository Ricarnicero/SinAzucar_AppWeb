
Imports Telerik.Web.UI

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub lvRecetas_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles lvRecetas.NeedDataSource
        lvRecetas.DataSource = SP.DISPLAY_RECETAS(1)
    End Sub
End Class
