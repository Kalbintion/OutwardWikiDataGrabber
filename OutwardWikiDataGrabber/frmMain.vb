Imports Newtonsoft.Json

Public Class frmMain
    Public Items As New List(Of Item.Core)
    Public Que As New List(Of QueItem)
    Public NextAction As Action

    Private Const URL_BASE = "https://outward.fandom.com/"
    Private Const URL_ALL_ITEMS = URL_BASE & "wiki/Items/Item_Values"

#Region "Form"
    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        Que.Add(New QueItem(URL_ALL_ITEMS, AddressOf ParseForItemList))
        ProcessNextQue()
    End Sub

    Private Sub wbBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbBrowser.DocumentCompleted
        Console.WriteLine("Document Completed")
        NextAction()
        ProcessNextQue()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wbBrowser.ScriptErrorsSuppressed = True
    End Sub

    Private Sub NextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextToolStripMenuItem.Click
        ProcessNextQue()
    End Sub
#End Region

#Region "Handlers"
    Private Sub ProcessNextQue()
        Console.WriteLine("Process Next Que [" & Que.Count & "]")

        If Que.Count <= 0 Then Exit Sub

        Dim nextQue As QueItem = Que.First()
        NextAction = nextQue.GetAction()
        wbBrowser.Navigate(nextQue.GetURL())
        Que.Remove(nextQue)
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

            Dim newItem As New Item.Core With {
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

            'Console.Write(i & vbTab)
            'Console.WriteLine(newItem.AsJSON())
        Next

        Que.Add(New QueItem("./Pages/Complete.html", AddressOf WriteJSONContent))

    End Sub

    Private Sub ParseItemInfo()
        progDataGrabber.Value = Math.Min(progDataGrabber.Value + 1, progDataGrabber.Maximum)
        tslCurrent.Text = progDataGrabber.Value

        Dim infoTable As HtmlElement = wbBrowser.Document.GetElementsByClassName("infoboxtable").Item(0)
        infoTable = infoTable.Children(0) ' get tbody

        Dim itemName As String = infoTable.Children(0).InnerText.Trim()

        Dim itemInfo As Item.Core = GetItemData(itemName)
        If IsNothing(itemInfo) Then
            Console.WriteLine("Failed to get item data for " & itemName)
            Return
        End If

        Console.WriteLine("Got item info for " & itemName)

        For i = 3 To infoTable.Children.Count - 1
            Dim rowInfo = infoTable.Children(i)
            Dim rowHeader As String, rowData As String, rowHTML As String, rowEle As HtmlElement

            If rowInfo.Children.Count = 2 Then
                rowHeader = rowInfo.Children(0).InnerText.Trim()
                rowData = rowInfo.Children(1).InnerText.Trim()
                rowHTML = rowInfo.Children(1).InnerHtml.Trim()
                rowEle = rowInfo.Children(1)
            Else
                Continue For
            End If

            Select Case rowHeader
                ' Standard Headers
                Case "Type"
                    itemInfo.Stats.Type = rowData
                Case "Item Set"
                    itemInfo.ItemSet = rowData
                Case "Durability"
                    If rowData = "∞" Then rowData = -1
                    itemInfo.Stats.Durability = rowData
                Case "DLC"
                    itemInfo.DLC = rowData
                Case "Effects"
                    itemInfo.Stats.Effects = rowData

                ' Food Headers
                Case "Hunger"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Food.Food = rowData
                Case "Drink"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Food.Drink = rowData
                Case "Perish Time"
                    If rowData = "∞" Then rowData = -1
                    itemInfo.Food.PerishTime = rowData

                ' Offensive Headers
                Case "Damage"
                    itemInfo.Stats.Offensive.ParseDamage(rowEle)
                Case "Impact"
                    itemInfo.Stats.Offensive.Impact = rowData
                Case "Attack Speed"
                    itemInfo.Stats.AttackSpeed = rowData
                Case "Stamina Cost"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.StaminaCost = rowData
                Case "Damage Bonus"
                    itemInfo.Stats.Offensive.ParseDamageBonus(rowEle)

                ' Defensive Headers
                Case "Protection"
                    itemInfo.Stats.Defensive.Protection = rowData
                Case "Damage Resist"
                    itemInfo.Stats.Defensive.ParseResist(rowEle)
                Case "Corruption Resist"
                    itemInfo.Stats.Defensive.CorruptionResist = rowData

                ' Backpack Headers
                Case "Inventory Protection"
                    itemInfo.Stats.InventoryProtection = rowData
                Case "Capacity"
                    itemInfo.Stats.Capacity = rowData

                'Ignored Headers [These headers are already obtained from the main item page listing]
                Case "Object ID"
                Case "Buy"
                Case "Sell"
                Case "Weight"
                    Continue For

                    ' Unknown Header
                Case Else
                    Console.WriteLine("Unknown Header: " & rowHeader)
                    Console.WriteLine(vbTab & "w/ Data: " & rowData)
            End Select
        Next

    End Sub

    Private Function GetItemData(ByVal name) As Item.Core
        For Each itm As Item.Core In Items
            'Console.WriteLine(name & "(" & name.Length & ")" & vbTab & itm.Name & "(" & itm.Name.Length & ")")
            If String.Equals(itm.Name, name) Then Return itm
        Next

        Return Nothing
    End Function

    Private Sub WriteJSONContent()
        Dim ItemString As String = JsonConvert.SerializeObject(Items)
        System.IO.File.WriteAllText("items.json", ItemString)
    End Sub

#End Region
End Class
