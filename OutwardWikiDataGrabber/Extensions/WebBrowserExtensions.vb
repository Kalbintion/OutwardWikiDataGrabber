Imports System.Runtime.CompilerServices

Module WebBrowserExtensions
    <Extension()>
    Public Function GetElementsByName(ByVal document As HtmlDocument, ByVal name As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In document.All
            If hElement.GetAttribute("name") = name Then elements.Add(hElement)
        Next

        Return elements
    End Function

    <Extension()>
    Public Function GetElementsByClassName(document As HtmlDocument, className As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In document.All
            If hElement.GetAttribute("classname").Contains(className) Then
                elements.Add(hElement)
            End If
        Next

        Return elements
    End Function

    <Extension()>
    Public Function GetElementsByClassNameAndTag(document As HtmlDocument, tag As String, className As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In document.GetElementsByTagName(tag)
            If hElement.GetAttribute("classname").Contains(className) Then
                elements.Add(hElement)
            End If
        Next

        Return elements
    End Function

    <Extension()>
    Public Function GetElementsByTagAndContent(document As HtmlDocument, tag As String, mustContain As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In document.GetElementsByTagName(tag)
            If hElement.InnerHtml.Contains(mustContain) Then
                elements.Add(hElement)
            End If
        Next

        Return elements
    End Function

    <Extension()>
    Public Function GetElementsWithSubElement(document As HtmlDocument, tag As String, subTag As String) As List(Of HtmlElement)
        Dim elements As New List(Of HtmlElement)

        For Each hElement As HtmlElement In document.GetElementsByTagName(tag)
            For Each cElement As HtmlElement In hElement.Children
                If cElement.TagName.ToLower = subTag.ToLower Then
                    elements.Add(hElement)
                    Exit For
                End If
            Next
        Next

        Return elements
    End Function
End Module
