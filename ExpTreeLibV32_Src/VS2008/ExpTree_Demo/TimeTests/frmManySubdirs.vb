Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Public Class frmManySubdirs

    Private TMR As New MyTimer()
    Private TimeLog As New List(Of String)(128)     'For Timer logging
    Private Const TgtBase As String = "\\WHS1\Users\parsellj\SubDirTest"
    Private BaseItem As CShItem

    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
        Me.Close()
    End Sub

    Private Sub frmManySubdirs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TimeLog.Add("Starting Form @ " & Now().ToString)
        If Directory.Exists(TgtBase) Then
            TMR.TimeIncr("Check Base Exists", TimeLog)
        Else
            My.Computer.FileSystem.CreateDirectory(TgtBase)
            TMR.TimeIncr("Create Base", TimeLog)
        End If
        BaseItem = GetCShItem(TgtBase)
        TMR.TimeIncr("Create Base CShItem", TimeLog)
        txtDisplay.Lines = TimeLog.ToArray
    End Sub

    Private Sub cmdShowLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowLog.Click
        txtDisplay.Lines = TimeLog.ToArray
    End Sub

    Private Sub cmdPopulateDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPopulateDir.Click
        Dim ToGen As Integer
        Dim NumStr As String = InputBox("Enter how many to Create", "Create Dirs").Trim
        If NumStr.Length < 1 Then
            tsslMiddle.Text = "User Cancelled"
            Exit Sub
        End If
        If Not Int32.TryParse(NumStr, System.Globalization.NumberStyles.AllowThousands, Nothing, ToGen) Then
            tsslMiddle.Text = "Invalid Number to Generate"
            Exit Sub
        End If
        With prgBar
            .Maximum = ToGen - 1
            .Minimum = 0
            .Step = 500
        End With
        Dim Names() As String = GenFileNames(ToGen, False)
        TimeLog.Add("Creating " & ToGen & " SubDirs")
        txtDisplay.Lines = TimeLog.ToArray
        TMR = New MyTimer
        For i As Integer = 0 To ToGen - 1
            My.Computer.FileSystem.CreateDirectory(TgtBase & "\" & Names(i))
            If i = 0 OrElse i Mod 500 = 0 Then
                TMR.TimeIncr("Gen " & i + 1, TimeLog)
                prgBar.PerformStep()
                tsslRight.Text = i.ToString
                Application.DoEvents()
            End If
        Next
        TMR.TotalTime("Gen Complete", TimeLog)
        txtDisplay.Lines = TimeLog.ToArray
    End Sub

    Private Sub cmdRunTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRunTest.Click
        Dim TMR As New MyTimer
        Dim TDir As CShItem = GetCShItem(TgtBase & "\" & "Aah01452")   'actual known existant dir
        TMR.TimeIncr("Create CShItem", TimeLog)
        txtDisplay.Lines = TimeLog.ToArray

    End Sub
End Class