Imports DBM


Public Class FiscalController
    Public Shared Event SuccessProcess()
    Public Shared Event ErrorProcess()
    Private Shared classes As New Fiscal
    Public Shared Function getColumns() As ArrayList
        Try
            Dim nameClass As String = classes.GetType().Name
            Dim query As String = String.Format("SELECT COLUMN_NAME" & "FROM INFORMATION_SCHEMA.COLUMNS" & "WHERE TABLE_NAME = {0}" &
                    "ORDER BY ORDINAL_POSITION", nameClass)
            Dim lst As New ArrayList
            lst.Clear()
            For Each rw As DataRow In DBQueries.queryNonExecute(query).Tables(0).Rows
                lst.Add(rw(0).ToString())
            Next
            Return lst

        Catch ex As Exception
            Return Nothing

        End Try
    End Function
    Public Shared Function getList() As DataSet
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "SELECT")
            Return DBQueries.queryNonExecute("Fiscal_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Public Shared Sub insert(values As Fiscal)
        'no utilizado
    End Sub
    Public Shared Sub delete(values As Fiscal)
        'no utilizado
    End Sub

    Public Shared Sub update(values As Fiscal)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "UPDATE")
            dic.Add("@id", values.Id.ToString)
            dic.Add("@iva", values.IVA.ToString)
            dic.Add("@alicuota", values.Alicuota.ToString)
            dic.Add("@impuesto", values.Impuesto.ToString)

            DBQueries.queryExecute("Fiscal_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()

        End Try
    End Sub


End Class
