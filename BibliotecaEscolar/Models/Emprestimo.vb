Namespace BibliotecaEscolar.Models
    Public Class Emprestimo
        Public Property ID As Integer
        Public Property IdLivro As Integer
        Public Property IdUtilizador As Integer
        Public Property DataEmprestimo As Date
        Public Property DataDevolucao As Date?

        Public Sub New()
            ' Construtor padrão
        End Sub

        Public Sub New(id As Integer, idLivro As Integer, idUtilizador As Integer, dataEmprestimo As Date, dataDevolucao As Date?)
            Me.ID = id
            Me.IdLivro = idLivro
            Me.IdUtilizador = idUtilizador
            Me.DataEmprestimo = dataEmprestimo
            Me.DataDevolucao = dataDevolucao
        End Sub
    End Class
End Namespace