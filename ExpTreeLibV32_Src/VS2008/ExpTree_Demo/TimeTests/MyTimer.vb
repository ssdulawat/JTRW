Imports System.Collections.Generic

''' <summary>
''' A simple Class to support measuring and reporting elapsed time used in a block of code.<br />
''' It creates and maintains two timer variables, one for measuring Total Time spent in a code block,
''' and one for measuring time increments. The second timer initially has the same start time value as the
''' first, but resets to current time each time an Incremental time is requested.
''' </summary>
''' <remarks>The First timer is for measuring the Total elapsed Time spent in a code block.<br />
'''          The Second timer is for measuring elapsed time spent in a subsection of that code block.<br />
'''          Certain methods support the use of an application supplied List(Of String) as an in-memory
'''          Log.</remarks>
Public Class MyTimer
    Private m_StartTime As DateTime
    Private m_LastTime As DateTime
    Private m_TimerLog As New List(Of String)

    ''' <summary>
    ''' Creates a new instance of the Class and initializes both timers to the current time.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        m_StartTime = Now()
        m_LastTime = m_StartTime
    End Sub

    ''' <summary>
    ''' Creates a String containing the elapsed time from the creation of this instance until Now, appended to the Text parameter.
    ''' That String is appended to the TimerLog parameter.
    ''' </summary>
    ''' <param name="Text">Text to be prepended to the time report string.</param>
    ''' <param name="TimerLog">A List(Of String) to which the created String will be Added.</param>
    ''' <returns>The created String</returns>
    Public Function TotalTime(ByVal Text As String, ByVal TimerLog As List(Of String)) As String
        TotalTime = Now().Subtract(m_StartTime).TotalMilliseconds.ToString & " ms"
        TimerLog.Add(Text & TotalTime)
    End Function

    ''' <summary>
    ''' Creates a String containing the elapsed time from the creation of this instance until Now.
    ''' </summary>
    ''' <returns>The created String</returns>
    Public Function TotalTime() As String
        Return Now().Subtract(m_StartTime).TotalMilliseconds.ToString & " ms"
    End Function

    ''' <summary>
    ''' Creates a String containing the elapsed time since the last call to TimeIncr or, if no previous call, then the 
    ''' creation of this instance until Now, appended to the Text parameter.
    ''' That String is appended to the TimerLog parameter.
    ''' </summary>
    ''' <param name="Text">Text to be prepended to the time report string.</param>
    ''' <param name="TimerLog">A List(Of String) to which the created String will be Added.</param>
    ''' <returns>The created String</returns>
    Public Function TimeIncr(ByVal Text As String, ByVal TimerLog As List(Of String)) As String
        TimeIncr = Now().Subtract(m_LastTime).TotalMilliseconds.ToString & " ms"
        TimerLog.Add(Text & TimeIncr)
        m_LastTime = Now()
    End Function

    ''' <summary>
    ''' Creates a String containing the elapsed time since the last call to TimeIncr or, if no previous call, then the 
    ''' creation of this instance until Now</summary>
    ''' <returns>The created String</returns>
    Public Function TimeIncr() As String
        TimeIncr = Now().Subtract(m_LastTime).TotalMilliseconds.ToString & " ms"
        m_LastTime = Now()
    End Function

    ''' <summary>
    ''' Resets the Time Increment timer to Now()
    ''' </summary>
    ''' <remarks>Use to restart the Increment timer after some code sub-block that is not being measured</remarks>
    Public Sub SetLastTime()
        m_LastTime = Now()
    End Sub
End Class