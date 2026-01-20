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
        Me.btnLivros = New System.Windows.Forms.Button()
        Me.btnUtilizadores = New System.Windows.Forms.Button()
        Me.btnEmprestimos = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnLivros
        '
        Me.btnLivros.Location = New System.Drawing.Point(50, 80)
        Me.btnLivros.Name = "btnLivros"
        Me.btnLivros.Size = New System.Drawing.Size(200, 40)
        Me.btnLivros.TabIndex = 0
        Me.btnLivros.Text = "Gestão de Livros"
        Me.btnLivros.UseVisualStyleBackColor = True
        '
        'btnUtilizadores
        '
        Me.btnUtilizadores.Location = New System.Drawing.Point(50, 140)
        Me.btnUtilizadores.Name = "btnUtilizadores"
        Me.btnUtilizadores.Size = New System.Drawing.Size(200, 40)
        Me.btnUtilizadores.TabIndex = 1
        Me.btnUtilizadores.Text = "Gestão de Utilizadores"
        Me.btnUtilizadores.UseVisualStyleBackColor = True
        '
        'btnEmprestimos
        '
        Me.btnEmprestimos.Location = New System.Drawing.Point(50, 200)
        Me.btnEmprestimos.Name = "btnEmprestimos"
        Me.btnEmprestimos.Size = New System.Drawing.Size(200, 40)
        Me.btnEmprestimos.TabIndex = 2
        Me.btnEmprestimos.Text = "Gestão de Empréstimos"
        Me.btnEmprestimos.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(45, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(212, 26)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Biblioteca Escolar"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 300)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnEmprestimos)
        Me.Controls.Add(Me.btnUtilizadores)
        Me.Controls.Add(Me.btnLivros)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Principal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLivros As System.Windows.Forms.Button
    Friend WithEvents btnUtilizadores As System.Windows.Forms.Button
    Friend WithEvents btnEmprestimos As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
End Class
