﻿Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Db
Public Class SP

    Public Shared Function USUARIO(v_bandera As String, Optional v_nombre As String = "", Optional v_correo As String = "", Optional v_contrasena As String = "", Optional v_edad As String = "", Optional v_ing As String = "", Optional imagen As Byte() = Nothing) As DataTable
        Dim SSCommandL As New SqlCommand("SP_USUARIO")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_NOMBRE", SqlDbType.VarChar).Value = v_nombre
        SSCommandL.Parameters.Add("@V_CORREO", SqlDbType.VarChar).Value = v_correo
        SSCommandL.Parameters.Add("@V_CONTRASENA", SqlDbType.VarChar).Value = v_contrasena
        SSCommandL.Parameters.Add("@V_EDAD", SqlDbType.VarChar).Value = v_edad
        SSCommandL.Parameters.Add("@V_INGR", SqlDbType.VarChar).Value = v_ing
        SSCommandL.Parameters.Add("@V_FOTO_PERFIL", SqlDbType.VarBinary).Value = imagen
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.VarChar).Value = v_bandera
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function
    Public Shared Function ADD_RECETA(v_bandera As String, Optional V_RECETA_ID As String = "", Optional V_NOMBRE As String = "", Optional V_USR_ID As String = "", Optional V_DESCRIPCION As String = "", Optional V_LINK_VIDEO As String = "", Optional V_INGREDIENTES As String = "", Optional V_IMAGEN As Byte() = Nothing, Optional V_PASO As String = "", Optional V_DIFICULTAD As String = "", Optional V_CANTIDAD As String = "", Optional V_MEDIDA As String = "", Optional V_HTML As String = "") As DataTable
        Dim SSCommandL As New SqlCommand("SP_ADD_RECETA")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_RECETA_ID", SqlDbType.VarChar).Value = V_RECETA_ID
        SSCommandL.Parameters.Add("@V_NOMBRE", SqlDbType.VarChar).Value = V_NOMBRE
        SSCommandL.Parameters.Add("@V_USR_ID", SqlDbType.VarChar).Value = V_USR_ID
        SSCommandL.Parameters.Add("@V_DESCRIPCION", SqlDbType.VarChar).Value = V_DESCRIPCION
        SSCommandL.Parameters.Add("@V_LINK_VIDEO", SqlDbType.VarChar).Value = V_LINK_VIDEO
        SSCommandL.Parameters.Add("@V_CANTIDAD", SqlDbType.VarChar).Value = V_CANTIDAD
        SSCommandL.Parameters.Add("@V_MEDIDA", SqlDbType.VarChar).Value = V_MEDIDA
        SSCommandL.Parameters.Add("@V_INGREDIENTES", SqlDbType.VarChar).Value = V_INGREDIENTES
        SSCommandL.Parameters.Add("@V_HTML", SqlDbType.VarChar).Value = V_HTML
        SSCommandL.Parameters.Add("@V_PASO", SqlDbType.VarChar).Value = V_PASO
        SSCommandL.Parameters.Add("@V_DIFICULTAD", SqlDbType.VarChar).Value = V_DIFICULTAD
        SSCommandL.Parameters.Add("@V_IMAGEN", SqlDbType.VarBinary).Value = V_IMAGEN
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.Int).Value = v_bandera
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function

    Public Shared Function DISPLAY_RECETAS(v_bandera As String, Optional V_RECETA_ID As String = Nothing, Optional V_WHERE As String = Nothing) As DataTable
        Dim SSCommandL As New SqlCommand("SP_DISPLAY_RECETAS")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_WHERE", SqlDbType.VarChar).Value = V_WHERE
        SSCommandL.Parameters.Add("@V_RECETA_ID", SqlDbType.VarChar).Value = V_RECETA_ID
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.Int).Value = v_bandera
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function

    Public Shared Function ADD_INGREDIENTE(v_bandera As String, Optional v_ingrediente As String = "") As DataTable
        Dim SSCommandL As New SqlCommand("SP_ADD_INGREDIENTE")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.Int).Value = v_bandera
        SSCommandL.Parameters.Add("@v_ingrediente", SqlDbType.VarChar).Value = v_ingrediente
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function

    Public Shared Function MI_SALUD(v_bandera As Integer, Optional v_id As Integer = Nothing, Optional v_valor As Double = Nothing, Optional v_tipo As Integer = Nothing, Optional v_fecha As Date = Nothing) As DataTable
        Dim SSCommandL As New SqlCommand("SP_MI_SALUD")
        SSCommandL.CommandType = CommandType.StoredProcedure
        SSCommandL.Parameters.Add("@V_Bandera", SqlDbType.Int).Value = v_bandera
        SSCommandL.Parameters.Add("@v_id", SqlDbType.Int).Value = v_id
        SSCommandL.Parameters.Add("@v_valor", SqlDbType.Int).Value = v_valor
        SSCommandL.Parameters.Add("@v_tipo", SqlDbType.Float).Value = v_tipo
        SSCommandL.Parameters.Add("@v_fecha", SqlDbType.Date).Value = v_fecha
        Dim DtsLogin As DataTable = Consulta_Procedure(SSCommandL, "LogOn")
        Return DtsLogin
    End Function

End Class
