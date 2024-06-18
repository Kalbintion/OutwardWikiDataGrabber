Imports System.Runtime.CompilerServices

Module HtmlElementCollectionExt
    <Extension()>
    Public Function GetElementsByClassName(ByVal collection As List(Of HtmlElement), ByVal classname As String) As List(Of HtmlElement)
        Dim nCollection As New List(Of HtmlElement)
        For Each itm As HtmlElement In collection
            If InStr(itm.GetAttribute("class"), classname, CompareMethod.Text) Then nCollection.Add(itm)
        Next

        Return nCollection
    End Function
End Module
