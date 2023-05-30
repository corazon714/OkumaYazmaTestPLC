Imports System.Text
Imports S7.Net
Imports S7.Net.Types

Public Class Form1
    Private Plc As Plc

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        ' Connect to PLC at 192.168.10.125 using S7.Net '
        Plc = New Plc(CpuType.S71200, "192.168.10.215", 0, 1)
        Plc.Open()

        If Plc.IsConnected Then
            MessageBox.Show("Connected to PLC")
        Else
            MessageBox.Show("Cannot connect to the PLC")
        End If
    End Sub

    Private Sub btnDisconnet_Click(sender As Object, e As EventArgs) Handles btnDisconnet.Click
        'disconnect from PLC '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Plc.Close()

            If Plc.IsConnected Then
                MessageBox.Show("Still connected")
            Else
                MessageBox.Show("Disconnected from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnReadProduct_Click(sender As Object, e As EventArgs) Handles btnReadProduct.Click
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            ' Read the value from DB 1994 offset 6.0 value is String[30] '
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 8
            Dim byteCount As Integer = 30
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
            If rawData IsNot Nothing Then
                Dim result As String = Encoding.Default.GetString(rawData)
                txtProduct.Text = result
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnWriteProduct_Click(sender As Object, e As EventArgs) Handles btnWriteProduct.Click
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            ' Get the value from the inputProduct TextBox '
            Dim valueToWrite As String = inputProduct.Text

            ' Define the expected length in the PLC '
            Dim expectedLength As Integer = 30

            ' Truncate or pad the valueToWrite to match the expected length '
            If valueToWrite.Length > expectedLength Then
                valueToWrite = valueToWrite.Substring(0, expectedLength)
            Else
                valueToWrite = valueToWrite.PadRight(expectedLength, Chr(0)) 'valueToWrite.PadRight(expectedLength, " ") Or
            End If

            ' Write the value to DB 1994 offset 6.0 '
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 8 'simantic screen reads from 8.
            Dim rawData As Byte() = Encoding.Default.GetBytes(valueToWrite)
            Plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

            MessageBox.Show("Data written to PLC successfully")
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnReadTest_Click(sender As Object, e As EventArgs) Handles btnReadTest.Click
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            ' Read the current value from DB 1994, offset 0.0 '
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 0

            ' Read the byte containing the bit value '
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
            Dim currentValue As Boolean = (rawData(0) And &H1) <> 0

            ' Toggle the value and write it back to the PLC '
            Dim newValue As Boolean = Not currentValue
            If newValue Then
                rawData(0) = rawData(0) Or &H1
            Else
                rawData(0) = rawData(0) And Not &H1
            End If
            Plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

            MessageBox.Show("Value toggled successfully")
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnReadBaleWeight_Click(sender As Object, e As EventArgs) Handles btnReadBaleWeight.Click
        'read the value which is DInt from DB 1994 offset 2.0 '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 2
            Dim byteCount As Integer = 4
            'READ DB 1994 OFFSET 2.0'
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
            If rawData IsNot Nothing Then
                Dim result As Integer = S7.Net.Types.DInt.FromByteArray(rawData)
                txtBaleWeight.Text = result.ToString()
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnWriteBaleWeight_Click(sender As Object, e As EventArgs) Handles btnWriteBaleWeight.Click
        ' Write the value from txtWriteBaleWeight to DB 1994, offset 2.0 as DInt '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 2
            Dim valueToWrite As Integer

            If Integer.TryParse(txtWriteBaleWeight.Text, valueToWrite) Then
                Plc.Write(DataType.DataBlock, dbNumber, startByteAdr, valueToWrite)
                MessageBox.Show("Data written to PLC successfully")
            Else
                MessageBox.Show("Invalid value")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnReadPressInfo.Click
        'read Word value from offset 38.0 '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 38
            Dim byteCount As Integer = 2
            'READ DB 1994 OFFSET 38.0'
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
            If rawData IsNot Nothing Then
                Dim result As Integer = S7.Net.Types.Word.FromByteArray(rawData)
                txtPressInfo.Text = result.ToString()
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub
End Class
