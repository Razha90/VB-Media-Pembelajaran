﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        latihan_kanan = New Panel()
        latihan_next = New Button()
        latihan_pertanyaan = New Panel()
        latihan_1 = New RadioButton()
        latihan_2 = New RadioButton()
        latihan_4 = New RadioButton()
        latihan_3 = New RadioButton()
        latihan_pilih = New Panel()
        Label4 = New Label()
        latihan_kiri = New Panel()
        latihan_flow = New FlowLayoutPanel()
        Panel2 = New Panel()
        latihan_keluar = New Button()
        Label3 = New Label()
        Belajar = New Panel()
        belajar_default = New Panel()
        Label2 = New Label()
        belajar_layout = New Panel()
        belajar_subJudul = New Label()
        belajar_isi = New Panel()
        belajar_text = New TextBox()
        belajar_next = New Button()
        belajar_previous = New Button()
        Panel1 = New Panel()
        belajar_keluar = New Button()
        Panel3 = New Panel()
        Label1 = New Label()
        belajar_flowLayout = New FlowLayoutPanel()
        latihan_soal = New TextBox()
        BackPanel.SuspendLayout()
        profile_panel.SuspendLayout()
        Latihan.SuspendLayout()
        latihan_kanan.SuspendLayout()
        latihan_pertanyaan.SuspendLayout()
        latihan_pilih.SuspendLayout()
        latihan_kiri.SuspendLayout()
        Panel2.SuspendLayout()
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
        Latihan.Controls.Add(latihan_kanan)
        Latihan.Controls.Add(latihan_pilih)
        Latihan.Controls.Add(latihan_kiri)
        Latihan.Dock = DockStyle.Fill
        Latihan.Location = New Point(0, 0)
        Latihan.Name = "Latihan"
        Latihan.Size = New Size(1162, 607)
        Latihan.TabIndex = 4
        Latihan.Visible = False
        ' 
        ' latihan_kanan
        ' 
        latihan_kanan.Controls.Add(latihan_soal)
        latihan_kanan.Controls.Add(latihan_next)
        latihan_kanan.Controls.Add(latihan_pertanyaan)
        latihan_kanan.Dock = DockStyle.Fill
        latihan_kanan.Location = New Point(300, 0)
        latihan_kanan.Name = "latihan_kanan"
        latihan_kanan.Size = New Size(862, 607)
        latihan_kanan.TabIndex = 1
        ' 
        ' latihan_next
        ' 
        latihan_next.Font = New Font("Segoe UI Black", 26F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        latihan_next.Location = New Point(797, 278)
        latihan_next.Name = "latihan_next"
        latihan_next.Size = New Size(53, 164)
        latihan_next.TabIndex = 6
        latihan_next.Text = ">"
        latihan_next.UseVisualStyleBackColor = True
        ' 
        ' latihan_pertanyaan
        ' 
        latihan_pertanyaan.Controls.Add(latihan_1)
        latihan_pertanyaan.Controls.Add(latihan_2)
        latihan_pertanyaan.Controls.Add(latihan_4)
        latihan_pertanyaan.Controls.Add(latihan_3)
        latihan_pertanyaan.Location = New Point(68, 216)
        latihan_pertanyaan.Name = "latihan_pertanyaan"
        latihan_pertanyaan.Size = New Size(721, 241)
        latihan_pertanyaan.TabIndex = 5
        ' 
        ' latihan_1
        ' 
        latihan_1.AutoSize = True
        latihan_1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        latihan_1.Location = New Point(13, 22)
        latihan_1.Name = "latihan_1"
        latihan_1.Size = New Size(184, 36)
        latihan_1.TabIndex = 0
        latihan_1.TabStop = True
        latihan_1.Text = "RadioButton1"
        latihan_1.UseVisualStyleBackColor = True
        ' 
        ' latihan_2
        ' 
        latihan_2.AutoSize = True
        latihan_2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        latihan_2.Location = New Point(13, 77)
        latihan_2.Name = "latihan_2"
        latihan_2.Size = New Size(184, 36)
        latihan_2.TabIndex = 1
        latihan_2.TabStop = True
        latihan_2.Text = "RadioButton2"
        latihan_2.UseVisualStyleBackColor = True
        ' 
        ' latihan_4
        ' 
        latihan_4.AutoSize = True
        latihan_4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        latihan_4.Location = New Point(13, 182)
        latihan_4.Name = "latihan_4"
        latihan_4.Size = New Size(184, 36)
        latihan_4.TabIndex = 3
        latihan_4.TabStop = True
        latihan_4.Text = "RadioButton4"
        latihan_4.UseVisualStyleBackColor = True
        ' 
        ' latihan_3
        ' 
        latihan_3.AutoSize = True
        latihan_3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        latihan_3.Location = New Point(13, 130)
        latihan_3.Name = "latihan_3"
        latihan_3.Size = New Size(184, 36)
        latihan_3.TabIndex = 2
        latihan_3.TabStop = True
        latihan_3.Text = "RadioButton3"
        latihan_3.UseVisualStyleBackColor = True
        ' 
        ' latihan_pilih
        ' 
        latihan_pilih.BackgroundImage = My.Resources.Resources.bg_materi
        latihan_pilih.BackgroundImageLayout = ImageLayout.Stretch
        latihan_pilih.Controls.Add(Label4)
        latihan_pilih.Dock = DockStyle.Fill
        latihan_pilih.Location = New Point(300, 0)
        latihan_pilih.Name = "latihan_pilih"
        latihan_pilih.Size = New Size(862, 607)
        latihan_pilih.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Black", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(454, 28)
        Label4.Name = "Label4"
        Label4.Size = New Size(362, 60)
        Label4.TabIndex = 0
        Label4.Text = "Pilihlah Latihan"
        ' 
        ' latihan_kiri
        ' 
        latihan_kiri.BackColor = Color.IndianRed
        latihan_kiri.Controls.Add(latihan_flow)
        latihan_kiri.Controls.Add(Panel2)
        latihan_kiri.Dock = DockStyle.Left
        latihan_kiri.Location = New Point(0, 0)
        latihan_kiri.Name = "latihan_kiri"
        latihan_kiri.Size = New Size(300, 607)
        latihan_kiri.TabIndex = 0
        ' 
        ' latihan_flow
        ' 
        latihan_flow.Dock = DockStyle.Left
        latihan_flow.Location = New Point(0, 150)
        latihan_flow.Name = "latihan_flow"
        latihan_flow.Size = New Size(300, 457)
        latihan_flow.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(latihan_keluar)
        Panel2.Controls.Add(Label3)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(300, 150)
        Panel2.TabIndex = 0
        ' 
        ' latihan_keluar
        ' 
        latihan_keluar.Location = New Point(12, 12)
        latihan_keluar.Name = "latihan_keluar"
        latihan_keluar.Size = New Size(112, 34)
        latihan_keluar.TabIndex = 1
        latihan_keluar.Text = "keluar"
        latihan_keluar.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Black", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(55, 52)
        Label3.Name = "Label3"
        Label3.Size = New Size(186, 60)
        Label3.TabIndex = 0
        Label3.Text = "Latihan"
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
        belajar_default.BackgroundImage = My.Resources.Resources.bg_materi1
        belajar_default.BackgroundImageLayout = ImageLayout.Stretch
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
        Label2.Location = New Point(362, 31)
        Label2.Name = "Label2"
        Label2.Size = New Size(486, 65)
        Label2.TabIndex = 0
        Label2.Text = "Silakan Pilih Materi"
        ' 
        ' belajar_layout
        ' 
        belajar_layout.BackColor = Color.LemonChiffon
        belajar_layout.BackgroundImage = My.Resources.Resources.materis
        belajar_layout.BackgroundImageLayout = ImageLayout.Stretch
        belajar_layout.Controls.Add(belajar_subJudul)
        belajar_layout.Controls.Add(belajar_isi)
        belajar_layout.Controls.Add(belajar_next)
        belajar_layout.Controls.Add(belajar_previous)
        belajar_layout.Dock = DockStyle.Fill
        belajar_layout.Location = New Point(300, 0)
        belajar_layout.Name = "belajar_layout"
        belajar_layout.Size = New Size(862, 607)
        belajar_layout.TabIndex = 1
        ' 
        ' belajar_subJudul
        ' 
        belajar_subJudul.AutoSize = True
        belajar_subJudul.Font = New Font("Arial Narrow", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        belajar_subJudul.Location = New Point(362, 42)
        belajar_subJudul.Name = "belajar_subJudul"
        belajar_subJudul.Size = New Size(123, 46)
        belajar_subJudul.TabIndex = 3
        belajar_subJudul.Text = "Label3"
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
        belajar_text.Size = New Size(150, 46)
        belajar_text.TabIndex = 0
        belajar_text.Text = "sdsdsd"
        ' 
        ' belajar_next
        ' 
        belajar_next.BackColor = Color.Red
        belajar_next.BackgroundImage = My.Resources.Resources._next
        belajar_next.BackgroundImageLayout = ImageLayout.Zoom
        belajar_next.Location = New Point(795, 260)
        belajar_next.Name = "belajar_next"
        belajar_next.Size = New Size(55, 89)
        belajar_next.TabIndex = 1
        belajar_next.UseVisualStyleBackColor = False
        ' 
        ' belajar_previous
        ' 
        belajar_previous.BackColor = Color.Red
        belajar_previous.BackgroundImage = My.Resources.Resources.previous
        belajar_previous.BackgroundImageLayout = ImageLayout.Zoom
        belajar_previous.Location = New Point(6, 238)
        belajar_previous.Name = "belajar_previous"
        belajar_previous.Size = New Size(58, 96)
        belajar_previous.TabIndex = 0
        belajar_previous.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.IndianRed
        Panel1.Controls.Add(belajar_keluar)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(belajar_flowLayout)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 607)
        Panel1.TabIndex = 0
        ' 
        ' belajar_keluar
        ' 
        belajar_keluar.Location = New Point(12, 561)
        belajar_keluar.Name = "belajar_keluar"
        belajar_keluar.Size = New Size(112, 34)
        belajar_keluar.TabIndex = 1
        belajar_keluar.Text = "Keluar"
        belajar_keluar.UseVisualStyleBackColor = True
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
        belajar_flowLayout.Location = New Point(0, 91)
        belajar_flowLayout.Name = "belajar_flowLayout"
        belajar_flowLayout.Size = New Size(300, 460)
        belajar_flowLayout.TabIndex = 0
        ' 
        ' latihan_soal
        ' 
        latihan_soal.Font = New Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        latihan_soal.Location = New Point(64, 34)
        latihan_soal.Multiline = True
        latihan_soal.Name = "latihan_soal"
        latihan_soal.ReadOnly = True
        latihan_soal.Size = New Size(725, 176)
        latihan_soal.TabIndex = 8
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.image_bg
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1162, 607)
        Controls.Add(Latihan)
        Controls.Add(Belajar)
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
        Latihan.ResumeLayout(False)
        latihan_kanan.ResumeLayout(False)
        latihan_kanan.PerformLayout()
        latihan_pertanyaan.ResumeLayout(False)
        latihan_pertanyaan.PerformLayout()
        latihan_pilih.ResumeLayout(False)
        latihan_pilih.PerformLayout()
        latihan_kiri.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Belajar.ResumeLayout(False)
        belajar_default.ResumeLayout(False)
        belajar_default.PerformLayout()
        belajar_layout.ResumeLayout(False)
        belajar_layout.PerformLayout()
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
    Friend WithEvents belajar_keluar As Button
    Friend WithEvents belajar_subJudul As Label
    Friend WithEvents latihan_kanan As Panel
    Friend WithEvents latihan_kiri As Panel
    Friend WithEvents latihan_flow As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents latihan_keluar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents latihan_pilih As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents latihan_pertanyaan As Panel
    Friend WithEvents latihan_1 As RadioButton
    Friend WithEvents latihan_2 As RadioButton
    Friend WithEvents latihan_4 As RadioButton
    Friend WithEvents latihan_3 As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents latihan_next As Button
    Friend WithEvents latihan_soal As TextBox

End Class
