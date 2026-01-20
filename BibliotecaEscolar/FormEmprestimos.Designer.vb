<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.DataGridViewEmprestimos = New System.Windows.Forms.DataGridView()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.LabelLivro = New System.Windows.Forms.Label()
        Me.ComboBoxLivro = New System.Windows.Forms.ComboBox()
        Me.LabelUtilizador = New System.Windows.Forms.Label()
        Me.ComboBoxUtilizador = New System.Windows.Forms.ComboBox()
        Me.LabelDataEmprestimo = New System.Windows.Forms.Label()
        Me.DateTimePickerEmprestimo = New System.Windows.Forms.DateTimePicker()
        Me.LabelDataDevolucao = New System.Windows.Forms.Label()
        Me.DateTimePickerDevolucao = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxDevolvido = New System.Windows.Forms.CheckBox()
        Me.ButtonRegistrarEmprestimo = New System.Windows.Forms.Button()
        Me.ButtonRegistrarDevolucao = New System.Windows.Forms.Button()
        Me.ButtonLimpar = New System.Windows.Forms.Button()
        Me.ButtonVoltar = New System.Windows.Forms.Button()
        CType(Me.DataGridViewEmprestimos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' DataGridViewEmprestimos
        '
        Me.DataGridViewEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEmprestimos.Location = New System.Drawing.Point(12, 250)
        Me.DataGridViewEmprestimos.Name = "DataGridViewEmprestimos"
        Me.DataGridViewEmprestimos.Size = New System.Drawing.Size(760, 150)
        Me.DataGridViewEmprestimos.TabIndex = 0
        '
        ' LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(200, 24)
        Me.LabelTitulo.TabIndex = 1
        Me.LabelTitulo.Text = "Gestão de Empréstimos"
        '
        ' LabelLivro
        '
        Me.LabelLivro.AutoSize = True
        Me.LabelLivro.Location = New System.Drawing.Point(12, 50)
        Me.LabelLivro.Name = "LabelLivro"
        Me.LabelLivro.Size = New System.Drawing.Size(34, 13)
        Me.LabelLivro.TabIndex = 2
        Me.LabelLivro.Text = "Livro:"
        '
        ' ComboBoxLivro
        '
        Me.ComboBoxLivro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLivro.FormattingEnabled = True
        Me.ComboBoxLivro.Location = New System.Drawing.Point(100, 50)
        Me.ComboBoxLivro.Name = "ComboBoxLivro"
        Me.ComboBoxLivro.Size = New System.Drawing.Size(300, 21)
        Me.ComboBoxLivro.TabIndex = 3
        '
        ' LabelUtilizador
        '
        Me.LabelUtilizador.AutoSize = True
        Me.LabelUtilizador.Location = New System.Drawing.Point(12, 80)
        Me.LabelUtilizador.Name = "LabelUtilizador"
        Me.LabelUtilizador.Size = New System.Drawing.Size(61, 13)
        Me.LabelUtilizador.TabIndex = 4
        Me.LabelUtilizador.Text = "Utilizador:"
        '
        ' ComboBoxUtilizador
        '
        Me.ComboBoxUtilizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUtilizador.FormattingEnabled = True
        Me.ComboBoxUtilizador.Location = New System.Drawing.Point(100, 80)
        Me.ComboBoxUtilizador.Name = "ComboBoxUtilizador"
        Me.ComboBoxUtilizador.Size = New System.Drawing.Size(300, 21)
        Me.ComboBoxUtilizador.TabIndex = 5
        '
        ' LabelDataEmprestimo
        '
        Me.LabelDataEmprestimo.AutoSize = True
        Me.LabelDataEmprestimo.Location = New System.Drawing.Point(12, 110)
        Me.LabelDataEmprestimo.Name = "LabelDataEmprestimo"
        Me.LabelDataEmprestimo.Size = New System.Drawing.Size(92, 13)
        Me.LabelDataEmprestimo.TabIndex = 6
        Me.LabelDataEmprestimo.Text = "Data de Empréstimo:"
        '
        ' DateTimePickerEmprestimo
        '
        Me.DateTimePickerEmprestimo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerEmprestimo.Location = New System.Drawing.Point(100, 110)
        Me.DateTimePickerEmprestimo.Name = "DateTimePickerEmprestimo"
        Me.DateTimePickerEmprestimo.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerEmprestimo.TabIndex = 7
        '
        ' LabelDataDevolucao
        '
        Me.LabelDataDevolucao.AutoSize = True
        Me.LabelDataDevolucao.Location = New System.Drawing.Point(12, 140)
        Me.LabelDataDevolucao.Name = "LabelDataDevolucao"
        Me.LabelDataDevolucao.Size = New System.Drawing.Size(86, 13)
        Me.LabelDataDevolucao.TabIndex = 8
        Me.LabelDataDevolucao.Text = "Data de Devolução:"
        '
        ' DateTimePickerDevolucao
        '
        Me.DateTimePickerDevolucao.Enabled = False
        Me.DateTimePickerDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDevolucao.Location = New System.Drawing.Point(100, 140)
        Me.DateTimePickerDevolucao.Name = "DateTimePickerDevolucao"
        Me.DateTimePickerDevolucao.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePickerDevolucao.TabIndex = 9
        '
        ' CheckBoxDevolvido
        '
        Me.CheckBoxDevolvido.AutoSize = True
        Me.CheckBoxDevolvido.Location = New System.Drawing.Point(350, 140)
        Me.CheckBoxDevolvido.Name = "CheckBoxDevolvido"
        Me.CheckBoxDevolvido.Size = New System.Drawing.Size(150, 17)
        Me.CheckBoxDevolvido.TabIndex = 10
        Me.CheckBoxDevolvido.Text = "Marcar como devolvido agora"
        Me.CheckBoxDevolvido.UseVisualStyleBackColor = True
        '
        ' ButtonRegistrarEmprestimo
        '
        Me.ButtonRegistrarEmprestimo.Location = New System.Drawing.Point(50, 200)
        Me.ButtonRegistrarEmprestimo.Name = "ButtonRegistrarEmprestimo"
        Me.ButtonRegistrarEmprestimo.Size = New System.Drawing.Size(150, 30)
        Me.ButtonRegistrarEmprestimo.TabIndex = 11
        Me.ButtonRegistrarEmprestimo.Text = "Registrar Empréstimo"
        Me.ButtonRegistrarEmprestimo.UseVisualStyleBackColor = True
        '
        ' ButtonRegistrarDevolucao
        '
        Me.ButtonRegistrarDevolucao.Location = New System.Drawing.Point(250, 200)
        Me.ButtonRegistrarDevolucao.Name = "ButtonRegistrarDevolucao"
        Me.ButtonRegistrarDevolucao.Size = New System.Drawing.Size(150, 30)
        Me.ButtonRegistrarDevolucao.TabIndex = 12
        Me.ButtonRegistrarDevolucao.Text = "Registrar Devolução"
        Me.ButtonRegistrarDevolucao.UseVisualStyleBackColor = True
        '
        ' ButtonLimpar
        '
        Me.ButtonLimpar.Location = New System.Drawing.Point(450, 50)
        Me.ButtonLimpar.Name = "ButtonLimpar"
        Me.ButtonLimpar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonLimpar.TabIndex = 13
        Me.ButtonLimpar.Text = "Limpar"
        Me.ButtonLimpar.UseVisualStyleBackColor = True
        '
        ' ButtonVoltar
        '
        Me.ButtonVoltar.Location = New System.Drawing.Point(450, 100)
        Me.ButtonVoltar.Name = "ButtonVoltar"
        Me.ButtonVoltar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonVoltar.TabIndex = 14
        Me.ButtonVoltar.Text = "Voltar"
        Me.ButtonVoltar.UseVisualStyleBackColor = True
        '
        ' FormEmprestimos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ButtonVoltar)
        Me.Controls.Add(Me.ButtonLimpar)
        Me.Controls.Add(Me.ButtonRegistrarDevolucao)
        Me.Controls.Add(Me.ButtonRegistrarEmprestimo)
        Me.Controls.Add(Me.CheckBoxDevolvido)
        Me.Controls.Add(Me.DateTimePickerDevolucao)
        Me.Controls.Add(Me.LabelDataDevolucao)
        Me.Controls.Add(Me.DateTimePickerEmprestimo)
        Me.Controls.Add(Me.LabelDataEmprestimo)
        Me.Controls.Add(Me.ComboBoxUtilizador)
        Me.Controls.Add(Me.LabelUtilizador)
        Me.Controls.Add(Me.ComboBoxLivro)
        Me.Controls.Add(Me.LabelLivro)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.DataGridViewEmprestimos)
        Me.Name = "FormEmprestimos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestão de Empréstimos"
        CType(Me.DataGridViewEmprestimos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewEmprestimos As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents LabelLivro As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLivro As System.Windows.Forms.ComboBox
    Friend WithEvents LabelUtilizador As System.Windows.Forms.Label
    Friend WithEvents ComboBoxUtilizador As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDataEmprestimo As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEmprestimo As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelDataDevolucao As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerDevolucao As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxDevolvido As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonRegistrarEmprestimo As System.Windows.Forms.Button
    Friend WithEvents ButtonRegistrarDevolucao As System.Windows.Forms.Button
    Friend WithEvents ButtonLimpar As System.Windows.Forms.Button
    Friend WithEvents ButtonVoltar As System.Windows.Forms.Button
End Class