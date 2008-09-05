Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim frm1 As Form1()
    Public flagvisible As Int16
    Public contp As Int16

    Private Sub Form2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Dim id As Integer
        Try

            Dim proceso As System.Diagnostics.Process
            id = Process.GetCurrentProcess.Id
            proceso = Process.GetProcessById(id)
            proceso.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagvisible = 1
        'Me.BackColor = Color.PowderBlue
        Me.ForeColor = Color.Blue
        contp = 0
        Dim conf As New controladorChat.chat
        conf.config()
        txtIP.Text = conf.ip
        txtPuerto.Text = conf.port
        GroupBox1.Visible = False
    End Sub

    Private Sub AgregarUsuarioToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarUsuarioToolStripMenuItem1.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        contp = contp + 1
        If contp = 3 Then
            Form1.Show()

        End If
        If flagvisible = 1 And contp = 30 Then
            'Form5.Show()
            Form1.PictureBox1.Visible = False
            Form1.PictureBox2.Visible = False
            Form1.Label4.Visible = False
            Form1.Visible = False
            GroupBox1.Visible = True
            txtUsuario.Focus()
            flagvisible = 0
        End If
        If contp = 32 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnConectar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConectar.Click
        If txtUsuario.Text <> "" Then
            Form1.Visible = True
            Me.Visible = False
            Form1.conectar()
        Else
            MsgBox("Ingresa el nombre de usuario")
        End If
    End Sub
End Class