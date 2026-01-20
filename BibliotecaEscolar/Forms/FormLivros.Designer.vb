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
        Me.dgvLivros = New System.Windows.Forms.DataGridView()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.txtAutor = New System.Windows.Forms.TextBox()
        Me.dtpPublicacao = New System.Windows.Forms.DateTimePicker()
        Me.chkDisponivel = New System.Windows.Forms.CheckBox()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblAutor = New System.Windows.Forms.Label()
        CType(Me.dgvLivros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLivros
        '
        Me.dgvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLivros.Location = New System.Drawing.Point(12, 150)
        Me.dgvLivros.Name = "dgvLivros"
        Me.dgvLivros.Size = New System.Drawing.Size(560, 200)
        Me.dgvLivros.TabIndex = 0
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(70, 20)
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(200, 20)
        Me.txtTitulo.TabIndex = 1
        '
        'txtAutor
        '
        Me.txtAutor.Location = New System.Drawing.Point(70, 50)
        Me.txtAutor.Name = "txtAutor"
        Me.txtAutor.Size = New System.Drawing.Size(200, 20)
        Me.txtAutor.TabIndex = 2
        '
        'dtpPublicacao
        '
        Me.dtpPublicacao.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPublicacao.Location = New System.Drawing.Point(300, 20)
        Me.dtpPublicacao.Name = "dtpPublicacao"
        Me.dtpPublicacao.Size = New System.Drawing.Size(100, 20)
        Me.dtpPublicacao.TabIndex = 3
        '
        'chkDisponivel
        '
        Me.chkDisponivel.AutoSize = True
        Me.chkDisponivel.Location = New System.Drawing.Point(300, 52)
        Me.chkDisponivel.Name = "chkDisponivel"
        Me.chkDisponivel.Size = New System.Drawing.Size(77, 17)
        Me.chkDisponivel.TabIndex = 4
        Me.chkDisponivel.Text = "Disponível"
        Me.chkDisponivel.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Location = New System.Drawing.Point(12, 100)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(75, 23)
        Me.btnAdicionar.TabIndex = 5
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(93, 100)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(174, 100)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(12, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(38, 13)
        Me.lblTitulo.TabIndex = 8
        Me.lblTitulo.Text = "Título:"
        '
        'lblAutor
        '
        Me.lblAutor.AutoSize = True
        Me.lblAutor.Location = New System.Drawing.Point(12, 53)
        Me.lblAutor.Name = "lblAutor"
        Me.lblAutor.Size = New System.Drawing.Size(35, 13)
        Me.lblAutor.TabIndex = 9
        Me.lblAutor.Text = "Autor:"
        '
        'FormLivros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.lblAutor)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.chkDisponivel)
        Me.Controls.Add(Me.dtpPublicacao)
        Me.Controls.Add(Me.txtAutor)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.dgvLivros)
        Me.Name = "FormLivros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gestão de Livros"
        CType(Me.dgvLivros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvLivros As System.Windows.Forms.DataGridView
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents txtAutor As System.Windows.Forms.TextBox
    Friend WithEvents dtpPublicacao As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDisponivel As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAutor As System.Windows.Forms.Label
End Class
