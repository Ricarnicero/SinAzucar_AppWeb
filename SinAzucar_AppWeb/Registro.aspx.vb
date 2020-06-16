
Partial Class Registro
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim msgValid As String = ValidateForm()
        If msgValid = "1" Then
            Dim res As String = SP.USUARIO(v_bandera:=0, v_nombre:=txtNombre.Text, v_contrasena:=txtPwd.Text, v_correo:=txtCorreo.Text).Rows(0)(0).ToString
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "myScript", "demo.RegistroExitoso()", True)
        Else
            Funciones.showModal(Notificacion, "deny", "Error", msgValid)
        End If
    End Sub

    Private Function ValidateForm() As String
        If Not New Regex("^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$").IsMatch(txtCorreo.Text, 0) Then
            Return "Correo no válido"
        End If
        If txtPwd.Text.Length < 8 Then
            Return "La contraseña debe tener al menos 8 caracteres"
        End If
        If txtPwd.Text <> txtPwd2.Text Then
            Return "Las contraseñas no coinciden"
        End If
        If Not New Regex("[A-Za-zñÑÁÉÍÓÚáéíóú\.\ ]+").IsMatch(txtNombre.Text, 0) Then
            Return "El nombre no puede llevar caracteres especiales"
        End If


        Return "1"
    End Function
End Class
