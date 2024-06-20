<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.pg = New System.Windows.Forms.PropertyGrid()
        Me.SuspendLayout()
        '
        'pg
        '
        Me.pg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pg.HelpVisible = False
        Me.pg.Location = New System.Drawing.Point(0, 0)
        Me.pg.Name = "pg"
        Me.pg.Size = New System.Drawing.Size(373, 212)
        Me.pg.TabIndex = 0
        Me.pg.ToolbarVisible = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 212)
        Me.Controls.Add(Me.pg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pg As PropertyGrid
End Class
