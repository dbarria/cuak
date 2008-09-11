Public Class SalaChat

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
    Public horaCambio As Date = Now





    Public Sub Wait(ByVal seconds As Single)
        Dim newDate As Date
        newDate = DateAndTime.Now.AddSeconds(seconds)
        While DateAndTime.Now.Second <> newDate.Second
            Application.DoEvents()
        End While
    End Sub
    


    'Private Sub Button2_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseClick

    '    IngresoContacto.ShowDialog()

    '    If IngresoContacto.elegido = 0 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Edmundo Leiva a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 1 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Rodrigo Morales a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 2 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Patricio Castro a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 3 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Roberto Vargas a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 4 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Daniel Barria a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 5 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Cristian Muñoz a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 6 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Francia Jimenez a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 7 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Claudio Sanhueza a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 8 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Isaias Gonzalez a la Conversacion"
    '    End If
    '    If IngresoContacto.elegido = 9 Then
    '        RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Sebastian Maldonado a la Conversacion"
    '    End If


    'End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles barraEstado.Click

    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        Dim Instance As New ToolTip()
        Instance.AutoPopDelay = 5000
        Instance.InitialDelay = 100
        Instance.ReshowDelay = 200
        ' Force the ToolTip text to be displayed whether or not the form is active.
        Instance.ShowAlways = True
        Instance.SetToolTip(Me.PictureBox6, "Haga click para salir de la aplicación")
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (CerrarSistema.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Form1.ventanas.Item(LabelContacto.Text) = 1
            Form1.WindowState = FormWindowState.Normal
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.WindowState = FormWindowState.Minimized
        If RichTextBox3.Text <> "" Then
            Dim inicio As Integer
            Dim fin As Integer

            'Envio lo que esta escrito en la caja de texto del mensaje
            Form1.enviar_mensaje(TextBox1.Text, RichTextBox3.Text & vbNewLine)
            'Añado el msje enviado a mi ventana
            inicio = RichTextBox1.TextLength
            RichTextBox1.AppendText("Yo: " & RichTextBox3.Text & vbNewLine)


            fin = RichTextBox1.TextLength
            RichTextBox1.SelectionStart = inicio
            RichTextBox1.SelectionLength = RichTextBox1.TextLength - inicio
            RichTextBox1.Select(inicio, RichTextBox1.TextLength - inicio)
            RichTextBox1.SelectionColor = Color.Red

            'ListBox1.Items.Add("Yo: " & txtMsje.Text)
            'limpio la caja
            RichTextBox3.Text = ""
            RichTextBox1.Focus()
            SendKeys.SendWait("{DOWN}")
            'SendKeys.Send("{DOWN}")
            RichTextBox3.Focus()
        End If


        RichTextBox3.Focus()
    End Sub

    Private Sub LabelContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelContacto.Click

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        If (CerrarSistema.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim inicio As Integer
        Dim fin As Integer


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
                inicio = RichTextBox1.TextLength
                RichTextBox1.AppendText(mensaje & vbNewLine)
                fin = RichTextBox1.TextLength
                RichTextBox1.SelectionStart = inicio
                RichTextBox1.SelectionLength = RichTextBox1.TextLength - inicio
                RichTextBox1.Select(inicio, RichTextBox1.TextLength - inicio)
                RichTextBox1.SelectionColor = Color.Blue
                'ListBox1.Items.Add(mensaje)
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
                        barraEstado.Text = "Esta escribiendo"
                        horaCambio = Now
                        horaCambio = horaCambio.AddSeconds(4)
                        flagRescr = 1
                    End If
                Else
                    

                    inicio = RichTextBox1.TextLength

                    temp = TextBox1.Text & ":" & temp


                    RichTextBox1.AppendText(temp)
                    fin = RichTextBox1.TextLength
                    RichTextBox1.SelectionStart = inicio
                    RichTextBox1.SelectionLength = RichTextBox1.TextLength - inicio
                    RichTextBox1.Select(inicio, RichTextBox1.TextLength - inicio)

                    RichTextBox1.SelectionColor = Color.Blue
                    'ListBox1.Items.Add(temp)
                    RichTextBox1.Focus()


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
            barraEstado.Text = ""
            horaCambio = Now
            horaCambio = horaCambio.AddSeconds(4)
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

        If Form1.ultimoConectado <> "none" Then
            Dim ahora As Date
            ahora = Now
            Dim hora As String = ahora.Hour.ToString
            Dim minuto As String = ahora.Minute.ToString


            If ahora.Hour < 10 Then
                hora = 0 & ahora.Hour.ToString
            End If

            If ahora.Minute < 10 Then
                hora = 0 & ahora.Minute.ToString
            End If

            barraEstado.Text = "[" & hora & ":" & minuto & "] " & Form1.ultimoConectado & " conectado"
            horaCambio = Now
            horaCambio = horaCambio.AddSeconds(4)
            Form1.ultimoConectado = "none"
        End If

    End Sub

    Private Sub RichTextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RichTextBox3.KeyPress
        Form1.WindowState = FormWindowState.Minimized
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then

            If RichTextBox3.Text <> "" Then
                Dim inicio As Integer
                Dim fin As Integer

                'Envio lo que esta escrito en la caja de texto del mensaje
                Form1.enviar_mensaje(TextBox1.Text, RichTextBox3.Text)
                'Añado el msje enviado a mi ventana
                inicio = RichTextBox1.TextLength

                RichTextBox1.AppendText("Yo: " & RichTextBox3.Text)

                fin = RichTextBox1.TextLength
                RichTextBox1.SelectionStart = inicio
                RichTextBox1.SelectionLength = RichTextBox1.TextLength - inicio
                RichTextBox1.Select(inicio, RichTextBox1.TextLength - inicio)
                RichTextBox1.SelectionColor = Color.Red
                'ListBox1.Items.Add("Yo: " & txtMsje.Text)
                'limpio la caja
                RichTextBox3.Text = ""
                RichTextBox1.Focus()
                SendKeys.SendWait("{DOWN}")
                'SendKeys.Send("{DOWN}")
                RichTextBox3.Focus()
            End If
            RichTextBox3.Focus()
        End If

        flagescr = 1

    End Sub

    Private Sub SalaChat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer2.Interval = 5000
        Timer2.Enabled = True
        Timer2.Start()
        Timer1.Start()



    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If horaCambio.CompareTo(Now) < 0 Then
            barraEstado.Text = ""
        End If


        'Form1.ListBox2

    End Sub

    Private Sub RichTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.GotFocus
        RichTextBox3.Focus()
    End Sub

    Private Function buscar(ByVal Lista As System.Windows.Forms.ListBox, ByVal texto As String, ByVal tipo As Integer) As Integer
        Dim s As String
        Dim i As Integer
        i = 1

        For Each s In Lista.Items
            If s = texto Then

                Return i
            End If
            i = i + 1

        Next
        Return -1

    End Function

    Protected Overrides Sub Finalize()
        

        Form1.ventanas.Item(TextBox1.Text) = 1
        LabelContacto.Text = "hola hola"
        MyBase.Finalize()
    End Sub
End Class
