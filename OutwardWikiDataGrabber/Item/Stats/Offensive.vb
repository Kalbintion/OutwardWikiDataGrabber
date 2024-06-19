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
            'Console.WriteLine("ParseDamage" & vbCrLf & damageData.InnerHtml)
            ' Each element type is wrapped in a child DIV with plain-text to be extracted by innerText
            ' and damage type to be extracted by the title attribute of the inner child (<A>)
            If damageData.Children.Count > 0 AndAlso damageData.Children(0).TagName = "div" Then

                For Each child As HtmlElement In damageData.Children()
                    Dim dmgAmt As String = child.InnerText.Trim()
                    Dim dmgType As String = child.Children(0).GetAttribute("title").Trim()

                    If dmgAmt.EndsWith("%") Then
                        dmgAmt = dmgAmt.Replace("%", "")
                        dmgAmt = dmgAmt / 100
                    End If

                    DamageType.Add(dmgType, dmgAmt)
                Next
            Else
                ' Format not correct, not in child divs? Fallback to trying to parse
                Dim dmgTexts As String = damageData.InnerText
                Dim dmgText() As String = dmgTexts.Split(" ")

                Dim i As Integer = 0

                For Each child As HtmlElement In damageData.Children()
                    If child.TagName = "a" Then
                        Dim dmgAmt As String = dmgText(i)
                        Dim dmgType As String = child.GetAttribute("title")

                        If dmgAmt.EndsWith("%") Then
                            dmgAmt = dmgAmt.Replace("%", "")
                            dmgAmt = dmgAmt / 100
                        End If

                        DamageType.Add(dmgType, dmgAmt)
                    End If

                    i += 1
                Next
            End If
        End Sub

        Public Sub ParseDamageBonus(ByVal damageData As HtmlElement)
            'Console.WriteLine("ParseDamageBonus" & vbCrLf & damageData.InnerHtml)
            If damageData.Children.Count > 0 AndAlso damageData.Children(0).TagName = "div" Then

                For Each child As HtmlElement In damageData.Children()
                    Dim dmgAmt As String = child.InnerText.Trim()
                    Dim dmgType As String = child.Children(0).GetAttribute("title").Trim()

                    If dmgAmt.EndsWith("%") Then
                        dmgAmt = dmgAmt.Replace("%", "")
                        dmgAmt = dmgAmt / 100
                    End If

                    DamageBonus.Add(dmgType, dmgAmt)
                Next
            Else
                ' Format not correct, not in child divs? Fallback to trying to parse
                Dim dmgTexts As String = damageData.InnerText
                Dim dmgText() As String = dmgTexts.Split(" ")

                Dim i As Integer = 0

                For Each child As HtmlElement In damageData.Children()
                    If child.TagName = "a" Then
                        Dim dmgAmt As String = dmgText(i)
                        Dim dmgType As String = child.GetAttribute("title")

                        If dmgAmt.EndsWith("%") Then
                            dmgAmt = dmgAmt.Replace("%", "")
                            dmgAmt = dmgAmt / 100
                        End If

                        DamageBonus.Add(dmgType, dmgAmt)
                    End If

                    i += 1
                Next
            End If
        End Sub

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace