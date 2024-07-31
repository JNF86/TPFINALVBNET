Public Class FrmVentas
    Private WithEvents ctrl As New VentasController
    Private datas As New List(Of Ventas)
    Private Sub getColumns()
        ToolStripComboBox1.Items.Clear()
        For Each rw As String In VentasController.getColumns()
            ToolStripComboBox1.Items.Add(rw.ToString())
        Next
        ToolStripComboBox1.SelectedIndex = 0
    End Sub
    Private Sub getList()
        datas.Clear()
        For Each rw As DataRow In VentasController.getList().Tables(0).Rows
            datas.Add(New Ventas With {
            .Vendedor = rw("Vendedor").ToString(),
           .Factura = rw("Factura").ToString(),
           .Total = Convert.ToDecimal(rw("Total").ToString())})
        Next
        Dim q = From c In datas
                Select c.Vendedor, c.Factura, c.Total
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = q.ToList()
    End Sub
    Private Sub getFilterList()
        DataGridView1.DataSource = Nothing
        Try
            Select Case ToolStripComboBox1.SelectedIndex
                Case 0
                    DataGridView1.DataSource = datas.Where(Function(x) x.Vendedor.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 1
                    DataGridView1.DataSource = datas.Where(Function(x) x.Factura.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 2
                    DataGridView1.DataSource = datas.Where(Function(x) x.Total = Convert.ToDecimal(ToolStripTextBox1.Text.Trim())).ToList()
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
        Text = "Ventas"
        ToolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ToolStripButton1.Visible = False
        ToolStripButton2.Visible = False
        ToolStripButton3.Visible = False
        ToolStripButton4.Visible = False
        ToolStripButton5.Visible = False
        ToolStripStatusLabel1.Text = "Sistema de Gestión ERP"
        getColumns()
        getList()
    End Sub
End Class