Public Class PowerManagement

    Public prankTimer As Timers.Timer = New Timers.Timer()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.EventLog = New System.Diagnostics.EventLog
        If Not System.Diagnostics.EventLog.SourceExists("PowerManagement") Then
            System.Diagnostics.EventLog.CreateEventSource("PowerManagement", "Log")
        End If
        EventLog.Source = "PowerManagement"
        EventLog.Log = "Log"
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        EventLog.WriteEntry("Service is starting")
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        StartTimer(10)
        EventLog.WriteEntry("Service has started")
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        StopTimer()
        prankTimer.Dispose()
        EventLog.Dispose()
        Prank.Dispose()
    End Sub

    Public Sub StartTimer(ByVal intervalSeconds As Integer)
        prankTimer.Interval = intervalSeconds * 1000
        AddHandler prankTimer.Elapsed, AddressOf Me.OnTimer
        prankTimer.Start()
    End Sub

    Public Sub StopTimer()
        If prankTimer.Enabled Then
            prankTimer.Stop()
        End If
    End Sub

    Private Sub OnTimer(sender As Object, e As Timers.ElapsedEventArgs)
        If Prank.PerformPrank(EventLog) Then
            ' NOTHING NEEDS TO BE DONE HERE, BUT CAN BE WHETHER PRANK SUCCEEDS OR NOT
        End If
    End Sub

End Class
