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
        RemoveButton.Enabled = False
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

    Function Scramble(thisString As String) As String
        Dim temp As String = ""
        Dim position As Integer
        Dim letters(Len(thisString) - 1) As String
        Dim count As Integer = 0

        If RandomCheckBox.Checked Then

            For i = 0 To UBound(letters)
                letters(i) = thisString(i)
            Next

            Do
                position = RandomNumberInRange(UBound(letters))
                If letters(position) <> "" Then
                    temp &= letters(position)
                    letters(position) = ""
                    count = count + 1
                End If
            Loop Until count >= Len(thisString)
        Else
            temp = thisString
        End If

        Return temp
    End Function

    Sub AddToList(thisString As String)
        DataListBox.Items.Add(thisString)
        ComboBoxBox.Items.Add(thisString)
    End Sub

    Function randomNumberBetween(min As Integer, max As Integer) As Integer
        Randomize()
        Dim randomNumber As Single
        randomNumber = Rnd()
        randomNumber *= max - min + 1
        randomNumber += min - 1
        Return CInt(Math.Ceiling(randomNumber))
    End Function


    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        'Me.Text = "Forms Are Cool"
        ' Me.Text = StrReverse(Me.Text)
        If UserInputIsValid() Then
            SetCase()
            SetFormat()
            TheFirstTextBox.Text = Scramble(TheFirstTextBox.Text)
            LastTextBox.Text = Scramble(LastTextBox.Text)
            ReverseString()
            AddToList(Me.Text)
            RemoveWhiteSpace()
            SetDefaults()
        End If

    End Sub
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function

    Private Sub winFormExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetDefaults()
    End Sub

    Private Sub DataListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataListBox.SelectedIndexChanged
        Me.Text = DataListBox.SelectedIndex.ToString
        If DataListBox.SelectedIndex = -1 Then
            RemoveButton.Enabled = False
        Else
            RemoveButton.Enabled = True
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Console.WriteLine($"The item at index {DataListBox.SelectedIndex} is {DataListBox.SelectedItem}!")
        DataListBox.Items.RemoveAt(DataListBox.SelectedIndex)

    End Sub

    Private Sub ComboBoxBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBox.SelectedIndexChanged
        Me.Text = ComboBoxBox.SelectedIndex.ToString
    End Sub
End Class




'tool tips 
'accept button and cancel button