<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Button1 = New Button()
        BackPanel = New Panel()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(629, 93)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 1
        Button1.Text = "Hot Reload"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' BackPanel
        ' 
        BackPanel.Location = New Point(174, 175)
        BackPanel.Name = "BackPanel"
        BackPanel.Size = New Size(785, 272)
        BackPanel.TabIndex = 2
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(21, 12)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 0
        Button2.Text = "Materi"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1162, 607)
        Controls.Add(Button2)
        Controls.Add(BackPanel)
        Controls.Add(Button1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimizeBox = False
        Name = "Home"
        RightToLeft = RightToLeft.No
        StartPosition = FormStartPosition.CenterParent
        Text = "MePA"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents BackPanel As Panel
    Friend WithEvents Button2 As Button

End Class
