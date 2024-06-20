<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.progDataGrabber = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslCurrent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslDivider = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslMax = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.wbBrowser = New System.Windows.Forms.WebBrowser()
        Me.ssMain.SuspendLayout()
        Me.msMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssMain
        '
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus, Me.progDataGrabber, Me.tslCurrent, Me.tslDivider, Me.tslMax})
        Me.ssMain.Location = New System.Drawing.Point(0, 174)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(453, 22)
        Me.ssMain.TabIndex = 0
        Me.ssMain.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(52, 17)
        Me.tslStatus.Text = "Progress"
        '
        'progDataGrabber
        '
        Me.progDataGrabber.Maximum = 0
        Me.progDataGrabber.Name = "progDataGrabber"
        Me.progDataGrabber.Size = New System.Drawing.Size(100, 16)
        Me.progDataGrabber.ToolTipText = "Overall status of data obtaining"
        '
        'tslCurrent
        '
        Me.tslCurrent.Name = "tslCurrent"
        Me.tslCurrent.Size = New System.Drawing.Size(13, 17)
        Me.tslCurrent.Text = "0"
        '
        'tslDivider
        '
        Me.tslDivider.Name = "tslDivider"
        Me.tslDivider.Size = New System.Drawing.Size(12, 17)
        Me.tslDivider.Text = "/"
        '
        'tslMax
        '
        Me.tslMax.Name = "tslMax"
        Me.tslMax.Size = New System.Drawing.Size(13, 17)
        Me.tslMax.Text = "0"
        '
        'msMain
        '
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ActionsToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(453, 24)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        Me.ExitToolStripMenuItem.ToolTipText = "Exits the program"
        '
        'ActionsToolStripMenuItem
        '
        Me.ActionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.NextToolStripMenuItem})
        Me.ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem"
        Me.ActionsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ActionsToolStripMenuItem.Text = "&Actions"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NextToolStripMenuItem.Text = "Next"
        Me.NextToolStripMenuItem.ToolTipText = "Attempts to start the new que item, if there are any"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'wbBrowser
        '
        Me.wbBrowser.AllowWebBrowserDrop = False
        Me.wbBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbBrowser.IsWebBrowserContextMenuEnabled = False
        Me.wbBrowser.Location = New System.Drawing.Point(0, 24)
        Me.wbBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbBrowser.Name = "wbBrowser"
        Me.wbBrowser.ScriptErrorsSuppressed = True
        Me.wbBrowser.Size = New System.Drawing.Size(453, 150)
        Me.wbBrowser.TabIndex = 2
        Me.wbBrowser.WebBrowserShortcutsEnabled = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 196)
        Me.Controls.Add(Me.wbBrowser)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.msMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmMain"
        Me.Text = "Outward Wiki Data Grabber"
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ssMain As StatusStrip
    Friend WithEvents msMain As MenuStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents progDataGrabber As ToolStripProgressBar
    Friend WithEvents tslCurrent As ToolStripStatusLabel
    Friend WithEvents tslDivider As ToolStripStatusLabel
    Friend WithEvents tslMax As ToolStripStatusLabel
    Friend WithEvents wbBrowser As WebBrowser
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
End Class
