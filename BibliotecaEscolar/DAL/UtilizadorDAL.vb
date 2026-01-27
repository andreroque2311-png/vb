Imports BibliotecaEscolar.Models
Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class UtilizadorDAL
        Private db As DatabaseConnection
        
        Public Sub New()
            db = New DatabaseConnection()
        End Sub
        
        Public Function ListarTodos() As DataTable
            Dim query As String = "SELECT * FROM Utilizadores"
            Return db.ExecuteQuery(query)
        End Function
        
        Public Sub AdicionarUtilizador(utilizador As Utilizador)
            Dim query As String = "INSERT INTO Utilizadores (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Nome", utilizador.Nome),
                New MySqlParameter("@Email", utilizador.Email),
                New MySqlParameter("@Telefone", utilizador.Telefone)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub AtualizarUtilizador(utilizador As Utilizador)
            Dim query As String = "UPDATE Utilizadores SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Nome", utilizador.Nome),
                New MySqlParameter("@Email", utilizador.Email),
                New MySqlParameter("@Telefone", utilizador.Telefone),
                New MySqlParameter("@ID", utilizador.ID)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub DeletarUtilizador(id As Integer)
            Dim query As String = "DELETE FROM Utilizadores WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Function ObterPorId(id As Integer) As Utilizador
            Dim query As String = "SELECT * FROM Utilizadores WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            Dim dt As DataTable = db.ExecuteQuery(query, parameters)
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
