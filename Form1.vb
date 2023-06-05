Imports System.ComponentModel
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports S7.Net
Imports S7.Net.Types
Imports functions = OkumaYazmaTestPLC.Functions
Imports variables = OkumaYazmaTestPLC.Variables


Public Class Form1
    'functions.vb DOSYASININ DAHİL EDİLMESİ'
    Dim funcs As New Functions()

    'PLC TANIMLAMASI'
    Private Plc As Plc

    'BAĞLANTIYI HARAKETE GEÇİRMEK İÇİN AYRICA BİR TANIMLAMADIR. Plc.IsConnected İLE KARIŞTIRILMAMALIDIR.'
    Private isConnected As Boolean = False ' Flag to track the connection status

    'UYGULAMA ALIŞTIĞINDA YAPILACAK İŞLEMLER'
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim counter As Integer = 0
        ' BELİRLENEN IP ADRESİNDEKİ PLC'Yİ OLUŞTUR '
        Plc = New Plc(CpuType.S71200, plcAdress, 0, 1)

        'SÜREKLİ İŞLEMLERİN KONTROLÜ İÇİN ZAMANLAYICI '
        connectionTimer.Interval = 500
        connectionTimer.Start()

        ' PLC'YE BAĞLAN '
        If Variables.pingResponse Then
            Try
                Plc.Open()
                lastJobContext.Text = ""
            Catch ex As Exception
                pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
                lastJobContext.Text = ""
                MessageBox.Show("PLC Ulaşılabilir durumda değil. IP: " + plcAdress)
            End Try
        Else
            pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
            lastJobContext.Text = ""
            If counter > 0 Then
                MessageBox.Show("PLC Ulaşılabilir durumda değil. IP: " + plcAdress)
            End If
        End If
    End Sub

    'BU FONKSİYON BAĞLANTI KOPMASI DURUMDA OTOMATİK BAĞLANMADA SIKINTI ÇIKARSA KULLANILMASI İÇİN PROGRAMLANMIŞTIR. SİSTEMİ YENİDEN BAŞLATMAK İÇİN DE KULLANILABİLİR.'
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ' PLC BAĞLANTISI KUR '
        Plc = New Plc(CpuType.S71200, plcAdress, 0, 1)
        If Variables.pingResponse Then
            Try
                Plc.Open()
                pingStatus.Text = "PLC Bağlı"
            Catch ex As Exception
                pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
                MessageBox.Show("PLC Ulaşılabilir durumda değil. IP: " + plcAdress)
            End Try
        Else
            pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
            MessageBox.Show("PLC Ulaşılabilir durumda değil. IP: " + plcAdress)
        End If
    End Sub

    'PLC KOPTUĞUNDA TEKRAR BAĞLANACAK MI SORUSUNA YANIT İÇİN DENEME FONKSİYONUDUR. BAĞLANTIYI KOPARIR.'
    Private Sub btnDisconnet_Click(sender As Object, e As EventArgs) Handles btnDisconnet.Click
        'PLC BAĞLANTISINI KOPAR '
        If Variables.pingResponse AndAlso Plc IsNot Nothing Then
            Try
                Plc.Close()
            Catch ex As Exception
                pingStatus.Text = "PLC'den ayrılınamıyor. IP: " + plcAdress
                MessageBox.Show("PLC'den ayrılınamıyor. IP: " + plcAdress)
            End Try
        Else
            pingStatus.Text = "PLC Ulaşılabilir durumda değil. IP: " + plcAdress
            MessageBox.Show("PLC Ulaşılabilir durumda değil. IP: " + plcAdress)
        End If
    End Sub

    Private Sub btnReadProduct_Click(sender As Object, e As EventArgs) Handles btnReadProduct.Click
        txtProduct.Text = funcs.ReadStringFromPLC(Plc, 1994, 8, 30)
    End Sub

    Private Sub btnWriteProduct_Click(sender As Object, e As EventArgs) Handles btnWriteProduct.Click
        funcs.WriteStringToPLC(Plc, 1994, 8, txtWriteProduct.Text, 30)
    End Sub

    Private Sub btnToggleValue_Click(sender As Object, e As EventArgs) Handles btnReadTest.Click
        ' Call the ToggleValueInPLC function '
        funcs.ToggleBoolValueInPLC(Plc, 1994, 0)
    End Sub

    Private Sub btnReadBaleWeight_Click(sender As Object, e As EventArgs) Handles btnReadBaleWeight.Click
        'read the value which is DInt from DB 1994 offset 2.0 '
        txtBaleWeight.Text = funcs.ReadDIntFromPLC(Plc, 1994, 2, 4)
    End Sub

    Private Sub btnWriteBaleWeight_Click(sender As Object, e As EventArgs) Handles btnWriteBaleWeight.Click
        ' Write the value from txtWriteBaleWeight to DB 1994, offset 2.0 as DInt '
        funcs.WriteDIntToPLC(Plc, 1994, 2, txtWriteBaleWeight.Text)
    End Sub

    Private Sub btnReadPressInfo_Click(sender As Object, e As EventArgs) Handles btnReadPressInfo.Click
        'read Word value from offset 38.0 '
        txtPressInfo.Text = funcs.ReadWordFromPLC(Plc, 1994, 38, 2)
    End Sub

    Private Sub btnWritePressInfo_Click(sender As Object, e As EventArgs) Handles btnWritePressInfo.Click
        ' Write Word value to DB 1994, offset 38.0 '
        funcs.WriteWordToPLC(Plc, 1994, 38, txtWritePressInfo.Text)
    End Sub

    Private Sub btnReadProductionCapacity_Click(sender As Object, e As EventArgs) Handles btnReadProductionCapacity.Click
        ' Read Real value from DB 1994, offset 40.0 '
        txtProductionCapacity.Text = funcs.ReadRealFromPLC(Plc, 1994, 40, 4)
    End Sub

    Private Sub btnWriteProductionCapacity_Click(sender As Object, e As EventArgs) Handles btnWriteProductionCapacity.Click
        ' Write Real value to DB 1994, offset 40.0 '
        funcs.WriteRealToPLC(Plc, 1994, 40, txtWriteProductionCapacity.Text)
    End Sub

    Private Sub btnReadRequest_Click(sender As Object, e As EventArgs) Handles btnReadRequest.Click
        txtReadTest.Text = funcs.ReadBooleanFromPLC(Plc, 1994, 0)
    End Sub

    Private Sub btnEstimatedBaleWeight_Click(sender As Object, e As EventArgs) Handles btnEstimatedBaleWeight.Click
        'Read Real value from DB 1994, offset 44.0 '
        txtEstimatedBaleWeight.Text = funcs.ReadRealFromPLC(Plc, 1994, 44, 4)
    End Sub

    Private Sub btnWriteEstimatedBaleWeight_Click(sender As Object, e As EventArgs) Handles btnWriteEstimatedBaleWeight.Click
        funcs.WriteRealToPLC(Plc, 1994, 44, txtWriteEstimatedBaleWeight.Text)
    End Sub

    Private Sub btnBaleWeigthingMinute_Click(sender As Object, e As EventArgs) Handles btnBaleWeigthingMinute.Click
        txtWeightingMinute.Text = funcs.ReadIntFromPLC(Plc, 1994, 48, 2)
    End Sub

    Private Sub btnWriteWeightingBale_Click(sender As Object, e As EventArgs) Handles btnWriteWeightingBale.Click
        funcs.WriteIntToPLC(Plc, 1994, 48, txtWriteWeightingMinute.Text)
    End Sub

    Private Sub btnBaleWeightingSecond_Click(sender As Object, e As EventArgs) Handles btnBaleWeightingSecond.Click
        txtWeightingSecond.Text = funcs.ReadIntFromPLC(Plc, 1994, 50, 2)
    End Sub

    Private Sub btnWriteWeightingSecond_Click(sender As Object, e As EventArgs) Handles btnWriteWeightingSecond.Click
        funcs.WriteIntToPLC(Plc, 1994, 50, txtWriteWeightingSecond.Text)
    End Sub

    Private Sub btnReadPressingMinute_Click(sender As Object, e As EventArgs) Handles btnReadPressingMinute.Click
        txtPressingMinute.Text = funcs.ReadIntFromPLC(Plc, 1994, 52, 2)
    End Sub

    Private Sub btnWritePressingMinute_Click(sender As Object, e As EventArgs) Handles btnWritePressingMinute.Click
        funcs.WriteIntToPLC(Plc, 1994, 52, txtWritePressingMinute.Text)
    End Sub

    Private Sub btnReadPressingSecond_Click(sender As Object, e As EventArgs) Handles btnReadPressingSecond.Click
        txtPressingSecond.Text = funcs.ReadIntFromPLC(Plc, 1994, 54, 2)
    End Sub

    Private Sub btnWritePressingSeconds_Click(sender As Object, e As EventArgs) Handles btnWritePressingSeconds.Click
        funcs.WriteIntToPLC(Plc, 1994, 54, txtWritePressingSecond.Text)
    End Sub

    Private Sub btnReadBaleID_Click(sender As Object, e As EventArgs) Handles btnReadBaleID.Click
        txtBaleID.Text = funcs.ReadDIntFromPLC(Plc, 1994, 56, 4)
    End Sub

    Private Sub btnWriteBaleID_Click(sender As Object, e As EventArgs) Handles btnWriteBaleID.Click
        funcs.WriteDIntToPLC(Plc, 1994, 56, txtWriteBaleID.Text)
    End Sub

    Private Sub btnReadBaleNo_Click(sender As Object, e As EventArgs) Handles btnReadBaleNo.Click
        txtBaleNo.Text = funcs.ReadDIntFromPLC(Plc, 1994, 60, 4)
    End Sub

    Private Sub btnWriteBaleNo_Click(sender As Object, e As EventArgs) Handles btnWriteBaleNo.Click
        funcs.WriteDIntToPLC(Plc, 1994, 60, txtWriteBaleNo.Text)
    End Sub

    Private Sub btnReadLotNumber_Click(sender As Object, e As EventArgs) Handles btnReadLotNumber.Click
        txtLotNumber.Text = funcs.ReadStringFromPLC(Plc, 1994, 68, 30)
    End Sub

    Private Sub btnReadRawMaterial_Click(sender As Object, e As EventArgs) Handles btnReadRawMaterial.Click
        txtRawMaterial.Text = funcs.ReadStringFromPLC(Plc, 1994, 100, 30)
    End Sub

    Private Sub btnReadOrderNo_Click(sender As Object, e As EventArgs) Handles btnReadOrderNo.Click
        txtOrderNo.Text = funcs.ReadStringFromPLC(Plc, 1994, 132, 30)
    End Sub

    Private Sub btnWriteLotNo_Click(sender As Object, e As EventArgs) Handles btnWriteLotNo.Click
        funcs.WriteStringToPLC(Plc, 1994, 68, txtWriteLotNo.Text, 30)
    End Sub

    Private Sub btnWriteRawMaterial_Click(sender As Object, e As EventArgs) Handles btnWriteRawMaterial.Click
        funcs.WriteStringToPLC(Plc, 1994, 100, txtWriteRawMaterial.Text, 30)
    End Sub

    Private Sub btnWriteOrderNo_Click(sender As Object, e As EventArgs) Handles btnWriteOrderNo.Click
        funcs.WriteStringToPLC(Plc, 1994, 132, txtWriteOrderNo.Text, 30)

    End Sub

    'BU ZAMANLAYICI SÜREKLİ İŞLEMLER YAPMAK İSTENİLDİĞİNDE KULLANILACAK BİR SANİYE SAYACIDIR.
    Private Sub connectionTimer_Tick(sender As Object, e As EventArgs) Handles connectionTimer.Tick
        ' Disable the timer while the BackgroundWorker is running
        txtSaniye.Text = Now.ToString("HH:mm:ss")
    End Sub

    'ZAMANLAYICIYU GÖSTEREN TEXTBOX TAKİ DEĞİŞİMİ KULLANARAK SÜREKLİ İŞLEMLERİ YAPMAYI SAĞLAR.
    Public lasJobStatusCounter As Integer = 0
    Private Async Sub txtSaniye_TextChanged(sender As Object, e As EventArgs) Handles txtSaniye.TextChanged
        'PİNG FONKSİYONU ASENKRON OLARAK KULLANILARAK PERFORMANS ARTTIRILMIŞTIR. AYNI ZAMANDA AWAİT KULLANIMINA OLANAK VERDİĞİ İÇİN OLASI HATALARDAN DA KAÇINMAMIZI SAĞLAR.'
        Dim isPingSuccessful As Boolean = Await Functions.PingIpAddress(plcAdress)

        '5 saniyede bir son işlemi gösteren label ı temizler.
        If lastJobContext.Text IsNot "" Then
            lasJobStatusCounter += 1
            If lasJobStatusCounter >= 5 Then
                lastJobContext.Text = ""
                lasJobStatusCounter = 0
            End If
        End If

        If isPingSuccessful Then
            ' PLC is reachable
            lblPingStatus.Text = "Ulaşılabilir."

            If Plc IsNot Nothing AndAlso Plc.IsConnected Then
                If Not isConnected Then
                    ' PLC has just been connected
                    isConnected = True
                    lblConnectionStatus.Text = "Bağlantı var."
                    pingStatus.Text = "PLC Bağlı"
                End If

                If Variables.pingResponse Then
                    ' ARKAPLAN İŞLLEMLERİNİ BAŞLATARAK VERİLERİ OKUR'
                    If Not BackgroundWorker1.IsBusy Then
                        ' Start the BackgroundWorker
                        BackgroundWorker1.RunWorkerAsync(plcDataItems)
                    End If
                End If
            Else
                lblPingStatus.Text = "PLC Bağlı Değil"
                If Variables.pingResponse Then
                    ' PLC ULAŞILABİLİR AMA BAĞLI DEĞİL'
                    lblPingStatus.Text = "Ulaşılabilir."

                    ' PLC'YE BAĞLANMAYA ÇALIŞIR'
                    Try
                        Plc.Open()
                        lastJobContext.Text = ""
                        If Plc.IsConnected Then
                            ' PLC BAĞLI'
                            lblConnectionStatus.Text = "Bağlantı var."
                            isConnected = True
                            pingStatus.Text = "PLC Bağlı"

                            ' VERİYİ ALMAK İÇİN ARKAPLAN İŞLEMLERİNİ BAŞLATIR'
                            BackgroundWorker1.RunWorkerAsync(plcDataItems)
                        Else
                            ' PLC BAĞLI DEĞİLDİR
                            lblConnectionStatus.Text = "Bağlantı yok."
                            lastJobContext.Text = ""
                            isConnected = False
                        End If
                    Catch ex As Exception
                        ' PLC BAĞLI DEĞİLDİR
                        lblConnectionStatus.Text = "Bağlantı yok."
                        lastJobContext.Text = ""
                        isConnected = False
                    End Try
                Else
                    ' PLC ULAŞILAMAZ'
                    lblPingStatus.Text = "Ulaşılamaz"
                    lblConnectionStatus.Text = "Bağlantı yok."
                    lastJobContext.Text = ""
                    isConnected = False
                End If
            End If
        Else
            ' PLC ULAŞILAMAZ'
            lblPingStatus.Text = "Ulaşılamaz"
            lblConnectionStatus.Text = "Bağlantı yok."
            lastJobContext.Text = ""
            isConnected = False ' Reset the connection status flag
        End If
    End Sub


    'BU KISIM ARKAPLAN İŞLEMLERİNİ YAPAR. YAPILACAK İŞLEMLERİN YAZILDIĞI YERDİR.
    Private Sub backgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' variables.vb DOSYASINDA TANIMLANAN VERİ DİZİSİNİ ALIR.
        Dim items As PlcDataItem() = DirectCast(e.Argument, PlcDataItem())

        'ARKAPLAN İLEMLERİ YAPILIRKEN ZAMANLAYICIYI DURDURUR.
        connectionTimer.Enabled = False
        ' DİZİDE DÖNEREK HER BİR VERİ İÇİN İŞLEM YAPAR.
        For Each item As PlcDataItem In items
            Dim name As String = item.Name
            Dim type As String = item.Type
            Dim dbNumber As Integer = item.DbNumber
            Dim startByteAddress As Integer = item.StartByteAddress
            Dim byteCount As Integer = item.ByteCount

            ' Read the value from the PLC based on the data type
            Select Case type
                Case "String"
                    Dim value As String = funcs.ReadStringFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                    item.Value = value
                Case "Boolean"
                    Dim value As Boolean = funcs.ReadBooleanFromPLC(Plc, dbNumber, startByteAddress)
                    item.Value = value
                Case "Int"
                    Dim value As Integer = funcs.ReadIntFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                    item.Value = value
                Case "DInt"
                    Dim value As Integer = funcs.ReadDIntFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                    item.Value = value
                Case "Word"
                    Dim value As Integer = funcs.ReadWordFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                    item.Value = value
                Case "Real"
                    Dim value As Double = funcs.ReadRealFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                    item.Value = value
                Case Else
                    MessageBox.Show($"Unknown data type '{type}'")
            End Select
        Next
    End Sub

    'BU KISIM ARKAPLAN İŞLEMLERİ BİTTİKTEN SONRA SONUÇLARI DÖNER'
    Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            ' ARKAPLAN İŞLEMLERİ SIRASINDA BİR HATA OLUŞUP OLUŞMADIĞINI KONTROL EDER.'
            MessageBox.Show($"An error occurred: {e.Error.Message}")
        Else
            ' GELEN VERİLERLE ARAYÜZÜ GÜNCELLER'

            ' DİZİYİ DÖNEREK HER BİR VERİ İÇİN İŞLEM YAPAR.'
            For Each item As PlcDataItem In plcDataItems
                Dim textBoxName As String = item.TextBoxName

                ' DİZİDE VERİLEN TextBoxName VERİSİNE GÖRE UYGUN TextBox'u BULUR.'
                Dim textBox As System.Windows.Forms.TextBox = Functions.FindControl(Me, textBoxName)

                If textBox IsNot Nothing Then
                    ' DEĞERİ TextBox'IN Text ÖZELLİĞİNE BAĞLAR.'
                    textBox.DataBindings.Clear()
                    textBox.DataBindings.Add("Text", item, "Value")
                Else
                    'BU UYARI YALNIZDA GELİŞTİRİCİNİN GÖREBİLECEĞİ BİR UYARIDIR. KULLANICIYA GÖSTERİLMEZ.'
                    MessageBox.Show($"TextBox control '{textBoxName}' not found.")
                End If
            Next
        End If
        'ARKAPLAN İŞLEMLERİ TAMAMEN BİTTİĞİ İÇİN ZAMANLAYICI YENİDEN BAŞLATILIR.'
        connectionTimer.Enabled = True
    End Sub

    Private Sub btnSetTrueRequest_Click(sender As Object, e As EventArgs) Handles btnSetTrueRequest.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 0)
    End Sub

    Private Sub btnSetFalseRequest_Click(sender As Object, e As EventArgs) Handles btnSetFalseRequest.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 0)
    End Sub

    Private Sub btnDolumBasladiTrue_Click(sender As Object, e As EventArgs) Handles btnDolumBasladiTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64)
    End Sub

    Private Sub btnDolumBasladiFalse_Click(sender As Object, e As EventArgs) Handles btnDolumBasladiFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64)
    End Sub

    Private Sub btnHedefKiloTrue_Click(sender As Object, e As EventArgs) Handles btnHedefKiloTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.1)
    End Sub

    Private Sub btnHedefKiloFalse_Click(sender As Object, e As EventArgs) Handles btnHedefKiloFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.1)
    End Sub

    Private Sub btnPreslemeBasladiTrue_Click(sender As Object, e As EventArgs) Handles btnPreslemeBasladiTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.2)
    End Sub

    Private Sub btnPreslemeBasladiFalse_Click(sender As Object, e As EventArgs) Handles btnPreslemeBasladiFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.2)
    End Sub

    Private Sub btnPreslemeTamamTrue_Click(sender As Object, e As EventArgs) Handles btnPreslemeTamamTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.3)
    End Sub

    Private Sub btnPreslemeTamamFalse_Click(sender As Object, e As EventArgs) Handles btnPreslemeTamamFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.3)
    End Sub

    Private Sub btnTelBaglamaBasladiTrue_Click(sender As Object, e As EventArgs) Handles btnTelBaglamaBasladiTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.4)
    End Sub

    Private Sub btnTelBaglamaBasladiFalse_Click(sender As Object, e As EventArgs) Handles btnTelBaglamaBasladiFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.4)
    End Sub

    Private Sub btnTelBaglamaTamamlandiTrue_Click(sender As Object, e As EventArgs) Handles btnTelBaglamaTamamlandiTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.5)
    End Sub

    Private Sub btnTelBaglamaTamamlandiFalse_Click(sender As Object, e As EventArgs) Handles btnTelBaglamaTamamlandiFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.5)
    End Sub

    Private Sub btnErpControllerTrue_Click(sender As Object, e As EventArgs) Handles btnErpControllerTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.6)
    End Sub

    Private Sub btnErpControllerFalse_Click(sender As Object, e As EventArgs) Handles btnErpControllerFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.6)
    End Sub

    Private Sub btnBalingControllerTrue_Click(sender As Object, e As EventArgs) Handles btnBalingControllerTrue.Click
        funcs.SetBoolValueToTrueInPLC(Plc, 1994, 64.7)
    End Sub

    Private Sub btnBaleControllerFalse_Click(sender As Object, e As EventArgs) Handles btnBaleControllerFalse.Click
        funcs.SetBoolValueToFalseInPLC(Plc, 1994, 64.7)
    End Sub
End Class
