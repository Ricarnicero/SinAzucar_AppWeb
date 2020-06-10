
Imports System.Data
Imports Telerik.Web.UI

Partial Class Perfil
    Inherits System.Web.UI.Page
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property
    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub

    Private Sub Perfil_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable = SP.PERFIL_USUARIO(V_BANDERA:=2, V_WHERE:=buildExpression)
        acbIngredientes.DataSource = dt
        acbIngredientes.DataTextField = "TEXTO"
        acbIngredientes.DataValueField = "VALOR"
        If Not IsPostBack Then
            acbIngredientes.DataBind()

            Dim info As DataRow = SP.PERFIL_USUARIO(V_BANDERA:=0, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID")).Rows(0)
            txtAltura.Value = Double.Parse(info("ALTURA").ToString)
            txtEdad.Value = Double.Parse(info("EDAD").ToString)
            txtEmail.Text = info("CORREO").ToString
            txtNombre.Text = info("NOMBRE").ToString
            txtPeso.Value = Double.Parse(info("PESO").ToString)
            txtFechaNac.DbSelectedDate = info("FECHA_NAC").ToString

            Dim where As String = " where CAT_ING_ID in (select [CAT_ING_ID] from ING_NO_FAVORITOS WHERE [CAT_LO_ID] = " & tmpUSUARIO("CAT_LO_ID") & ")"
            Dim ingredientes As DataTable = SP.PERFIL_USUARIO(V_BANDERA:=2, V_WHERE:=where)

            For Each ingrediente As DataRow In ingredientes.Rows
                Dim entry As New AutoCompleteBoxEntry(ingrediente("TEXTO"), ingrediente("VALOR"))
                acbIngredientes.Entries.Add(entry)
            Next
        End If
    End Sub

    Private Sub acbIngredientes_EntryAdded(sender As Object, e As AutoCompleteEntryEventArgs) Handles acbIngredientes.EntryAdded
        Dim i = acbIngredientes.Entries.IndexOf(e.Entry)
    End Sub

    Private Sub btnguardarPerfil_Click(sender As Object, e As EventArgs) Handles btnguardarPerfil.Click
        Dim EntriesValues As New List(Of String)
        For Each entry As AutoCompleteBoxEntry In acbIngredientes.Entries
            EntriesValues.Add(entry.Value)
        Next
        SP.PERFIL_USUARIO(V_BANDERA:=1, V_ALTURA:=txtAltura.Value, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"), V_PESO:=txtPeso.Value, V_EDAD:=txtEdad.Value, V_FECHA_NAC:=txtFechaNac.DbSelectedDate, V_INGREDIENTES:=String.Join(",", EntriesValues))
        Funciones.showModal(RN1, "ok", "Correcto", "Perfi; actualizado correctamente")
    End Sub

    Private Sub Perfil_Init(sender As Object, e As EventArgs) Handles Me.Init
        If tmpUSUARIO Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Private Sub btnActualizarContrasena_Click(sender As Object, e As EventArgs) Handles btnActualizarContrasena.Click
        Dim resultado As String = SP.PERFIL_USUARIO(V_BANDERA:=3, V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"), V_CONTRASENA_ACTUAL:=txtContrasenaActual.Text, V_NUEVA_CONTRASENA:=txtNuevacontrasena.Text, V_CONFRIMA_CONTRASENA:=txtConfirmarContrasena.Text).Rows(0)(0).ToString
        Select Case resultado
            Case "0"
                Funciones.showModal(RN1, "deny", "Error", "Contraseña actual incorrecta")
            Case "1"
                Funciones.showModal(RN1, "deny", "Error", "La nueva contraseña no coincide con la confirmacion")
            Case "2"
                Funciones.showModal(RN1, "ok", "Correcto", "Contraseña actualizada correctamente")
            Case Else
                Funciones.showModal(RN1, "deny", "Error", resultado)
        End Select
    End Sub

    Private Function buildExpression() As String
        If acbIngredientes.Entries.Count > 0 Then

            Dim expession As String = " WHERE CAT_ING_ID NOT IN ('"
            Dim EntriesValues As New List(Of String)
            For Each entry As AutoCompleteBoxEntry In acbIngredientes.Entries
                EntriesValues.Add(entry.Value)
            Next
            Return expession & String.Join("','", EntriesValues) & "')"
        End If
        Return " "
    End Function
End Class
