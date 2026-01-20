Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL

Namespace BibliotecaEscolar.Forms
    Public Class FormLivros
        Inherits Form
        
        Private dgvLivros As DataGridView
        Private txtTitulo As TextBox
        Private txtAutor As TextBox
        Private txtISBN As TextBox
        Private btnAdicionar As Button
        Private btnAtualizar As Button
        Private btnDeletar As Button
        Private btnLimpar As Button
        
        Public Sub New()
            Me.Text = "Gestão de Livros"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvLivros = New DataGridView
            dgvLivros.Location = New Point(10, 10)
            dgvLivros.Size = New Size(860, 300)
            dgvLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.Controls.Add(dgvLivros)
            
            ' Labels e TextBoxes
            Dim lblTitulo = New Label
            lblTitulo.Text = "Título:"
            lblTitulo.Location = New Point(10, 320)
            Me.Controls.Add(lblTitulo)
            
            txtTitulo = New TextBox
            txtTitulo.Location = New Point(10, 340)
            txtTitulo.Size = New Size(200, 25)
            Me.Controls.Add(txtTitulo)
            
            Dim lblAutor = New Label
            lblAutor.Text = "Autor:"
            lblAutor.Location = New Point(220, 320)
            Me.Controls.Add(lblAutor)
            
            txtAutor = New TextBox
            txtAutor.Location = New Point(220, 340)
            txtAutor.Size = New Size(200, 25)
            Me.Controls.Add(txtAutor)
            
            Dim lblISBN = New Label
            lblISBN.Text = "ISBN:"
            lblISBN.Location = New Point(430, 320)
            Me.Controls.Add(lblISBN)
            
            txtISBN = New TextBox
            txtISBN.Location = New Point(430, 340)
            txtISBN.Size = New Size(200, 25)
            Me.Controls.Add(txtISBN)
            
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
            Dim livro = New Livro
            livro.Titulo = txtTitulo.Text
            livro.Autor = txtAutor.Text
            livro.ISBN = txtISBN.Text
            
            MessageBox.Show("Livro adicionado com sucesso!")
            BtnLimpar_Click(Nothing, Nothing)
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtTitulo.Clear()
            txtAutor.Clear()
            txtISBN.Clear()
        End Sub
    End Class
End Namespace
