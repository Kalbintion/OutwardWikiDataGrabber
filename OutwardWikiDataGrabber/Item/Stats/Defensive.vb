Imports Newtonsoft.Json

Namespace Item.Stats
    Public Class Defensive
        Public Property DamageResist As New Dictionary(Of String, Double)
        Public Property StatusResist As Double
        Public Property CorruptionResist As Double
        Public Property Impact As Double
        Public Property Protection As Double
        Public Property WeatherHot As Double
        Public Property WeatherCold As Double
        Public Property Barrier As Double

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function

        Public Sub ParseResist(ByVal resistData As HtmlElement)
            Console.WriteLine("ParseResist" & vbCrLf & resistData.InnerHtml)
        End Sub
    End Class

End Namespace