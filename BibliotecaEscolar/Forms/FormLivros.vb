Imports System.Windows.Forms
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data
Imports System.Drawing

Namespace BibliotecaEscolar.Forms
    Public Class FormLivros
    Inherits Form

    Private dgvLivros As DataGridView
    Private btnAdicionar As Button
    Private btnEditar As Button
    Private btnExcluir As Button
    Private btnAtualizar As Button
    Private txtPesquisa As TextBox
    Private btnPesquisar As Button

    Public Sub New()
        InitializeComponent()
        CarregarLivros()
    End Sub

    Private Sub InitializeComponent()
        Me.dgvLivros = New DataGridView()
        Me.btnAdicionar = New Button()
        Me.btnEditar = New Button()
        Me.btnExcluir = New Button()
        Me.btnAtualizar = New Button()
        Me.txtPesquisa = New TextBox()
        Me.btnPesquisar = New Button()
        
        Me.SuspendLayout()
        
        ' FormLivros
        Me.Text = "Gestão de Livros"
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        
        ' dgvLivros
        Me.dgvLivros.Location = New System.Drawing.Point(20, 20)
        Me.dgvLivros.Size = New System.Drawing.Size(760, 400)
        Me.dgvLivros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLivros.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvLivros.AllowUserToAddRows = False
        Me.dgvLivros.ReadOnly = True
        
        ' btnAdicionar
        Me.btnAdicionar.Location = New System.Drawing.Point(20, 440)
        Me.btnAdicionar.Size = New System.Drawing.Size(150, 40)
        Me.btnAdicionar.Text = "Adicionar Livro"
        AddHandler Me.btnAdicionar.Click, AddressOf Me.BtnAdicionar_Click
        
        ' btnEditar
        Me.btnEditar.Location = New System.Drawing.Point(190, 440)
        Me.btnEditar.Size = New System.Drawing.Size(150, 40)
        Me.btnEditar.Text = "Editar Livro"
        AddHandler Me.btnEditar.Click, AddressOf Me.BtnEditar_Click
        
        ' btnExcluir
        Me.btnExcluir.Location = New System.Drawing.Point(360, 440)
        Me.btnExcluir.Size = New System.Drawing.Size(150, 40)
        Me.btnExcluir.Text = "Excluir Livro"
        AddHandler Me.btnExcluir.Click, AddressOf Me.BtnExcluir_Click
        
        ' btnAtualizar
        Me.btnAtualizar.Location = New System.Drawing.Point(530, 440)
        Me.btnAtualizar.Size = New System.Drawing.Size(150, 40)
        Me.btnAtualizar.Text = "Atualizar Lista"
        AddHandler Me.btnAtualizar.Click, AddressOf Me.BtnAtualizar_Click
        
        ' txtPesquisa
        Me.txtPesquisa.Location = New System.Drawing.Point(20, 500)
        Me.txtPesquisa.Size = New System.Drawing.Size(500, 30)
        Me.txtPesquisa.PlaceholderText = "Pesquisar por título, autor ou ISBN..."
        
        ' btnPesquisar
        Me.btnPesquisar.Location = New System.Drawing.Point(540, 500)
        Me.btnPesquisar.Size = New System.Drawing.Size(150, 30)
        Me.btnPesquisar.Text = "Pesquisar"
        AddHandler Me.btnPesquisar.Click, AddressOf Me.BtnPesquisar_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.dgvLivros)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.txtPesquisa)
        Me.Controls.Add(Me.btnPesquisar)
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarLivros()
        Try
            Dim livros As List(Of Livro) = LivroDAL.ListarTodos()
            Dim dt As New DataTable()
            
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Título", GetType(String))
            dt.Columns.Add("Autor", GetType(String))
            dt.Columns.Add("ISBN", GetType(String))
            dt.Columns.Add("Data Publicação", GetType(Date))
            dt.Columns.Add("Disponível", GetType(String))
            
            For Each livro As Livro In livros
                dt.Rows.Add(livro.ID, livro.Titulo, livro.Autor, livro.ISBN, livro.DataPublicacao, If(livro.Disponivel, "Sim", "Não"))
            Next
            
            dgvLivros.DataSource = dt
            dgvLivros.Columns("ID").Visible = False
            
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar livros: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
        Dim formDetalhes As New FormLivroDetalhes()
        If formDetalhes.ShowDialog() = DialogResult.OK Then
            CarregarLivros()
        End If
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs)
        If dgvLivros.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um livro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim id As Integer = CInt(dgvLivros.SelectedRows(0).Cells("ID").Value)
        Dim livro As Livro = LivroDAL.Obter(id)
        
        If livro IsNot Nothing Then
            Dim formDetalhes As New FormLivroDetalhes(livro)
            If formDetalhes.ShowDialog() = DialogResult.OK Then
                CarregarLivros()
            End If
        End If
    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs)
        If dgvLivros.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um livro para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim id As Integer = CInt(dgvLivros.SelectedRows(0).Cells("ID").Value)
        
        If MessageBox.Show("Tem certeza que deseja excluir este livro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If LivroDAL.Deletar(id) Then
                    MessageBox.Show("Livro excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarLivros()
                Else
                    MessageBox.Show("Falha ao excluir livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
        CarregarLivros()
    End Sub

    Private Sub BtnPesquisar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtPesquisa.Text) Then
            CarregarLivros()
            Return
        End If
        
        Try
            Dim livros As List(Of Livro) = LivroDAL.Pesquisar(txtPesquisa.Text)
            Dim dt As New DataTable()
            
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Título", GetType(String))
            dt.Columns.Add("Autor", GetType(String))
            dt.Columns.Add("ISBN", GetType(String))
            dt.Columns.Add("Data Publicação", GetType(Date))
            dt.Columns.Add("Disponível", GetType(String))
            
            For Each livro As Livro In livros
                dt.Rows.Add(livro.ID, livro.Titulo, livro.Autor, livro.ISBN, livro.DataPublicacao, If(livro.Disponivel, "Sim", "Não"))
            Next
            
            dgvLivros.DataSource = dt
            dgvLivros.Columns("ID").Visible = False
            
        Catch ex As Exception
            MessageBox.Show("Erro ao pesquisar livros: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FormLivroDetalhes
    Inherits Form

    Private lblTitulo As Label
    Private txtTitulo As TextBox
    Private lblAutor As Label
    Private txtAutor As TextBox
    Private lblISBN As Label
    Private txtISBN As TextBox
    Private lblDataPublicacao As Label
    Private dtpDataPublicacao As DateTimePicker
    Private lblDisponivel As Label
    Private chkDisponivel As CheckBox
    Private btnSalvar As Button
    Private btnCancelar As Button

    Private livro As Livro
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Text = "Adicionar Livro"
        Me.livro = New Livro()
        Me.isEditMode = False
    End Sub

    Public Sub New(existingLivro As Livro)
        InitializeComponent()
        Me.Text = "Editar Livro"
        Me.livro = existingLivro
        Me.isEditMode = True
        CarregarDados()
    End Sub

    Private Sub InitializeComponent()
        Me.lblTitulo = New Label()
        Me.txtTitulo = New TextBox()
        Me.lblAutor = New Label()
        Me.txtAutor = New TextBox()
        Me.lblISBN = New Label()
        Me.txtISBN = New TextBox()
        Me.lblDataPublicacao = New Label()
        Me.dtpDataPublicacao = New DateTimePicker()
        Me.lblDisponivel = New Label()
        Me.chkDisponivel = New CheckBox()
        Me.btnSalvar = New Button()
        Me.btnCancelar = New Button()
        
        Me.SuspendLayout()
        
        ' lblTitulo
        Me.lblTitulo.Location = New System.Drawing.Point(20, 20)
        Me.lblTitulo.Size = New System.Drawing.Size(100, 25)
        Me.lblTitulo.Text = "Título:"
        
        ' txtTitulo
        Me.txtTitulo.Location = New System.Drawing.Point(130, 20)
        Me.txtTitulo.Size = New System.Drawing.Size(300, 30)
        
        ' lblAutor
        Me.lblAutor.Location = New System.Drawing.Point(20, 70)
        Me.lblAutor.Size = New System.Drawing.Size(100, 25)
        Me.lblAutor.Text = "Autor:"
        
        ' txtAutor
        Me.txtAutor.Location = New System.Drawing.Point(130, 70)
        Me.txtAutor.Size = New System.Drawing.Size(300, 30)
        
        ' lblISBN
        Me.lblISBN.Location = New System.Drawing.Point(20, 120)
        Me.lblISBN.Size = New System.Drawing.Size(100, 25)
        Me.lblISBN.Text = "ISBN:"
        
        ' txtISBN
        Me.txtISBN.Location = New System.Drawing.Point(130, 120)
        Me.txtISBN.Size = New System.Drawing.Size(300, 30)
        
        ' lblDataPublicacao
        Me.lblDataPublicacao.Location = New System.Drawing.Point(20, 170)
        Me.lblDataPublicacao.Size = New System.Drawing.Size(100, 25)
        Me.lblDataPublicacao.Text = "Data Publicação:"
        
        ' dtpDataPublicacao
        Me.dtpDataPublicacao.Location = New System.Drawing.Point(130, 170)
        Me.dtpDataPublicacao.Size = New System.Drawing.Size(300, 30)
        Me.dtpDataPublicacao.Format = DateTimePickerFormat.Short
        
        ' lblDisponivel
        Me.lblDisponivel.Location = New System.Drawing.Point(20, 220)
        Me.lblDisponivel.Size = New System.Drawing.Size(100, 25)
        Me.lblDisponivel.Text = "Disponível:"
        
        ' chkDisponivel
        Me.chkDisponivel.Location = New System.Drawing.Point(130, 220)
        Me.chkDisponivel.Size = New System.Drawing.Size(200, 30)
        Me.chkDisponivel.Checked = True
        
        ' btnSalvar
        Me.btnSalvar.Location = New System.Drawing.Point(130, 270)
        Me.btnSalvar.Size = New System.Drawing.Size(100, 40)
        Me.btnSalvar.Text = "Salvar"
        AddHandler Me.btnSalvar.Click, AddressOf Me.BtnSalvar_Click
        
        ' btnCancelar
        Me.btnCancelar.Location = New System.Drawing.Point(250, 270)
        Me.btnCancelar.Size = New System.Drawing.Size(100, 40)
        Me.btnCancelar.Text = "Cancelar"
        AddHandler Me.btnCancelar.Click, AddressOf Me.BtnCancelar_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.lblAutor)
        Me.Controls.Add(Me.txtAutor)
        Me.Controls.Add(Me.lblISBN)
        Me.Controls.Add(Me.txtISBN)
        Me.Controls.Add(Me.lblDataPublicacao)
        Me.Controls.Add(Me.dtpDataPublicacao)
        Me.Controls.Add(Me.lblDisponivel)
        Me.Controls.Add(Me.chkDisponivel)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        
        Me.ClientSize = New System.Drawing.Size(480, 350)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarDados()
        txtTitulo.Text = livro.Titulo
        txtAutor.Text = livro.Autor
        txtISBN.Text = livro.ISBN
        dtpDataPublicacao.Value = livro.DataPublicacao
        chkDisponivel.Checked = livro.Disponivel
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs)
        ' Validar dados
        If String.IsNullOrWhiteSpace(txtTitulo.Text) Then
            MessageBox.Show("O título é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        If String.IsNullOrWhiteSpace(txtAutor.Text) Then
            MessageBox.Show("O autor é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Atualizar objeto livro
        livro.Titulo = txtTitulo.Text
        livro.Autor = txtAutor.Text
        livro.ISBN = txtISBN.Text
        livro.DataPublicacao = dtpDataPublicacao.Value
        livro.Disponivel = chkDisponivel.Checked
        
        Try
            If isEditMode Then
                ' Atualizar livro existente
                If LivroDAL.Atualizar(livro) Then
                    MessageBox.Show("Livro atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Falha ao atualizar livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Adicionar novo livro
                livro.ID = LivroDAL.Adicionar(livro)
                If livro.ID > 0 Then
                    MessageBox.Show("Livro adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Falha ao adicionar livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar livro: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
End Namespace