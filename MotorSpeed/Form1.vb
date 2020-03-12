Imports System
Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Threading

Public Class Form1

    Dim MyPorts As Array
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyPorts = IO.Ports.SerialPort.GetPortNames()
        PortComboBox.Items.AddRange(MyPorts)
        ConnectButton.Enabled = True
        ConnectButton.BringToFront()

        DisconnectButton.Enabled = False
        DisconnectButton.SendToBack()

        BaudComboBox.SelectedItem = "115200"

    End Sub

    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        SerialPort1.PortName = PortComboBox.Text
        SerialPort1.BaudRate = BaudComboBox.Text
        SerialPort1.Open()

        ConnectButton.Enabled = False
        ConnectButton.SendToBack()

        DisconnectButton.Enabled = True
        DisconnectButton.BringToFront()
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)


    End Sub

    Private Sub ScanButton_Click(sender As Object, e As EventArgs) Handles ScanButton.Click
        PortComboBox.Items.Clear()
        MyPorts = IO.Ports.SerialPort.GetPortNames()
        PortComboBox.Items.AddRange(MyPorts)
    End Sub

    Private Sub DisconnectButton_Click(sender As Object, e As EventArgs) Handles DisconnectButton.Click
        DisconnectButton.Enabled = False
        DisconnectButton.SendToBack()

        SerialPort1.Close()

        ConnectButton.Enabled = True
        ConnectButton.BringToFront()
    End Sub
End Class
