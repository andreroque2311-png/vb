Imports System
Imports System.Windows.Forms

Module Program
    Sub Main(args As String())
        ' Configurar aplicação para usar Windows Forms
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        
        ' Inicializar o formulário principal
        Dim mainForm As New FormMain()
        Application.Run(mainForm)
    End Sub
End Module