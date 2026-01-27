Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data

Namespace BibliotecaEscolar.Forms
    Public Class FormLivros
        Inherits Form
        
        Private dgvLivros As DataGridView
        Private txtTitulo As TextBox
        Private txtAutor As TextBox
        Private txtAno As TextBox
        Private cmbEstado As ComboBox
        Private btnAdicionar As Button
        Private btnAtualizar As Button
        Private btnDeletar As Button
        Private btnLimpar As Button
        
        Public Sub New()
            InitializeComponent()
            CarregarLivros()
        End Sub
        
        Private Sub InitializeComponent()
            Me.Text = "Gestão de Livros"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvLivros = New DataGridView
            dgvLivros.Location = New Point(10, 10)
            dgvLivros.Size = New Size(860, 300)
            dgvLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvLivros.AllowUserToAddRows = False
            dgvLivros.ReadOnly = True
            dgvLivros.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            AddHandler dgvLivros.SelectionChanged, AddressOf DgvLivros_SelectionChanged
            Me.Controls.Add(dgvLivros)
            
            ' Labels e TextBoxes
            Dim lblTitulo = New Label
            lblTitulo.Text = "Título:"
            lblTitulo.Location = New Point(10, 320)
            lblTitulo.AutoSize = True
            Me.Controls.Add(lblTitulo)
            
            txtTitulo = New TextBox
            txtTitulo.Location = New Point(10, 340)
            txtTitulo.Size = New Size(200, 25)
            Me.Controls.Add(txtTitulo)
            
            Dim lblAutor = New Label
            lblAutor.Text = "Autor:"
            lblAutor.Location = New Point(220, 320)
            lblAutor.AutoSize = True
            Me.Controls.Add(lblAutor)
            
            txtAutor = New TextBox
            txtAutor.Location = New Point(220, 340)
            txtAutor.Size = New Size(200, 25)
            Me.Controls.Add(txtAutor)
            
            Dim lblAno = New Label
            lblAno.Text = "Ano:"
            lblAno.Location = New Point(430, 320)
            lblAno.AutoSize = True
            Me.Controls.Add(lblAno)
            
            txtAno = New TextBox
            txtAno.Location = New Point(430, 340)
            txtAno.Size = New Size(100, 25)
            Me.Controls.Add(txtAno)

            Dim lblEstado = New Label
            lblEstado.Text = "Estado:"
            lblEstado.Location = New Point(540, 320)
            lblEstado.AutoSize = True
            Me.Controls.Add(lblEstado)

            cmbEstado = New ComboBox
            cmbEstado.Location = New Point(540, 340)
            cmbEstado.Size = New Size(150, 25)
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList
            cmbEstado.Items.AddRange(New Object() {"Disponível", "Emprestado"})
            cmbEstado.SelectedIndex = 0
            Me.Controls.Add(cmbEstado)
            
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
        
        Private Sub CarregarLivros()
            Try
                Dim dt As DataTable = LivroDAL.ListarTodos()
                dgvLivros.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar livros: " & ex.Message)
            End Try
        End Sub
        
        Private Sub DgvLivros_SelectionChanged(sender As Object, e As EventArgs)
            If dgvLivros.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = dgvLivros.SelectedRows(0)
                txtTitulo.Text = row.Cells("Titulo").Value.ToString()
                txtAutor.Text = row.Cells("Autor").Value.ToString()
                txtAno.Text = row.Cells("Ano").Value.ToString()
                cmbEstado.SelectedItem = row.Cells("Estado").Value.ToString()
                txtTitulo.Tag = row.Cells("ID").Value
            End If
        End Sub
        
        Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
            Try
                If String.IsNullOrWhiteSpace(txtTitulo.Text) OrElse String.IsNullOrWhiteSpace(txtAutor.Text) Then
                    MessageBox.Show("Preencha o título e autor!")
                    Return
                End If
                
                Dim livro As New Livro
                livro.Titulo = txtTitulo.Text
                livro.Autor = txtAutor.Text
                livro.Ano = If(IsNumeric(txtAno.Text), CInt(txtAno.Text), 0)
                livro.Estado = cmbEstado.SelectedItem.ToString()
                
                LivroDAL.AdicionarLivro(livro)
                MessageBox.Show("Livro adicionado com sucesso!")
                CarregarLivros()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar livro: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
            Try
                If txtTitulo.Tag Is Nothing Then
                    MessageBox.Show("Selecione um livro para atualizar!")
                    Return
                End If
                
                If String.IsNullOrWhiteSpace(txtTitulo.Text) OrElse String.IsNullOrWhiteSpace(txtAutor.Text) Then
                    MessageBox.Show("Preencha o título e autor!")
                    Return
                End If
                
                Dim livro As New Livro
                livro.ID = CInt(txtTitulo.Tag)
                livro.Titulo = txtTitulo.Text
                livro.Autor = txtAutor.Text
                livro.Ano = If(IsNumeric(txtAno.Text), CInt(txtAno.Text), 0)
                livro.Estado = cmbEstado.SelectedItem.ToString()
                
                LivroDAL.AtualizarLivro(livro)
                MessageBox.Show("Livro atualizado com sucesso!")
                CarregarLivros()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar livro: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnDeletar_Click(sender As Object, e As EventArgs)
            Try
                If txtTitulo.Tag Is Nothing Then
                    MessageBox.Show("Selecione um livro para deletar!")
                    Return
                End If
                
                If MessageBox.Show("Deseja realmente deletar este livro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim id As Integer = CInt(txtTitulo.Tag)
                    LivroDAL.DeletarLivro(id)
                    MessageBox.Show("Livro deletado com sucesso!")
                    CarregarLivros()
                    BtnLimpar_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao deletar livro: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtTitulo.Clear()
            txtAutor.Clear()
            txtAno.Clear()
            If cmbEstado.Items.Count > 0 Then cmbEstado.SelectedIndex = 0
            txtTitulo.Tag = Nothing
            dgvLivros.ClearSelection()
        End Sub
    End Class
End Namespace
