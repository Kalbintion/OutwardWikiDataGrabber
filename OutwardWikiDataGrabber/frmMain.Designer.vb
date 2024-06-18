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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.progDataGrabber = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslCurrent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslDivider = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslMax = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.wbBrowser = New System.Windows.Forms.WebBrowser()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus, Me.progDataGrabber, Me.tslCurrent, Me.tslDivider, Me.tslMax})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.NextToolStripMenuItem, Me.StopToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'wbBrowser
        '
        Me.wbBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbBrowser.Location = New System.Drawing.Point(0, 24)
        Me.wbBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbBrowser.Name = "wbBrowser"
        Me.wbBrowser.Size = New System.Drawing.Size(1008, 509)
        Me.wbBrowser.TabIndex = 2
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.NextToolStripMenuItem.Text = "Next"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 555)
        Me.Controls.Add(Me.wbBrowser)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Outward Wiki Data Grabber"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents progDataGrabber As ToolStripProgressBar
    Friend WithEvents tslCurrent As ToolStripStatusLabel
    Friend WithEvents tslDivider As ToolStripStatusLabel
    Friend WithEvents tslMax As ToolStripStatusLabel
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents wbBrowser As WebBrowser
    Friend WithEvents NextToolStripMenuItem As ToolStripMenuItem
End Class
