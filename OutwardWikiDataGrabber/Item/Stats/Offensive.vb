Imports Newtonsoft.Json

Namespace Item.Stats
    Public Class Offensive
        Public Property DamageType As New Dictionary(Of String, Double)
        Public Property DamageBonus As New Dictionary(Of String, Double)
        Public Property Impact As Double

        Public Function GetDamage(ByVal name As String) As Double
            Return DamageType.Item(name)
        End Function

        Public Sub SetDamage(ByVal name As String, ByVal val As Double)
            DamageType.Add(name, val)
        End Sub

        Public Function GetDamageBonus(ByVal name As String) As Double
            Return DamageBonus.Item(name)
        End Function

        Public Sub SetDamageBonus(ByVal name As String, ByVal val As Double)
            DamageBonus.Add(name, val)
        End Sub

        Public Sub ParseDamage(ByVal damageData As HtmlElement)
            Console.WriteLine("ParseDamage" & vbCrLf & damageData.InnerHtml)
        End Sub

        Public Sub ParseDamageBonus(ByVal damageData As HtmlElement)
            Console.WriteLine("ParseDamageBonus" & vbCrLf & damageData.InnerHtml)
        End Sub

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace