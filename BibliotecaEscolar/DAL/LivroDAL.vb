Imports MySql.Data.MySqlClient
Imports BibliotecaEscolar.Models
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class LivroDAL
    Public Shared Function Adicionar(livro As Livro) As Integer
        Dim query As String = "INSERT INTO livros (titulo, autor, isbn, data_publicacao, disponivel) VALUES (@titulo, @autor, @isbn, @dataPublicacao, @disponivel); SELECT LAST_INSERT_ID();"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@titulo", livro.Titulo),
            New MySqlParameter("@autor", livro.Autor),
            New MySqlParameter("@isbn", livro.ISBN),
            New MySqlParameter("@dataPublicacao", livro.DataPublicacao),
            New MySqlParameter("@disponivel", livro.Disponivel)
        }
        
        Return CInt(DatabaseConnection.ExecuteScalar(query, parameters))
    End Function

    Public Shared Function Atualizar(livro As Livro) As Boolean
        Dim query As String = "UPDATE livros SET titulo = @titulo, autor = @autor, isbn = @isbn, data_publicacao = @dataPublicacao, disponivel = @disponivel WHERE id = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@titulo", livro.Titulo),
            New MySqlParameter("@autor", livro.Autor),
            New MySqlParameter("@isbn", livro.ISBN),
            New MySqlParameter("@dataPublicacao", livro.DataPublicacao),
            New MySqlParameter("@disponivel", livro.Disponivel),
            New MySqlParameter("@id", livro.ID)
        }
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Deletar(id As Integer) As Boolean
        Dim query As String = "DELETE FROM livros WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Obter(id As Integer) As Livro
        Dim query As String = "SELECT id, titulo, autor, isbn, data_publicacao, disponivel FROM livros WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
        If dt.Rows.Count = 0 Then Return Nothing
        
        Dim row As DataRow = dt.Rows(0)
        Return New Livro(
            CInt(row("id")),
            row("titulo").ToString(),
            row("autor").ToString(),
            row("isbn").ToString(),
            CDate(row("data_publicacao")),
            CBool(row("disponivel"))
        )
    End Function

    Public Shared Function ListarTodos() As List(Of Livro)
        Dim query As String = "SELECT id, titulo, autor, isbn, data_publicacao, disponivel FROM livros ORDER BY titulo"
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query)
        Dim livros As New List(Of Livro)()
        
        For Each row As DataRow In dt.Rows
            livros.Add(New Livro(
                CInt(row("id")),
                row("titulo").ToString(),
                row("autor").ToString(),
                row("isbn").ToString(),
                CDate(row("data_publicacao")),
                CBool(row("disponivel"))
            ))
        Next
        
        Return livros
    End Function

    Public Shared Function ObterDisponiveis() As List(Of Livro)
        Dim query As String = "SELECT id, titulo, autor, isbn, data_publicacao, disponivel FROM livros WHERE disponivel = 1 ORDER BY titulo"
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query)
        Dim livros As New List(Of Livro)()
        
        For Each row As DataRow In dt.Rows
            livros.Add(New Livro(
                CInt(row("id")),
                row("titulo").ToString(),
                row("autor").ToString(),
                row("isbn").ToString(),
                CDate(row("data_publicacao")),
                CBool(row("disponivel"))
            ))
        Next
        
        Return livros
    End Function

    Public Shared Function Pesquisar(termo As String) As List(Of Livro)
        Dim query As String = "SELECT id, titulo, autor, isbn, data_publicacao, disponivel FROM livros WHERE titulo LIKE @termo OR autor LIKE @termo OR isbn LIKE @termo ORDER BY titulo"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@termo", "%" & termo & "%")}
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
        Dim livros As New List(Of Livro)()
        
        For Each row As DataRow In dt.Rows
            livros.Add(New Livro(
                CInt(row("id")),
                row("titulo").ToString(),
                row("autor").ToString(),
                row("isbn").ToString(),
                CDate(row("data_publicacao")),
                CBool(row("disponivel"))
            ))
        Next
        
        Return livros
    End Function
End Class
End Namespace