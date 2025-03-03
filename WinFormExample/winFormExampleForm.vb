'Rudy Earnest
'RCET 2265 
'Form Examples
'git link

Option Strict On
Option Explicit On
Public Class winFormExampleForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        'Me.Text = "Forms Are Cool"
        Me.Text = StrReverse(Me.Text)
    End Sub
End Class
