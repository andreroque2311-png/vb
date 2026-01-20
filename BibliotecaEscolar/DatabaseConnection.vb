Imports MySql.Data.MySqlClient

Namespace BibliotecaEscolar
    Public Class DatabaseConnection
        Private connectionString As String = "Server=localhost;Database=biblioteca_escolar;Uid=root;Pwd=;"
        Private connection As MySqlConnection

        Public Sub New()
            connection = New MySqlConnection(connectionString)
        End Sub

        Public Function GetConnection() As MySqlConnection
            Return connection
        End Function

        Public Sub OpenConnection()
            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao conectar ao banco de dados: " & ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CloseConnection()
            Try
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao fechar conexão: " & ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace