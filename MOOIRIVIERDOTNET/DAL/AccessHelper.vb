Imports System.Configuration
Imports System.Data.OleDb
Imports System.Collections.Specialized

Namespace DAL
    Public Class AccessHelper
        Private Shared parmCache As Hashtable = Hashtable.Synchronized(New Hashtable())

        Public Shared Function DefaultConnectionString() As String
            Return ConfigurationManager.AppSettings("AccessConn").ToString()
        End Function

        Public Shared Function GetConnection() As OleDbConnection
            Return GetConnection(DefaultConnectionString)
        End Function

        Public Shared Function GetConnection(ByVal connectionString) As OleDbConnection
            Return New OleDbConnection(connectionString)
        End Function

        Public Shared Function ExecuteNonQuery(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Integer
            Dim rowsAffected As Integer = 0
            Dim conn As New OleDbConnection(DefaultConnectionString())
            ' rowsAffected = ExecuteNonQuery(conn, cmdType, cmdText, commandParameters)
            rowsAffected = ExecuteNonQuery(DefaultConnectionString, cmdType, cmdText, commandParameters)
            Return rowsAffected
        End Function

        Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Integer
            Dim rowsAffected As Integer = 0
            Dim conn As New OleDbConnection(connectionString)
            'rowsAffected = ExecuteNonQuery(conn, cmdType, cmdText, commandParameters)
            rowsAffected = ExecuteNonQuery(connectionString, cmdType, cmdText, commandParameters)
            Return rowsAffected
        End Function

        Public Shared Function ReturnDataset(ByVal conn As OleDbConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As DataSet
            Dim ds As DataSet = New DataSet()
            Using cmd As New OleDbCommand()
                PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                da.Fill(ds, "LOCO_USERS")
            End Using
            Return ds
        End Function
        Public Shared Function ExecuteNonQuery(ByVal conn As OleDbConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Integer
            Dim rowsAffected As Integer
            Using cmd As New OleDbCommand()
                cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
                PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
            Return rowsAffected
        End Function


        Public Shared Function ExecuteNonQuery(ByVal trans As OleDbTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Integer
            Dim rowsAffected As Integer
            Using cmd As New OleDbCommand()
                cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters)
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
            Return rowsAffected
        End Function

        Public Shared Function ExecuteReader(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As OleDbDataReader
            Dim reader As OleDbDataReader
            Dim conn As New OleDbConnection(DefaultConnectionString())
            'reader = ExecuteReader(conn, cmdType, cmdText, commandParameters)
            reader = ExecuteReader(DefaultConnectionString, cmdType, cmdText, commandParameters)
            Return reader
        End Function

        Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As OleDbDataReader
            Dim reader As OleDbDataReader
            Dim conn As New OleDbConnection(connectionString)
            'reader = ExecuteReader(conn, cmdType, cmdText, commandParameters)
            reader = ExecuteReader(connectionString, cmdType, cmdText, commandParameters)
            Return reader
        End Function

        Public Shared Function ExecuteReader(ByVal conn As OleDbConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As OleDbDataReader
            Dim reader As OleDbDataReader = Nothing
            Using cmd As New OleDbCommand()
                cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
                conn.ConnectionString = DefaultConnectionString()
                PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
                reader = cmd.ExecuteReader()
            End Using
            Return reader
        End Function

        Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Object
            Dim value As Object
            Dim conn As New OleDbConnection(connectionString)
            value = ExecuteScalar(conn, cmdType, cmdText, commandParameters)
            Return value
        End Function

        Public Shared Function ExecuteScalar(ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Object
            Dim conn As New OleDbConnection(DefaultConnectionString())
            Return ExecuteScalar(conn, cmdType, cmdText, commandParameters)
        End Function

        Public Shared Function ExecuteScalar(ByVal conn As OleDbConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal ParamArray commandParameters() As OleDbParameter) As Object
            Dim value As Object
            Using cmd As New OleDbCommand()
                cmd.CommandTimeout = ConfigurationManager.AppSettings("commandTimeOut")
                PrepareCommand(cmd, conn, Nothing, cmdType, cmdText, commandParameters)
                value = cmd.ExecuteScalar()
            End Using
            Return value
        End Function

        Public Shared Sub CacheParameters(ByVal cacheKey As String, ByVal ParamArray commandParameters() As OleDbParameter)
            parmCache(cacheKey) = commandParameters
        End Sub

        Public Shared Function GetCachedParameters(ByVal cacheKey As String) As OleDbParameter()
            Dim cachedParms() As OleDbParameter = DirectCast(parmCache(cacheKey), OleDbParameter())

            If cachedParms Is Nothing Then
                Return Nothing
            End If
            Dim clonedParms(cachedParms.Length) As OleDbParameter
            For i As Integer = 0 To cachedParms.Length - 1
                clonedParms(i) = DirectCast(DirectCast(cachedParms(i), ICloneable).Clone, OleDbParameter)
            Next
            Return clonedParms
        End Function

        Private Shared Sub PrepareCommand(ByVal cmd As OleDbCommand, ByVal conn As OleDbConnection, ByVal trans As OleDbTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms() As OleDbParameter)
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
                For Each parm As OleDbParameter In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
        End Sub
    End Class

End Namespace