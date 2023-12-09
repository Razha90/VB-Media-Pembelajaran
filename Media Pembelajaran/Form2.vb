Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.IO
Imports System.Text.RegularExpressions

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

        ElseIf val = 3 Then
            Database.Visible = False
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = True
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False

            Flow_Menu.Controls.SetChildIndex(Profile, 0)
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
        End If
    End Sub

    Sub ConnectorActivities()
        If Connector.ReadJsonFile() Then
            If Connector.ConnectToDatabase() Then
                PositionMenu(2)
                Dim GetData As String() = Connector.GetDataBaseInfo()
                Text_Server.Text = GetData(0)
                TextBox_Data.Text = GetData(1)
                Text_User.Text = GetData(2)
                Text_Password.Text = GetData(3)
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
    End Sub

    Private Sub Exit_Button_Click(sender As Object, e As EventArgs) Handles Exit_Button.Click
        Me.Close()
    End Sub

    Private Sub Minimize_Button_Click(sender As Object, e As EventArgs) Handles Minimize_Button.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Connection_Test_Click(sender As Object, e As EventArgs) Handles Connection_Test.Click
        If Connector.CheckConnection(Text_Server.Text, TextBox_Data.Text, Text_Password.Text, Text_User.Text) Then
            MessageBox.Show("Berhasil Terhubung")
        Else
            MessageBox.Show("Gagal Terhubung ke Database")
        End If
    End Sub

    Private Sub Connection_Save_Click(sender As Object, e As EventArgs) Handles Connection_Save.Click
        If Connector.CheckConnection(Text_Server.Text, TextBox_Data.Text, Text_Password.Text, Text_User.Text) Then
            If Connector.CreateJson(Text_Server.Text, TextBox_Data.Text, Text_Password.Text, Text_User.Text) Then
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
        Else

        End If
    End Sub
    Private Sub Icon_Materi_Click(sender As Object, e As EventArgs) Handles Icon_Materi.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
        Else

        End If
    End Sub
    Private Sub Materi_Click(sender As Object, e As EventArgs) Handles Materi.Click
        If PositionPage <> 5 Then
            ActivePage(5)
            PannelPosition(5)
            PositionPage = 5
        Else

        End If
    End Sub

    Private Sub Latihan_Label_Click(sender As Object, e As EventArgs) Handles Latihan_Label.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
        Else

        End If
    End Sub
    Private Sub Icon_Latihan_Click(sender As Object, e As EventArgs) Handles Icon_Latihan.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
        Else

        End If
    End Sub
    Private Sub Latihan_Click(sender As Object, e As EventArgs) Handles Latihan.Click
        If PositionPage <> 6 Then
            ActivePage(6)
            PannelPosition(6)
            PositionPage = 6
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

    Private Sub Daftar_Button_Click(sender As Object, e As EventArgs) Handles Daftar_Button.Click
        Dim errorMes As String = ""
        Dim T_Nama As String = ""
        Dim T_Username As String = ""
        Dim T_Email As String = ""
        Dim T_Password As String = ""
        Dim T_Pertanyaan As String = ""
        Dim T_Jawaban As String = ""
        Dim T_Role As String = "Pengajar"

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
            PositionMenu(4)
        Else
            MessageBox.Show("Login Gagal. Username atau Email dan password salah.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class