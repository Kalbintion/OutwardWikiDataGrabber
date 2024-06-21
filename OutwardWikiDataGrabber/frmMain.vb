Imports Newtonsoft.Json

Public Class frmMain
    Public Items As New List(Of Item.Core)
    Public Que As New List(Of QueItem)
    Public NextAction As Action

    Private Const URL_BASE = "https://outward.fandom.com/"
    Private Const URL_ALL_ITEMS = URL_BASE & "wiki/Items/Item_Values"

#Region "Toolstrip"
    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        SetProgress(0)
        ResetProgress()

        StartToolStripMenuItem.Enabled = False

        Que.Add(New QueItem(URL_ALL_ITEMS, AddressOf ParseForItemList))
        ProcessNextQue()
    End Sub

    Private Sub wbBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbBrowser.DocumentCompleted
        Console.WriteLine("Document Completed")

        NextToolStripMenuItem.Enabled = True

        If Not IsNothing(NextAction) Then NextAction()
        ProcessNextQue()
    End Sub

    Private Sub wbBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles wbBrowser.Navigating
        NextToolStripMenuItem.Enabled = False
    End Sub

    Private Sub NextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NextToolStripMenuItem.Click
        ProcessNextQue()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.ShowDialog(Me)
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        WriteJSONContent()
    End Sub
#End Region

#Region "Form"
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Reload()
        updateProperties()

        wbBrowser.ScriptErrorsSuppressed = True
        wbBrowser.AllowWebBrowserDrop = False
        wbBrowser.WebBrowserShortcutsEnabled = False
        wbBrowser.IsWebBrowserContextMenuEnabled = False

        wbBrowser.Navigate("file:///" & IO.Path.GetFullPath("./Pages/Startup.html"))
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Console.WriteLine(e.KeyData)
        Select Case e.KeyData
            Case My.Settings.HotkeyNext
                NextToolStripMenuItem.PerformClick()
            Case My.Settings.HotkeyStart
                StartToolStripMenuItem.PerformClick()
        End Select
    End Sub

    Private Sub frmMain_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        Console.WriteLine(e.KeyData)
        Select Case e.KeyData
            Case My.Settings.HotkeyNext
                NextToolStripMenuItem.PerformClick()
            Case My.Settings.HotkeyStart
                StartToolStripMenuItem.PerformClick()
        End Select
    End Sub

    Private Sub frmMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Console.WriteLine(e.KeyChar)
    End Sub

    Private Sub frmMain_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged
        My.Settings.Location = Me.Location
    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
        My.Settings.Size = Me.Size
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.EventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub
#End Region

#Region "Helpers"
    Private Sub DecrementProgress(ByVal amount As Integer)
        progDataGrabber.Maximum -= amount
        tslMax.Text = progDataGrabber.Maximum
    End Sub

    Private Sub IncrementProgress(ByVal amount As Integer)
        progDataGrabber.Value += amount
    End Sub

    Private Sub SetProgress(ByVal amount As Integer)
        tslMax.Text = amount
        progDataGrabber.Maximum = amount
    End Sub

    Private Sub ResetProgress()
        tslCurrent.Text = "0"
        progDataGrabber.Value = 0
    End Sub

    Public Sub updateProperties()
        For Each control As Object In Me.Controls
            control.BackColor = My.Settings.BackgroundColor
            control.ForeColor = My.Settings.TextColor
            control.Font = My.Settings.AppFont
        Next

        StartToolStripMenuItem.ShortcutKeys = My.Settings.HotkeyStart
        NextToolStripMenuItem.ShortcutKeys = My.Settings.HotkeyNext
    End Sub
#End Region

#Region "Handlers"
    Private Sub ProcessNextQue()
        Console.WriteLine("Process Next Que [" & Que.Count & "]")

        If Que.Count <= 0 Then
            StartToolStripMenuItem.Enabled = True
            NextToolStripMenuItem.Enabled = True
            Exit Sub
        End If

        Dim nextQue As QueItem = Que.First()
        NextAction = nextQue.GetAction()
        wbBrowser.Navigate(nextQue.GetURL())
        Que.Remove(nextQue)
    End Sub

    Private Sub ParseForItemList()
        Console.WriteLine("Parse For Item List")
        Dim tables As HtmlElementCollection = wbBrowser.Document.GetElementsByTagName("tbody")
        Dim itemTable As HtmlElement = tables(0)

        ResetProgress()
        SetProgress(itemTable.Children.Count)

        Dim i As Integer = 0

        For Each child As HtmlElement In itemTable.Children
            i += 1
            If i = 1 Then
                DecrementProgress(1)
                Continue For
            End If

            Dim newItem As New Item.Core With {
                .Name = child.Children(0).InnerText,
                .ObjectID = child.Children(5).InnerText,
                .WikiURL = child.Children(0).Children(0).GetAttribute("href")
            }
            newItem.Value.Sell = child.Children(2).InnerText
            newItem.Weight = child.Children(3).InnerText
            newItem.Value.Buy = child.Children(4).InnerText

            ' Skip nil object id's as theyre likely set pages
            If newItem.ObjectID = "nil" Then
                DecrementProgress(1)
                Continue For
            End If

            ' Add item data so far and que item for parsing info
            Que.Add(New QueItem(newItem.WikiURL, AddressOf ParseItemInfo))
            Items.Add(newItem)

            'Console.WriteLine(i & vbTab & newItem.AsJSON())
        Next
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("file:///" & IO.Path.GetFullPath("./Pages/Complete.html"))
        Console.ForegroundColor = ConsoleColor.White
        Que.Add(New QueItem("file:///" & IO.Path.GetFullPath("./Pages/Complete.html"), AddressOf WriteJSONContent))

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

        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Got item info for " & itemName)
        Console.ForegroundColor = ConsoleColor.White

        For i = 3 To infoTable.Children.Count - 1
            Dim rowInfo = infoTable.Children(i)
            Dim rowHeader As String, rowData As String, rowHTML As String, rowEle As HtmlElement

            If rowInfo.Children.Count = 2 Then
                ' Bail if child is empty [Could happen on forced stats being shown on page with no value]
                If IsNothing(rowInfo.Children(0).InnerText) Or IsNothing(rowInfo.Children(1).InnerText) Then Continue For

                ' Setup FOR vars
                rowHeader = rowInfo.Children(0).InnerText.Trim()
                rowData = rowInfo.Children(1).InnerText.Trim()
                rowHTML = rowInfo.Children(1).InnerHtml.Trim()
                rowEle = rowInfo.Children(1)
            Else
                ' Not enough children, or too many children, next!
                Continue For
            End If

            Select Case rowHeader
                ' Standard Headers
                Case "Slot"
                Case "Type"
                    itemInfo.Stats.Type = rowData
                Case "Class"
                    itemInfo.Stats.ItemClass = rowData
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
                    If rowData = "∞" Then
                        itemInfo.Food.PerishTime = -1
                    Else
                        itemInfo.Food.ParsePerishTime(rowData)
                    End If

                ' General Stat Headers
                Case "Mana Cost"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.ManaCost = rowData
                Case "Movement Speed"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.MovementSpeed = rowData
                Case "Pouch Bonus"
                    itemInfo.Stats.PouchBonus = rowData
                Case "Cooldown Reduction"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.CooldownReduction = rowData
                Case "Made By"
                    itemInfo.MadeBy = rowData
                Case "Materials"
                    itemInfo.Materials = rowData

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
                Case "Impact Resist"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.Defensive.Impact = rowData
                Case "Corruption Resist"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.Defensive.CorruptionResist = rowData
                Case "Cold Weather Def."
                    itemInfo.Stats.Defensive.WeatherCold = rowData
                Case "Hot Weather Def."
                    itemInfo.Stats.Defensive.WeatherHot = rowData
                Case "Status Resist"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.Defensive.StatusResist = rowData
                Case "Barrier"
                    itemInfo.Stats.Defensive.Barrier = rowData


                ' Backpack Headers
                Case "Inventory Protection"
                    itemInfo.Stats.InventoryProtection = rowData
                Case "Capacity"
                    itemInfo.Stats.Capacity = rowData
                Case "Preservation Amount"
                    If rowData.Contains("%") Then
                        rowData = rowData.Replace("%", "")
                        rowData = rowData / 100
                    End If
                    itemInfo.Stats.PreservationAmount = rowData

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

        ' Set other misc fields
        itemInfo.Image = itemInfo.GetImageFileName()

        ' Final check on item type
        If IsNothing(itemInfo.Type) Then
            If itemInfo.Food.Drink > 0 Or itemInfo.Food.Food > 0 Then
                itemInfo.Type = "Food"
            ElseIf Not itemInfo.Stats.Type = "" And Not itemInfo.Stats.ItemClass = "" Then
                itemInfo.Type = "Weapon"
            End If
        End If

    End Sub

    Private Function GetItemData(ByVal name) As Item.Core
        For Each itm As Item.Core In Items
            If String.Equals(itm.Name, name) Then Return itm
        Next

        Return Nothing
    End Function

    Private Sub WriteJSONContent()
        Dim ItemString As String = JsonConvert.SerializeObject(Items)
        Dim dir As String = My.Settings.OutputFilePath
        Dim fil As String = My.Settings.OutputFileName
        Dim ext As String = My.Settings.OutputFileExt

        Dim invalidPathChars As Char() = System.IO.Path.GetInvalidPathChars()
        Dim invalidFileChars As Char() = System.IO.Path.GetInvalidFileNameChars()

        Dim invalidPathCheck As New System.Text.RegularExpressions.Regex("[" & New String(invalidPathChars) & "]")
        Dim invalidFileCheck As New System.Text.RegularExpressions.Regex("[" & New String(invalidFileChars) & "]")

        If Not dir.EndsWith("/") And Not dir.EndsWith("\") Then
            dir &= "/"
        End If
        If Not ext.StartsWith(".") Then
            ext = "." & ext
        End If

        If invalidPathCheck.Matches(dir).Count > 0 Then
            MessageBox.Show("Could not save file! Invalid characters found in save path." & Environment.NewLine &
                            "Invalid characters: " & invalidPathChars.ToString() & Environment.NewLine &
                            "Provided path: " & dir & Environment.NewLine &
                            "Check supplied path, once verified use the ""Export"" option to try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            frmSettings.ShowDialog(Me)
            Exit Sub
        End If

        If invalidFileCheck.Matches(fil).Count > 0 Or invalidFileCheck.Matches(ext).Count > 0 Then
            MessageBox.Show("Could not save file! Invalid characters found in the filename or extension." & Environment.NewLine &
                            "Invalid characters: " & invalidFileChars.ToString() & Environment.NewLine &
                            "Provided name: " & fil & vbTab & "Provided ext: " & ext & Environment.NewLine &
                            "Check supplied file name and extension, once verified use the ""Export"" option to try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            frmSettings.ShowDialog(Me)
            Exit Sub
        End If

        Dim path As String = dir & fil & ext
        System.IO.File.WriteAllText(path, ItemString)
    End Sub

    Private Sub wbBrowser_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles wbBrowser.PreviewKeyDown
        frmMain_PreviewKeyDown(sender, e)
    End Sub
#End Region

End Class
