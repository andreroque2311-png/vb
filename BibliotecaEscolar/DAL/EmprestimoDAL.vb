Imports MySql.Data.MySqlClient
Imports System.Data

Public Class EmprestimoDAL
    Public Function ObterTodos() As List(Of Emprestimo)
        Dim lista As New List(Of Emprestimo)()
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery("SELECT * FROM Emprestimos")
        For Each row As DataRow In dt.Rows
            lista.Add(MapRowToEmprestimo(row))
        Next
        Return lista
    End Function

    Public Sub Inserir(emprestimo As Emprestimo)
        Dim query As String = "INSERT INTO Emprestimos (ID_Livro, ID_Utilizador, Data_Emprestimo, Data_Devolucao) VALUES (@idLivro, @idUtilizador, @dataEmprestimo, @dataDevolucao)"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@idLivro", emprestimo.IdLivro),
            New MySqlParameter("@idUtilizador", emprestimo.IdUtilizador),
            New MySqlParameter("@dataEmprestimo", emprestimo.DataEmprestimo),
            New MySqlParameter("@dataDevolucao", If(emprestimo.DataDevolucao.HasValue, emprestimo.DataDevolucao.Value, DBNull.Value))
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)
        
        ' Atualizar estado do livro para 'Emprestado'
        Dim updateLivroQuery As String = "UPDATE Livros SET Estado = 'Emprestado' WHERE ID = @idLivro"
        DatabaseConnection.ExecuteNonQuery(updateLivroQuery, {New MySqlParameter("@idLivro", emprestimo.IdLivro)})
    End Sub

    Public Sub RegistrarDevolucao(idEmprestimo As Integer, idLivro As Integer)
        Dim query As String = "UPDATE Emprestimos SET Data_Devolucao = @dataDevolucao WHERE ID_Emprestimo = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@dataDevolucao", DateTime.Now),
            New MySqlParameter("@id", idEmprestimo)
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)

        ' Atualizar estado do livro para 'Disponível'
        Dim updateLivroQuery As String = "UPDATE Livros SET Estado = 'Disponível' WHERE ID = @idLivro"
        DatabaseConnection.ExecuteNonQuery(updateLivroQuery, {New MySqlParameter("@idLivro", idLivro)})
    End Sub

    Private Function MapRowToEmprestimo(row As DataRow) As Emprestimo
        Return New Emprestimo() With {
            .ID = Convert.ToInt32(row("ID_Emprestimo")),
            .IdLivro = Convert.ToInt32(row("ID_Livro")),
            .IdUtilizador = Convert.ToInt32(row("ID_Utilizador")),
            .DataEmprestimo = Convert.ToDateTime(row("Data_Emprestimo")),
            .DataDevolucao = If(IsDBNull(row("Data_Devolucao")), Nothing, New DateTime?(Convert.ToDateTime(row("Data_Devolucao"))))
        }
    End Function
End Class
