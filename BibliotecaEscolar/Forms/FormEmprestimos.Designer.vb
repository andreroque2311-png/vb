Partial Class FormEmprestimos
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
        Me.dgvEmprestimos = New System.Windows.Forms.DataGridView()
        Me.cmbLivros = New System.Windows.Forms.ComboBox()
        Me.cmbUtilizadores = New System.Windows.Forms.ComboBox()
        Me.btnEmprestar = New System.Windows.Forms.Button()
        Me.btnDevolver = New System.Windows.Forms.Button()
        Me.lblLivro = New System.Windows.Forms.Label()
        Me.lblUtilizador = New System.Windows.Forms.Label()
        CType(Me.dgvEmprestimos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvEmprestimos
        '
        Me.dgvEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmprestimos.Location = New System.Drawing.Point(12, 120)
        Me.dgvEmprestimos.Name = "dgvEmprestimos"
        Me.dgvEmprestimos.Size = New System.Drawing.Size(560, 230)
        Me.dgvEmprestimos.TabIndex = 0
        '
        'cmbLivros
        '
        Me.cmbLivros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLivros.FormattingEnabled = True
        Me.cmbLivros.Location = New System.Drawing.Point(80, 20)
        Me.cmbLivros.Name = "cmbLivros"
        Me.cmbLivros.Size = New System.Drawing.Size(200, 21)
        Me.cmbLivros.TabIndex = 1
        '
        'cmbUtilizadores
        '
        Me.cmbUtilizadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUtilizadores.FormattingEnabled = True
        Me.cmbUtilizadores.Location = New System.Drawing.Point(80, 50)
        Me.cmbUtilizadores.Name = "cmbUtilizadores"
        Me.cmbUtilizadores.Size = New System.Drawing.Size(200, 21)
        Me.cmbUtilizadores.TabIndex = 2
        '
        'btnEmprestar
        '
        Me.btnEmprestar.Location = New System.Drawing.Point(12, 80)
        Me.btnEmprestar.Name = "btnEmprestar"
        Me.btnEmprestar.Size = New System.Drawing.Size(100, 23)
        Me.btnEmprestar.TabIndex = 3
        Me.btnEmprestar.Text = "Emprestar"
        Me.btnEmprestar.UseVisualStyleBackColor = True
        '
        'btnDevolver
        '
        Me.btnDevolver.Location = New System.Drawing.Point(118, 80)
        Me.btnDevolver.Name = "btnDevolver"
        Me.btnDevolver.Size = New System.Drawing.Size(100, 23)
        Me.btnDevolver.TabIndex = 4
        Me.btnDevolver.Text = "Devolver"
        Me.btnDevolver.UseVisualStyleBackColor = True
        '
        'lblLivro
        '
        Me.lblLivro.AutoSize = True
        Me.lblLivro.Location = New System.Drawing.Point(12, 23)
        Me.lblLivro.Name = "lblLivro"
        Me.lblLivro.Size = New System.Drawing.Size(33, 13)
        Me.lblLivro.TabIndex = 5
        Me.lblLivro.Text = "Livro:"
        '
        'lblUtilizador
        '
        Me.lblUtilizador.AutoSize = True
        Me.lblUtilizador.Location = New System.Drawing.Point(12, 53)
        Me.lblUtilizador.Name = "lblUtilizador"
        Me.lblUtilizador.Size = New System.Drawing.Size(53, 13)
        Me.lblUtilizador.TabIndex = 6
        Me.lblUtilizador.Text = "Utilizador:"
        '
        'FormEmprestimos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.lblUtilizador)
        Me.Controls.Add(Me.lblLivro)
        Me.Controls.Add(Me.btnDevolver)
        Me.Controls.Add(Me.btnEmprestar)
        Me.Controls.Add(Me.cmbUtilizadores)
        Me.Controls.Add(Me.cmbLivros)
        Me.Controls.Add(Me.dgvEmprestimos)
        Me.Name = "FormEmprestimos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestão de Empréstimos"
        CType(Me.dgvEmprestimos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvEmprestimos As System.Windows.Forms.DataGridView
    Friend WithEvents cmbLivros As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUtilizadores As System.Windows.Forms.ComboBox
    Friend WithEvents btnEmprestar As System.Windows.Forms.Button
    Friend WithEvents btnDevolver As System.Windows.Forms.Button
    Friend WithEvents lblLivro As System.Windows.Forms.Label
    Friend WithEvents lblUtilizador As System.Windows.Forms.Label
End Class
