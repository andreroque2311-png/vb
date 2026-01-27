Imports BibliotecaEscolar.Models
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class LivroDAL
        Public Shared Function ListarTodos() As DataTable
            Return DatabaseConnection.ExecuteQuery("SELECT * FROM Livros")
        End Function
        
        Public Shared Sub AdicionarLivro(livro As Livro)
            Dim query = "INSERT INTO Livros (Titulo, Autor, Ano, Estado) VALUES ('" & livro.Titulo & "', '" & livro.Autor & "', " & livro.Ano & ", '" & livro.Estado & "')"
            DatabaseConnection.ExecuteNonQuery(query)
        End Sub
        
        Public Shared Sub AtualizarLivro(livro As Livro)
            Dim query = "UPDATE Livros SET Titulo='" & livro.Titulo & "', Autor='" & livro.Autor & "', Ano=" & livro.Ano & ", Estado='" & livro.Estado & "' WHERE ID=" & livro.ID
            DatabaseConnection.ExecuteNonQuery(query)
        End Sub
        
        Public Shared Sub DeletarLivro(id As Integer)
            Dim query = "DELETE FROM Livros WHERE ID=" & id
            DatabaseConnection.ExecuteNonQuery(query)
        End Sub
    End Class
End Namespace
