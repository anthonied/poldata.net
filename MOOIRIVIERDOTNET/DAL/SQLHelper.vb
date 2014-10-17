Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class SqlHelper
    Public Shared Function DefaultConnectionString() As String
        Return ConfigurationManager.AppSettings("SqlConn").ToString()
    End Function

    Public Shared Function GetConnection() As SqlConnection
        Return GetConnection(DefaultConnectionString)
    End Function

    Private Shared Function GetConnection(ByVal connectionString) As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public Shared Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Dim rowsAffected As Integer = 0
        Dim conn As New SqlConnection(DefaultConnectionString())
        rowsAffected = ExecuteNonQuery(conn, cmdType, cmdText, commandParameters)
        Return rowsAffected
        'Linkie 28/03/2013 - close connection to database - error with timeout
        conn.Close()
    End Function

    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Dim rowsAffected As Integer = 0
        Dim conn As New SqlConnection(connectionString)
        rowsAffected = ExecuteNonQuery(conn, cmdType, cmdText, commandParameters)
        Return rowsAffected
        'Linkie 28/03/2013 - close connection to database - error with timeout
        conn.Close()
    End Function

    Public Shared Function ExecuteNonQuery(ByVal conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Dim rowsAffected As Integer
        Using cmd As New SqlCommand()
            cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
            PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
            rowsAffected = cmd.ExecuteNonQuery()
        End Using
        Return rowsAffected
    End Function

    Public Shared Function ExecuteNonQuery(ByVal trans As SqlTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As Integer
        Dim rowsAffected As Integer
        Using cmd As New SqlCommand()
            cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters)
            rowsAffected = cmd.ExecuteNonQuery()
        End Using
        Return rowsAffected
    End Function

    Public Shared Function ExecuteReader(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Dim reader As SqlDataReader
        Dim conn As New SqlConnection(DefaultConnectionString())
        reader = ExecuteReader(conn, cmdType, cmdText, commandParameters)
        Return reader
        'Linkie 28/03/2013 - close connection to database - error with timeout
        conn.Close()
    End Function

    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Dim reader As SqlDataReader
        Dim conn As New SqlConnection(connectionString)
        reader = ExecuteReader(conn, cmdType, cmdText, commandParameters)
        Return reader
        'Linkie 28/03/2013 - close connection to database - error with timeout
        conn.Close()
    End Function

    Public Shared Function ExecuteReader(ByVal conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Dim reader As SqlDataReader = Nothing
        Using cmd As New SqlCommand()
            cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
            PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
            reader = cmd.ExecuteReader()
        End Using
        Return reader
    End Function

    Private Shared Sub PrepareCommand(ByVal cmd As SqlCommand, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms() As SqlParameter)
        If (conn.State <> ConnectionState.Open) Then
            conn.Open()
        End If
        cmd.Connection = conn
        cmd.CommandText = cmdText
        If trans IsNot Nothing Then
            cmd.Transaction = trans
        End If
        cmd.CommandType = cmdType
        If cmdParms IsNot Nothing Then
            For Each parm As SqlParameter In cmdParms
                cmd.Parameters.Add(parm)
            Next
        End If
    End Sub
End Class
