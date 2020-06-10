
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

    Public Function GetFaceDificult(dificultado As String) As String
        Dim number As Decimal = Decimal.Parse(dificultado)
        Dim html As String = ""
        If dificultado <= 1 Then
            html = "Muy fácil :D"
        ElseIf dificultado <= 2 Then
            html = "Fácil :)"
        ElseIf dificultado <= 3 Then
            html = "Intermedio :|"
        ElseIf dificultado <= 4 Then
            html = "Difícil :O"
        ElseIf dificultado <= 5 Then
            html = "Muy Difícil D:"
        End If
        Return html
    End Function
End Class
