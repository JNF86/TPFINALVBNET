Public Class PrintFacturaAController

    Public Sub printing(ByRef prnPreDiag As PrintPreviewDialog, ByRef prnDoc As Drawing.Printing.PrintDocument)

        prnPreDiag.Document = prnDoc
        prnPreDiag.Text = "Prevista de Impresión"
        prnPreDiag.PrintPreviewControl.Zoom = 0.8
        prnPreDiag.WindowState = FormWindowState.Maximized
        If prnPreDiag.ShowDialog() = DialogResult.OK Then
            prnDoc.Print()
        End If
    End Sub


End Class
