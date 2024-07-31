Imports DBM

Public Class LogonController

    Public Shared Function getList() As DataSet
        Try
            Dim dickv As New Dictionary(Of String, String)
            dickv.Clear()
            dickv.Add("@operation", "SELECT")
            dickv.Add("@id", "0")
            dickv.Add("@username", "")
            dickv.Add("@privilege", "0")

            Return DBQueries.queryNonExecute("Logon_CRUD", dickv)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function
End Class
