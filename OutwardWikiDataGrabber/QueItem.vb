Public Class QueItem
    Private url As String
    Private act As Action

    Public Sub New(url As String, action As Action)
        Me.url = url
        Me.act = action
    End Sub

    Public Function GetURL() As String
        Return Me.url
    End Function

    Public Function GetAction() As Action
        Return Me.act
    End Function

End Class
