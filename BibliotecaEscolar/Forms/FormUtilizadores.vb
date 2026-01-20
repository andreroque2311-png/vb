Imports System.Windows.Forms
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data
Imports System.Drawing

Namespace BibliotecaEscolar.Forms
    Public Class FormUtilizadores
    Inherits Form

    Private dgvUtilizadores As DataGridView
    Private btnAdicionar As Button
    Private btnEditar As Button
    Private btnExcluir As Button
    Private btnAtualizar As Button
    Private txtPesquisa As TextBox
    Private btnPesquisar As Button

    Public Sub New()
        InitializeComponent()
        CarregarUtilizadores()
    End Sub

    Private Sub InitializeComponent()
        Me.dgvUtilizadores = New DataGridView()
        Me.btnAdicionar = New Button()
        Me.btnEditar = New Button()
        Me.btnExcluir = New Button()
        Me.btnAtualizar = New Button()
        Me.txtPesquisa = New TextBox()
        Me.btnPesquisar = New Button()
        
        Me.SuspendLayout()
        
        ' FormUtilizadores
        Me.Text = "Gestão de Utilizadores"
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        
        ' dgvUtilizadores
        Me.dgvUtilizadores.Location = New System.Drawing.Point(20, 20)
        Me.dgvUtilizadores.Size = New System.Drawing.Size(760, 400)
        Me.dgvUtilizadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUtilizadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvUtilizadores.AllowUserToAddRows = False
        Me.dgvUtilizadores.ReadOnly = True
        
        ' btnAdicionar
        Me.btnAdicionar.Location = New System.Drawing.Point(20, 440)
        Me.btnAdicionar.Size = New System.Drawing.Size(150, 40)
        Me.btnAdicionar.Text = "Adicionar Utilizador"
        AddHandler Me.btnAdicionar.Click, AddressOf Me.BtnAdicionar_Click
        
        ' btnEditar
        Me.btnEditar.Location = New System.Drawing.Point(190, 440)
        Me.btnEditar.Size = New System.Drawing.Size(150, 40)
        Me.btnEditar.Text = "Editar Utilizador"
        AddHandler Me.btnEditar.Click, AddressOf Me.BtnEditar_Click
        
        ' btnExcluir
        Me.btnExcluir.Location = New System.Drawing.Point(360, 440)
        Me.btnExcluir.Size = New System.Drawing.Size(150, 40)
        Me.btnExcluir.Text = "Excluir Utilizador"
        AddHandler Me.btnExcluir.Click, AddressOf Me.BtnExcluir_Click
        
        ' btnAtualizar
        Me.btnAtualizar.Location = New System.Drawing.Point(530, 440)
        Me.btnAtualizar.Size = New System.Drawing.Size(150, 40)
        Me.btnAtualizar.Text = "Atualizar Lista"
        AddHandler Me.btnAtualizar.Click, AddressOf Me.BtnAtualizar_Click
        
        ' txtPesquisa
        Me.txtPesquisa.Location = New System.Drawing.Point(20, 500)
        Me.txtPesquisa.Size = New System.Drawing.Size(500, 30)
        Me.txtPesquisa.PlaceholderText = "Pesquisar por nome, email ou telefone..."
        
        ' btnPesquisar
        Me.btnPesquisar.Location = New System.Drawing.Point(540, 500)
        Me.btnPesquisar.Size = New System.Drawing.Size(150, 30)
        Me.btnPesquisar.Text = "Pesquisar"
        AddHandler Me.btnPesquisar.Click, AddressOf Me.BtnPesquisar_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.dgvUtilizadores)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.txtPesquisa)
        Me.Controls.Add(Me.btnPesquisar)
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarUtilizadores()
        Try
            Dim utilizadores As List(Of Utilizador) = UtilizadorDAL.ListarTodos()
            Dim dt As New DataTable()
            
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Nome", GetType(String))
            dt.Columns.Add("Email", GetType(String))
            dt.Columns.Add("Telefone", GetType(String))
            dt.Columns.Add("Data Registro", GetType(Date))
            
            For Each utilizador As Utilizador In utilizadores
                dt.Rows.Add(utilizador.ID, utilizador.Nome, utilizador.Email, utilizador.Telefone, utilizador.DataRegistro)
            Next
            
            dgvUtilizadores.DataSource = dt
            dgvUtilizadores.Columns("ID").Visible = False
            
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar utilizadores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
        Dim formDetalhes As New FormUtilizadorDetalhes()
        If formDetalhes.ShowDialog() = DialogResult.OK Then
            CarregarUtilizadores()
        End If
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs)
        If dgvUtilizadores.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um utilizador para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim id As Integer = CInt(dgvUtilizadores.SelectedRows(0).Cells("ID").Value)
        Dim utilizador As Utilizador = UtilizadorDAL.Obter(id)
        
        If utilizador IsNot Nothing Then
            Dim formDetalhes As New FormUtilizadorDetalhes(utilizador)
            If formDetalhes.ShowDialog() = DialogResult.OK Then
                CarregarUtilizadores()
            End If
        End If
    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs)
        If dgvUtilizadores.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um utilizador para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim id As Integer = CInt(dgvUtilizadores.SelectedRows(0).Cells("ID").Value)
        
        If MessageBox.Show("Tem certeza que deseja excluir este utilizador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If UtilizadorDAL.Deletar(id) Then
                    MessageBox.Show("Utilizador excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarUtilizadores()
                Else
                    MessageBox.Show("Falha ao excluir utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao excluir utilizador: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
        CarregarUtilizadores()
    End Sub

    Private Sub BtnPesquisar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtPesquisa.Text) Then
            CarregarUtilizadores()
            Return
        End If
        
        Try
            Dim utilizadores As List(Of Utilizador) = UtilizadorDAL.Pesquisar(txtPesquisa.Text)
            Dim dt As New DataTable()
            
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Nome", GetType(String))
            dt.Columns.Add("Email", GetType(String))
            dt.Columns.Add("Telefone", GetType(String))
            dt.Columns.Add("Data Registro", GetType(Date))
            
            For Each utilizador As Utilizador In utilizadores
                dt.Rows.Add(utilizador.ID, utilizador.Nome, utilizador.Email, utilizador.Telefone, utilizador.DataRegistro)
            Next
            
            dgvUtilizadores.DataSource = dt
            dgvUtilizadores.Columns("ID").Visible = False
            
        Catch ex As Exception
            MessageBox.Show("Erro ao pesquisar utilizadores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

Public Class FormUtilizadorDetalhes
    Inherits Form

    Private lblNome As Label
    Private txtNome As TextBox
    Private lblEmail As Label
    Private txtEmail As TextBox
    Private lblTelefone As Label
    Private txtTelefone As TextBox
    Private lblDataRegistro As Label
    Private dtpDataRegistro As DateTimePicker
    Private btnSalvar As Button
    Private btnCancelar As Button

    Private utilizador As Utilizador
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        Me.Text = "Adicionar Utilizador"
        Me.utilizador = New Utilizador()
        Me.isEditMode = False
    End Sub

    Public Sub New(existingUtilizador As Utilizador)
        InitializeComponent()
        Me.Text = "Editar Utilizador"
        Me.utilizador = existingUtilizador
        Me.isEditMode = True
        CarregarDados()
    End Sub

    Private Sub InitializeComponent()
        Me.lblNome = New Label()
        Me.txtNome = New TextBox()
        Me.lblEmail = New Label()
        Me.txtEmail = New TextBox()
        Me.lblTelefone = New Label()
        Me.txtTelefone = New TextBox()
        Me.lblDataRegistro = New Label()
        Me.dtpDataRegistro = New DateTimePicker()
        Me.btnSalvar = New Button()
        Me.btnCancelar = New Button()
        
        Me.SuspendLayout()
        
        ' lblNome
        Me.lblNome.Location = New System.Drawing.Point(20, 20)
        Me.lblNome.Size = New System.Drawing.Size(100, 25)
        Me.lblNome.Text = "Nome:"
        
        ' txtNome
        Me.txtNome.Location = New System.Drawing.Point(130, 20)
        Me.txtNome.Size = New System.Drawing.Size(300, 30)
        
        ' lblEmail
        Me.lblEmail.Location = New System.Drawing.Point(20, 70)
        Me.lblEmail.Size = New System.Drawing.Size(100, 25)
        Me.lblEmail.Text = "Email:"
        
        ' txtEmail
        Me.txtEmail.Location = New System.Drawing.Point(130, 70)
        Me.txtEmail.Size = New System.Drawing.Size(300, 30)
        
        ' lblTelefone
        Me.lblTelefone.Location = New System.Drawing.Point(20, 120)
        Me.lblTelefone.Size = New System.Drawing.Size(100, 25)
        Me.lblTelefone.Text = "Telefone:"
        
        ' txtTelefone
        Me.txtTelefone.Location = New System.Drawing.Point(130, 120)
        Me.txtTelefone.Size = New System.Drawing.Size(300, 30)
        
        ' lblDataRegistro
        Me.lblDataRegistro.Location = New System.Drawing.Point(20, 170)
        Me.lblDataRegistro.Size = New System.Drawing.Size(100, 25)
        Me.lblDataRegistro.Text = "Data Registro:"
        
        ' dtpDataRegistro
        Me.dtpDataRegistro.Location = New System.Drawing.Point(130, 170)
        Me.dtpDataRegistro.Size = New System.Drawing.Size(300, 30)
        Me.dtpDataRegistro.Format = DateTimePickerFormat.Short
        
        ' btnSalvar
        Me.btnSalvar.Location = New System.Drawing.Point(130, 220)
        Me.btnSalvar.Size = New System.Drawing.Size(100, 40)
        Me.btnSalvar.Text = "Salvar"
        AddHandler Me.btnSalvar.Click, AddressOf Me.BtnSalvar_Click
        
        ' btnCancelar
        Me.btnCancelar.Location = New System.Drawing.Point(250, 220)
        Me.btnCancelar.Size = New System.Drawing.Size(100, 40)
        Me.btnCancelar.Text = "Cancelar"
        AddHandler Me.btnCancelar.Click, AddressOf Me.BtnCancelar_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.lblNome)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblTelefone)
        Me.Controls.Add(Me.txtTelefone)
        Me.Controls.Add(Me.lblDataRegistro)
        Me.Controls.Add(Me.dtpDataRegistro)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        
        Me.ClientSize = New System.Drawing.Size(480, 300)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarDados()
        txtNome.Text = utilizador.Nome
        txtEmail.Text = utilizador.Email
        txtTelefone.Text = utilizador.Telefone
        dtpDataRegistro.Value = utilizador.DataRegistro
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs)
        ' Validar dados
        If String.IsNullOrWhiteSpace(txtNome.Text) Then
            MessageBox.Show("O nome é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Atualizar objeto utilizador
        utilizador.Nome = txtNome.Text
        utilizador.Email = txtEmail.Text
        utilizador.Telefone = txtTelefone.Text
        utilizador.DataRegistro = dtpDataRegistro.Value
        
        Try
            If isEditMode Then
                ' Atualizar utilizador existente
                If UtilizadorDAL.Atualizar(utilizador) Then
                    MessageBox.Show("Utilizador atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Falha ao atualizar utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Adicionar novo utilizador
                utilizador.ID = UtilizadorDAL.Adicionar(utilizador)
                If utilizador.ID > 0 Then
                    MessageBox.Show("Utilizador adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Falha ao adicionar utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar utilizador: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
End Namespace