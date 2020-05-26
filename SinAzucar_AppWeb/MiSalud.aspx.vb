
Partial Class MiSalud
    Inherits System.Web.UI.Page

    Private id As Integer = -1

    Public Property tmpUSUARIO As IDictionary
        Get
            Return CType(Session("USUARIO"), IDictionary)
        End Get
        Set(value As IDictionary)
            Session("USUARIO") = value
        End Set
    End Property

    Public ReadOnly Property GetID As Integer
        Get
            Return IIf(Session("CAT_LO_ID_AUX") Is Nothing, tmpUSUARIO("CAT_LO_ID"), Session("CAT_LO_ID_AUX"))
        End Get
    End Property

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If tmpUSUARIO Is Nothing Then
                Response.Redirect("login.aspx")
            End If
            Session.Remove("CAT_LO_ID_AUX")
            Try
                Session("CAT_LO_ID_AUX") = Request.QueryString("id")
                If Session("CAT_LO_ID_AUX") IsNot Nothing Then
                    pnlAddGlucosa.Visible = False
                    pnlAddPresion.Visible = False
                    pnlAddPeso.Visible = False
                    pnlShareLink.Visible = False
                Else
                    txtCopy.Text = "https://dev.mcnoc.mx/RichisTest/MiSalud.aspx?id=" + tmpUSUARIO("CAT_LO_ID")
                End If
            Catch ex As Exception

            End Try


        End If

        chartGlucosa.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=0)
        chartPeso.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=1)
        chartPresion.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=2)
    End Sub

    Private Sub AddPresion_Click(sender As Object, e As EventArgs) Handles AddPresion.Click
        SP.MI_SALUD(v_bandera:=1, v_id:=GetID, v_tipo:=2, v_valor:=txtPresion.Value)
        chartPresion.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=2)
        chartPresion.DataBind()
    End Sub

    Private Sub btnAddGlucosa_Click(sender As Object, e As EventArgs) Handles btnAddGlucosa.Click
        SP.MI_SALUD(v_bandera:=1, v_id:=GetID, v_tipo:=0, v_valor:=txtGlucosa.Value)
        chartGlucosa.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=0)
        chartGlucosa.DataBind()
    End Sub

    Private Sub btnAddPeso_Click(sender As Object, e As EventArgs) Handles btnAddPeso.Click
        SP.MI_SALUD(v_bandera:=1, v_id:=GetID, v_tipo:=1, v_valor:=txtPeso.Value)
        chartPeso.DataSource = SP.MI_SALUD(v_bandera:=0, v_id:=GetID, v_tipo:=1)
        chartPeso.DataBind()
    End Sub
End Class
