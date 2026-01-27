Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data

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
            InitializeComponent()
            CarregarUtilizadores()
        End Sub
        
        Private Sub InitializeComponent()
            Me.Text = "Gestão de Utilizadores"
            Me.Size = New Size(900, 500)
            Me.StartPosition = FormStartPosition.CenterScreen
            
            ' DataGridView
            dgvUtilizadores = New DataGridView
            dgvUtilizadores.Location = New Point(10, 10)
            dgvUtilizadores.Size = New Size(860, 300)
            dgvUtilizadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvUtilizadores.AllowUserToAddRows = False
            dgvUtilizadores.ReadOnly = True
            dgvUtilizadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            AddHandler dgvUtilizadores.SelectionChanged, AddressOf DgvUtilizadores_SelectionChanged
            Me.Controls.Add(dgvUtilizadores)
            
            ' Labels e TextBoxes
            Dim lblNome = New Label
            lblNome.Text = "Nome:"
            lblNome.Location = New Point(10, 320)
            lblNome.AutoSize = True
            Me.Controls.Add(lblNome)
            
            txtNome = New TextBox
            txtNome.Location = New Point(10, 340)
            txtNome.Size = New Size(200, 25)
            Me.Controls.Add(txtNome)
            
            Dim lblEmail = New Label
            lblEmail.Text = "Email:"
            lblEmail.Location = New Point(220, 320)
            lblEmail.AutoSize = True
            Me.Controls.Add(lblEmail)
            
            txtEmail = New TextBox
            txtEmail.Location = New Point(220, 340)
            txtEmail.Size = New Size(200, 25)
            Me.Controls.Add(txtEmail)
            
            Dim lblTelefone = New Label
            lblTelefone.Text = "Telefone:"
            lblTelefone.Location = New Point(430, 320)
            lblTelefone.AutoSize = True
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
        
        Private Sub CarregarUtilizadores()
            Try
                Dim dt As DataTable = UtilizadorDAL.ListarTodos()
                dgvUtilizadores.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar utilizadores: " & ex.Message)
            End Try
        End Sub
        
        Private Sub DgvUtilizadores_SelectionChanged(sender As Object, e As EventArgs)
            If dgvUtilizadores.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = dgvUtilizadores.SelectedRows(0)
                txtNome.Text = row.Cells("Nome").Value.ToString()
                txtEmail.Text = row.Cells("Email").Value.ToString()
                txtTelefone.Text = row.Cells("Telefone").Value.ToString()
                txtNome.Tag = row.Cells("ID").Value
            End If
        End Sub
        
        Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
            Try
                If String.IsNullOrWhiteSpace(txtNome.Text) Then
                    MessageBox.Show("Preencha o nome!")
                    Return
                End If

                ' Validação de telefone: deve conter exatamente 9 dígitos
                If Not System.Text.RegularExpressions.Regex.IsMatch(txtTelefone.Text, "^\d{9}$") Then
                    MessageBox.Show("Telefone inválido! Deve conter exatamente 9 números.")
                    Return
                End If

                Dim utilizador As New Utilizador
                utilizador.Nome = txtNome.Text
                utilizador.Email = txtEmail.Text
                utilizador.Telefone = txtTelefone.Text

                UtilizadorDAL.AdicionarUtilizador(utilizador)
                MessageBox.Show("Utilizador adicionado com sucesso!")
                CarregarUtilizadores()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar utilizador: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
            Try
                If txtNome.Tag Is Nothing Then
                    MessageBox.Show("Selecione um utilizador para atualizar!")
                    Return
                End If

                If String.IsNullOrWhiteSpace(txtNome.Text) Then
                    MessageBox.Show("Preencha o nome!")
                    Return
                End If

                ' Validação de telefone: deve conter exatamente 9 dígitos
                If Not System.Text.RegularExpressions.Regex.IsMatch(txtTelefone.Text, "^\d{9}$") Then
                    MessageBox.Show("Telefone inválido! Deve conter exatamente 9 números.")
                    Return
                End If

                Dim utilizador As New Utilizador
                utilizador.ID = CInt(txtNome.Tag)
                utilizador.Nome = txtNome.Text
                utilizador.Email = txtEmail.Text
                utilizador.Telefone = txtTelefone.Text

                UtilizadorDAL.AtualizarUtilizador(utilizador)
                MessageBox.Show("Utilizador atualizado com sucesso!")
                CarregarUtilizadores()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar utilizador: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnDeletar_Click(sender As Object, e As EventArgs)
            Try
                If txtNome.Tag Is Nothing Then
                    MessageBox.Show("Selecione um utilizador para deletar!")
                    Return
                End If
                
                If MessageBox.Show("Deseja realmente deletar este utilizador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim id As Integer = CInt(txtNome.Tag)
                    UtilizadorDAL.DeletarUtilizador(id)
                    MessageBox.Show("Utilizador deletado com sucesso!")
                    CarregarUtilizadores()
                    BtnLimpar_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao deletar utilizador: " & ex.Message)
            End Try
        End Sub
        
        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            txtNome.Clear()
            txtEmail.Clear()
            txtTelefone.Clear()
            txtNome.Tag = Nothing
            dgvUtilizadores.ClearSelection()
        End Sub
    End Class
End Namespace
