Imports System.Windows.Forms
Imports System.Drawing
Imports BibliotecaEscolar.Forms

Namespace BibliotecaEscolar.Forms
    Public Class FormMain
        Inherits Form
        
        Private btnLivros As Button
        Private btnUtilizadores As Button
        Private btnEmprestimos As Button
        Private btnSair As Button
        
        Public Sub New()
            Me.Text = "BibliotecaEscolar - Menu Principal"
            Me.Size = New Size(400, 300)
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            
            ' Botões
            btnLivros = New Button
            btnLivros.Text = "Gestão de Livros"
            btnLivros.Location = New Point(50, 50)
            btnLivros.Size = New Size(300, 40)
            AddHandler btnLivros.Click, AddressOf BtnLivros_Click
            Me.Controls.Add(btnLivros)
            
            btnUtilizadores = New Button
            btnUtilizadores.Text = "Gestão de Utilizadores"
            btnUtilizadores.Location = New Point(50, 100)
            btnUtilizadores.Size = New Size(300, 40)
            AddHandler btnUtilizadores.Click, AddressOf BtnUtilizadores_Click
            Me.Controls.Add(btnUtilizadores)
            
            btnEmprestimos = New Button
            btnEmprestimos.Text = "Gestão de Empréstimos"
            btnEmprestimos.Location = New Point(50, 150)
            btnEmprestimos.Size = New Size(300, 40)
            AddHandler btnEmprestimos.Click, AddressOf BtnEmprestimos_Click
            Me.Controls.Add(btnEmprestimos)
            
            btnSair = New Button
            btnSair.Text = "Sair"
            btnSair.Location = New Point(50, 200)
            btnSair.Size = New Size(300, 40)
            AddHandler btnSair.Click, AddressOf BtnSair_Click
            Me.Controls.Add(btnSair)
        End Sub
        
        Private Sub BtnLivros_Click(sender As Object, e As EventArgs)
            Dim form = New FormLivros
            form.ShowDialog()
        End Sub
        
        Private Sub BtnUtilizadores_Click(sender As Object, e As EventArgs)
            Dim form = New FormUtilizadores
            form.ShowDialog()
        End Sub
        
        Private Sub BtnEmprestimos_Click(sender As Object, e As EventArgs)
            Dim form = New FormEmprestimos
            form.ShowDialog()
        End Sub
        
        Private Sub BtnSair_Click(sender As Object, e As EventArgs)
            Me.Close()
        End Sub
    End Class
End Namespace
