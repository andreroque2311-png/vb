Imports MySql.Data.MySqlClient
Imports System.Data

Public Class LivroDAL
    Public Function ObterTodos() As List(Of Livro)
        Dim lista As New List(Of Livro)()
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery("SELECT * FROM Livros")
        For Each row As DataRow In dt.Rows
            lista.Add(MapRowToLivro(row))
        Next
        Return lista
    End Function

    Public Function ObterPorId(id As Integer) As Livro
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery("SELECT * FROM Livros WHERE ID = @id", parameters)
        If dt.Rows.Count > 0 Then
            Return MapRowToLivro(dt.Rows(0))
        End If
        Return Nothing
    End Function

    Public Sub Inserir(livro As Livro)
        Dim query As String = "INSERT INTO Livros (Titulo, Autor, Ano, Estado) VALUES (@titulo, @autor, @ano, @estado)"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@titulo", livro.Titulo),
            New MySqlParameter("@autor", livro.Autor),
            New MySqlParameter("@ano", livro.DataPublicacao.Year),
            New MySqlParameter("@estado", If(livro.Disponivel, "Disponível", "Emprestado"))
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Atualizar(livro As Livro)
        Dim query As String = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Ano = @ano, Estado = @estado WHERE ID = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@titulo", livro.Titulo),
            New MySqlParameter("@autor", livro.Autor),
            New MySqlParameter("@ano", livro.DataPublicacao.Year),
            New MySqlParameter("@estado", If(livro.Disponivel, "Disponível", "Emprestado")),
            New MySqlParameter("@id", livro.ID)
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Eliminar(id As Integer)
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        DatabaseConnection.ExecuteNonQuery("DELETE FROM Livros WHERE ID = @id", parameters)
    End Sub

    Private Function MapRowToLivro(row As DataRow) As Livro
        Return New Livro() With {
            .ID = Convert.ToInt32(row("ID")),
            .Titulo = row("Titulo").ToString(),
            .Autor = row("Autor").ToString(),
            .DataPublicacao = New DateTime(If(IsDBNull(row("Ano")), DateTime.Now.Year, Convert.ToInt32(row("Ano"))), 1, 1),
            .Disponivel = (row("Estado").ToString() = "Disponível"),
            .ISBN = "" ' Não existe na DB atual
        }
    End Function
End Class
