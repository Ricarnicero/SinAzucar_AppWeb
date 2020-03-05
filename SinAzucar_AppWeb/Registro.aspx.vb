
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If ValidateForm() = "1" Then
            Dim res As String = SP.USUARIO(v_bandera:=0, v_nombre:=txtNombre.Text, v_contrasena:=txtPwd.Text, v_correo:=txtCorreo.Text).Rows(0)(0).ToString
            Funciones.showModal(Notificacion, "ok", "ok", res)
        End If
    End Sub

    Private Function ValidateForm() As String
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
