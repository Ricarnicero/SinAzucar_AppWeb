
Imports Telerik.Web.UI

Partial Class AddIngredientes
    Inherits System.Web.UI.Page

    Private Sub gridIngredientes_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles gridIngredientes.NeedDataSource
        gridIngredientes.DataSource = SP.ADD_INGREDIENTE(2)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        For Each ingrediente As String In txtIngredeiente.Text.Split(",")
            SP.ADD_INGREDIENTE(1, ingrediente)
        Next
        txtIngredeiente.Text = ""
        gridIngredientes.Rebind()
    End Sub
End Class
