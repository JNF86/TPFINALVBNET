
Public Class FrmVendedores
        Private WithEvents ctrl As New VendedoresController
        Private datas As New List(Of Vendedores)
        Private Sub getColumns()
            ToolStripComboBox1.Items.Clear()
            For Each rw As String In VendedoresController.getColumns()
                ToolStripComboBox1.Items.Add(rw.ToString())
            Next
            ToolStripComboBox1.SelectedIndex = 0
        End Sub
        Private Sub getList()
            datas.Clear()
            For Each rw As DataRow In VendedoresController.getList().Tables(0).Rows
                datas.Add(New Vendedores With {
                .Id = Convert.ToInt32(rw("Id")),
                .Vendedor = rw("Vendedor").ToString(),
                .Telefono = rw("Telefono").ToString(),
                .Email = rw("Email").ToString()})
            Next
            Dim q = From c In datas
                    Select c.Id, c.Vendedor, c.Telefono, c.Email
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
                        DataGridView1.DataSource = datas.Where(Function(x) x.Vendedor.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                    Case 2
                        DataGridView1.DataSource = datas.Where(Function(x) x.Telefono.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                    Case 3
                        DataGridView1.DataSource = datas.Where(Function(x) x.Email.StartsWith(ToolStripTextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList()
                End Select
            Catch ex As Exception
                getList()
            End Try
        End Sub
        Private Sub clcksBtns(sender As Object, e As EventArgs) Handles ToolStripButton1.Click, ToolStripButton2.Click, ToolStripButton3.Click, ToolStripButton4.Click, ToolStripButton5.Click
            ' Insertar
            If sender.Equals(ToolStripButton1) Then
                Dim frm As New FrmVendedoresCRUD(
                "Iniciar Alta",
                New Vendedores With {
                .Id = 0,
                .Vendedor = String.Empty,
                .Telefono = String.Empty,
                .Email = String.Empty},
                False)
                frm.ShowDialog()
            End If
            ' Eliminar
            If sender.Equals(ToolStripButton2) And DataGridView1.Rows.Count > 0 Then
                Dim ip As DialogResult = MessageBox.Show("¿Desea Eliminar este Registro ahora?", "ELIMINAR REGISTRO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If ip = DialogResult.Yes Then
                    Dim idx As Integer = DataGridView1.CurrentRow.Index
                    Dim frm As New FrmVendedoresCRUD()
                    frm.delete(New Vendedores With {
                    .Id = Convert.ToInt32(DataGridView1.Item(0, idx).Value),
                    .Vendedor = DataGridView1.Item(1, idx).Value.ToString(),
                    .Telefono = DataGridView1.Item(2, idx).Value.ToString(),
                    .Email = DataGridView1.Item(3, idx).Value.ToString()})
                End If
            End If
            ' Actualizar
            If sender.Equals(ToolStripButton3) And DataGridView1.Rows.Count > 0 Then
                Dim idx As Integer = DataGridView1.CurrentRow.Index
                Dim frm As New FrmVendedoresCRUD(
                "Actualizar",
                New Vendedores With {
                .Id = Convert.ToInt32(DataGridView1.Item(0, idx).Value),
                .Vendedor = DataGridView1.Item(1, idx).Value.ToString(),
                .Telefono = DataGridView1.Item(2, idx).Value.ToString(),
                .Email = DataGridView1.Item(3, idx).Value.ToString()},
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
            Text = "Vendedores"
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
