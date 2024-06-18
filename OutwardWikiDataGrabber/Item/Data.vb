Namespace Item
    Public Class Data
        Public Property Name As String
        Public Property Type As String
        Public Property Weight As Double
        Public Property ObjectID As String
        Public Property Value As New Item.Value
        Public Property Stats As New Item.Stats
        Public Property WikiURL As String

        Public Sub Test()
            Me.Stats.SetDamage(E_DAMAGE_TYPES.Decay, 1)
        End Sub

        Public Function AsJSON() As String
            Return "{""wiki"": """ & WikiURL & """, ""name"":""" & Name & """, ""type"":""" & Type & """, ""weight"": """ & Weight & """, ""objectid"": """ & ObjectID & """, ""value"": " & Value.AsJSON() & ", ""stats"": " & Stats.AsJSON & "}"
        End Function
    End Class
End Namespace
