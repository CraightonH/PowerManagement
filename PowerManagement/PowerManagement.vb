Public Class PowerManagement

    Public prankTimer As Timers.Timer = New Timers.Timer()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.PowerManagementLog = New System.Diagnostics.EventLog
        Dim sourceName As String = "Power Management"
        Dim logName As String = "Power Management Log"
        If Not System.Diagnostics.EventLog.SourceExists("Power Management") Then
            System.Diagnostics.EventLog.CreateEventSource(sourceName, logName)
        End If
        Me.PowerManagementLog.Source = sourceName
        Me.PowerManagementLog.Log = logName
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        Me.PowerManagementLog.WriteEntry("Service is starting")
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        StartTimer(90)
        Me.PowerManagementLog.WriteEntry("Service has started")
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        StopTimer()
        prankTimer.Dispose()
        Prank.Dispose()
        PowerManagementLog.WriteEntry("Service has stopped")
        Me.PowerManagementLog.Dispose()
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
        If Prank.PerformPrank(Me.PowerManagementLog) Then
            ' NOTHING NEEDS TO BE DONE HERE, BUT CAN BE WHETHER PRANK SUCCEEDS OR NOT
        End If
    End Sub

End Class
