Namespace My
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Friend Class MyApplication
        Inherits Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase

        <System.Diagnostics.DebuggerNonUserCode()>
        Public Sub New()
            MyBase.New(Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = False
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = True
            Me.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.BibliotecaEscolar.FormMain
        End Sub
    End Class
End Namespace