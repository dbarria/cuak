Imports System.Xml


Public Class Form2
    Inherits System.Windows.Forms.Form

    Dim frm1 As Form1()
    Public flagvisible As Int16
    Public estado As Int16
    Public timeCounter As Int16
    Public contp As Int16
    Dim timeCounter2 As Integer = 0

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
        estado = 0
        timeCounter = 0
        'Me.BackColor = Color.PowderBlue
        Me.ForeColor = Color.Blue
        contp = 0
        Dim conf As New controladorChat.chat
        conf.config()
        txtIP.Text = conf.ip
        txtPuerto.Text = conf.port
        LectorAutocompleteUsuarios()

    End Sub

    Private Sub AgregarUsuarioToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        contp = contp + 1
        If contp = 3 Then
            'Form1.Show()
            'Form1.Hide()


        End If
        If flagvisible = 1 And contp = 30 Then
            'Form5.Show()
            'Form1.PictureBox1.Visible = False
            'Form1.PictureBox2.Visible = False
            'Form1.Label4.Visible = False
            Form1.Visible = False

            txtUsuario.Focus()
            flagvisible = 0
        End If
        If contp = 32 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnConectar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConectar.Click, MyBase.Enter
        If txtUsuario.Text <> "" And txtClave.Text <> "" Then


            barraEstado.Text = "Iniciando Sesi�n"
            Timer2.Enabled = True
            Timer2.Start()

            Form1.conectar()
            estado = 1
            Form1.quieroCerrarSesion = 0
            Me.Visible = False
            Form1.Visible = True
            Form1.Timer2.Start()
            escribirAutocompleteUsuario(txtUsuario.Text)

        Else

            If txtUsuario.Text <> "" Then
                FaltaContrase�a.ShowDialog()
            Else

                FaltaCuentaUsuario.ShowDialog()
            End If


        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim id As Integer

        If (CerrarSistema.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Try

                Dim proceso As System.Diagnostics.Process
                id = Process.GetCurrentProcess.Id
                proceso = Process.GetProcessById(id)
                proceso.Kill()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Process.Start("c:\Windows\hh.exe", ".\Ayuda.chm::/Bienvenida.htm")
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        barraEstado.Text = barraEstado.Text + "."
        timeCounter = timeCounter + 1
        If timeCounter = 4 Then
            barraEstado.Text = "Iniciando Sesi�n"
            timeCounter = 0
        End If

        If estado = 1 Then

            Timer2.Stop()
            barraEstado.Text = ""
        End If
    End Sub

    Sub escribirAutocompleteUsuario(ByVal usuarioTxt As String)
        Dim xmlDocument As XmlDocument = New XmlDocument()

        Dim data As XmlElement




        xmlDocument.Load("autocomplete.xml")

        If buscarUsuarioAutocomplete(usuarioTxt, xmlDocument) = True Then


        Else
            data = xmlDocument.CreateElement("usuario")
            data.InnerText = usuarioTxt
            xmlDocument.DocumentElement.AppendChild(data)
            xmlDocument.Save("autocomplete.xml")


        End If


    End Sub

    Function buscarUsuarioAutocomplete(ByVal userTXT as String, ByVal documento As XmlDocument) As Boolean
        For Each nodo As XmlNode In documento.DocumentElement.ChildNodes

            If nodo.InnerText = userTXT Then
                Return True
            End If

        Next
        Return False

    End Function

    Sub LectorAutocompleteUsuarios()
        'Dim xml As Xml.XmlText
        Dim reader As XmlTextReader
        Dim usuarioLeido As String


        'Creamos el XML Reader
        reader = New XmlTextReader("autocomplete.xml")

        'Desabilitamos las lineas en blanco,
        'ya no las necesitamos
        reader.WhitespaceHandling = WhitespaceHandling.None

        Do While (reader.Read())
           



            'Mostrar nombre y valor del atributo.
            If reader.Name = "usuario" Then
                usuarioLeido = reader.ReadString()
                txtUsuario.AutoCompleteCustomSource.Add(usuarioLeido)
            End If


        Loop

        reader.Close()

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        If Form1.quieroCerrarSesion = 1 Then

            If estado = 1 Then
                barraEstado.Text = barraEstado.Text + "."
                timeCounter2 = timeCounter2 + 1
                If timeCounter2 = 4 Then
                    barraEstado.Text = "Cerrando Sesi�n"
                    timeCounter2 = 0
                End If
            End If


        End If
    End Sub
End Class