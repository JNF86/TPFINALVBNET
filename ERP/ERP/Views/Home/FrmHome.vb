Imports System.ComponentModel

Class FrmHome
        Private Sub openForms(formus As Form, titles As String)
            Me.Cursor = Cursors.WaitCursor
            formus.Text = titles
            formus.ShowDialog()
            Me.Cursor = Cursors.Default
        End Sub
    Private Sub menuControls(sender As Object, e As EventArgs) Handles smnSalir.Click, smnClientes.Click, smnProveedores.Click, smnVendedores.Click, smnProductos.Click, smnBancos.Click,
            smnFiscal.Click, smnFacturaA.Click, smnFacturaB.Click, smnSeriales.Click, smnExplorarFacturaA.Click, smnExplorarFacturaB.Click, smnVentas.Click
        ' Salir de ERP Gestión
        If sender.Equals(smnSalir) Then
            quit()
        End If
        ' Abrir Formulario de Clientes.
        If sender.Equals(smnClientes) Then
            openForms(New FrmClientes(), "Clientes")
        End If
        ' Abrir Formulario de Proveedores.
        If sender.Equals(smnProveedores) Then
            openForms(New FrmProveedores(), "Proveedores")
        End If
        ' Abrir Formulario de Vendedores.
        If sender.Equals(smnVendedores) Then
            openForms(New FrmVendedores(), "Vendedores")
        End If
        ' Abrir Formulario de Productos-Stock.
        If sender.Equals(smnProductos) Then
            openForms(New FrmProductos(), "Productos")
        End If
        ' Abrir Formulario de Bancos.
        If sender.Equals(smnBancos) Then
            openForms(New FrmBancos(), "Bancos")
        End If
        ' Abrir Formulario de Fiscal.
        If sender.Equals(smnFiscal) Then
            openForms(New FrmFiscal(), "Fiscal")
        End If
        ' Abrir Formulario de Factura A.
        If sender.Equals(smnFacturaA) Then
            openForms(New FrmFacturaA(), "Factura A")
        End If
        ' Abrir Formulario de Factura B.
        If sender.Equals(smnFacturaB) Then
            openForms(New FrmFacturaB(), "Factura B")
        End If
        ' Abrir Formulario de Seriales de las Facturas.
        If sender.Equals(smnSeriales) Then
            openForms(New FrmFacturaSeriales(), "Seriales de las Facturas")
        End If
        ' Abrir Formulario para Explorar las Facturas A.
        If sender.Equals(smnExplorarFacturaA) Then
            openForms(New FrmFacturaAExplorar(), "Explorar Facturas A")
        End If
        ' Abrir Formulario para Explorar las Facturas B.
        If sender.Equals(smnExplorarFacturaB) Then
            openForms(New FrmFacturaBExplorar(), "Explorar Facturas B")
        End If
        ' Abrir Formulario de las Ventas realizadas por los Vendedores.
        If sender.Equals(smnVentas) Then
            openForms(New FrmVentas(), "Ventas")
        End If
    End Sub
    Private Sub quit()
            End
        End Sub
        Private Sub FrmHome_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            quit()
        End Sub
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
