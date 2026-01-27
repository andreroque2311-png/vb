Imports BibliotecaEscolar.Models
Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class EmprestimoDAL
        Private db As DatabaseConnection
        
        Public Sub New()
            db = New DatabaseConnection()
        End Sub
        
        Public Function ObterTodos() As DataTable
            Dim query As String = "SELECT e.ID, e.IdLivro, l.Titulo AS LivroTitulo, e.IdUtilizador, u.Nome AS UtilizadorNome, e.DataEmprestimo, e.DataDevolucao FROM Emprestimos e INNER JOIN Livros l ON e.IdLivro = l.ID INNER JOIN Utilizadores u ON e.IdUtilizador = u.ID"
            Return db.ExecuteQuery(query)
        End Function
        
        Public Sub AdicionarEmprestimo(emprestimo As Emprestimo)
            Dim query As String = "INSERT INTO Emprestimos (IdLivro, IdUtilizador, DataEmprestimo, DataDevolucao) VALUES (@IdLivro, @IdUtilizador, @DataEmprestimo, @DataDevolucao)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@IdLivro", emprestimo.IdLivro),
                New MySqlParameter("@IdUtilizador", emprestimo.IdUtilizador),
                New MySqlParameter("@DataEmprestimo", emprestimo.DataEmprestimo),
                New MySqlParameter("@DataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Object), DBNull.Value))
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub AtualizarEmprestimo(emprestimo As Emprestimo)
            Dim query As String = "UPDATE Emprestimos SET IdLivro = @IdLivro, IdUtilizador = @IdUtilizador, DataEmprestimo = @DataEmprestimo, DataDevolucao = @DataDevolucao WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@IdLivro", emprestimo.IdLivro),
                New MySqlParameter("@IdUtilizador", emprestimo.IdUtilizador),
                New MySqlParameter("@DataEmprestimo", emprestimo.DataEmprestimo),
                New MySqlParameter("@DataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Object), DBNull.Value)),
                New MySqlParameter("@ID", emprestimo.ID)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Sub DeletarEmprestimo(id As Integer)
            Dim query As String = "DELETE FROM Emprestimos WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            db.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Function ObterPorId(id As Integer) As Emprestimo
            Dim query As String = "SELECT * FROM Emprestimos WHERE ID = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            Dim dt As DataTable = db.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim emprestimo As New Emprestimo
                emprestimo.ID = Convert.ToInt32(row("ID"))
                emprestimo.IdLivro = Convert.ToInt32(row("IdLivro"))
                emprestimo.IdUtilizador = Convert.ToInt32(row("IdUtilizador"))
                emprestimo.DataEmprestimo = Convert.ToDateTime(row("DataEmprestimo"))
                If row("DataDevolucao") IsNot DBNull.Value Then
                    emprestimo.DataDevolucao = Convert.ToDateTime(row("DataDevolucao"))
                End If
                Return emprestimo
            End If
            Return Nothing
        End Function
        
        Public Function ObterLivrosDisponiveis() As DataTable
            Dim query As String = "SELECT * FROM Livros WHERE ID NOT IN (SELECT IdLivro FROM Emprestimos WHERE DataDevolucao IS NULL)"
            Return db.ExecuteQuery(query)
        End Function
        
        Public Function ObterUtilizadores() As DataTable
            Dim query As String = "SELECT * FROM Utilizadores"
            Return db.ExecuteQuery(query)
        End Function
    End Class
End Namespace
