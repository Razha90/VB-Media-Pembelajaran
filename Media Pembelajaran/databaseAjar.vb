Imports System.IO
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Newtonsoft.Json

Public Class databaseAjar
    Dim conn As New MySqlConnection
    Dim Server As String
    Dim Port As String
    Dim Database As String
    Dim Password As String
    Dim UserId As String

    Public Sub New()
        ReadJsonFile()
    End Sub

    Private Sub ReadJsonFile()
        Dim jsonFilePath As String = "saveDatabase.json"
        If File.Exists(jsonFilePath) Then
            Try
                Dim jsonContent As String = File.ReadAllText(jsonFilePath)
                Dim savedDatabase As Database = JsonConvert.DeserializeObject(Of Database)(jsonContent)
                Server = savedDatabase.server
                Port = savedDatabase.port
                Database = savedDatabase.database
                Password = savedDatabase.password
                UserId = savedDatabase.userid
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Gagal membuka Local Data!")
        End If
    End Sub

    Public Function GetMateriData() As List(Of Materi)
        Dim materiList As New List(Of Materi)()

        Using conn As New MySqlConnection($"server={Server};port={Port};database={Database};userid={UserId};password={Password}")
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM materi"
                Using command As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim materi As New Materi()
                            materi.IdMateri = Convert.ToInt64(reader("id_materi"))
                            materi.Judul = reader("judul").ToString()
                            materiList.Add(materi)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                ' Handle exception, if needed
            End Try
        End Using

        Return materiList
    End Function

    Public Function GetIsiMateriById(idMateri As Long) As List(Of IsiMateri)
        Dim isiMateriList As New List(Of IsiMateri)()

        Using conn As New MySqlConnection($"server={Server};port={Port};database={Database};userid={UserId};password={Password}")
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM isi_materi WHERE id_materi = @idMateri ORDER BY page"
                Using command As New MySqlCommand(query, conn)
                    command.Parameters.AddWithValue("@idMateri", idMateri)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim isiMateri As New IsiMateri()
                            isiMateri.IdIsi = Convert.ToInt64(reader("id_isi"))
                            isiMateri.SubJudul = reader("sub_judul").ToString()
                            isiMateri.Page = Convert.ToInt32(reader("page"))
                            isiMateri.Isi = reader("isi").ToString()
                            isiMateri.Video = reader("vidio").ToString()
                            isiMateriList.Add(isiMateri)
                        End While
                    End Using
                End Using
            Catch ex As Exception
            End Try
        End Using

        Return isiMateriList
    End Function
End Class

Public Class IsiMateri
    Public Property IdIsi As Long
    Public Property SubJudul As String
    Public Property Page As Integer
    Public Property Isi As String
    Public Property Video As String
End Class