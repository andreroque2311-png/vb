Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL

Namespace BibliotecaEscolar.Forms
    Public Class FormUtilizadores
        Inherits Form
        
        Private dgvUtilizadores As DataGridView
        Private txtNome As TextBox
        Private txtEmail As TextBox
        Private txtTelefone As TextBox
        Private btnAdicionar As Button
        Private btnAtualizar As Button
        Private btnDeletar As Button
        Private btnLimpar As Button
        
        Public Sub New()
            Me.Text = "Gestão de Utilizadores"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvUtilizadores = New DataGridView
            dgvUtilizadores.Location = New Point(10, 10)
            dgvUtilizadores.Size = New Size(860, 300)
            dgvUtilizadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Controls.Add(dgvUtilizadores)
            
            ' Labels e TextBoxes
            Dim lblNome = New Label
            lblNome.Text = "Nome:"
            lblNome.Location = New Point(10, 320)
            Me.Controls.Add(lblNome)
            
            txtNome = New TextBox
            txtNome.Location = New Point(10, 340)
            txtNome.Size = New Size(200, 25)
            Me.Controls.Add(txtNome)
            
            Dim lblEmail = New Label
            lblEmail.Text = "Email:"
            lblEmail.Location = New Point(220, 320)
            Me.Controls.Add(lblEmail)
            
            txtEmail = New TextBox
            txtEmail.Location = New Point(220, 340)
            txtEmail.Size = New Size(200, 25)
            Me.Controls.Add(txtEmail)
            
            Dim lblTelefone = New Label
            lblTelefone.Text = "Telefone:"
            lblTelefone.Location = New Point(430, 320)
            Me.Controls.Add(lblTelefone)
            
            txtTelefone = New TextBox
            txtTelefone.Location = New Point(430, 340)
            txtTelefone.Size = New Size(200, 25)
            Me.Controls.Add(txtTelefone)
            
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
            Dim utilizador = New Utilizador
            utilizador.Nome = txtNome.Text
            utilizador.Email = txtEmail.Text
            utilizador.Telefone = txtTelefone.Text
            
            MessageBox.Show("Utilizador adicionado com sucesso!")
            BtnLimpar_Click(Nothing, Nothing)
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtNome.Clear()
            txtEmail.Clear()
            txtTelefone.Clear()
        End Sub
    End Class
End Namespace
