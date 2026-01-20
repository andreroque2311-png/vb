Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Data

Public Class DatabaseConnection
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("BibliotecaEscolarDB").ConnectionString

    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Public Shared Function ExecuteQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As MySqlConnection = GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Shared Function ExecuteNonQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As Integer
        Using conn As MySqlConnection = GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Shared Function ExecuteScalar(query As String, Optional parameters As MySqlParameter() = Nothing) As Object
        Using conn As MySqlConnection = GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If
                conn.Open()
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function
End Class
