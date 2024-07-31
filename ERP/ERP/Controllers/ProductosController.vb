Imports DBM
Public Class ProductosController
    Public Shared Event SuccessProcess()
    Public Shared Event ErrorProcess()

    Private Shared classes As New Productos

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
            Return DBQueries.queryNonExecute("Productos_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Public Shared Sub insert(values As Productos)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "INSERT")
            dic.Add("@codigobarra", values.CodigoBarra)
            dic.Add("@codigointerno", values.CodigoInterno)
            dic.Add("@producto", values.Producto)
            dic.Add("@detalle", values.Detalle)
            dic.Add("@entrada", values.Entrada.ToString)
            dic.Add("@salida", values.Salida.ToString)
            dic.Add("@existencia", values.Existencia.ToString)
            dic.Add("@costo", values.Costo.ToString)
            DBQueries.queryExecute("Productos_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()

        End Try
    End Sub
    Public Shared Sub delete(values As Productos)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "DELETE")
            dic.Add("@id", values.Id.ToString)
            DBQueries.queryExecute("Productos_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()

        End Try
    End Sub
    Public Shared Sub update(values As Productos)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "UPDATE")
            dic.Add("@codigobarra", values.CodigoBarra)
            dic.Add("@codigointerno", values.CodigoInterno)
            dic.Add("@producto", values.Producto)
            dic.Add("@detalle", values.Detalle)
            dic.Add("@entrada", values.Entrada.ToString)
            dic.Add("@salida", values.Salida.ToString)
            dic.Add("@existencia", values.Existencia.ToString)
            dic.Add("@costo", values.Costo.ToString)
            DBQueries.queryExecute("Productos_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()

        End Try
    End Sub

End Class
