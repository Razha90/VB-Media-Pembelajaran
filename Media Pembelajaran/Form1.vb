Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient

Public Class Home
    Dim conn As New MySqlConnection
    Dim connector As New databaseAjar
    Dim PanelPos As Integer = 0
    Public save_profile As String()
    Private currentIndex As Integer = 0

    Sub CenterGroup()
        BackPanel.Width = Me.Width / 1.45
        BackPanel.Height = Me.Height / 2.2
        BackPanel.Left = (Me.ClientSize.Width - BackPanel.Width) / 2
        BackPanel.Top = (Me.Height - BackPanel.Height) / 2
        BackPanel.BackColor = Color.Transparent


        menu_belajar.Left = (BackPanel.Width - menu_belajar.Width) / 2
        menu_belajar.Top = (BackPanel.Height - 2 * menu_belajar.Height) / 3

        menu_latihan.Left = (BackPanel.Width - menu_latihan.Width) / 2
        menu_latihan.Top = menu_latihan.Bottom + (BackPanel.Height - 2 * menu_latihan.Height) / 3 ' Jarak dari tombol pertama

        menu_keluar.Left = (BackPanel.Width - menu_keluar.Width) / 2
        menu_keluar.Top = menu_keluar.Bottom + (BackPanel.Height - 2 * menu_keluar.Height) / 3 ' Jarak dari tombol kedua

    End Sub

    Sub belajarPanelPosi(val As Integer)
        If val = 1 Then
            belajar_default.Visible = True
            belajar_layout.Visible = False
        ElseIf val = 2 Then
            belajar_default.Visible = False
            belajar_layout.Visible = True
        End If
    End Sub

    Sub Profile_menu()
        If save_profile.Length = 0 Then
            MessageBox.Show("Maaf ada masalah dengan kondisi Login, Kembali ke Dashboard!")
        Else
            profile_panel.BackColor = Color.Transparent
            profile_nama.Text = save_profile(1)
            profile_role.Text = save_profile(5)
        End If
    End Sub

    Sub PanelPosition(val As Integer)
        If val = 1 Then
            Latihan.Visible = False
            Belajar.Visible = True
        ElseIf val = 2 Then
            Latihan.Visible = True
            Belajar.Visible = False
        End If
    End Sub

    Sub PanelClick(val As Integer)
        If PanelPos = val Then
        Else
            PanelPos = val
            PanelPosition(val)
        End If
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        CenterGroup()
        Profile_menu()
        LayoutBelajar()
        Me.Visible = True
    End Sub

    Private Sub menu_belajar_Click(sender As Object, e As EventArgs) Handles menu_belajar.Click
        belajarPanelPosi(1)
        PanelClick(1)
        Dim materiList As List(Of Materi) = connector.GetMateriData()

        Dim buttonWidth As Integer = belajar_flowLayout.ClientSize.Width
        Dim buttonHeight As Integer = 40

        For Each materi In materiList
            Dim materiButton As New Button()
            materiButton.Text = materi.Judul
            materiButton.Width = buttonWidth
            materiButton.Height = buttonHeight

            AddHandler materiButton.Click, Sub(senderBtn As Object, eBtn As EventArgs)
                                               materiAkses(materi.IdMateri)
                                               belajarPanelPosi(2)
                                           End Sub
            belajar_flowLayout.Controls.Add(materiButton)
        Next
        LayoutBelajar()
    End Sub

    Private Sub LayoutBelajar()
        belajar_next.Left = belajar_layout.Width - 65
        belajar_next.Top = (belajar_layout.Height - belajar_next.Width) / 2

        belajar_previous.Left = belajar_layout.Left / 5
        belajar_previous.Top = (belajar_layout.Height - belajar_previous.Width) / 2

        belajar_isi.BackColor = Color.Pink
        belajar_isi.Height = belajar_layout.Height - 50
        belajar_isi.Top = 25
        belajar_isi.Width = belajar_layout.Width - 170
        belajar_isi.Left = belajar_previous.Left + 50

        belajar_text.Width = belajar_isi.Width
        belajar_text.Height = belajar_isi.Height
        belajar_text.Top = belajar_isi.Top
        belajar_text.Left = belajar_isi.Left
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dashboard.Show()
    End Sub

    Private Sub menu_keluar_Click(sender As Object, e As EventArgs) Handles menu_keluar.Click
        Me.Close()
    End Sub

    Private Sub menu_latihan_Click(sender As Object, e As EventArgs) Handles menu_latihan.Click
        PanelClick(2)
    End Sub

    Private Sub materiAkses(val As Integer)
        Dim isiMateriList As List(Of IsiMateri) = connector.GetIsiMateriById(val)

        ' Update tata letak dan tombol berdasarkan isiMateriList
        UpdateLayout(isiMateriList)
    End Sub



    Private Sub belajar_next_Click(sender As Object, e As EventArgs) Handles belajar_previous.Click
        CenterGroup()
        LayoutBelajar()
    End Sub

    Private Sub belajar_previous_Click(sender As Object, e As EventArgs) Handles belajar_next.Click
        CenterGroup()
        LayoutBelajar()

    End Sub
End Class
