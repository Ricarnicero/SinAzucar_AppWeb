Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Db
Public Class SP
    Public Shared Function ACTUALIZA_UIDS(v_valor As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_ACTUALIZA_UDIS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = v_valor
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_ARCHIVO(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_AVISOS(V_BANDERA As String, V_HIST_AV_DTEEXPIRA As String, V_HIST_AV_ESTATUS As String, V_HIST_AV_MENSAJE As String, V_HIST_AV_PRIORIDAD As String, V_HIST_AV_EMISOR As String, V_HIST_AV_RECEPTOR As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_ADD_AVISOS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_HIST_AV_DTEEXPIRA", SqlDbType.NVarChar).Value = V_HIST_AV_DTEEXPIRA
        SSCommand.Parameters.Add("@V_HIST_AV_ESTATUS", SqlDbType.NVarChar).Value = V_HIST_AV_ESTATUS
        SSCommand.Parameters.Add("@V_HIST_AV_MENSAJE", SqlDbType.NVarChar).Value = V_HIST_AV_MENSAJE
        SSCommand.Parameters.Add("@V_HIST_AV_PRIORIDAD", SqlDbType.NVarChar).Value = V_HIST_AV_PRIORIDAD
        SSCommand.Parameters.Add("@V_HIST_AV_EMISOR", SqlDbType.NVarChar).Value = V_HIST_AV_EMISOR
        SSCommand.Parameters.Add("@V_HIST_AV_RECEPTOR", SqlDbType.NVarChar).Value = V_HIST_AV_RECEPTOR
        SSCommand.Parameters.Add("@V_BANDERA", SqlDbType.NVarChar).Value = V_BANDERA
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CAT_AGENCIAS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CAT_BLOQUEO_MEDIOS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CAT_REPORTE_DETALLE(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CAT_REPORTE_GRAFICA(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CATALOGOS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_CODIGOS(V_Cat_Co_Id As Integer, V_Cat_Co_Accion As String, V_Cat_Co_Adescripcion As String, V_Cat_Co_Resultado As String,
        V_Cat_Co_Rdescripcion As String, V_Cat_Co_Significativo As Integer,
        V_Cat_Co_Perfiles As String, V_Cat_Co_Ponderacion As String, V_Cat_Co_Producto As String, V_Cat_Co_Configuracion As Integer,
        V_Cat_Co_Verde As Integer, V_Cat_Co_Amarillo As Integer, V_Cat_Co_Tipo As Integer, ByVal V_Cat_Co_NoPago As String, ByVal V_Cat_Co_Atencion_A As Integer, V_Bandera As Integer, Optional ByVal V_Cat_Co_Instancia As String = "", Optional ByVal V_Cat_Co_R1 As String = "", Optional ByVal V_Cat_Co_R2 As String = "", Optional ByVal V_Cat_Co_R3 As String = "") As DataTable
        Dim SSCommandCodigos As New SqlCommand
        SSCommandCodigos.CommandText = "Sp_Add_Codigos"
        SSCommandCodigos.CommandType = CommandType.StoredProcedure
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Id", SqlDbType.Decimal).Value = V_Cat_Co_Id
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Accion", SqlDbType.NVarChar).Value = V_Cat_Co_Accion
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Adescripcion", SqlDbType.NVarChar).Value = HttpUtility.HtmlDecode(V_Cat_Co_Adescripcion)
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Resultado", SqlDbType.NVarChar).Value = V_Cat_Co_Resultado
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Rdescripcion", SqlDbType.NVarChar).Value = HttpUtility.HtmlDecode(V_Cat_Co_Rdescripcion)
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Significativo", SqlDbType.Decimal).Value = V_Cat_Co_Significativo
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Perfiles", SqlDbType.NVarChar).Value = V_Cat_Co_Perfiles
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Ponderacion", SqlDbType.NVarChar).Value = V_Cat_Co_Ponderacion
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Producto", SqlDbType.NVarChar).Value = V_Cat_Co_Producto
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Configuracion", SqlDbType.Decimal).Value = V_Cat_Co_Configuracion
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Verde", SqlDbType.Decimal).Value = V_Cat_Co_Verde
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Amarillo", SqlDbType.Decimal).Value = V_Cat_Co_Amarillo
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Tipo", SqlDbType.Decimal).Value = V_Cat_Co_Tipo
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_NoPago", SqlDbType.NVarChar).Value = V_Cat_Co_NoPago
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_Atencion_A", SqlDbType.Decimal).Value = V_Cat_Co_Atencion_A
        ' SSCommandCodigos.Parameters.Add("@V_Cat_Co_Instancia", SqlDbType.NVarChar).Value = V_Cat_Co_Instancia
        SSCommandCodigos.Parameters.Add("@V_Cat_Co_R1", SqlDbType.NVarChar).Value = V_Cat_Co_R1
        'SSCommandCodigos.Parameters.Add("@V_Cat_Co_R2", SqlDbType.NVarChar).Value = V_Cat_Co_R2
        'SSCommandCodigos.Parameters.Add("@V_Cat_Co_R3", SqlDbType.NVarChar).Value = V_Cat_Co_R3
        SSCommandCodigos.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = V_Bandera
        Return Consulta_Procedure(SSCommandCodigos, "Codigos")
    End Function

    Public Shared Function ADD_ETIQUETAS_CORREO(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_CORREO(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_DIRECCIONES(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_GESTIONES(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_PAGOS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_PROMESAS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_HIST_TELEFONOS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand("SP_RP_MONITOREO_V2")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_LOGINS(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function ADD_NEGOCIACIONES(valores As IDictionary) As DataTable
        Dim SSCommand As New SqlCommand
        SSCommand.CommandText = "SP_RP_MONITOREO_V2"
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_valor", SqlDbType.NVarChar).Value = valores("v_valor")
        Return Consulta_Procedure(SSCommand, "Filtros")
    End Function

    Public Shared Function INFOUSUARIOS(ByVal V_Usuario As String, ByVal V_Condicion As String, ByVal V_Bandera As String) As DataTable
        Dim SSCOMMAND As New SqlCommand("SP_INFOUSUARIOS")
        SSCOMMAND.CommandType = CommandType.StoredProcedure
        SSCOMMAND.Parameters.Add("@V_Usuario", SqlDbType.NVarChar).Value = V_Usuario
        SSCOMMAND.Parameters.Add("@V_Condicion", SqlDbType.NVarChar).Value = V_Condicion
        SSCOMMAND.Parameters.Add("@V_Bandera", SqlDbType.NVarChar).Value = V_Bandera
        Dim DtsUsuarios As DataTable = Consulta_Procedure(SSCOMMAND, "ELEMENTOS")
        Return DtsUsuarios
    End Function
    Public Shared Function MONITOREO(ByVal V_Usuario As String, ByVal V_Sucursales As String, ByVal V_Bandera As Integer) As DataTable
        Dim SSCOMMAND As New SqlCommand("SP_MONITOREO")
        SSCOMMAND.CommandType = CommandType.StoredProcedure
        SSCOMMAND.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = V_Bandera
        SSCOMMAND.Parameters.Add("@v_sucursales", SqlDbType.NVarChar).Value = V_Sucursales
        SSCOMMAND.Parameters.Add("@V_Usuario", SqlDbType.NVarChar).Value = V_Usuario
        Dim DtsUsuarios As DataTable = Consulta_Procedure(SSCOMMAND, "ELEMENTOS")
        Return DtsUsuarios
    End Function

    Public Shared Function RP_MONITOREO_V2(ByVal V_agrupacion As String, ByVal V_tipo As String, ByVal v_filtro As String, ByVal v_Tipotope As String, ByVal V_Bandera As Integer) As DataTable
        Dim cadenacomas As String = "'"

        If V_tipo = "1" Then
            V_agrupacion = "'" & V_agrupacion & "'"
            V_agrupacion = V_agrupacion.Replace(",", "','")
        End If

        v_filtro = "'" & v_filtro & "'"
        v_filtro = v_filtro.Replace(",", "','")

        Dim SSCOMMAND As New SqlCommand("SP_RP_MONITOREO_V2")
        SSCOMMAND.CommandType = CommandType.StoredProcedure
        SSCOMMAND.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = V_Bandera
        SSCOMMAND.Parameters.Add("@v_dato1", SqlDbType.NVarChar).Value = V_agrupacion
        SSCOMMAND.Parameters.Add("@v_dato2", SqlDbType.NVarChar).Value = V_tipo
        SSCOMMAND.Parameters.Add("@v_dato3", SqlDbType.NVarChar).Value = v_filtro
        SSCOMMAND.Parameters.Add("@v_condiciones", SqlDbType.NVarChar).Value = v_Tipotope
        Dim DtsUsuarios As DataTable = Consulta_Procedure(SSCOMMAND, "ELEMENTOS")
        Return DtsUsuarios
    End Function

    Public Shared Function RP_SOLICITUDINVCAMPO(ByVal V_Bandera As Integer, Optional V_Usuario As String = "", Optional V_Agencia As String = "", Optional V_condiciones As String = "") As DataTable
        Dim SSCommand As New SqlCommand("SP_RP_SOLICITUDINVCAMPO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_bandera", SqlDbType.Decimal).Value = V_Bandera
        SSCommand.Parameters.Add("@v_usuario", SqlDbType.NVarChar).Value = V_Usuario
        SSCommand.Parameters.Add("@v_agencia", SqlDbType.NVarChar).Value = V_Agencia
        SSCommand.Parameters.Add("@v_condiciones", SqlDbType.NVarChar).Value = V_condiciones
        Dim DtsInvCampo As DataTable = Consulta_Procedure(SSCommand, "Catalogo")
        Return DtsInvCampo
    End Function

    Public Shared Function PERMISOS(v_usuario As String, v_contrasena As String, v_modulo As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_PERMISOS")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_USUARIO", SqlDbType.NVarChar).Value = v_usuario
        SSCommand.Parameters.Add("@V_CONTRASENA", SqlDbType.NVarChar).Value = v_contrasena
        SSCommand.Parameters.Add("@V_MODULO", SqlDbType.NVarChar).Value = v_modulo
        Dim DtsPermiso As DataTable = Consulta_Procedure(SSCommand, "LogOn")
        Return DtsPermiso
    End Function

    Public Shared Function USUARIO(v_bandera As String, v_usuario As String, v_contrasena As String, v_modulo As String, Optional v_imei As String = "000") As DataTable
        Dim SSCommandL As New SqlCommand("SP_USUARIO")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_USUARIO", SqlDbType.NVarChar).Value = v_usuario
        SSCommandL.Parameters.Add("@V_CONTRASENA", SqlDbType.NVarChar).Value = v_contrasena
        SSCommandL.Parameters.Add("@V_imei", SqlDbType.NVarChar).Value = v_imei
        SSCommandL.Parameters.Add("@V_MODULO", SqlDbType.NVarChar).Value = v_modulo
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.NVarChar).Value = v_bandera
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function

    Public Shared Function AUDITORIA_GLOBAL(v_bandera As String, ByVal quien As String, ByVal donde As String, ByVal que As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_AUDITORIA_GLOBAL")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@v_quien", SqlDbType.NVarChar).Value = quien
        SSCommand.Parameters.Add("@v_donde", SqlDbType.NVarChar).Value = donde
        SSCommand.Parameters.Add("@v_que", SqlDbType.NVarChar).Value = que
        SSCommand.Parameters.Add("@v_bandera", SqlDbType.NVarChar).Value = 0
        Return Consulta_Procedure(SSCommand, "ELEMENTOS")
    End Function

    Public Shared Function INGRESO(v_bandera As String, ByVal v_usuario As String, ByVal v_ip As String, ByVal v_modulo As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_INGRESO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_USUARIO", SqlDbType.NVarChar).Value = v_usuario
        SSCommand.Parameters.Add("@V_Bandera", SqlDbType.NVarChar).Value = v_bandera
        SSCommand.Parameters.Add("@V_IP", SqlDbType.NVarChar).Value = v_ip
        SSCommand.Parameters.Add("@V_MODULO", SqlDbType.NVarChar).Value = v_modulo
        Return Consulta_Procedure(SSCommand, "ELEMENTOS")
    End Function

    Public Shared Function GUARDAR_CONTRASENA(ByVal v_usuario As String, ByVal v_contrasena As String) As DataTable
        Dim SSCommand As New SqlCommand("SP_GUARDAR_CONTRASENA")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_LUSUARIO", SqlDbType.NVarChar).Value = v_usuario
        SSCommand.Parameters.Add("@v_CONTRASENA", SqlDbType.NVarChar).Value = v_contrasena
        Return Consulta_Procedure(SSCommand, "ELEMENTOS")
    End Function
    Public Shared Function ADD_PERFILES(V_BANDERA As Integer, V_CAT_PE_PERFIL As String, V_CAT_PE_A_GESTION As String, V_CAT_PE_P_GESTION As String, V_CAT_PE_P_ADMINISTRADOR As String, V_CAT_PE_P_BACKOFFICE As String, V_CAT_PE_P_REPORTES As String, V_CAT_PE_P_MOVIL As String, V_CAT_PE_P_JUDICIAL As String, V_CAT_PE_ID As Integer, V_MODULO As Integer) As DataTable
        Dim SSCommandCat As New SqlCommand
        SSCommandCat.CommandText = "SP_ADD_PERFILES"
        SSCommandCat.CommandType = CommandType.StoredProcedure
        SSCommandCat.Parameters.Add("@V_BANDERA", SqlDbType.Decimal).Value = V_BANDERA
        SSCommandCat.Parameters.Add("@V_CAT_PE_PERFIL", SqlDbType.NVarChar).Value = V_CAT_PE_PERFIL
        SSCommandCat.Parameters.Add("@V_CAT_PE_A_GESTION", SqlDbType.NVarChar).Value = V_CAT_PE_A_GESTION
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_GESTION", SqlDbType.NVarChar).Value = V_CAT_PE_P_GESTION
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_ADMINISTRADOR", SqlDbType.NVarChar).Value = V_CAT_PE_P_ADMINISTRADOR
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_BACKOFFICE", SqlDbType.NVarChar).Value = V_CAT_PE_P_BACKOFFICE
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_REPORTES", SqlDbType.NVarChar).Value = V_CAT_PE_P_REPORTES
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_MOVIL", SqlDbType.NVarChar).Value = V_CAT_PE_P_MOVIL
        SSCommandCat.Parameters.Add("@V_CAT_PE_P_JUDICIAL", SqlDbType.NVarChar).Value = V_CAT_PE_P_JUDICIAL
        SSCommandCat.Parameters.Add("@V_CAT_PE_ID", SqlDbType.Decimal).Value = IIf(V_CAT_PE_ID = 0, 1, V_CAT_PE_ID)
        SSCommandCat.Parameters.Add("@V_MODULO", SqlDbType.Decimal).Value = V_MODULO
        Dim ds As DataTable = Consulta_Procedure(SSCommandCat, "Catalogo")
        Return ds
    End Function
    Public Shared Function Add_AGENCIAS(V_Cat_Ag_Id As Integer, V_Cat_Ag_Usuario As String, V_Cat_Ag_Nombre As String, V_Cat_Ag_Estatus As String, v_Cat_Ag_Motivo As String, V_Cat_Ag_UsuarioR As String, V_Bandera As Integer) As DataTable
        Dim SSCommand As New SqlCommand("Sp_Add_Cat_Agencias")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_Cat_Ag_Id", SqlDbType.NVarChar).Value = V_Cat_Ag_Id
        SSCommand.Parameters.Add("@V_Cat_Ag_Usuario", SqlDbType.NVarChar).Value = V_Cat_Ag_Usuario
        SSCommand.Parameters.Add("@V_Cat_Ag_Nombre", SqlDbType.NVarChar).Value = V_Cat_Ag_Nombre
        SSCommand.Parameters.Add("@V_Cat_Ag_Estatus", SqlDbType.NVarChar).Value = V_Cat_Ag_Estatus
        SSCommand.Parameters.Add("@v_Cat_Ag_Motivo", SqlDbType.NVarChar).Value = v_Cat_Ag_Motivo
        SSCommand.Parameters.Add("@V_Cat_Ag_UsuarioR", SqlDbType.NVarChar).Value = V_Cat_Ag_UsuarioR
        SSCommand.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = V_Bandera
        Dim DtsVarios As DataTable = Consulta_Procedure(SSCommand, "Agencias")

        Return DtsVarios
    End Function

    Public Shared Function CARGA_ASIGNACION_MOVIL(bandera As Integer, usuario As String, dt As DataTable) As DataTable
        Dim SSCommand2 As New SqlCommand("SP_CARGA_ASIGNACION_MOVIL") With {
                            .CommandType = CommandType.StoredProcedure
                        }
        SSCommand2.Parameters.Add(New SqlParameter("@DT_CARGA_ASIGNACION", dt))
        SSCommand2.Parameters.Add("@V_USUARIO", SqlDbType.VarChar).Value = usuario
        SSCommand2.Parameters.Add("@V_BANDERA", SqlDbType.Int).Value = bandera
        Return Consulta_Procedure(SSCommand2, "SP_CARGA_CARTERA")
    End Function

    Public Shared Function CARGA_CARTERA(bandera As Integer, usuario As String, dt As DataTable) As DataTable
        Dim SSCommand2 As New SqlCommand("SP_CARGA_CARTERA") With {
                            .CommandType = CommandType.StoredProcedure
                        }
        SSCommand2.CommandTimeout = 1800
        SSCommand2.Parameters.Add(New SqlParameter("@DT_CARGA_CLIENTE", dt))
        SSCommand2.Parameters.Add("@V_USUARIO", SqlDbType.VarChar).Value = usuario
        SSCommand2.Parameters.Add("@V_BANDERA", SqlDbType.Int).Value = bandera
        Return Consulta_Procedure(SSCommand2, "SP_CARGA_CARTERA")
    End Function
    Public Shared Function INFORMACION_CREDITO(credito As String, bandera As Integer) As DataTable
        Dim SSCommand As New SqlCommand("SP_INFORMACION_CREDITO")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_Credito", SqlDbType.NVarChar).Value = credito
        SSCommand.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = bandera
        Return Consulta_Procedure(SSCommand, "SP_INFORMACION_CREDITO")
    End Function
    Public Shared Function IMAGENES_LOGIN(ID As Integer, bandera As Integer, Optional imagen As Byte() = Nothing) As DataTable
        Dim SSCommand As New SqlCommand("SP_IMAGENES_LOGIN")
        SSCommand.CommandType = CommandType.StoredProcedure
        SSCommand.Parameters.Add("@V_ID", SqlDbType.Decimal).Value = ID
        SSCommand.Parameters.Add("@V_Bandera", SqlDbType.Decimal).Value = bandera
        If imagen IsNot Nothing Then
            SSCommand.Parameters.Add("@V_Imagen", SqlDbType.VarBinary).Value = imagen
        End If
        Return Consulta_Procedure(SSCommand, "SP_INFORMACION_CREDITO")
    End Function
End Class
