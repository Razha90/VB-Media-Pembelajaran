Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient
Imports System.Resources
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class Home
    Dim conn As New MySqlConnection
    Dim connector As New databaseAjar
    Dim PanelPos As Integer = 0
    Public save_profile As String()
    Private currentIndex As Integer = 0
    Private isiMateriList As New List(Of IsiMateri)
    Dim idMatkul As Integer

    Private soals As New List(Of Soal)

    Private currentSoalIndex As Integer = 0
    Dim skor As Integer = 0

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

    Sub latihanPos(val As Integer)
        latihan_kanan.Visible = False
        latihan_pilih.Visible = False
        If val = 1 Then
            latihan_pilih.Visible = True
        ElseIf val = 2 Then
            latihan_kanan.Visible = True
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

        belajar_isi.BackColor = Color.LightBlue

        belajar_isi.Height = belajar_layout.Height - 50
        belajar_isi.Top = 25
        belajar_isi.Width = belajar_layout.Width - 170
        belajar_isi.Left = belajar_previous.Left + 50

        belajar_text.Width = belajar_isi.Width - 5
        belajar_text.Height = belajar_isi.Height - 80
        belajar_text.Top = belajar_isi.Top + 40
        belajar_text.Left = belajar_isi.Left - 90
        belajar_text.Font = New Font(belajar_text.Font.FontFamily, 20)
        belajar_text.ReadOnly = True

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

    Private Sub menu_latihan_Click(sender As Object, e As EventArgs) Handles menu_latihan.Click
        currentSoalIndex = 0
        Try
            latihan_flow.Controls.Clear()

            Dim latihanList As List(Of Latihan) = connector.GetLatihanData()

            If latihanList.Count > 0 Then
                Dim buttonWidth As Integer = latihan_flow.ClientSize.Width
                Dim buttonHeight As Integer = 40

                For Each latih As Latihan In latihanList
                    Dim materiButton As New Button()
                    materiButton.Text = latih.Judul
                    materiButton.Width = buttonWidth
                    materiButton.Height = buttonHeight

                    AddHandler materiButton.Click, Sub(senderBtn As Object, eBtn As EventArgs)
                                                       dapatkanLatihan(latih.Id)
                                                   End Sub

                    latihan_flow.Controls.Add(materiButton)

                Next
            Else
            End If
        Catch ex As Exception
            MessageBox.Show($"Terjadi kesalahan: {ex.Message}")
        Finally
            latihanLayout()
            latihanPos(1)
            PanelClick(2)
        End Try
    End Sub



    Private Sub dapatkanLatihan(val As Integer)
        skor = 0
        latihanPos(2)
        soals = connector.GetSoalData(val)
        currentSoalIndex = 0
        TampilkanSoal(currentSoalIndex)
    End Sub


    Private Sub TampilkanSoal(index As Integer)
        If index >= 0 AndAlso index < soals.Count Then
            Dim currentSoal As Soal = soals(index)

            latihan_soal.Text = currentSoal.Pertanyaan

            latihan_1.Text = currentSoal.Pilihan1
            latihan_2.Text = currentSoal.Pilihan2
            latihan_3.Text = currentSoal.Pilihan3
            latihan_4.Text = currentSoal.Pilihan4

            latihan_1.Checked = False
            latihan_2.Checked = False
            latihan_3.Checked = False
            latihan_4.Checked = False
        Else
            MessageBox.Show($"Selamat! Anda telah menyelesaikan semua soal dengan Skor = {(skor / soals.Count) * 100}.")
            latihanPos(1)
        End If
        latihanLayout()
    End Sub

    Private Sub latihanLayout()
        latihan_pertanyaan.Left = (Me.ClientSize.Width - latihan_pertanyaan.Width - 300) / 2
        latihan_pertanyaan.Top = (latihan_kanan.Height - latihan_pertanyaan.Height) / 2

        latihan_next.Top = (latihan_kanan.Height - latihan_next.Height) / 2
        latihan_next.Left = latihan_kanan.Width - 100

        latihan_soal.Left = (Me.ClientSize.Width - latihan_pertanyaan.Width - 300) / 2
        latihan_soal.Top = latihan_pertanyaan.Top - 100

        latihan_next.Visible = True

        If currentSoalIndex = 0 Then
        ElseIf currentSoalIndex = soals.Count Then
            latihan_next.Visible = False
        End If
    End Sub

    Private Sub latihan_keluar_Click(sender As Object, e As EventArgs) Handles latihan_keluar.Click
        PanelClick(3)
    End Sub

    Private Sub latihan_next_Click(sender As Object, e As EventArgs) Handles latihan_next.Click
        If latihan_1.Checked Or latihan_2.Checked Or latihan_3.Checked Or latihan_4.Checked Then
            SimpanJawaban(currentSoalIndex)
            currentSoalIndex += 1
            TampilkanSoal(currentSoalIndex)
            latihanLayout()
        End If

    End Sub

    Private Sub SimpanJawaban(index As Integer)
        Dim currentSoal As Soal = soals(index)
        If currentSoal.Jawaban = "pilihan_1" And latihan_1.Checked Then
            skor += 1
        ElseIf currentSoal.Jawaban = "pilihan_2" And latihan_2.Checked Then
            skor += 1


        ElseIf currentSoal.Jawaban = "pilihan_3" And latihan_3.Checked Then
            skor += 1


        ElseIf currentSoal.Jawaban = "pilihan_4" And latihan_4.Checked Then
            skor += 1
        End If
    End Sub

End Class
