Imports MySql.Data.MySqlClient

Namespace BibliotecaEscolar
    Public Class FormUtilizadores
        Private db As New DatabaseConnection()

        Private Sub FormUtilizadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ListarUtilizadores()
        End Sub

        Private Sub ListarUtilizadores()
            Try
                db.OpenConnection()
                Dim query As String = "SELECT * FROM Utilizadores"
                Dim adapter As New MySqlDataAdapter(query, db.GetConnection())
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridViewUtilizadores.DataSource = table
                db.CloseConnection()
            Catch ex As Exception
                MessageBox.Show("Erro ao listar utilizadores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonInserir_Click(sender As Object, e As EventArgs) Handles ButtonInserir.Click
            If String.IsNullOrWhiteSpace(TextBoxNome.Text) Then
                MessageBox.Show("Por favor, preencha o nome do utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                db.OpenConnection()
                Dim query As String = "INSERT INTO Utilizadores (Nome, Turma, Contacto) VALUES (@Nome, @Turma, @Contacto)"
                Dim command As New MySqlCommand(query, db.GetConnection())
                command.Parameters.AddWithValue("@Nome", TextBoxNome.Text)
                command.Parameters.AddWithValue("@Turma", TextBoxTurma.Text)
                command.Parameters.AddWithValue("@Contacto", TextBoxContacto.Text)
                command.ExecuteNonQuery()
                db.CloseConnection()
                MessageBox.Show("Utilizador inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListarUtilizadores()
                LimparCampos()
            Catch ex As Exception
                MessageBox.Show("Erro ao inserir utilizador: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonEditar_Click(sender As Object, e As EventArgs) Handles ButtonEditar.Click
            If DataGridViewUtilizadores.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecione um utilizador para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If String.IsNullOrWhiteSpace(TextBoxNome.Text) Then
                MessageBox.Show("Por favor, preencha o nome do utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                Dim id As Integer = Convert.ToInt32(DataGridViewUtilizadores.SelectedRows(0).Cells("ID").Value)
                db.OpenConnection()
                Dim query As String = "UPDATE Utilizadores SET Nome = @Nome, Turma = @Turma, Contacto = @Contacto WHERE ID = @ID"
                Dim command As New MySqlCommand(query, db.GetConnection())
                command.Parameters.AddWithValue("@Nome", TextBoxNome.Text)
                command.Parameters.AddWithValue("@Turma", TextBoxTurma.Text)
                command.Parameters.AddWithValue("@Contacto", TextBoxContacto.Text)
                command.Parameters.AddWithValue("@ID", id)
                command.ExecuteNonQuery()
                db.CloseConnection()
                MessageBox.Show("Utilizador atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListarUtilizadores()
                LimparCampos()
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar utilizador: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click
            If DataGridViewUtilizadores.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, selecione um utilizador para eliminar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("Tem certeza que deseja eliminar este utilizador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    Dim id As Integer = Convert.ToInt32(DataGridViewUtilizadores.SelectedRows(0).Cells("ID").Value)
                    db.OpenConnection()
                    Dim query As String = "DELETE FROM Utilizadores WHERE ID = @ID"
                    Dim command As New MySqlCommand(query, db.GetConnection())
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()
                    db.CloseConnection()
                    MessageBox.Show("Utilizador eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListarUtilizadores()
                    LimparCampos()
                Catch ex As Exception
                    MessageBox.Show("Erro ao eliminar utilizador: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub DataGridViewUtilizadores_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewUtilizadores.SelectionChanged
            If DataGridViewUtilizadores.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = DataGridViewUtilizadores.SelectedRows(0)
                TextBoxID.Text = row.Cells("ID").Value.ToString()
                TextBoxNome.Text = row.Cells("Nome").Value.ToString()
                TextBoxTurma.Text = row.Cells("Turma").Value.ToString()
                TextBoxContacto.Text = row.Cells("Contacto").Value.ToString()
            End If
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
            TextBoxNome.Clear()
            TextBoxTurma.Clear()
            TextBoxContacto.Clear()
        End Sub
    End Class
End Namespace