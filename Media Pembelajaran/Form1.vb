Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient
Imports System.Resources

Public Class Home
    Dim conn As New MySqlConnection
    Dim connector As New databaseAjar
    Dim PanelPos As Integer = 0
    Public save_profile As String()
    Private currentIndex As Integer = 0
    Private isiMateriList As New List(Of IsiMateri)
    Dim idMatkul As Integer

    Private currentSoalIndex As Integer = 0
    Private soals As List(Of Soal)

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
        ElseIf val = 3 Then
            Latihan.Visible = False
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
        Me.Visible = True
    End Sub

    Private Sub menu_belajar_Click(sender As Object, e As EventArgs) Handles menu_belajar.Click
        belajarPanelPosi(1)
        PanelClick(1)
        belajar_flowLayout.Controls.Clear()
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
                                               LayoutBelajar()
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

        belajar_text.Width = belajar_isi.Width - 5
        belajar_text.Height = belajar_isi.Height - 80
        belajar_text.Top = belajar_isi.Top + 40
        belajar_text.Left = belajar_isi.Left - 90

        belajar_subJudul.Left = (belajar_isi.Left + belajar_isi.Width - belajar_subJudul.Width) / 2 + 10
        belajar_subJudul.Top = belajar_isi.Top + 10

        belajar_keluar.Top = belajar_isi.Height
        belajar_keluar.Left = (belajar_flowLayout.Width - belajar_keluar.Width) / 2
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dashboard.Show()
    End Sub

    Private Sub menu_keluar_Click(sender As Object, e As EventArgs) Handles menu_keluar.Click
        Me.Close()
    End Sub

    Private Sub menu_latihan_Click(sender As Object, e As EventArgs) Handles menu_latihan.Click
        PanelClick(2)
        FlowLayoutPanel1.Controls.Clear()
        Dim juduls As List(Of String) = connector.GetLatihanTitles()

        For Each judul In juduls
            Dim button As New Button()
            button.Text = judul
            AddHandler button.Click, AddressOf Button_Click
            FlowLayoutPanel1.Controls.Add(button)
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim judul As String = DirectCast(sender, Button).Text

        ' Mendapatkan ID latihan berdasarkan judul
        Dim idLatihan As Integer = connector.GetLatihanIdByJudul(judul)

        If idLatihan > 0 Then
            Dim soals As List(Of Soal) = connector.GetSoalData(idLatihan)
            ShowSoalOnMainForm(currentSoalIndex)
        Else
            MessageBox.Show("Latihan tidak ditemukan.")
        End If
    End Sub

    Private Sub ShowSoalOnMainForm(index)
        If index >= 0 AndAlso index < soals.Count Then
            Dim currentSlide As Soal = soals(index)

            lblPertanyaan.Text = currentSlide.Pertanyaan
            ' Aktifkan atau nonaktifkan tombol Previous dan Next sesuai dengan kondisi
            'belajar_previous.Enabled = index > 0
            'belajar_next.Enabled = index < isiMateriList.Count
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Navigasi ke soal berikutnya
        currentSoalIndex += 1
        ' Tampilkan soal yang baru
        ShowSoalOnMainForm(currentSoalIndex)
    End Sub


    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        ' Navigasi ke soal sebelumnya
        currentSoalIndex -= 1
        ' Tampilkan soal yang baru
        ShowSoalOnMainForm(currentSoalIndex)
    End Sub

    Private Sub materiAkses(val As Integer)
        isiMateriList = connector.GetIsiMateriById(val)
        idMatkul = val
        currentIndex = 0
        ShowMateri(currentIndex)
    End Sub

    Private Sub ShowMateri(index As Integer)
        If index >= 0 AndAlso index < isiMateriList.Count Then
            Dim currentSlide As IsiMateri = isiMateriList(index)

            belajar_subJudul.Text = currentSlide.SubJudul
            belajar_text.Text = currentSlide.Isi
            ' Gantilah 'YourVideoControl' dengan kontrol video yang sesuai
            'YourVideoControl.URL = currentSlide.Video

            ' Aktifkan atau nonaktifkan tombol Previous dan Next sesuai dengan kondisi
            belajar_previous.Enabled = index > 0
            belajar_next.Enabled = index < isiMateriList.Count
        End If
    End Sub



    Private Sub belajar_next_Click(sender As Object, e As EventArgs) Handles belajar_next.Click
        currentIndex += 1

        If currentIndex = isiMateriList.Count Then
            If connector.InsertIntoSelesaiMateri(idMatkul, save_profile(0)) Then
                MessageBox.Show("Anda telah menyelesaikan materi.")
                belajarPanelPosi(1)
                PanelClick(1)
            Else
                MessageBox.Show("Something Error.")
            End If
        Else
            ShowMateri(currentIndex)
        End If
    End Sub

    Private Sub belajar_previous_Click(sender As Object, e As EventArgs) Handles belajar_previous.Click
        'CenterGroup()
        'LayoutBelajar()
        currentIndex -= 1
        ShowMateri(currentIndex)
    End Sub

    Private Sub belajar_keluar_Click(sender As Object, e As EventArgs) Handles belajar_keluar.Click
        PanelClick(3)
        LayoutBelajar()
    End Sub

    Private Sub latihan_keluar_Click(sender As Object, e As EventArgs) Handles latihan_keluar.Click
        PanelClick(3)
    End Sub

End Class
