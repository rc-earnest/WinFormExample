'Rudy Earnest
'RCET 2265 
'Form Examples
'git link

Option Strict On
Option Explicit On
Public Class winFormExampleForm
    Sub SetDefaults()
        TheFirstTextBox.Focus()
        TheFirstTextBox.Text = ""
        LastTextBox.Text = ""
        AgeTextBox.Text = ""
        UpperRadioButton.Checked = True
        LastFirstRadioButton.Checked = True
        ReverseCheckBox.Checked = False
        WhiteSpaceCheckBox.Checked = False
        RandomCheckBox.Checked = False
    End Sub

    Sub ReverseString()
        If ReverseCheckBox.Checked = True Then
            Me.Text = StrReverse(Me.Text)
        End If
    End Sub

    Sub RemoveWhiteSpace()
        If WhiteSpaceCheckBox.Checked Then
            Me.Text = Replace(Me.Text, " ", "")
        End If
    End Sub

    Sub SetCase()
        If UpperRadioButton.Checked Then
            TheFirstTextBox.Text = UCase(TheFirstTextBox.Text)
            LastTextBox.Text = UCase(LastTextBox.Text)

        ElseIf LowerRadioButton.Checked Then
            TheFirstTextBox.Text = LCase(TheFirstTextBox.Text)
            LastTextBox.Text = LCase(LastTextBox.Text)

        End If
    End Sub

    Sub SetFormat()
        If FirstLastRadioButton.Checked Then
            Me.Text = (TheFirstTextBox.Text & ", " & LastTextBox.Text)

        ElseIf LastFirstRadioButton.Checked Then
            Me.Text = (LastTextBox.Text & ", " & TheFirstTextBox.Text)

        End If
    End Sub


    'Event Handlers *****************************************************************************************
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function UserInputIsValid() As Boolean
        Dim valid As Boolean = True
        Dim message As String
        If IsNumeric(AgeTextBox.Text) = False Then
            valid = False
            AgeTextBox.Focus()
            message &= "Please enter a valid age" & vbNewLine
        End If

        If LastTextBox.Text = "" Then
            valid = False
            LastTextBox.Focus()
            message &= "Last name is required" & vbNewLine
        End If

        If TheFirstTextBox.Text = "" Then
            valid = False
            TheFirstTextBox.Focus()
            message &= "First name is required" & vbNewLine
        End If

        If Not valid Then
            MsgBox(message, MsgBoxStyle.Exclamation, "User Input Fail!!!")
        End If

        Return valid
    End Function


    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        'Me.Text = "Forms Are Cool"
        ' Me.Text = StrReverse(Me.Text)
        If UserInputIsValid() Then

            SetCase()
            SetFormat()
            ReverseString()
            RemoveWhiteSpace()
            SetDefaults()
        End If

    End Sub

    Private Sub winFormExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDefaults()
    End Sub


End Class
