Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class DatabaseConnection
    Private Shared connectionString As String = ConfigurationManager.ConnectionStrings("BibliotecaEscolar.My.MySettings.BibliotecaEscolarConnectionString").ConnectionString

    Public Shared Function ExecuteQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As DataTable
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                Try
                    connection.Open()
                    Dim adapter As New MySqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)
                    Return dataTable
                Catch ex As MySqlException
                    Throw New Exception("Erro ao executar consulta: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ExecuteNonQuery(query As String, Optional parameters As MySqlParameter() = Nothing) As Integer
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                Try
                    connection.Open()
                    Return command.ExecuteNonQuery()
                Catch ex As MySqlException
                    Throw New Exception("Erro ao executar comando: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ExecuteScalar(query As String, Optional parameters As MySqlParameter() = Nothing) As Object
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                If parameters IsNot Nothing Then
                    command.Parameters.AddRange(parameters)
                End If
                
                Try
                    connection.Open()
                    Return command.ExecuteScalar()
                Catch ex As MySqlException
                    Throw New Exception("Erro ao executar comando escalar: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ExecuteTransaction(queries As List(Of String), Optional parametersList As List(Of MySqlParameter()) = Nothing) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Using transaction As MySqlTransaction = connection.BeginTransaction()
                Try
                    For i As Integer = 0 To queries.Count - 1
                        Using command As New MySqlCommand(queries(i), connection, transaction)
                            If parametersList IsNot Nothing AndAlso parametersList.Count > i Then
                                command.Parameters.AddRange(parametersList(i))
                            End If
                            command.ExecuteNonQuery()
                        End Using
                    Next
                    
                    transaction.Commit()
                    Return True
                Catch ex As Exception
                    transaction.Rollback()
                    Throw New Exception("Erro na transação: " & ex.Message)
                End Try
            End Using
        End Using
    End Function
End Class