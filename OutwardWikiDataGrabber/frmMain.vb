Public Class frmMain
    Public Items As New List(Of Item.Data)
    Public Que As New List(Of QueItem)
    Public NextAction As Action

    Private Const URL_BASE = "https://outward.fandom.com/"
    Private Const URL_ALL_ITEMS = URL_BASE & "wiki/Items/Item_Values"

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        Que.Add(New QueItem(URL_ALL_ITEMS, AddressOf ParseForItemList))
        ProcessNextQue()
    End Sub

    Private Sub wbBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbBrowser.DocumentCompleted
        Console.WriteLine("Document Completed")
        NextAction()
        ProcessNextQue()
    End Sub

    Private Sub ProcessNextQue()
        Console.WriteLine("Process Next Que [" & Que.Count & "]")

        If Que.Count <= 0 Then Exit Sub

        Dim nextQue As QueItem = Que.First()
        NextAction = nextQue.GetAction()
        wbBrowser.Navigate(nextQue.GetURL())
        Que.Remove(nextQue)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wbBrowser.ScriptErrorsSuppressed = True
    End Sub

    Private Sub NextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextToolStripMenuItem.Click
        ProcessNextQue()
    End Sub

    Private Sub ParseForItemList()
        Console.WriteLine("Parse For Item List")
        Dim tables As HtmlElementCollection = wbBrowser.Document.GetElementsByTagName("tbody")
        Dim itemTable As HtmlElement = tables(0)

        tslMax.Text = itemTable.Children.Count
        progDataGrabber.Maximum = itemTable.Children.Count

        Dim i As Integer = 0

        For Each child As HtmlElement In itemTable.Children
            i += 1
            If i = 1 Then Continue For

            Dim newItem As New Item.Data With {
                .Name = child.Children(0).InnerText,
                .ObjectID = child.Children(5).InnerText,
                .WikiURL = child.Children(0).Children(0).GetAttribute("href")
            }
            newItem.Value.Sell = child.Children(2).InnerText
            newItem.Weight = child.Children(3).InnerText
            newItem.Value.Buy = child.Children(4).InnerText

            ' Skip nil object id's as theyre likely set pages
            If newItem.ObjectID = "nil" Then Continue For

            ' Add item data so far and que item for parsing info
            Que.Add(New QueItem(newItem.WikiURL, AddressOf ParseItemInfo))
            Items.Add(newItem)

            Console.Write(i & vbTab)
            Console.WriteLine(newItem.AsJSON())
        Next

    End Sub

    Private Sub ParseItemInfo()
        progDataGrabber.Value = Math.Min(progDataGrabber.Value + 1, progDataGrabber.Maximum)
        tslCurrent.Text = progDataGrabber.Value

        Dim infoTable As HtmlElement = wbBrowser.Document.GetElementsByClassName("infoboxtable").Item(0)
    End Sub
End Class
