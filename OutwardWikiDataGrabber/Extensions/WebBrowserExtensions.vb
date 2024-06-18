Imports System.Runtime.CompilerServices

Module WebBrowserExtensions
    <Extension()>
    Public Function GetElementsByClassName(ByVal doc As HtmlDocument, ByVal classname As String) As List(Of HtmlElement)
        Dim nCollection As New List(Of HtmlElement)
        For Each itm As HtmlElement In doc.All
            If InStr(itm.GetAttribute("class"), classname, CompareMethod.Text) Then nCollection.Add(itm)
        Next

        Return nCollection
    End Function

    <Extension()>
    Public Function GetElementsByName(ByVal doc As HtmlDocument, ByVal name As String) As List(Of HtmlElement)
        Dim nCollection As New List(Of HtmlElement)
        For Each itm As HtmlElement In doc.All
            If itm.GetAttribute("name") = name Then nCollection.Add(itm)
        Next

        Return nCollection
    End Function
End Module
