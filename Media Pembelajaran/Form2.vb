Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports System.IO

Public Class Dashboard
    Dim conn As New MySqlConnection
    Dim Server As String
    Dim Database_Name As String
    Dim Userid As String
    Dim Password As String

    Private Function ReadJsonFile() As Boolean
        Try
            Dim jsonFilePath As String = "saveDatabase.json"

            Dim jsonContent As String = File.ReadAllText(jsonFilePath)

            Dim savedDatabase As Database = JsonConvert.DeserializeObject(Of Database)(jsonContent)

            Server = savedDatabase.server
            Database_Name = savedDatabase.database
            Password = savedDatabase.password
            Userid = savedDatabase.userid
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ConnectToDatabase()
        If ReadJsonFile() Then
            Try
                conn.ConnectionString = $"server={Server};database={Database_Name};userid={Userid};password={Password}"
                conn.Open()
                PositionMenu(2)
            Catch ex As Exception
                MessageBox.Show("Maaf Gagal Terhubung Ke Database database server!")
                PositionMenu(1)
            End Try
        Else
            MessageBox.Show("Silahkan Simpan Database Di Menu Database!")
            PositionMenu(1)
        End If
    End Sub

    Private Sub CreateJson()
        Try
            Dim saveDatabase As New Database With {
                .server = "John",
                .database = "Doe",
                .password = "",
                .userid = "sasa"
            }

            Dim json As String = JsonConvert.SerializeObject(saveDatabase)
            System.IO.File.WriteAllText("saveDatabase.json", json)
        Catch ex As Exception

        End Try
    End Sub

    Sub PositionMenu(val As Integer)
        If val = 1 Then
            Database.Visible = True
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = False
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False

            Database.Top = 3
        ElseIf val = 2 Then
            Database.Visible = True
            Login.Visible = True
            Daftar.Visible = True
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False
            Profile.Visible = False

            Database.Top = 3
            Login.Top = 59
            Daftar.Top = 115
        ElseIf val = 3 Then
            Database.Visible = False
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = True
            Materi.Visible = False
            Latihan.Visible = False
            Murid.Visible = False
        ElseIf val = 4 Then
            Database.Visible = True
            Login.Visible = False
            Daftar.Visible = False
            Profile.Visible = True
            Materi.Visible = True
            Latihan.Visible = True
            Murid.Visible = True
        End If
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectToDatabase()
    End Sub

    Private Sub Exit_Button_Click(sender As Object, e As EventArgs) Handles Exit_Button.Click
        Me.Close()
    End Sub

    Private Sub Minimize_Button_Click(sender As Object, e As EventArgs) Handles Minimize_Button.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class