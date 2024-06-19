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
            Dim pattern As String = "(?<Days>(?<DayCount>\d+) Days?)?,? ?(?<Hours>(?<HourCount>\d+) Hours?)?"
            Dim r As New Regex(pattern)

            Dim result As Match = r.Match(perishInfo)
            Dim daysStr As String = result.Groups.Item("DayCount").Value
            If daysStr = "" Then daysStr = "0"
            Dim hoursStr As String = result.Groups.Item("HourCount").Value
            If hoursStr = "" Then hoursStr = "0"

            Dim days As Integer = daysStr
            Dim hours As Integer = hoursStr

            Dim timeInMinutes As Integer = (days * 60) + ((hours / 24) * 60)

            Me.PerishTime = timeInMinutes
            Return timeInMinutes
        End Function

        Public Function PerishTimeToString() As String
            Dim days As Integer = Me.PerishTime / 60
            Dim hours As Integer = Me.PerishTime Mod 60

            Return days & " Days, " & hours & " Hours"
        End Function

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace