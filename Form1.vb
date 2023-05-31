Imports System.Text
Imports System.Threading
Imports S7.Net
Imports S7.Net.Types
Imports functions = OkumaYazmaTestPLC.functions


Public Class Form1
    Private Plc As Plc
    Dim funcs As New functions()

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ' Connect to PLC at 192.168.10.215 using S7.Net '
        Plc = New Plc(CpuType.S71200, "192.168.10.215", 0, 1)
        Plc.Open()
        If Plc.IsConnected Then
            MessageBox.Show("Connected to PLC")
        Else
            MessageBox.Show("Cannot connect to PLC")
        End If
    End Sub

    Private Sub btnDisconnet_Click(sender As Object, e As EventArgs) Handles btnDisconnet.Click
        'disconnect from PLC '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Plc.Close()
            If Plc.IsConnected Then
                MessageBox.Show("Cannot disconnect from PLC")
            Else
                MessageBox.Show("Disconnected from PLC")
            End If
        Else
            MessageBox.Show("Allready disconnected from PLC")
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
End Class
