Imports MySql.Data.MySqlClient
Imports BibliotecaEscolar.Models

Public Class UtilizadorDAL
    Public Shared Function Adicionar(utilizador As Utilizador) As Integer
        Dim query As String = "INSERT INTO utilizadores (nome, email, telefone, data_registro) VALUES (@nome, @email, @telefone, @dataRegistro); SELECT LAST_INSERT_ID();"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@nome", utilizador.Nome),
            New MySqlParameter("@email", utilizador.Email),
            New MySqlParameter("@telefone", utilizador.Telefone),
            New MySqlParameter("@dataRegistro", utilizador.DataRegistro)
        }
        
        Return CInt(DatabaseConnection.ExecuteScalar(query, parameters))
    End Function

    Public Shared Function Atualizar(utilizador As Utilizador) As Boolean
        Dim query As String = "UPDATE utilizadores SET nome = @nome, email = @email, telefone = @telefone, data_registro = @dataRegistro WHERE id = @id"
        Dim parameters As MySqlParameter() = {
            New MySqlParameter("@nome", utilizador.Nome),
            New MySqlParameter("@email", utilizador.Email),
            New MySqlParameter("@telefone", utilizador.Telefone),
            New MySqlParameter("@dataRegistro", utilizador.DataRegistro),
            New MySqlParameter("@id", utilizador.ID)
        }
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Deletar(id As Integer) As Boolean
        Dim query As String = "DELETE FROM utilizadores WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Return DatabaseConnection.ExecuteNonQuery(query, parameters) > 0
    End Function

    Public Shared Function Obter(id As Integer) As Utilizador
        Dim query As String = "SELECT id, nome, email, telefone, data_registro FROM utilizadores WHERE id = @id"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@id", id)}
        
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
        If dt.Rows.Count = 0 Then Return Nothing
        
        Dim row As DataRow = dt.Rows(0)
        Return New Utilizador(
            CInt(row("id")),
            row("nome").ToString(),
            row("email").ToString(),
            row("telefone").ToString(),
            CDate(row("data_registro"))
        )
    End Function

    Public Shared Function ListarTodos() As List(Of Utilizador)
        Dim query As String = "SELECT id, nome, email, telefone, data_registro FROM utilizadores ORDER BY nome"
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query)
        Dim utilizadores As New List(Of Utilizador)()
        
        For Each row As DataRow In dt.Rows
            utilizadores.Add(New Utilizador(
                CInt(row("id")),
                row("nome").ToString(),
                row("email").ToString(),
                row("telefone").ToString(),
                CDate(row("data_registro"))
            ))
        Next
        
        Return utilizadores
    End Function

    Public Shared Function Pesquisar(termo As String) As List(Of Utilizador)
        Dim query As String = "SELECT id, nome, email, telefone, data_registro FROM utilizadores WHERE nome LIKE @termo OR email LIKE @termo OR telefone LIKE @termo ORDER BY nome"
        Dim parameters As MySqlParameter() = {New MySqlParameter("@termo", "%" & termo & "%")}
        Dim dt As DataTable = DatabaseConnection.ExecuteQuery(query, parameters)
        Dim utilizadores As New List(Of Utilizador)()
        
        For Each row As DataRow In dt.Rows
            utilizadores.Add(New Utilizador(
                CInt(row("id")),
                row("nome").ToString(),
                row("email").ToString(),
                row("telefone").ToString(),
                CDate(row("data_registro"))
            ))
        Next
        
        Return utilizadores
    End Function
End Class