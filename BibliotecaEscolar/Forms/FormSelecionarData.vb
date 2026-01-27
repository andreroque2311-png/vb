Imports System.Windows.Forms
Imports System.Drawing

Namespace BibliotecaEscolar.Forms
    Public Class FormSelecionarData
        Inherits Form

        Private monthCalendar As MonthCalendar
        Private btnOk As Button
        Private btnCancelar As Button
        Private lblTitulo As Label

        Public Property DataSelecionada As DateTime?
            Get
                Return monthCalendar.SelectionStart
            End Get
            Private Set(value As DateTime?)
                ' Property apenas para leitura
            End Set
        End Property

        Public Property DataMinima As DateTime?
            Get
                Return monthCalendar.MinDate
            End Get
            Set(value As DateTime?)
                If value.HasValue Then
                    monthCalendar.MinDate = value.Value
                End If
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(titulo As String)
            Me.New()
            Me.Text = titulo
            lblTitulo.Text = titulo
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "Selecionar Data"
            Me.Size = New Size(400, 350)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.DialogResult = DialogResult.Cancel

            ' Label do título
            lblTitulo = New Label
            lblTitulo.Text = "Selecionar Data"
            lblTitulo.Location = New Point(20, 10)
            lblTitulo.AutoSize = True
            lblTitulo.Font = New Font(lblTitulo.Font.FontFamily, 10, FontStyle.Bold)
            Me.Controls.Add(lblTitulo)

            ' MonthCalendar
            monthCalendar = New MonthCalendar
            monthCalendar.Location = New Point(20, 40)
            monthCalendar.Size = New Size(340, 200)
            monthCalendar.MaxSelectionCount = 1 ' Permite apenas uma seleção
            Me.Controls.Add(monthCalendar)

            ' Botão OK
            btnOk = New Button
            btnOk.Text = "OK"
            btnOk.Size = New Size(80, 30)
            btnOk.Location = New Point(200, 260)
            btnOk.DialogResult = DialogResult.OK
            AddHandler btnOk.Click, AddressOf BtnOk_Click
            Me.Controls.Add(btnOk)

            ' Botão Cancelar
            btnCancelar = New Button
            btnCancelar.Text = "Cancelar"
            btnCancelar.Size = New Size(80, 30)
            btnCancelar.Location = New Point(290, 260)
            btnCancelar.DialogResult = DialogResult.Cancel
            AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
            Me.Controls.Add(btnCancelar)

            ' Definir foco no botão OK
            Me.AcceptButton = btnOk
            Me.CancelButton = btnCancelar

            ' Setar data mínima para hoje
            monthCalendar.MinDate = DateTime.Today
        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Public Function ShowDialog(parentForm As Form) As DialogResult
            Return Me.ShowDialog(parentForm)
        End Function

        Public Function ShowDialog() As DialogResult
            Return MyBase.ShowDialog()
        End Function
    End Class
End Namespace