Imports System.Windows.Forms
Imports System.Drawing

Namespace BibliotecaEscolar.Forms
    Public Class FormMain
    Inherits Form

    Private btnLivros As Button
    Private btnUtilizadores As Button
    Private btnEmprestimos As Button
    Private btnSair As Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.btnLivros = New Button()
        Me.btnUtilizadores = New Button()
        Me.btnEmprestimos = New Button()
        Me.btnSair = New Button()
        
        Me.SuspendLayout()
        
        ' FormMain
        Me.Text = "Biblioteca Escolar - Menu Principal"
        Me.ClientSize = New System.Drawing.Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        
        ' btnLivros
        Me.btnLivros.Location = New System.Drawing.Point(50, 50)
        Me.btnLivros.Size = New System.Drawing.Size(300, 40)
        Me.btnLivros.Text = "Gestão de Livros"
        Me.btnLivros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
        AddHandler Me.btnLivros.Click, AddressOf Me.BtnLivros_Click
        
        ' btnUtilizadores
        Me.btnUtilizadores.Location = New System.Drawing.Point(50, 110)
        Me.btnUtilizadores.Size = New System.Drawing.Size(300, 40)
        Me.btnUtilizadores.Text = "Gestão de Utilizadores"
        Me.btnUtilizadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
        AddHandler Me.btnUtilizadores.Click, AddressOf Me.BtnUtilizadores_Click
        
        ' btnEmprestimos
        Me.btnEmprestimos.Location = New System.Drawing.Point(50, 170)
        Me.btnEmprestimos.Size = New System.Drawing.Size(300, 40)
        Me.btnEmprestimos.Text = "Gestão de Empréstimos"
        Me.btnEmprestimos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
        AddHandler Me.btnEmprestimos.Click, AddressOf Me.BtnEmprestimos_Click
        
        ' btnSair
        Me.btnSair.Location = New System.Drawing.Point(50, 230)
        Me.btnSair.Size = New System.Drawing.Size(300, 40)
        Me.btnSair.Text = "Sair"
        Me.btnSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Regular)
        AddHandler Me.btnSair.Click, AddressOf Me.BtnSair_Click
        
        ' Adicionar controles ao form
        Me.Controls.Add(Me.btnLivros)
        Me.Controls.Add(Me.btnUtilizadores)
        Me.Controls.Add(Me.btnEmprestimos)
        Me.Controls.Add(Me.btnSair)
        
        Me.ResumeLayout(False)
    End Sub

    Private Sub BtnLivros_Click(sender As Object, e As EventArgs)
        Dim formLivros As New FormLivros()
        formLivros.ShowDialog()
    End Sub

    Private Sub BtnUtilizadores_Click(sender As Object, e As EventArgs)
        Dim formUtilizadores As New FormUtilizadores()
        formUtilizadores.ShowDialog()
    End Sub

    Private Sub BtnEmprestimos_Click(sender As Object, e As EventArgs)
        Dim formEmprestimos As New FormEmprestimos()
        formEmprestimos.ShowDialog()
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub
End Class
End Namespace