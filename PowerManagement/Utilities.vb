Module Utilities

    ''' <summary>
    ''' This will get a random number between the lower and upper bounds
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>Taken from MSDN article: https://msdn.microsoft.com/en-us/library/f7s023d2(v=vs.90).aspx </remarks>
    Public Function RNG(ByVal lowerBound As Integer, ByVal upperBound As Integer) As Integer
        Return CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound
    End Function

End Module
