Public Class Form3
    Public temp As String
    Public po As Integer
    Public cola As String
    Public indice As Int16
    Public datos As String
    Public cantidad As Integer
    Public flagescr As Integer
    Public cont As Integer
    Public cont2 As Integer
    Public flagRescr As Integer

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Form1.WindowState = FormWindowState.Minimized
        If txtMsje.Text <> "" Then
            'Envio lo que esta escrito en la caja de texto del mensaje
            Form1.enviar_mensaje(TextBox1.Text, txtMsje.Text)
            'Añado el msje enviado a mi ventana
            ListBox1.Items.Add("Yo: " & txtMsje.Text)
            'limpio la caja
            txtMsje.Text = ""
            ListBox1.Focus()
            SendKeys.SendWait("{DOWN}")
            'SendKeys.Send("{DOWN}")
            txtMsje.Focus()
        End If


        txtMsje.Focus()
    End Sub

    Private Sub txtMsje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMsje.KeyPress
        'al presionar enter se envia el msje
        Form1.WindowState = FormWindowState.Minimized
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then

            If txtMsje.Text <> "" Then
                'Envio lo que esta escrito en la caja de texto del mensaje
                Form1.enviar_mensaje(TextBox1.Text, txtMsje.Text)
                'Añado el msje enviado a mi ventana
                ListBox1.Items.Add("Yo: " & txtMsje.Text)
                'limpio la caja
                txtMsje.Text = ""
                ListBox1.Focus()
                SendKeys.SendWait("{DOWN}")
                'SendKeys.Send("{DOWN}")
                txtMsje.Focus()
            End If
            txtMsje.Focus()
        End If

        flagescr = 1


    End Sub

 
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        'En caso de que existan mensajes en cola para el usuario, procedo a mostrarlos
        If Form1.txtUserCola.Text = TextBox1.Text Then
            Dim i As Integer
            Dim mensaje As String

            '-----------este segmento de código arregla los mensajes en cola y los añade a la venta
            'agregando la palabra "(Antes)" al final de cada mensaje
            datos = Form1.txtCola.Text
            po = datos.IndexOf(":")
            cantidad = datos.Substring(0, po)
            indice = po + 1
            datos = datos.Substring(indice, datos.Length - indice)
            For i = 1 To cantidad
                po = datos.IndexOf(":")
                mensaje = datos.Substring(0, po)
                indice = po + 1
                datos = datos.Substring(indice, datos.Length - indice)
                po = datos.IndexOf(":")
                indice = po + 1
                datos = datos.Substring(indice, datos.Length - indice)
                po = datos.IndexOf(":")
                mensaje = mensaje & " :" & datos.Substring(0, po) & " (Antes)"
                indice = po + 1
                datos = datos.Substring(indice, datos.Length - indice)
                ListBox1.Items.Add(mensaje)
            Next
            Form1.txtUserCola.Text = ""
        End If

        'Acá se agregan mensajes enviados por usuarios. se utiliza un textBox en form1 como flag
        ' para avisar si existenuevo mensaje para una ventana especifica
        If Form1.txtFlag.Text = 1 Then
            If Form1.txtComando.Text = TextBox1.Text Then
                po = Form1.txtDatos.Text.IndexOf(":")
                po = po + 1
                temp = Form1.txtDatos.Text
                temp = temp.Substring(po, temp.Length - po)

                po = temp.IndexOf(":")
                po = po + 1
                temp = temp.Substring(po, temp.Length - po)

                If temp = " ::::estoy_escribiendo::::" Then
                    If cont = 0 Then
                        Label2.Text = "Esta escribiendo"
                        flagRescr = 1
                    End If
                Else


                    temp = TextBox1.Text & ":" & temp
                    ListBox1.Items.Add(temp)

                End If
                Form1.txtFlag.Text = 0
            End If
        End If



        If flagRescr = 1 Then
            If cont2 = 0 Then
                'Form1.enviar_mensaje(TextBox1.Text, "::::estoy_escribiendo::::")
                'TextBox2.Text = "escribiendo"
            End If
            cont2 = cont2 + 1
        End If

        If cont2 = 23 Then
            flagRescr = 0
            'TextBox2.Text = ""
            Label2.Text = ""
            cont2 = 0
        End If




        If flagescr = 1 Then
            If cont = 0 Then
                Form1.enviar_mensaje(TextBox1.Text, "::::estoy_escribiendo::::")
                'TextBox2.Text = "escribiendo"
            End If
            cont = cont + 1
        End If

        If cont = 23 Then
            flagescr = 0
            'TextBox2.Text = ""
            cont = 0
        End If

    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        
        'Form1.ventanas.Add(user.Text, "0")
        'Al cerrar ventana, se asigna 1 al usuario en la tablaH para poder abrir otra ventana.
        Form1.ventanas.Item(user.Text) = 1
        Me.Hide()
        Form1.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form3_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'al presionar la x
        'Form1.ventanas.Add(user.Text, "0")
        'Al cerrar ventana, se asigna 1 al usuario en la tablaH para poder abrir otra ventana.
        Form1.ventanas.Item(user.Text) = 1
        Form1.WindowState = FormWindowState.Normal
    End Sub


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        flagescr = 0
        cont = 0
        flagRescr = 0
        cont2 = 0
    End Sub
End Class