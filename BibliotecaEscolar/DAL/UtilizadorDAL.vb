Imports MySql.Data.MySqlClient
Imports System.Data

Public Class UtilizadorDAL
    Public Function ObterTodos() As List(Of Utilizador)
        Dim lista As New List(Of Utilizador)()
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery("SELECT * FROM Utilizadores")
        For Each row As DataRow In dt.Rows
            lista.Add(MapRowToUtilizador(row))
        Next
        Return lista
    End Function

    Public Function ObterPorId(id As Integer) As Utilizador
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery("SELECT * FROM Utilizadores WHERE ID = @id", parameters)
        If dt.Rows.Count > 0 Then
            Return MapRowToUtilizador(dt.Rows(0))
        End If
        Return Nothing
    End Function

    Public Sub Inserir(utilizador As Utilizador)
        Dim query As String = "INSERT INTO Utilizadores (Nome, Contacto) VALUES (@nome, @contacto)"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@nome", utilizador.Nome),
            New MySqlParameter("@contacto", utilizador.Telefone)
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Atualizar(utilizador As Utilizador)
        Dim query As String = "UPDATE Utilizadores SET Nome = @nome, Contacto = @contacto WHERE ID = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@nome", utilizador.Nome),
            New MySqlParameter("@contacto", utilizador.Telefone),
            New MySqlParameter("@id", utilizador.ID)
        }
        DatabaseConnection.ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Eliminar(id As Integer)
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        DatabaseConnection.ExecuteNonQuery("DELETE FROM Utilizadores WHERE ID = @id", parameters)
    End Sub

    Private Function MapRowToUtilizador(row As DataRow) As Utilizador
        Return New Utilizador() With {
            .ID = Convert.ToInt32(row("ID")),
            .Nome = row("Nome").ToString(),
            .Telefone = row("Contacto").ToString(),
            .Email = "",
            .DataRegistro = DateTime.Now
        }
    End Function
End Class
