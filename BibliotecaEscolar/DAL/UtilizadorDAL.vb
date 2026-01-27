Imports BibliotecaEscolar.Models
Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class UtilizadorDAL
        Public Shared Function ListarTodos() As DataTable
            Return DatabaseConnection.ExecuteQuery("SELECT * FROM Utilizadores")
        End Function
        
        Public Shared Sub AdicionarUtilizador(utilizador As Utilizador)
            Dim query As String = "INSERT INTO Utilizadores (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Nome", utilizador.Nome),
                New MySqlParameter("@Email", utilizador.Email),
                New MySqlParameter("@Telefone", utilizador.Telefone)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Sub AtualizarUtilizador(utilizador As Utilizador)
            Dim query As String = "UPDATE Utilizadores SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Nome", utilizador.Nome),
                New MySqlParameter("@Email", utilizador.Email),
                New MySqlParameter("@Telefone", utilizador.Telefone),
                New MySqlParameter("@ID", utilizador.ID)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Sub DeletarUtilizador(id As Integer)
            Dim query As String = "DELETE FROM Utilizadores WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Function ObterPorId(id As Integer) As Utilizador
            Dim query As String = "SELECT * FROM Utilizadores WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim utilizador As New Utilizador
                utilizador.ID = Convert.ToInt32(row("ID"))
                utilizador.Nome = row("Nome").ToString()
                utilizador.Email = row("Email").ToString()
                utilizador.Telefone = row("Telefone").ToString()
                Return utilizador
            End If
            Return Nothing
        End Function
    End Class
End Namespace
