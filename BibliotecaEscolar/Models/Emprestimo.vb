Namespace BibliotecaEscolar.Models
    Public Class Emprestimo
        Public Property ID As Integer
        Public Property IdLivro As Integer
        Public Property IdUtilizador As Integer
        Public Property DataEmprestimo As DateTime
        Public Property DataDevolucao As DateTime?
    End Class
End Namespace
