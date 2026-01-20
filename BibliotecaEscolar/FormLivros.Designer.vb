<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLivros
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
        Me.DataGridViewLivros = New System.Windows.Forms.DataGridView()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.LabelID = New System.Windows.Forms.Label()
        Me.TextBoxID = New System.Windows.Forms.TextBox()
        Me.LabelTituloLivro = New System.Windows.Forms.Label()
        Me.TextBoxTitulo = New System.Windows.Forms.TextBox()
        Me.LabelAutor = New System.Windows.Forms.Label()
        Me.TextBoxAutor = New System.Windows.Forms.TextBox()
        Me.LabelAno = New System.Windows.Forms.Label()
        Me.TextBoxAno = New System.Windows.Forms.TextBox()
        Me.LabelEstado = New System.Windows.Forms.Label()
        Me.ComboBoxEstado = New System.Windows.Forms.ComboBox()
        Me.ButtonInserir = New System.Windows.Forms.Button()
        Me.ButtonEditar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ButtonLimpar = New System.Windows.Forms.Button()
        Me.ButtonVoltar = New System.Windows.Forms.Button()
        Me.TextBoxPesquisa = New System.Windows.Forms.TextBox()
        Me.ButtonPesquisar = New System.Windows.Forms.Button()
        CType(Me.DataGridViewLivros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' DataGridViewLivros
        '
        Me.DataGridViewLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewLivros.Location = New System.Drawing.Point(12, 250)
        Me.DataGridViewLivros.Name = "DataGridViewLivros"
        Me.DataGridViewLivros.Size = New System.Drawing.Size(760, 150)
        Me.DataGridViewLivros.TabIndex = 0
        '
        ' LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(12, 9)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(150, 24)
        Me.LabelTitulo.TabIndex = 1
        Me.LabelTitulo.Text = "Gestão de Livros"
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
        ' LabelTituloLivro
        '
        Me.LabelTituloLivro.AutoSize = True
        Me.LabelTituloLivro.Location = New System.Drawing.Point(12, 80)
        Me.LabelTituloLivro.Name = "LabelTituloLivro"
        Me.LabelTituloLivro.Size = New System.Drawing.Size(36, 13)
        Me.LabelTituloLivro.TabIndex = 4
        Me.LabelTituloLivro.Text = "Título:"
        '
        ' TextBoxTitulo
        '
        Me.TextBoxTitulo.Location = New System.Drawing.Point(100, 80)
        Me.TextBoxTitulo.Name = "TextBoxTitulo"
        Me.TextBoxTitulo.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxTitulo.TabIndex = 5
        '
        ' LabelAutor
        '
        Me.LabelAutor.AutoSize = True
        Me.LabelAutor.Location = New System.Drawing.Point(12, 110)
        Me.LabelAutor.Name = "LabelAutor"
        Me.LabelAutor.Size = New System.Drawing.Size(35, 13)
        Me.LabelAutor.TabIndex = 6
        Me.LabelAutor.Text = "Autor:"
        '
        ' TextBoxAutor
        '
        Me.TextBoxAutor.Location = New System.Drawing.Point(100, 110)
        Me.TextBoxAutor.Name = "TextBoxAutor"
        Me.TextBoxAutor.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxAutor.TabIndex = 7
        '
        ' LabelAno
        '
        Me.LabelAno.AutoSize = True
        Me.LabelAno.Location = New System.Drawing.Point(12, 140)
        Me.LabelAno.Name = "LabelAno"
        Me.LabelAno.Size = New System.Drawing.Size(29, 13)
        Me.LabelAno.TabIndex = 8
        Me.LabelAno.Text = "Ano:"
        '
        ' TextBoxAno
        '
        Me.TextBoxAno.Location = New System.Drawing.Point(100, 140)
        Me.TextBoxAno.Name = "TextBoxAno"
        Me.TextBoxAno.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxAno.TabIndex = 9
        '
        ' LabelEstado
        '
        Me.LabelEstado.AutoSize = True
        Me.LabelEstado.Location = New System.Drawing.Point(12, 170)
        Me.LabelEstado.Name = "LabelEstado"
        Me.LabelEstado.Size = New System.Drawing.Size(43, 13)
        Me.LabelEstado.TabIndex = 10
        Me.LabelEstado.Text = "Estado:"
        '
        ' ComboBoxEstado
        '
        Me.ComboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEstado.FormattingEnabled = True
        Me.ComboBoxEstado.Location = New System.Drawing.Point(100, 170)
        Me.ComboBoxEstado.Name = "ComboBoxEstado"
        Me.ComboBoxEstado.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxEstado.TabIndex = 11
        '
        ' ButtonInserir
        '
        Me.ButtonInserir.Location = New System.Drawing.Point(350, 50)
        Me.ButtonInserir.Name = "ButtonInserir"
        Me.ButtonInserir.Size = New System.Drawing.Size(100, 30)
        Me.ButtonInserir.TabIndex = 12
        Me.ButtonInserir.Text = "Inserir"
        Me.ButtonInserir.UseVisualStyleBackColor = True
        '
        ' ButtonEditar
        '
        Me.ButtonEditar.Location = New System.Drawing.Point(350, 90)
        Me.ButtonEditar.Name = "ButtonEditar"
        Me.ButtonEditar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonEditar.TabIndex = 13
        Me.ButtonEditar.Text = "Editar"
        Me.ButtonEditar.UseVisualStyleBackColor = True
        '
        ' ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(350, 130)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonEliminar.TabIndex = 14
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        ' ButtonLimpar
        '
        Me.ButtonLimpar.Location = New System.Drawing.Point(500, 50)
        Me.ButtonLimpar.Name = "ButtonLimpar"
        Me.ButtonLimpar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonLimpar.TabIndex = 15
        Me.ButtonLimpar.Text = "Limpar"
        Me.ButtonLimpar.UseVisualStyleBackColor = True
        '
        ' ButtonVoltar
        '
        Me.ButtonVoltar.Location = New System.Drawing.Point(500, 90)
        Me.ButtonVoltar.Name = "ButtonVoltar"
        Me.ButtonVoltar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonVoltar.TabIndex = 16
        Me.ButtonVoltar.Text = "Voltar"
        Me.ButtonVoltar.UseVisualStyleBackColor = True
        '
        ' TextBoxPesquisa
        '
        Me.TextBoxPesquisa.Location = New System.Drawing.Point(100, 210)
        Me.TextBoxPesquisa.Name = "TextBoxPesquisa"
        Me.TextBoxPesquisa.Size = New System.Drawing.Size(200, 20)
        Me.TextBoxPesquisa.TabIndex = 17
        '
        ' ButtonPesquisar
        '
        Me.ButtonPesquisar.Location = New System.Drawing.Point(350, 210)
        Me.ButtonPesquisar.Name = "ButtonPesquisar"
        Me.ButtonPesquisar.Size = New System.Drawing.Size(100, 30)
        Me.ButtonPesquisar.TabIndex = 18
        Me.ButtonPesquisar.Text = "Pesquisar"
        Me.ButtonPesquisar.UseVisualStyleBackColor = True
        '
        ' FormLivros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ButtonPesquisar)
        Me.Controls.Add(Me.TextBoxPesquisa)
        Me.Controls.Add(Me.ButtonVoltar)
        Me.Controls.Add(Me.ButtonLimpar)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonEditar)
        Me.Controls.Add(Me.ButtonInserir)
        Me.Controls.Add(Me.ComboBoxEstado)
        Me.Controls.Add(Me.LabelEstado)
        Me.Controls.Add(Me.TextBoxAno)
        Me.Controls.Add(Me.LabelAno)
        Me.Controls.Add(Me.TextBoxAutor)
        Me.Controls.Add(Me.LabelAutor)
        Me.Controls.Add(Me.TextBoxTitulo)
        Me.Controls.Add(Me.LabelTituloLivro)
        Me.Controls.Add(Me.TextBoxID)
        Me.Controls.Add(Me.LabelID)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.DataGridViewLivros)
        Me.Name = "FormLivros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestão de Livros"
        CType(Me.DataGridViewLivros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewLivros As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents LabelID As System.Windows.Forms.Label
    Friend WithEvents TextBoxID As System.Windows.Forms.TextBox
    Friend WithEvents LabelTituloLivro As System.Windows.Forms.Label
    Friend WithEvents TextBoxTitulo As System.Windows.Forms.TextBox
    Friend WithEvents LabelAutor As System.Windows.Forms.Label
    Friend WithEvents TextBoxAutor As System.Windows.Forms.TextBox
    Friend WithEvents LabelAno As System.Windows.Forms.Label
    Friend WithEvents TextBoxAno As System.Windows.Forms.TextBox
    Friend WithEvents LabelEstado As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonInserir As System.Windows.Forms.Button
    Friend WithEvents ButtonEditar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonLimpar As System.Windows.Forms.Button
    Friend WithEvents ButtonVoltar As System.Windows.Forms.Button
    Friend WithEvents TextBoxPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPesquisar As System.Windows.Forms.Button
End Class