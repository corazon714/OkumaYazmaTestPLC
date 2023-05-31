<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnConnect = New Button()
        btnDisconnet = New Button()
        btnReadProduct = New Button()
        txtProduct = New TextBox()
        btnWriteProduct = New Button()
        txtWriteProduct = New TextBox()
        btnReadTest = New Button()
        btnReadBaleWeight = New Button()
        txtBaleWeight = New TextBox()
        btnWriteBaleWeight = New Button()
        txtWriteBaleWeight = New TextBox()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        btnReadPressInfo = New Button()
        txtPressInfo = New TextBox()
        btnWritePressInfo = New Button()
        txtWritePressInfo = New TextBox()
        btnReadProductionCapacity = New Button()
        txtProductionCapacity = New TextBox()
        btnWriteProductionCapacity = New Button()
        txtWriteProductionCapacity = New TextBox()
        txtReadTest = New TextBox()
        btnReadRequest = New Button()
        btnEstimatedBaleWeight = New Button()
        txtEstimatedBaleWeight = New TextBox()
        btnWriteEstimatedBaleWeight = New Button()
        txtWriteEstimatedBaleWeight = New TextBox()
        btnBaleWeigthingMinute = New Button()
        txtWeightingMinute = New TextBox()
        btnWriteWeightingBale = New Button()
        txtWriteWeightingMinute = New TextBox()
        btnBaleWeightingSecond = New Button()
        txtWeightingSecond = New TextBox()
        btnWriteWeightingSecond = New Button()
        txtWriteWeightingSecond = New TextBox()
        btnReadPressingMinute = New Button()
        txtPressingMinute = New TextBox()
        btnWritePressingMinute = New Button()
        txtWritePressingMinute = New TextBox()
        btnReadPressingSecond = New Button()
        txtPressingSecond = New TextBox()
        btnWritePressingSeconds = New Button()
        txtWritePressingSecond = New TextBox()
        btnReadBaleID = New Button()
        txtBaleID = New TextBox()
        btnWriteBaleID = New Button()
        txtWriteBaleID = New TextBox()
        btnReadBaleNo = New Button()
        txtBaleNo = New TextBox()
        btnWriteBaleNo = New Button()
        txtWriteBaleNo = New TextBox()
        btnReadLotNumber = New Button()
        txtLotNumber = New TextBox()
        btnReadRawMaterial = New Button()
        txtRawMaterial = New TextBox()
        btnReadOrderNo = New Button()
        txtOrderNo = New TextBox()
        btnWriteLotNo = New Button()
        txtWriteLotNo = New TextBox()
        btnWriteRawMaterial = New Button()
        txtWriteRawMaterial = New TextBox()
        btnWriteOrderNo = New Button()
        txtWriteOrderNo = New TextBox()
        SuspendLayout()
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(517, 10)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(91, 54)
        btnConnect.TabIndex = 0
        btnConnect.Text = "Connect"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' btnDisconnet
        ' 
        btnDisconnet.Location = New Point(614, 10)
        btnDisconnet.Name = "btnDisconnet"
        btnDisconnet.Size = New Size(96, 52)
        btnDisconnet.TabIndex = 1
        btnDisconnet.Text = "Disconnect"
        btnDisconnet.UseVisualStyleBackColor = True
        ' 
        ' btnReadProduct
        ' 
        btnReadProduct.Location = New Point(12, 5)
        btnReadProduct.Name = "btnReadProduct"
        btnReadProduct.Size = New Size(91, 25)
        btnReadProduct.TabIndex = 2
        btnReadProduct.Text = "Read Product"
        btnReadProduct.UseVisualStyleBackColor = True
        ' 
        ' txtProduct
        ' 
        txtProduct.Location = New Point(109, 6)
        txtProduct.Name = "txtProduct"
        txtProduct.Size = New Size(100, 23)
        txtProduct.TabIndex = 3
        ' 
        ' btnWriteProduct
        ' 
        btnWriteProduct.Location = New Point(1009, 5)
        btnWriteProduct.Name = "btnWriteProduct"
        btnWriteProduct.Size = New Size(91, 23)
        btnWriteProduct.TabIndex = 4
        btnWriteProduct.Text = "Write Product"
        btnWriteProduct.UseVisualStyleBackColor = True
        ' 
        ' txtWriteProduct
        ' 
        txtWriteProduct.Location = New Point(1117, 5)
        txtWriteProduct.Name = "txtWriteProduct"
        txtWriteProduct.Size = New Size(100, 23)
        txtWriteProduct.TabIndex = 5
        ' 
        ' btnReadTest
        ' 
        btnReadTest.Location = New Point(517, 70)
        btnReadTest.Name = "btnReadTest"
        btnReadTest.Size = New Size(91, 43)
        btnReadTest.TabIndex = 6
        btnReadTest.Text = "Toggle Read Request"
        btnReadTest.UseVisualStyleBackColor = True
        ' 
        ' btnReadBaleWeight
        ' 
        btnReadBaleWeight.Location = New Point(12, 36)
        btnReadBaleWeight.Name = "btnReadBaleWeight"
        btnReadBaleWeight.Size = New Size(91, 39)
        btnReadBaleWeight.TabIndex = 7
        btnReadBaleWeight.Text = "Read Bale Weight"
        btnReadBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtBaleWeight
        ' 
        txtBaleWeight.Location = New Point(109, 45)
        txtBaleWeight.Name = "txtBaleWeight"
        txtBaleWeight.Size = New Size(100, 23)
        txtBaleWeight.TabIndex = 8
        ' 
        ' btnWriteBaleWeight
        ' 
        btnWriteBaleWeight.Location = New Point(1009, 34)
        btnWriteBaleWeight.Name = "btnWriteBaleWeight"
        btnWriteBaleWeight.Size = New Size(91, 39)
        btnWriteBaleWeight.TabIndex = 9
        btnWriteBaleWeight.Text = "Write Bale Weight"
        btnWriteBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtWriteBaleWeight
        ' 
        txtWriteBaleWeight.Location = New Point(1117, 41)
        txtWriteBaleWeight.Name = "txtWriteBaleWeight"
        txtWriteBaleWeight.Size = New Size(100, 23)
        txtWriteBaleWeight.TabIndex = 10
        ' 
        ' BackgroundWorker1
        ' 
        ' 
        ' btnReadPressInfo
        ' 
        btnReadPressInfo.Location = New Point(12, 81)
        btnReadPressInfo.Name = "btnReadPressInfo"
        btnReadPressInfo.Size = New Size(91, 39)
        btnReadPressInfo.TabIndex = 11
        btnReadPressInfo.Text = "Read Press Info"
        btnReadPressInfo.UseVisualStyleBackColor = True
        ' 
        ' txtPressInfo
        ' 
        txtPressInfo.Location = New Point(109, 90)
        txtPressInfo.Name = "txtPressInfo"
        txtPressInfo.Size = New Size(100, 23)
        txtPressInfo.TabIndex = 12
        ' 
        ' btnWritePressInfo
        ' 
        btnWritePressInfo.Location = New Point(1009, 79)
        btnWritePressInfo.Name = "btnWritePressInfo"
        btnWritePressInfo.Size = New Size(91, 39)
        btnWritePressInfo.TabIndex = 13
        btnWritePressInfo.Text = "Write Press Info"
        btnWritePressInfo.UseVisualStyleBackColor = True
        ' 
        ' txtWritePressInfo
        ' 
        txtWritePressInfo.Location = New Point(1117, 86)
        txtWritePressInfo.Name = "txtWritePressInfo"
        txtWritePressInfo.Size = New Size(100, 23)
        txtWritePressInfo.TabIndex = 14
        ' 
        ' btnReadProductionCapacity
        ' 
        btnReadProductionCapacity.Location = New Point(12, 126)
        btnReadProductionCapacity.Name = "btnReadProductionCapacity"
        btnReadProductionCapacity.Size = New Size(91, 53)
        btnReadProductionCapacity.TabIndex = 15
        btnReadProductionCapacity.Text = "Read Production Capacity"
        btnReadProductionCapacity.UseVisualStyleBackColor = True
        ' 
        ' txtProductionCapacity
        ' 
        txtProductionCapacity.Location = New Point(109, 142)
        txtProductionCapacity.Name = "txtProductionCapacity"
        txtProductionCapacity.Size = New Size(100, 23)
        txtProductionCapacity.TabIndex = 16
        ' 
        ' btnWriteProductionCapacity
        ' 
        btnWriteProductionCapacity.Location = New Point(1009, 124)
        btnWriteProductionCapacity.Name = "btnWriteProductionCapacity"
        btnWriteProductionCapacity.Size = New Size(91, 58)
        btnWriteProductionCapacity.TabIndex = 17
        btnWriteProductionCapacity.Text = "Write Production Capacity"
        btnWriteProductionCapacity.UseVisualStyleBackColor = True
        ' 
        ' txtWriteProductionCapacity
        ' 
        txtWriteProductionCapacity.Location = New Point(1117, 143)
        txtWriteProductionCapacity.Name = "txtWriteProductionCapacity"
        txtWriteProductionCapacity.Size = New Size(100, 23)
        txtWriteProductionCapacity.TabIndex = 18
        ' 
        ' txtReadTest
        ' 
        txtReadTest.Location = New Point(550, 119)
        txtReadTest.Name = "txtReadTest"
        txtReadTest.Size = New Size(112, 23)
        txtReadTest.TabIndex = 19
        ' 
        ' btnReadRequest
        ' 
        btnReadRequest.Location = New Point(614, 68)
        btnReadRequest.Name = "btnReadRequest"
        btnReadRequest.Size = New Size(96, 43)
        btnReadRequest.TabIndex = 20
        btnReadRequest.Text = "Read Request"
        btnReadRequest.UseVisualStyleBackColor = True
        ' 
        ' btnEstimatedBaleWeight
        ' 
        btnEstimatedBaleWeight.Location = New Point(12, 185)
        btnEstimatedBaleWeight.Name = "btnEstimatedBaleWeight"
        btnEstimatedBaleWeight.Size = New Size(91, 53)
        btnEstimatedBaleWeight.TabIndex = 21
        btnEstimatedBaleWeight.Text = "Read Estimated Bale Weight"
        btnEstimatedBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtEstimatedBaleWeight
        ' 
        txtEstimatedBaleWeight.Location = New Point(109, 201)
        txtEstimatedBaleWeight.Name = "txtEstimatedBaleWeight"
        txtEstimatedBaleWeight.Size = New Size(100, 23)
        txtEstimatedBaleWeight.TabIndex = 22
        ' 
        ' btnWriteEstimatedBaleWeight
        ' 
        btnWriteEstimatedBaleWeight.Location = New Point(1009, 188)
        btnWriteEstimatedBaleWeight.Name = "btnWriteEstimatedBaleWeight"
        btnWriteEstimatedBaleWeight.Size = New Size(91, 53)
        btnWriteEstimatedBaleWeight.TabIndex = 23
        btnWriteEstimatedBaleWeight.Text = "Write Estimated Bale Weight"
        btnWriteEstimatedBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtWriteEstimatedBaleWeight
        ' 
        txtWriteEstimatedBaleWeight.Location = New Point(1117, 201)
        txtWriteEstimatedBaleWeight.Name = "txtWriteEstimatedBaleWeight"
        txtWriteEstimatedBaleWeight.Size = New Size(100, 23)
        txtWriteEstimatedBaleWeight.TabIndex = 24
        ' 
        ' btnBaleWeigthingMinute
        ' 
        btnBaleWeigthingMinute.Location = New Point(12, 244)
        btnBaleWeigthingMinute.Name = "btnBaleWeigthingMinute"
        btnBaleWeigthingMinute.Size = New Size(91, 53)
        btnBaleWeigthingMinute.TabIndex = 25
        btnBaleWeigthingMinute.Text = "Read Minute for Bale Weight"
        btnBaleWeigthingMinute.UseVisualStyleBackColor = True
        ' 
        ' txtWeightingMinute
        ' 
        txtWeightingMinute.Location = New Point(109, 260)
        txtWeightingMinute.Name = "txtWeightingMinute"
        txtWeightingMinute.Size = New Size(100, 23)
        txtWeightingMinute.TabIndex = 26
        ' 
        ' btnWriteWeightingBale
        ' 
        btnWriteWeightingBale.Location = New Point(1009, 247)
        btnWriteWeightingBale.Name = "btnWriteWeightingBale"
        btnWriteWeightingBale.Size = New Size(91, 53)
        btnWriteWeightingBale.TabIndex = 27
        btnWriteWeightingBale.Text = "Write Minute for Bale Weight"
        btnWriteWeightingBale.UseVisualStyleBackColor = True
        ' 
        ' txtWriteWeightingMinute
        ' 
        txtWriteWeightingMinute.Location = New Point(1117, 263)
        txtWriteWeightingMinute.Name = "txtWriteWeightingMinute"
        txtWriteWeightingMinute.Size = New Size(100, 23)
        txtWriteWeightingMinute.TabIndex = 28
        ' 
        ' btnBaleWeightingSecond
        ' 
        btnBaleWeightingSecond.Location = New Point(12, 303)
        btnBaleWeightingSecond.Name = "btnBaleWeightingSecond"
        btnBaleWeightingSecond.Size = New Size(91, 53)
        btnBaleWeightingSecond.TabIndex = 29
        btnBaleWeightingSecond.Text = "Read Seconds for Bale Weight"
        btnBaleWeightingSecond.UseVisualStyleBackColor = True
        ' 
        ' txtWeightingSecond
        ' 
        txtWeightingSecond.Location = New Point(109, 319)
        txtWeightingSecond.Name = "txtWeightingSecond"
        txtWeightingSecond.Size = New Size(100, 23)
        txtWeightingSecond.TabIndex = 30
        ' 
        ' btnWriteWeightingSecond
        ' 
        btnWriteWeightingSecond.Location = New Point(1009, 306)
        btnWriteWeightingSecond.Name = "btnWriteWeightingSecond"
        btnWriteWeightingSecond.Size = New Size(91, 53)
        btnWriteWeightingSecond.TabIndex = 31
        btnWriteWeightingSecond.Text = "Write Seconds for Bale Weight"
        btnWriteWeightingSecond.UseVisualStyleBackColor = True
        ' 
        ' txtWriteWeightingSecond
        ' 
        txtWriteWeightingSecond.Location = New Point(1117, 322)
        txtWriteWeightingSecond.Name = "txtWriteWeightingSecond"
        txtWriteWeightingSecond.Size = New Size(100, 23)
        txtWriteWeightingSecond.TabIndex = 32
        ' 
        ' btnReadPressingMinute
        ' 
        btnReadPressingMinute.Location = New Point(12, 362)
        btnReadPressingMinute.Name = "btnReadPressingMinute"
        btnReadPressingMinute.Size = New Size(91, 53)
        btnReadPressingMinute.TabIndex = 33
        btnReadPressingMinute.Text = "Read Minutes for Bale Pressing"
        btnReadPressingMinute.UseVisualStyleBackColor = True
        ' 
        ' txtPressingMinute
        ' 
        txtPressingMinute.Location = New Point(109, 378)
        txtPressingMinute.Name = "txtPressingMinute"
        txtPressingMinute.Size = New Size(100, 23)
        txtPressingMinute.TabIndex = 34
        ' 
        ' btnWritePressingMinute
        ' 
        btnWritePressingMinute.Location = New Point(1009, 365)
        btnWritePressingMinute.Name = "btnWritePressingMinute"
        btnWritePressingMinute.Size = New Size(91, 53)
        btnWritePressingMinute.TabIndex = 35
        btnWritePressingMinute.Text = "Write Minutes for Bale Pressing"
        btnWritePressingMinute.UseVisualStyleBackColor = True
        ' 
        ' txtWritePressingMinute
        ' 
        txtWritePressingMinute.Location = New Point(1117, 378)
        txtWritePressingMinute.Name = "txtWritePressingMinute"
        txtWritePressingMinute.Size = New Size(100, 23)
        txtWritePressingMinute.TabIndex = 36
        ' 
        ' btnReadPressingSecond
        ' 
        btnReadPressingSecond.Location = New Point(12, 421)
        btnReadPressingSecond.Name = "btnReadPressingSecond"
        btnReadPressingSecond.Size = New Size(91, 53)
        btnReadPressingSecond.TabIndex = 37
        btnReadPressingSecond.Text = "Read Seconds for Bale Pressing"
        btnReadPressingSecond.UseVisualStyleBackColor = True
        ' 
        ' txtPressingSecond
        ' 
        txtPressingSecond.Location = New Point(109, 437)
        txtPressingSecond.Name = "txtPressingSecond"
        txtPressingSecond.Size = New Size(100, 23)
        txtPressingSecond.TabIndex = 38
        ' 
        ' btnWritePressingSeconds
        ' 
        btnWritePressingSeconds.Location = New Point(1009, 424)
        btnWritePressingSeconds.Name = "btnWritePressingSeconds"
        btnWritePressingSeconds.Size = New Size(91, 53)
        btnWritePressingSeconds.TabIndex = 39
        btnWritePressingSeconds.Text = "Write Seconds for Bale Pressing"
        btnWritePressingSeconds.UseVisualStyleBackColor = True
        ' 
        ' txtWritePressingSecond
        ' 
        txtWritePressingSecond.Location = New Point(1117, 440)
        txtWritePressingSecond.Name = "txtWritePressingSecond"
        txtWritePressingSecond.Size = New Size(100, 23)
        txtWritePressingSecond.TabIndex = 40
        ' 
        ' btnReadBaleID
        ' 
        btnReadBaleID.Location = New Point(275, 6)
        btnReadBaleID.Name = "btnReadBaleID"
        btnReadBaleID.Size = New Size(91, 25)
        btnReadBaleID.TabIndex = 41
        btnReadBaleID.Text = "Read Bale ID"
        btnReadBaleID.UseVisualStyleBackColor = True
        ' 
        ' txtBaleID
        ' 
        txtBaleID.Location = New Point(372, 7)
        txtBaleID.Name = "txtBaleID"
        txtBaleID.Size = New Size(100, 23)
        txtBaleID.TabIndex = 42
        ' 
        ' btnWriteBaleID
        ' 
        btnWriteBaleID.Location = New Point(762, 8)
        btnWriteBaleID.Name = "btnWriteBaleID"
        btnWriteBaleID.Size = New Size(91, 23)
        btnWriteBaleID.TabIndex = 43
        btnWriteBaleID.Text = "Write Bale ID"
        btnWriteBaleID.UseVisualStyleBackColor = True
        ' 
        ' txtWriteBaleID
        ' 
        txtWriteBaleID.Location = New Point(868, 9)
        txtWriteBaleID.Name = "txtWriteBaleID"
        txtWriteBaleID.Size = New Size(100, 23)
        txtWriteBaleID.TabIndex = 44
        ' 
        ' btnReadBaleNo
        ' 
        btnReadBaleNo.Location = New Point(275, 37)
        btnReadBaleNo.Name = "btnReadBaleNo"
        btnReadBaleNo.Size = New Size(91, 25)
        btnReadBaleNo.TabIndex = 45
        btnReadBaleNo.Text = "Read Bale No"
        btnReadBaleNo.UseVisualStyleBackColor = True
        ' 
        ' txtBaleNo
        ' 
        txtBaleNo.Location = New Point(372, 37)
        txtBaleNo.Name = "txtBaleNo"
        txtBaleNo.Size = New Size(100, 23)
        txtBaleNo.TabIndex = 46
        ' 
        ' btnWriteBaleNo
        ' 
        btnWriteBaleNo.Location = New Point(762, 37)
        btnWriteBaleNo.Name = "btnWriteBaleNo"
        btnWriteBaleNo.Size = New Size(91, 23)
        btnWriteBaleNo.TabIndex = 47
        btnWriteBaleNo.Text = "Write Bale No"
        btnWriteBaleNo.UseVisualStyleBackColor = True
        ' 
        ' txtWriteBaleNo
        ' 
        txtWriteBaleNo.Location = New Point(868, 36)
        txtWriteBaleNo.Name = "txtWriteBaleNo"
        txtWriteBaleNo.Size = New Size(100, 23)
        txtWriteBaleNo.TabIndex = 48
        ' 
        ' btnReadLotNumber
        ' 
        btnReadLotNumber.Location = New Point(275, 68)
        btnReadLotNumber.Name = "btnReadLotNumber"
        btnReadLotNumber.Size = New Size(91, 41)
        btnReadLotNumber.TabIndex = 49
        btnReadLotNumber.Text = "Read Lot Number"
        btnReadLotNumber.UseVisualStyleBackColor = True
        ' 
        ' txtLotNumber
        ' 
        txtLotNumber.Location = New Point(372, 78)
        txtLotNumber.Name = "txtLotNumber"
        txtLotNumber.Size = New Size(100, 23)
        txtLotNumber.TabIndex = 50
        ' 
        ' btnReadRawMaterial
        ' 
        btnReadRawMaterial.Location = New Point(275, 115)
        btnReadRawMaterial.Name = "btnReadRawMaterial"
        btnReadRawMaterial.Size = New Size(91, 41)
        btnReadRawMaterial.TabIndex = 51
        btnReadRawMaterial.Text = "Read Raw Material"
        btnReadRawMaterial.UseVisualStyleBackColor = True
        ' 
        ' txtRawMaterial
        ' 
        txtRawMaterial.Location = New Point(372, 124)
        txtRawMaterial.Name = "txtRawMaterial"
        txtRawMaterial.Size = New Size(100, 23)
        txtRawMaterial.TabIndex = 52
        ' 
        ' btnReadOrderNo
        ' 
        btnReadOrderNo.Location = New Point(275, 162)
        btnReadOrderNo.Name = "btnReadOrderNo"
        btnReadOrderNo.Size = New Size(91, 41)
        btnReadOrderNo.TabIndex = 53
        btnReadOrderNo.Text = "Read Order No"
        btnReadOrderNo.UseVisualStyleBackColor = True
        ' 
        ' txtOrderNo
        ' 
        txtOrderNo.Location = New Point(372, 172)
        txtOrderNo.Name = "txtOrderNo"
        txtOrderNo.Size = New Size(100, 23)
        txtOrderNo.TabIndex = 54
        ' 
        ' btnWriteLotNo
        ' 
        btnWriteLotNo.Location = New Point(762, 66)
        btnWriteLotNo.Name = "btnWriteLotNo"
        btnWriteLotNo.Size = New Size(91, 41)
        btnWriteLotNo.TabIndex = 55
        btnWriteLotNo.Text = "Write Lot Number"
        btnWriteLotNo.UseVisualStyleBackColor = True
        ' 
        ' txtWriteLotNo
        ' 
        txtWriteLotNo.Location = New Point(868, 76)
        txtWriteLotNo.Name = "txtWriteLotNo"
        txtWriteLotNo.Size = New Size(100, 23)
        txtWriteLotNo.TabIndex = 56
        ' 
        ' btnWriteRawMaterial
        ' 
        btnWriteRawMaterial.Location = New Point(762, 113)
        btnWriteRawMaterial.Name = "btnWriteRawMaterial"
        btnWriteRawMaterial.Size = New Size(91, 41)
        btnWriteRawMaterial.TabIndex = 57
        btnWriteRawMaterial.Text = "Write Raw Material"
        btnWriteRawMaterial.UseVisualStyleBackColor = True
        ' 
        ' txtWriteRawMaterial
        ' 
        txtWriteRawMaterial.Location = New Point(868, 119)
        txtWriteRawMaterial.Name = "txtWriteRawMaterial"
        txtWriteRawMaterial.Size = New Size(100, 23)
        txtWriteRawMaterial.TabIndex = 58
        ' 
        ' btnWriteOrderNo
        ' 
        btnWriteOrderNo.Location = New Point(762, 160)
        btnWriteOrderNo.Name = "btnWriteOrderNo"
        btnWriteOrderNo.Size = New Size(91, 41)
        btnWriteOrderNo.TabIndex = 59
        btnWriteOrderNo.Text = "Write Order Number"
        btnWriteOrderNo.UseVisualStyleBackColor = True
        ' 
        ' txtWriteOrderNo
        ' 
        txtWriteOrderNo.Location = New Point(868, 170)
        txtWriteOrderNo.Name = "txtWriteOrderNo"
        txtWriteOrderNo.Size = New Size(100, 23)
        txtWriteOrderNo.TabIndex = 60
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1225, 479)
        Controls.Add(txtWriteOrderNo)
        Controls.Add(btnWriteOrderNo)
        Controls.Add(txtWriteRawMaterial)
        Controls.Add(btnWriteRawMaterial)
        Controls.Add(txtWriteLotNo)
        Controls.Add(btnWriteLotNo)
        Controls.Add(txtOrderNo)
        Controls.Add(btnReadOrderNo)
        Controls.Add(txtRawMaterial)
        Controls.Add(btnReadRawMaterial)
        Controls.Add(txtLotNumber)
        Controls.Add(btnReadLotNumber)
        Controls.Add(txtWriteBaleNo)
        Controls.Add(btnWriteBaleNo)
        Controls.Add(txtBaleNo)
        Controls.Add(btnReadBaleNo)
        Controls.Add(txtWriteBaleID)
        Controls.Add(btnWriteBaleID)
        Controls.Add(txtBaleID)
        Controls.Add(btnReadBaleID)
        Controls.Add(txtWritePressingSecond)
        Controls.Add(btnWritePressingSeconds)
        Controls.Add(txtPressingSecond)
        Controls.Add(btnReadPressingSecond)
        Controls.Add(txtWritePressingMinute)
        Controls.Add(btnWritePressingMinute)
        Controls.Add(txtPressingMinute)
        Controls.Add(btnReadPressingMinute)
        Controls.Add(txtWriteWeightingSecond)
        Controls.Add(btnWriteWeightingSecond)
        Controls.Add(txtWeightingSecond)
        Controls.Add(btnBaleWeightingSecond)
        Controls.Add(txtWriteWeightingMinute)
        Controls.Add(btnWriteWeightingBale)
        Controls.Add(txtWeightingMinute)
        Controls.Add(btnBaleWeigthingMinute)
        Controls.Add(txtWriteEstimatedBaleWeight)
        Controls.Add(btnWriteEstimatedBaleWeight)
        Controls.Add(txtEstimatedBaleWeight)
        Controls.Add(btnEstimatedBaleWeight)
        Controls.Add(btnReadRequest)
        Controls.Add(txtReadTest)
        Controls.Add(txtWriteProductionCapacity)
        Controls.Add(btnWriteProductionCapacity)
        Controls.Add(txtProductionCapacity)
        Controls.Add(btnReadProductionCapacity)
        Controls.Add(txtWritePressInfo)
        Controls.Add(btnWritePressInfo)
        Controls.Add(txtPressInfo)
        Controls.Add(btnReadPressInfo)
        Controls.Add(txtWriteBaleWeight)
        Controls.Add(btnWriteBaleWeight)
        Controls.Add(txtBaleWeight)
        Controls.Add(btnReadBaleWeight)
        Controls.Add(btnReadTest)
        Controls.Add(txtWriteProduct)
        Controls.Add(btnWriteProduct)
        Controls.Add(txtProduct)
        Controls.Add(btnReadProduct)
        Controls.Add(btnDisconnet)
        Controls.Add(btnConnect)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnConnect As Button
    Friend WithEvents btnDisconnet As Button
    Friend WithEvents btnReadProduct As Button
    Friend WithEvents txtProduct As TextBox
    Friend WithEvents btnWriteProduct As Button
    Friend WithEvents txtWriteProduct As TextBox
    Friend WithEvents btnReadTest As Button
    Friend WithEvents btnReadBaleWeight As Button
    Friend WithEvents txtBaleWeight As TextBox
    Friend WithEvents btnWriteBaleWeight As Button
    Friend WithEvents txtWriteBaleWeight As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnReadPressInfo As Button
    Friend WithEvents txtPressInfo As TextBox
    Friend WithEvents btnWritePressInfo As Button
    Friend WithEvents txtWritePressInfo As TextBox
    Friend WithEvents btnReadProductionCapacity As Button
    Friend WithEvents txtProductionCapacity As TextBox
    Friend WithEvents btnWriteProductionCapacity As Button
    Friend WithEvents txtWriteProductionCapacity As TextBox
    Friend WithEvents txtReadTest As TextBox
    Friend WithEvents btnReadRequest As Button
    Friend WithEvents btnEstimatedBaleWeight As Button
    Friend WithEvents txtEstimatedBaleWeight As TextBox
    Friend WithEvents btnWriteEstimatedBaleWeight As Button
    Friend WithEvents txtWriteEstimatedBaleWeight As TextBox
    Friend WithEvents btnBaleWeigthingMinute As Button
    Friend WithEvents txtWeightingMinute As TextBox
    Friend WithEvents btnWriteWeightingBale As Button
    Friend WithEvents txtWriteWeightingMinute As TextBox
    Friend WithEvents btnBaleWeightingSecond As Button
    Friend WithEvents txtWeightingSecond As TextBox
    Friend WithEvents btnWriteWeightingSecond As Button
    Friend WithEvents txtWriteWeightingSecond As TextBox
    Friend WithEvents btnReadPressingMinute As Button
    Friend WithEvents txtPressingMinute As TextBox
    Friend WithEvents btnWritePressingMinute As Button
    Friend WithEvents txtWritePressingMinute As TextBox
    Friend WithEvents btnReadPressingSecond As Button
    Friend WithEvents txtPressingSecond As TextBox
    Friend WithEvents btnWritePressingSeconds As Button
    Friend WithEvents txtWritePressingSecond As TextBox
    Friend WithEvents btnReadBaleID As Button
    Friend WithEvents txtBaleID As TextBox
    Friend WithEvents btnWriteBaleID As Button
    Friend WithEvents txtWriteBaleID As TextBox
    Friend WithEvents btnReadBaleNo As Button
    Friend WithEvents txtBaleNo As TextBox
    Friend WithEvents btnWriteBaleNo As Button
    Friend WithEvents txtWriteBaleNo As TextBox
    Friend WithEvents btnReadLotNumber As Button
    Friend WithEvents txtLotNumber As TextBox
    Friend WithEvents btnReadRawMaterial As Button
    Friend WithEvents txtRawMaterial As TextBox
    Friend WithEvents btnReadOrderNo As Button
    Friend WithEvents txtOrderNo As TextBox
    Friend WithEvents btnWriteLotNo As Button
    Friend WithEvents txtWriteLotNo As TextBox
    Friend WithEvents btnWriteRawMaterial As Button
    Friend WithEvents txtWriteRawMaterial As TextBox
    Friend WithEvents btnWriteOrderNo As Button
    Friend WithEvents txtWriteOrderNo As TextBox
End Class
