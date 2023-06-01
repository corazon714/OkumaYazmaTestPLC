Module Variables
    'Plc Adres'
    Public plcAdress As String = "192.168.10.215"

    Public Class PlcDataItem
        Public Property Name As String
        Public Property Type As String
        Public Property DbNumber As Integer
        Public Property StartByteAddress As Integer
        Public Property ByteCount As Integer
        Public Property TextBoxName As String

    End Class

    Public plcDataItems As PlcDataItem() = {
        New PlcDataItem() With {
            .Name = "request",
            .Type = "Boolean",
            .DbNumber = 1994,
            .StartByteAddress = 0,
            .ByteCount = 0,
            .TextBoxName = "txtReadTest"
        },
        New PlcDataItem() With {
            .Name = "baleWeight",
            .Type = "DInt",
            .DbNumber = 1994,
            .StartByteAddress = 2,
            .ByteCount = 4,
            .TextBoxName = "txtBaleWeight"
        },
        New PlcDataItem() With {
            .Name = "product",
            .Type = "String",
            .DbNumber = 1994,
            .StartByteAddress = 8,
            .ByteCount = 30,
            .TextBoxName = "txtProduct"
        },
        New PlcDataItem() With {
            .Name = "pressInfo",
            .Type = "Word",
            .DbNumber = 1994,
            .StartByteAddress = 38,
            .ByteCount = 2,
            .TextBoxName = "txtPressInfo"
        },
        New PlcDataItem() With {
            .Name = "productionCapacity",
            .Type = "Real",
            .DbNumber = 1994,
            .StartByteAddress = 40,
            .ByteCount = 4,
            .TextBoxName = "txtProductionCapacity"
        },
        New PlcDataItem() With {
            .Name = "estimatedBaleWeight",
            .Type = "Real",
            .DbNumber = 1994,
            .StartByteAddress = 44,
            .ByteCount = 4,
            .TextBoxName = "txtEstimatedBaleWeight"
        },
        New PlcDataItem() With {
            .Name = "baleWeightingMinute",
            .Type = "Int",
            .DbNumber = 1994,
            .StartByteAddress = 48,
            .ByteCount = 2,
            .TextBoxName = "txtWeightingMinute"
        },
        New PlcDataItem() With {
            .Name = "baleWeightingSecond",
            .Type = "Int",
            .DbNumber = 1994,
            .StartByteAddress = 50,
            .ByteCount = 2,
            .TextBoxName = "txtWeightingSecond"
        },
        New PlcDataItem() With {
            .Name = "pressingMinute",
            .Type = "Int",
            .DbNumber = 1994,
            .StartByteAddress = 52,
            .ByteCount = 2,
            .TextBoxName = "txtPressingMinute"
        },
        New PlcDataItem() With {
            .Name = "pressingSecond",
            .Type = "Int",
            .DbNumber = 1994,
            .StartByteAddress = 54,
            .ByteCount = 2,
            .TextBoxName = "txtPressingSecond"
        },
        New PlcDataItem() With {
            .Name = "baleID",
            .Type = "DInt",
            .DbNumber = 1994,
            .StartByteAddress = 56,
            .ByteCount = 4,
            .TextBoxName = "txtBaleID"
        },
        New PlcDataItem() With {
            .Name = "baleNo",
            .Type = "DInt",
            .DbNumber = 1994,
            .StartByteAddress = 60,
            .ByteCount = 4,
            .TextBoxName = "txtBaleNO"
        },
        New PlcDataItem() With {
            .Name = "lotNumber",
            .Type = "String",
            .DbNumber = 1994,
            .StartByteAddress = 68,
            .ByteCount = 30,
            .TextBoxName = "txtLotNumber"
        },
        New PlcDataItem() With {
            .Name = "rawMaterial",
            .Type = "String",
            .DbNumber = 1994,
            .StartByteAddress = 100,
            .ByteCount = 30,
            .TextBoxName = "txtRawMaterial"
        },
        New PlcDataItem() With {
            .Name = "orderNo",
            .Type = "String",
            .DbNumber = 1994,
            .StartByteAddress = 132,
            .ByteCount = 30,
            .TextBoxName = "txtOrderNO"
        }
    }

End Module