
Imports System.Data

Partial Class VisorReceta
    Inherits System.Web.UI.Page
    Private id As Integer
    Private Sub VisorReceta_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            id = Request.QueryString("id")

        Catch ex As Exception
            Response.Redirect("Recetas.aspx")

        End Try

    End Sub

    Private Sub VisorReceta_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DT As DataTable = SP.DISPLAY_RECETAS(v_bandera:=2, V_RECETA_ID:=id)

        Dim info As DataRow = DT(0)

        RadBinaryImage1.DataValue = IIf(info("FOTO") IsNot DBNull.Value, info("FOTO"), New System.Byte(-1) {})

        lblTitulo.Text = info("NOMBRE")
        lblDescripcion.Text = info("DESCRIPCION")
        lblDificultad.Text = info("DIFICULTAD")
        lblFecha.Text = info("FECHA")

        phPasos.Controls.Add(New LiteralControl(IIf(info("HTML") IsNot DBNull.Value, info("HTML"), "<div>¡UPS! No hemos encontrado informacion para esta receta ):</div>")))
    End Sub
End Class
