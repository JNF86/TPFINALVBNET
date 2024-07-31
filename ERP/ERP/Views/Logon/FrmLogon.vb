Public Class FrmLogon
    Private Sub logonAccesPermission()
        Dim lst As New List(Of Logon)
        lst.Clear()
        For Each rw As DataRow In LogonController.getList().Tables(0).Rows
            lst.Add(
            New Logon() With {
            .Id = Convert.ToInt32(rw("Id")),
            .UserName = Convert.ToString(rw("UserName")),
            .UserPass = Convert.ToString(rw("UserPass")),
            .Privilege = Convert.ToInt32(rw("Privilege"))
            })
        Next
        Dim q = From lg In lst
                Where lg.UserName.Equals(TextBox1.Text.Trim(), StringComparison.InvariantCultureIgnoreCase) And lg.UserPass.Equals(TextBox2.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)
                Select {lg.Id, lg.UserName, lg.UserPass, lg.Privilege}
        If q.Count() <> 0 Then
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            Me.Hide()
            Dim frm As New FrmHome
            frm.ShowDialog()
            Exit Sub
        Else
            Dim msj As String = "Acceso Denegado. No puede acceder a la Base de Datos. " & vbCr
            msj &= "No tiene permisos o sus credenciales son erróneas."
            MessageBox.Show(msj, "ACCESO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub txtChanged(sender As Object, e As EventArgs)
        Button1.Enabled =
Convert.ToBoolean(TextBox1.Text.Trim().Length) _
And Convert.ToBoolean(TextBox2.Text.Trim().Length)
    End Sub
    Private Sub buttons(sender As Object, e As EventArgs) _
Handles Button1.Click, Button2.Click
        ' Iniciar Logon.
        If sender.Equals(Button1) Then
            logonAccesPermission()
        End If
        ' Salir de Logon.
        If sender.Equals(Button2) Then
            End
        End If
    End Sub
    Private Sub loading(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Iniciar Sesión"
    End Sub
End Class