Public Class PowerManagement

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
        Dim prankTimer As System.Timers.Timer = New System.Timers.Timer()
        prankTimer.Interval = 60000 ' 60 seconds  
        AddHandler prankTimer.Elapsed, AddressOf Me.OnTimer
        prankTimer.Start()
        EventLog.WriteEntry("Service has started")
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

    End Sub

    Private Sub OnTimer(sender As Object, e As Timers.ElapsedEventArgs)
        Throw New NotImplementedException
    End Sub

End Class
