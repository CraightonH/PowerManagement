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
    ''' This will be the entry point into this file
    ''' It will handle determining probability and then execute a prank
    ''' </summary>
    ''' <param name="EventLog">The Event Log object so logs can be kept</param>
    Public Sub PerformPrank(ByVal EventLog As EventLog)
        Dim roll As Integer = Utilities.RNG(probabilityLowerBound, probabilityUpperBound)
        EventLog.WriteEntry(String.Format("PerformPrank lowerBound: {0}, roll: {1}, upperBound: {2}", probabilityLowerBound.ToString(), roll.ToString(), probabilityUpperBound.ToString()))
    End Sub

    ''' <summary>
    ''' This routine will handle locking the computer
    ''' </summary>
    ''' <param name="EventLog">The Event Log object so logs can be kept</param>
    Private Sub Lock(ByVal EventLog As EventLog)
        EventLog.WriteEntry("Lock: {0}", Pranks.LockComputer.ToString())
    End Sub
End Module
