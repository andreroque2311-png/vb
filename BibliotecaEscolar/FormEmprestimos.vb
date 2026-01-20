Imports MySql.Data.MySqlClient

Namespace BibliotecaEscolar
    Public Class FormEmprestimos
        Private db As New DatabaseConnection()

        Private Sub FormEmprestimos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ListarEmprestimos()
            CarregarLivros()
            CarregarUtilizadores()
        End Sub

        Private Sub ListarEmprestimos()
            Try
                db.OpenConnection()
                Dim query As String = "SELECT e.ID_Emprestimo, l.Titulo as Livro, u.Nome as Utilizador, e.Data_Emprestimo, e.Data_Devolucao FROM Emprestimos e JOIN Livros l ON e.ID_Livro = l.ID JOIN Utilizadores u ON e.ID_Utilizador = u.ID"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridViewEmprestimos.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao listar empréstimos: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CarregarLivros()
            Try
                db.OpenConnection()
                Dim query As String = "SELECT ID, Titulo FROM Livros WHERE Estado = 'Disponível'"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                Dim table As New DataTable()
                adapter.Fill(table)
                ComboBoxLivro.DisplayMember = "Titulo"
                ComboBoxLivro.ValueMember = "ID"
                ComboBoxLivro.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar livros: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CarregarUtilizadores()
            Try
                db.OpenConnection()
                Dim query As String = "SELECT ID, Nome FROM Utilizadores"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                Dim table As New DataTable()
                adapter.Fill(table)
                ComboBoxUtilizador.DisplayMember = "Nome"
                ComboBoxUtilizador.ValueMember = "ID"
                ComboBoxUtilizador.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar utilizadores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonRegistrarEmprestimo_Click(sender As Object, e As EventArgs) Handles ButtonRegistrarEmprestimo.Click
            If ComboBoxLivro.SelectedValue Is Nothing Or ComboBoxUtilizador.SelectedValue Is Nothing Then
                MessageBox.Show("Por favor, selecione um livro e um utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                db.OpenConnection()
                ' Iniciar transação
                Dim transaction As MySqlTransaction = db.GetConnection().BeginTransaction()
                
                Try
                    ' Registrar empréstimo
                    Dim queryEmprestimo As String = "INSERT INTO Emprestimos (ID_Livro, ID_Utilizador, Data_Emprestimo, Data_Devolucao) VALUES (@ID_Livro, @ID_Utilizador, @Data_Emprestimo, @Data_Devolucao)"
                    Dim commandEmprestimo As New MySqlCommand(queryEmprestimo, db.GetConnection(), transaction)
                    commandEmprestimo.Parameters.AddWithValue("@ID_Livro", ComboBoxLivro.SelectedValue)
                    commandEmprestimo.Parameters.AddWithValue("@ID_Utilizador", ComboBoxUtilizador.SelectedValue)
                    commandEmprestimo.Parameters.AddWithValue("@Data_Emprestimo", DateTimePickerEmprestimo.Value)
                    commandEmprestimo.Parameters.AddWithValue("@Data_Devolucao", If(CheckBoxDevolvido.Checked, DateTimePickerDevolucao.Value, DBNull.Value))
                    commandEmprestimo.ExecuteNonQuery()
                    
                    ' Atualizar estado do livro
                    Dim queryLivro As String = "UPDATE Livros SET Estado = 'Emprestado' WHERE ID = @ID"
                    Dim commandLivro As New MySqlCommand(queryLivro, db.GetConnection(), transaction)
                    commandLivro.Parameters.AddWithValue("@ID", ComboBoxLivro.SelectedValue)
                    commandLivro.ExecuteNonQuery()
                    
                    ' Confirmar transação
                    transaction.Commit()
                    
                    MessageBox.Show("Empréstimo registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListarEmprestimos()
                    LimparCampos()
                    CarregarLivros() ' Atualizar lista de livros disponíveis
                    
                Catch ex As Exception
                    ' Reverter transação em caso de erro
                    transaction.Rollback()
                    MessageBox.Show("Erro ao registrar empréstimo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao abrir conexão: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonRegistrarDevolucao_Click(sender As Object, e As EventArgs) Handles ButtonRegistrarDevolucao.Click
            If DataGridViewEmprestimos.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecione um empréstimo para registrar devolução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim idEmprestimo As Integer = Convert.ToInt32(DataGridViewEmprestimos.SelectedRows(0).Cells("ID_Emprestimo").Value)
            Dim idLivro As Integer = GetLivroIdFromEmprestimo(idEmprestimo)

            Try
                db.OpenConnection()
                ' Iniciar transação
                Dim transaction As MySqlTransaction = db.GetConnection().BeginTransaction()
                
                Try
                    ' Atualizar data de devolução
                    Dim queryDevolucao As String = "UPDATE Emprestimos SET Data_Devolucao = @Data_Devolucao WHERE ID_Emprestimo = @ID_Emprestimo"
                    Dim commandDevolucao As New MySqlCommand(queryDevolucao, db.GetConnection(), transaction)
                    commandDevolucao.Parameters.AddWithValue("@Data_Devolucao", DateTime.Now)
                    commandDevolucao.Parameters.AddWithValue("@ID_Emprestimo", idEmprestimo)
                    commandDevolucao.ExecuteNonQuery()
                    
                    ' Atualizar estado do livro
                    Dim queryLivro As String = "UPDATE Livros SET Estado = 'Disponível' WHERE ID = @ID"
                    Dim commandLivro As New MySqlCommand(queryLivro, db.GetConnection(), transaction)
                    commandLivro.Parameters.AddWithValue("@ID", idLivro)
                    commandLivro.ExecuteNonQuery()
                    
                    ' Confirmar transação
                    transaction.Commit()
                    
                    MessageBox.Show("Devolução registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListarEmprestimos()
                    LimparCampos()
                    CarregarLivros() ' Atualizar lista de livros disponíveis
                    
                Catch ex As Exception
                    ' Reverter transação em caso de erro
                    transaction.Rollback()
                    MessageBox.Show("Erro ao registrar devolução: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao abrir conexão: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function GetLivroIdFromEmprestimo(idEmprestimo As Integer) As Integer
            Dim idLivro As Integer = 0
            Try
                db.OpenConnection()
                Dim query As String = "SELECT ID_Livro FROM Emprestimos WHERE ID_Emprestimo = @ID_Emprestimo"
                Dim command As New MySqlCommand(query, db.GetConnection())
                command.Parameters.AddWithValue("@ID_Emprestimo", idEmprestimo)
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    idLivro = Convert.ToInt32(result)
                End If
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao obter ID do livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return idLivro
        End Function

        Private Sub ButtonLimpar_Click(sender As Object, e As EventArgs) Handles ButtonLimpar.Click
            LimparCampos()
        End Sub

        Private Sub ButtonVoltar_Click(sender As Object, e As EventArgs) Handles ButtonVoltar.Click
            Dim formMain As New FormMain()
            formMain.Show()
            Me.Close()
        End Sub

        Private Sub LimparCampos()
            ComboBoxLivro.SelectedIndex = -1
            ComboBoxUtilizador.SelectedIndex = -1
            DateTimePickerEmprestimo.Value = DateTime.Now
            DateTimePickerDevolucao.Value = DateTime.Now
            CheckBoxDevolvido.Checked = False
        End Sub
    End Class
End Namespace