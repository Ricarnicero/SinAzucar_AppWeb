Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Db
Imports Conexiones

Public Class Db

    Public Shared Function StrRuta() As String
        StrRuta = "E:\Cargas\BODESA\"
        Return StrRuta
    End Function

    Public Shared Sub SubExisteRuta(ByRef Ruta As String)
        If Not Directory.Exists(Ruta) Then
            Directory.CreateDirectory(Ruta)
        End If
    End Sub

    Public Shared Function Conectando() As String

        'Dim conexion As String = "Server =" & DesEncriptarCadena(StrConexion(3)) & ";Database=BODESA;User Id=" & DesEncriptarCadena(StrConexion(1)) & ";Password=" & DesEncriptarCadena(StrConexion(2)) & ";Connection Timeout=900;"

        'Return conexion
        Return "Server=sql.mcnoc.mx;Database=SQLServer;User Id=sa;Password=Enter83;"
    End Function

    Shared SSconex As New SqlConnection(Conectando())
    Shared Sub abre()
        SSconex.Open()
    End Sub
    Shared Sub cierra()
        SSconex.Close()
    End Sub
    Public Shared Function Ejecuta_Procedure(ByVal command As SqlCommand) As Boolean
        Try
            abre()
            command.Connection = SSconex
            If command.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        Finally
            cierra()
        End Try
    End Function
    Public Shared Function Consulta_Procedure(ByVal command As SqlCommand, ByVal name As String) As DataTable
        Dim dtable As New DataTable()
        Try
            dtable.TableName = name
            abre()
            command.Connection = SSconex
            dtable.Load(command.ExecuteReader())
        Catch ex As Exception
            dtable.TableName = "Exception"
            dtable.Columns.Add("Mensaje")
            Dim row As DataRow = dtable.NewRow()
            row("Mensaje") = ex.HResult & " -> " & ex.Message
            dtable.Rows.Add(row)
        Finally
            cierra()
        End Try
        Return dtable
    End Function
    Public Shared Function Consulta_Procedure2(ByVal command As SqlCommand, ByVal name As String) As DataSet
        Dim dset As New DataSet
        Dim dtable As New DataTable
        Try

            abre()

            command.Connection = SSconex
            Dim sqladap As New SqlDataAdapter(command)
            sqladap.Fill(dset)
        Catch ex As Exception
            dtable.TableName = "Exception"
            dtable.Columns.Add("Mensaje")
            Dim row As DataRow = dtable.NewRow()
            row("Mensaje") = ex.HResult & " -> " & ex.Message
            dtable.Rows.Add(row)
            dset.Tables.Add(dtable)
        Finally
            cierra()
        End Try
        Return dset
    End Function
    Public Shared Function Consulta(ByVal Query As String, ByVal Nombre As String) As DataTable
        Dim oDataset As New DataTable
        Dim conexion As String = Conectando()
        Dim objConexion As New SqlConnection(conexion)
        Dim objCommand As New SqlCommand(Query, objConexion)
        objCommand.CommandTimeout = 300
        Dim dtable As New DataTable(Nombre)
        dtable.Load(objCommand.ExecuteReader())
        Return oDataset
    End Function
    Public Shared Sub Ejecuta(ByVal Query As String)
        Dim conexion As String = Conectando()
        Dim objConexion As New SqlConnection(conexion)
        If objConexion.State = ConnectionState.Closed Then
            objConexion.Open()
        End If
        Dim MyQuery As New SqlCommand(Query, objConexion)
        MyQuery.ExecuteNonQuery()
        objConexion.Close()
    End Sub

    Public Shared Function DesEncriptarCadena(ByVal cadena As String) As String
        Dim idx As Integer
        Dim result As String = ""
        For idx = 0 To cadena.Length - 1
            result += DesEncriptarCaracter(cadena.Substring(idx, 1), cadena.Length, idx)
        Next
        Return result
    End Function

    Public Shared Function DesEncriptarCaracter(ByVal caracter As String, ByVal variable As Integer, ByVal a_indice As Integer) As String
        Dim patron_busqueda As String = "qpwoeirutyQPWOEIRUTYañsld1234567890kfjghAÑSLDKFJGHzmxncbvZMXNCBV."
        Dim Patron_encripta As String = "zmxncbvZMXNCBVañsldkfjghAÑ.SLDKFJGHqpwoeirutyQPWOEIRUTY0987654321"

        Dim indice As Integer
        If Patron_encripta.IndexOf(caracter) <> -1 Then
            If (Patron_encripta.IndexOf(caracter) - variable - a_indice) > 0 Then
                indice = (Patron_encripta.IndexOf(caracter) - variable - a_indice) Mod Patron_encripta.Length
            Else
                indice = (patron_busqueda.Length) + ((Patron_encripta.IndexOf(caracter) - variable - a_indice) Mod Patron_encripta.Length)
            End If
            indice = indice Mod Patron_encripta.Length
            Return patron_busqueda.Substring(indice, 1)
        Else
            Return caracter
        End If
    End Function

    Public Shared Function StrEndPoint(ByVal v_provedor As String, ByVal v_bandera As Integer) As String
        Dim res As String = ""

        If v_provedor = "SAFI" Then
            If v_bandera = 1 Then ' url
                res = "http://172.17.0.1:7070/bienestarws/"
            ElseIf v_bandera = 2 Then 'usuario
                res = "usuarioPruebaWS"
            ElseIf v_bandera = 3 Then 'contraseña
                res = "123"
            End If

        ElseIf v_provedor = "AB" Then
            If v_bandera = 1 Then ' url
                res = "http://10.150.102.76:8686/ws_rest-0.0.1/"
            ElseIf v_bandera = 2 Then 'usuario
                res = ""
            ElseIf v_bandera = 3 Then 'contraseña
                res = ""
            End If

        End If

        Return res

    End Function
End Class
