Namespace Logger
    Module Logger
        Public Property WriteToConsole As Boolean = False

        Public Function WriteLog(ByVal message As String) As Boolean
            Dim tstamp As String = DateTime.UtcNow.ToLongTimeString()

            If WriteToConsole Then Console.WriteLine(tstamp & vbTab & message)

            If My.Settings.AppLogging = False Then Return True

            Dim path As String = System.IO.Path.GetFullPath(My.Settings.AppLoggingPath)
            Dim fil As String = String.Format("{0:yyyy-MM-dd}.log", DateTime.UtcNow)

            If Not path.EndsWith("/") Or Not path.EndsWith("\") Then path &= "/"

            Try
                If MakeLogDirectory() Then
                    System.IO.File.AppendAllText(path & fil, tstamp & vbTab & message)
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try

            Return False
        End Function

        Public Function MakeLogDirectory() As Boolean
            Dim path As String = System.IO.Path.GetFullPath(My.Settings.AppLoggingPath)

            If Not System.IO.Directory.Exists(path) Then
                Try
                    System.IO.Directory.CreateDirectory(path)
                Catch ex As Exception
                    Return False
                End Try
            End If

            Return True
        End Function

        Public Function ClearExcessLogs() As Boolean
            Logger.MakeLogDirectory()

            Dim path As String = System.IO.Path.GetFullPath(My.Settings.AppLoggingPath)
            Dim maxFiles As Integer = My.Settings.AppLoggingMax

            Dim files As String() = System.IO.Directory.GetFiles(path, "*.log", IO.SearchOption.TopDirectoryOnly)

            If Not path.EndsWith("/") Or Not path.EndsWith("\") Then path &= "/"

            If files.Count > maxFiles Then
                ' We need to prune
                Array.Sort(files)

                For i = 0 To files.Count - maxFiles
                    Try
                        System.IO.File.Delete(files(i))
                        Logger.WriteLog("Deleted old log " & files(i))
                    Catch ex As Exception
                        Logger.WriteLog("Failed to deleted old log " & files(i))
                    End Try
                Next
            End If

            Return True
        End Function

    End Module
End Namespace