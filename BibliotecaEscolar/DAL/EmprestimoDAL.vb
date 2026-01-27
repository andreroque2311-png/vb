Imports BibliotecaEscolar.Models
Imports MySql.Data.MySqlClient
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class EmprestimoDAL
        Public Shared Function ListarTodos() As DataTable
            Return DatabaseConnection.ExecuteQuery("SELECT * FROM Emprestimos")
        End Function
        
        Public Shared Sub AdicionarEmprestimo(emprestimo As Emprestimo)
            Dim query As String = "INSERT INTO Emprestimos (ID_Livro, ID_Utilizador, Data_Emprestimo, Data_Devolucao) VALUES (@IdLivro, @IdUtilizador, @DataEmprestimo, @DataDevolucao)"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@IdLivro", emprestimo.IdLivro),
                New MySqlParameter("@IdUtilizador", emprestimo.IdUtilizador),
                New MySqlParameter("@DataEmprestimo", emprestimo.DataEmprestimo),
                New MySqlParameter("@DataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Object), DBNull.Value))
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Sub AtualizarEmprestimo(emprestimo As Emprestimo)
            Dim query As String = "UPDATE Emprestimos SET ID_Livro = @IdLivro, ID_Utilizador = @IdUtilizador, Data_Emprestimo = @DataEmprestimo, Data_Devolucao = @DataDevolucao WHERE ID_Emprestimo = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@IdLivro", emprestimo.IdLivro),
                New MySqlParameter("@IdUtilizador", emprestimo.IdUtilizador),
                New MySqlParameter("@DataEmprestimo", emprestimo.DataEmprestimo),
                New MySqlParameter("@DataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Object), DBNull.Value)),
                New MySqlParameter("@ID", emprestimo.ID)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Sub DeletarEmprestimo(id As Integer)
            Dim query As String = "DELETE FROM Emprestimos WHERE ID_Emprestimo = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            DatabaseConnection.ExecuteNonQuery(query, parameters)
        End Sub
        
        Public Shared Function ObterPorId(id As Integer) As Emprestimo
            Dim query As String = "SELECT * FROM Emprestimos WHERE ID_Emprestimo = @ID"
            Dim parameters As MySqlParameter() = {
                New MySqlParameter("@ID", id)
            }
            Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim emprestimo As New Emprestimo
                emprestimo.ID = Convert.ToInt32(row("ID_Emprestimo"))
                emprestimo.IdLivro = Convert.ToInt32(row("ID_Livro"))
                emprestimo.IdUtilizador = Convert.ToInt32(row("ID_Utilizador"))
                emprestimo.DataEmprestimo = Convert.ToDateTime(row("Data_Emprestimo"))
                If row("Data_Devolucao") IsNot DBNull.Value Then
                    emprestimo.DataDevolucao = Convert.ToDateTime(row("Data_Devolucao"))
                End If
                Return emprestimo
            End If
            Return Nothing
        End Function
        
        Public Shared Function ObterLivrosDisponiveis() As DataTable
            Dim query As String = "SELECT * FROM Livros WHERE Estado = 'Disponível'"
            Return DatabaseConnection.ExecuteQuery(query)
        End Function
        
        Public Shared Function ObterUtilizadores() As DataTable
            Dim query As String = "SELECT * FROM Utilizadores"
            Return DatabaseConnection.ExecuteQuery(query)
        End Function
    End Class
End Namespace
