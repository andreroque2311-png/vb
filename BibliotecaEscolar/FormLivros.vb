Imports MySql.Data.MySqlClient

Namespace BibliotecaEscolar
    Public Class FormLivros
        Private db As New DatabaseConnection()

        Private Sub FormLivros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ListarLivros()
            CarregarEstados()
        End Sub

        Private Sub ListarLivros()
            Try
                db.OpenConnection()
                Dim query As String = "SELECT * FROM Livros"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridViewLivros.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao listar livros: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CarregarEstados()
            ComboBoxEstado.Items.Add("Disponível")
            ComboBoxEstado.Items.Add("Emprestado")
        End Sub

        Private Sub ButtonInserir_Click(sender As Object, e As EventArgs) Handles ButtonInserir.Click
            If String.IsNullOrWhiteSpace(TextBoxTitulo.Text) Or String.IsNullOrWhiteSpace(TextBoxAutor.Text) Then
                MessageBox.Show("Por favor, preencha o título e autor do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                db.OpenConnection()
                Dim query As String = "INSERT INTO Livros (Titulo, Autor, Ano, Estado) VALUES (@Titulo, @Autor, @Ano, @Estado)"
                Dim command As New MySqlCommand(query, db.GetConnection())
                command.Parameters.AddWithValue("@Titulo", TextBoxTitulo.Text)
                command.Parameters.AddWithValue("@Autor", TextBoxAutor.Text)
                command.Parameters.AddWithValue("@Ano", If(String.IsNullOrWhiteSpace(TextBoxAno.Text), DBNull.Value, Convert.ToInt32(TextBoxAno.Text)))
                command.Parameters.AddWithValue("@Estado", ComboBoxEstado.SelectedItem.ToString())
                command.ExecuteNonQuery()
                db.CloseConnection()
                MessageBox.Show("Livro inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListarLivros()
                LimparCampos()
            Catch ex As Exception
                MessageBox.Show("Erro ao inserir livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
            If DataGridViewLivros.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecione um livro para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If String.IsNullOrWhiteSpace(TextBoxTitulo.Text) Or String.IsNullOrWhiteSpace(TextBoxAutor.Text) Then
                MessageBox.Show("Por favor, preencha o título e autor do livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                Dim id As Integer = Convert.ToInt32(DataGridViewLivros.SelectedRows(0).Cells("ID").Value)
                db.OpenConnection()
                Dim query As String = "UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, Ano = @Ano, Estado = @Estado WHERE ID = @ID"
                Dim command As New MySqlCommand(query, db.GetConnection())
                command.Parameters.AddWithValue("@Titulo", TextBoxTitulo.Text)
                command.Parameters.AddWithValue("@Autor", TextBoxAutor.Text)
                command.Parameters.AddWithValue("@Ano", If(String.IsNullOrWhiteSpace(TextBoxAno.Text), DBNull.Value, Convert.ToInt32(TextBoxAno.Text)))
                command.Parameters.AddWithValue("@Estado", ComboBoxEstado.SelectedItem.ToString())
                command.Parameters.AddWithValue("@ID", id)
                command.ExecuteNonQuery()
                db.CloseConnection()
                MessageBox.Show("Livro atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListarLivros()
                LimparCampos()
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click
            If DataGridViewLivros.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecione um livro para eliminar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("Tem certeza que deseja eliminar este livro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    Dim id As Integer = Convert.ToInt32(DataGridViewLivros.SelectedRows(0).Cells("ID").Value)
                    db.OpenConnection()
                    Dim query As String = "DELETE FROM Livros WHERE ID = @ID"
                    Dim command As New MySqlCommand(query, db.GetConnection())
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()
                    db.CloseConnection()
                    MessageBox.Show("Livro eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListarLivros()
                    LimparCampos()
                Catch ex As Exception
                    MessageBox.Show("Erro ao eliminar livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub DataGridViewLivros_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewLivros.SelectionChanged
            If DataGridViewLivros.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = DataGridViewLivros.SelectedRows(0)
                TextBoxID.Text = row.Cells("ID").Value.ToString()
                TextBoxTitulo.Text = row.Cells("Titulo").Value.ToString()
                TextBoxAutor.Text = row.Cells("Autor").Value.ToString()
                TextBoxAno.Text = row.Cells("Ano").Value.ToString()
                ComboBoxEstado.SelectedItem = row.Cells("Estado").Value.ToString()
            End If
        End Sub

        Private Sub ButtonPesquisar_Click(sender As Object, e As EventArgs) Handles ButtonPesquisar.Click
            Try
                db.OpenConnection()
                Dim query As String = "SELECT * FROM Livros WHERE Titulo LIKE @Titulo OR Autor LIKE @Autor"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                adapter.SelectCommand.Parameters.AddWithValue("@Titulo", "%" & TextBoxPesquisa.Text & "%")
                adapter.SelectCommand.Parameters.AddWithValue("@Autor", "%" & TextBoxPesquisa.Text & "%")
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridViewLivros.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao pesquisar livros: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonLimpar_Click(sender As Object, e As EventArgs) Handles ButtonLimpar.Click
            LimparCampos()
        End Sub

        Private Sub ButtonVoltar_Click(sender As Object, e As EventArgs) Handles ButtonVoltar.Click
            Dim formMain As New FormMain()
            formMain.Show()
            Me.Close()
        End Sub

        Private Sub LimparCampos()
            TextBoxID.Clear()
            TextBoxTitulo.Clear()
            TextBoxAutor.Clear()
            TextBoxAno.Clear()
            ComboBoxEstado.SelectedIndex = -1
            TextBoxPesquisa.Clear()
        End Sub
    End Class
End Namespace