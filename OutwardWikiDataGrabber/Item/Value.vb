Imports Newtonsoft.Json

Namespace Item
    Public Class Value
        Public Property Sell As Double
        Public Property Buy As Double

        Public Function SellPriceWeight(ByVal Weight As Double) As Double
            Return Me.Sell / Weight
        End Function

        Public Function BuyPriceWeight(ByVal Weight As Double) As Double
            Return Me.Buy / Weight
        End Function

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace
