Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pg.SelectedObject = My.Settings
        pg.BrowsableAttributes = New System.ComponentModel.AttributeCollection(New System.Configuration.UserScopedSettingAttribute)
    End Sub

    Private Sub pg_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles pg.PropertyValueChanged
        frmMain.updateProperties()
    End Sub

    Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
        frmMain.updateProperties()
    End Sub
End Class