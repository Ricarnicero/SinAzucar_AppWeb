
Imports System.Data

Partial Class VisorReceta
    Inherits System.Web.UI.Page
    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property

    Private Sub VisorReceta_Init(sender As Object, e As EventArgs) Handles Me.Init
        Session.Remove("recetaid")
        Try
            Session("recetaid") = Request.QueryString("id")

        Catch ex As Exception
            Response.Redirect("Recetas.aspx")

        End Try

    End Sub

    Private Sub VisorReceta_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim DT As DataTable
            Try
                DT = SP.DISPLAY_RECETAS(v_bandera:=2, V_RECETA_ID:=Session("recetaid"), V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"))
            Catch ex As Exception
                DT = SP.DISPLAY_RECETAS(v_bandera:=2, V_RECETA_ID:=Session("recetaid"))

            End Try
            Dim info As DataRow = DT(0)
            ssOptions.TitleToShare = "Mira """ & info("NOMBRE") & """ "
            ssOptions.UrlToShare = "https://dev.mcnoc.mx/RichisTest/VisorReceta.aspx?id=" & Session("recetaid")

            RadBinaryImage1.DataValue = IIf(info("FOTO") IsNot DBNull.Value, info("FOTO"), New System.Byte(-1) {})

            lblTitulo.Text = info("NOMBRE")
            lblDescripcion.Text = info("DESCRIPCION")
            lblDificultad.Text = info("DIFICULTAD")
            lblFecha.Text = info("FECHA")
            txtDificultad.Value = info("CALIFICACION")

            phPasos.Controls.Add(New LiteralControl(IIf(info("HTML") IsNot DBNull.Value, info("HTML"), "<div>¡UPS! No hemos encontrado informacion para esta receta ):</div>")))

            Try
                lvIngredientes.DataSource = SP.DISPLAY_RECETAS(v_bandera:=3, V_RECETA_ID:=Session("recetaid"))
                lvIngredientes.DataBind()
            Catch ex As Exception

            End Try

            Try
                lvComentarios.DataSource = SP.DISPLAY_RECETAS(v_bandera:=6, V_RECETA_ID:=Session("recetaid"))
                lvComentarios.DataBind()
            Catch ex As Exception

            End Try

            If tmpUSUARIO Is Nothing Then
                txtDificultad.Enabled = False
                pnlAddComentario.Visible = False
            End If
        End If
    End Sub

    Private Sub txtDificultad_Rate(sender As Object, e As EventArgs) Handles txtDificultad.Rate
        SP.DISPLAY_RECETAS(v_bandera:=4, V_RECETA_ID:=Session("recetaid"), V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"), V_CALIFICACION:=txtDificultad.Value)
    End Sub

    Private Sub btnAddComentario_Click(sender As Object, e As EventArgs) Handles btnAddComentario.Click
        If txtComentario.Text <> "" Then

            SP.DISPLAY_RECETAS(v_bandera:=5, V_RECETA_ID:=Session("recetaid"), V_USUARIO_ID:=tmpUSUARIO("CAT_LO_ID"), V_COMENTARIO:=txtComentario.Text)
            txtComentario.Text = ""
        End If
        Try
            lvComentarios.DataSource = SP.DISPLAY_RECETAS(v_bandera:=6, V_RECETA_ID:=Session("recetaid"))
            lvComentarios.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
