
'Sean Gingerich
'RCET0265
'Spring 2021
'Stan's Grocery
'https://github.com/gingsean5/StansGrocery

Option Strict On
Option Explicit On

Public Class StansGroceryForm

    Dim food(256, 2) As String

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim temp(256) As String
        temp = Split(My.Resources.Grocery, vbNewLine)
        Dim temp1(256) As String
        Dim temp2() As String
        Dim temp3(256) As String
        Dim atemp1(256) As String
        Dim atemp2() As String
        Dim atemp3(256) As String
        Dim btemp1(256) As String
        Dim btemp2() As String
        Dim btemp3(256) As String


        For i = 0 To 255
            temp1 = Split(temp(i), "$$ITM")
            temp2 = Split(temp1(1), ",")
            temp3 = Split(temp2(0), """")
            food(i, 0) = temp3(0)
            DisplayListBox.Items.Add(food(i, 0))
        Next

        For i = 0 To 255
            atemp1 = Split(temp(i), "##LOC")
            atemp2 = Split(atemp1(1), ",")
            atemp3 = Split(atemp2(0), """")
            food(i, 1) = atemp3(0)
        Next

        For i = 0 To 255
            btemp1 = Split(temp(i), "%%CAT")
            btemp2 = Split(btemp1(1), ",")
            btemp3 = Split(btemp2(0), """")
            food(i, 2) = btemp3(0)
        Next



    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        If SearchTextBox.Text = "zzz" Then
            Me.Close()
        End If
    End Sub

    Function FindFood() As String

        Dim FoodItemString As String
        Dim TrueCount As Integer
        Dim FalseCount As Integer
        Dim FoodIndex As Object
        Dim OneDimFood(256) As String
        Dim ReturnString As String


        For i As Integer = 0 To 255
            OneDimFood(i) = food(i, 0)
            If SearchTextBox.Text = food(i, 0) Then

                TrueCount += 1
            Else

                FalseCount += 1
            End If

        Next
        If TrueCount = 1 Then
            FoodItemString = SearchTextBox.Text
            FoodIndex = Array.IndexOf(OneDimFood, FoodItemString)
            ReturnString = CStr(FoodIndex)
        Else
            ReturnString = "Sorry no matches for"
        End If
        Return ReturnString
    End Function

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click, SearchMenuItem.Click
        Dim FoodString As String = FindFood()
        Dim FoodIndex As Integer
        Dim Name As String
        Dim Aisle As String
        Dim Category As String


        If FoodString = "Sorry no matches for" Then
            DisplayLabel.Text = $"Sorry no matches for {SearchTextBox.Text}"
            DisplayListBox.Text = ""
        Else
            FoodIndex = CInt(FoodString)
            Name = food(FoodIndex, 0)
            Aisle = food(FoodIndex, 1)
            Category = food(FoodIndex, 2)
            DisplayLabel.Text = $"{Name} can be found on aisle {Aisle} with the {Category}"
        End If

        SelectItemComboBox.Items.Add(SearchTextBox.Text)

    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        SearchTextBox.Text = CStr(DisplayListBox.SelectedItem)
    End Sub

    Private Sub SelectItemComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectItemComboBox.SelectedIndexChanged
        SearchTextBox.Text = CStr(SelectItemComboBox.SelectedItem)
    End Sub

    Private Sub ExitMenuItem_Click(sender As Object, e As EventArgs) Handles ExitMenuItem.Click
        Me.Close()
    End Sub

End Class
