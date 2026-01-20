Public Class Utilizador
    Public Property ID As Integer
    Public Property Nome As String
    Public Property Email As String
    Public Property Telefone As String
    Public Property DataRegistro As Date

    Public Sub New()
        ' Construtor padrão
    End Sub

    Public Sub New(id As Integer, nome As String, email As String, telefone As String, dataRegistro As Date)
        Me.ID = id
        Me.Nome = nome
        Me.Email = email
        Me.Telefone = telefone
        Me.DataRegistro = dataRegistro
    End Sub
End Class