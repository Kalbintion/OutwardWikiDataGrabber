Imports Newtonsoft.Json

Namespace Item
    Public Class Core
        Public Property Name As String
        Public Property Type As String
        Public Property Weight As Double
        Public Property ObjectID As String
        Public Property Value As New Item.Value
        Public Property Stats As New Item.Stats.Core
        Public Property Food As New Item.Food
        Public Property DLC As String
        Public Property WikiURL As String
        Public Property Image As String
        Public Property ItemSet As String

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function

        Public Function GetImageFileName() As String
            Return ObjectID & "_" & Name.Replace(" ", "") & "_v_icn.png"
        End Function
    End Class
End Namespace
