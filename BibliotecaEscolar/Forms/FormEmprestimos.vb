Imports System.Windows.Forms
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data
Imports System.Drawing

Namespace BibliotecaEscolar.Forms
    Public Class FormEmprestimos
    Inherits Form

    Private dgvEmprestimos As DataGridView
    Private btnAdicionar As Button
    Private btnDevolver As Button
    Private btnAtualizar As Button
    Private chkMostrarAtivos As CheckBox

    Public Sub New()
        InitializeComponent()
        CarregarEmprestimos()
    End Sub

    Private Sub InitializeComponent()
        Me.dgvEmprestimos = New DataGridView()
        Me.btnAdicionar = New Button()
        Me.btnDevolver = New Button()
        Me.btnAtualizar = New Button()
        Me.chkMostrarAtivos = New CheckBox()
        
        Me.SuspendLayout()
        
        ' FormEmprestimos
        Me.Text = "Gestão de Empréstimos"
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        
        ' dgvEmprestimos
        Me.dgvEmprestimos.Location = New System.Drawing.Point(20, 20)
        Me.dgvEmprestimos.Size = New System.Drawing.Size(760, 400)
        Me.dgvEmprestimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmprestimos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmprestimos.AllowUserToAddRows = False
        Me.dgvEmprestimos.ReadOnly = True
        
        ' btnAdicionar
        Me.btnAdicionar.Location = New System.Drawing.Point(20, 440)
        Me.btnAdicionar.Size = New System.Drawing.Size(150, 40)
        Me.btnAdicionar.Text = "Novo Empréstimo"
        AddHandler Me.btnAdicionar.Click, AddressOf Me.BtnAdicionar_Click
        
        ' btnDevolver
        Me.btnDevolver.Location = New System.Drawing.Point(190, 440)
        Me.btnDevolver.Size = New System.Drawing.Size(150, 40)
        Me.btnDevolver.Text = "Devolver Livro"
        AddHandler Me.btnDevolver.Click, AddressOf Me.BtnDevolver_Click
        
        ' btnAtualizar
        Me.btnAtualizar.Location = New System.Drawing.Point(360, 440)
        Me.btnAtualizar.Size = New System.Drawing.Size(150, 40)
        Me.btnAtualizar.Text = "Atualizar Lista"
        AddHandler Me.btnAtualizar.Click, AddressOf Me.BtnAtualizar_Click
        
        ' chkMostrarAtivos
        Me.chkMostrarAtivos.Location = New System.Drawing.Point(20, 490)
        Me.chkMostrarAtivos.Size = New System.Drawing.Size(200, 30)
        Me.chkMostrarAtivos.Text = "Mostrar apenas empréstimos ativos"
        Me.chkMostrarAtivos.Checked = True
        AddHandler Me.chkMostrarAtivos.CheckedChanged, AddressOf Me.ChkMostrarAtivos_CheckedChanged
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.dgvEmprestimos)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.btnDevolver)
        Me.Controls.Add(Me.btnAtualizar)
        Me.Controls.Add(Me.chkMostrarAtivos)
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarEmprestimos()
        Try
            Dim emprestimos As List(Of Emprestimo)
            If chkMostrarAtivos.Checked Then
                emprestimos = EmprestimoDAL.ListarAtivos()
            Else
                emprestimos = EmprestimoDAL.ListarTodos()
            End If
            
            Dim dt As New DataTable()
            
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("ID Livro", GetType(Integer))
            dt.Columns.Add("ID Utilizador", GetType(Integer))
            dt.Columns.Add("Data Empréstimo", GetType(Date))
            dt.Columns.Add("Data Devolução", GetType(String))
            dt.Columns.Add("Status", GetType(String))
            
            For Each emprestimo As Emprestimo In emprestimos
                Dim status As String = If(emprestimo.DataDevolucao.HasValue, "Devolvido", "Ativo")
                Dim dataDevolucaoStr As String = If(emprestimo.DataDevolucao.HasValue, emprestimo.DataDevolucao.Value.ToString("dd/MM/yyyy HH:mm"), "Não devolvido")
                
                dt.Rows.Add(emprestimo.ID, emprestimo.IdLivro, emprestimo.IdUtilizador, emprestimo.DataEmprestimo, dataDevolucaoStr, status)
            Next
            
            dgvEmprestimos.DataSource = dt
            dgvEmprestimos.Columns("ID").Visible = False
            
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar empréstimos: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
        Dim formDetalhes As New FormEmprestimoDetalhes()
        If formDetalhes.ShowDialog() = DialogResult.OK Then
            CarregarEmprestimos()
        End If
    End Sub

    Private Sub BtnDevolver_Click(sender As Object, e As EventArgs)
        If dgvEmprestimos.SelectedRows.Count = 0 Then
            MessageBox.Show("Selecione um empréstimo para devolver.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        Dim id As Integer = CInt(dgvEmprestimos.SelectedRows(0).Cells("ID").Value)
        Dim status As String = dgvEmprestimos.SelectedRows(0).Cells("Status").Value.ToString()
        
        If status = "Devolvido" Then
            MessageBox.Show("Este empréstimo já foi devolvido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        If MessageBox.Show("Tem certeza que deseja registrar a devolução deste livro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                If EmprestimoDAL.DevolverLivro(id) Then
                    MessageBox.Show("Livro devolvido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CarregarEmprestimos()
                Else
                    MessageBox.Show("Falha ao registrar devolução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao registrar devolução: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
        CarregarEmprestimos()
    End Sub

    Private Sub ChkMostrarAtivos_CheckedChanged(sender As Object, e As EventArgs)
        CarregarEmprestimos()
    End Sub
End Class

Public Class FormEmprestimoDetalhes
    Inherits Form

    Private lblLivro As Label
    Private cmbLivros As ComboBox
    Private lblUtilizador As Label
    Private cmbUtilizadores As ComboBox
    Private lblDataEmprestimo As Label
    Private dtpDataEmprestimo As DateTimePicker
    Private btnSalvar As Button
    Private btnCancelar As Button

    Private emprestimo As Emprestimo

    Public Sub New()
        InitializeComponent()
        Me.Text = "Novo Empréstimo"
        Me.emprestimo = New Emprestimo()
        CarregarComboBoxes()
    End Sub

    Private Sub InitializeComponent()
        Me.lblLivro = New Label()
        Me.cmbLivros = New ComboBox()
        Me.lblUtilizador = New Label()
        Me.cmbUtilizadores = New ComboBox()
        Me.lblDataEmprestimo = New Label()
        Me.dtpDataEmprestimo = New DateTimePicker()
        Me.btnSalvar = New Button()
        Me.btnCancelar = New Button()
        
        Me.SuspendLayout()
        
        ' lblLivro
        Me.lblLivro.Location = New System.Drawing.Point(20, 20)
        Me.lblLivro.Size = New System.Drawing.Size(100, 25)
        Me.lblLivro.Text = "Livro:"
        
        ' cmbLivros
        Me.cmbLivros.Location = New System.Drawing.Point(130, 20)
        Me.cmbLivros.Size = New System.Drawing.Size(300, 30)
        Me.cmbLivros.DropDownStyle = ComboBoxStyle.DropDownList
        
        ' lblUtilizador
        Me.lblUtilizador.Location = New System.Drawing.Point(20, 70)
        Me.lblUtilizador.Size = New System.Drawing.Size(100, 25)
        Me.lblUtilizador.Text = "Utilizador:"
        
        ' cmbUtilizadores
        Me.cmbUtilizadores.Location = New System.Drawing.Point(130, 70)
        Me.cmbUtilizadores.Size = New System.Drawing.Size(300, 30)
        Me.cmbUtilizadores.DropDownStyle = ComboBoxStyle.DropDownList
        
        ' lblDataEmprestimo
        Me.lblDataEmprestimo.Location = New System.Drawing.Point(20, 120)
        Me.lblDataEmprestimo.Size = New System.Drawing.Size(100, 25)
        Me.lblDataEmprestimo.Text = "Data Empréstimo:"
        
        ' dtpDataEmprestimo
        Me.dtpDataEmprestimo.Location = New System.Drawing.Point(130, 120)
        Me.dtpDataEmprestimo.Size = New System.Drawing.Size(300, 30)
        Me.dtpDataEmprestimo.Format = DateTimePickerFormat.Short
        Me.dtpDataEmprestimo.Value = Date.Now
        
        ' btnSalvar
        Me.btnSalvar.Location = New System.Drawing.Point(130, 170)
        Me.btnSalvar.Size = New System.Drawing.Size(100, 40)
        Me.btnSalvar.Text = "Salvar"
        AddHandler Me.btnSalvar.Click, AddressOf Me.BtnSalvar_Click
        
        ' btnCancelar
        Me.btnCancelar.Location = New System.Drawing.Point(250, 170)
        Me.btnCancelar.Size = New System.Drawing.Size(100, 40)
        Me.btnCancelar.Text = "Cancelar"
        AddHandler Me.btnCancelar.Click, AddressOf Me.BtnCancelar_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.lblLivro)
        Me.Controls.Add(Me.cmbLivros)
        Me.Controls.Add(Me.lblUtilizador)
        Me.Controls.Add(Me.cmbUtilizadores)
        Me.Controls.Add(Me.lblDataEmprestimo)
        Me.Controls.Add(Me.dtpDataEmprestimo)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnCancelar)
        
        Me.ClientSize = New System.Drawing.Size(480, 250)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private Sub CarregarComboBoxes()
        Try
            ' Carregar livros disponíveis
            Dim livros As List(Of Livro) = LivroDAL.ObterDisponiveis()
            cmbLivros.Items.Clear()
            
            For Each livro As Livro In livros
                cmbLivros.Items.Add(New ComboBoxItem(livro.ID, livro.Titulo & " - " & livro.Autor))
            Next
            
            ' Carregar utilizadores
            Dim utilizadores As List(Of Utilizador) = UtilizadorDAL.ListarTodos()
            cmbUtilizadores.Items.Clear()
            
            For Each utilizador As Utilizador In utilizadores
                cmbUtilizadores.Items.Add(New ComboBoxItem(utilizador.ID, utilizador.Nome & " - " & utilizador.Email))
            Next
            
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar dados: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs)
        ' Validar seleção
        If cmbLivros.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione um livro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        If cmbUtilizadores.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione um utilizador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        
        ' Obter IDs selecionados
        Dim livroItem As ComboBoxItem = CType(cmbLivros.SelectedItem, ComboBoxItem)
        Dim utilizadorItem As ComboBoxItem = CType(cmbUtilizadores.SelectedItem, ComboBoxItem)
        
        ' Criar empréstimo
        emprestimo.IdLivro = livroItem.ID
        emprestimo.IdUtilizador = utilizadorItem.ID
        emprestimo.DataEmprestimo = dtpDataEmprestimo.Value
        emprestimo.DataDevolucao = Nothing
        
        Try
            ' Realizar empréstimo (usa transação)
            If EmprestimoDAL.RealizarEmprestimo(emprestimo.IdLivro, emprestimo.IdUtilizador) Then
                MessageBox.Show("Empréstimo realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Falha ao realizar empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao realizar empréstimo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Class ComboBoxItem
        Public Property ID As Integer
        Public Property DisplayText As String
        
        Public Sub New(id As Integer, displayText As String)
            Me.ID = id
            Me.DisplayText = displayText
        End Sub
        
        Public Overrides Function ToString() As String
            Return DisplayText
        End Function
    End Class
End Class
End Namespace