
Partial Class SesionExpirada
    Inherits System.Web.UI.Page

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
End Class
