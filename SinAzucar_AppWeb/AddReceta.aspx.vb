
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
        e.NextStep.Enabled = True
        e.CurrentStep.Enabled = False
    End Sub

    Private Sub wizardReceta_FinishButtonClick(sender As Object, e As WizardEventArgs) Handles wizardReceta.FinishButtonClick
        Dim id_receta As String = GuardarReceta()
        guardarPasos(id_receta)
        guardarFotos(id_receta)
        guardarIngredientes(id_receta)
    End Sub

    Private Sub guardarIngredientes(id_receta As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub guardarFotos(id_receta As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub guardarPasos(id_receta As String)
        Throw New NotImplementedException()
    End Sub


    Private Function GuardarReceta() As String
        Throw New NotImplementedException()
    End Function

    Private Sub btnAddIngrediente_Click(sender As Object, e As EventArgs) Handles btnAddIngrediente.Click
        lbIngredientes.Items.Add("ingrediente nuevo")
    End Sub
End Class
