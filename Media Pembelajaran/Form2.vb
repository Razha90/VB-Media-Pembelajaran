Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Dashboard
    Dim conn As New MySqlConnection
    Dim Connector As New DatabaseConnection
    Dim PositionPage As Integer = 0
    Dim Save_Profile As String()


    ' Mengatur Menu yang akan ditampilkan
    Sub PositionMenu(val As Integer)
        If val = 1 Then
            Database.Visible = True
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = False
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False

            Flow_Menu.Controls.SetChildIndex(Database, 0)
            Flow_Menu.Controls.SetChildIndex(Developer, 1)

        ElseIf val = 2 Then
            Database.Visible = True
            Login.Visible = True
            Daftar.Visible = True
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False
            Profile.Visible = False

            Flow_Menu.Controls.SetChildIndex(Login, 0)
            Flow_Menu.Controls.SetChildIndex(Daftar, 1)
            Flow_Menu.Controls.SetChildIndex(Database, 2)
            Flow_Menu.Controls.SetChildIndex(Developer, 3)

        ElseIf val = 3 Then
            Database.Visible = False
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = True
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False

            Flow_Menu.Controls.SetChildIndex(Profile, 0)
            Flow_Menu.Controls.SetChildIndex(Developer, 1)

        ElseIf val = 4 Then
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = True
            Materi.Visible = True
            Latihan.Visible = True
            Murid.Visible = True
            Database.Visible = True

            Flow_Menu.Controls.SetChildIndex(Profile, 0)
            Flow_Menu.Controls.SetChildIndex(Materi, 1)
            Flow_Menu.Controls.SetChildIndex(Latihan, 2)
            Flow_Menu.Controls.SetChildIndex(Murid, 3)
            Flow_Menu.Controls.SetChildIndex(Database, 4)
            Flow_Menu.Controls.SetChildIndex(Developer, 5)


            Database.Top = 227
            Profile.Top = 3
            Materi.Top = 59
            Latihan.Top = 115
            Murid.Top = 171
        End If
    End Sub

    ' Mengatur Posisi Panel
    Sub PannelPosition(val As Integer)
        Content_Display.Visible = False
        Login_Container.Visible = False
        Daftar_Container.Visible = False
        Database_Container.Visible = False
        Profile_Container.Visible = False
        Materi_Container.Visible = False
        Latihan_Container.Visible = False
        Murid_Container.Visible = False
        materi_container_isi.Visible = False
        container_soal.Visible = False
        Developer_Panel.Visible = False
        If val = 0 Then
            Content_Display.Visible = True
        ElseIf val = 1 Then
            Login_Container.Visible = True
        ElseIf val = 2 Then
            Daftar_Container.Visible = True
        ElseIf val = 3 Then
            Database_Container.Visible = True
        ElseIf val = 4 Then
            Profile_Container.Visible = True
        ElseIf val = 5 Then
            Materi_Container.Visible = True
        ElseIf val = 6 Then
            Latihan_Container.Visible = True
        ElseIf val = 7 Then
            Murid_Container.Visible = True
        ElseIf val = 8 Then
            materi_container_isi.Visible = True
        ElseIf val = 9 Then
            container_soal.Visible = True
        ElseIf val = 10 Then
            Developer_Panel.Visible = True
        End If
    End Sub

    ' mengatur Active Menu
    Sub ActivePage(val As Integer)
        Active_Login.Visible = False
        Active_Daftar.Visible = False
        Active_Database.Visible = False
        Active_Profile.Visible = False
        Active_Materi.Visible = False
        Active_Latihan.Visible = False
        Active_Murid.Visible = False
        Developer_Active.Visible = False
        If val = 0 Then
        ElseIf val = 1 Then
            Active_Login.Visible = True
        ElseIf val = 2 Then
            Active_Daftar.Visible = True
        ElseIf val = 3 Then
            Active_Database.Visible = True
        ElseIf val = 4 Then
            Active_Profile.Visible = True
        ElseIf val = 5 Then
            Active_Materi.Visible = True
        ElseIf val = 6 Then
            Active_Latihan.Visible = True
        ElseIf val = 7 Then
            Active_Murid.Visible = True
        ElseIf val = 8 Then
            Developer_Active.Visible = True
        End If
    End Sub

    Sub ConnectorActivities()
        If Connector.ReadJsonFile() Then
            If Connector.ConnectToDatabase() Then
                PositionMenu(2)
                Dim GetData As String() = Connector.GetDataBaseInfo()
                Text_Server.Text = GetData(0)
                Text_Port.Text = GetData(1)
                TextBox_Data.Text = GetData(2)
                Text_User.Text = GetData(3)
                Text_Password.Text = GetData(4)
            Else
                PositionMenu(1)
                MessageBox.Show("Gagal terhubung ke database, periksa koneksi database!")
            End If
        Else
            PositionMenu(1)
            MessageBox.Show("Silahkan untuk melakukan simpan database terlebih dahulu!")
        End If
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectorActivities()
        ActivePage(0)
        PannelPosition(0)
        dgMateri.AllowUserToAddRows = False
        materi_list.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Exit_Button_Click(sender As Object, e As EventArgs) Handles Exit_Button.Click
        Me.Close()
    End Sub

    Private Sub Minimize_Button_Click(sender As Object, e As EventArgs) Handles Minimize_Button.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Connection_Test_Click(sender As Object, e As EventArgs) Handles Connection_Test.Click
        If Connector.CheckConnection(Text_Server.Text, Text_Port.Text.Trim(), TextBox_Data.Text, Text_Password.Text, Text_User.Text) Then
            MessageBox.Show("Berhasil Terhubung")
        Else
            MessageBox.Show("Gagal Terhubung ke Database")
        End If
    End Sub

    Private Sub Connection_Save_Click(sender As Object, e As EventArgs) Handles Connection_Save.Click
        If Connector.CheckConnection(Text_Server.Text.Trim(), Text_Port.Text.Trim(), TextBox_Data.Text.Trim(), Text_Password.Text.Trim(), Text_User.Text.Trim()) Then
            If Connector.CreateJson(Text_Server.Text, Text_Port.Text.Trim(), TextBox_Data.Text.Trim(), Text_Password.Text.Trim(), Text_User.Text.Trim()) Then
                MessageBox.Show("Database Berhasil Disimpan")
                If Connector.MigrateDatabase() Then
                    PositionPage = 0
                    ConnectorActivities()
                    ActivePage(0)
                    PannelPosition(0)
                Else
                    MessageBox.Show("Migrasi Database Gagal Dilakukan Silakan!")
                End If
            Else
                MessageBox.Show("Gagal Menyimpan Database!")
            End If
        Else
            MessageBox.Show("Database yang coba kamu simpan tidak dapat terhubung!!")
        End If
    End Sub

    '''''''' ANIMATION ''''''''''''
    Private Sub Exit_Button_MouseEnter(sender As Object, e As EventArgs) Handles Exit_Button.MouseEnter
        Exit_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, Exit_Button.BackColor)
    End Sub

    Private Sub Exit_Button_MouseLeave(sender As Object, e As EventArgs) Handles Exit_Button.MouseLeave
        Exit_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, Exit_Button.BackColor)
    End Sub

    Private Sub Database_Label_Click(sender As Object, e As EventArgs) Handles Database_Label.Click
        If PositionPage <> 3 Then
            ActivePage(3)
            PannelPosition(3)
            PositionPage = 3
        Else

        End If
    End Sub
    Private Sub Database_MouseClick(sender As Object, e As MouseEventArgs) Handles Database.MouseClick
        If PositionPage <> 3 Then
            ActivePage(3)
            PannelPosition(3)
            PositionPage = 3
        Else

        End If
    End Sub
    Private Sub Database_Icon_MouseClick(sender As Object, e As MouseEventArgs) Handles Database_Icon.MouseClick
        If PositionPage <> 3 Then
            ActivePage(3)
            PannelPosition(3)
            PositionPage = 3
        Else

        End If
    End Sub

    Private Sub Label_Login_Click(sender As Object, e As EventArgs) Handles Label_Login.Click
        If PositionPage <> 1 Then
            ActivePage(1)
            PannelPosition(1)
            PositionPage = 1
        Else

        End If
    End Sub
    Private Sub Login_MouseClick(sender As Object, e As MouseEventArgs) Handles Login.MouseClick
        If PositionPage <> 1 Then
            ActivePage(1)
            PannelPosition(1)
            PositionPage = 1
        Else

        End If
    End Sub
    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If PositionPage <> 1 Then
            ActivePage(1)
            PannelPosition(1)
            PositionPage = 1
        Else

        End If
    End Sub

    Private Sub Daftar_Label_Click(sender As Object, e As EventArgs) Handles Daftar_Label.Click
        If PositionPage <> 2 Then
            ActivePage(2)
            PannelPosition(2)
            PositionPage = 2
        Else

        End If
    End Sub
    Private Sub Icon_Daftar_Click(sender As Object, e As EventArgs) Handles Icon_Daftar.Click
        If PositionPage <> 2 Then
            ActivePage(2)
            PannelPosition(2)
            PositionPage = 2
        Else

        End If
    End Sub
    Private Sub Daftar_Click(sender As Object, e As EventArgs) Handles Daftar.Click
        If PositionPage <> 2 Then
            ActivePage(2)
            PannelPosition(2)
            PositionPage = 2
        Else

        End If
    End Sub

    Private Sub Profile_Label_Click(sender As Object, e As EventArgs) Handles Profile_Label.Click
        If PositionPage <> 4 Then
            ActivePage(4)
            PannelPosition(4)
            PositionPage = 4
        Else

        End If
    End Sub
    Private Sub Icon_Profile_Click(sender As Object, e As EventArgs) Handles Icon_Profile.Click
        If PositionPage <> 4 Then
            ActivePage(4)
            PannelPosition(4)
            PositionPage = 4
        Else

        End If
    End Sub
    Private Sub Profile_Click(sender As Object, e As EventArgs) Handles Profile.Click
        If PositionPage <> 4 Then
            ActivePage(4)
            PannelPosition(4)
            PositionPage = 4
        Else

        End If
    End Sub

    Private Sub Materi_Label_Click(sender As Object, e As EventArgs) Handles Materi_Label.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
            GetMateri()
        Else

        End If
    End Sub
    Private Sub Icon_Materi_Click(sender As Object, e As EventArgs) Handles Icon_Materi.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
            GetMateri()

        Else

        End If
    End Sub
    Private Sub Materi_Click(sender As Object, e As EventArgs) Handles Materi.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
            GetMateri()
        Else

        End If
    End Sub

    Private Sub Latihan_Label_Click(sender As Object, e As EventArgs) Handles Latihan_Label.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
            refreshLatihanJudul()
        Else

        End If
    End Sub
    Private Sub Icon_Latihan_Click(sender As Object, e As EventArgs) Handles Icon_Latihan.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
            refreshLatihanJudul()
        Else

        End If
    End Sub
    Private Sub Latihan_Click(sender As Object, e As EventArgs) Handles Latihan.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
            refreshLatihanJudul()
        Else

        End If
    End Sub

    Private Sub Murid_Label_Click(sender As Object, e As EventArgs) Handles Murid_Label.Click
        If PositionPage <> 7 Then
            ActivePage(7)
            PannelPosition(7)
            PositionPage = 7
        Else

        End If
    End Sub
    Private Sub Icon_Murid_Click(sender As Object, e As EventArgs) Handles Icon_Murid.Click
        If PositionPage <> 7 Then
            ActivePage(7)
            PannelPosition(7)
            PositionPage = 7
        Else

        End If
    End Sub
    Private Sub Murid_Click(sender As Object, e As EventArgs) Handles Murid.Click
        If PositionPage <> 7 Then
            ActivePage(7)
            PannelPosition(7)
            PositionPage = 7
        Else

        End If
    End Sub

    Private Sub Developer_Label_Click(sender As Object, e As EventArgs) Handles Developer_Label.Click
        If PositionPage <> 9 Then
            ActivePage(8)
            PannelPosition(10)
            PositionPage = 9
        Else

        End If
    End Sub

    Private Sub Developer_Icon_Click(sender As Object, e As EventArgs) Handles Developer_Icon.Click
        If PositionPage <> 9 Then
            ActivePage(8)
            PannelPosition(10)
            PositionPage = 9
        Else

        End If
    End Sub

    Private Sub Developer_Click(sender As Object, e As EventArgs) Handles Developer.Click
        If PositionPage <> 9 Then
            ActivePage(8)
            PannelPosition(10)
            PositionPage = 9
        Else

        End If
    End Sub



    Private Sub Daftar_Button_Click(sender As Object, e As EventArgs) Handles Daftar_Button.Click
        Dim errorMes As String = ""
        Dim T_Nama As String = ""
        Dim T_Username As String = ""
        Dim T_Email As String = ""
        Dim T_Password As String = ""
        Dim T_Pertanyaan As String = ""
        Dim T_Jawaban As String = ""
        Dim T_Role As String = ""

        If Daftar_Nama.Text.Length >= 5 AndAlso Daftar_Nama.Text.Length <= 18 Then
            Daftar_Nama.BackColor = Color.PaleGreen
            Daftar_Nama.ForeColor = Color.White
            T_Nama = Daftar_Nama.Text.Trim()
        Else
            errorMes &= vbCrLf & "Perhatikan Nama Minimal 5 dan Maksimal 18!"
            Daftar_Nama.BackColor = Color.Tomato
            Daftar_Nama.ForeColor = Color.White
        End If
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        If Regex.IsMatch(Daftar_Email.Text.Trim(), emailPattern) Then
            Daftar_Email.BackColor = Color.PaleGreen
            Daftar_Email.ForeColor = Color.White
            T_Email = Daftar_Email.Text.Trim()
        Else
            errorMes &= vbCrLf & "Periksa Email Kamu Kembali"
            Daftar_Email.BackColor = Color.Tomato
            Daftar_Email.ForeColor = Color.White
        End If
        If Daftar_Username.Text.Length >= 5 AndAlso Daftar_Username.Text.Length <= 18 Then
            Daftar_Username.BackColor = Color.PaleGreen
            Daftar_Username.ForeColor = Color.White
            T_Username = Daftar_Username.Text.Trim()
        Else
            errorMes &= vbCrLf & "Perhatikan UserName Minimal 5 dan Maksimal 18!"
            Daftar_Username.BackColor = Color.Tomato
            Daftar_Username.ForeColor = Color.White
        End If
        If Daftar_Password.TextLength >= 6 AndAlso Daftar_Password.TextLength <= 18 Then
            Daftar_Password.BackColor = Color.PaleGreen
            Daftar_Password.ForeColor = Color.White
            If Daftar_Password.Text.Trim() = Daftar_RePassword.Text.Trim() Then
                Daftar_RePassword.BackColor = Color.PaleGreen
                Daftar_RePassword.ForeColor = Color.White
                T_Password = Daftar_Password.Text.Trim()
            Else
                errorMes &= vbCrLf & "Perhatikan Reply Password Not Match!"
                Daftar_RePassword.BackColor = Color.Tomato
                Daftar_RePassword.ForeColor = Color.White
            End If
        Else
            errorMes &= vbCrLf & "Perhatikan Password Minimal 6 dan Maksimal 18!"
            Daftar_Password.BackColor = Color.Tomato
            Daftar_Password.ForeColor = Color.White
        End If
        If Daftar_Pertanyaan.Text.Length >= 5 Then
            Label_Pertanyaan.Text = "Pertanyaan"
            Label_Pertanyaan.ForeColor = Color.PaleGreen
            T_Pertanyaan = Daftar_Pertanyaan.Text.Trim()
        Else
            errorMes &= vbCrLf & "Perhatikan Pertanyaan Minimal Panjang 5!"
            Label_Pertanyaan.Text = "Pertanyaan * Tidak Boleh Kosong"
            Label_Pertanyaan.ForeColor = Color.Tomato
        End If
        If Daftar_Jawaban.Text.Length >= 0 Then
            Label_Jawaban.Text = "Jawaban"
            Label_Jawaban.ForeColor = Color.PaleGreen
            T_Jawaban = Daftar_Jawaban.Text.Trim()
        Else
            errorMes &= vbCrLf & "Perhatikan Jawaban Kamu Kosong!"
            Label_Jawaban.Text = "Jawaban * Tidak Boleh Kosong"
            Label_Jawaban.ForeColor = Color.Tomato
        End If

        If Connector.CheckAdminRole() Then
            T_Role = "Murid"
        Else
            T_Role = "Pengajar"

        End If

        If errorMes.Length > 0 Then
            MessageBox.Show(errorMes)
        Else
            If Connector.DaftarAkun(T_Nama, T_Username, T_Email, T_Password, T_Pertanyaan, T_Jawaban, T_Role) Then
                MessageBox.Show($"Pendaftar akun Berhasil, Silakan Login {T_Nama}")
                Daftar_Nama.BackColor = Color.White
                Daftar_Nama.ForeColor = Color.Black
                Daftar_Nama.Text = ""

                Daftar_Email.BackColor = Color.White
                Daftar_Email.ForeColor = Color.Black
                Daftar_Email.Text = ""

                Daftar_Username.BackColor = Color.White
                Daftar_Username.ForeColor = Color.Black
                Daftar_Username.Text = ""

                Daftar_Password.BackColor = Color.White
                Daftar_Password.ForeColor = Color.Black
                Daftar_Password.Text = ""

                Daftar_RePassword.BackColor = Color.White
                Daftar_RePassword.ForeColor = Color.Black
                Daftar_RePassword.Text = ""

                Label_Pertanyaan.ForeColor = Color.Black
                Daftar_Pertanyaan.Text = ""

                Label_Jawaban.ForeColor = Color.Black
                Daftar_Jawaban.Text = ""
            Else
                MessageBox.Show($"Pendaftar akun Gagal!")
            End If
        End If
    End Sub

    Private Sub Login_Button_Click(sender As Object, e As EventArgs) Handles Login_Button.Click
        Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Dim GetData As String()
        If Regex.IsMatch(Login_user.Text.Trim(), emailPattern) Then
            GetData = Connector.Login(Login_user.Text.Trim, Login_Password.Text.Trim(), True)
        Else
            GetData = Connector.Login(Login_user.Text.Trim, Login_Password.Text.Trim(), False)
        End If

        If GetData IsNot Nothing AndAlso GetData.Length > 0 AndAlso GetData(0) IsNot Nothing Then
            Save_Profile = GetData
            PositionPage = 0
            ActivePage(0)
            PannelPosition(0)
            profile_name.Text = $"Nama : {Save_Profile(1)}"
            profile_email.Text = $"Email : {Save_Profile(3)}"
            profile_roles.Text = $"Kamu adalah {Save_Profile(5)}"

            If Save_Profile(5) = "Murid" Then
                PositionMenu(3)
            Else
                PositionMenu(4)

            End If
        Else
            MessageBox.Show("Login Gagal. Username atau Email dan password salah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Logout_Click(sender As Object, e As EventArgs) Handles Logout.Click
        PositionMenu(2)
        Array.Clear(Save_Profile, 0, Save_Profile.Length)
        ActivePage(0)
        PannelPosition(0)
    End Sub

    Sub GetMateri()
        dgMateri.DataSource = Connector.GetMateriData()
        dgMateri.Columns("id_materi").Visible = False
    End Sub

    Sub GetIsiMateri()
        If materi_list.Text = "" Then
            MessageBox.Show("Kamu Belum Memasukkan Judul Materi")
        Else
            dgIsiMateri.DataSource = Connector.GetIsiMateri(materi_list.Text)
            dgIsiMateri.Columns("id_materi").Visible = False
            dgIsiMateri.Columns("id_isi").Visible = False
        End If
    End Sub

    Private Sub materi_getdata_Click(sender As Object, e As EventArgs) Handles materi_getdata.Click
        GetMateri()
    End Sub


    Private Sub materi_update_Click(sender As Object, e As EventArgs) Handles materi_update.Click
        Dim selectedRow As DataGridViewRow = dgMateri.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim rowIndex As Integer = selectedRow.Index
            Dim idMateri As Integer = Convert.ToInt32(selectedRow.Cells("id_materi").Value)
            Dim columnName As String = dgMateri.CurrentCell.OwningColumn.Name
            Dim newValue As String = Convert.ToString(dgMateri.CurrentCell.Value)

            Connector.UpdateMateriField(idMateri, columnName, newValue)
            GetMateri()
        End If
    End Sub

    Private Sub materi_tambah_Click(sender As Object, e As EventArgs) Handles materi_tambah.Click
        If Connector.InsertMateri(materi_insert.Text.Trim()) Then
            materi_insert.Text = ""
            GetMateri()
        Else
            MessageBox.Show("Gagal Menambahkan Judul")
        End If
    End Sub

    Private Sub materi_judul_but_Click(sender As Object, e As EventArgs) Handles materi_judul_but.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
            GetMateri()
        Else

        End If
    End Sub

    Private Sub SearchList()
        materi_list.Items.Clear()
        Dim judulList As List(Of String) = Connector.SearchListMateri()
        materi_list.Items.AddRange(judulList.ToArray())
    End Sub

    Private Sub materi_isi_Click(sender As Object, e As EventArgs) Handles materi_isi.Click
        If PositionPage <> 8 Then
            PannelPosition(8)
            PositionPage = 8
            SearchList()
        Else

        End If

    End Sub

    Private Sub materi_isi_tem_Click(sender As Object, e As EventArgs) Handles materi_isi_tem.Click
        GetIsiMateri()
    End Sub

    Private Sub materi_hapus_Click(sender As Object, e As EventArgs) Handles materi_hapus.Click
        Dim selectedRow As DataGridViewRow = dgMateri.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim idMateri As Integer = Convert.ToInt32(selectedRow.Cells("id_materi").Value)

            ' Panggil fungsi DeleteMateri dari instance databaseHandler
            If Connector.DeleteMateri(idMateri) Then
                GetMateri()
            Else
                MessageBox.Show("Gagal menghapus data.")
            End If
        Else
            MessageBox.Show("Pilih baris yang ingin dihapus.")
        End If
    End Sub

    Private Sub mater_isi_tam_Click(sender As Object, e As EventArgs) Handles mater_isi_tam.Click
        Dim subJudul As String = materi_isi_judul.Text
        Dim page As Integer = materi_page.Text
        Dim isi As String = materi_isi_isi.Text.Trim()
        Dim vidio As String = materi_isi_video.Text
        Dim idMateri As Integer = Connector.GetIdMateriByJudul(materi_list.Text)
        If idMateri = 0 Then
            MessageBox.Show("Harap Temukan Judul!!")
        Else
            If Connector.InsertIsiMateri(subJudul, page, isi, vidio, idMateri) Then
                GetIsiMateri()
                materi_isi_judul.Text = ""
                materi_page.Value = 1
                materi_isi_isi.Text = ""
                materi_isi_video.Text = ""
            Else
                MessageBox.Show("Gagal menyisipkan data.")
            End If
        End If

    End Sub

    Private Sub materi_isi_hapus_Click(sender As Object, e As EventArgs) Handles materi_isi_hapus.Click
        Dim selectedRow As DataGridViewRow = dgIsiMateri.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim idIsi As Integer = Convert.ToInt32(selectedRow.Cells("id_isi").Value)

            If Connector.DeleteIsiMateri(idIsi) Then
                GetIsiMateri()
            Else
                MessageBox.Show("Gagal menghapus data.")
            End If
        Else
            MessageBox.Show("Pilih baris yang ingin dihapus.")
        End If
    End Sub

    Private Sub materi_isi_per_Click(sender As Object, e As EventArgs) Handles materi_isi_per.Click
        For Each row As DataGridViewRow In dgIsiMateri.Rows
            ' Pastikan baris bukan baris header
            If Not row.IsNewRow Then
                ' Ambil nilai dari setiap sel dalam baris
                Dim idIsi As Long = Convert.ToInt64(row.Cells("id_isi").Value)
                Dim subJudul As String = Convert.ToString(row.Cells("sub_judul").Value)
                Dim page As Integer = Convert.ToInt32(row.Cells("page").Value)
                Dim isi As String = Convert.ToString(row.Cells("isi").Value)
                Dim vidio As String = Convert.ToString(row.Cells("vidio").Value)
                Dim idMateri As Long = Convert.ToInt64(row.Cells("id_materi").Value)

                If Connector.UpdateIsiMateri(idIsi, subJudul, page, isi, vidio, idMateri) Then
                Else
                    MessageBox.Show("Gagal memperbarui data.")
                End If
            End If
        Next
    End Sub

    Private Sub materi_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles materi_list.SelectedIndexChanged
        GetIsiMateri()
    End Sub

    Private Sub profile_gopage_Click(sender As Object, e As EventArgs) Handles profile_gopage.Click
        Dim gopage As New Home
        gopage.save_profile = Save_Profile
        gopage.Show()
        Me.Hide()
    End Sub

    ''' ------------------------------------ Latihan

    Private Sub refreshLatihanJudul()
        latihan_dataGrid.DataSource = Connector.GetLatihanData()
        latihan_dataGrid.Columns("id_latihan").Visible = False
        latihan_dataGrid.AllowUserToAddRows = False
    End Sub

    Private Sub latihan_segarkan_Click(sender As Object, e As EventArgs) Handles latihan_segarkan.Click
        refreshLatihanJudul()
    End Sub

    Private Sub latihan_tambah_Click(sender As Object, e As EventArgs) Handles latihan_tambah.Click
        If String.IsNullOrEmpty(latihan_judul.Text) Then
            MessageBox.Show("Judul Masih Kosong!!")
        Else
            If Connector.AddLatihanData(latihan_judul.Text) Then
                refreshLatihanJudul()
            Else
                MessageBox.Show("Gagak Menambahkan Judul!!")
            End If
        End If
    End Sub

    Private Sub latihan_perbarui_Click(sender As Object, e As EventArgs) Handles latihan_perbarui.Click
        ' Mendapatkan nilai dari baris yang dipilih
        Dim selectedRow As DataGridViewRow = latihan_dataGrid.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim newValue As String = Convert.ToString(latihan_dataGrid.CurrentCell.Value)
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells("id_latihan").Value)
            Dim judul As String = latihan_dataGrid.CurrentCell.OwningColumn.Name


            Connector.UpdateLatihanField(id, judul, newValue)
            refreshLatihanJudul()
        End If

    End Sub

    Private Sub latihan_hapus_Click(sender As Object, e As EventArgs) Handles latihan_hapus.Click
        Dim selectedRow As DataGridViewRow = latihan_dataGrid.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim idLatihan As Integer = Convert.ToInt32(selectedRow.Cells("id_latihan").Value)

            ' Konfirmasi penghapusan (opsional)
            Dim confirmationResult As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data terpilih?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirmationResult = DialogResult.Yes Then
                Connector.DeleteLatihan(idLatihan)

                refreshLatihanJudul()
            End If
        Else
            MessageBox.Show("Pilih baris terlebih dahulu untuk dihapus.")
        End If
    End Sub

    Private Sub latihan_soal_Click(sender As Object, e As EventArgs) Handles latihan_soal.Click
        soal_jawaban.DropDownStyle = ComboBoxStyle.DropDownList
        soal_jawaban.Items.Add("pilihan_1")
        soal_jawaban.Items.Add("pilihan_2")
        soal_jawaban.Items.Add("pilihan_3")
        soal_jawaban.Items.Add("pilihan_4")

        soal_list.DataSource = Connector.GetLatihanTitles()
        soal_list.DropDownStyle = ComboBoxStyle.DropDownList

        If PositionPage <> 9 Then
            PannelPosition(9)
            PositionPage = 9
        Else

        End If
    End Sub

    Private Sub latihan_back_Click(sender As Object, e As EventArgs) Handles latihan_back.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
            refreshLatihanJudul()
        Else

        End If
    End Sub

    Private Sub soal_add_Click(sender As Object, e As EventArgs) Handles soal_add.Click
        If Not String.IsNullOrWhiteSpace(soal_soal.Text) AndAlso
    Not String.IsNullOrWhiteSpace(soal_a.Text) AndAlso
    Not String.IsNullOrWhiteSpace(soal_b.Text) AndAlso
        Not String.IsNullOrWhiteSpace(soal_c.Text) AndAlso
        Not String.IsNullOrWhiteSpace(soal_jawaban.Text) AndAlso
        Not String.IsNullOrWhiteSpace(soal_d.Text) Then
            Dim val As Integer = Connector.GetSelectedLatihanID(soal_list.Text)

            If Connector.InsertNewSoal(soal_soal.Text, soal_a.Text, soal_b.Text, soal_c.Text, soal_d.Text, soal_jawaban.Text, val) Then
                refresh_Latihan()
            Else
                MessageBox.Show("Gagal Memasukkan Data")

            End If
        Else
            MessageBox.Show("Semua TextBox harus diisi. Silakan lengkapi data.")
        End If
    End Sub

    Private Sub refresh_Latihan()
        Dim val As Integer = Connector.GetSelectedLatihanID(soal_list.Text)
        soal_dataGrid.DataSource = Connector.GetSoalDataByLatihanID(val)
        soal_dataGrid.Columns("id_soal").Visible = False
        soal_dataGrid.Columns("id_latihan").Visible = False
        soal_dataGrid.AllowUserToAddRows = False
    End Sub

    Private Sub soal_refresh_Click(sender As Object, e As EventArgs) Handles soal_refresh.Click
        If soal_list.Text = "" Then
            MessageBox.Show("Harap Pilih Latihan!")
        Else
            refresh_Latihan()
        End If
    End Sub

    Private Sub soal_hapus_Click(sender As Object, e As EventArgs) Handles soal_hapus.Click
        Dim selectedRow As DataGridViewRow = soal_dataGrid.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim idSoal As Integer = Convert.ToInt32(selectedRow.Cells("id_soal").Value)
            Connector.DeleteSoal(idSoal)
            refresh_Latihan()
        Else
            MessageBox.Show("Pilih soal yang akan dihapus.")
        End If
    End Sub

    Private Sub soal_update_Click(sender As Object, e As EventArgs) Handles soal_update.Click
        Dim selectedRow As DataGridViewRow = soal_dataGrid.CurrentRow

        If selectedRow IsNot Nothing Then
            Dim idSoal As Integer = Convert.ToInt32(selectedRow.Cells("id_soal").Value)
            Dim pertanyaan As String = selectedRow.Cells("pertanyaan").Value.ToString()
            Dim pilihan1 As String = selectedRow.Cells("pilihan_1").Value.ToString()
            Dim pilihan2 As String = selectedRow.Cells("pilihan_2").Value.ToString()
            Dim pilihan3 As String = selectedRow.Cells("pilihan_3").Value.ToString()
            Dim pilihan4 As String = selectedRow.Cells("pilihan_4").Value.ToString()
            Dim jawaban As String = selectedRow.Cells("jawaban").Value.ToString()
            Dim idLatihan As Integer = selectedRow.Cells("id_latihan").Value.ToString()

            ' Memperbarui data soal dalam database
            Connector.UpdateSoal(idSoal, pertanyaan, pilihan1, pilihan2, pilihan3, pilihan4, jawaban, idLatihan)

            ' Memperbarui DataGridView setelah pembaruan
            refresh_Latihan()
        Else
            MessageBox.Show("Pilih soal yang akan diperbarui.")
        End If
    End Sub

End Class