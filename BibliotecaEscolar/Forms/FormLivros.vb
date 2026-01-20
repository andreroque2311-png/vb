Public Class FormLivros
    Private dal As New LivroDAL()

    Private Sub FormLivros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarLivros()
    End Sub

    Private Sub CarregarLivros()
        dgvLivros.DataSource = Nothing
        dgvLivros.DataSource = dal.ObterTodos()
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        Dim livro As New Livro() With {
            .Titulo = txtTitulo.Text,
            .Autor = txtAutor.Text,
            .DataPublicacao = dtpPublicacao.Value,
            .Disponivel = chkDisponivel.Checked,
            .ISBN = ""
        }
        dal.Inserir(livro)
        CarregarLivros()
        LimparCampos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvLivros.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(dgvLivros.SelectedRows(0).Cells("ID").Value)
            Dim livro As New Livro() With {
                .ID = id,
                .Titulo = txtTitulo.Text,
                .Autor = txtAutor.Text,
                .DataPublicacao = dtpPublicacao.Value,
                .Disponivel = chkDisponivel.Checked,
                .ISBN = ""
            }
            dal.Atualizar(livro)
            CarregarLivros()
            LimparCampos()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvLivros.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(dgvLivros.SelectedRows(0).Cells("ID").Value)
            dal.Eliminar(id)
            CarregarLivros()
            LimparCampos()
        End If
    End Sub

    Private Sub dgvLivros_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLivros.SelectionChanged
        If dgvLivros.SelectedRows.Count > 0 Then
            Dim row = dgvLivros.SelectedRows(0)
            txtTitulo.Text = row.Cells("Titulo").Value.ToString()
            txtAutor.Text = row.Cells("Autor").Value.ToString()
            dtpPublicacao.Value = Convert.ToDateTime(row.Cells("DataPublicacao").Value)
            chkDisponivel.Checked = Convert.ToBoolean(row.Cells("Disponivel").Value)
        End If
    End Sub

    Private Sub LimparCampos()
        txtTitulo.Clear()
        txtAutor.Clear()
        dtpPublicacao.Value = DateTime.Now
        chkDisponivel.Checked = True
    End Sub
End Class
