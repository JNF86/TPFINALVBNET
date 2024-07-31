Public Class DBQueries
    Inherits DBQ.DBQueriesFactory

    Private Shared Sub getConection()
        Dim PATH_DIR As String = "base"
        Dim FILE_DB As String = "erp.mdf"
        Dim dbRoot As String = String.Format("{0}\{1}\{2}", My.Application.Info.DirectoryPath, PATH_DIR, FILE_DB)

        'Dim dbset As String = String.Format("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & "{0};Integrated Security=True;Connect Timeout=30", dbRoot)
        Dim dbset As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nahui\source\repos\ERP\ERP\bin\Debug\Base\erp.mdf;Integrated Security=True;Connect Timeout=30"
        DBQ.DBQueriesFactory.setConnection(dbset)

    End Sub
    Public Overloads Shared Function queryNonExecute(querySP As String, dicKeyValues As Dictionary(Of String, String)) As DataSet
        Return DBQ.DBQueriesFactory.queryNonExecute(querySP, dicKeyValues)
    End Function

    Public Overloads Shared Function queryExecute(querySP As String, dicKeyValues As Dictionary(Of String, String), clazz As Object) As Integer
        Return DBQ.DBQueriesFactory.queryExecute(querySP, dicKeyValues, clazz)

    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub
End Class

