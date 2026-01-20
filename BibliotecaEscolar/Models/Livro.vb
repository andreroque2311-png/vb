Public Class Livro
    Public Property ID As Integer
    Public Property Titulo As String
    Public Property Autor As String
    Public Property ISBN As String
    Public Property DataPublicacao As Date
    Public Property Disponivel As Boolean

    Public Sub New()
        ' Construtor padrão
    End Sub

    Public Sub New(id As Integer, titulo As String, autor As String, isbn As String, dataPublicacao As Date, disponivel As Boolean)
        Me.ID = id
        Me.Titulo = titulo
        Me.Autor = autor
        Me.ISBN = isbn
        Me.DataPublicacao = dataPublicacao
        Me.Disponivel = disponivel
    End Sub
End Class