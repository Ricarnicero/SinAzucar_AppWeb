Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Db
Imports System.Globalization
Imports System.IO
Imports System.Web.SessionState.HttpSessionState
Imports Newtonsoft.Json
Imports Telerik.Web.UI

Public Class Funciones
    Public Shared Function DStoJSON(ds As DataTable) As String
        Dim json As New StringBuilder()

        For Each dr As DataRow In ds.Rows
            json.Append("{")

            Dim i As Integer = 0
            Dim colcount As Integer = dr.Table.Columns.Count

            For Each dc As DataColumn In dr.Table.Columns
                json.Append("""")
                json.Append(HttpUtility.HtmlDecode(dc.ColumnName))
                json.Append("""")
                json.Append(":")
                json.Append("""")
                json.Append(HttpUtility.HtmlDecode(NuloAVacio(dr(dc))).Replace(Chr(34), "").Replace(Chr(10), "").Replace(Chr(92), "/"))
                json.Append("""")

                i += 1
                If i < colcount Then
                    json.Append(",")
                End If
            Next
            json.Append("}")
            json.Append(",")
        Next

        Return json.ToString()

    End Function

    Public Shared Function NuloAVacio(valor As Object) As String
        If Not IsDBNull(valor) Then
            Return valor.ToString()
        Else
            Return " "
        End If
    End Function

    Public Shared Function TableToDictionary(ByVal tabla As DataTable) As IDictionary
        Dim gson As String = JsonConvert.SerializeObject(tabla, Newtonsoft.Json.Formatting.None)
        gson = gson.Substring(1, gson.Length - 2)
        Dim dict As IDictionary(Of String, String) = New Dictionary(Of String, String)()
        dict = JsonConvert.DeserializeObject(Of IDictionary(Of String, String))(gson)
        Return dict
    End Function
    Public Shared Sub EnviarCorreo(ByVal Pantalla As String, ByVal Evento As String, ByVal ex As Exception, ByVal Mgcta As String, ByVal Captura As String, ByVal usr As String)

        Dim SSCommand As New SqlCommand("SP_ENVIAR_CORREO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_Subject", SqlDbType.NVarChar).Value = "Cliente WEB"
        SSCommand.Parameters.Add("@V_Pantalla", SqlDbType.NVarChar).Value = Pantalla
        SSCommand.Parameters.Add("@V_Evento", SqlDbType.NVarChar).Value = Evento
        SSCommand.Parameters.Add("@V_Error", SqlDbType.NVarChar).Value = ex.ToString
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = Mgcta
        SSCommand.Parameters.Add("@V_Captura", SqlDbType.NVarChar).Value = Captura
        SSCommand.Parameters.Add("@V_Usuario", SqlDbType.NVarChar).Value = usr

        Ejecuta_Procedure(SSCommand)
    End Sub

    Public Shared Sub EnviarCorreo(ByVal Pantalla As String, ByVal Evento As String, ByVal ex As String, ByVal Mgcta As String, ByVal Captura As String, ByVal usr As String)
        Dim SSCommand As New SqlCommand("SP_ENVIAR_CORREO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_Subject", SqlDbType.NVarChar).Value = "Cliente WEB"
        SSCommand.Parameters.Add("@V_Pantalla", SqlDbType.NVarChar).Value = Pantalla
        SSCommand.Parameters.Add("@V_Evento", SqlDbType.NVarChar).Value = Evento
        SSCommand.Parameters.Add("@V_Error", SqlDbType.NVarChar).Value = ex
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = Mgcta
        SSCommand.Parameters.Add("@V_Captura", SqlDbType.NVarChar).Value = Captura
        SSCommand.Parameters.Add("@V_Usuario", SqlDbType.NVarChar).Value = usr
        Ejecuta_Procedure(SSCommand)
    End Sub

    Public Shared Sub EnviarCorreoSinEx(ByVal Pantalla As String, ByVal Evento As String, ByVal ex As String, ByVal Mgcta As String, ByVal Captura As String, ByVal usr As String)
        Dim SSCommand As New SqlCommand("SP_ENVIAR_CORREO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_Subject", SqlDbType.NVarChar).Value = "Cliente WEB"
        SSCommand.Parameters.Add("@V_Pantalla", SqlDbType.NVarChar).Value = Pantalla
        SSCommand.Parameters.Add("@V_Evento", SqlDbType.NVarChar).Value = Evento
        SSCommand.Parameters.Add("@V_Error", SqlDbType.NVarChar).Value = ex
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = Mgcta
        SSCommand.Parameters.Add("@V_Captura", SqlDbType.NVarChar).Value = Captura
        SSCommand.Parameters.Add("@V_Usuario", SqlDbType.NVarChar).Value = usr
        Ejecuta_Procedure(SSCommand)
    End Sub

    Public Shared Function Codificar(ByVal V_Valor As String) As String
        Return HttpUtility.HtmlDecode(V_Valor)
    End Function

    Public Shared Sub OffLine(ByVal Usuario As String)
        Dim DtsVariable As DataTable
        Dim SSCommand As New SqlCommand("SP_INGRESO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_USUARIO", SqlDbType.NVarChar).Value = Usuario
        SSCommand.Parameters.Add("@V_CAMPANA", SqlDbType.NVarChar).Value = "TUIIO"
        SSCommand.Parameters.Add("@V_MODULO", SqlDbType.NVarChar).Value = "Gestion"
        SSCommand.Parameters.Add("@V_MOTIVO", SqlDbType.NVarChar).Value = "Expiro Sesión"
        SSCommand.Parameters.Add("@V_BANDERA", SqlDbType.Decimal).Value = 4
        DtsVariable = Consulta_Procedure(SSCommand, "Licencias")
    End Sub

    Public Shared Sub AUDITORIA(ByVal USUARIO As String, ByVal MODULO As String, ByVal PAGINA As String, ByVal CREDITO As String, ByVal EVENTO As String, ByVal VALOR As String, ByVal IPPUBLICA As String, ByVal IPPRIVADA As String)
        Dim SSCommand As New SqlCommand("SP_AUDITORIA")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_USUARIO", SqlDbType.NVarChar).Value = USUARIO
        SSCommand.Parameters.Add("@V_MODULO", SqlDbType.NVarChar).Value = MODULO
        SSCommand.Parameters.Add("@V_PAGINA", SqlDbType.NVarChar).Value = PAGINA
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = CREDITO
        SSCommand.Parameters.Add("@V_EVENTO", SqlDbType.NVarChar).Value = EVENTO
        SSCommand.Parameters.Add("@V_VALOR", SqlDbType.NVarChar).Value = VALOR
        SSCommand.Parameters.Add("@V_IPPUBLICA", SqlDbType.NVarChar).Value = IPPUBLICA
        SSCommand.Parameters.Add("@V_IPPRIVADA", SqlDbType.NVarChar).Value = IPPRIVADA
        Ejecuta_Procedure(SSCommand)
    End Sub
    Public Shared Function EmailValida(ByVal correo As String) As Boolean
        Dim atCnt As String
        Dim revCorreo As Boolean = 0
        If Len(correo) < 5 Then
            revCorreo = True
        ElseIf InStr(correo, "@") = 0 Then
            revCorreo = True
        ElseIf InStr(correo, ".") = 0 Then
            revCorreo = True
        ElseIf Len(correo) - InStrRev(correo, ".") > 4 Then
            revCorreo = True
        Else
            atCnt = 0
            For i = 1 To Len(correo)
                If Mid(correo, i, 1) = "@" Then
                    atCnt = atCnt + 1
                End If
            Next
            If atCnt > 1 Then
                revCorreo = True
            End If
            For i = 1 To Len(correo)
                If Not IsNumeric(Mid(correo, i, 1)) And
          (LCase(Mid(correo, i, 1)) < "a" Or
          LCase(Mid(correo, i, 1)) > "z") And
          Mid(correo, i, 1) <> "_" And
          Mid(correo, i, 1) <> "." And
          Mid(correo, i, 1) <> "@" And
          Mid(correo, i, 1) <> "-" Then
                    revCorreo = True
                End If
            Next
        End If
        Return revCorreo
        'Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        'Return emailExpression.IsMatch(correo)
    End Function

    Public Shared Function Boleano(ByVal valor As String) As Integer
        Dim bin As Integer
        If valor = True Then
            bin = 1
        Else
            bin = 0
        End If
        Return bin
    End Function

    Public Shared Function Boleano2(ByVal valor As Integer) As Boolean
        Dim bin As Integer
        If valor = 1 Then
            bin = True
        Else
            bin = False
        End If
        Return bin
    End Function

    Public Shared Function ValidaMonto(ByVal cadena As String) As Integer
        Dim CuantosCaracteres As Integer
        Dim MontoValido As Integer = 0
        CuantosCaracteres = 0
        For i = 1 To Len(cadena)
            If Mid(cadena, i, 1) = "." Then
                CuantosCaracteres = CuantosCaracteres + 1
            End If
        Next
        If CuantosCaracteres > 1 Then
            MontoValido = 1
        Else
            MontoValido = 0
        End If
        Return MontoValido
    End Function

    Public Shared Function ppvigente(ByVal cuenta As String) As Integer
        Dim SSCommand As New SqlCommand("SP_AUDITORIA")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = cuenta
        Dim odatatable As DataTable = Consulta_Procedure(SSCommand, "VALIDAPP")
        Dim VALIDA As Integer = odatatable.Rows(0)("EXISTE")
        Return VALIDA
    End Function

    Public Shared Function HIST_avisos(ByVal credito As String, ByVal Asigna As String, ByVal Recibe As String, ByVal folio As String, ByVal dtelimite As String, ByVal bandera As Integer) As Integer
        Dim SSCommand As New SqlCommand("SP_AVISOS_GESTION")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.NVarChar).Value = credito
        SSCommand.Parameters.Add("@v_usario_asig", SqlDbType.NVarChar).Value = Asigna
        SSCommand.Parameters.Add("@v_usuario_recibe", SqlDbType.NVarChar).Value = Recibe
        SSCommand.Parameters.Add("@v_folio", SqlDbType.NVarChar).Value = folio
        SSCommand.Parameters.Add("@v_bandera", SqlDbType.NVarChar).Value = dtelimite
        SSCommand.Parameters.Add("@V_CREDITO", SqlDbType.Decimal).Value = bandera
        Dim odatatable As DataTable = Consulta_Procedure(SSCommand, "VALIDAPP")
        Return 0
    End Function

    Public Shared Function to_money(ByRef numero As String) As String
        Dim valor As Double = CDbl(Val(numero))
        to_money = "$ " & (valor.ToString("N", CultureInfo.InvariantCulture))
        Return to_money
    End Function

    Public Shared Function to_codigos(ByVal VALOR As String, ByVal campo As Integer) As String
        Dim extrae() As String = VALOR.Split("|")
        Return extrae(campo)
    End Function

    Public Shared Sub to_excel(ByRef pagina As Page, ByVal control As Control, ByVal file As String)
        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim htw As New HtmlTextWriter(sw)
        Dim Page As New Page()
        Dim Form As New HtmlForm()
        control.EnableViewState = False
        Page.EnableEventValidation = False
        Page.DesignerInitialize()
        Page.Controls.Add(Form)
        Form.Controls.Add(control)
        Page.RenderControl(htw)
        pagina.Response.Clear()
        pagina.Response.Clear()
        pagina.Response.Buffer = True
        pagina.Response.ContentType = "text/plain"
        Dim fecha As String = Now.ToString("ddMMyyyy")
        pagina.Response.AddHeader("Content-Disposition", "attachment;filename=" & file + fecha & ".xls")
        pagina.Response.Charset = "UTF-8"
        pagina.Response.ContentEncoding = Encoding.Default
        pagina.Response.Write(sb.ToString())
        'pagina.Response.End()
    End Sub

    Public Shared Sub LLENAR_DROP(ByVal bandera As String, ByVal ITEM As DropDownList, ByVal DataValueField As String, ByVal DataTextField As String)
        Dim SSCommand As New SqlCommand("SP_CATALOGOS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_BANDERA", SqlDbType.Decimal).Value = bandera
        SSCommand.Parameters.Add("@V_Valor", SqlDbType.NVarChar).Value = ""
        Dim objDSa As DataTable = Consulta_Procedure(SSCommand, "PROD")
        ITEM.Visible = True
        If objDSa.Rows.Count >= 1 Then
            ITEM.DataTextField = DataTextField
            ITEM.DataValueField = DataValueField
            ITEM.DataSource = objDSa
            ITEM.DataBind()
            ITEM.Items.Add("Seleccione")
            ITEM.SelectedValue = "Seleccione"
        Else
            ITEM.Visible = False
        End If
    End Sub

    Public Shared Function GuardarGestion(ByVal v_HIST_GE_CREDITO As String, ByVal v_HIST_GE_PRODUCTO As String, ByVal v_HIST_GE_USUARIO As String, ByVal V_CODACCION As String, ByVal v_HIST_GE_RESULTADO As String, ByVal v_HIST_GE_CODIGO As String, ByVal V_CODNOPAGO As String, ByVal v_HIST_GE_COMENTARIO As String, ByVal v_HIST_GE_INOUTBOUND As Integer, ByVal v_HIST_GE_TELEFONO As String, ByVal v_HIST_GE_AGENCIA As String, ByVal V_DTECONTACTO As String, ByVal V_CONFIGURACION As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_ADD_HIST_GESTIONES")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_HIST_GE_CREDITO", SqlDbType.Decimal).Value = v_HIST_GE_CREDITO
        SSCommand.Parameters.Add("@v_HIST_GE_PRODUCTO", SqlDbType.NVarChar).Value = "%" & v_HIST_GE_PRODUCTO & "%"
        SSCommand.Parameters.Add("@v_HIST_GE_USUARIO", SqlDbType.NVarChar).Value = v_HIST_GE_USUARIO
        SSCommand.Parameters.Add("@V_CODACCION", SqlDbType.NVarChar).Value = V_CODACCION
        SSCommand.Parameters.Add("@v_HIST_GE_RESULTADO", SqlDbType.NVarChar).Value = v_HIST_GE_RESULTADO
        SSCommand.Parameters.Add("@v_HIST_GE_CODIGO", SqlDbType.NVarChar).Value = v_HIST_GE_CODIGO
        SSCommand.Parameters.Add("@V_CODNOPAGO", SqlDbType.NVarChar).Value = V_CODNOPAGO
        SSCommand.Parameters.Add("@v_HIST_GE_COMENTARIO", SqlDbType.NVarChar).Value = v_HIST_GE_COMENTARIO
        SSCommand.Parameters.Add("@v_HIST_GE_INOUTBOUND", SqlDbType.Decimal).Value = v_HIST_GE_INOUTBOUND
        SSCommand.Parameters.Add("@v_HIST_GE_TELEFONO", SqlDbType.NVarChar).Value = v_HIST_GE_TELEFONO
        SSCommand.Parameters.Add("@v_HIST_GE_AGENCIA", SqlDbType.NVarChar).Value = v_HIST_GE_AGENCIA
        SSCommand.Parameters.Add("@V_DTECONTACTO", SqlDbType.NVarChar).Value = V_DTECONTACTO
        SSCommand.Parameters.Add("@V_CONFIGURACION", SqlDbType.NVarChar).Value = V_CONFIGURACION
        Dim DtsGestion As DataTable = Consulta_Procedure(SSCommand, "Gestion")
        Return DtsGestion
    End Function

    Public Shared Function GuardarPromesa(ByVal v_HIST_PR_CREDITO As String, ByVal v_HIST_PR_PRODUCTO As String, ByVal v_HIST_PR_MONTOPP As Double, ByVal v_HIST_PR_DTEPROMESA As String, ByVal v_HIST_PR_USUARIO As String, ByVal v_HIST_PR_TIPO As String, ByVal v_HIST_PR_CONSECUTIVO As Integer, ByVal v_HIST_PR_ORIGEN As String, ByVal v_HIST_PR_AGENCIA As String, ByVal V_CODACCION As String, ByVal v_HIST_GE_RESULTADO As String, ByVal v_HIST_GE_CODIGO As String, ByVal v_HIST_GE_COMENTARIO As String, ByVal v_HIST_VI_DTEVISITA As String, ByVal v_HIST_GE_TELEFONO As String, ByVal v_HIST_GE_INOUTBOUND As Integer, ByVal V_CONFIGURACION As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_ADD_HIST_PROMESAS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_HIST_GE_CREDITO", SqlDbType.NVarChar).Value = v_HIST_PR_CREDITO
        SSCommand.Parameters.Add("@v_HIST_PR_PRODUCTO", SqlDbType.NVarChar).Value = "%" & v_HIST_PR_PRODUCTO & "%"
        SSCommand.Parameters.Add("@v_HIST_PR_MONTOPP", SqlDbType.Decimal).Value = v_HIST_PR_MONTOPP
        SSCommand.Parameters.Add("@v_HIST_PR_DTEPROMESA", SqlDbType.NVarChar).Value = v_HIST_PR_DTEPROMESA
        SSCommand.Parameters.Add("@v_HIST_PR_USUARIO", SqlDbType.NVarChar).Value = v_HIST_PR_USUARIO
        SSCommand.Parameters.Add("@v_HIST_PR_TIPO", SqlDbType.NVarChar).Value = v_HIST_PR_TIPO
        SSCommand.Parameters.Add("@v_HIST_PR_CONSECUTIVO", SqlDbType.Decimal).Value = v_HIST_PR_CONSECUTIVO
        SSCommand.Parameters.Add("@v_HIST_PR_ORIGEN", SqlDbType.NVarChar).Value = v_HIST_PR_ORIGEN
        SSCommand.Parameters.Add("@v_HIST_PR_AGENCIA", SqlDbType.NVarChar).Value = v_HIST_PR_AGENCIA
        SSCommand.Parameters.Add("@V_CODACCION", SqlDbType.NVarChar).Value = V_CODACCION
        SSCommand.Parameters.Add("@v_HIST_GE_RESULTADO", SqlDbType.NVarChar).Value = v_HIST_GE_RESULTADO
        SSCommand.Parameters.Add("@v_HIST_GE_CODIGO", SqlDbType.NVarChar).Value = v_HIST_GE_CODIGO
        SSCommand.Parameters.Add("@v_HIST_GE_COMENTARIO", SqlDbType.NVarChar).Value = v_HIST_GE_COMENTARIO
        SSCommand.Parameters.Add("@v_HIST_VI_DTEVISITA", SqlDbType.NVarChar).Value = v_HIST_VI_DTEVISITA
        SSCommand.Parameters.Add("@v_HIST_GE_TELEFONO", SqlDbType.NVarChar).Value = v_HIST_GE_TELEFONO
        SSCommand.Parameters.Add("@v_HIST_GE_INOUTBOUND", SqlDbType.Decimal).Value = v_HIST_GE_INOUTBOUND
        SSCommand.Parameters.Add("@V_CONFIGURACION", SqlDbType.NVarChar).Value = V_CONFIGURACION
        Dim DtsPromesa As DataTable = Consulta_Procedure(SSCommand, "Gestion")
        Return DtsPromesa
    End Function

    ''' <summary>
    ''' Establece los parametros para mostrar una notificacion
    ''' </summary>
    ''' <param name="Notificacion">Objeto RadNotification de Telerik</param>
    ''' <param name="icono">info - delete - deny - edit - ok - warning - none</param>
    ''' <param name="titulo">título de la notificación</param>
    ''' <param name="msg">mensaje de la notificación</param>
    Public Shared Sub showModal(ByRef Notificacion As Object, ByVal icono As String, ByVal titulo As String, ByVal msg As String)
        Dim radnot As RadNotification = TryCast(Notificacion, RadNotification)
        radnot.TitleIcon = icono
        radnot.ContentIcon = icono
        radnot.Title = titulo
        radnot.Text = msg
        radnot.Show()
    End Sub

    Public Shared Sub LLENAR_DROP2(ByVal bandera As String, ByVal condicion As String, ByVal ITEM As RadComboBox, ByVal DataValueField As String, ByVal DataTextField As String)
        Dim SSCommand As New SqlCommand("SP_CATALOGOS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_BANDERA", SqlDbType.NVarChar).Value = bandera
        SSCommand.Parameters.Add("@V_Valor", SqlDbType.NVarChar).Value = condicion
        Dim objDSa As DataTable = Consulta_Procedure(SSCommand, "PROD")
        ITEM.Visible = True
        If objDSa.Rows.Count >= 1 Then
            ITEM.DataTextField = DataTextField
            ITEM.DataValueField = DataValueField
            ITEM.DataSource = objDSa
            ITEM.DataBind()
        Else
            ITEM.EmptyMessage = "No aplica"
            ITEM.Enabled = False
        End If
    End Sub
    Public Shared Sub LLENAR_DROP2(ByVal bandera As String, ByVal condicion As String, ByVal ITEM As RadComboBox, ByVal DataValueField As String, ByVal DataTextField As String, ByVal condicion2 As String)
        Dim SSCommand As New SqlCommand("SP_CATALOGOS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_BANDERA", SqlDbType.NVarChar).Value = bandera
        SSCommand.Parameters.Add("@V_Valor", SqlDbType.NVarChar).Value = condicion
        SSCommand.Parameters.Add("@V_Valor2", SqlDbType.NVarChar).Value = condicion2
        Dim objDSa As DataTable = Consulta_Procedure(SSCommand, "PROD")
        ITEM.Visible = True
        If objDSa.Rows.Count >= 1 Then
            ITEM.DataTextField = DataTextField
            ITEM.DataValueField = DataValueField
            ITEM.DataSource = objDSa
            ITEM.DataBind()
        Else
            ITEM.Visible = False
        End If
    End Sub
    Public Shared Function Separador(ByRef numero As String, ByVal V_Tipo As String) As String
        If V_Tipo = "Sum" Then
            Dim valor As Double = CDbl(Val(numero))
            Separador = (valor.ToString("N", CultureInfo.InvariantCulture))
        Else
            Separador = FormatNumber(numero, 0)
        End If
        Return Separador
    End Function
End Class
