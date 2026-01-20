Public Class Emprestimo
    Public Property ID As Integer
    Public Property IdLivro As Integer
    Public Property IdUtilizador As Integer
    Public Property DataEmprestimo As DateTime
    Public Property DataDevolucao As DateTime?

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, idLivro As Integer, idUtilizador As Integer, dataEmprestimo As DateTime, Optional dataDevolucao As DateTime? = Nothing)
        Me.ID = id
        Me.IdLivro = idLivro
        Me.IdUtilizador = idUtilizador
        Me.DataEmprestimo = dataEmprestimo
        Me.DataDevolucao = dataDevolucao
    End Sub
End Class
