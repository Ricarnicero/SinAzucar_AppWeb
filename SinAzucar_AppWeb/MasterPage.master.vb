
Imports Telerik.Web.UI

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property
    Private Sub menu_Load(sender As Object, e As EventArgs) Handles menu.Load
        If tmpUSUARIO IsNot Nothing Then
            If tmpUSUARIO("CAT_LO_ROL").ToString >= 2 Then
                menu.Items(3).Visible = False
                menu.Items(5).Visible = False
            End If
        Else
            menu.Items(1).Visible = False
            menu.Items(2).Visible = False
            menu.Items(3).Visible = False
            menu.Items(5).Visible = False
            Dim iniciarSesion As New RadMenuItem("Iniciar sesión", "login.aspx")
            Dim Registro As New RadMenuItem("Registrarse", "Registro.aspx")
            menu.Items.Add(iniciarSesion)
            menu.Items.Add(Registro)
        End If
    End Sub
End Class

