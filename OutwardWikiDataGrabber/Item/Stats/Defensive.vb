Imports Newtonsoft.Json

Namespace Item.Stats
    Public Class Defensive
        Public Property DamageResist As New Dictionary(Of String, Double)
        Public Property CorruptionResist As Double
        Public Property Impact As Double
        Public Property Protection As Double

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function

        Public Sub ParseResist(ByVal resistData As HtmlElement)

        End Sub
    End Class

End Namespace