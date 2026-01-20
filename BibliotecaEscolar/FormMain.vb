Imports System.Windows.Forms

Namespace BibliotecaEscolar
    Public Class FormMain
        Private Sub ButtonUtilizadores_Click(sender As Object, e As EventArgs) Handles ButtonUtilizadores.Click
            Dim formUtilizadores As New FormUtilizadores()
            formUtilizadores.Show()
            Me.Hide()
        End Sub

        Private Sub ButtonLivros_Click(sender As Object, e As EventArgs) Handles ButtonLivros.Click
            Dim formLivros As New FormLivros()
            formLivros.Show()
            Me.Hide()
        End Sub

        Private Sub ButtonEmprestimos_Click(sender As Object, e As EventArgs) Handles ButtonEmprestimos.Click
            Dim formEmprestimos As New FormEmprestimos()
            formEmprestimos.Show()
            Me.Hide()
        End Sub

        Private Sub ButtonSair_Click(sender As Object, e As EventArgs) Handles ButtonSair.Click
            Application.Exit()
        End Sub
    End Class
End Namespace