<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnEntidades = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.smnVendedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.smnBancos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnProducción = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnVentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnContable = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnFiscal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnFacturación = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnCrearFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnFacturaA = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnFacturaB = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnVerExplorar = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnExplorarFacturaA = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnExplorarFacturaB = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.smnSeriales = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnArchivo, Me.mnEntidades, Me.mnProducción, Me.mnOperaciones, Me.mnContable, Me.mnFacturación})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(701, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnArchivo
        '
        Me.mnArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnSalir})
        Me.mnArchivo.Name = "mnArchivo"
        Me.mnArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnArchivo.Text = "Archivo"
        '
        'smnSalir
        '
        Me.smnSalir.Name = "smnSalir"
        Me.smnSalir.Size = New System.Drawing.Size(96, 22)
        Me.smnSalir.Text = "Salir"
        '
        'mnEntidades
        '
        Me.mnEntidades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnClientes, Me.smnProveedores, Me.ToolStripMenuItem1, Me.smnVendedores, Me.ToolStripMenuItem2, Me.smnBancos})
        Me.mnEntidades.Name = "mnEntidades"
        Me.mnEntidades.Size = New System.Drawing.Size(70, 20)
        Me.mnEntidades.Text = "Entidades"
        '
        'smnClientes
        '
        Me.smnClientes.Name = "smnClientes"
        Me.smnClientes.Size = New System.Drawing.Size(139, 22)
        Me.smnClientes.Text = "Clientes"
        '
        'smnProveedores
        '
        Me.smnProveedores.Name = "smnProveedores"
        Me.smnProveedores.Size = New System.Drawing.Size(139, 22)
        Me.smnProveedores.Text = "Proveedores"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 6)
        '
        'smnVendedores
        '
        Me.smnVendedores.Name = "smnVendedores"
        Me.smnVendedores.Size = New System.Drawing.Size(139, 22)
        Me.smnVendedores.Text = "Vendedores"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(136, 6)
        '
        'smnBancos
        '
        Me.smnBancos.Name = "smnBancos"
        Me.smnBancos.Size = New System.Drawing.Size(139, 22)
        Me.smnBancos.Text = "Bancos"
        '
        'mnProducción
        '
        Me.mnProducción.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnProductos})
        Me.mnProducción.Name = "mnProducción"
        Me.mnProducción.Size = New System.Drawing.Size(80, 20)
        Me.mnProducción.Text = "Producción"
        '
        'smnProductos
        '
        Me.smnProductos.Name = "smnProductos"
        Me.smnProductos.Size = New System.Drawing.Size(128, 22)
        Me.smnProductos.Text = "Productos"
        '
        'mnOperaciones
        '
        Me.mnOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnVentas})
        Me.mnOperaciones.Name = "mnOperaciones"
        Me.mnOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnOperaciones.Text = "Operaciones"
        '
        'smnVentas
        '
        Me.smnVentas.Name = "smnVentas"
        Me.smnVentas.Size = New System.Drawing.Size(109, 22)
        Me.smnVentas.Text = "Ventas"
        '
        'mnContable
        '
        Me.mnContable.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnFiscal})
        Me.mnContable.Name = "mnContable"
        Me.mnContable.Size = New System.Drawing.Size(67, 20)
        Me.mnContable.Text = "Contable"
        '
        'smnFiscal
        '
        Me.smnFiscal.Name = "smnFiscal"
        Me.smnFiscal.Size = New System.Drawing.Size(164, 22)
        Me.smnFiscal.Text = "Fiscal"
        '
        'mnFacturación
        '
        Me.mnFacturación.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnCrearFactura, Me.smnVerExplorar, Me.ToolStripMenuItem3, Me.smnSeriales})
        Me.mnFacturación.Name = "mnFacturación"
        Me.mnFacturación.Size = New System.Drawing.Size(81, 20)
        Me.mnFacturación.Text = "Facturación"
        '
        'smnCrearFactura
        '
        Me.smnCrearFactura.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnFacturaA, Me.smnFacturaB})
        Me.smnCrearFactura.Name = "smnCrearFactura"
        Me.smnCrearFactura.Size = New System.Drawing.Size(144, 22)
        Me.smnCrearFactura.Text = "Crear Factura"
        '
        'smnFacturaA
        '
        Me.smnFacturaA.Name = "smnFacturaA"
        Me.smnFacturaA.Size = New System.Drawing.Size(124, 22)
        Me.smnFacturaA.Text = "Factura A"
        '
        'smnFacturaB
        '
        Me.smnFacturaB.Name = "smnFacturaB"
        Me.smnFacturaB.Size = New System.Drawing.Size(124, 22)
        Me.smnFacturaB.Text = "Factura B"
        '
        'smnVerExplorar
        '
        Me.smnVerExplorar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnExplorarFacturaA, Me.smnExplorarFacturaB})
        Me.smnVerExplorar.Name = "smnVerExplorar"
        Me.smnVerExplorar.Size = New System.Drawing.Size(144, 22)
        Me.smnVerExplorar.Text = "Ver Explorar"
        '
        'smnExplorarFacturaA
        '
        Me.smnExplorarFacturaA.Name = "smnExplorarFacturaA"
        Me.smnExplorarFacturaA.Size = New System.Drawing.Size(124, 22)
        Me.smnExplorarFacturaA.Text = "Factura A"
        '
        'smnExplorarFacturaB
        '
        Me.smnExplorarFacturaB.Name = "smnExplorarFacturaB"
        Me.smnExplorarFacturaB.Size = New System.Drawing.Size(124, 22)
        Me.smnExplorarFacturaB.Text = "Factura B"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(141, 6)
        '
        'smnSeriales
        '
        Me.smnSeriales.Name = "smnSeriales"
        Me.smnSeriales.Size = New System.Drawing.Size(144, 22)
        Me.smnSeriales.Text = "Seriales"
        '
        'FrmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 407)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bienvenidos a ERP Gestión"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnArchivo As ToolStripMenuItem
    Friend WithEvents smnSalir As ToolStripMenuItem
    Friend WithEvents mnEntidades As ToolStripMenuItem
    Friend WithEvents smnClientes As ToolStripMenuItem
    Friend WithEvents smnProveedores As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents smnVendedores As ToolStripMenuItem
    Friend WithEvents mnProducción As ToolStripMenuItem
    Friend WithEvents smnProductos As ToolStripMenuItem
    Friend WithEvents mnContable As ToolStripMenuItem
    Friend WithEvents mnFacturación As ToolStripMenuItem
    Friend WithEvents smnCrearFactura As ToolStripMenuItem
    Friend WithEvents smnFacturaA As ToolStripMenuItem
    Friend WithEvents smnFacturaB As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents smnBancos As ToolStripMenuItem
    Friend WithEvents smnFiscal As ToolStripMenuItem
    Friend WithEvents smnVerExplorar As ToolStripMenuItem
    Friend WithEvents smnExplorarFacturaA As ToolStripMenuItem
    Friend WithEvents smnExplorarFacturaB As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents smnSeriales As ToolStripMenuItem
    Friend WithEvents mnOperaciones As ToolStripMenuItem
    Friend WithEvents smnVentas As ToolStripMenuItem
End Class
