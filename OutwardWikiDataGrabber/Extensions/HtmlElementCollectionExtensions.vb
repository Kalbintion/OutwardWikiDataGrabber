Imports System.Runtime.CompilerServices

Module HtmlElementCollectionExtensions
    <Extension()>
    Public Function GetElementsByName(ByVal collection As List(Of HtmlElement), ByVal name As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In collection
            If hElement.GetAttribute("name") = name Then elements.Add(hElement)
        Next

        Return elements
    End Function

    <Extension()>
    Public Function GetElementsByClassName(ByVal collection As List(Of HtmlElement), className As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In collection
            If hElement.GetAttribute("classname").Contains(className) Then
                elements.Add(hElement)
            End If
        Next

        Return elements
    End Function
End Module
