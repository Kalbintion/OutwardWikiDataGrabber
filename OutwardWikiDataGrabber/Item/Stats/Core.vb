Imports Newtonsoft.Json

Namespace Item.Stats
    Public Class Core
        Public Property Offensive As New Item.Stats.Offensive
        Public Property Defensive As New Item.Stats.Defensive

        Public Property Type As String
        Public Property AttackSpeed As Double
        Public Property StaminaCost As Double
        Public Property Durability As Integer
        Public Property Effects As String

        ' Properties typically found with backpacks
        Public Property InventoryProtection As Integer
        Public Property Capacity As Integer

        Public Function AsJSON() As String
            Return JsonConvert.SerializeObject(Me)
        End Function
    End Class
End Namespace