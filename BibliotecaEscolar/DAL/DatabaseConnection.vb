Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class DatabaseConnection
        Private connectionString As String = "Server=localhost;Database=biblioteca_escolar;Uid=root;Pwd=;"

        Public Function GetConnection() As MySqlConnection
            Return New MySqlConnection(connectionString)
        End Function
        
        Public Function ExecuteQuery(query As String, ParamArray parameters As MySqlParameter()) As DataTable
            Using conn As MySqlConnection = GetConnection()
                Using cmd As New MySqlCommand(query, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Return dt
                    End Using
                End Using
            End Using
        End Function
        
        Public Function ExecuteNonQuery(query As String, ParamArray parameters As MySqlParameter()) As Integer
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        End Function
        
        Public Function ExecuteScalar(query As String, ParamArray parameters As MySqlParameter()) As Object
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        End Function
    End Class
End Namespace
