Public Class FrmFiscal
    Private WithEvents ctrl As New FiscalController
    Private datas As New List(Of Fiscal)
    Private Sub getColumns()
        ToolStripComboBox1.Items.Clear()
        For Each rw As String In FiscalController.getColumns()
            ToolStripComboBox1.Items.Add(rw.ToString())
        Next
        ToolStripComboBox1.SelectedIndex = 0
    End Sub
    Private Sub getList()
        datas.Clear()
        For Each rw As DataRow In FiscalController.getList().Tables(0).Rows
            datas.Add(New Fiscal With {
            .Id = Convert.ToInt32(rw("Id")),
            .IVA = rw("IVA").ToString(),
            .Alicuota = Convert.ToDecimal(rw("Alicuota")),
            .Impuesto = Convert.ToDecimal(rw("Impuesto"))})
        Next
        Dim q = From c In datas
                Select c.Id, c.IVA, c.Alicuota, c.Impuesto
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = q.ToList()
    End Sub
    Private Sub getFilterList()
        DataGridView1.DataSource = Nothing
        Try
            Select Case ToolStripComboBox1.SelectedIndex
                Case 0
                    DataGridView1.DataSource = datas.Where(Function(x) x.Id = Convert.ToInt32(ToolStripTextBox1.Text)).ToList()
                Case 1
                    DataGridView1.DataSource = datas.Where(Function(x) x.IVA.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                Case 2
                    DataGridView1.DataSource = datas.Where(Function(x) x.Alicuota = Convert.ToDecimal(ToolStripTextBox1.Text)).ToList()
                Case 3
                    DataGridView1.DataSource = datas.Where(Function(x) x.Impuesto = Convert.ToDecimal(ToolStripTextBox1.Text)).ToList()
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
            ' No Usado.
        End If
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
