Imports DBM
Public Class FacturaBController
    Public Shared Event SuccessProcess()
    Public Shared Event ErrorProcess()

    Private Shared classes As New FacturaB

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
            Return DBQueries.queryNonExecute("FacturaA_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function

    Public Shared Sub insert(values As FacturaB)
        Try
            Dim dic As New Dictionary(Of String, String)
            dic.Clear()
            dic.Add("@operation", "INSERT")
            dic.Add("@facturabserie", values.FacturaBSerie)
            dic.Add("@fecha", (values.Fecha).ToString)
            dic.Add("@vendedor", values.Vendedor)
            dic.Add("@razon", values.Razon)
            dic.Add("@direccion", values.Direccion)
            dic.Add("@tipofactura", values.TipoFactura)
            dic.Add("@tipoiva", values.TipoIVA)
            dic.Add("@tipopago", values.TipoPago)
            dic.Add("@Remito", values.Remito)
            dic.Add("@codigo1", values.Codigo1)
            dic.Add("@Descripcion1", values.Descripcion1)
            dic.Add("@cantidad1", values.Cantidad1.ToString)
            dic.Add("@unitario1", values.Unitario1.ToString)
            dic.Add("@importe1", values.Importe1.ToString)
            dic.Add("@codigo2", values.Codigo2)
            dic.Add("@Descripcion2", values.Descripcion2)
            dic.Add("@cantidad2", values.Cantidad2.ToString)
            dic.Add("@unitario2", values.Unitario2.ToString)
            dic.Add("@importe2", values.Importe2.ToString)
            dic.Add("@codigo3", values.Codigo3)
            dic.Add("@Descripcion3", values.Descripcion3)
            dic.Add("@cantidad3", values.Cantidad3.ToString)
            dic.Add("@unitario3", values.Unitario3.ToString)
            dic.Add("@importe3", values.Importe3.ToString)
            dic.Add("@codigo4", values.Codigo4)
            dic.Add("@Descripcion4", values.Descripcion4)
            dic.Add("@cantidad4", values.Cantidad4.ToString)
            dic.Add("@unitario4", values.Unitario4.ToString)
            dic.Add("@importe4", values.Importe4.ToString)
            dic.Add("@codigo5", values.Codigo5)
            dic.Add("@Descripcion5", values.Descripcion5)
            dic.Add("@cantidad5", values.Cantidad5.ToString)
            dic.Add("@unitario5", values.Unitario5.ToString)
            dic.Add("@importe5", values.Importe5.ToString)
            dic.Add("@total", values.Total.ToString)
            DBQueries.queryExecute("FacturaB_CRUD", dic, values)
            RaiseEvent SuccessProcess()

        Catch ex As Exception
            RaiseEvent ErrorProcess()
        End Try
    End Sub

    Public Shared Sub delete(values As FacturaA)
        'no se usa

    End Sub
    Public Shared Sub update(values As FacturaA)
        'no se usa
    End Sub

End Class
