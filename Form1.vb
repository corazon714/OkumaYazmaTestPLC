Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports S7.Net
Imports S7.Net.Types
Imports functions = OkumaYazmaTestPLC.Functions
Imports variables = OkumaYazmaTestPLC.Variables


Public Class Form1
    Dim funcs As New Functions()

    Private Plc As Plc

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connect to PLC at the desired IP address '
        Plc = New Plc(CpuType.S71200, plcAdress, 0, 1)

        'setting timer for connection '
        connectionTimer.Interval = 550
        connectionTimer.Start()

        ' Open the connection to the PLC '
        If Functions.PingIpAddress(plcAdress) Then
            Try
                Plc.Open()
            Catch ex As Exception
                MessageBox.Show("Cannot connect to PLC at " + plcAdress)
            End Try
        Else
            MessageBox.Show("Cannot connect to PLC at " + plcAdress)
        End If
    End Sub


    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ' Connect to PLC at 192.168.10.215 using S7.Net '
        Plc = New Plc(CpuType.S71200, plcAdress, 0, 1)
        If Functions.PingIpAddress(plcAdress) Then
            Try
                Plc.Open()
                If Plc.IsConnected Then
                    MessageBox.Show("Connected to PLC")
                Else
                    MessageBox.Show("Cannot connect to PLC")
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot connect to PLC at " + plcAdress)
            End Try
        Else
            MessageBox.Show("Cannot connect to PLC at " + plcAdress)
        End If
    End Sub

    Private Sub btnDisconnet_Click(sender As Object, e As EventArgs) Handles btnDisconnet.Click
        'disconnect from PLC '
        If Functions.PingIpAddress(plcAdress) AndAlso Plc IsNot Nothing Then
            Try
                Plc.Close()
                If Plc.IsConnected Then
                    MessageBox.Show("Cannot disconnect from PLC")
                Else
                    MessageBox.Show("Disconnected from PLC")
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot disconnect from PLC at " + plcAdress)
            End Try
        Else
            MessageBox.Show("There is no response or you are not connected to PLC at " + plcAdress)
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
        funcs.ToggleValueInPLC(Plc, 1994, 0)
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

    Private Sub connectionTimer_Tick(sender As Object, e As EventArgs) Handles connectionTimer.Tick
        If Functions.PingIpAddress(plcAdress) Then
            ' PLC is reachable
            lblPingStatus.Text = "Reachable"
            ' Check the connection status
            If Plc IsNot Nothing AndAlso Plc.IsConnected Then
                ' Connected to PLC
                lblConnectionStatus.Text = "Connected"
                ' Loop through the PlcDataItems
                For Each item As PlcDataItem In plcDataItems
                    Dim name As String = item.Name
                    Dim type As String = item.Type
                    Dim dbNumber As Integer = item.DbNumber
                    Dim startByteAddress As Integer = item.StartByteAddress
                    Dim byteCount As Integer = item.ByteCount
                    Dim textBoxName As String = item.TextBoxName

                    ' Find the TextBox control by its name
                    Dim textBox As System.Windows.Forms.TextBox = Functions.FindControl(Me, textBoxName)

                    If textBox IsNot Nothing Then
                        ' Read the value from the PLC based on the data type
                        Select Case type
                            Case "String"
                                Dim value As String = funcs.ReadStringFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                                textBox.Text = value
                            Case "Boolean"
                                Dim value As Boolean = funcs.ReadBooleanFromPLC(Plc, dbNumber, startByteAddress)
                                textBox.Text = value.ToString()
                            Case "Int"
                                Dim value As Integer = funcs.ReadIntFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                                textBox.Text = value.ToString()
                            Case "DInt"
                                Dim value As Integer = funcs.ReadDIntFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                                textBox.Text = value.ToString()
                            Case "Word"
                                Dim value As Integer = funcs.ReadWordFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                                textBox.Text = value.ToString()
                            Case "Real"
                                Dim value As Double = funcs.ReadRealFromPLC(Plc, dbNumber, startByteAddress, byteCount)
                                textBox.Text = value.ToString()
                            Case Else
                                MessageBox.Show($"Unknown data type '{type}'")
                        End Select
                    Else
                        MessageBox.Show($"TextBox control '{textBoxName}' not found.")
                    End If
                Next
            Else
                ' Not connected to PLC
                lblConnectionStatus.Text = "Disconnected"
            End If
        Else
            ' PLC is not reachable
            lblPingStatus.Text = "Not reachable"
            lblConnectionStatus.Text = "Disconnected"
        End If
    End Sub
End Class
