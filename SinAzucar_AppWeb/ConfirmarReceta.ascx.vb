
Imports System.Data

Partial Class ConfirmarReceta
    Inherits System.Web.UI.UserControl
    Private _dataItem As Object = Nothing
    Public Property DataItem() As Object
        Get
            Return Me._dataItem
        End Get
        Set(ByVal value As Object)
            Me._dataItem = value
        End Set
    End Property

    Private Sub ConfirmarReceta_Init(sender As Object, e As EventArgs) Handles Me.Init
        Session.Remove("recetaid")
        If Session("Visualizar") Then
            Try
                Session("recetaid") = DataItem("ID")

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ConfirmarReceta_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Visualizar") Then
            Session.Remove("Visualizar")
            Dim DT As DataTable
            DT = SP.DISPLAY_RECETAS(v_bandera:=2, V_RECETA_ID:=Session("recetaid"))

            Dim info As DataRow = DT(0)

            RadBinaryImage1.DataValue = IIf(info("FOTO") IsNot DBNull.Value, info("FOTO"), New System.Byte(-1) {})

            lblTitulo.Text = info("NOMBRE")
            lblDescripcion.Text = info("DESCRIPCION")
            lblDificultad.Text = info("DIFICULTAD")
            lblFecha.Text = info("FECHA")

            phPasos.Controls.Add(New LiteralControl(IIf(info("HTML") IsNot DBNull.Value, info("HTML"), "<div>¡UPS! No hemos encontrado informacion para esta receta ):</div>")))

            Try
                lvIngredientes.DataSource = SP.DISPLAY_RECETAS(v_bandera:=3, V_RECETA_ID:=Session("recetaid"))
                lvIngredientes.DataBind()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
