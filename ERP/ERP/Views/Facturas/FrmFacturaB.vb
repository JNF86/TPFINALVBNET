Imports System.Drawing.Printing

Public Class FrmFacturaB
    Private Class Listin
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Cantidad As Integer
        Public Property Unitaro As Decimal
        Public Property Importe As Decimal
    End Class

    Private WithEvents ctrlPrint As New PrintFacturaBController()
    Private WithEvents ctrlFactura As New FacturaBController()

    Private listaFactura As New List(Of Listin)

    Private Sub getFacturaSerial()
        Dim serial As Integer = 0
        ' Obtener el último serial registrado.
        For Each rw As DataRow In FacturaSerialesController.getList().Tables(0).Rows
            serial = Convert.ToInt32(rw("SerieB"))
        Next
        ' Sumarle uno.
        serial += 1
        TxtFacturaBSerie.Text = String.Format("{0}", serial)
    End Sub

    Private Sub getLoadVendedores()
        CmbVendedores.Items.Clear()
        CmbVendedores.Items.Add("")
        For Each rw As DataRow In VendedoresController.getList().Tables(0).Rows
            CmbVendedores.Items.Add(rw("Vendedor").ToString())
        Next
        CmbVendedores.SelectedIndex = 0
    End Sub

    Private Sub getLoadClientes()
        CmbClientes.Items.Clear()
        CmbClientes.Items.Add("")
        For Each rw As DataRow In ClientesController.getList().Tables(0).Rows
            CmbClientes.Items.Add(rw("Razon").ToString())
        Next
        CmbClientes.SelectedIndex = 0
    End Sub

    Private Sub getLoadProductos()
        CmbProductos.Items.Clear()
        CmbProductos.Items.Add("")
        For Each rw As DataRow In ProductosController.getList().Tables(0).Rows
            CmbProductos.Items.Add(rw("Producto"))
        Next
        CmbProductos.SelectedIndex = 0
    End Sub

    Private Sub setClearClientes()
        TxtRazon.Text = String.Empty
        TxtDireccion.Text = String.Empty
        TxtCUIT.Text = String.Empty
    End Sub

    Private Sub setClearProductos()
        TxtCodigoInterno.Text = String.Empty
        TxtDescripcion.Text = String.Empty
        TxtCantidad.Text = String.Empty
        TxtUnidad.Text = String.Empty
        TxtExistencia.Text = String.Empty
    End Sub

    Private Sub getSearchClientes()
        If CmbClientes.Text.Trim().Length = 0 Then
            setClearClientes()
        Else
            Dim lst As New List(Of Clientes)
            lst.Clear()
            For Each rw As DataRow In ClientesController.getList().Tables(0).Rows
                lst.Add(New Clientes With {
                      .Id = Convert.ToInt32(rw("Id")),
                      .CUIT = rw("CUIT").ToString(),
                      .Razon = rw("Razon").ToString(),
                      .Contacto = rw("Contacto").ToString(),
                      .Cargo = rw("Cargo").ToString(),
                      .Direccion = rw("Direccion").ToString(),
                      .Ciudad = rw("Ciudad").ToString(),
                      .Provincia = rw("Provincia").ToString(),
                      .Pais = rw("Pais").ToString(),
                      .Telefono = rw("Telefono").ToString(),
                      .Email = rw("Email").ToString(),
                      .Internet = rw("Internet").ToString()})
            Next

            Dim q = From c In lst
                    Where c.Razon.StartsWith(CmbClientes.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    Select c.Id, c.CUIT, c.Razon, c.Contacto, c.Cargo, c.Direccion,
                       c.Ciudad, c.Provincia, c.Pais, c.Telefono, c.Email,
                       c.Internet

            For Each cl As Object In q
                TxtRazon.Text = cl.Razon.ToString()
                TxtCUIT.Text = cl.CUIT.ToString()
                TxtDireccion.Text =
                cl.Direccion.ToString() & " " _
                & cl.Ciudad.ToString() & " " _
                & cl.Provincia.ToString() & " " _
                & IIf(cl.Telefono.ToString().Trim().Length = 0, "", "Tel: " & cl.Telefono.ToString())
            Next
        End If
    End Sub

    Private Sub getSearchProductos()
        If CmbProductos.Text.Trim().Length = 0 Then
            setClearProductos()
        Else
            Dim aliIVA As Decimal = 0
            Dim impIVA As Decimal = 0
            ' Ejecutar los Cálculos.
            getIVAAlicuotaImpuesto(aliIVA, impIVA) 'Obtener valores fiscales.
            Dim lst As New List(Of Productos)
            lst.Clear()
            For Each rw As DataRow In ProductosController.getList().Tables(0).Rows
                lst.Add(New Productos With {
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

            Dim q = From c In lst
                    Where c.Producto.StartsWith(CmbProductos.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    Select c.Id, c.CodigoBarra, c.CodigoInterno, c.Producto, c.Detalle,
                           c.Entrada, c.Salida, c.Existencia, c.Costo

            For Each cl As Object In q
                TxtCodigoInterno.Text = cl.CodigoInterno.ToString()
                TxtDescripcion.Text = cl.Detalle.ToString()
                TxtExistencia.Text = cl.Existencia.ToString()
                TxtUnidad.Text = String.Format("{0:f2}", cl.costo + (cl.costo * aliIVA / 100))
            Next
        End If
    End Sub

    Private Sub getIVAAlicuotaImpuesto(ByRef setAlicuota As Decimal, ByRef setImpuesto As Decimal)
        Dim lst As New List(Of Fiscal)
        lst.Clear()
        For Each rw As DataRow In FiscalController.getList().Tables(0).Rows
            lst.Add(New Fiscal() With {
                    .Id = Convert.ToInt32(rw("Id")),
                    .IVA = rw("IVA").ToString(),
                    .Alicuota = Convert.ToDecimal(rw("Alicuota")),
                    .Impuesto = Convert.ToDecimal(rw("Impuesto"))})

            Dim q = From i In lst
                    Where i.Id = 3
                    Select i.Id, i.IVA, i.Alicuota, i.Impuesto

            For Each cl As Object In q
                setAlicuota = cl.Alicuota
                setImpuesto = cl.Impuesto
            Next
        Next
    End Sub

    Private Sub getTipoFactura()
        CmbTipoFactura.Items.Clear()
        CmbTipoFactura.Items.AddRange({"FA", "NC", "ND"})
        CmbTipoFactura.SelectedIndex = 0
    End Sub

    Private Sub getCondicionesIVA()
        CmbIVA.Items.Clear()
        CmbIVA.Items.AddRange({"", "CONSUMIDOR FINAL", "NO RESPONSABLE", "EXENTO", "MONOTRIBUTO"})
        CmbIVA.SelectedIndex = 0
    End Sub

    Private Sub getCondicionesPago()
        CmbTiposPago.Items.Clear()
        CmbTiposPago.Items.AddRange({"", "CONTADO", "CUENTA CORRIENTE"})
        CmbTiposPago.SelectedIndex = 0
    End Sub

    Private Sub getList()
        Dim q = From l In listaFactura
                Select l.Codigo, l.Descripcion, l.Cantidad, l.Unitaro, l.Importe

        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = q.ToList

        setFormatGrid() ' Autoformatear grilla.
        calcTotal()     ' Recalcular totales finales.
    End Sub

    Private Sub addItemsListin()
        If DataGridView1.RowCount < 5 Then
            Try
                Dim strCodigo As String = TxtCodigoInterno.Text.Trim()
                Dim strDescrp As String = TxtDescripcion.Text.Trim()
                Dim intCant As Integer = Convert.ToInt32(TxtCantidad.Text)
                Dim decUnid As Decimal = Convert.ToDecimal(TxtUnidad.Text)
                listaFactura.Add(New Listin With {
                                 .Codigo = strCodigo,
                                 .Descripcion = strDescrp,
                                 .Cantidad = intCant,
                                 .Unitaro = decUnid,
                                 .Importe = intCant * decUnid})
                CmbProductos.Text = String.Empty
                setFormatGrid() ' Autoformatear grilla.
                calcTotal()     ' Recalcular totales finales.
            Catch ex As Exception
                TxtCantidad.Text = String.Empty
            End Try
        Else
            MessageBox.Show(
                "Se ha llegado al límite de carga.",
                "LIMITE DE CARGA", MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub deleteItemListin()
        Dim idx As Integer = DataGridView1.CurrentRow.Index
        listaFactura.RemoveAt(idx)
        getList()
    End Sub

    Private Sub emptyItemsListin()
        listaFactura.Clear()
        getList()
    End Sub

    Private Sub calcTotal()
        If DataGridView1.RowCount > 0 Then
            Dim aliIVA As Decimal = 0
            Dim impIVA As Decimal = 0
            Dim impuesto As Decimal = 0
            Dim iva As Decimal = 0
            Dim total As Decimal = 0
            ' Ejecutar los Cálculos.
            getIVAAlicuotaImpuesto(aliIVA, impIVA) 'Obtener valores fiscales.
            For r As Integer = 0 To DataGridView1.RowCount - 1
                total += Convert.ToDecimal(DataGridView1.Item(4, r).Value)
            Next
            ' Cálculos para el pie final de la Factura B.            
            TxtTotal.Text = String.Format("{0:f2}", total)
        Else
            TxtTotal.Text = String.Empty
        End If
    End Sub

    Private Sub setFormatGrid()
        If DataGridView1.RowCount > 0 Then
            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(1).Width = 250
            DataGridView1.Columns(2).Width = 80
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(3).Width = 80
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(4).Width = 80
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub

    Private Sub setLoadingAll()
        AddHandler PrintDocument1.PrintPage, AddressOf previewPrinting
        DTFecha.Value = Date.Now
        TxtRemito.Text = String.Empty
        listaFactura.Clear()
        getTipoFactura()
        getCondicionesIVA()
        getCondicionesPago()
        getFacturaSerial()
        getLoadVendedores()
        getLoadClientes()
        getLoadProductos()
        getList()
    End Sub

    Private Sub messageErrors(title As String, message As String)
        MessageBox.Show(
            message,
            title, MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub

    Private Function validateMessages()
        ' Validaciones primarias para la factura.
        If TxtFacturaBSerie.Text.Trim().Length = 0 Then
            messageErrors("FALTA SERIE", "Se requiere cargar el Número de Serie.")
            Return -1
        End If
        If CmbVendedores.Text.Trim().Length = 0 Then
            messageErrors("FALTA VENDEDOR", "Se requiere cargar al menos un Vendedor.")
            Return -1
        End If
        If TxtRazon.Text.Trim().Length = 0 Then
            messageErrors("FALTA RAZÓN", "Se requiere el Cliente o Razón.")
            Return -1
        End If
        If DataGridView1.RowCount <= 0 Then
            messageErrors("FALTA ARTÍCULO", "Se requiere cargar al menos un Artículo.")
            Return -1
        End If
        Return 0
    End Function

    Private Sub saveInvoice()
        Dim fac As New FacturaB()
        fac.FacturaBSerie = TxtFacturaBSerie.Text.Trim()
        fac.Fecha = Convert.ToDateTime(DTFecha.Text)
        fac.Vendedor = CmbVendedores.Text.Trim()
        fac.Razon = TxtRazon.Text.Trim()
        fac.Direccion = TxtDireccion.Text.Trim()
        fac.TipoFactura = CmbTipoFactura.Text.Trim()
        fac.CUIT = TxtCUIT.Text.Trim()
        fac.TipoIVA = CmbIVA.Text.Trim()
        fac.TipoPago = CmbTipoFactura.Text.Trim()
        fac.Remito = TxtRemito.Text.Trim()
        Dim codigo(5) As String
        Dim descripcion(5) As String
        Dim cantidad(5) As Integer
        Dim unitario(5) As Decimal
        Dim importe(5) As Decimal
        For r As Integer = 0 To 4
            codigo(r) = String.Empty
            descripcion(r) = String.Empty
            cantidad(r) = 0
            unitario(r) = 0
            importe(r) = 0
        Next
        For r As Integer = 0 To DataGridView1.RowCount - 1
            codigo(r) = DataGridView1.Item(0, r).Value.trim()
            descripcion(r) = DataGridView1.Item(1, r).Value.trim()
            cantidad(r) = Convert.ToInt32(DataGridView1.Item(2, r).Value)
            unitario(r) = Convert.ToInt32(DataGridView1.Item(3, r).Value)
            importe(r) = Convert.ToInt32(DataGridView1.Item(4, r).Value)
        Next
        fac.Codigo1 = codigo(0)
        fac.Descripcion1 = descripcion(0)
        fac.Cantidad1 = cantidad(0)
        fac.Unitario1 = unitario(0)
        fac.Importe1 = importe(0)
        fac.Codigo2 = codigo(1)
        fac.Descripcion2 = descripcion(1)
        fac.Cantidad2 = cantidad(1)
        fac.Unitario2 = unitario(1)
        fac.Importe2 = importe(1)
        fac.Codigo3 = codigo(2)
        fac.Descripcion3 = descripcion(2)
        fac.Cantidad3 = cantidad(2)
        fac.Unitario3 = unitario(2)
        fac.Importe3 = importe(2)
        fac.Codigo4 = codigo(3)
        fac.Descripcion4 = descripcion(3)
        fac.Cantidad4 = cantidad(3)
        fac.Unitario4 = unitario(3)
        fac.Importe4 = importe(3)
        fac.Codigo5 = codigo(4)
        fac.Descripcion5 = descripcion(4)
        fac.Cantidad5 = cantidad(4)
        fac.Unitario5 = unitario(4)
        fac.Importe5 = importe(4)
        fac.Total = Convert.ToDecimal(TxtTotal.Text)
        FacturaBController.insert(fac)
    End Sub

    Private Sub previewPrinting(sender As Object, e As PrintPageEventArgs)
        ' Estilos fuentes principales de la factura.
        Dim printFontLetraA As System.Drawing.Font = New Font("Courier New", 26, FontStyle.Bold)
        Dim printFont As System.Drawing.Font = New Font("Courier New", 10)
        Dim printFont2 As System.Drawing.Font = New Font("Courier New", 10, FontStyle.Bold)
        'Especificar altura y anchuras. 
        Dim yPos As Double = 100
        Dim xPos As Double = 50
        ' Colocar Factura A.
        e.Graphics.DrawString(LbFactura.Text.Trim(), printFontLetraA, System.Drawing.Brushes.Black, (e.MarginBounds.Left + e.MarginBounds.Right) / 2.25, yPos - 50)
        ' Colocar Número de Serie de la Factura.
        e.Graphics.DrawString("N: " & RSet(TxtFacturaBSerie.Text.Trim(), 10), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Right - 100, yPos)
        ' Colocar la Fecha.
        e.Graphics.DrawString("Fecha: " & RSet(DTFecha.Text.Trim(), 10), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Right - 120, yPos + 20)
        ' Colocar la Razón o nombre del Clientes.
        e.Graphics.DrawString("Razón:     " & TxtRazon.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left, yPos + 80)
        ' Colocar el CUIT.
        e.Graphics.DrawString("C.U.I.T: " & TxtCUIT.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left + 350, yPos + 80)
        ' Colocar el Tipo de Factura.
        e.Graphics.DrawString("Tipo: " & CmbTipoFactura.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Right - 100, yPos + 80)
        ' Colocar la Dirección, Ciudad, Provincia, etc.
        e.Graphics.DrawString("Dirección: " & TxtDireccion.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left, yPos + 100)
        ' Colocar el Tipo de IVA.
        e.Graphics.DrawString("IVA: " & CmbIVA.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left, yPos + 140)
        ' Colocar Condición de Pago.
        e.Graphics.DrawString("Pago: " & CmbTiposPago.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left + 300, yPos + 140)
        ' Colocar el Remito.
        e.Graphics.DrawString("Remito Nº: " & TxtRemito.Text.Trim(), printFont, System.Drawing.Brushes.Black, e.MarginBounds.Right - 100, yPos + 140)
        ' Títulos del Listado de Código-Detalle-Cantidad-Unidad-Importe.
        Dim titlesGrid As String = String.Format("{0} {1} {2} {3} {4}",
            LSet("CODIGO", 10), LSet("DETALLES", 37), RSet("CANTIDAD", 10),
            RSet("UNIDAD", 10), RSet("IMPORTE", 10))
        e.Graphics.DrawString(titlesGrid, printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left, yPos + 220)
        ' Detalles del Listado de Código-Detalle-Cantidad-Unidad-Importe. 
        Dim stepGrid As Integer = yPos + 280
        For r As Integer = 0 To DataGridView1.RowCount - 1
            Dim listinGrid As String = String.Format("{0} {1} {2} {3} {4}",
                LSet(DataGridView1.Item(0, r).Value, 10),
                LSet(DataGridView1.Item(1, r).Value, 37),
                RSet(String.Format("{0}", DataGridView1.Item(2, r).Value), 10),
                RSet(String.Format("$ {0:f2}", DataGridView1.Item(3, r).Value), 10),
                RSet(String.Format("$ {0:f2}", DataGridView1.Item(4, r).Value), 10))
            e.Graphics.DrawString(listinGrid, printFont, System.Drawing.Brushes.Black, e.MarginBounds.Left, stepGrid)
            stepGrid += 20
        Next
        ' Detalles para Subtotales, Impuestos, IVA y Total General. 
        ' Total 
        e.Graphics.DrawString(LSet("Total", 15), printFont2, System.Drawing.Brushes.Black, e.MarginBounds.Right - 180, yPos + 580)
        e.Graphics.DrawString(RSet("$ " & TxtTotal.Text, 81), printFont2, System.Drawing.Brushes.Black, e.MarginBounds.Left, yPos + 580)
        ' Fin de Procesos para la Factura A.
    End Sub

    Private Sub FrmFacturaA_Load(sender As Object, e As EventArgs) Handles Me.Load
        setLoadingAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click, Button2.Click, Button3.Click,
        Button4.Click, Button5.Click, Button6.Click
        ' Añadir al Listin.
        If sender.Equals(Button1) Then
            addItemsListin()
            getList()
        End If
        ' Eliminar de a un Item a la vez.
        If sender.Equals(Button2) And DataGridView1.RowCount > 0 Then
            deleteItemListin()
        End If
        ' Vaciar el Listin por completo.
        If sender.Equals(Button3) And DataGridView1.RowCount > 0 Then
            emptyItemsListin()
        End If
        ' Imprimir Factura.
        If sender.Equals(Button4) Then
            If validateMessages() = 0 Then
                ctrlPrint.printing(PrintPreviewDialog1, PrintDocument1)
            End If
        End If
        ' Guardar Factura.
        If sender.Equals(Button5) Then
            If validateMessages() = 0 Then
                saveInvoice()
            End If
        End If
        ' Limpiar Factura.
        If sender.Equals(Button6) Then
            setLoadingAll()
        End If
    End Sub

    Private Sub buscar(sender As Object, e As EventArgs) _
        Handles CmbClientes.TextChanged, CmbProductos.TextChanged
        ' Clientes.
        If sender.Equals(CmbClientes) Then
            getSearchClientes()
        End If
        ' Productos.
        If sender.Equals(CmbProductos) Then
            getSearchProductos()
        End If
    End Sub

    Private Sub automanual(sender As Object, e As EventArgs) Handles ChkMembrete.Click
        ChkMembrete.Text = IIf(ChkMembrete.Checked, "Manual", "Auto")
        CmbClientes.Visible = Not ChkMembrete.Checked
        TxtRazon.Enabled = ChkMembrete.Checked
        TxtCUIT.Enabled = ChkMembrete.Checked
        TxtDireccion.Enabled = ChkMembrete.Checked
    End Sub

    Private Sub correctoGuardarFactura() Handles ctrlFactura.ErrorProcess
        MessageBox.Show(
            "Proceso Guardado Satisfactoriamente",
            "GUARDAR FACTURA A", MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub errorGuardarFactura() Handles ctrlFactura.SuccessProcess
        MessageBox.Show(
            "Se ha producido un error en el guardado. Proceso abortado.",
            "ERROR - GUARDAR FACTURA A", MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub
End Class