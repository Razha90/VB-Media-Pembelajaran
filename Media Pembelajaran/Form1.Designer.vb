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
        BackPanel = New Panel()
        menu_keluar = New Button()
        menu_latihan = New Button()
        menu_belajar = New Button()
        profile_panel = New Panel()
        profile_role = New Label()
        profile_nama = New Label()
        Latihan = New Panel()
        Belajar = New Panel()
        belajar_default = New Panel()
        Label2 = New Label()
        belajar_layout = New Panel()
        belajar_isi = New Panel()
        belajar_text = New TextBox()
        belajar_next = New Button()
        belajar_previous = New Button()
        Panel1 = New Panel()
        Panel3 = New Panel()
        Label1 = New Label()
        belajar_flowLayout = New FlowLayoutPanel()
        BackPanel.SuspendLayout()
        profile_panel.SuspendLayout()
        Belajar.SuspendLayout()
        belajar_default.SuspendLayout()
        belajar_layout.SuspendLayout()
        belajar_isi.SuspendLayout()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' BackPanel
        ' 
        BackPanel.Controls.Add(menu_keluar)
        BackPanel.Controls.Add(menu_latihan)
        BackPanel.Controls.Add(menu_belajar)
        BackPanel.Location = New Point(0, 0)
        BackPanel.Name = "BackPanel"
        BackPanel.Size = New Size(785, 272)
        BackPanel.TabIndex = 2
        ' 
        ' menu_keluar
        ' 
        menu_keluar.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        menu_keluar.Location = New Point(304, 196)
        menu_keluar.Name = "menu_keluar"
        menu_keluar.Size = New Size(166, 46)
        menu_keluar.TabIndex = 2
        menu_keluar.Text = "Keluar"
        menu_keluar.UseVisualStyleBackColor = True
        ' 
        ' menu_latihan
        ' 
        menu_latihan.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        menu_latihan.Location = New Point(449, 34)
        menu_latihan.Name = "menu_latihan"
        menu_latihan.Size = New Size(181, 69)
        menu_latihan.TabIndex = 1
        menu_latihan.Text = "Latihan"
        menu_latihan.UseVisualStyleBackColor = True
        ' 
        ' menu_belajar
        ' 
        menu_belajar.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        menu_belajar.Location = New Point(132, 34)
        menu_belajar.Name = "menu_belajar"
        menu_belajar.Size = New Size(181, 69)
        menu_belajar.TabIndex = 0
        menu_belajar.Text = "Belajar"
        menu_belajar.UseVisualStyleBackColor = True
        ' 
        ' profile_panel
        ' 
        profile_panel.Controls.Add(profile_role)
        profile_panel.Controls.Add(profile_nama)
        profile_panel.Location = New Point(12, 12)
        profile_panel.Name = "profile_panel"
        profile_panel.Size = New Size(346, 94)
        profile_panel.TabIndex = 3
        ' 
        ' profile_role
        ' 
        profile_role.AutoSize = True
        profile_role.Location = New Point(20, 51)
        profile_role.Name = "profile_role"
        profile_role.Size = New Size(144, 25)
        profile_role.TabIndex = 1
        profile_role.Text = "Role Kamu Disini"
        ' 
        ' profile_nama
        ' 
        profile_nama.AutoSize = True
        profile_nama.Location = New Point(20, 15)
        profile_nama.Name = "profile_nama"
        profile_nama.Size = New Size(157, 25)
        profile_nama.TabIndex = 0
        profile_nama.Text = "Nama Kamu Disini"
        ' 
        ' Latihan
        ' 
        Latihan.Dock = DockStyle.Fill
        Latihan.Location = New Point(0, 0)
        Latihan.Name = "Latihan"
        Latihan.Size = New Size(1162, 607)
        Latihan.TabIndex = 4
        Latihan.Visible = False
        ' 
        ' Belajar
        ' 
        Belajar.Controls.Add(belajar_default)
        Belajar.Controls.Add(belajar_layout)
        Belajar.Controls.Add(Panel1)
        Belajar.Dock = DockStyle.Fill
        Belajar.Location = New Point(0, 0)
        Belajar.Name = "Belajar"
        Belajar.Size = New Size(1162, 607)
        Belajar.TabIndex = 5
        Belajar.Visible = False
        ' 
        ' belajar_default
        ' 
        belajar_default.Controls.Add(Label2)
        belajar_default.Dock = DockStyle.Fill
        belajar_default.Location = New Point(300, 0)
        belajar_default.Name = "belajar_default"
        belajar_default.Size = New Size(862, 607)
        belajar_default.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(197, 27)
        Label2.Name = "Label2"
        Label2.Size = New Size(486, 65)
        Label2.TabIndex = 0
        Label2.Text = "Silakan Pilih Materi"
        ' 
        ' belajar_layout
        ' 
        belajar_layout.BackColor = Color.LemonChiffon
        belajar_layout.Controls.Add(belajar_isi)
        belajar_layout.Controls.Add(belajar_next)
        belajar_layout.Controls.Add(belajar_previous)
        belajar_layout.Dock = DockStyle.Fill
        belajar_layout.Location = New Point(300, 0)
        belajar_layout.Name = "belajar_layout"
        belajar_layout.Size = New Size(862, 607)
        belajar_layout.TabIndex = 1
        ' 
        ' belajar_isi
        ' 
        belajar_isi.Controls.Add(belajar_text)
        belajar_isi.Location = New Point(79, 12)
        belajar_isi.Name = "belajar_isi"
        belajar_isi.Size = New Size(300, 150)
        belajar_isi.TabIndex = 2
        ' 
        ' belajar_text
        ' 
        belajar_text.Location = New Point(3, 3)
        belajar_text.Multiline = True
        belajar_text.Name = "belajar_text"
        belajar_text.ReadOnly = True
        belajar_text.Size = New Size(150, 46)
        belajar_text.TabIndex = 0
        ' 
        ' belajar_next
        ' 
        belajar_next.BackgroundImage = My.Resources.Resources._next
        belajar_next.BackgroundImageLayout = ImageLayout.Zoom
        belajar_next.Location = New Point(795, 278)
        belajar_next.Name = "belajar_next"
        belajar_next.Size = New Size(55, 46)
        belajar_next.TabIndex = 1
        belajar_next.UseVisualStyleBackColor = True
        ' 
        ' belajar_previous
        ' 
        belajar_previous.BackgroundImage = My.Resources.Resources.previous
        belajar_previous.BackgroundImageLayout = ImageLayout.Zoom
        belajar_previous.Location = New Point(6, 260)
        belajar_previous.Name = "belajar_previous"
        belajar_previous.Size = New Size(58, 47)
        belajar_previous.TabIndex = 0
        belajar_previous.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.IndianRed
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(belajar_flowLayout)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 607)
        Panel1.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(300, 88)
        Panel3.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(40, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(214, 48)
        Label1.TabIndex = 0
        Label1.Text = "Pilih Materi"
        ' 
        ' belajar_flowLayout
        ' 
        belajar_flowLayout.Dock = DockStyle.Bottom
        belajar_flowLayout.Location = New Point(0, 91)
        belajar_flowLayout.Name = "belajar_flowLayout"
        belajar_flowLayout.Size = New Size(300, 516)
        belajar_flowLayout.TabIndex = 0
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1162, 607)
        Controls.Add(Belajar)
        Controls.Add(Latihan)
        Controls.Add(profile_panel)
        Controls.Add(BackPanel)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimizeBox = False
        Name = "Home"
        RightToLeft = RightToLeft.No
        StartPosition = FormStartPosition.CenterParent
        Text = "MePA"
        WindowState = FormWindowState.Maximized
        BackPanel.ResumeLayout(False)
        profile_panel.ResumeLayout(False)
        profile_panel.PerformLayout()
        Belajar.ResumeLayout(False)
        belajar_default.ResumeLayout(False)
        belajar_default.PerformLayout()
        belajar_layout.ResumeLayout(False)
        belajar_isi.ResumeLayout(False)
        belajar_isi.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents profile_panel As Panel
    Friend WithEvents BackPanel As Panel
    Friend WithEvents profile_nama As Label
    Friend WithEvents profile_role As Label
    Friend WithEvents menu_keluar As Button
    Friend WithEvents menu_latihan As Button
    Friend WithEvents menu_belajar As Button
    Friend WithEvents Latihan As Panel
    Friend WithEvents Belajar As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents belajar_layout As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents belajar_flowLayout As FlowLayoutPanel
    Friend WithEvents belajar_next As Button
    Friend WithEvents belajar_previous As Button
    Friend WithEvents belajar_isi As Panel
    Friend WithEvents belajar_text As TextBox
    Friend WithEvents belajar_default As Panel
    Friend WithEvents Label2 As Label

End Class
