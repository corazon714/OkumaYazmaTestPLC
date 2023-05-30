Imports System.Text
Imports S7.Net
Imports S7.Net.Types

Public Class Form1
    Private Plc As Plc
    'FUNCTIONS TO READ AND WRITE TO PLC
    Private Function ReadProductFromPLC() As String
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 8
            Dim byteCount As Integer = 30
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
            If rawData IsNot Nothing Then
                Dim result As String = Encoding.Default.GetString(rawData)
                Return result
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If

        Return String.Empty
    End Function
    Private Sub WriteProductToPLC(ByVal valueToWrite As String)
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            ' Define the expected length in the PLC '
            Dim expectedLength As Integer = 30

            ' Truncate or pad the valueToWrite to match the expected length '
            If valueToWrite.Length > expectedLength Then
                valueToWrite = valueToWrite.Substring(0, expectedLength)
            Else
                valueToWrite = valueToWrite.PadRight(expectedLength, Chr(0)) ' valueToWrite.PadRight(expectedLength, " ") or
            End If

            ' Write the value to DB 1994 offset 8.0 '
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 8
            Dim rawData As Byte() = Encoding.Default.GetBytes(valueToWrite)
            Plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

            MessageBox.Show("Data written to PLC successfully")
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub
    Private Sub ToggleValueInPLC()
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
    Private Function ReadDIntFromPLC() As Integer
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 2
            Dim byteCount As Integer = 4

            ' Read the DInt value from DB 1994 offset 2.0 '
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)

            If rawData IsNot Nothing Then
                Dim result As Integer = S7.Net.Types.DInt.FromByteArray(rawData)
                Return result
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If

        Return 0 ' Default value if reading fails
    End Function
    Private Sub WriteDIntToPLC(valueToWrite As Integer)
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 2

            ' Write the DInt value to DB 1994 offset 2.0 '
            Plc.Write(DataType.DataBlock, dbNumber, startByteAdr, valueToWrite)

            MessageBox.Show("Data written to PLC successfully")
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

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
        Dim product As String = ReadProductFromPLC()
        txtProduct.Text = product
    End Sub

    Private Sub btnWriteProduct_Click(sender As Object, e As EventArgs) Handles btnWriteProduct.Click
        ' Get the value from the inputProduct TextBox '
        Dim valueToWrite As String = inputProduct.Text

        ' Call the WriteProductToPLC function '
        WriteProductToPLC(valueToWrite)
        ' Read the value back from the PLC and display it in the txtProduct TextBox '
        Dim product As String = ReadProductFromPLC()
        txtProduct.Text = product
    End Sub

    Private Sub btnToggleValue_Click(sender As Object, e As EventArgs) Handles btnReadTest.Click
        ' Call the ToggleValueInPLC function '
        ToggleValueInPLC()
    End Sub

    Private Sub btnReadBaleWeight_Click(sender As Object, e As EventArgs) Handles btnReadBaleWeight.Click
        ' Call the ReadDIntFromPLC function '
        Dim result As Integer = ReadDIntFromPLC()
        txtBaleWeight.Text = result.ToString()
    End Sub

    Private Sub btnWriteBaleWeight_Click(sender As Object, e As EventArgs) Handles btnWriteBaleWeight.Click
        ' Convert the value from txtWriteBaleWeight to Integer and call the WriteDIntToPLC function '
        Dim valueToWrite As Integer

        If Integer.TryParse(txtWriteBaleWeight.Text, valueToWrite) Then
            WriteDIntToPLC(valueToWrite)
            ' Read the value back from the PLC and display it in the txtBaleWeight TextBox '
            Dim result As Integer = ReadDIntFromPLC()
            txtBaleWeight.Text = result.ToString()
        Else
            MessageBox.Show("Invalid value")
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

    Private Sub btnWritePressInfo_Click(sender As Object, e As EventArgs) Handles btnWritePressInfo.Click
        ' Write Word value to DB 1994, offset 38.0 '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 38
            Dim valueToWrite As UShort

            If UShort.TryParse(txtWritePressInfo.Text, valueToWrite) Then
                Dim data As Byte() = BitConverter.GetBytes(valueToWrite)
                Array.Reverse(data) ' Reverse the byte order for the Endian conversion '
                Plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                MessageBox.Show("Data written to PLC successfully")
            Else
                MessageBox.Show("Invalid value")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnReadProductionCapacity_Click(sender As Object, e As EventArgs) Handles btnReadProductionCapacity.Click
        ' Read Real value from DB 1994, offset 40.0 '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 40
            Dim byteCount As Integer = 4
            ' Read DB 1994, offset 40.0 '
            Dim rawData As Byte() = Plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
            If rawData IsNot Nothing Then
                Dim result As Single = S7.Net.Types.Real.FromByteArray(rawData)
                txtProductionCapacity.Text = result.ToString("F2") ' Format the result with 2 decimal places
            Else
                MessageBox.Show("Failed to read data from PLC")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

    Private Sub btnWriteProductionCapacity_Click(sender As Object, e As EventArgs) Handles btnWriteProductionCapacity.Click
        ' Write Real value to DB 1994, offset 40.0 '
        If Plc IsNot Nothing AndAlso Plc.IsConnected Then
            Dim dbNumber As Integer = 1994
            Dim startByteAdr As Integer = 40
            Dim valueToWrite As Single
            If Single.TryParse(txtWriteProductionCapacity.Text, valueToWrite) Then
                Dim data As Byte() = S7.Net.Types.Real.ToByteArray(valueToWrite)
                Plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                MessageBox.Show("Data written to PLC successfully")
            Else
                MessageBox.Show("Invalid value")
            End If
        Else
            MessageBox.Show("Not connected to PLC")
        End If
    End Sub

End Class
