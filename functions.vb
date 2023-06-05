Imports System.Text
Imports S7.Net
Imports S7.Net.Types
Imports System.Net.NetworkInformation
Imports variables = OkumaYazmaTestPLC.Variables
Imports System


Public Class Functions
    'GENEL FONKSİYONLAR BAŞLANGIÇ'

    'BU FONKSİYON AĞA PİNG GÖNDEREREK PLC ADRESİNİN DOĞRULUĞUNU KONTROL EDER'
    Public Shared Async Function PingIpAddress(ipAddress As String) As Task(Of Boolean)
        Try
            Dim pingSender As New Ping()
            Dim reply As PingReply = Await pingSender.SendPingAsync(ipAddress, 500) ' Set the timeout to 500ms

            If reply.Status = IPStatus.Success Then
                Variables.pingResponse = True
                'OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC'ye Ulaşılabilir."
                Return True
            Else
                Variables.pingResponse = False
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
                Return False
            End If
        Catch ex As Exception
            Variables.pingResponse = False
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
            Return False
        End Try
    End Function

    'BU FONKSİYON variables.vb DOSYASINDAKİ DATA DİZİSİNE GÖRE UYGUN TEXTBOX'I BULUR'
    Public Shared Function FindControl(form As Form, name As String) As TextBox
        Dim control As Control = form.Controls.Find(name, True).OfType(Of TextBox)().FirstOrDefault()
        Return control
    End Function


    'GENEL FONKSİYONLAR BİTİŞ'

    'BOOLEAN FONKSİYONLARI'

    'BU FONKSİYON DEĞERİ TRUE İSE FALSE FALSE İSE TRUE YAPAR'
    Public Sub ToggleBoolValueInPLC(plc As Plc, db As Integer, offset As Double)
        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = CInt(Math.Floor(offset))
            Dim bitIndex As Integer = CInt((offset - startByteAdr) * 10) ' Calculate the bit index within the byte

            Try
                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim bitMask As Byte = CByte(1 << bitIndex) ' Create the bit mask for the specific bit

                rawData(0) = rawData(0) Xor bitMask ' Toggle the bit value
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer başarıyla değiştirildi."
            Catch ex As Exception
                ' Handle the exception or display an error message
                MessageBox.Show("Değer değişimi sırasında hata: " + ex.Message)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer değiştirme hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub




    'BU FONKSİYON DEĞERİ TRUE YAPAR'
    Public Sub SetBoolValueToTrueInPLC(plc As Plc, db As Integer, offset As Double)
        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = CInt(Math.Floor(offset))
            Dim bitIndex As Integer = CInt((offset - startByteAdr) * 10) ' Calculate the bit index within the byte

            Try
                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim bitMask As Byte = CByte(1 << bitIndex) ' Create the bit mask for the specific bit

                rawData(0) = rawData(0) Or bitMask ' Set the bit value to 1
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer başarıyla değiştirildi."
            Catch ex As Exception
                ' Handle the exception or display an error message
                MessageBox.Show("Değer değişimi sırasında hata: " + ex.Message)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer değiştirme hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub


    'BU FONKSİYON DEĞERİ FALSE YAPAR'
    Public Sub SetBoolValueToFalseInPLC(plc As Plc, db As Integer, offset As Double)
        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = CInt(Math.Floor(offset))
            Dim bitIndex As Integer = CInt((offset - startByteAdr) * 10) ' Calculate the bit index within the byte

            Try
                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim bitMask As Byte = CByte(1 << bitIndex) ' Create the bit mask for the specific bit

                rawData(0) = rawData(0) And Not bitMask ' Set the bit value to 0
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer başarıyla değiştirildi."
            Catch ex As Exception
                ' Handle the exception or display an error message
                MessageBox.Show("Değer değişimi sırasında hata: " + ex.Message)
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer değiştirme hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub
    'BOOLEAN FONKSİYONLARI BİTİŞ'

    '---------------------------------------------------------------------------------------------------------------------------------------'

    'DEĞER OKUMA FONKSİYONLARI'

    'BU FONKSİYON PLC'DEN WORD DEĞERLERİ OKUR'
    Public Function ReadWordFromPLC(plc As Plc, db As Integer, offset As Integer, count As Integer) As Integer
        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = offset
            Dim byteCount As Integer = count

            Try
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing AndAlso rawData.Length >= 2 Then
                    Dim theWord As Integer = S7.Net.Types.Word.FromByteArray(rawData)
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."
                    Return theWord
                Else
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer okunamadı."
                End If
            Catch ex As Exception
                ' Handle the exception or display an error message
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return 0 ' Return a default value if the reading failed
    End Function


    'BU FONKSİYON PLC'DEKİ STRING VERİLERİ OKUR'
    Public Function ReadStringFromPLC(plc As Plc, db As Integer, offset As Integer, byteCount As Integer) As String
        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = offset

            Try
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."
                    Return S7.Net.Types.String.FromByteArray(rawData)
                Else
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer okunamadı."
                End If
            Catch ex As Exception
                ' Handle the exception or display an error message
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return String.Empty ' Return an empty string if the reading failed
    End Function


    'BU FONKSİYON PLC'DEKİ DINT VERİLERİ OKUR'
    Public Function ReadDIntFromPLC(plc As Plc, db As Integer, offset As Integer, byteCount As Integer) As Integer
        Dim result As Integer = 0

        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = offset

            Try
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    result = S7.Net.Types.DInt.FromByteArray(rawData)
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."
                Else
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer okunamadı."
                End If
            Catch ex As Exception
                ' Handle the exception or display an error message
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return result
    End Function


    'BU FONKSİYON PLC'DEKİ REAL VERİLERİ OKUR'
    Public Function ReadRealFromPLC(plc As Plc, db As Integer, offset As Integer, byteCount As Integer) As Double
        Dim result As Double = 0.0

        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Dim dbNumber As Integer = db
            Dim startByteAdr As Integer = offset

            Try
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    Dim floatValue As Single = S7.Net.Types.Real.FromByteArray(rawData)
                    result = Math.Round(floatValue, 1) ' Round to one decimal place
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."
                Else
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer okunamadı."
                End If
            Catch ex As Exception
                ' Handle the exception or display an error message
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
            End Try

        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return result
    End Function



    'BU FONKSİYON PLC'DEKİ BOOLEAN VERİLERİ OKUR'
    Public Function ReadBooleanFromPLC(plc As Plc, db As Integer, offset As Integer) As Boolean

        If Variables.pingResponse AndAlso plc IsNot Nothing AndAlso plc.IsConnected Then
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
            Try
                Dim dbNumber As Integer = db
                Dim startByteAdr As Integer = offset

                ' Read the byte containing the boolean value from the PLC '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim value As Boolean = (rawData(0) And &H1) <> 0
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."

                Return value
            Catch ex As Exception
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
            End Try
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return False
    End Function



    'BU FONKSİYON PLC'DEKİ INT VERİLERİ OKUR'
    Public Function ReadIntFromPLC(plc As Plc, db As Integer, offset As Double, byteCount As Integer) As Integer
        Dim result As Integer = 0

        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                Try
                    Dim dbNumber As Integer = CInt(db)
                    Dim startByteAdr As Integer = CInt(offset)

                    Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                    If rawData IsNot Nothing AndAlso rawData.Length >= 2 Then
                        result = S7.Net.Types.Int.FromByteArray(rawData)
                        OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla okundu."
                    Else
                        OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Değer okunamadı."
                    End If
                Catch ex As Exception
                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Okuma hatası"
                End Try
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If

        Return result
    End Function



    'OKUMA FONKSİYONLARI BİTİŞ'

    '---------------------------------------------------------------------------------------------------------------------------------------'

    'YAZMA FONKSİYONLARI BAŞLANGIÇ'

    'BU FONKSİYON PLC'YE WORD VERİLERİ YAZAR'
    Public Sub WriteWordToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim ushortValue As UShort

                If UShort.TryParse(valueToWrite, ushortValue) Then
                    Try
                        Dim data As Byte() = BitConverter.GetBytes(ushortValue)
                        Array.Reverse(data) ' Reverse the byte order for the Endian conversion '
                        plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                        OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla yazıldı."
                    Catch ex As Exception
                        MessageBox.Show("Yazarken hata: " + ex.Message)
                    End Try
                Else
                    MessageBox.Show("Geçersiz değer.")
                End If
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub


    'BU FONKSİYON PLC'YE STRING VERİLERİ YAZAR'
    Public Sub WriteStringToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String, expectedLength As Integer)
        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                ' Truncate or pad the valueToWrite to match the expected length '
                valueToWrite = valueToWrite.PadRight(expectedLength, ChrW(0))

                Try
                    Dim dbNumber As Integer = CInt(db)
                    Dim startByteAdr As Integer = CInt(offset)
                    Dim rawData As Byte() = Encoding.Default.GetBytes(valueToWrite)
                    plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                    OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla yazıldı."
                Catch ex As Exception
                    MessageBox.Show("Yazarken hata: " + ex.Message)
                End Try
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub


    'BU FONKSİYON PLC'YE DINT VERİLERİ YAZAR'
    Public Sub WriteDIntToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim int32Value As Int32

                If Int32.TryParse(valueToWrite, int32Value) Then
                    Try
                        Dim data As Byte() = S7.Net.Types.DInt.ToByteArray(int32Value)
                        plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                        OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla yazıldı."
                    Catch ex As Exception
                        MessageBox.Show("Yazarken hata: " + ex.Message)
                    End Try
                Else
                    MessageBox.Show("Geçersiz değer.")
                End If
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub


    'BU FONKSİYON PLC'YE REAL VERİLERİ YAZAR'
    Public Sub WriteRealToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim singleValue As Single

                If Single.TryParse(valueToWrite, singleValue) Then
                    Try
                        ' Round the value to the desired precision '
                        Dim roundedValue As Single = CSng(Math.Round(singleValue, 1))
                        Dim data As Byte() = S7.Net.Types.Real.ToByteArray(roundedValue)

                        ' Check if the byte count matches the expected length '
                        If data.Length = 4 Then
                            plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla yazıldı."
                        Else
                            MessageBox.Show("Beklenmeyen durum")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Yazarken hata: " + ex.Message)
                    End Try
                Else
                    MessageBox.Show("Geçersiz değer.")
                End If
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub



    'BU FONKSİYON PLC'YE INT DEĞERLERİ YAZAR.'
    Public Sub WriteIntToPLC(plc As Plc, db As Integer, offset As Double, value As String)
        If Variables.pingResponse AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Bağlı"
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                Dim intValue As Integer
                If Not String.IsNullOrEmpty(value) AndAlso Integer.TryParse(value, intValue) Then
                    If Short.MinValue <= intValue AndAlso intValue <= Short.MaxValue Then
                        Dim rawData As Byte() = S7.Net.Types.Int.ToByteArray(intValue)
                        plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)
                        OkumaYazmaTestPLC.Form1.lastJobContext.Text = "Başarıyla yazıldı."
                    Else
                        MessageBox.Show("Geçersiz değer.")
                    End If
                Else
                    MessageBox.Show("Geçersiz değer.")
                End If
            Else
                OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            End If
        Else
            OkumaYazmaTestPLC.Form1.lastJobContext.Text = "İşlem Başarısız"
            OkumaYazmaTestPLC.Form1.pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
        End If
    End Sub


    'YAZMA FONKSİYONLARI BİTİŞ'

End Class
