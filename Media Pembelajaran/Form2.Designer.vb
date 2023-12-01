<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Panel1 = New Panel()
        Label1 = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Login = New Panel()
        Active_Login = New Button()
        Label_Login = New Label()
        Icon_Login = New Button()
        Daftar = New Panel()
        Active_Daftar = New Button()
        Daftar_Label = New Label()
        Icon_Daftar = New Button()
        Database = New Panel()
        Active_Database = New Button()
        Database_Label = New Label()
        Icon_Database = New Button()
        Profile = New Panel()
        Active_Profile = New Button()
        Profile_Label = New Label()
        Icon_Profile = New Button()
        Materi = New Panel()
        Active_Materi = New Button()
        Materi_Label = New Label()
        Icon_Materi = New Button()
        Latihan = New Panel()
        Active_Latihan = New Button()
        Latihan_Label = New Label()
        Icon_Latihan = New Button()
        Murid = New Panel()
        Active_Murid = New Button()
        Murid_Label = New Label()
        Icon_Murid = New Button()
        Minimize_Button = New Button()
        Exit_Button = New Button()
        Database_Container = New Panel()
        DC_Title = New Label()
        DC_L_Server = New Label()
        DC_L_Database = New Label()
        DC_L_User = New Label()
        DC_L_Password = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Panel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        Login.SuspendLayout()
        Daftar.SuspendLayout()
        Database.SuspendLayout()
        Profile.SuspendLayout()
        Materi.SuspendLayout()
        Latihan.SuspendLayout()
        Murid.SuspendLayout()
        Database_Container.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.IndianRed
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(FlowLayoutPanel1)
        Panel1.Controls.Add(Minimize_Button)
        Panel1.Controls.Add(Exit_Button)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(223, 744)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ButtonFace
        Label1.Location = New Point(9, 710)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 28)
        Label1.TabIndex = 4
        Label1.Text = "V 1.0"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(Login)
        FlowLayoutPanel1.Controls.Add(Daftar)
        FlowLayoutPanel1.Controls.Add(Database)
        FlowLayoutPanel1.Controls.Add(Profile)
        FlowLayoutPanel1.Controls.Add(Materi)
        FlowLayoutPanel1.Controls.Add(Latihan)
        FlowLayoutPanel1.Controls.Add(Murid)
        FlowLayoutPanel1.Location = New Point(0, 55)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(223, 649)
        FlowLayoutPanel1.TabIndex = 3
        ' 
        ' Login
        ' 
        Login.Controls.Add(Active_Login)
        Login.Controls.Add(Label_Login)
        Login.Controls.Add(Icon_Login)
        Login.Location = New Point(3, 3)
        Login.Name = "Login"
        Login.Size = New Size(223, 50)
        Login.TabIndex = 0
        ' 
        ' Active_Login
        ' 
        Active_Login.BackColor = Color.Gold
        Active_Login.FlatAppearance.BorderSize = 0
        Active_Login.FlatStyle = FlatStyle.Flat
        Active_Login.Location = New Point(0, 0)
        Active_Login.Name = "Active_Login"
        Active_Login.Size = New Size(15, 50)
        Active_Login.TabIndex = 1
        Active_Login.UseVisualStyleBackColor = False
        ' 
        ' Label_Login
        ' 
        Label_Login.AutoSize = True
        Label_Login.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label_Login.ForeColor = SystemColors.ControlLightLight
        Label_Login.Location = New Point(84, 9)
        Label_Login.Name = "Label_Login"
        Label_Login.Size = New Size(85, 30)
        Label_Login.TabIndex = 1
        Label_Login.Text = "Masuk"
        ' 
        ' Icon_Login
        ' 
        Icon_Login.BackColor = Color.Transparent
        Icon_Login.BackgroundImage = My.Resources.Resources.Login
        Icon_Login.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Login.FlatAppearance.BorderSize = 0
        Icon_Login.FlatStyle = FlatStyle.Flat
        Icon_Login.Location = New Point(41, 7)
        Icon_Login.Margin = New Padding(0)
        Icon_Login.Name = "Icon_Login"
        Icon_Login.Size = New Size(49, 35)
        Icon_Login.TabIndex = 0
        Icon_Login.UseVisualStyleBackColor = False
        ' 
        ' Daftar
        ' 
        Daftar.Controls.Add(Active_Daftar)
        Daftar.Controls.Add(Daftar_Label)
        Daftar.Controls.Add(Icon_Daftar)
        Daftar.Location = New Point(3, 59)
        Daftar.Name = "Daftar"
        Daftar.Size = New Size(223, 50)
        Daftar.TabIndex = 2
        ' 
        ' Active_Daftar
        ' 
        Active_Daftar.BackColor = Color.Gold
        Active_Daftar.FlatAppearance.BorderSize = 0
        Active_Daftar.FlatStyle = FlatStyle.Flat
        Active_Daftar.Location = New Point(0, 0)
        Active_Daftar.Name = "Active_Daftar"
        Active_Daftar.Size = New Size(15, 50)
        Active_Daftar.TabIndex = 1
        Active_Daftar.UseVisualStyleBackColor = False
        ' 
        ' Daftar_Label
        ' 
        Daftar_Label.AutoSize = True
        Daftar_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Daftar_Label.ForeColor = SystemColors.ControlLightLight
        Daftar_Label.Location = New Point(84, 9)
        Daftar_Label.Name = "Daftar_Label"
        Daftar_Label.Size = New Size(82, 30)
        Daftar_Label.TabIndex = 1
        Daftar_Label.Text = "Daftar"
        ' 
        ' Icon_Daftar
        ' 
        Icon_Daftar.BackColor = Color.Transparent
        Icon_Daftar.BackgroundImage = My.Resources.Resources.register
        Icon_Daftar.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Daftar.FlatAppearance.BorderSize = 0
        Icon_Daftar.FlatStyle = FlatStyle.Flat
        Icon_Daftar.Location = New Point(41, 7)
        Icon_Daftar.Margin = New Padding(0)
        Icon_Daftar.Name = "Icon_Daftar"
        Icon_Daftar.Size = New Size(49, 35)
        Icon_Daftar.TabIndex = 0
        Icon_Daftar.UseVisualStyleBackColor = False
        ' 
        ' Database
        ' 
        Database.Controls.Add(Active_Database)
        Database.Controls.Add(Database_Label)
        Database.Controls.Add(Icon_Database)
        Database.Location = New Point(3, 115)
        Database.Name = "Database"
        Database.Size = New Size(223, 50)
        Database.TabIndex = 3
        ' 
        ' Active_Database
        ' 
        Active_Database.BackColor = Color.Gold
        Active_Database.FlatAppearance.BorderSize = 0
        Active_Database.FlatStyle = FlatStyle.Flat
        Active_Database.Location = New Point(0, 0)
        Active_Database.Name = "Active_Database"
        Active_Database.Size = New Size(15, 50)
        Active_Database.TabIndex = 1
        Active_Database.UseVisualStyleBackColor = False
        ' 
        ' Database_Label
        ' 
        Database_Label.AutoSize = True
        Database_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Database_Label.ForeColor = SystemColors.ControlLightLight
        Database_Label.Location = New Point(84, 9)
        Database_Label.Name = "Database_Label"
        Database_Label.Size = New Size(112, 30)
        Database_Label.TabIndex = 1
        Database_Label.Text = "Database"
        ' 
        ' Icon_Database
        ' 
        Icon_Database.BackColor = Color.Transparent
        Icon_Database.BackgroundImage = My.Resources.Resources.Database
        Icon_Database.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Database.FlatAppearance.BorderSize = 0
        Icon_Database.FlatStyle = FlatStyle.Flat
        Icon_Database.Location = New Point(41, 7)
        Icon_Database.Margin = New Padding(0)
        Icon_Database.Name = "Icon_Database"
        Icon_Database.Size = New Size(49, 35)
        Icon_Database.TabIndex = 0
        Icon_Database.UseVisualStyleBackColor = False
        ' 
        ' Profile
        ' 
        Profile.Controls.Add(Active_Profile)
        Profile.Controls.Add(Profile_Label)
        Profile.Controls.Add(Icon_Profile)
        Profile.Location = New Point(3, 171)
        Profile.Name = "Profile"
        Profile.Size = New Size(223, 50)
        Profile.TabIndex = 4
        ' 
        ' Active_Profile
        ' 
        Active_Profile.BackColor = Color.Gold
        Active_Profile.FlatAppearance.BorderSize = 0
        Active_Profile.FlatStyle = FlatStyle.Flat
        Active_Profile.Location = New Point(0, 0)
        Active_Profile.Name = "Active_Profile"
        Active_Profile.Size = New Size(15, 50)
        Active_Profile.TabIndex = 1
        Active_Profile.UseVisualStyleBackColor = False
        ' 
        ' Profile_Label
        ' 
        Profile_Label.AutoSize = True
        Profile_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Profile_Label.ForeColor = SystemColors.ControlLightLight
        Profile_Label.Location = New Point(84, 9)
        Profile_Label.Name = "Profile_Label"
        Profile_Label.Size = New Size(86, 30)
        Profile_Label.TabIndex = 1
        Profile_Label.Text = "Profile"
        ' 
        ' Icon_Profile
        ' 
        Icon_Profile.BackColor = Color.Transparent
        Icon_Profile.BackgroundImage = My.Resources.Resources.Profile
        Icon_Profile.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Profile.FlatAppearance.BorderSize = 0
        Icon_Profile.FlatStyle = FlatStyle.Flat
        Icon_Profile.Location = New Point(41, 7)
        Icon_Profile.Margin = New Padding(0)
        Icon_Profile.Name = "Icon_Profile"
        Icon_Profile.Size = New Size(49, 35)
        Icon_Profile.TabIndex = 0
        Icon_Profile.UseVisualStyleBackColor = False
        ' 
        ' Materi
        ' 
        Materi.Controls.Add(Active_Materi)
        Materi.Controls.Add(Materi_Label)
        Materi.Controls.Add(Icon_Materi)
        Materi.Location = New Point(3, 227)
        Materi.Name = "Materi"
        Materi.Size = New Size(223, 50)
        Materi.TabIndex = 5
        ' 
        ' Active_Materi
        ' 
        Active_Materi.BackColor = Color.Gold
        Active_Materi.FlatAppearance.BorderSize = 0
        Active_Materi.FlatStyle = FlatStyle.Flat
        Active_Materi.Location = New Point(0, 0)
        Active_Materi.Name = "Active_Materi"
        Active_Materi.Size = New Size(15, 50)
        Active_Materi.TabIndex = 1
        Active_Materi.UseVisualStyleBackColor = False
        ' 
        ' Materi_Label
        ' 
        Materi_Label.AutoSize = True
        Materi_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Materi_Label.ForeColor = SystemColors.ControlLightLight
        Materi_Label.Location = New Point(84, 9)
        Materi_Label.Name = "Materi_Label"
        Materi_Label.Size = New Size(85, 30)
        Materi_Label.TabIndex = 1
        Materi_Label.Text = "Materi"
        ' 
        ' Icon_Materi
        ' 
        Icon_Materi.BackColor = Color.Transparent
        Icon_Materi.BackgroundImage = My.Resources.Resources.Reading
        Icon_Materi.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Materi.FlatAppearance.BorderSize = 0
        Icon_Materi.FlatStyle = FlatStyle.Flat
        Icon_Materi.Location = New Point(41, 7)
        Icon_Materi.Margin = New Padding(0)
        Icon_Materi.Name = "Icon_Materi"
        Icon_Materi.Size = New Size(49, 35)
        Icon_Materi.TabIndex = 0
        Icon_Materi.UseVisualStyleBackColor = False
        ' 
        ' Latihan
        ' 
        Latihan.Controls.Add(Active_Latihan)
        Latihan.Controls.Add(Latihan_Label)
        Latihan.Controls.Add(Icon_Latihan)
        Latihan.Location = New Point(3, 283)
        Latihan.Name = "Latihan"
        Latihan.Size = New Size(223, 50)
        Latihan.TabIndex = 6
        ' 
        ' Active_Latihan
        ' 
        Active_Latihan.BackColor = Color.Gold
        Active_Latihan.FlatAppearance.BorderSize = 0
        Active_Latihan.FlatStyle = FlatStyle.Flat
        Active_Latihan.Location = New Point(0, 0)
        Active_Latihan.Name = "Active_Latihan"
        Active_Latihan.Size = New Size(15, 50)
        Active_Latihan.TabIndex = 1
        Active_Latihan.UseVisualStyleBackColor = False
        ' 
        ' Latihan_Label
        ' 
        Latihan_Label.AutoSize = True
        Latihan_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Latihan_Label.ForeColor = SystemColors.ControlLightLight
        Latihan_Label.Location = New Point(84, 9)
        Latihan_Label.Name = "Latihan_Label"
        Latihan_Label.Size = New Size(93, 30)
        Latihan_Label.TabIndex = 1
        Latihan_Label.Text = "Latihan"
        ' 
        ' Icon_Latihan
        ' 
        Icon_Latihan.BackColor = Color.Transparent
        Icon_Latihan.BackgroundImage = My.Resources.Resources.Task
        Icon_Latihan.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Latihan.FlatAppearance.BorderSize = 0
        Icon_Latihan.FlatStyle = FlatStyle.Flat
        Icon_Latihan.Location = New Point(41, 7)
        Icon_Latihan.Margin = New Padding(0)
        Icon_Latihan.Name = "Icon_Latihan"
        Icon_Latihan.Size = New Size(49, 35)
        Icon_Latihan.TabIndex = 0
        Icon_Latihan.UseVisualStyleBackColor = False
        ' 
        ' Murid
        ' 
        Murid.Controls.Add(Active_Murid)
        Murid.Controls.Add(Murid_Label)
        Murid.Controls.Add(Icon_Murid)
        Murid.Location = New Point(3, 339)
        Murid.Name = "Murid"
        Murid.Size = New Size(223, 50)
        Murid.TabIndex = 7
        ' 
        ' Active_Murid
        ' 
        Active_Murid.BackColor = Color.Gold
        Active_Murid.FlatAppearance.BorderSize = 0
        Active_Murid.FlatStyle = FlatStyle.Flat
        Active_Murid.Location = New Point(0, 0)
        Active_Murid.Name = "Active_Murid"
        Active_Murid.Size = New Size(15, 50)
        Active_Murid.TabIndex = 1
        Active_Murid.UseVisualStyleBackColor = False
        ' 
        ' Murid_Label
        ' 
        Murid_Label.AutoSize = True
        Murid_Label.Font = New Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Murid_Label.ForeColor = SystemColors.ControlLightLight
        Murid_Label.Location = New Point(84, 9)
        Murid_Label.Name = "Murid_Label"
        Murid_Label.Size = New Size(80, 30)
        Murid_Label.TabIndex = 1
        Murid_Label.Text = "Murid"
        ' 
        ' Icon_Murid
        ' 
        Icon_Murid.BackColor = Color.Transparent
        Icon_Murid.BackgroundImage = My.Resources.Resources.people
        Icon_Murid.BackgroundImageLayout = ImageLayout.Zoom
        Icon_Murid.FlatAppearance.BorderSize = 0
        Icon_Murid.FlatStyle = FlatStyle.Flat
        Icon_Murid.Location = New Point(41, 7)
        Icon_Murid.Margin = New Padding(0)
        Icon_Murid.Name = "Icon_Murid"
        Icon_Murid.Size = New Size(49, 35)
        Icon_Murid.TabIndex = 0
        Icon_Murid.UseVisualStyleBackColor = False
        ' 
        ' Minimize_Button
        ' 
        Minimize_Button.BackColor = Color.Transparent
        Minimize_Button.BackgroundImageLayout = ImageLayout.Stretch
        Minimize_Button.Cursor = Cursors.Hand
        Minimize_Button.FlatAppearance.BorderSize = 0
        Minimize_Button.FlatStyle = FlatStyle.Flat
        Minimize_Button.Font = New Font("Impact", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Minimize_Button.ForeColor = SystemColors.ButtonFace
        Minimize_Button.Location = New Point(44, 4)
        Minimize_Button.Margin = New Padding(0)
        Minimize_Button.Name = "Minimize_Button"
        Minimize_Button.Size = New Size(28, 48)
        Minimize_Button.TabIndex = 2
        Minimize_Button.Text = "-"
        Minimize_Button.UseVisualStyleBackColor = False
        ' 
        ' Exit_Button
        ' 
        Exit_Button.BackColor = Color.Transparent
        Exit_Button.BackgroundImageLayout = ImageLayout.Stretch
        Exit_Button.Cursor = Cursors.Hand
        Exit_Button.FlatAppearance.BorderSize = 0
        Exit_Button.FlatStyle = FlatStyle.Flat
        Exit_Button.Font = New Font("Impact", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Exit_Button.ForeColor = SystemColors.ButtonFace
        Exit_Button.Location = New Point(11, 2)
        Exit_Button.Margin = New Padding(0)
        Exit_Button.Name = "Exit_Button"
        Exit_Button.Size = New Size(28, 50)
        Exit_Button.TabIndex = 1
        Exit_Button.Text = "×"
        Exit_Button.UseVisualStyleBackColor = False
        ' 
        ' Database_Container
        ' 
        Database_Container.Controls.Add(Button2)
        Database_Container.Controls.Add(Button1)
        Database_Container.Controls.Add(TextBox4)
        Database_Container.Controls.Add(TextBox3)
        Database_Container.Controls.Add(TextBox2)
        Database_Container.Controls.Add(TextBox1)
        Database_Container.Controls.Add(DC_L_Password)
        Database_Container.Controls.Add(DC_L_User)
        Database_Container.Controls.Add(DC_L_Database)
        Database_Container.Controls.Add(DC_L_Server)
        Database_Container.Controls.Add(DC_Title)
        Database_Container.Dock = DockStyle.Fill
        Database_Container.Location = New Point(223, 0)
        Database_Container.Name = "Database_Container"
        Database_Container.Size = New Size(865, 744)
        Database_Container.TabIndex = 1
        ' 
        ' DC_Title
        ' 
        DC_Title.AutoSize = True
        DC_Title.Font = New Font("Lucida Bright", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DC_Title.Location = New Point(60, 43)
        DC_Title.Name = "DC_Title"
        DC_Title.Size = New Size(460, 42)
        DC_Title.TabIndex = 0
        DC_Title.Text = "Connection To Database"
        ' 
        ' DC_L_Server
        ' 
        DC_L_Server.AutoSize = True
        DC_L_Server.Location = New Point(72, 123)
        DC_L_Server.Name = "DC_L_Server"
        DC_L_Server.Size = New Size(70, 25)
        DC_L_Server.TabIndex = 1
        DC_L_Server.Text = "Server :"
        ' 
        ' DC_L_Database
        ' 
        DC_L_Database.AutoSize = True
        DC_L_Database.Location = New Point(72, 170)
        DC_L_Database.Name = "DC_L_Database"
        DC_L_Database.Size = New Size(95, 25)
        DC_L_Database.TabIndex = 2
        DC_L_Database.Text = "Database :"
        ' 
        ' DC_L_User
        ' 
        DC_L_User.AutoSize = True
        DC_L_User.Location = New Point(72, 212)
        DC_L_User.Name = "DC_L_User"
        DC_L_User.Size = New Size(56, 25)
        DC_L_User.TabIndex = 3
        DC_L_User.Text = "User :"
        ' 
        ' DC_L_Password
        ' 
        DC_L_Password.AutoSize = True
        DC_L_Password.Location = New Point(72, 251)
        DC_L_Password.Name = "DC_L_Password"
        DC_L_Password.Size = New Size(96, 25)
        DC_L_Password.TabIndex = 4
        DC_L_Password.Text = "Password :"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(172, 122)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(622, 31)
        TextBox1.TabIndex = 5
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(173, 170)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(622, 31)
        TextBox2.TabIndex = 6
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(172, 212)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(622, 31)
        TextBox3.TabIndex = 7
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(172, 251)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(622, 31)
        TextBox4.TabIndex = 8
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(682, 311)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 9
        Button1.Text = "Test"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(376, 333)
        Button2.Name = "Button2"
        Button2.Size = New Size(144, 44)
        Button2.TabIndex = 10
        Button2.Text = "Save"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1088, 744)
        Controls.Add(Database_Container)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Dashboard"
        StartPosition = FormStartPosition.CenterParent
        Text = "MePa"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        Login.ResumeLayout(False)
        Login.PerformLayout()
        Daftar.ResumeLayout(False)
        Daftar.PerformLayout()
        Database.ResumeLayout(False)
        Database.PerformLayout()
        Profile.ResumeLayout(False)
        Profile.PerformLayout()
        Materi.ResumeLayout(False)
        Materi.PerformLayout()
        Latihan.ResumeLayout(False)
        Latihan.PerformLayout()
        Murid.ResumeLayout(False)
        Murid.PerformLayout()
        Database_Container.ResumeLayout(False)
        Database_Container.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Exit_Button As Button
    Friend WithEvents Minimize_Button As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Login As Panel
    Friend WithEvents Icon_Login As Button
    Friend WithEvents Label_Login As Label
    Friend WithEvents Daftar As Panel
    Friend WithEvents Active_Daftar As Button
    Friend WithEvents Daftar_Label As Label
    Friend WithEvents Icon_Daftar As Button
    Friend WithEvents Active_Login As Button
    Friend WithEvents Database As Panel
    Friend WithEvents Active_Database As Button
    Friend WithEvents Database_Label As Label
    Friend WithEvents Icon_Database As Button
    Friend WithEvents Profile As Panel
    Friend WithEvents Active_Profile As Button
    Friend WithEvents Profile_Label As Label
    Friend WithEvents Icon_Profile As Button
    Friend WithEvents Materi As Panel
    Friend WithEvents Active_Materi As Button
    Friend WithEvents Materi_Label As Label
    Friend WithEvents Icon_Materi As Button
    Friend WithEvents Latihan As Panel
    Friend WithEvents Active_Latihan As Button
    Friend WithEvents Latihan_Label As Label
    Friend WithEvents Icon_Latihan As Button
    Friend WithEvents Murid As Panel
    Friend WithEvents Active_Murid As Button
    Friend WithEvents Murid_Label As Label
    Friend WithEvents Icon_Murid As Button
    Friend WithEvents Database_Container As Panel
    Friend WithEvents DC_L_Password As Label
    Friend WithEvents DC_L_User As Label
    Friend WithEvents DC_L_Database As Label
    Friend WithEvents DC_L_Server As Label
    Friend WithEvents DC_Title As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
