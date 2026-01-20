Public Class FormMain
    Private Sub btnLivros_Click(sender As Object, e As EventArgs) Handles btnLivros.Click
        Dim frm As New FormLivros()
        frm.ShowDialog()
    End Sub

    Private Sub btnUtilizadores_Click(sender As Object, e As EventArgs) Handles btnUtilizadores.Click
        Dim frm As New FormUtilizadores()
        frm.ShowDialog()
    End Sub

    Private Sub btnEmprestimos_Click(sender As Object, e As EventArgs) Handles btnEmprestimos.Click
        Dim frm As New FormEmprestimos()
        frm.ShowDialog()
    End Sub
End Class
