Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module modTimeTests

#Region "   Transform raw timer data to Tab separated file"
    ''' <summary>
    ''' This is the Class used to build all but the last data sets for Excel
    ''' </summary>
    ''' <remarks></remarks>
    Private Class TimeRecord
        Private m_Remarks As String = ""
        Private m_DirName As String = ""
        Private m_GetItems As Double = -1
        Private m_Sorting As Double = -1
        Private m_InfoTime As Double = -1
        Private m_FirstItem As Double = -1
        Private m_FirstN As Double = -1
        Private m_GenTime As Double = -1
        Private m_IconTime As Double = -1
        Private m_Total As Double = -1
        Private m_Reboot As Integer = -1
        Private m_Icons As Integer = -1
        Private m_FileInfo As Integer = -1

        Sub New(ByVal SR As StreamReader, ByVal Remarks As String, ByVal DirName As String)
            m_Remarks = Remarks
            Dim RemParts() As String = Remarks.Split(New Char() {" ", ","}, StringSplitOptions.RemoveEmptyEntries)
            Dim Negate As Boolean = False
            Dim ElemCnt As Integer = 0
            Dim i As Integer = 0
            Do While i < RemParts.Length AndAlso ElemCnt < 3
                If RemParts(i).Equals("No", StringComparison.CurrentCultureIgnoreCase) Then
                    Negate = True
                    i += 1
                    Continue Do
                ElseIf RemParts(i).Equals("Reboot", StringComparison.CurrentCultureIgnoreCase) Then
                    m_Reboot = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                ElseIf RemParts(i).Equals("Icons", StringComparison.CurrentCultureIgnoreCase) Then
                    m_Icons = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                ElseIf RemParts(i).Equals("FileInfo", StringComparison.CurrentCultureIgnoreCase) Then
                    m_FileInfo = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                Else
                    i += 1
                End If
            Loop
            m_DirName = DirName
            Do Until SR.Peek = -1 OrElse Chr(SR.Peek) = vbCr
                Dim Inp As String = SR.ReadLine
                If Inp = String.Empty Then Continue Do
                If Inp.StartsWith("GetItems") Then
                    m_GetItems = GetDbl(Inp)
                ElseIf Inp.StartsWith("Sort") Then
                    m_Sorting = GetDbl(Inp)
                ElseIf Inp.StartsWith("InfoTime") Then
                    m_InfoTime = GetDbl(Inp)
                ElseIf Inp.StartsWith("FirstItem") Then
                    m_FirstItem = GetDbl(Inp)
                ElseIf Inp.StartsWith("First") Then
                    m_FirstN = GetDbl(Inp)
                ElseIf Inp.StartsWith("GenTime") Then
                    m_GenTime = GetDbl(Inp)
                ElseIf Inp.StartsWith("IconTime") Then
                    m_IconTime = GetDbl(Inp)
                ElseIf Inp.StartsWith("Total") Then
                    m_Total = GetDbl(Inp)
                End If
            Loop
        End Sub

        Friend Shared Function GetDbl(ByVal S As String) As Double
            Dim Parts() As String = S.Split()
            If Not Parts.Length = 3 OrElse Not Double.TryParse(Parts(1), GetDbl) Then
                GetDbl = -1
            End If
        End Function

        Public Overrides Function ToString() As String
            Dim RText() As Char = {"?", "N", "Y"}
            Dim SB As New StringBuilder
            If m_GetItems >= 0 Then SB.Append(m_GetItems.ToString("0.####"))
            SB.Append(vbTab)
            If m_Sorting >= 0 Then SB.Append(m_Sorting.ToString("0.####"))
            SB.Append(vbTab)
            If m_InfoTime >= 0 Then SB.Append(m_InfoTime.ToString("0.####"))
            SB.Append(vbTab)
            If m_FirstItem >= 0 Then SB.Append(m_FirstItem.ToString("0.####"))
            SB.Append(vbTab)
            If m_FirstN >= 0 Then SB.Append(m_FirstN.ToString("0.####"))
            SB.Append(vbTab)
            If m_GenTime >= 0 Then SB.Append(m_GenTime.ToString("0.####"))
            SB.Append(vbTab)
            If m_IconTime >= 0 Then SB.Append(m_IconTime.ToString("0.####"))
            SB.Append(vbTab)
            If m_Total >= 0 Then SB.Append(m_Total.ToString("0.####"))
            SB.Append(vbTab)
            SB.Append(RText(m_Reboot + 1))
            SB.Append(vbTab)
            SB.Append(RText(m_Icons + 1))
            SB.Append(vbTab)
            SB.Append(RText(m_FileInfo + 1))
            SB.Append(vbTab)
            SB.Append(m_Remarks)
            Return SB.ToString
        End Function

#Region "   Properties"
        Public Property Remarks() As String
            Get
                Return m_Remarks
            End Get
            Set(ByVal value As String)
                m_Remarks = value
            End Set
        End Property

        Public Property DirName() As String
            Get
                Return m_DirName
            End Get
            Set(ByVal Value As String)
                m_DirName = Value
            End Set
        End Property
        Public Property GetItems() As Double
            Get
                Return m_GetItems
            End Get
            Set(ByVal Value As Double)
                m_GetItems = Value
            End Set
        End Property
        Public Property Sorting() As Double
            Get
                Return m_Sorting
            End Get
            Set(ByVal Value As Double)
                m_Sorting = Value
            End Set
        End Property
        Public Property FirstItem() As Double
            Get
                Return m_FirstItem
            End Get
            Set(ByVal Value As Double)
                m_FirstItem = Value
            End Set
        End Property
        Public Property FirstN() As Double
            Get
                Return m_FirstN
            End Get
            Set(ByVal Value As Double)
                m_FirstN = Value
            End Set
        End Property
        Public Property Total() As Double
            Get
                Return m_Total
            End Get
            Set(ByVal Value As Double)
                m_Total = Value
            End Set
        End Property
#End Region

    End Class

    Private Class TimeRecord2
        Private m_Remarks As String = ""
        Private m_DirName As String = ""
        Private m_Vals As New List(Of KeyValuePair(Of String, Double))
        Private m_Reboot As Integer = -1
        Private m_Icons As Integer = -1
        Private m_FileInfo As Integer = -1
        Private Shared Cols As New List(Of String)

        Sub New(ByVal SR As StreamReader, ByVal Remarks As String, ByVal DirName As String)
            m_Remarks = Remarks
            Dim RemParts() As String = Remarks.Split(New Char() {" ", ","}, StringSplitOptions.RemoveEmptyEntries)
            Dim Negate As Boolean = False
            Dim ElemCnt As Integer = 0
            Dim i As Integer = 0
            Do While i < RemParts.Length AndAlso ElemCnt < 3
                If RemParts(i).Equals("No", StringComparison.CurrentCultureIgnoreCase) Then
                    Negate = True
                    i += 1
                    Continue Do
                ElseIf RemParts(i).Equals("Reboot", StringComparison.CurrentCultureIgnoreCase) Then
                    m_Reboot = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                ElseIf RemParts(i).Equals("Icons", StringComparison.CurrentCultureIgnoreCase) Then
                    m_Icons = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                ElseIf RemParts(i).Equals("FileInfo", StringComparison.CurrentCultureIgnoreCase) Then
                    m_FileInfo = IIf(Negate, 0, 1)
                    Negate = False
                    i += 1 : ElemCnt += 1
                    Continue Do
                Else
                    i += 1
                End If
            Loop
            m_DirName = DirName
            Do Until SR.Peek = -1 OrElse Chr(SR.Peek) = vbCr
                Dim Inp As String = SR.ReadLine
                If Inp = String.Empty Then Continue Do
                Dim InpParts() As String = Inp.Split()
                If InpParts.Length <> 3 Then Continue Do
                If InpParts(0).StartsWith("SparseLoad") Then InpParts(0) = "SparseLoad"
                m_Vals.Add(New KeyValuePair(Of String, Double)(InpParts(0), TimeRecord.GetDbl(Inp)))
                If Cols.IndexOf(InpParts(0)) < 0 Then Cols.Add(InpParts(0))
            Loop
        End Sub

        Public Overrides Function ToString() As String
            Dim RText() As Char = {"?", "N", "Y"}
            Dim SB As New StringBuilder
            For Each kvp As KeyValuePair(Of String, Double) In m_Vals
                SB.Append(kvp.Value.ToString("0.####"))
                SB.Append(vbTab)
            Next
            SB.Append(RText(m_Reboot + 1))
            SB.Append(vbTab)
            SB.Append(RText(m_Icons + 1))
            SB.Append(vbTab)
            SB.Append(RText(m_FileInfo + 1))
            SB.Append(vbTab)
            SB.Append(m_Remarks)
            Return SB.ToString
        End Function

        Friend Shared Function GetColHead() As String
            Dim SB As New StringBuilder(128)
            For Each ch As String In Cols
                SB.Append(ch) : SB.Append(vbTab)
            Next
            SB.Append("Reboot") : SB.Append(vbTab)
            SB.Append("Icons") : SB.Append(vbTab)
            SB.Append("FileInfo") : SB.Append(vbTab)
            SB.Append("Remarks")
            Return SB.ToString
        End Function
    End Class

    Public Sub ParseTimeTests(ByVal InpFile As String)
        Dim Remarks As String = ""
        Dim DirPath As String
        Dim DataDict As New Dictionary(Of String, List(Of TimeRecord2))
        Using SR As New StreamReader(InpFile)
            Do While SR.Peek >= 0
                Dim Inp As String = SR.ReadLine
                If Inp.Length < 1 Then Continue Do
                If Inp.StartsWith("'") Then
                    Remarks = Inp.Substring(1)
                ElseIf Inp.StartsWith("ANS - Dir = ") Then
                    DirPath = Inp.Substring(12).Split()(0)  'OK here, not in general case
                    Dim TR As New TimeRecord2(SR, Remarks, DirPath)
                    If Not DataDict.ContainsKey(DirPath) Then
                        DataDict.Add(DirPath, New List(Of TimeRecord2))
                    End If
                    DataDict(DirPath).Add(TR)
                End If
            Loop
        End Using
        Dim OutFile As String = Path.GetDirectoryName(InpFile) & "\" & Path.GetFileNameWithoutExtension(InpFile) & "TSF" & Path.GetExtension(InpFile)
        Using SW As New StreamWriter(OutFile, False)
            SW.WriteLine(TimeRecord2.GetColHead)
            For Each Key As String In DataDict.Keys
                SW.WriteLine(Key)
                SW.WriteLine(TimeRecord2.GetColHead)
                For Each TR As TimeRecord2 In DataDict(Key)
                    SW.WriteLine(TR.ToString)
                Next
            Next
        End Using
    End Sub

    Public Function ColHeads() As String
        Dim SB As New StringBuilder
        With SB
            .Append("GetItems") : .Append(vbTab)
            .Append("Sort") : .Append(vbTab)
            .Append("InfoTime") : .Append(vbTab)
            .Append("FirstItem") : .Append(vbTab)
            .Append("FirstN") : .Append(vbTab)
            .Append("GenTime") : .Append(vbTab)
            .Append("IconTime") : .Append(vbTab)
            .Append("Total") : .Append(vbTab)
            .Append("Reboot") : .Append(vbTab)
            .Append("Icons") : .Append(vbTab)
            .Append("FileInfo") : .Append(vbTab)
            .Append("Remarks")
        End With
        Return SB.ToString
    End Function

#End Region

#Region "   Create Random Empty Files"

#Region "       Ext Freq Tables"
    Private Freq() As Integer = { _
                            3332, _
4520, _
5071, _
5522, _
5882, _
6239, _
6580, _
6904, _
7179, _
7391, _
7577, _
7749, _
7901, _
8041, _
8152, _
8262, _
8366, _
8467, _
8564, _
8655, _
8744, _
8825, _
8902, _
8974, _
9044, _
9114, _
9181, _
9242, _
9299, _
9355, _
9411, _
9462, _
9510, _
9557, _
9600, _
9641, _
9678, _
9709, _
9740, _
9765, _
9787, _
9804, _
9819, _
9833, _
9847, _
9860, _
9873, _
9885, _
9897, _
9909, _
9920, _
9931, _
9942, _
9952, _
9961, _
9970, _
9979, _
9986, _
9993, _
10000}
    Private Exts() As String = { _
                            ".jpg", _
".vb", _
".resources", _
".dll", _
".resx", _
".pdb", _
".exe", _
".txt", _
".xml", _
".htm", _
".gif", _
".cache", _
".log", _
".xls", _
".ico", _
".frm", _
".doc", _
".vbproj", _
".sln", _
".suo", _
".config", _
".user", _
".pdf", _
".bas", _
".vbp", _
".vbw", _
".css", _
".xsd", _
".settings", _
".datasource", _
".myapp", _
".zip", _
".cls", _
".frx", _
".bmp", _
".tmp", _
".manifest", _
".xsc", _
".xss", _
".xsx", _
".mdb", _
".h", _
".cs", _
".csv", _
".js", _
".sav", _
".tif", _
".rtf", _
".xslt", _
".html", _
".asc", _
".cpp", _
".obj", _
".tlog", _
".lib", _
".sbr", _
".vsd", _
".c", _
".csproj", _
".db"}
#End Region

    Private Function GenExt(ByVal RandObj As Random) As String
        Dim Index As Integer = RandObj.Next(0, 10000)
        Dim i As Integer
        Do Until Freq(i) > Index
            i += 1
        Loop
        Return Exts(i)
    End Function

    ''' <summary>
    ''' Generate ToGen semi-random unique Strings in the Format "Xabc0003" for use as File or Directory names
    ''' </summary>
    ''' <param name="ToGen">Number to generate</param>
    ''' <returns>A String Array Containing ToGen unique Strings</returns>
    ''' <remarks></remarks>
    Public Function GenFileNames(ByVal ToGen As Integer, Optional ByVal AddExt As Boolean = True) As String()
        Dim RVal(ToGen - 1) As String
        Dim rDict As New Dictionary(Of String, String)(ToGen - 1)
        Dim RandObj As New Random()
        Dim LCLetters As String = "abcdefghijklmnopqrstuvwxyz"
        Dim UCLetters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        For i As Integer = 0 To ToGen - 1
            Do
                Dim SB As New StringBuilder
                SB.Append(UCLetters.Chars(RandObj.Next(0, 25)))
                SB.Append(LCLetters.Chars(RandObj.Next(0, 25)))
                SB.Append(LCLetters.Chars(RandObj.Next(0, 25)))
                SB.Append(i.ToString("0000#"))
                If AddExt Then SB.Append(GenExt(RandObj))
                RVal(i) = SB.ToString
            Loop Until Not rDict.ContainsKey(RVal(i))
            rDict.Add(RVal(i), Nothing)
        Next
        Return RVal
    End Function

    Public Function GenFiles(ByVal DirName As String, ByVal NrToGen As Integer) As Integer
        Dim Names() As String = GenFileNames(NrToGen)
        Dim AFile As String = ""
        For i As Integer = 0 To NrToGen - 1
            Try
                AFile = DirName & "\" & Names(i)
                Dim FS As FileStream = File.Create(AFile)
                FS.Close()
                GenFiles += 1
            Catch ex As Exception
                MsgBox("Failed to Create " & AFile & vbCrLf & ex.ToString)
                Exit Function
            End Try
        Next
    End Function
#End Region

End Module
