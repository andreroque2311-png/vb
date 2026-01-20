Public Class FormEmprestimos
    Private emprestimoDal As New EmprestimoDAL()
    Private livroDal As New LivroDAL()
    Private utilizadorDal As New UtilizadorDAL()

    Private Sub FormEmprestimos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarDados()
    End Sub

    Private Sub CarregarDados()
        dgvEmprestimos.DataSource = Nothing
        dgvEmprestimos.DataSource = emprestimoDal.ObterTodos()

        cmbLivros.DataSource = livroDal.ObterTodos().FindAll(Function(l) l.Disponivel)
        cmbLivros.DisplayMember = "Titulo"
        cmbLivros.ValueMember = "ID"

        cmbUtilizadores.DataSource = utilizadorDal.ObterTodos()
        cmbUtilizadores.DisplayMember = "Nome"
        cmbUtilizadores.ValueMember = "ID"
    End Sub

    Private Sub btnEmprestar_Click(sender As Object, e As EventArgs) Handles btnEmprestar.Click
        If cmbLivros.SelectedValue IsNot Nothing AndAlso cmbUtilizadores.SelectedValue IsNot Nothing Then
            Dim emprestimo As New Emprestimo() With {
                .IdLivro = Convert.ToInt32(cmbLivros.SelectedValue),
                .IdUtilizador = Convert.ToInt32(cmbUtilizadores.SelectedValue),
                .DataEmprestimo = DateTime.Now
            }
            emprestimoDal.Inserir(emprestimo)
            CarregarDados()
        End If
    End Sub

    Private Sub btnDevolver_Click(sender As Object, e As EventArgs) Handles btnDevolver.Click
        If dgvEmprestimos.SelectedRows.Count > 0 Then
            Dim row = dgvEmprestimos.SelectedRows(0)
            Dim idEmprestimo As Integer = Convert.ToInt32(row.Cells("ID").Value)
            Dim idLivro As Integer = Convert.ToInt32(row.Cells("IdLivro").Value)
            
            If row.Cells("DataDevolucao").Value Is DBNull.Value OrElse row.Cells("DataDevolucao").Value Is Nothing Then
                emprestimoDal.RegistrarDevolucao(idEmprestimo, idLivro)
                CarregarDados()
            Else
                MessageBox.Show("Este empréstimo já foi devolvido.")
            End If
        End If
    End Sub
End Class
