Imports BibliotecaEscolar.Models
Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class LivroDAL
        Private db As DatabaseConnection
        
        Public Sub New()
            db = New DatabaseConnection()
        End Sub
        
        Public Function ListarTodos() As DataTable
            Dim query As String = "SELECT * FROM Livros"
            Return db.ExecuteQuery(query)
        End Function
        
        Public Sub AdicionarLivro(livro As Livro)
            Dim query As String = "INSERT INTO Livros (Titulo, Autor, ISBN) VALUES (@Titulo, @Autor, @ISBN)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Titulo", livro.Titulo),
                New MySqlParameter("@Autor", livro.Autor),
                New MySqlParameter("@ISBN", livro.ISBN)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub AtualizarLivro(livro As Livro)
            Dim query As String = "UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, ISBN = @ISBN WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@Titulo", livro.Titulo),
                New MySqlParameter("@Autor", livro.Autor),
                New MySqlParameter("@ISBN", livro.ISBN),
                New MySqlParameter("@ID", livro.ID)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub DeletarLivro(id As Integer)
            Dim query As String = "DELETE FROM Livros WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Function ObterPorId(id As Integer) As Livro
            Dim query As String = "SELECT * FROM Livros WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            Dim dt As DataTable = db.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim livro As New Livro
                livro.ID = Convert.ToInt32(row("ID"))
                livro.Titulo = row("Titulo").ToString()
                livro.Autor = row("Autor").ToString()
                livro.ISBN = row("ISBN").ToString()
                Return livro
            End If
            Return Nothing
        End Function
    End Class
End Namespace
