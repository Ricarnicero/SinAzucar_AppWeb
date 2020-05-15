
Imports System.Data
Imports Telerik.Web.UI

Partial Class _Default
    Inherits System.Web.UI.Page
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property

    Dim ingredeientes() As String

    Private Sub _Default_Init(sender As Object, e As EventArgs) Handles Me.Init
        If tmpUSUARIO Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
    End Sub


    Private Function guardarIngredientes(id_receta As String) As Boolean
        Dim res As Boolean = True
        For Each ingrediente As RadListBoxItem In lbIngredientes.Items
            Try
                SP.ADD_RECETA(v_bandera:=4, V_RECETA_ID:=id_receta, V_DESCRIPCION:=ingrediente.Text)
            Catch ex As Exception
                res = False
            End Try
        Next
        Return res
    End Function


    Private Function GuardarReceta() As String
        Dim id As String = 0
        Try
            If txtNombre.Text = "" Then
                Throw New Exception("Dale un nombre a tu receta")
            End If
            If txtDificultad.Value = 0 Then
                txtDificultad.Value = 0.5
            End If
            If txtDescripcion.Text = "" Then
                txtDescripcion.Focus()
                Throw New Exception("Cuentanos del resultado final de tu receta")
            End If
            Dim res = SP.ADD_RECETA(v_bandera:=1, V_NOMBRE:=txtNombre.Text, V_USR_ID:=tmpUSUARIO("CAT_LO_ID"), V_DESCRIPCION:=txtDescripcion.Text, V_LINK_VIDEO:=txtLink.Text, V_DIFICULTAD:=txtDificultad.Value)
            If res.TableName = "Exception" Then
                Throw New Exception("No fue posible agregar tu receta. Intenta más tarde")
            End If
            id = res(0)(0).ToString
        Catch ex As Exception
            Funciones.showModal(Notificacion, "deny", "Error", ex.Message)
        End Try
        Return id
    End Function

    '-----------------------------------------------------
    'Ingredientes
    '-----------------------------------------------------
    Private Sub btnAddIngrediente_Click(sender As Object, e As EventArgs) Handles btnAddIngrediente.Click
        Try
            If txtCantidad.Text = "" Then
                Throw New Exception("Selecciona una cantidad")
            End If
            If txtMedida.SelectedValue = "" Then
                Throw New Exception("Selecciona una medida")
            End If
            If txtIngrediente.Text = "" Then
                Throw New Exception("Selecciona un ingrediente")
            End If
            Dim item As New RadListBoxItem
            item.Attributes.Add("cantidad", txtCantidad.Text)
            item.Attributes.Add("medida", txtMedida.SelectedValue)
            item.Attributes.Add("ingrediente", txtIngrediente.Text)
            item.Text = txtCantidad.Text & " " & txtMedida.SelectedValue & " de " & txtIngrediente.Text
            lbIngredientes.Items.Add(item)
            Funciones.showModal(Notificacion, "ok", "Correcto", "Ingrediente agregado correctamente")
            txtCantidad.Entries.Clear()
            txtMedida.ClearSelection()
            txtIngrediente.Entries.Clear()
        Catch ex As Exception
            Funciones.showModal(Notificacion, "deny", "Error", ex.Message)
        End Try
    End Sub

    Private Sub txtCantidad_Init(sender As Object, e As EventArgs) Handles txtCantidad.Init
        txtCantidad.DataValueField = "CAT_CA_CANTIDAD"
        txtCantidad.DataTextField = "CAT_CA_CANTIDAD"
        txtCantidad.DataSource = SP.ADD_RECETA(6)
    End Sub

    Private Sub txtMedida_Init(sender As Object, e As EventArgs) Handles txtMedida.Init
        txtMedida.DataValueField = "CAT_ME_DESCRIPCION"
        txtMedida.DataTextField = "CAT_ME_DESCRIPCION"
        txtMedida.DataSource = SP.ADD_RECETA(7)
        txtMedida.DataBind()
    End Sub

    Private Sub txtIngrediente_Init(sender As Object, e As EventArgs) Handles txtIngrediente.Init
        txtIngrediente.DataValueField = "CAT_ING_DESC"
        txtIngrediente.DataTextField = "CAT_ING_DESC"
        txtIngrediente.DataSource = SP.ADD_RECETA(8)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim id As String = 0
        Try
            If txtNombre.Text = "" Then
                Throw New Exception("Dale un nombre a tu receta")
            End If
            If txtDificultad.Value = 0 Then
                txtDificultad.Value = 0.5
            End If
            If txtDescripcion.Text = "" Then
                txtDescripcion.Focus()
                Throw New Exception("Cuentanos del resultado final de tu receta")
            End If
            Dim res = SP.ADD_RECETA(v_bandera:=1, V_NOMBRE:=txtNombre.Text, V_USR_ID:=tmpUSUARIO("CAT_LO_ID"), V_DESCRIPCION:=txtDescripcion.Text, V_LINK_VIDEO:=txtLink.Text, V_DIFICULTAD:=txtDificultad.Value)
            If res.TableName = "Exception" Then
                Throw New Exception("No fue posible agregar tu receta. Intenta más tarde")
            End If
            id = res(0)(0).ToString
        Catch ex As Exception
            Funciones.showModal(Notificacion, "deny", "Error", ex.Message)
        End Try

        Dim res2 As Boolean = True
        For Each ingrediente As RadListBoxItem In lbIngredientes.Items
            Try
                SP.ADD_RECETA(v_bandera:=4, V_RECETA_ID:=id, V_CANTIDAD:=ingrediente.Attributes("cantidad"), V_MEDIDA:=ingrediente.Attributes("medida"), V_INGREDIENTES:=ingrediente.Attributes("ingrediente"))
            Catch ex As Exception
                res2 = False
            End Try
        Next

        Dim subido As UploadedFile = asyncPhoto.UploadedFiles(0)
        Dim subidoBytes As Byte() = New Byte(subido.InputStream.Length - 1) {}
        subido.InputStream.Read(subidoBytes, 0, subidoBytes.Length)

        SP.ADD_RECETA(v_bandera:=2, V_RECETA_ID:=id, V_IMAGEN:=subidoBytes)


        Dim html As String = editor.GetHtml(EditorStripHtmlOptions.Comments)
        SP.ADD_RECETA(v_bandera:=3, V_RECETA_ID:=id, V_HTML:=html)


        SP.ADD_RECETA(v_bandera:=13, V_RECETA_ID:=id)

        Response.Redirect("Recetas.aspx")
    End Sub

End Class
