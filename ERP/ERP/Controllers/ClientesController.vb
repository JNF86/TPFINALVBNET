Imports DBM
Public Class ClientesController
    Public Shared Event SuccessProcess()
    Public Shared Event ErrorProcess()

    Private Shared classes As New Clientes

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
            Return DBQueries.queryNonExecute("Clientes_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Public Shared Sub insert(values As Clientes)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "INSERT")
            dic.Add("@cuit", values.CUIT)
            dic.Add("@razon", values.Razon)
            dic.Add("@contacto", values.Contacto)
            dic.Add("@cargo", values.Cargo)
            dic.Add("@direccion", values.Direccion)
            dic.Add("@ciudad", values.Ciudad)
            dic.Add("@provincia", values.Provincia)
            dic.Add("@pais", values.Pais)
            dic.Add("@telefono", values.Telefono)
            dic.Add("@email", values.Email)
            dic.Add("@internet", values.Internet)
            DBQueries.queryExecute("Clientes_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub

    Public Shared Sub delete(values As Clientes)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "DELETE")
            dic.Add("@id", values.Id.ToString())
            DBQueries.queryExecute("Clientes_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub
    Public Shared Sub update(values As Clientes)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "UPDATE")
            dic.Add("@cuit", values.CUIT)
            dic.Add("@razon", values.Razon)
            dic.Add("@contacto", values.Contacto)
            dic.Add("@cargo", values.Cargo)
            dic.Add("@direccion", values.Direccion)
            dic.Add("@ciudad", values.Ciudad)
            dic.Add("@provincia", values.Provincia)
            dic.Add("@pais", values.Pais)
            dic.Add("@telefono", values.Telefono)
            dic.Add("@email", values.Email)
            dic.Add("@internet", values.Internet)
            DBQueries.queryExecute("Clientes_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub
End Class
