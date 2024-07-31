Imports System.Reflection
Public Class FrmProveedoresCRUD
    Private _modo As Boolean
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(operTitle As String, values As Proveedores, modo As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' Add any initialization after the InitializeComponent() call.
        _modo = modo
        Text = operTitle
        getStruct()
        ' Cargar automáticamente los valores desde la Clase de Entidad de Datos.
        Dim ty As Type = values.GetType()
        Dim r As Integer = 0
        Dim proinf As PropertyInfo() = ty.GetProperties()
        For Each vl As PropertyInfo In proinf
            DataGridView1.Item(1, r).Value = vl.GetValue(values, Nothing)
            r += 1
        Next
    End Sub
    Private Sub getStruct()
        DataGridView1.ReadOnly = False
        Dim col1 As DataGridViewColumn = New DataGridViewTextBoxColumn()
        Dim col2 As DataGridViewColumn = New DataGridViewTextBoxColumn()
        col1.DefaultCellStyle.BackColor = Color.LightGray
        col2.DefaultCellStyle.BackColor = Color.White
        col1.Width = 80
        col2.Width = 180
        DataGridView1.Columns.Add(col1)
        DataGridView1.Columns.Add(col2)
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = False
        DataGridView1.ColumnHeadersVisible = False
        Dim r As Integer = 0
        For Each rw As String In ProveedoresController.getColumns()
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, r).Value = rw.ToString()
            r += 1
        Next
        DataGridView1.Rows.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.Rows.Item(0).ReadOnly = True
    End Sub
    Private Sub insert()
        ProveedoresController.insert(
        New Proveedores With {
        .Id = Convert.ToInt32(DataGridView1.Item(1, 0).Value),
        .CUIT = DataGridView1.Item(1, 1).Value.ToString,
        .Razon = DataGridView1.Item(1, 2).Value.ToString,
        .Direccion = DataGridView1.Item(1, 5).Value.ToString,
        .Contacto = DataGridView1.Item(1, 3).Value.ToString,
        .Cargo = DataGridView1.Item(1, 4).Value.ToString,
        .Ciudad = DataGridView1.Item(1, 6).Value.ToString,
        .Provincia = DataGridView1.Item(1, 7).Value.ToString,
        .Pais = DataGridView1.Item(1, 8).Value.ToString,
        .Telefono = DataGridView1.Item(1, 9).Value.ToString,
        .Email = DataGridView1.Item(1, 10).Value.ToString,
        .Internet = DataGridView1.Item(1, 11).Value.ToString})
    End Sub
    Public Sub delete(values As Proveedores)
        ProveedoresController.delete(
        New Proveedores With {
        .Id = values.Id,
        .CUIT = String.Empty,
        .Razon = String.Empty,
        .Contacto = String.Empty,
        .Cargo = String.Empty,
        .Direccion = String.Empty,
        .Ciudad = String.Empty,
        .Provincia = String.Empty,
        .Pais = String.Empty,
        .Telefono = String.Empty,
        .Email = String.Empty,
        .Internet = String.Empty})
    End Sub
    Private Sub updates()
        ProveedoresController.update(
        New Proveedores With {
        .Id = Convert.ToInt32(DataGridView1.Item(1, 0).Value),
        .CUIT = DataGridView1.Item(1, 1).Value.ToString,
        .Razon = DataGridView1.Item(1, 2).Value.ToString,
        .Direccion = DataGridView1.Item(1, 5).Value.ToString,
        .Contacto = DataGridView1.Item(1, 3).Value.ToString,
        .Cargo = DataGridView1.Item(1, 4).Value.ToString,
        .Ciudad = DataGridView1.Item(1, 6).Value.ToString,
        .Provincia = DataGridView1.Item(1, 7).Value.ToString,
        .Pais = DataGridView1.Item(1, 8).Value.ToString,
        .Telefono = DataGridView1.Item(1, 9).Value.ToString,
        .Email = DataGridView1.Item(1, 10).Value.ToString,
        .Internet = DataGridView1.Item(1, 11).Value.ToString})
    End Sub
    Private Sub clickBtns(sender As Object, e As EventArgs) _
    Handles Button1.Click, Button2.Click
        ' Aceptar
        If sender.Equals(Button1) Then
            If _modo = False Then
                ' Guardar Ingreso de Datos.
                insert()
                Close()
            Else
                ' Guardar Edición de Datos.
                updates()
                Close()
            End If
        End If
        ' Cancelar
        If sender.Equals(Button2) Then
            Close()
        End If
    End Sub
End Class
