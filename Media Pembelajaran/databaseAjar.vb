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

    Public Function InsertIntoSelesaiMateri(idMateri As Integer, idAkun As Integer)
        Using conn As New MySqlConnection($"server={Server};port={Port};database={Database};userid={UserId};password={Password}")
            Try
                conn.Open()
                Dim query As String = "INSERT INTO selesai_materi (id_materi, id_akun) VALUES (@idMateri, @idAkun)"
                Using command As New MySqlCommand(query, conn)
                    command.Parameters.AddWithValue("@idMateri", idMateri)
                    command.Parameters.AddWithValue("@idAkun", idAkun)
                    command.ExecuteNonQuery()
                End Using
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function GetLatihanData() As List(Of Latihan)
        Dim latihanList As New List(Of Latihan)

        Try
            Using conn As New MySqlConnection($"server={Server};port={Port};database={Database};userid={UserId};password={Password}")
                conn.Open()

                Dim query As String = "SELECT * FROM latihan"
                Using command As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim latihan As New Latihan()
                            latihan.Id = Convert.ToInt32(reader("id_latihan"))
                            latihan.Judul = reader("judul").ToString()
                            latihanList.Add(latihan)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        End Try

        Return latihanList
    End Function


    Public Function GetLatihanIdByJudul(judul As String) As Integer
        Dim idLatihan As Integer = -1

        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "SELECT id_latihan FROM latihan WHERE judul = @judul"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@judul", judul)

                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    idLatihan = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try

        Return idLatihan
    End Function



    Public Function GetSoalData(idLatihan As Integer) As List(Of Soal)
        Dim soals As New List(Of Soal)()
        Using conn As New MySqlConnection($"server={Server};port={Port};database={Database};userid={UserId};password={Password}")
            Try
                conn.Open()

                Dim query As String = "SELECT * FROM soal WHERE id_latihan = @idLatihan"
                Using command As New MySqlCommand(query, conn)
                    command.Parameters.AddWithValue("@idLatihan", idLatihan)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim soal As New Soal() With {
                        .IdSoal = Convert.ToInt32(reader("id_soal")),
                        .Pertanyaan = reader("pertanyaan").ToString(),
                        .Pilihan1 = reader("pilihan_1").ToString(),
                        .Pilihan2 = reader("pilihan_2").ToString(),
                        .Pilihan3 = reader("pilihan_3").ToString(),
                        .Pilihan4 = reader("pilihan_4").ToString(),
                        .Jawaban = reader("jawaban").ToString()
                    }
                            soals.Add(soal)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine($"Error: {ex.Message}")
            Finally
                conn.Close()
            End Try
        End Using

        Return soals
    End Function



End Class



Public Class IsiMateri
    Public Property IdIsi As Long
    Public Property SubJudul As String
    Public Property Page As Integer
    Public Property Isi As String
    Public Property Video As String
End Class

Public Class Soal
    Public Property IdSoal As Integer
    Public Property Pertanyaan As String
    Public Property Pilihan1 As String
    Public Property Pilihan2 As String
    Public Property Pilihan3 As String
    Public Property Pilihan4 As String
    Public Property Jawaban As String
    Public Property JawabanUser As String
End Class

Public Class Latihan
    Public Property Judul As String
    Public Property Id As Integer
End Class