
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
    Private Sub wizardReceta_NextButtonClick(sender As Object, e As WizardEventArgs) Handles wizardReceta.NextButtonClick

        Select Case e.CurrentStepIndex
            Case 0
                Dim res = GuardarReceta()
                If res <> 0 Then
                    e.NextStep.Enabled = True
                    e.CurrentStep.Enabled = False
                    Session("receta_id") = res
                End If
            Case 1
                If guardarIngredientes(Session("receta_id")) Then
                    e.NextStep.Enabled = True
                    e.CurrentStep.Enabled = False
                Else
                    Funciones.showModal(Notificacion, "deny", "Error", "Error al agregar los ingredientes. Intenta más tarde")
                End If
            Case 2
                If guardarPasos(Session("receta_id")) Then
                    e.NextStep.Enabled = True
                    e.CurrentStep.Enabled = False
                Else
                    Funciones.showModal(Notificacion, "deny", "Error", "Error al agregar los pasos. Intenta más tarde")
                End If

            Case 3
                e.NextStep.Enabled = True
                e.CurrentStep.Enabled = False
        End Select
    End Sub

    Private Sub wizardReceta_FinishButtonClick(sender As Object, e As WizardEventArgs) Handles wizardReceta.FinishButtonClick
        SP.ADD_RECETA(13, Session("receta_id"))
        Response.Redirect("Recetas.aspx")
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

    Private Sub guardarFotos(id_receta As String)

        Dim Imagen As New ImageProcessor.ImageFactory
        'Imagen.Save()
    End Sub

    Private Function guardarPasos(id_receta As String) As Boolean
        Dim res As Boolean = True
        For Each paso As RadListBoxItem In lbPasos.Items
            Try
                SP.ADD_RECETA(v_bandera:=3, V_RECETA_ID:=id_receta, V_DESCRIPCION:=paso.Text)
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
            lbIngredientes.Items.Add(txtCantidad.Text & " " & txtMedida.SelectedValue & " de " & txtIngrediente.Text)
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

    '-----------------------------------------------------
    'Pasos
    '-----------------------------------------------------

    Private Sub btnAddPaso_Click(sender As Object, e As EventArgs) Handles btnAddPaso.Click
        If txtPasoNuevo.Text = "" Then
            Throw New Exception("Da una breve descripcion de lo que se debe hacer a continuación")
        End If
        lbPasos.Items.Add(txtPasoNuevo.Text)
        lbPasos.DataBind()
        txtPasoNuevo.Text = ""
        ContadorPasos.Text = "Paso " & (lbPasos.Items.Count + 1)
    End Sub

    Private Sub uploadedImages_FileUploaded(sender As Object, e As FileUploadedEventArgs) Handles uploadedImages.FileUploaded
        Dim imagen As New ImageProcessor.ImageFactory()
        imagen.Load(e.File.InputStream)
        Dim watermark As New ImageProcessor.Imaging.TextLayer With {
            .DropShadow = True,
            .Text = "SinAzucar"
        }
        imagen.Watermark(watermark)
        imagen.Quality(50)
        Dim imageStream As IO.Stream = New IO.MemoryStream()
        imagen.Save(imageStream)
        Dim subidoBytes As Byte() = New Byte(imageStream.Length - 1) {}
        imageStream.Read(subidoBytes, 0, subidoBytes.Length)
        SP.ADD_RECETA(v_bandera:=2, V_RECETA_ID:=Session("receta_id"), V_IMAGEN:=subidoBytes)
    End Sub

    Private Sub dockLayout_PreRender(sender As Object, e As EventArgs) Handles dockLayout.PreRender
        dockInfoGral.Text = SP.ADD_RECETA(9, Session("receta_id")).Rows(0)(0).ToString

        gridIngredientes.DataSource = SP.ADD_RECETA(10, Session("receta_id"))
        gridIngredientes.DataBind()

        gridPasos.DataSource = SP.ADD_RECETA(11, Session("receta_id"))
        gridPasos.DataBind()

        Dim dtab As DataTable = SP.ADD_RECETA(12, Session("receta_id"))
        Dim b64table As New DataTable()
        b64table.Columns.Add("ImgURL")
        For Each row As DataRow In dtab.Rows
            Dim newRow As DataRow = b64table.NewRow()
            newRow(0) = "data:image;base64," + Convert.ToBase64String(row(0))
            b64table.Rows.Add(newRow)
        Next
        b64table.AcceptChanges()
        RadRotator1.DataSource = b64table
        RadRotator1.DataBind()
    End Sub
End Class
