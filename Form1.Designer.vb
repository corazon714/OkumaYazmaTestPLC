﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        inputProduct = New TextBox()
        btnReadTest = New Button()
        btnReadBaleWeight = New Button()
        txtBaleWeight = New TextBox()
        btnWriteBaleWeight = New Button()
        txtWriteBaleWeight = New TextBox()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        btnReadPressInfo = New Button()
        txtPressInfo = New TextBox()
        SuspendLayout()
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(12, 12)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(91, 54)
        btnConnect.TabIndex = 0
        btnConnect.Text = "Connect"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' btnDisconnet
        ' 
        btnDisconnet.Location = New Point(109, 14)
        btnDisconnet.Name = "btnDisconnet"
        btnDisconnet.Size = New Size(96, 52)
        btnDisconnet.TabIndex = 1
        btnDisconnet.Text = "Disconnect"
        btnDisconnet.UseVisualStyleBackColor = True
        ' 
        ' btnReadProduct
        ' 
        btnReadProduct.Location = New Point(12, 72)
        btnReadProduct.Name = "btnReadProduct"
        btnReadProduct.Size = New Size(91, 25)
        btnReadProduct.TabIndex = 2
        btnReadProduct.Text = "Read Product"
        btnReadProduct.UseVisualStyleBackColor = True
        ' 
        ' txtProduct
        ' 
        txtProduct.Location = New Point(109, 74)
        txtProduct.Name = "txtProduct"
        txtProduct.Size = New Size(96, 23)
        txtProduct.TabIndex = 3
        ' 
        ' btnWriteProduct
        ' 
        btnWriteProduct.Location = New Point(12, 103)
        btnWriteProduct.Name = "btnWriteProduct"
        btnWriteProduct.Size = New Size(91, 23)
        btnWriteProduct.TabIndex = 4
        btnWriteProduct.Text = "Write Product"
        btnWriteProduct.UseVisualStyleBackColor = True
        ' 
        ' inputProduct
        ' 
        inputProduct.Location = New Point(109, 103)
        inputProduct.Name = "inputProduct"
        inputProduct.Size = New Size(96, 23)
        inputProduct.TabIndex = 5
        ' 
        ' btnReadTest
        ' 
        btnReadTest.Location = New Point(52, 132)
        btnReadTest.Name = "btnReadTest"
        btnReadTest.Size = New Size(112, 34)
        btnReadTest.TabIndex = 6
        btnReadTest.Text = "ReadTest"
        btnReadTest.UseVisualStyleBackColor = True
        ' 
        ' btnReadBaleWeight
        ' 
        btnReadBaleWeight.Location = New Point(12, 170)
        btnReadBaleWeight.Name = "btnReadBaleWeight"
        btnReadBaleWeight.Size = New Size(91, 39)
        btnReadBaleWeight.TabIndex = 7
        btnReadBaleWeight.Text = "Read Bale Weight"
        btnReadBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtBaleWeight
        ' 
        txtBaleWeight.Location = New Point(109, 179)
        txtBaleWeight.Name = "txtBaleWeight"
        txtBaleWeight.Size = New Size(100, 23)
        txtBaleWeight.TabIndex = 8
        ' 
        ' btnWriteBaleWeight
        ' 
        btnWriteBaleWeight.Location = New Point(12, 215)
        btnWriteBaleWeight.Name = "btnWriteBaleWeight"
        btnWriteBaleWeight.Size = New Size(91, 39)
        btnWriteBaleWeight.TabIndex = 9
        btnWriteBaleWeight.Text = "Write Bale Weight"
        btnWriteBaleWeight.UseVisualStyleBackColor = True
        ' 
        ' txtWriteBaleWeight
        ' 
        txtWriteBaleWeight.Location = New Point(109, 224)
        txtWriteBaleWeight.Name = "txtWriteBaleWeight"
        txtWriteBaleWeight.Size = New Size(100, 23)
        txtWriteBaleWeight.TabIndex = 10
        ' 
        ' btnReadPressInfo
        ' 
        btnReadPressInfo.Location = New Point(12, 260)
        btnReadPressInfo.Name = "btnReadPressInfo"
        btnReadPressInfo.Size = New Size(91, 39)
        btnReadPressInfo.TabIndex = 11
        btnReadPressInfo.Text = "Read Press Info"
        btnReadPressInfo.UseVisualStyleBackColor = True
        ' 
        ' txtPressInfo
        ' 
        txtPressInfo.Location = New Point(109, 269)
        txtPressInfo.Name = "txtPressInfo"
        txtPressInfo.Size = New Size(100, 23)
        txtPressInfo.TabIndex = 12
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(217, 409)
        Controls.Add(txtPressInfo)
        Controls.Add(btnReadPressInfo)
        Controls.Add(txtWriteBaleWeight)
        Controls.Add(btnWriteBaleWeight)
        Controls.Add(txtBaleWeight)
        Controls.Add(btnReadBaleWeight)
        Controls.Add(btnReadTest)
        Controls.Add(inputProduct)
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
    Friend WithEvents inputProduct As TextBox
    Friend WithEvents btnReadTest As Button
    Friend WithEvents btnReadBaleWeight As Button
    Friend WithEvents txtBaleWeight As TextBox
    Friend WithEvents btnWriteBaleWeight As Button
    Friend WithEvents txtWriteBaleWeight As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnReadPressInfo As Button
    Friend WithEvents txtPressInfo As TextBox
End Class