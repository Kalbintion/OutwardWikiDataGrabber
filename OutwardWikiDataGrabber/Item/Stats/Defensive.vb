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
            If resistData.Children.Count > 0 AndAlso resistData.Children(0).TagName = "DIV" Then

                For Each child As HtmlElement In resistData.Children()
                    Dim dmgAmt As String = child.InnerText.Trim()
                    Dim dmgType As String = child.Children(0).GetAttribute("title").Trim()

                    If dmgAmt.EndsWith("%") Then
                        dmgAmt = dmgAmt.Replace("%", "")
                        dmgAmt = dmgAmt / 100
                    End If

                    If Not DamageResist.ContainsKey(dmgType) Then DamageResist.Add(dmgType, dmgAmt)
                Next
            Else
                ' Format not correct, not in child divs? Fallback to trying to parse
                Dim dmgTexts As String = resistData.InnerText
                Dim dmgText() As String = dmgTexts.Split(" ")

                Dim i As Integer = 0

                For Each child As HtmlElement In resistData.Children()
                    If child.TagName = "a" Then
                        Dim dmgAmt As String = dmgText(i)
                        Dim dmgType As String = child.GetAttribute("title")

                        If dmgAmt.EndsWith("%") Then
                            dmgAmt = dmgAmt.Replace("%", "")
                            dmgAmt = dmgAmt / 100
                        End If

                        If Not DamageResist.ContainsKey(dmgType) Then DamageResist.Add(dmgType, dmgAmt)
                    End If

                    i += 1
                Next
            End If
        End Sub
    End Class

End Namespace