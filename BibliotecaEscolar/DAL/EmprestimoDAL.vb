Imports MySql.Data.MySqlClient
Imports BibliotecaEscolar.Models
Imports System.Data

Namespace BibliotecaEscolar.DAL
    Public Class EmprestimoDAL
    Public Shared Function Adicionar(emprestimo As Emprestimo) As Integer
        Dim query As String = "INSERT INTO emprestimos (id_livro, id_utilizador, data_emprestimo, data_devolucao) VALUES (@idLivro, @idUtilizador, @dataEmprestimo, @dataDevolucao); SELECT LAST_INSERT_ID();"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@idLivro", emprestimo.IdLivro),
            New MySqlParameter("@idUtilizador", emprestimo.IdUtilizador),
            New MySqlParameter("@dataEmprestimo", emprestimo.DataEmprestimo),
            New MySqlParameter("@dataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Date), DBNull.Value))
        }
        
        Return CInt(DatabaseConnection.ExecuteScalar(query, parameters))
    End Function

    Public Shared Function Atualizar(emprestimo As Emprestimo) As Boolean
        Dim query As String = "UPDATE emprestimos SET id_livro = @idLivro, id_utilizador = @idUtilizador, data_emprestimo = @dataEmprestimo, data_devolucao = @dataDevolucao WHERE id = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@idLivro", emprestimo.IdLivro),
            New MySqlParameter("@idUtilizador", emprestimo.IdUtilizador),
            New MySqlParameter("@dataEmprestimo", emprestimo.DataEmprestimo),
            New MySqlParameter("@dataDevolucao", If(emprestimo.DataDevolucao.HasValue, CType(emprestimo.DataDevolucao, Date), DBNull.Value)),
            New MySqlParameter("@id", emprestimo.ID)
        }
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Deletar(id As Integer) As Boolean
        Dim query As String = "DELETE FROM emprestimos WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Obter(id As Integer) As Emprestimo
        Dim query As String = "SELECT id, id_livro, id_utilizador, data_emprestimo, data_devolucao FROM emprestimos WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
        If dt.Rows.Count = 0 Then Return Nothing
        
        Dim row As DataRow = dt.Rows(0)
        Dim dataDevolucao As Date? = If(IsDBNull(row("data_devolucao")), Nothing, CType(row("data_devolucao"), Date))
        
        Return New Emprestimo(
            CInt(row("id")),
            CInt(row("id_livro")),
            CInt(row("id_utilizador")),
            CDate(row("data_emprestimo")),
            dataDevolucao
        )
    End Function

    Public Shared Function ListarTodos() As List(Of Emprestimo)
        Dim query As String = "SELECT id, id_livro, id_utilizador, data_emprestimo, data_devolucao FROM emprestimos ORDER BY data_emprestimo DESC"
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query)
        Dim emprestimos As New List(Of Emprestimo)()
        
        For Each row As DataRow In dt.Rows
            Dim dataDevolucao As Date? = If(IsDBNull(row("data_devolucao")), Nothing, CType(row("data_devolucao"), Date))
            emprestimos.Add(New Emprestimo(
                CInt(row("id")),
                CInt(row("id_livro")),
                CInt(row("id_utilizador")),
                CDate(row("data_emprestimo")),
                dataDevolucao
            ))
        Next
        
        Return emprestimos
    End Function

    Public Shared Function ListarAtivos() As List(Of Emprestimo)
        Dim query As String = "SELECT id, id_livro, id_utilizador, data_emprestimo, data_devolucao FROM emprestimos WHERE data_devolucao IS NULL ORDER BY data_emprestimo DESC"
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query)
        Dim emprestimos As New List(Of Emprestimo)()
        
        For Each row As DataRow In dt.Rows
            emprestimos.Add(New Emprestimo(
                CInt(row("id")),
                CInt(row("id_livro")),
                CInt(row("id_utilizador")),
                CDate(row("data_emprestimo")),
                Nothing
            ))
        Next
        
        Return emprestimos
    End Function

    Public Shared Function RealizarEmprestimo(idLivro As Integer, idUtilizador As Integer) As Boolean
        ' Inicia transação para atualizar livro e criar empréstimo
        Dim queries As New List(Of String)()
        Dim parametersList As New List(Of MySqlParameter())()
        
        ' 1. Atualiza livro para indisponível
        Dim updateLivroQuery As String = "UPDATE livros SET disponivel = 0 WHERE id = @idLivro AND disponivel = 1"
        Dim updateLivroParams As MySqlParameter() = {New MySqlParameter("@idLivro", idLivro)}
        queries.Add(updateLivroQuery)
        parametersList.Add(updateLivroParams)
        
        ' 2. Cria empréstimo
        Dim createEmprestimoQuery As String = "INSERT INTO emprestimos (id_livro, id_utilizador, data_emprestimo) VALUES (@idLivro, @idUtilizador, @dataEmprestimo)"
        Dim createEmprestimoParams As MySqlParameter() = {
            New MySqlParameter("@idLivro", idLivro),
            New MySqlParameter("@idUtilizador", idUtilizador),
            New MySqlParameter("@dataEmprestimo", Date.Now)
        }
        queries.Add(createEmprestimoQuery)
        parametersList.Add(createEmprestimoParams)
        
        Return DatabaseConnection.ExecuteTransaction(queries, parametersList)
    End Function

    Public Shared Function DevolverLivro(idEmprestimo As Integer) As Boolean
        ' Obtém o empréstimo para saber qual livro atualizar
        Dim emprestimo As Emprestimo = Obter(idEmprestimo)
        If emprestimo Is Nothing Then Return False
        
        ' Inicia transação para atualizar livro e empréstimo
        Dim queries As New List(Of String)()
        Dim parametersList As New List(Of MySqlParameter())()
        
        ' 1. Atualiza livro para disponível
        Dim updateLivroQuery As String = "UPDATE livros SET disponivel = 1 WHERE id = @idLivro"
        Dim updateLivroParams As MySqlParameter() = {New MySqlParameter("@idLivro", emprestimo.IdLivro)}
        queries.Add(updateLivroQuery)
        parametersList.Add(updateLivroParams)
        
        ' 2. Atualiza empréstimo com data de devolução
        Dim updateEmprestimoQuery As String = "UPDATE emprestimos SET data_devolucao = @dataDevolucao WHERE id = @idEmprestimo"
        Dim updateEmprestimoParams As MySqlParameter() = {
            New MySqlParameter("@dataDevolucao", Date.Now),
            New MySqlParameter("@idEmprestimo", idEmprestimo)
        }
        queries.Add(updateEmprestimoQuery)
        parametersList.Add(updateEmprestimoParams)
        
        Return DatabaseConnection.ExecuteTransaction(queries, parametersList)
    End Function
End Class
End Namespace