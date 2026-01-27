Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Models
Imports BibliotecaEscolar.DAL
Imports System.Data

Namespace BibliotecaEscolar.Forms
    Public Class FormEmprestimos
        Inherits Form

        Private dgvEmprestimos As DataGridView
        Private cmbLivro As ComboBox
        Private cmbUtilizador As ComboBox
        Private txtDataEmprestimo As TextBox
        Private txtDataDevolucao As TextBox
        Private btnAdicionar As Button
        Private btnAtualizar As Button
        Private btnDeletar As Button
        Private btnLimpar As Button

        Public Sub New()
            InitializeComponent()
            CarregarDados()
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "Gestão de Empréstimos"
            Me.Size = New Size(900, 520)
            Me.StartPosition = FormStartPosition.CenterScreen

            dgvEmprestimos = New DataGridView
            dgvEmprestimos.Location = New Point(10, 10)
            dgvEmprestimos.Size = New Size(860, 300)
            dgvEmprestimos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvEmprestimos.AllowUserToAddRows = False
            dgvEmprestimos.ReadOnly = True
            dgvEmprestimos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            AddHandler dgvEmprestimos.SelectionChanged, AddressOf DgvEmprestimos_SelectionChanged
            Me.Controls.Add(dgvEmprestimos)

            Dim lblLivro = New Label
            lblLivro.Text = "Livro:"
            lblLivro.Location = New Point(10, 320)
            lblLivro.AutoSize = True
            Me.Controls.Add(lblLivro)

            cmbLivro = New ComboBox
            cmbLivro.Location = New Point(10, 340)
            cmbLivro.Size = New Size(340, 25)
            cmbLivro.DropDownStyle = ComboBoxStyle.DropDownList
            AddHandler cmbLivro.SelectedIndexChanged, AddressOf CmbLivro_SelectedIndexChanged
            Me.Controls.Add(cmbLivro)

            Dim lblUtilizador = New Label
            lblUtilizador.Text = "Utilizador:"
            lblUtilizador.Location = New Point(360, 320)
            lblUtilizador.AutoSize = True
            Me.Controls.Add(lblUtilizador)

            cmbUtilizador = New ComboBox
            cmbUtilizador.Location = New Point(360, 340)
            cmbUtilizador.Size = New Size(220, 25)
            cmbUtilizador.DropDownStyle = ComboBoxStyle.DropDownList
            AddHandler cmbUtilizador.SelectedIndexChanged, AddressOf CmbUtilizador_SelectedIndexChanged
            Me.Controls.Add(cmbUtilizador)

            Dim lblDataEmprestimo = New Label
            lblDataEmprestimo.Text = "Data Empréstimo:"
            lblDataEmprestimo.Location = New Point(590, 320)
            lblDataEmprestimo.AutoSize = True
            Me.Controls.Add(lblDataEmprestimo)

            txtDataEmprestimo = New TextBox
            txtDataEmprestimo.Location = New Point(590, 340)
            txtDataEmprestimo.Size = New Size(130, 25)
            txtDataEmprestimo.ReadOnly = True
            Me.Controls.Add(txtDataEmprestimo)

            Dim lblDataDevolucao = New Label
            lblDataDevolucao.Text = "Data de Devolução:"
            lblDataDevolucao.Location = New Point(730, 320)
            lblDataDevolucao.AutoSize = True
            AddHandler lblDataDevolucao.Click, AddressOf LblDataDevolucao_Click
            Me.Controls.Add(lblDataDevolucao)

            txtDataDevolucao = New TextBox
            txtDataDevolucao.Location = New Point(730, 340)
            txtDataDevolucao.Size = New Size(140, 25)
            AddHandler txtDataDevolucao.Click, AddressOf TxtDataDevolucao_Click
            Me.Controls.Add(txtDataDevolucao)

            btnAdicionar = New Button
            btnAdicionar.Text = "Adicionar"
            btnAdicionar.Location = New Point(10, 390)
            btnAdicionar.Size = New Size(100, 30)
            AddHandler btnAdicionar.Click, AddressOf BtnAdicionar_Click
            Me.Controls.Add(btnAdicionar)

            btnAtualizar = New Button
            btnAtualizar.Text = "Atualizar"
            btnAtualizar.Location = New Point(120, 390)
            btnAtualizar.Size = New Size(100, 30)
            AddHandler btnAtualizar.Click, AddressOf BtnAtualizar_Click
            Me.Controls.Add(btnAtualizar)

            btnDeletar = New Button
            btnDeletar.Text = "Deletar"
            btnDeletar.Location = New Point(230, 390)
            btnDeletar.Size = New Size(100, 30)
            AddHandler btnDeletar.Click, AddressOf BtnDeletar_Click
            Me.Controls.Add(btnDeletar)

            btnLimpar = New Button
            btnLimpar.Text = "Limpar"
            btnLimpar.Location = New Point(340, 390)
            btnLimpar.Size = New Size(100, 30)
            AddHandler btnLimpar.Click, AddressOf BtnLimpar_Click
            Me.Controls.Add(btnLimpar)
        End Sub

        Private Sub CarregarDados()
            CarregarEmprestimos()
            CarregarLivrosDisponiveis()
            CarregarUtilizadores()
            txtDataEmprestimo.Text = DateTime.Today.ToString("yyyy-MM-dd")
        End Sub

        Private Sub CarregarEmprestimos()
            Try
                Dim dt As DataTable = EmprestimoDAL.ListarTodos()
                dgvEmprestimos.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar empréstimos: " & ex.Message)
            End Try
        End Sub

        Private Sub CarregarLivrosDisponiveis()
            Try
                Dim dt As DataTable = LivroDAL.ListarTodos()

                Dim dv As New DataView(dt)
                dv.RowFilter = "Estado = 'Disponível'"

                cmbLivro.DataSource = dv
                cmbLivro.DisplayMember = "Titulo"
                cmbLivro.ValueMember = "ID"

                cmbLivro.Tag = Nothing
                AtualizarDisplayLivroSelecionado()
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar livros disponíveis: " & ex.Message)
            End Try
        End Sub

        Private Sub CarregarUtilizadores()
            Try
                Dim dt As DataTable = UtilizadorDAL.ListarTodos()
                cmbUtilizador.DataSource = dt
                cmbUtilizador.DisplayMember = "Nome"
                cmbUtilizador.ValueMember = "ID"

                cmbUtilizador.Tag = Nothing
            Catch ex As Exception
                MessageBox.Show("Erro ao carregar utilizadores: " & ex.Message)
            End Try
        End Sub

        Private Sub AtualizarDisplayLivroSelecionado()
            If cmbLivro.SelectedItem Is Nothing Then
                Return
            End If

            Dim drv = TryCast(cmbLivro.SelectedItem, DataRowView)
            If drv Is Nothing Then
                Return
            End If

            Dim titulo As String = drv.Row("Titulo").ToString()
            Dim autor As String = drv.Row("Autor").ToString()
            cmbLivro.Text = titulo & " - " & autor
        End Sub

        Private Sub CmbLivro_SelectedIndexChanged(sender As Object, e As EventArgs)
            If cmbLivro.SelectedValue Is Nothing Then
                cmbLivro.Tag = Nothing
                Return
            End If

            cmbLivro.Tag = Convert.ToInt32(cmbLivro.SelectedValue)
            AtualizarDisplayLivroSelecionado()
        End Sub

        Private Sub CmbUtilizador_SelectedIndexChanged(sender As Object, e As EventArgs)
            If cmbUtilizador.SelectedValue Is Nothing Then
                cmbUtilizador.Tag = Nothing
                Return
            End If

            cmbUtilizador.Tag = Convert.ToInt32(cmbUtilizador.SelectedValue)
        End Sub

        Private Sub DgvEmprestimos_SelectionChanged(sender As Object, e As EventArgs)
            If dgvEmprestimos.SelectedRows.Count = 0 Then
                Return
            End If

            Dim row As DataGridViewRow = dgvEmprestimos.SelectedRows(0)

            If row.Cells("ID_Livro").Value IsNot DBNull.Value Then
                Dim idLivro As Integer = Convert.ToInt32(row.Cells("ID_Livro").Value)
                If cmbLivro.DataSource IsNot Nothing Then
                    cmbLivro.SelectedValue = idLivro
                    cmbLivro.Tag = idLivro
                    AtualizarDisplayLivroSelecionado()
                End If
            End If

            If row.Cells("ID_Utilizador").Value IsNot DBNull.Value Then
                Dim idUtilizador As Integer = Convert.ToInt32(row.Cells("ID_Utilizador").Value)
                If cmbUtilizador.DataSource IsNot Nothing Then
                    cmbUtilizador.SelectedValue = idUtilizador
                    cmbUtilizador.Tag = idUtilizador
                End If
            End If

            If row.Cells("Data_Emprestimo").Value IsNot DBNull.Value Then
                txtDataEmprestimo.Text = Convert.ToDateTime(row.Cells("Data_Emprestimo").Value).ToString("yyyy-MM-dd")
            Else
                txtDataEmprestimo.Text = DateTime.Today.ToString("yyyy-MM-dd")
            End If

            If row.Cells("Data_Devolucao").Value IsNot DBNull.Value Then
                txtDataDevolucao.Text = Convert.ToDateTime(row.Cells("Data_Devolucao").Value).ToString("yyyy-MM-dd")
            Else
                txtDataDevolucao.Clear()
            End If

            txtDataEmprestimo.Tag = row.Cells("ID_Emprestimo").Value
        End Sub

        Private Sub BtnAdicionar_Click(sender As Object, e As EventArgs)
            Try
                If cmbLivro.Tag Is Nothing OrElse cmbUtilizador.Tag Is Nothing Then
                    MessageBox.Show("Selecione um livro e um utilizador!")
                    Return
                End If

                ' Verificar se o livro já está emprestado sem devolução
                If EmprestimoDAL.VerificarLivroEmprestadoSemDevolucao(CInt(cmbLivro.Tag)) Then
                    MessageBox.Show("Este livro ainda está sendo emprestado. Registre a devolução antes de fazer um novo empréstimo!")
                    Return
                End If

                Dim emprestimo As New Emprestimo
                emprestimo.IdLivro = CInt(cmbLivro.Tag)
                emprestimo.IdUtilizador = CInt(cmbUtilizador.Tag)
                emprestimo.DataEmprestimo = DateTime.Today

                If Not String.IsNullOrWhiteSpace(txtDataDevolucao.Text) Then
                    emprestimo.DataDevolucao = DateTime.Parse(txtDataDevolucao.Text)
                End If

                EmprestimoDAL.AdicionarEmprestimo(emprestimo)

                Dim livroTexto As String = If(cmbLivro.SelectedItem IsNot Nothing, cmbLivro.Text, "")
                Dim utilizadorTexto As String = If(cmbUtilizador.SelectedItem IsNot Nothing, cmbUtilizador.Text, "")
                MessageBox.Show("Empréstimo registado com sucesso!" & Environment.NewLine & "Livro: " & livroTexto & Environment.NewLine & "Utilizador: " & utilizadorTexto & Environment.NewLine & "Data: " & emprestimo.DataEmprestimo.ToString("yyyy-MM-dd"))

                CarregarDados()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao adicionar empréstimo: " & ex.Message)
            End Try
        End Sub

        Private Sub BtnAtualizar_Click(sender As Object, e As EventArgs)
            Try
                If txtDataEmprestimo.Tag Is Nothing Then
                    MessageBox.Show("Selecione um empréstimo para atualizar!")
                    Return
                End If

                If cmbLivro.Tag Is Nothing OrElse cmbUtilizador.Tag Is Nothing OrElse String.IsNullOrWhiteSpace(txtDataEmprestimo.Text) Then
                    MessageBox.Show("Selecione um livro, um utilizador e verifique a data de empréstimo!")
                    Return
                End If

                Dim emprestimo As New Emprestimo
                emprestimo.ID = CInt(txtDataEmprestimo.Tag)
                emprestimo.IdLivro = CInt(cmbLivro.Tag)
                emprestimo.IdUtilizador = CInt(cmbUtilizador.Tag)
                emprestimo.DataEmprestimo = DateTime.Parse(txtDataEmprestimo.Text)

                If Not String.IsNullOrWhiteSpace(txtDataDevolucao.Text) Then
                    emprestimo.DataDevolucao = DateTime.Parse(txtDataDevolucao.Text)
                Else
                    emprestimo.DataDevolucao = Nothing
                End If

                EmprestimoDAL.AtualizarEmprestimo(emprestimo)
                MessageBox.Show("Empréstimo atualizado com sucesso!")
                CarregarDados()
                BtnLimpar_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar empréstimo: " & ex.Message)
            End Try
        End Sub

        Private Sub BtnDeletar_Click(sender As Object, e As EventArgs)
            Try
                If txtDataEmprestimo.Tag Is Nothing Then
                    MessageBox.Show("Selecione um empréstimo para deletar!")
                    Return
                End If

                If MessageBox.Show("Deseja realmente deletar este empréstimo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim id As Integer = CInt(txtDataEmprestimo.Tag)
                    EmprestimoDAL.DeletarEmprestimo(id)
                    MessageBox.Show("Empréstimo deletado com sucesso!")
                    CarregarDados()
                    BtnLimpar_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show("Erro ao deletar empréstimo: " & ex.Message)
            End Try
        End Sub

        Private Sub BtnLimpar_Click(sender As Object, e As EventArgs)
            dgvEmprestimos.ClearSelection()

            txtDataEmprestimo.Tag = Nothing
            txtDataEmprestimo.Text = DateTime.Today.ToString("yyyy-MM-dd")

            txtDataDevolucao.Clear()

            cmbLivro.Tag = Nothing
            cmbUtilizador.Tag = Nothing

            If cmbLivro.Items.Count > 0 Then
                cmbLivro.SelectedIndex = -1
            End If

            If cmbUtilizador.Items.Count > 0 Then
                cmbUtilizador.SelectedIndex = -1
            End If
        End Sub

        Private Sub LblDataDevolucao_Click(sender As Object, e As EventArgs)
            AbrirCalendario()
        End Sub

        Private Sub TxtDataDevolucao_Click(sender As Object, e As EventArgs)
            AbrirCalendario()
        End Sub

        Private Sub AbrirCalendario()
            Try
                ' Criar o formulário de seleção de data
                Using frmCalendario As New FormSelecionarData("Selecionar Data de Devolução")
                    ' Definir a data mínima baseada na data de empréstimo
                    Dim dataMinima As DateTime = If(Not String.IsNullOrWhiteSpace(txtDataEmprestimo.Text), 
                                                   DateTime.Parse(txtDataEmprestimo.Text), 
                                                   DateTime.Today)
                    frmCalendario.DataMinima = dataMinima

                    ' Exibir o formulário como modal
                    Dim result As DialogResult = frmCalendario.ShowDialog(Me)

                    ' Se o usuário selecionou uma data, preencher o campo
                    If result = DialogResult.OK Then
                        txtDataDevolucao.Text = frmCalendario.DataSelecionada.Value.ToString("yyyy-MM-dd")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Erro ao abrir calendário: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
