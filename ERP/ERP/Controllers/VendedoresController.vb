Imports DBM
Public Class VendedoresController

    Public Shared Event SuccessProcess()
    Public Shared Event ErrorProcess()

    Private Shared classes As New Vendedores

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
            Return DBQueries.queryNonExecute("Vendedores_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Public Shared Sub insert(values As Vendedores)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "INSERT")
            dic.Add("@id", values.Id.ToString)
            dic.Add("@vendedor", values.Vendedor)
            dic.Add("@contacto", values.Telefono)
            dic.Add("@email", values.Email)
            DBQueries.queryExecute("Vendedores_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub

    Public Shared Sub delete(values As Vendedores)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "DELETE")
            dic.Add("@id", values.Id.ToString())
            DBQueries.queryExecute("Vendedores_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub
    Public Shared Sub update(values As Vendedores)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "UPDATE")
            dic.Add("@id", values.Id.ToString)
            dic.Add("@vendedor", values.Vendedor)
            dic.Add("@telefono", values.Telefono)
            dic.Add("@email", values.Email)

            DBQueries.queryExecute("Vendedores_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub
End Class