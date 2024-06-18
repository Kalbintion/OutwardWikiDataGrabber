Imports Newtonsoft.Json

Namespace Item
    Public Class Stats
        Public Property DamageType As New Dictionary(Of String, Double)
        Public Property Impact As Double
        Public Property AttackSpeed As Double
        Public Property StaminaCost As Double
        Public Property Durability As Integer

        Public Function GetDamage(ByVal name As String) As Double
            Return DamageType.Item(name)
        End Function

        Public Sub SetDamage(ByVal name As String, ByVal val As Double)
            DamageType.Add(name, val)
        End Sub

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace