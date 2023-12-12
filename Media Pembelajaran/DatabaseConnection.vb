Imports System.IO
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Newtonsoft.Json
Imports BCrypt
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class DatabaseConnection
    Dim conn As New MySqlConnection
    Dim Server As String
    Dim Port As String
    Dim Database As String
    Dim Password As String
    Dim UserId As String


    Public Function ReadJsonFile() As Boolean
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
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Function GetDataBaseInfo() As String()
        Dim saved(4) As String
        saved(0) = Server
        saved(1) = Port
        saved(2) = Database
        saved(3) = UserId
        saved(4) = Password

        Return saved
    End Function

    Public Function Login(user As String, cPassword As String, orEmail As Boolean) As String()
        Try
            conn.ConnectionString = $"server={Server}; port={Port}; database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim saved(5) As String

            If orEmail Then
                Dim query As String = "SELECT * FROM akun WHERE email = @Email"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", user)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim storedHashedPassword As String = reader("password").ToString()

                        If BCrypt.Net.BCrypt.Verify(cPassword, storedHashedPassword) Then
                            saved(0) = reader("id_akun").ToString()
                            saved(1) = reader("nama").ToString()
                            saved(2) = reader("username").ToString()
                            saved(3) = reader("email").ToString()
                            saved(4) = reader("password").ToString()
                            saved(5) = reader("roles").ToString()
                        End If
                    End While
                End If
            Else
                Dim query As String = "SELECT * FROM akun WHERE username = @Username"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", user)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim storedHashedPassword As String = reader("password").ToString()

                        If BCrypt.Net.BCrypt.Verify(cPassword, storedHashedPassword) Then
                            saved(0) = reader("id_akun").ToString()
                            saved(1) = reader("nama").ToString()
                            saved(2) = reader("username").ToString()
                            saved(3) = reader("email").ToString()
                            saved(4) = reader("password").ToString()
                            saved(5) = reader("roles").ToString()
                        End If
                    End While
                End If

            End If
            Return saved
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return New String() {}
        Finally
            conn.Close()
        End Try
        Return New String() {}
    End Function

    Public Function ConnectToDatabase() As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function CheckConnection(CServer As String, CPort As String, CDatabase As String, CPassword As String, CUserid As String) As Boolean
        Dim TestConn As New MySqlConnection

        Try
            TestConn.ConnectionString = $"server={CServer}; port={CPort};database={CDatabase};userid={CUserid};password={CPassword}"
            TestConn.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function



    Public Function CreateJson(CServer As String, CPort As String, CDatabase As String, CPassword As String, CUserid As String) As Boolean
        Try
            Dim saveDatabase As New Database With {
                .server = CServer,
                .port = CPort,
                .database = CDatabase,
                .password = CPassword,
                .userid = CUserid
            }
            Dim json As String = JsonConvert.SerializeObject(saveDatabase)
            System.IO.File.WriteAllText("saveDatabase.json", json)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MigrateDatabase() As Boolean
        Try
            conn.ConnectionString = $"server={Server}; port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim createTableQuery As String = "CREATE TABLE IF NOT EXISTS akun (
    id_akun BIGINT PRIMARY KEY NOT NULL,
    nama VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL UNIQUE,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    roles ENUM('Pengajar', 'Murid') NOT NULL,
    pertanyaan VARCHAR(255) NOT NULL,
    jawaban VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS materi (
    id_materi BIGINT PRIMARY KEY NOT NULL,
    judul TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS isi_materi (
    id_isi BIGINT PRIMARY KEY NOT NULL,
    sub_judul TEXT,
    page INT,
    isi TEXT,
    vidio VARCHAR(255),
    id_materi BIGINT NOT NULL,
    FOREIGN KEY (id_materi) REFERENCES materi(id_materi)
);

CREATE TABLE IF NOT EXISTS selesai_materi (
    id_materi BIGINT NOT NULL,
    id_akun BIGINT NOT NULL,
    PRIMARY KEY (id_materi, id_akun),
    FOREIGN KEY (id_materi) REFERENCES materi(id_materi),
    FOREIGN KEY (id_akun) REFERENCES akun(id_akun)
);

CREATE TABLE IF NOT EXISTS latihan (
    id_latihan BIGINT PRIMARY KEY NOT NULL,
    judul TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS soal (
    id_soal BIGINT PRIMARY KEY NOT NULL,
    pertanyaan TEXT NOT NULL,
    pilihan_1 TEXT NOT NULL,
    pilihan_2 TEXT NOT NULL,
    pilihan_3 TEXT NOT NULL,
    pilihan_4 TEXT NOT NULL,
    jawaban ENUM('pilihan_1', 'pilihan_2', 'pilihan_3', 'pilihan_4') NOT NULL,
    id_latihan BIGINT NOT NULL,
    FOREIGN KEY (id_latihan) REFERENCES latihan(id_latihan)
);

CREATE TABLE IF NOT EXISTS selesai_latihan (
    id_selesai_latihan BIGINT PRIMARY KEY NOT NULL,
    id_latihan BIGINT NOT NULL,
    id_akun BIGINT NOT NULL,
    nilai BIGINT,
    FOREIGN KEY (id_latihan) REFERENCES latihan(id_latihan),
    FOREIGN KEY (id_akun) REFERENCES akun(id_akun)
);
"
            Dim createTableCommand As New MySqlCommand(createTableQuery, conn)
            createTableCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function DaftarAkun(Nama As String, Username As String, Email As String, Passwords As String, Pertanyaan As String, Jawaban As String, Role As String) As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey("akun", "id_akun")
            Dim insertQuery As String = $"INSERT INTO akun (id_akun, nama, username, email, password, pertanyaan, jawaban, roles) VALUES (@id_akun, @Nama, @Username, @Email, @Password, @Pertanyaan, @Jawaban, @Role)"
            Dim insertCommand As New MySqlCommand(insertQuery, conn)
            insertCommand.Parameters.AddWithValue("@id_akun", key)
            insertCommand.Parameters.AddWithValue("@Nama", Nama)
            insertCommand.Parameters.AddWithValue("@Username", Username)
            insertCommand.Parameters.AddWithValue("@Email", Email)
            insertCommand.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(Passwords))
            insertCommand.Parameters.AddWithValue("@Pertanyaan", Pertanyaan)
            insertCommand.Parameters.AddWithValue("@Jawaban", Jawaban)
            insertCommand.Parameters.AddWithValue("@Role", Role)

            insertCommand.ExecuteScalar()

            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conn.Close()
        End Try
    End Function



    Public Function CheckAdminRole() As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM akun WHERE roles = 'Pengajar'"
            Dim command As New MySqlCommand(query, conn)

            Dim adminCount As Integer = Convert.ToInt32(command.ExecuteScalar())
            MessageBox.Show(adminCount > 0)
            Return adminCount > 0
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetMateriData() As DataTable
        Dim dataTable As New DataTable()
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT * FROM materi"
            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
        Return dataTable
    End Function

    Public Sub UpdateMateriField(idMateri As Integer, fieldName As String, newValue As String)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = $"UPDATE materi SET {fieldName} = @newValue WHERE id_materi = @idMateri"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idMateri", idMateri)
                command.Parameters.AddWithValue("@newValue", newValue)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function InsertMateri(judul As String) As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey("materi", "id_materi")

            Dim query As String = "INSERT INTO materi (id_materi,judul) VALUES (@id_materi,@judul)"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@id_materi", key)
                command.Parameters.AddWithValue("@judul", judul)
                command.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function SearchListMateri()
        Dim judulList As New List(Of String)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT judul FROM materi"
            Using command As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        judulList.Add(reader("judul").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
        Return judulList
    End Function

    Public Function GetIsiMateri(judul As String) As DataTable
        Dim dataTable As New DataTable()

        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT isi_materi.* FROM isi_materi
                                   JOIN materi ON isi_materi.id_materi = materi.id_materi
                                   WHERE materi.judul = @judul"

            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@judul", judul)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try

        Return dataTable
    End Function

    Public Function DeleteMateri(idMateri As Integer) As Boolean
        Try
            conn.Open()

            Dim query As String = "DELETE FROM materi WHERE id_materi = @idMateri"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idMateri", idMateri)
                command.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function GetIdMateriByJudul(judul As String) As Long
        Try
            conn.Open()

            Dim query As String = "SELECT id_materi FROM materi WHERE judul = @judul"

            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@judul", judul)

                Dim result As Object = command.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Return Convert.ToInt64(result)
                Else
                    Return 0
                End If
            End Using
        Catch ex As Exception
            Return 0
        Finally
            conn.Close()
        End Try
    End Function

    Public Function InsertIsiMateri(subJudul As String, page As Integer, isi As String, vidio As String, idMateri As Integer) As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey("isi_materi", "id_isi")

            Dim query As String = "INSERT INTO isi_materi (id_isi ,sub_judul, page, isi, vidio, id_materi) VALUES (@id_isi,@subJudul, @page, @isi, @vidio, @idMateri)"

            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@id_isi", key)
                command.Parameters.AddWithValue("@subJudul", subJudul)
                command.Parameters.AddWithValue("@page", page)
                command.Parameters.AddWithValue("@isi", isi)
                command.Parameters.AddWithValue("@vidio", vidio)
                command.Parameters.AddWithValue("@idMateri", idMateri)
                command.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function DeleteIsiMateri(idIsi As Integer) As Boolean
        Try
            conn.Open()

            Dim query As String = "DELETE FROM isi_materi WHERE id_isi = @idIsi"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idIsi", idIsi)
                command.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function UpdateIsiMateri(idIsi As Integer, subJudul As String, page As Integer, isi As String, vidio As String, idMateri As Long) As Boolean
        Try

            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "UPDATE isi_materi SET sub_judul = @subJudul, page = @page, isi = @isi, vidio = @vidio, id_materi = @idMateri WHERE id_isi = @idIsi"

            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idIsi", idIsi)
                command.Parameters.AddWithValue("@subJudul", subJudul)
                command.Parameters.AddWithValue("@page", page)
                command.Parameters.AddWithValue("@isi", isi)
                command.Parameters.AddWithValue("@vidio", vidio)
                command.Parameters.AddWithValue("@idMateri", idMateri)

                command.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    ''' ----------------------------------------------------------------

    Public Function GetLatihanData() As DataTable
        Dim dataTable As New DataTable()
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT * FROM latihan"
            Dim adapter As New MySqlDataAdapter(query, conn)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
        Return dataTable
    End Function

    Public Function AddLatihanData(Judul As String)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey("latihan", "id_latihan")
            Dim query As String = "INSERT INTO latihan (id_latihan, judul) VALUES (@id_latihan, @judul)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id_latihan", key)
            cmd.Parameters.AddWithValue("@judul", Judul)

            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
            Return False
        Finally
            conn.Close()
        End Try
    End Function


    Public Sub UpdateLatihanField(idLatihan As Integer, fieldName As String, newValue As String)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = $"UPDATE latihan SET {fieldName} = @newValue WHERE id_latihan = @idLatihan"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idLatihan", idLatihan)
                command.Parameters.AddWithValue("@newValue", newValue)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub


    Public Sub DeleteLatihan(idLatihan As Integer)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "DELETE FROM latihan WHERE id_latihan = @idLatihan"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idLatihan", idLatihan)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function GetLatihanTitles() As List(Of String)
        Dim titles As New List(Of String)

        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "SELECT judul FROM latihan"
            Using command As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        titles.Add(reader("judul").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try

        Return titles
    End Function

    Public Function GetSoalDataByLatihanID(latihanID As Integer) As DataTable
        Dim dataTable As New DataTable()

        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"

            conn.Open()

            Dim query As String = "SELECT * FROM soal WHERE id_latihan = @latihanID"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@latihanID", latihanID)

                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try

        Return dataTable
    End Function

    Public Function GetSelectedLatihanID(selectedTitle As String) As Integer
        Dim selectedLatihanID As Integer = 0
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"

            conn.Open()

            Dim query As String = "SELECT id_latihan FROM latihan WHERE judul = @judul"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@judul", selectedTitle)
                Dim result As Object = command.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    selectedLatihanID = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try

        Return selectedLatihanID
    End Function


    Public Function InsertNewSoal(pertanyaan As String, pilihan1 As String, pilihan2 As String, pilihan3 As String, pilihan4 As String, jawaban As String, idLatihan As Integer) As Boolean
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey("soal", "id_soal")

            Dim query As String = "INSERT INTO soal (id_soal, pertanyaan, pilihan_1, pilihan_2, pilihan_3, pilihan_4, jawaban, id_latihan) VALUES (@id_soal,@pertanyaan, @pilihan1, @pilihan2, @pilihan3, @pilihan4, @jawaban, @idLatihan)"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@id_soal", key)
                command.Parameters.AddWithValue("@pertanyaan", pertanyaan)
                command.Parameters.AddWithValue("@pilihan1", pilihan1)
                command.Parameters.AddWithValue("@pilihan2", pilihan2)
                command.Parameters.AddWithValue("@pilihan3", pilihan3)
                command.Parameters.AddWithValue("@pilihan4", pilihan4)
                command.Parameters.AddWithValue("@jawaban", jawaban)
                command.Parameters.AddWithValue("@idLatihan", idLatihan)

                command.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            Return False
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Function

    Public Sub DeleteSoal(idSoal As Integer)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "DELETE FROM soal WHERE id_soal = @idSoal"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@idSoal", idSoal)

                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub UpdateSoal(idSoal As Integer, pertanyaan As String, pilihan1 As String, pilihan2 As String, pilihan3 As String, pilihan4 As String, jawaban As String, idLatihan As Integer)
        Try
            conn.ConnectionString = $"server={Server};port={Port};database={Database};userid={UserId};password={Password}"
            conn.Open()

            Dim query As String = "UPDATE soal SET pertanyaan = @pertanyaan, pilihan_1 = @pilihan1, pilihan_2 = @pilihan2, pilihan_3 = @pilihan3, pilihan_4 = @pilihan4, jawaban = @jawaban, id_latihan = @idLatihan WHERE id_soal = @idSoal"
            Using command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@pertanyaan", pertanyaan)
                command.Parameters.AddWithValue("@pilihan1", pilihan1)
                command.Parameters.AddWithValue("@pilihan2", pilihan2)
                command.Parameters.AddWithValue("@pilihan3", pilihan3)
                command.Parameters.AddWithValue("@pilihan4", pilihan4)
                command.Parameters.AddWithValue("@jawaban", jawaban)
                command.Parameters.AddWithValue("@idLatihan", idLatihan)
                command.Parameters.AddWithValue("@idSoal", idSoal)

                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Function GenerateUniqueNumericKey(dbname As String, dbid As String) As Integer
        Dim random As New Random()
        Dim key As Integer

        Do
            key = random.Next(1000000, 10000000)
        Loop Until IsKeyUnique(key, dbname, dbid)

        Return key
    End Function

    Private Function IsKeyUnique(key As String, dbname As String, dbid As String) As Boolean
        Try
            Dim query As String = $"SELECT COUNT(*) FROM {dbname} WHERE {dbid} = @key"
            Dim command As New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@key", key)

            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

            Return count = 0
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class