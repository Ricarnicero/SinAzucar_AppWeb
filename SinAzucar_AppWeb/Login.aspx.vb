Imports System.Data
Imports System.Data.SqlClient
Imports Funciones
Imports Db
Imports System
Imports Telerik.Web.UI
Imports System.Web.Services

Partial Class Login
    Inherits System.Web.UI.Page
    Public Property tmpPermisos As IDictionary
        Get
            Return CType(Session("Permisos"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("Permisos") = value
        End Set
    End Property

    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Session("USUARIO") IsNot Nothing Then
        '    Response.Redirect("Modulos.aspx")
        'End If
    End Sub
    Function LogOn(ByVal strEmail As String, ByVal strPassword As String) As String

        Dim validaSession As String = 0
        Try

            Dim DtsLogin As DataTable = SP.USUARIO(1, strEmail, strPassword, "WEB")

            tmpUSUARIO = TableToDictionary(DtsLogin)
            Select Case tmpUSUARIO("CAT_LO_ESTATUS")
                Case Is = "Cancelado"
                    validaSession = 1
                Case Is = "Expirado"
                    validaSession = 2
                Case Is = "Activo"
                    Dim Hora As String = Now.Hour & ":" & Now.Minute
                    If (Val(tmpUSUARIO("CAT_LO_HENTRADA")) <= Val(Hora)) = False Or (Val(tmpUSUARIO("CAT_LO_HSALIDA")) >= Val(Hora)) = False Then
                        validaSession = 3
                    Else
                        Dim Licencias As Integer = tmpUSUARIO("Licencias")
                        validaSession = 5
                    End If
            End Select
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
                Case "0"
                    Session.Abandon()
                    showModal(Notificacion, "warning", "Inicio de sesíon", "Credenciales incorrectas.")
                Case "5"
                    Dim Dt As DataTable = SP.INGRESO(2, tmpUSUARIO("CAT_LO_USUARIO"), GetIPv4Address(), "Modulos")
                    Response.Redirect("./Modulos")
            End Select
        End If
    End Sub

    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function

End Class