Public Class FrmProductos

    Private WithEvents ctrl As New ProductosController
        Private datas As New List(Of Productos)
 Private Sub getColumns()
        ToolStripComboBox1.Items.Clear()
        For Each rw As String In ProductosController.getColumns()
            ToolStripComboBox1.Items.Add(rw.ToString())
        Next
        ToolStripComboBox1.SelectedIndex = 0
    End Sub
    Private Sub getList()
        datas.Clear()
        For Each rw As DataRow In ProductosController.getList().Tables(0).Rows
            datas.Add(New Productos With {
            .Id = Convert.ToInt32(rw("Id")),
            .CodigoBarra = rw("CodigoBarra").ToString(),
           .CodigoInterno = rw("CodigoInterno").ToString(),
           .Producto = rw("Producto").ToString(),
           .Detalle = rw("Detalle").ToString(),
           .Entrada = Convert.ToInt32(rw("Entrada").ToString()),
            .Salida = Convert.ToInt32(rw("Salida").ToString()),
            .Existencia = Convert.ToInt32(rw("Existencia").ToString()),
            .Costo = Convert.ToDecimal(rw("Costo").ToString())})
        Next
        Dim q = From c In datas
                Select c.Id, c.CodigoBarra, c.CodigoInterno, c.Producto, c.Detalle,
                c.Entrada, c.Salida, c.Existencia, c.Costo
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = q.ToList()
    End Sub
    Private Sub getFilterList()
        DataGridView1.DataSource = Nothing
        Try
            Select Case ToolStripComboBox1.SelectedIndex
                Case 0
                    DataGridView1.DataSource = datas.Where(Function(x) x.Id =
                   Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 1
                    DataGridView1.DataSource = datas.Where(Function(x) x.CodigoBarra.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 2
                    DataGridView1.DataSource = datas.Where(Function(x) x.CodigoInterno.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 3
                    DataGridView1.DataSource = datas.Where(Function(x) x.Producto.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 4
                    DataGridView1.DataSource = datas.Where(Function(x) x.Detalle.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 5
                    DataGridView1.DataSource = datas.Where(Function(x) x.Entrada = Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 6
                    DataGridView1.DataSource = datas.Where(Function(x) x.Salida = Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 7
                    DataGridView1.DataSource = datas.Where(Function(x) x.Existencia = Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 8
                    DataGridView1.DataSource = datas.Where(Function(x) x.Costo = Convert.ToDecimal(ToolStripTextBox1.Text)).ToList()
            End Select
        Catch ex As Exception
            getList()
        End Try
    End Sub
    Private Sub clcksBtns(sender As Object, e As EventArgs) _
    Handles ToolStripButton1.Click, ToolStripButton2.Click,
    ToolStripButton3.Click, ToolStripButton4.Click,
    ToolStripButton5.Click
        ' Insertar
        If sender.Equals(ToolStripButton1) Then
            Dim frm As New FrmProductosCRUD(
             "Iniciar Alta",
             New Productos With {
             .Id = 0,
             .CodigoBarra = String.Empty,
             .CodigoInterno = String.Empty,
             .Producto = String.Empty,
             .Detalle = String.Empty,
             .Entrada = 0,
             .Salida = 0,
             .Existencia = 0,
             .Costo = 0},
             False)
            frm.ShowDialog()
        End If
        ' Eliminar
        If sender.Equals(ToolStripButton2) And DataGridView1.Rows.Count > 0 Then
            Dim ip As DialogResult = MessageBox.Show("¿Desea Eliminar este Registro ahora?", "ELIMINAR REGISTRO",
           MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If ip = DialogResult.Yes Then
                Dim idx As Integer = DataGridView1.CurrentRow.Index
                Dim frm As New FrmProductosCRUD()
                frm.delete(New Productos With {
                .Id = Convert.ToInt32(DataGridView1.Item(0, idx).Value),
                .CodigoBarra = DataGridView1.Item(1, idx).Value.ToString(),
                .CodigoInterno = DataGridView1.Item(2, idx).Value.ToString(),
                .Producto = DataGridView1.Item(3, idx).Value.ToString(),
                .Detalle = DataGridView1.Item(4, idx).Value.ToString(),
                .Entrada = Convert.ToInt32(DataGridView1.Item(5, idx).Value.ToString()),
                .Salida = Convert.ToInt32(DataGridView1.Item(6, idx).Value.ToString()),
                .Existencia = Convert.ToInt32(DataGridView1.Item(7, idx).Value.ToString()),
                .Costo = Convert.ToDecimal(DataGridView1.Item(8, idx).Value.ToString())})
            End If
        End If
        ' Actualizar
        If sender.Equals(ToolStripButton3) And DataGridView1.Rows.Count > 0 Then
            Dim idx As Integer = DataGridView1.CurrentRow.Index
            Dim frm As New FrmProductosCRUD(
            "Actualizar",
            New Productos With {
 .Id = Convert.ToInt32(DataGridView1.Item(0, idx).Value),
 .CodigoBarra = DataGridView1.Item(1, idx).Value.ToString(),
 .CodigoInterno = DataGridView1.Item(2, idx).Value.ToString(),
 .Producto = DataGridView1.Item(3, idx).Value.ToString(),
 .Detalle = DataGridView1.Item(4, idx).Value.ToString(),
 .Entrada = Convert.ToInt32(DataGridView1.Item(5, idx).Value.ToString()),
 .Salida = Convert.ToInt32(DataGridView1.Item(6, idx).Value.ToString()),
 .Existencia = Convert.ToInt32(DataGridView1.Item(7, idx).Value.ToString()),
 .Costo = Convert.ToDecimal(DataGridView1.Item(8, idx).Value.ToString())},
 True)
 frm.ShowDialog()
 End If
 ' Imprimir
 If sender.Equals(ToolStripButton4) Then
 End If
 ' Configurar Impresora
 If sender.Equals(ToolStripButton5) Then
 End If
 End Sub
 Private Sub txtChgd(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
 If ToolStripTextBox1.Text.Trim.Length <> 0 Then
 getFilterList()
 Else
 getList()
 End If
 End Sub
 Private Sub loading(sender As Object, e As EventArgs) Handles Me.Load
 Text = "Productos"
 ToolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
 DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
 ToolStripButton1.Image = My.Resources.addCrudGray
 ToolStripButton1.ToolTipText = "Ingresar"
 ToolStripButton2.Image = My.Resources.deleteCrudGray
        ToolStripButton2.ToolTipText = "Borrar"
        ToolStripButton3.Image = My.Resources.updateCrudGray
 ToolStripButton3.Text = "Modificar"
 ToolStripButton4.Image = My.Resources.printCrudGray
 ToolStripButton4.ToolTipText = "Imprimir"
 ToolStripButton5.Image = My.Resources.cfgprintGray
 ToolStripButton5.ToolTipText = "Configurar Impresora"
 ToolStripStatusLabel1.Text = "Sistema de Gestión ERP"
 getColumns()
 getList()
 End Sub
 Private Sub ctrl_SuccessProcess() Handles ctrl.SuccessProcess
 MessageBox.Show("¡Actualización Exitosa!", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
 getList()
 End Sub
 Private Sub ctrl_ErrorProcess() Handles ctrl.ErrorProcess
 MessageBox.Show("Error Inesperado. Proceso Abortado.", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Error)
 End Sub
End Class
