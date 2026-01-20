<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUtilizadores
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
        Me.DataGridViewUtilizadores = New System.Windows.Forms.DataGridView()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.LabelID = New System.Windows.Forms.Label()
        Me.TextBoxID = New System.Windows.Forms.TextBox()
        Me.LabelNome = New System.Windows.Forms.Label()
        Me.TextBoxNome = New System.Windows.Forms.TextBox()
        Me.LabelTurma = New System.Windows.Forms.Label()
        Me.TextBoxTurma = New System.Windows.Forms.TextBox()
        Me.LabelContacto = New System.Windows.Forms.Label()
        Me.TextBoxContacto = New System.Windows.Forms.TextBox()
        Me.ButtonInserir = New System.Windows.Forms.Button()
        Me.ButtonEditar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonLimpar = New System.Windows.Forms.Button()
        Me.ButtonVoltar = New System.Windows.Forms.Button()
        CType(Me.DataGridViewUtilizadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' DataGridViewUtilizadores
        '
        Me.DataGridViewUtilizadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewUtilizadores.Location = New System.Drawing.Point(12, 200)
        Me.DataGridViewUtilizadores.Name = "DataGridViewUtilizadores"
        Me.DataGridViewUtilizadores.Size = New System.Drawing.Size(760, 200)
        Me.DataGridViewUtilizadores.TabIndex = 0
        '
        ' LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(200, 24)
        Me.LabelTitulo.TabIndex = 1
        Me.LabelTitulo.Text = "Gestão de Utilizadores"
        '
        ' LabelID
        '
        Me.LabelID.AutoSize = True
        Me.LabelID.Location = New System.Drawing.Point(12, 50)
        Me.LabelID.Name = "LabelID"
        Me.LabelID.Size = New System.Drawing.Size(21, 13)
        Me.LabelID.TabIndex = 2
        Me.LabelID.Text = "ID:"
        '
        ' TextBoxID
        '
        Me.TextBoxID.Enabled = False
        Me.TextBoxID.Location = New System.Drawing.Point(100, 50)
        Me.TextBoxID.Name = "TextBoxID"
        Me.TextBoxID.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxID.TabIndex = 3
        '
        ' LabelNome
        '
        Me.LabelNome.AutoSize = True
        Me.LabelNome.Location = New System.Drawing.Point(12, 80)
        Me.LabelNome.Name = "LabelNome"
        Me.LabelNome.Size = New System.Drawing.Size(38, 13)
        Me.LabelNome.TabIndex = 4
        Me.LabelNome.Text = "Nome:"
        '
        ' TextBoxNome
        '
        Me.TextBoxNome.Location = New System.Drawing.Point(100, 80)
        Me.TextBoxNome.Name = "TextBoxNome"
        Me.TextBoxNome.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxNome.TabIndex = 5
        '
        ' LabelTurma
        '
        Me.LabelTurma.AutoSize = True
        Me.LabelTurma.Location = New System.Drawing.Point(12, 110)
        Me.LabelTurma.Name = "LabelTurma"
        Me.LabelTurma.Size = New System.Drawing.Size(40, 13)
        Me.LabelTurma.TabIndex = 6
        Me.LabelTurma.Text = "Turma:"
        '
        ' TextBoxTurma
        '
        Me.TextBoxTurma.Location = New System.Drawing.Point(100, 110)
        Me.TextBoxTurma.Name = "TextBoxTurma"
        Me.TextBoxTurma.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxTurma.TabIndex = 7
        '
        ' LabelContacto
        '
        Me.LabelContacto.AutoSize = True
        Me.LabelContacto.Location = New System.Drawing.Point(12, 140)
        Me.LabelContacto.Name = "LabelContacto"
        Me.LabelContacto.Size = New System.Drawing.Size(53, 13)
        Me.LabelContacto.TabIndex = 8
        Me.LabelContacto.Text = "Contacto:"
        '
        ' TextBoxContacto
        '
        Me.TextBoxContacto.Location = New System.Drawing.Point(100, 140)
        Me.TextBoxContacto.Name = "TextBoxContacto"
        Me.TextBoxContacto.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxContacto.TabIndex = 9
        '
        ' ButtonInserir
        '
        Me.ButtonInserir.Location = New System.Drawing.Point(350, 50)
        Me.ButtonInserir.Name = "ButtonInserir"
        Me.ButtonInserir.Size = New System.Drawing.Size(100, 30)
        Me.ButtonInserir.TabIndex = 10
        Me.ButtonInserir.Text = "Inserir"
        Me.ButtonInserir.UseVisualStyleBackColor = True
        '
        ' ButtonEditar
        '
        Me.ButtonEditar.Location = New System.Drawing.Point(350, 90)
        Me.ButtonEditar.Name = "ButtonEditar"
        Me.ButtonEditar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonEditar.TabIndex = 11
        Me.ButtonEditar.Text = "Editar"
        Me.ButtonEditar.UseVisualStyleBackColor = True
        '
        ' ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(350, 130)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonEliminar.TabIndex = 12
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        ' ButtonLimpar
        '
        Me.ButtonLimpar.Location = New System.Drawing.Point(500, 50)
        Me.ButtonLimpar.Name = "ButtonLimpar"
        Me.ButtonLimpar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonLimpar.TabIndex = 13
        Me.ButtonLimpar.Text = "Limpar"
        Me.ButtonLimpar.UseVisualStyleBackColor = True
        '
        ' ButtonVoltar
        '
        Me.ButtonVoltar.Location = New System.Drawing.Point(500, 90)
        Me.ButtonVoltar.Name = "ButtonVoltar"
        Me.ButtonVoltar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonVoltar.TabIndex = 14
        Me.ButtonVoltar.Text = "Voltar"
        Me.ButtonVoltar.UseVisualStyleBackColor = True
        '
        ' FormUtilizadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ButtonVoltar)
        Me.Controls.Add(Me.ButtonLimpar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonEditar)
        Me.Controls.Add(Me.ButtonInserir)
        Me.Controls.Add(Me.TextBoxContacto)
        Me.Controls.Add(Me.LabelContacto)
        Me.Controls.Add(Me.TextBoxTurma)
        Me.Controls.Add(Me.LabelTurma)
        Me.Controls.Add(Me.TextBoxNome)
        Me.Controls.Add(Me.LabelNome)
        Me.Controls.Add(Me.TextBoxID)
        Me.Controls.Add(Me.LabelID)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.DataGridViewUtilizadores)
        Me.Name = "FormUtilizadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestão de Utilizadores"
        CType(Me.DataGridViewUtilizadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewUtilizadores As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents LabelID As System.Windows.Forms.Label
    Friend WithEvents TextBoxID As System.Windows.Forms.TextBox
    Friend WithEvents LabelNome As System.Windows.Forms.Label
    Friend WithEvents TextBoxNome As System.Windows.Forms.TextBox
    Friend WithEvents LabelTurma As System.Windows.Forms.Label
    Friend WithEvents TextBoxTurma As System.Windows.Forms.TextBox
    Friend WithEvents LabelContacto As System.Windows.Forms.Label
    Friend WithEvents TextBoxContacto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonInserir As System.Windows.Forms.Button
    Friend WithEvents ButtonEditar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonLimpar As System.Windows.Forms.Button
    Friend WithEvents ButtonVoltar As System.Windows.Forms.Button
End Class