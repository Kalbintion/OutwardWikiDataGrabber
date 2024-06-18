Imports System.Text.RegularExpressions
Imports Newtonsoft.Json


Namespace Item
    Public Class Food
        Public Property Food As Double
        Public Property Drink As Double
        Public Property PerishTime As Integer

        Public Function CanPerish() As Boolean
            Return (PerishTime > 0)
        End Function

        Public Function ParsePerishTime(ByVal perishInfo As String) As Integer
            Dim pattern As String = "(?<Days>(?<DayCount>\d+) Days?)?,? ?(?<Hours>(?<HourCount>\d+) Hours?)"
            Dim r As New Regex(pattern)

            Dim result As Match = r.Match(perishInfo)
            Dim days As Integer = result.Groups.Item("DayCount").Value
            Dim hours As Integer = result.Groups.Item("HourCount").Value

            Dim timeInMinutes As Integer = (days * 60) + ((hours / 24) * 60)

            Me.PerishTime = timeInMinutes
            Return timeInMinutes
        End Function

        Public Function PerishTimeToString() As String

        End Function

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace