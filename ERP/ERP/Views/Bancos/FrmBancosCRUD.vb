Imports System.Reflection

Public Class FrmBancosCRUD
    Private _modo As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(operTitle As String, values As Bancos, modo As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _modo = modo
        Text = operTitle
        getStruct()
        Dim ty As Type = values.GetType()
        Dim r As Integer = 0
        Dim proinf As PropertyInfo() = ty.GetProperties()
        For Each v1 As PropertyInfo In proinf
            DataGridView1.Item(1, r).Value = v1.GetValue(values, Nothing)
        Next
    End Sub

    Private Sub getStruct()
        DataGridView1.ReadOnly = False
        Dim col1 As DataGridViewColumn = New DataGridViewTextBoxColumn
        Dim col2 As DataGridViewColumn = New DataGridViewTextBoxColumn

        col1.DefaultCellStyle.BackColor = Color.LightGray
        col2.DefaultCellStyle.BackColor = Color.White
        col1.Width = 80
        col2.Width = 180

        DataGridView1.Columns.Add(col1)
        DataGridView1.Columns.Add(col2)

        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True

        DataGridView1.ColumnHeadersVisible = False
        Dim r As Integer = 0
        For Each rw As String In BancosController.getColumns()
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, r).Value = rw.ToString()
            r += 1
        Next
        DataGridView1.Rows.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.Rows.Item(0).ReadOnly = True
    End Sub
    Private Sub insert()
        BancosController.insert(
 New Bancos With {
 .Id = Convert.ToInt32(DataGridView1.Item(1, 0).Value),
 .Banco = DataGridView1.Item(1, 1).Value.ToString,
 .Filial = DataGridView1.Item(1, 2).Value.ToString,
 .Telefono = DataGridView1.Item(1, 3).Value.ToString,
 .Email = DataGridView1.Item(1, 4).Value.ToString})
    End Sub
    Public Sub delete(values As Bancos)
        BancosController.delete(
 New Bancos With {
 .Id = values.Id,
 .Banco = String.empty,
 .Filial = String.empty,
 .Telefono = String.empty,
 .Email = String.empty})
    End Sub
    Private Sub updates()
        BancosController.update(
 New Bancos With {
 .Id = Convert.ToInt32(DataGridView1.Item(1, 0).Value),
 .Banco = DataGridView1.Item(1, 1).Value.ToString,
 .Filial = DataGridView1.Item(1, 2).Value.ToString,
 .Telefono = DataGridView1.Item(1, 3).Value.ToString,
 .Email = DataGridView1.Item(1, 4).Value.ToString})
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
