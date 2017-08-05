Module Prank
    ''' <summary>
    ''' This will determine the lowest possible value of probability
    ''' </summary>
    ''' <remarks>This can probably be moved to the config file after testing</remarks>
    Dim probabilityLowerBound As Integer = 0

    ''' <summary>
    ''' This will determine the lowest number by which a success is defined
    ''' </summary>
    ''' <remarks>This can probably be moved to the config file after testing</remarks>
    Dim probabilitySuccessThreshold As Decimal = 4

    ''' <summary>
    ''' This will determine the highest possible value of probability
    ''' </summary>
    ''' <remarks>This can probably be moved to the config file after testing</remarks>
    Dim probabilityUpperBound As Integer = 10

    ''' <summary>
    ''' This Enum will be the programmatic names of the pranks
    ''' </summary>
    Public Enum Pranks
        LockComputer
    End Enum

    ''' <summary>
    ''' This method will handle releasing any resources used in this module
    ''' </summary>
    Public Sub Dispose()

    End Sub

    ''' <summary>
    ''' This will be the entry point into this file
    ''' It will handle determining probability and then execute a prank
    ''' </summary>
    ''' <param name="PowerManagementLog">The Event Log object so logs can be kept</param>
    Public Function PerformPrank(ByVal PowerManagementLog As EventLog) As Boolean
        Dim roll As Integer = Utilities.RNG(probabilityLowerBound, probabilityUpperBound)
        PowerManagementLog.WriteEntry(String.Format("PerformPrank lowerBound: {0}, roll: {1}, upperBound: {2}", probabilityLowerBound.ToString(), roll.ToString(), probabilityUpperBound.ToString()))
        'TODO: ADD PROBABILITY CONDITIONS
        Lock(PowerManagementLog)
        Return True
    End Function

    ''' <summary>
    ''' This routine will handle locking the computer
    ''' </summary>
    ''' <param name="PowerManagementLog">The Event Log object so logs can be kept</param>
    Private Sub Lock(ByVal PowerManagementLog As EventLog)
        PowerManagementLog.WriteEntry("Lock")
        Dim info As New ProcessStartInfo("D:\WindowsAutomation\ComputerPyjamas.exe", "-lockthedoor")
        info.UseShellExecute = False
        info.RedirectStandardError = True
        info.RedirectStandardInput = True
        info.RedirectStandardOutput = True
        info.CreateNoWindow = True
        info.ErrorDialog = False
        info.WindowStyle = ProcessWindowStyle.Hidden

        Dim process As New Process
        process.Start(info)
    End Sub
End Module
