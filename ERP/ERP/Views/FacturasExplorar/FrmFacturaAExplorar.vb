Public Class FrmFacturaAExplorar
    Private datas As New List(Of FacturaA)
    Private Sub getColumns()
        ToolStripComboBox1.Items.Clear()
        For Each rw As String In FacturaAController.getColumns()
            ToolStripComboBox1.Items.Add(rw.ToString())
        Next
        ToolStripComboBox1.SelectedIndex = 0
    End Sub
    Private Sub getList()
        datas.Clear()
        For Each rw As DataRow In FacturaAController.getList().Tables(0).Rows
            datas.Add(New FacturaA With {
            .Id = Convert.ToInt32(rw("Id")),
            .FacturaASerie = rw("FacturaASerie").ToString(),
            .Fecha = Convert.ToDateTime(rw("Fecha").ToString()),
            .Vendedor = rw("Vendedor").ToString(),
            .Razon = rw("Razon").ToString(),
            .Direccion = rw("Direccion").ToString(),
            .TipoFactura = rw("TipoFactura").ToString(),
            .TipoIVA = rw("TipoIVA").ToString(),
            .CUIT = rw("CUIT").ToString(),
            .TipoPago = rw("TipoPago").ToString(),
            .Remito = rw("Remito").ToString(),
            .Codigo1 = rw("Codigo1").ToString(),
            .Descripcion1 = rw("Descripcion1").ToString(),
            .Cantidad1 = Convert.ToDecimal(rw("Cantidad1").ToString()),
            .Unitario1 = Convert.ToDecimal(rw("Unitario1").ToString()),
            .Importe1 = Convert.ToDecimal(rw("Importe1").ToString()),
            .Codigo2 = rw("Codigo2").ToString(),
            .Descripcion2 = rw("Descripcion2").ToString(),
            .Cantidad2 = Convert.ToDecimal(rw("Cantidad2").ToString()),
            .Unitario2 = Convert.ToDecimal(rw("Unitario2").ToString()),
            .Importe2 = Convert.ToDecimal(rw("Importe2").ToString()),
            .Codigo3 = rw("Codigo3").ToString(),
            .Descripcion3 = rw("Descripcion3").ToString(),
            .Cantidad3 = Convert.ToDecimal(rw("Cantidad3").ToString()),
            .Unitario3 = Convert.ToDecimal(rw("Unitario3").ToString()),
            .Importe3 = Convert.ToDecimal(rw("Importe3").ToString()),
            .Codigo4 = rw("Codigo4").ToString(),
            .Descripcion4 = rw("Descripcion4").ToString(),
            .Cantidad4 = Convert.ToDecimal(rw("Cantidad4").ToString()),
            .Unitario4 = Convert.ToDecimal(rw("Unitario4").ToString()),
            .Importe4 = Convert.ToDecimal(rw("Importe4").ToString()),
            .Codigo5 = rw("Codigo5").ToString(),
            .Descripcion5 = rw("Descripcion5").ToString(),
            .Cantidad5 = Convert.ToDecimal(rw("Cantidad5").ToString()),
            .Unitario5 = Convert.ToDecimal(rw("Unitario5").ToString()),
            .Importe5 = Convert.ToDecimal(rw("Importe5").ToString()),
            .Subtotal1 = Convert.ToDecimal(rw("Subtotal1")).ToString(),
            .Impuesto = Convert.ToDecimal(rw("Impuesto")).ToString(),
            .Subtotal2 = Convert.ToDecimal(rw("Subtotal2")).ToString(),
            .Total = Convert.ToDecimal(rw("Total").ToString())
})
        Next
        Dim q = From c In datas
                Select c.Id, c.FacturaASerie, c.Fecha, c.Vendedor, c.Razon, c.Direccion,
                c.TipoFactura, c.TipoIVA, c.CUIT, c.TipoPago, c.Remito, c.Codigo1, c.Descripcion1,
                c.Cantidad1, c.Unitario1, c.Importe1, c.Codigo2, c.Descripcion2,
                c.Cantidad2, c.Unitario2, c.Importe2, c.Codigo3, c.Descripcion3,
                c.Cantidad3, c.Unitario3, c.Importe3, c.Codigo4, c.Descripcion4,
                c.Cantidad4, c.Unitario4, c.Importe4, c.Codigo5, c.Descripcion5,
                c.Cantidad5, c.Unitario5, c.Importe5, c.Subtotal1, c.Impuesto,
                c.Subtotal2, c.Total
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = q.ToList()
    End Sub
    Private Sub getFilterList()
        DataGridView1.DataSource = Nothing
        Try
            Select Case ToolStripComboBox1.SelectedIndex
                Case 0
                    DataGridView1.DataSource =
                    datas.Where(Function(x) x.Id = Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 1
                    DataGridView1.DataSource = datas.Where(Function(x) x.FacturaASerie.StartsWith(ToolStripTextBox1.Text, StringComparison.InvariantCultureIgnoreCase)).ToList()
            End Select
        Catch ex As Exception
            getList()
        End Try
    End Sub
    Private Sub txtChgd(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        If ToolStripTextBox1.Text.Trim.Length <> 0 Then
            getFilterList()
        Else
            getList()
        End If
    End Sub
    Private Sub loading(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ToolStripStatusLabel1.Text = "Sistema de Gestión ERP"
        getColumns()
        getList()
    End Sub
End Class
