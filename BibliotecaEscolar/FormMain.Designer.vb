<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonUtilizadores = New System.Windows.Forms.Button()
        Me.ButtonLivros = New System.Windows.Forms.Button()
        Me.ButtonEmprestimos = New System.Windows.Forms.Button()
        Me.ButtonSair = New System.Windows.Forms.Button()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' ButtonUtilizadores
        '
        Me.ButtonUtilizadores.Location = New System.Drawing.Point(50, 50)
        Me.ButtonUtilizadores.Name = "ButtonUtilizadores"
        Me.ButtonUtilizadores.Size = New System.Drawing.Size(200, 50)
        Me.ButtonUtilizadores.TabIndex = 0
        Me.ButtonUtilizadores.Text = "Gerir Utilizadores"
        Me.ButtonUtilizadores.UseVisualStyleBackColor = True
        '
        ' ButtonLivros
        '
        Me.ButtonLivros.Location = New System.Drawing.Point(50, 120)
        Me.ButtonLivros.Name = "ButtonLivros"
        Me.ButtonLivros.Size = New System.Drawing.Size(200, 50)
        Me.ButtonLivros.TabIndex = 1
        Me.ButtonLivros.Text = "Gerir Livros"
        Me.ButtonLivros.UseVisualStyleBackColor = True
        '
        ' ButtonEmprestimos
        '
        Me.ButtonEmprestimos.Location = New System.Drawing.Point(50, 190)
        Me.ButtonEmprestimos.Name = "ButtonEmprestimos"
        Me.ButtonEmprestimos.Size = New System.Drawing.Size(200, 50)
        Me.ButtonEmprestimos.TabIndex = 2
        Me.ButtonEmprestimos.Text = "Gerir Empréstimos"
        Me.ButtonEmprestimos.UseVisualStyleBackColor = True
        '
        ' ButtonSair
        '
        Me.ButtonSair.Location = New System.Drawing.Point(50, 260)
        Me.ButtonSair.Name = "ButtonSair"
        Me.ButtonSair.Size = New System.Drawing.Size(200, 50)
        Me.ButtonSair.TabIndex = 3
        Me.ButtonSair.Text = "Sair"
        Me.ButtonSair.UseVisualStyleBackColor = True
        '
        ' LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(50, 10)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(300, 26)
        Me.LabelTitulo.TabIndex = 4
        Me.LabelTitulo.Text = "Sistema de Gestão de Biblioteca"
        '
        ' FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 350)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.ButtonSair)
        Me.Controls.Add(Me.ButtonEmprestimos)
        Me.Controls.Add(Me.ButtonLivros)
        Me.Controls.Add(Me.ButtonUtilizadores)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonUtilizadores As System.Windows.Forms.Button
    Friend WithEvents ButtonLivros As System.Windows.Forms.Button
    Friend WithEvents ButtonEmprestimos As System.Windows.Forms.Button
    Friend WithEvents ButtonSair As System.Windows.Forms.Button
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
End Class