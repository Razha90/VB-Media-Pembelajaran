Imports System.IO
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Newtonsoft.Json
Imports BCrypt

Public Class DatabaseConnection
    Dim conn As New MySqlConnection
    Dim Server As String
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
        Dim saved(3) As String
        saved(0) = Server
        saved(1) = Database
        saved(2) = UserId
        saved(3) = Password

        Return saved
    End Function

    Public Function Login(user As String, cPassword As String, orEmail As Boolean) As String()
        Try
            conn.ConnectionString = $"server={Server};database={Database};userid={UserId};password={Password}"
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
            conn.ConnectionString = $"server={Server};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function CheckConnection(CServer As String, CDatabase As String, CPassword As String, CUserid As String) As Boolean
        Dim TestConn As New MySqlConnection

        Try
            TestConn.ConnectionString = $"server={CServer};database={CDatabase};userid={CUserid};password={CPassword}"
            TestConn.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Public Function CreateJson(CServer As String, CDatabase As String, CPassword As String, CUserid As String) As Boolean
        Try
            Dim saveDatabase As New Database With {
                .server = CServer,
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
            conn.ConnectionString = $"server={Server};database={Database};userid={UserId};password={Password}"
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
    isi TEXT NOT NULL,
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
            conn.ConnectionString = $"server={Server};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim key As Integer = GenerateUniqueNumericKey()
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
            conn.ConnectionString = $"server={Server};database={Database};userid={UserId};password={Password}"
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM akun WHERE Role = 'Pengajar'"
            Dim command As New MySqlCommand(query, conn)

            Dim adminCount As Integer = Convert.ToInt32(command.ExecuteScalar())

            Return adminCount > 0
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Private Function GenerateUniqueNumericKey() As Integer
        Dim random As New Random()
        Dim key As Integer

        Do
            key = random.Next(1000000, 10000000)
        Loop Until IsKeyUnique(key)

        Return key
    End Function

    Private Function IsKeyUnique(key As String) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM akun WHERE id_akun = @key"
            Dim command As New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@key", key)

            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

            Return count = 0
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class