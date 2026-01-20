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
        
        Public Sub New()
            Me.Text = "Gestão de Empréstimos"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvEmprestimos = New DataGridView
            dgvEmprestimos.Location = New Point(10, 10)
            dgvEmprestimos.Size = New Size(860, 300)
            dgvEmprestimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Controls.Add(dgvEmprestimos)
            
            ' Labels e TextBoxes
            Dim lblIdLivro = New Label
            lblIdLivro.Text = "ID Livro:"
            lblIdLivro.Location = New Point(10, 320)
            Me.Controls.Add(lblIdLivro)
            
            txtIdLivro = New TextBox
            txtIdLivro.Location = New Point(10, 340)
            txtIdLivro.Size = New Size(150, 25)
            Me.Controls.Add(txtIdLivro)
            
            Dim lblIdUtilizador = New Label
            lblIdUtilizador.Text = "ID Utilizador:"
            lblIdUtilizador.Location = New Point(170, 320)
            Me.Controls.Add(lblIdUtilizador)
            
            txtIdUtilizador = New TextBox
            txtIdUtilizador.Location = New Point(170, 340)
            txtIdUtilizador.Size = New Size(150, 25)
            Me.Controls.Add(txtIdUtilizador)
            
            Dim lblDataEmprestimo = New Label
            lblDataEmprestimo.Text = "Data Empréstimo:"
            lblDataEmprestimo.Location = New Point(330, 320)
            Me.Controls.Add(lblDataEmprestimo)
            
            txtDataEmprestimo = New TextBox
            txtDataEmprestimo.Location = New Point(330, 340)
            txtDataEmprestimo.Size = New Size(150, 25)
            Me.Controls.Add(txtDataEmprestimo)
            
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
            Me.Controls.Add(btnAtualizar)
            
            btnDeletar = New Button
            btnDeletar.Text = "Deletar"
            btnDeletar.Location = New Point(230, 380)
            btnDeletar.Size = New Size(100, 30)
            Me.Controls.Add(btnDeletar)
            
            btnLimpar = New Button
            btnLimpar.Text = "Limpar"
            btnLimpar.Location = New Point(340, 380)
            btnLimpar.Size = New Size(100, 30)
            AddHandler btnLimpar.Click, AddressOf BtnLimpar_Click
            Me.Controls.Add(btnLimpar)
        End Sub
        
        Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
            Dim emprestimo = New Emprestimo
            emprestimo.IdLivro = CInt(txtIdLivro.Text)
            emprestimo.IdUtilizador = CInt(txtIdUtilizador.Text)
            emprestimo.DataEmprestimo = CDate(txtDataEmprestimo.Text)
            
            MessageBox.Show("Empréstimo adicionado com sucesso!")
            BtnLimpar_Click(Nothing, Nothing)
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtIdLivro.Clear()
            txtIdUtilizador.Clear()
            txtDataEmprestimo.Clear()
            txtDataDevolucao.Clear()
        End Sub
    End Class
End Namespace
