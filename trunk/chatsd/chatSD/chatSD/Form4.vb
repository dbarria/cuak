

Public Class Form4
    Inherits System.Windows.Forms.Form
    Public flagD As Int16



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then

            Form1.registrar_usuario(TextBox1.Text, TextBox2.Text)
        Else
            MsgBox("Ingresa los datos")
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Form4_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Dim id As Integer
        Try

            Dim proceso As System.Diagnostics.Process
            id = Process.GetCurrentProcess.Id
            proceso = Process.GetProcessById(id)
            proceso.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackColor = Color.Azure
        Me.ForeColor = Color.Blue
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
        Form2.Visible = True
    End Sub
End Class