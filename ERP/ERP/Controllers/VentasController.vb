Imports DBM
Imports System.Reflection

Public Class VentasController
    Private Shared classes As New Ventas
    Public Shared Function getColumns() As ArrayList
        Try
            Dim tp As Type = classes.GetType()
            Dim proInfo() As PropertyInfo = tp.GetProperties()
            Dim lst As New ArrayList
            lst.Clear()
            For Each p1 As PropertyInfo In proInfo
                lst.Add(p1.Name.Trim())
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
            Return DBQueries.queryNonExecute("Ventas_CRUD", dic)

        Catch ex As Exception
            Return Nothing

        End Try
    End Function
End Class
