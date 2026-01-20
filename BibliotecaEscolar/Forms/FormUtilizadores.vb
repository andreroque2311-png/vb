Public Class FormUtilizadores
    Private dal As New UtilizadorDAL()

    Private Sub FormUtilizadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarUtilizadores()
    End Sub

    Private Sub CarregarUtilizadores()
        dgvUtilizadores.DataSource = Nothing
        dgvUtilizadores.DataSource = dal.ObterTodos()
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim utilizador As New Utilizador() With {
            .Nome = txtNome.Text,
            .Telefone = txtTelefone.Text,
            .Email = "",
            .DataRegistro = DateTime.Now
        }
        dal.Inserir(utilizador)
        CarregarUtilizadores()
        LimparCampos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvUtilizadores.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(dgvUtilizadores.SelectedRows(0).Cells("ID").Value)
            Dim utilizador As New Utilizador() With {
                .ID = id,
                .Nome = txtNome.Text,
                .Telefone = txtTelefone.Text,
                .Email = "",
                .DataRegistro = DateTime.Now
            }
            dal.Atualizar(utilizador)
            CarregarUtilizadores()
            LimparCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvUtilizadores.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(dgvUtilizadores.SelectedRows(0).Cells("ID").Value)
            dal.Eliminar(id)
            CarregarUtilizadores()
            LimparCampos()
        End If
    End Sub

    Private Sub dgvUtilizadores_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUtilizadores.SelectionChanged
        If dgvUtilizadores.SelectedRows.Count > 0 Then
            Dim row = dgvUtilizadores.SelectedRows(0)
            txtNome.Text = row.Cells("Nome").Value.ToString()
            txtTelefone.Text = row.Cells("Telefone").Value.ToString()
        End If
    End Sub

    Private Sub LimparCampos()
        txtNome.Clear()
        txtTelefone.Clear()
    End Sub
End Class
