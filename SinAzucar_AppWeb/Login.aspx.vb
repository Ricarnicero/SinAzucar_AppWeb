Imports System.Data
Imports System.Data.SqlClient
Imports Funciones
Imports Db
Imports System
Imports Telerik.Web.UI
Imports System.Web.Services

Partial Class Login
    Inherits System.Web.UI.Page
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        If tmpUSUARIO IsNot Nothing Then
            Response.Redirect("Noticias.aspx")
        End If
    End Sub
    Function LogOn(ByVal strEmail As String, ByVal strPassword As String) As String
        Dim validaSession As String = 0
        Try
            Dim DtsLogin As DataTable = SP.USUARIO(v_bandera:=1, v_correo:=strEmail, v_contrasena:=strPassword)
            If DtsLogin.TableName = "Exception" Then
                Funciones.showModal(Notificacion, "deny", "Error", "Error al inciar sesion. Intentelo más tarde")
            ElseIf DtsLogin(0)(0) = 0 Then
                Funciones.showModal(Notificacion, "deny", "Error", "Credenciales incorrectas")
            Else
                tmpUSUARIO = TableToDictionary(DtsLogin)
                validaSession = 1
            End If
        Catch ex As Exception
            Dim asda As String = "Error: " & ex.Message
        End Try
        Return validaSession
    End Function
    Protected Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        iniciarSesion(txtUsr.Text, txtPwd.Text)
    End Sub

    Protected Sub iniciarSesion(usr As String, pwd As String)
        If usr = "" Then
            showModal(Notificacion, "warning", "Inicio de sesíon", "Capture Un Usuario Valido.")
        ElseIf txtPwd.Text = "" Then
            showModal(Notificacion, "warning", "Inicio de sesíon", "Capture Una Contraseña Valida.")
        Else
            Dim licencia As Integer = LogOn(usr, pwd)
            Select Case licencia
                Case "1"
                    Response.Redirect("AddReceta.aspx")
                Case Else
                    Session.Abandon()
            End Select
        End If
    End Sub

End Class