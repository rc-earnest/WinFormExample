'Rudy Earnest
'RCET 2265 
'Form Examples
'git link

Option Strict On
Option Explicit On
Public Class winFormExampleForm
    Sub Clear()
        TheFirstTextBox.Text = ""
        LastTextBox.Text = ""
        AgeTextBox.Text = ""
    End Sub








    'Event Handlers *****************************************************************************************
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        'Me.Text = "Forms Are Cool"
        ' Me.Text = StrReverse(Me.Text)
        Me.Text = TheFirstTextBox.Text & " " & LastTextBox.Text
        Clear()
    End Sub


End Class
