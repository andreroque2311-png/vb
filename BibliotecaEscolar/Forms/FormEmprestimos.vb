Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL

Namespace BibliotecaEscolar.Forms
    Public Class FormEmprestimos
        Inherits Form
        
        Private dgvEmprestimos As DataGridView
        Private txtIdLivro As TextBox
        Private txtIdUtilizador As TextBox
        Private txtDataEmprestimo As TextBox
        Private txtDataDevolucao As TextBox
        Private btnAdicionar As Button
        Private btnAtualizar As Button
        Private btnDeletar As Button
        Private btnLimpar As Button
        Private emprestimoDAL As EmprestimoDAL
        
        Public Sub New()
            emprestimoDAL = New EmprestimoDAL()
            InitializeComponent()
            CarregarEmprestimos()
        End Sub
        
        Private Sub InitializeComponent()
            Me.Text = "Gestão de Empréstimos"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvEmprestimos = New DataGridView
            dgvEmprestimos.Location = New Point(10, 10)
            dgvEmprestimos.Size = New Size(860, 300)
            dgvEmprestimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvEmprestimos.AllowUserToAddRows = False
            dgvEmprestimos.ReadOnly = True
            dgvEmprestimos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            AddHandler dgvEmprestimos.SelectionChanged, AddressOf DgvEmprestimos_SelectionChanged
            Me.Controls.Add(dgvEmprestimos)
            
            ' Labels e TextBoxes
            Dim lblIdLivro = New Label
            lblIdLivro.Text = "ID Livro:"
            lblIdLivro.Location = New Point(10, 320)
            lblIdLivro.AutoSize = True
            Me.Controls.Add(lblIdLivro)
            
            txtIdLivro = New TextBox
            txtIdLivro.Location = New Point(10, 340)
            txtIdLivro.Size = New Size(100, 25)
            Me.Controls.Add(txtIdLivro)
            
            Dim lblIdUtilizador = New Label
            lblIdUtilizador.Text = "ID Utilizador:"
            lblIdUtilizador.Location = New Point(120, 320)
            lblIdUtilizador.AutoSize = True
            Me.Controls.Add(lblIdUtilizador)
            
            txtIdUtilizador = New TextBox
            txtIdUtilizador.Location = New Point(120, 340)
            txtIdUtilizador.Size = New Size(100, 25)
            Me.Controls.Add(txtIdUtilizador)
            
            Dim lblDataEmprestimo = New Label
            lblDataEmprestimo.Text = "Data Empréstimo:"
            lblDataEmprestimo.Location = New Point(230, 320)
            lblDataEmprestimo.AutoSize = True
            Me.Controls.Add(lblDataEmprestimo)
            
            txtDataEmprestimo = New TextBox
            txtDataEmprestimo.Location = New Point(230, 340)
            txtDataEmprestimo.Size = New Size(120, 25)
            Me.Controls.Add(txtDataEmprestimo)
            
            Dim lblDataDevolucao = New Label
            lblDataDevolucao.Text = "Data Devolução:"
            lblDataDevolucao.Location = New Point(360, 320)
            lblDataDevolucao.AutoSize = True
            Me.Controls.Add(lblDataDevolucao)
            
            txtDataDevolucao = New TextBox
            txtDataDevolucao.Location = New Point(360, 340)
            txtDataDevolucao.Size = New Size(120, 25)
            Me.Controls.Add(txtDataDevolucao)
            
            ' Botões
            btnAdicionar = New Button
            btnAdicionar.Text = "Adicionar"
            btnAdicionar.Location = New Point(10, 380)
            btnAdicionar.Size = New Size(100, 30)
            AddHandler btnAdicionar.Click, AddressOf BtnAdicionar_Click
            Me.Controls.Add(btnAdicionar)
            
            btnAtualizar = New Button
            btnAtualizar.Text = "Atualizar"
            btnAtualizar.Location = New Point(120, 380)
            btnAtualizar.Size = New Size(100, 30)
            AddHandler btnAtualizar.Click, AddressOf BtnAtualizar_Click
            Me.Controls.Add(btnAtualizar)
            
            btnDeletar = New Button
            btnDeletar.Text = "Deletar"
            btnDeletar.Location = New Point(230, 380)
            btnDeletar.Size = New Size(100, 30)
            AddHandler btnDeletar.Click, AddressOf BtnDeletar_Click
            Me.Controls.Add(btnDeletar)
            
            btnLimpar = New Button
            btnLimpar.Text = "Limpar"
            btnLimpar.Location = New Point(340, 380)
            btnLimpar.Size = New Size(100, 30)
            AddHandler btnLimpar.Click, AddressOf BtnLimpar_Click
            Me.Controls.Add(btnLimpar)
        End Sub
        
        Private Sub CarregarEmprestimos()
            Try
                Dim dt As DataTable = emprestimoDAL.ObterTodos()
                dgvEmprestimos.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar empréstimos: " & ex.Message)
            End Try
        End Sub
        
        Private Sub DgvEmprestimos_SelectionChanged(sender As Object, e As EventArgs)
            If dgvEmprestimos.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = dgvEmprestimos.SelectedRows(0)
                txtIdLivro.Text = row.Cells("IdLivro").Value.ToString()
                txtIdUtilizador.Text = row.Cells("IdUtilizador").Value.ToString()
                
                If row.Table.Columns.Contains("DataEmprestimo") AndAlso row.Cells("DataEmprestimo").Value IsNot DBNull.Value Then
                    txtDataEmprestimo.Text = Convert.ToDateTime(row.Cells("DataEmprestimo").Value).ToString("yyyy-MM-dd")
                End If
                
                If row.Table.Columns.Contains("DataDevolucao") AndAlso row.Cells("DataDevolucao").Value IsNot DBNull.Value Then
                    txtDataDevolucao.Text = Convert.ToDateTime(row.Cells("DataDevolucao").Value).ToString("yyyy-MM-dd")
                Else
                    txtDataDevolucao.Clear()
                End If
                
                If row.Table.Columns.Contains("ID") Then
                    txtIdLivro.Tag = row.Cells("ID").Value
                End If
            End If
        End Sub
        
        Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
            Try
                If String.IsNullOrWhiteSpace(txtIdLivro.Text) OrElse String.IsNullOrWhiteSpace(txtIdUtilizador.Text) OrElse String.IsNullOrWhiteSpace(txtDataEmprestimo.Text) Then
                    MessageBox.Show("Preencha o ID do livro, ID do utilizador e a data de empréstimo!")
                    Return
                End If
                
                Dim emprestimo As New Emprestimo
                emprestimo.IdLivro = CInt(txtIdLivro.Text)
                emprestimo.IdUtilizador = CInt(txtIdUtilizador.Text)
                emprestimo.DataEmprestimo = DateTime.Parse(txtDataEmprestimo.Text)
                
                If Not String.IsNullOrWhiteSpace(txtDataDevolucao.Text) Then
                    emprestimo.DataDevolucao = DateTime.Parse(txtDataDevolucao.Text)
                End If
                
                emprestimoDAL.AdicionarEmprestimo(emprestimo)
                MessageBox.Show("Empréstimo adicionado com sucesso!")
                CarregarEmprestimos()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar empréstimo: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
            Try
                If txtIdLivro.Tag Is Nothing Then
                    MessageBox.Show("Selecione um empréstimo para atualizar!")
                    Return
                End If
                
                If String.IsNullOrWhiteSpace(txtIdLivro.Text) OrElse String.IsNullOrWhiteSpace(txtIdUtilizador.Text) OrElse String.IsNullOrWhiteSpace(txtDataEmprestimo.Text) Then
                    MessageBox.Show("Preencha o ID do livro, ID do utilizador e a data de empréstimo!")
                    Return
                End If
                
                Dim emprestimo As New Emprestimo
                emprestimo.ID = CInt(txtIdLivro.Tag)
                emprestimo.IdLivro = CInt(txtIdLivro.Text)
                emprestimo.IdUtilizador = CInt(txtIdUtilizador.Text)
                emprestimo.DataEmprestimo = DateTime.Parse(txtDataEmprestimo.Text)
                
                If Not String.IsNullOrWhiteSpace(txtDataDevolucao.Text) Then
                    emprestimo.DataDevolucao = DateTime.Parse(txtDataDevolucao.Text)
                Else
                    emprestimo.DataDevolucao = Nothing
                End If
                
                emprestimoDAL.AtualizarEmprestimo(emprestimo)
                MessageBox.Show("Empréstimo atualizado com sucesso!")
                CarregarEmprestimos()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar empréstimo: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnDeletar_Click(sender As Object, e As EventArgs)
            Try
                If txtIdLivro.Tag Is Nothing Then
                    MessageBox.Show("Selecione um empréstimo para deletar!")
                    Return
                End If
                
                If MessageBox.Show("Deseja realmente deletar este empréstimo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim id As Integer = CInt(txtIdLivro.Tag)
                    emprestimoDAL.DeletarEmprestimo(id)
                    MessageBox.Show("Empréstimo deletado com sucesso!")
                    CarregarEmprestimos()
                    BtnLimpar_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao deletar empréstimo: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtIdLivro.Clear()
            txtIdUtilizador.Clear()
            txtDataEmprestimo.Clear()
            txtDataDevolucao.Clear()
            txtIdLivro.Tag = Nothing
            dgvEmprestimos.ClearSelection()
        End Sub
    End Class
End Namespace
