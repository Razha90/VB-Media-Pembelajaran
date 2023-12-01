Imports Newtonsoft.Json
Imports MySql.Data.MySqlClient

Public Class Home
    Dim conn As New MySqlConnection

    Sub CenterGroup()
        BackPanel.Width = Me.Width / 1.45
        BackPanel.Height = Me.Height / 2.2
        BackPanel.Left = (Me.ClientSize.Width - BackPanel.Width) / 2
        MessageBox.Show(BackPanel.Left)
        BackPanel.Top = (Me.Height - BackPanel.Height) / 2
        BackPanel.BackColor = Color.Transparent
    End Sub

    Sub CreateJson()
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

    Sub Button1Posisition()
        Button2.Left = BackPanel.Left
        Button2.Top = BackPanel.Top
    End Sub

    Sub ConnectToDatabase()
        CreateJson()
        Try
            conn.ConnectionString = "server=127.0.0.1;database=marketplace;userid=root;password="
            conn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CenterGroup()
        Button1Posisition()
        ConnectToDatabase()
    End Sub

    Private Sub Home_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CenterGroup()
        Button1Posisition()
        ConnectToDatabase()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
