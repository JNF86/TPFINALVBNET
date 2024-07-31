Imports System.Reflection
Public Class FrmFiscalCRUD
    Private _modo As Boolean
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(opertitle As String, values As Fiscal, modo As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        ' Add any initialization after the InitializeComponent() call.
        _modo = modo
        Text = opertitle
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
        For Each rw As String In FiscalController.getColumns()
            DataGridView1.Rows.Add()
            DataGridView1.Item(0, r).Value = rw.ToString()
            r += 1
        Next
        DataGridView1.Rows.Item(0).DefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.Rows.Item(0).ReadOnly = True
    End Sub
    Private Sub insert()
        ' No Usado.
    End Sub
    Public Sub delete(values As Fiscal)
        ' No Usado.
    End Sub
    Private Sub updates()
        FiscalController.update(
New Fiscal With {
.Id = Convert.ToInt32(DataGridView1.Item(1, 0).Value),
.IVA = DataGridView1.Item(1, 1).Value.ToString,
.Alicuota = Convert.ToDecimal(DataGridView1.Item(1, 2).Value),
.Impuesto = Convert.ToDecimal(DataGridView1.Item(1, 3).Value)})
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
    Private Sub validates(sender As Object, e As DataGridViewCellValidatingEventArgs) _
    Handles DataGridView1.CellValidating
        If e.ColumnIndex = 1 Then
            If e.RowIndex = 2 Then
                Dim patron As Decimal
                If Decimal.TryParse(e.FormattedValue, patron) Then
                    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
                    DataGridView1.Rows(e.RowIndex).ErrorText = String.Empty
                    Button1.Enabled = True
                    e.Cancel = False
                Else
                    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).ErrorText = "Error de Formato Numérico."
                    Button1.Enabled = False
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Private Sub keyPressDGDecimalNumero(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58 Or Asc(e.KeyChar) = 8 _
        Or Asc(e.KeyChar) = 44 Or Asc(e.KeyChar) = 46 Then
            If Asc(e.KeyChar) = 46 Then
                e.KeyChar = Chr(44)
            End If
        Else
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Dim tb As TextBox = CType(e.Control, TextBox)
        If DataGridView1.CurrentCell.ColumnIndex = 1 Then
            ' Control de Números Decimales.
            If DataGridView1.CurrentCell.RowIndex = 2 Then
                AddHandler tb.KeyPress, AddressOf keyPressDGDecimalNumero
            Else
                RemoveHandler tb.KeyPress, AddressOf keyPressDGDecimalNumero
            End If
        End If
    End Sub
End Class

