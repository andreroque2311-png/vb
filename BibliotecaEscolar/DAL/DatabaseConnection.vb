Imports MySql.Data.MySqlClient

Namespace BibliotecaEscolar.DAL
    Public Class DatabaseConnection
        Private connectionString As String = "Server=localhost;Database=biblioteca_escolar;Uid=root;Pwd=;"

        Public Function GetConnection() As MySqlConnection
            Return New MySqlConnection(connectionString)
        End Function
    End Class
End Namespace
