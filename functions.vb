Imports System.Text
Imports S7.Net
Imports S7.Net.Types
Imports System.Net.NetworkInformation
Imports variables = OkumaYazmaTestPLC.Variables


Public Class Functions
    'GENERAL FUNCTIONS START'

    'This function tests the connection to the PLC with ping'
    Public Shared Function PingIpAddress(ipAddress As String) As Boolean
        Try
            Dim pingSender As New Ping()
            Dim reply As PingReply = pingSender.Send(ipAddress, 500) ' Set the timeout to 500ms

            If reply.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function FindControl(form As Form, name As String) As TextBox
        Dim control As Control = form.Controls.Find(name, True).FirstOrDefault()
        Return If(TypeOf control Is TextBox, DirectCast(control, TextBox), Nothing)
    End Function

    'GENERAL FUNCTIONS END'

    'TOGGLE FUNCTIONS START'

    'This function toggles the value of the bit in the PLC as TRUE if it is FALSE or FALSE if it is TRUE'
    Public Sub ToggleValueInPLC(plc As Plc, db As Integer, offset As Integer)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then

                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim currentValue As Boolean = (rawData(0) And &H1) <> 0

                ' Toggle the value and write it back to the PLC '
                Dim newValue As Boolean = Not currentValue
                If newValue Then
                    rawData(0) = rawData(0) Or &H1
                Else
                    rawData(0) = rawData(0) And Not &H1
                End If
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                MessageBox.Show("Value toggled successfully")
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'This turnes the value to TRUE'
    Public Sub SetBoolValueToTrueInPLC(plc As Plc, db As Integer, offset As Integer)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                rawData(0) = rawData(0) Or &H1 ' Set the bit value to 1
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                MessageBox.Show("Value set to True in PLC successfully")
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'This turnes the value to FALSE'
    Public Sub SetBoolValueToFalseInPLC(plc As Plc, db As Integer, offset As Integer)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                ' Read the byte containing the bit value '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                rawData(0) = rawData(0) And Not &H1 ' Set the bit value to 0
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                MessageBox.Show("Value set to False in PLC successfully")
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub


    'TOGGLE FUNCTIONS END'

    '---------------------------------------------------------------------------------------------------------------------------------------'

    'READ FUNCTIONS START'

    'This function reads the WORD value in the PLC'
    Public Function ReadWordFromPLC(plc As Plc, db As Integer, offset As Double, count As Integer)
        Dim resultText As String = String.Empty

        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim byteCount As Integer = CInt(count)

                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    Dim result As Integer = S7.Net.Types.Word.FromByteArray(rawData)
                    resultText = result.ToString()
                Else
                    MessageBox.Show("Failed to read data from PLC")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

        Return resultText
    End Function

    'This function reads the String[30] value in the PLC'
    Public Function ReadStringFromPLC(plc As Plc, db As Integer, offset As Double, byteCount As Integer) As String
        Dim result As String = String.Empty

        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    result = S7.Net.Types.String.FromByteArray(rawData)
                Else
                    MessageBox.Show("Failed to read data from PLC")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

        Return result
    End Function

    'This function reads the DINT value in the PLC'
    Public Function ReadDIntFromPLC(plc As Plc, db As Integer, offset As Double, byteCount As Integer) As String
        Dim Result As String = String.Empty

        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    Result = S7.Net.Types.DInt.FromByteArray(rawData)
                Else
                    MessageBox.Show("Failed to read data from PLC")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

        Return Result.ToString()
    End Function

    'This function reads the REAL value in the PLC'
    Public Function ReadRealFromPLC(plc As Plc, db As Integer, offset As Double, byteCount As Integer) As String
        Dim result As String = String.Empty

        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    result = S7.Net.Types.Real.FromByteArray(rawData) 'Format the result With 2 Decimal places
                Else
                    MessageBox.Show("Failed to read data from PLC")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

        Return result.ToString()
    End Function

    'This function reads the BOOL value in the PLC'
    Public Function ReadBooleanFromPLC(plc As Plc, db As Integer, offset As Integer) As Boolean
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                ' Read the byte containing the boolean value from the PLC '
                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, 1)
                Dim value As Boolean = (rawData(0) And &H1) <> 0

                Return value
            Else
                MessageBox.Show("Not connected to PLC")
                Return False
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
            Return False
        End If
    End Function

    'This function reads the INT value in the PLC'
    Public Function ReadIntFromPLC(plc As Plc, db As Integer, offset As Double, byteCount As Integer) As Integer
        Dim result As Integer = 0

        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                Dim rawData As Byte() = plc.ReadBytes(DataType.DataBlock, dbNumber, startByteAdr, byteCount)
                If rawData IsNot Nothing Then
                    result = S7.Net.Types.Int.FromByteArray(rawData)
                Else
                    MessageBox.Show("Failed to read data from PLC")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

        Return result
    End Function


    'READ FUNCTIONS END'

    '---------------------------------------------------------------------------------------------------------------------------------------'

    'WRITE FUNCTIONS START'

    'This function writes the WORD value to the PLC'
    Public Sub WriteWordToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim ushortValue As UShort

                If UShort.TryParse(valueToWrite, ushortValue) Then
                    Dim data As Byte() = BitConverter.GetBytes(ushortValue)
                    Array.Reverse(data) ' Reverse the byte order for the Endian conversion '
                    plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                    MessageBox.Show("Data written to PLC successfully")
                Else
                    MessageBox.Show("Invalid value")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'This function writes the String[30] value to the PLC'
    Public Sub WriteStringToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String, expectedLength As Integer)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                ' Truncate or pad the valueToWrite to match the expected length '
                If valueToWrite.Length > expectedLength Then
                    valueToWrite = valueToWrite.Substring(0, expectedLength)
                Else
                    valueToWrite = valueToWrite.PadRight(expectedLength, Chr(0)) 'valueToWrite.PadRight(expectedLength, " ") Or
                End If

                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim rawData As Byte() = Encoding.Default.GetBytes(valueToWrite)
                plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                MessageBox.Show("Data written to PLC successfully")
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'This function writes the DINT value to the PLC'
    Public Sub WriteDIntToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim int32Value As Int32

                If Int32.TryParse(valueToWrite, int32Value) Then
                    Dim data As Byte() = BitConverter.GetBytes(int32Value)
                    Array.Reverse(data) ' Reverse the byte order for the Endian conversion '
                    plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                    MessageBox.Show("Data written to PLC successfully")
                Else
                    MessageBox.Show("Invalid value")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If

    End Sub

    'This function writes the REAL value to the PLC'
    Public Sub WriteRealToPLC(plc As Plc, db As Integer, offset As Double, valueToWrite As String)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)
                Dim singleValue As Single
                If Single.TryParse(valueToWrite, singleValue) Then
                    Dim data As Byte() = S7.Net.Types.Real.ToByteArray(singleValue)
                    plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, data)
                    MessageBox.Show("Data written to PLC successfully")
                Else
                    MessageBox.Show("Invalid value")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'This function writes the INT value to the PLC'
    Public Sub WriteIntToPLC(plc As Plc, db As Integer, offset As Double, value As String)
        If PingIpAddress(plcAdress) AndAlso plc IsNot Nothing Then
            If plc.IsConnected Then
                Dim dbNumber As Integer = CInt(db)
                Dim startByteAdr As Integer = CInt(offset)

                If Not String.IsNullOrEmpty(value) AndAlso Integer.TryParse(value, Nothing) Then
                    Dim intValue As Integer = Integer.Parse(value)
                    If intValue >= Short.MinValue AndAlso intValue <= Short.MaxValue Then
                        Dim rawData As Byte() = S7.Net.Types.Int.ToByteArray(intValue)
                        plc.WriteBytes(DataType.DataBlock, dbNumber, startByteAdr, rawData)

                        MessageBox.Show("Value written to PLC successfully")
                    Else
                        MessageBox.Show("Invalid value. Value must be within the range of a signed 16-bit integer (Short).")
                    End If
                Else
                    MessageBox.Show("Invalid value. Value must be a valid integer.")
                End If
            Else
                MessageBox.Show("Not connected to PLC")
            End If
        Else
            MessageBox.Show("Plc is not responding or not connected at " + plcAdress)
        End If
    End Sub

    'WRITE FUNCTIONS END'

End Class
