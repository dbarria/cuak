Public Class Form1

    Inherits System.Windows.Forms.Form
    Public flagD As Int16
    Public WithEvents WinSockCliente2 As New controladorChat.Cliente
    Public datos As String
    Public ventanas As New Hashtable
    Public estadoUser As New Hashtable
    Public flagvisible As Int16
    Public contpre As Int16
    Public largodato As Integer
    Public tempRecibidos As String
    Public quieroCerrarSesion As Integer = 0



    Public Sub Wait(ByVal seconds As Single)
        Dim newDate As Date
        newDate = DateAndTime.Now.AddSeconds(seconds)
        While DateAndTime.Now.Second <> newDate.Second
            Application.DoEvents()
        End While
    End Sub


    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Dim id As Integer
        Try

            Dim proceso As System.Diagnostics.Process
            id = Process.GetCurrentProcess.Id
            proceso = Process.GetProcessById(id)
            proceso.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Sub registrar_usuario(ByVal user As String, ByVal pass As String)
        'Wait(2)
        'flagvisible = 1
        txtFlag.Text = 0
        flagD = 0
        contpre = 0
        'Me.BackColor = Color.Azure
        Me.ForeColor = Color.BlueViolet
        'Label4.ForeColor = Color.Black
        txtIP.Text = Form2.txtIP.Text
        txtPuerto.Text = Form2.txtPuerto.Text
        With WinSockCliente2
            'Determino a donde se quiere conectar el usuario
            .IPDelHost = txtIP.Text
            .PuertoDelHost = txtPuerto.Text
            'Me conecto
            .Conectar()
        End With
        WinSockCliente2.EnviarDatos("nadie" & ": /registro:" & user & ":" & pass & ":")

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Sub conectar()
        'Wait(2)
        'flagvisible = 1
        txtFlag.Text = 0
        flagD = 0
        contpre = 0
        'Me.BackColor = Color.Azure
        Me.ForeColor = Color.BlueViolet
        'Label4.ForeColor = Color.Black
        txtIP.Text = Form2.txtIP.Text
        txtPuerto.Text = Form2.txtPuerto.Text
        With WinSockCliente2
            'Determino a donde se quiere conectar el usuario
            .IPDelHost = txtIP.Text
            .PuertoDelHost = txtPuerto.Text
            'Me conecto
            .Conectar()
        End With
        txtUsuario.Text = Form2.txtUsuario.Text
        Me.Text = "MSN SD - " & txtUsuario.Text
        WinSockCliente2.EnviarDatos(txtUsuario.Text & ": /nueva_conexion")

    End Sub

    Sub desconectar()
        With WinSockCliente2
            .Desconectar()

        End With
    End Sub

    Private Sub WinSockCliente_DatosRecibidos(ByVal datosA As String) Handles WinSockCliente2.DatosRecibidos

        datos = datosA
        'cuando el string enviado es demasiado largo, este se recibe por partes.
        'EL string se va uniendo hasta que aparece el indicador de la parte final -> ::FIN::
        largodato = datos.IndexOf("::FIN::")

        If largodato > 0 Then
            'quito la cadena ::FIN:: para dejar datos limpios
            datos = tempRecibidos & datos
            largodato = datos.IndexOf("::FIN::")
            datos = datos.Substring(0, largodato)
            'dejo limpio el temporal
            tempRecibidos = ""
            'indico que se recibio nuevo mensaje
            flagD = 1
        Else
            tempRecibidos = tempRecibidos & datos
        End If

        'txtDatos.Text = datos
    End Sub

    Private Sub WinSockCliente_ConexionTerminada() Handles WinSockCliente2.ConexionTerminada

        If quieroCerrarSesion <> 1 Then
            With WinSockCliente2
                'Determino a donde se quiere conectar el usuario
                .IPDelHost = txtIP.Text
                .PuertoDelHost = txtPuerto.Text
                'Me conecto
                .Conectar()
            End With
            MsgBox("Se cerro el servidor, Reconectando")
        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim id As Integer
        Try
            Dim proceso As System.Diagnostics.Process
            id = Process.GetCurrentProcess.Id
            proceso = Process.GetProcessById(id)
            proceso.Kill()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'contpre = contpre + 1
        'If flagvisible = 1 And contpre = 10 Then
        'Me.Visible = False


        'Form2.Show()
        'flagvisible = 0
        'Timer1.Enabled = False
        'End If

        'flagD indica que se recibieron mensajes o datos
        If flagD = 1 Then
            txtFlag.Text = 1
            flagD = 0

            Dim po As Integer
            Dim comando As String
            Dim indice As Integer
            Dim cantidad As Integer
            Dim user As String
            Dim y As Integer
            'datos recibidos desde el servidor
            txtDatos.Text = datos
            po = datos.IndexOf(":")

            If po > 0 Then
                comando = datos.Substring(0, po)
                indice = po + 1
                datos = datos.Substring(indice, datos.Length - indice)
                'rescato comando para determinar la accion a seguir
                txtComando.Text = comando
            End If

            Select Case txtComando.Text

                'Si reggistrado existe, se mestra mensaje
                Case "/Conectado"
                    Me.Visible = False
                    MsgBox("el usuario ya esta conectado")
                    Form2.Visible = True

                Case "/Noexiste"
                    Me.Visible = False
                    MsgBox("el usuario no existe")
                    Form2.Visible = True

                Case "/regisSi"
                    If Form4.TextBox1.Text <> "" Then
                        MsgBox("el usuario ya existe")
                        Form4.TextBox1.Text = ""
                        Form4.TextBox1.Focus()
                    End If

                    'Si registro es existoso
                Case "/regisNo"
                    If Form4.TextBox1.Text <> "" Then
                        MsgBox("Registro con exito")
                        Form2.Visible = True
                        Form4.Visible = False
                    End If

                    ' Se conecto nuevo usuario
                Case "/con"

                    po = datos.IndexOf(":")
                    If po > 0 Then
                        indice = po + 1
                        cantidad = datos.Substring(0, po)

                        datos = datos.Substring(indice, datos.Length - indice)
                    End If

                    For y = 1 To cantidad
                        po = datos.IndexOf(":")
                        If po > 0 Then
                            indice = po + 1
                            user = datos.Substring(0, po)
                            datos = datos.Substring(indice, datos.Length - indice)

                            'agrego el usuario a la tabla hash si no esta agregado
                            If ventanas.Contains(user) = False Then
                                'No agrego al propio usuario (al yo) a la tabla y listado de conectados.
                                If user <> txtUsuario.Text Then
                                    ListBox2.Items.Add(user)





                                    ventanas.Add(user, "1")
                                End If
                            Else
                                'esto es en caso de que el usuario este agregado en la tablaH
                                'pero no este en la lista de conectados

                                If user <> txtUsuario.Text Then
                                    If ListBox2.Items.Contains(user) = False Then
                                        ListBox2.Items.Add(user)
                                    End If
                                End If
                            End If
                        End If

                    Next

                    '--------------ahora seguimos con los desconectados--------------
                    po = datos.IndexOf(":")
                    comando = datos.Substring(0, po)
                    indice = po + 1
                    datos = datos.Substring(indice, datos.Length - indice)
                    'Limpio la lista de NoConectados antes de agregar a los otros. 
                    ListBox3.Items.Clear()

                    ' Se conecto nuevo usuario
                    If comando = "/descon" Then
                        po = datos.IndexOf(":")
                        If po > 0 Then
                            indice = po + 1
                            cantidad = datos.Substring(0, po)

                            datos = datos.Substring(indice, datos.Length - indice)
                        End If

                        For y = 1 To cantidad
                            po = datos.IndexOf(":")
                            If po > 0 Then
                                indice = po + 1
                                user = datos.Substring(0, po)
                                datos = datos.Substring(indice, datos.Length - indice)

                                'agrego el usuario a la tabla hash si no esta agregado
                                If ventanas.Contains(user) = False Then
                                    'No agrego al propio (al Yo) usuario a la tabla y listado de NOconectados.
                                    If user <> txtUsuario.Text Then
                                        ListBox3.Items.Add(user)
                                        ventanas.Add(user, "1")
                                    End If
                                Else
                                    'esto es en caso de que el usuario este agregado en la tablaH
                                    'pero no este en la lista de NOconectados

                                    If user <> txtUsuario.Text Then
                                        If ListBox3.Items.Contains(user) = False Then
                                            ListBox3.Items.Add(user)
                                        End If
                                    End If
                                End If
                            End If

                        Next
                    End If


                    po = datos.IndexOf(":")
                    If po > 0 Then
                        comando = datos.Substring(0, po)

                        If comando = "/cola" Then
                            indice = po + 1
                            datos = datos.Substring(indice, datos.Length - indice)
                            po = datos.IndexOf(":")
                            indice = po + 1
                            cantidad = datos.Substring(0, po)
                            datos = datos.Substring(indice, datos.Length - indice)
                            txtDatos.Text = datos
                            txtCola.Text = cantidad & ":" & datos
                            po = datos.IndexOf(":")
                            txtUserCola.Text = txtDatos.Text.Substring(0, po)
                            abrirventana()

                        End If

                    End If




                Case "/des"

                    po = datos.IndexOf(":")
                    If po > 0 Then
                        indice = po + 1
                        user = datos.Substring(0, po)
                        ' cuando se desconecta un usuario lo saco de la tablaH y del listado de usuarios conectados
                        'ventanas.Remove(user)
                        'agrego a la lista de conectados
                        ListBox2.Items.Remove(user)
                        'agrego a la lista de NOconectados
                        ListBox3.Items.Add(user)

                    End If

                Case Else

                    abrirventana()

            End Select


        End If







    End Sub

    Sub abrirventana()
        Dim po As Integer
        'Dim z As String
        'Dim y As Integer
        po = txtDatos.Text.IndexOf(":")
        ' en caso de que no haya una ventana abierta con ese usuario, se abre una ventana
        'z = txtDatos.Text.Substring(0, po)
        ' y = ventanas.Item(txtDatos.Text.Substring(0, po))
        If ventanas.Item(txtDatos.Text.Substring(0, po)) = 1 Then
            'If ventanas.Contains((txtDatos.Text.Substring(0, po))) = True Then
            'Dim fmr3 As Form3 = New Form3()
            Dim chatIHC As SalaChat = New SalaChat()
            'fmr3.Show()
            chatIHC.Show()

            'agrego el nombre de usuario a la ventana
            chatIHC.TextBox1.Text = txtDatos.Text.Substring(0, po)
            'fmr3.TextBox1.Text = txtDatos.Text.Substring(0, po)
            chatIHC.Text = chatIHC.TextBox1.Text & " (Chat con " & chatIHC.TextBox1.Text & ")"
            'fmr3.Text = fmr3.TextBox1.Text & " (Chat con " & fmr3.TextBox1.Text & ")"
            chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text
            'fmr3.user.Text = fmr3.TextBox1.Text

            'Agrego un 0 en la tablaH para avisar que ya existe una ventana abierta
            ventanas.Item(txtDatos.Text.Substring(0, po)) = 0
            'If ListBox2.Items.Contains(txtDatos.Text.Substring(0, po)) Then
            '    fmr3.BackColor = Color.Azure
            'End If
            'If ListBox3.Items.Contains(txtDatos.Text.Substring(0, po)) Then
            '    fmr3.BackColor = Color.Beige
            '    fmr3.ForeColor = Color.Red
            'End If
            'ventanas.Remove(txtDatos.Text.Substring(0, po))
        End If

    End Sub
    Sub enviar_mensaje(ByVal UsuarioB As String, ByVal msje As String)

        'Envio lo que esta escrito en la caja de texto del mensaje
        WinSockCliente2.EnviarDatos(txtUsuario.Text & ":" & UsuarioB & ": " & msje)
        'Aado el msje enviado a mi ventana

    End Sub

    Sub enviar_mensaje_escr(ByVal UsuarioB As String, ByVal msje As String)

        'Envio lo que esta escrito en la caja de texto del mensaje
        'WinSockCliente2.EnviarDatos(txtUsuario.Text & ":/escr:" & UsuarioB & ": " & msje)
        'Aado el msje enviado a mi ventana

    End Sub


    Private Sub ListBox2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox2.MouseDoubleClick
        Try
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then
                Dim chatIHC As SalaChat = New SalaChat()
                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                chatIHC.LabelContacto.Text = "Conversando con " & Me.ListBox2.SelectedItem.ToString
                'fmr3.TextBox1.Text = Me.ListBox2.SelectedItem.ToString
                chatIHC.TextBox1.Text = Me.ListBox2.SelectedItem.ToString
                'fmr3.BackColor = Color.Azure
                'fmr3.Text = fmr3.TextBox1.Text & " (Chat con " & fmr3.TextBox1.Text & ")"
                chatIHC.Text = "Chat con " & Me.ListBox2.SelectedItem.ToString

                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
            'If ventanas.Item(Me.ListBox2.SelectedItem.ToString) = 1 Then
            '    Dim fmr3 As Form3 = New Form3()
            '    fmr3.Show()
            '    fmr3.TextBox1.Text = Me.ListBox2.SelectedItem.ToString
            '    fmr3.BackColor = Color.Azure
            '    fmr3.Text = fmr3.TextBox1.Text & " (Chat con " & fmr3.TextBox1.Text & ")"
            '    fmr3.user.Text = fmr3.TextBox1.Text

            '    'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
            '    ventanas.Item(Me.ListBox2.SelectedItem.ToString) = 0
            '    'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            'End If

        Catch ex As Exception

        End Try
    End Sub





    Private Sub ListBox3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox3.MouseDoubleClick
        Try
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then
                Dim chatIHC As SalaChat = New SalaChat()
                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                'fmr3.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.LabelContacto.Text = "Conversando con " & Me.ListBox2.SelectedItem.ToString
                'fmr3.BackColor = Color.Beige
                'fmr3.ForeColor = Color.Red
                chatIHC.Text = "Desconectado!! " & "Conversando con " & Me.ListBox2.SelectedItem.ToString
                'fmr3.Text = fmr3.TextBox1.Text & " Desconectado!!" & " (Chat con " & fmr3.TextBox1.Text & ")"
                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
            'If ventanas.Item(Me.ListBox3.SelectedItem.ToString) = 1 Then
            '    Dim fmr3 As Form3 = New Form3()
            '    fmr3.Show()
            '    fmr3.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
            '    fmr3.BackColor = Color.Beige
            '    fmr3.ForeColor = Color.Red
            '    fmr3.Text = fmr3.TextBox1.Text & " Desconectado!!" & " (Chat con " & fmr3.TextBox1.Text & ")"
            '    fmr3.user.Text = fmr3.TextBox1.Text

            '    'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
            '    ventanas.Item(Me.ListBox3.SelectedItem.ToString) = 0
            '    'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        quieroCerrarSesion = 1
        Form2.barraEstado.Text = "Cerrando Sesión"
        Form2.Timer3.Start()
        Form2.Show()
        Me.Hide()
        Me.desconectar()
        'Wait(10)
        Form2.estado = 0
        Form2.Timer3.Stop()
        Form2.barraEstado.Text = "Sesion Finalizada"


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.ListView1.SelectedItems.Item(0).ImageIndex = 0 Then
            'usuario conecatdo
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then

                Dim chatIHC As SalaChat = New SalaChat()

                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                chatIHC.TextBox1.Text = Me.ListView1.SelectedItems.Item(0).Text
                'chatIHC.TextBox1.Text = Me.ListView1.SelectedItem.ToString
                chatIHC.LabelContacto.Text = "Conversando con " & chatIHC.TextBox1.Text
                'fmr3.TextBox1.Text = Me.ListBox2.SelectedItem.ToString
                'fmr3.BackColor = Color.Azure
                'fmr3.Text = fmr3.TextBox1.Text & " (Chat con " & fmr3.TextBox1.Text & ")"
                chatIHC.Text = "Chat con " & chatIHC.TextBox1.Text

                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
        Else
            'usuario desconectado
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then
                Dim chatIHC As SalaChat = New SalaChat()
                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                'fmr3.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.TextBox1.Text = Me.ListView1.SelectedItems.Item(0).Text
                'chatIHC.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.LabelContacto.Text = "Conversando con " & chatIHC.TextBox1.Text
                'fmr3.BackColor = Color.Beige
                'fmr3.ForeColor = Color.Red
                chatIHC.RichTextBox1.Text = "Los mensajes seran entregados la proxima vez que el usuario se conecte."
                chatIHC.Text = "Desconectado!! " & "Conversando con " & chatIHC.TextBox1.Text
                'fmr3.Text = fmr3.TextBox1.Text & " Desconectado!!" & " (Chat con " & fmr3.TextBox1.Text & ")"
                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim indiceItem As Integer

        Dim ListViewItemTemp As System.Windows.Forms.ListViewItem
        Dim s As String
        For Each s In ListBox2.Items


            'ListView1.Items.Contains(ListViewItemTemp)
            indiceItem = buscar(ListView1, s, 0)

            If indiceItem > -1 Then
                'entonces el usuario existe como conectado en mi lista
            Else

                'entonces el usuario conectado no est en mi lista
                indiceItem = buscar(ListView1, s, 1)
                If indiceItem > -1 Then


                    'el usuario est como no conectado en mi lista, lo cambio a conectado

                    ListView1.Items.Item(indiceItem).ImageIndex = 0


                    'ListView1.Items.RemoveAt(indiceItem)

                    'ListViewItemTemp = New System.Windows.Forms.ListViewItem(s, 0)
                    'ListView1.Items.Add(ListViewItemTemp)


                Else
                    'el usuario  no est como no conectado, debo agregarlo como conectado
                    ListViewItemTemp = New System.Windows.Forms.ListViewItem(s, 0)
                    ListView1.Items.Add(ListViewItemTemp)
                End If



            End If





        Next s


        For Each s In ListBox3.Items


            'ListView1.Items.Contains(ListViewItemTemp)
            indiceItem = buscar(ListView1, s, 1)

            If indiceItem > -1 Then
                'entonces el usuario existe como no conectado en mi lista
            Else

                'entonces el usuario no conectado no est en mi lista
                indiceItem = buscar(ListView1, s, 0)
                If indiceItem > -1 Then


                    'el usuario est como  conectado en mi lista, lo cambio a no conectado

                    'ListView1.Items.RemoveAt(indiceItem)

                    'ListViewItemTemp = New System.Windows.Forms.ListViewItem(s, 1)
                    'ListView1.Items.Add(ListViewItemTemp)

                    ListView1.Items.Item(indiceItem).ImageIndex = 1

                Else
                    'el usuario  no est como conectado, debo agregarlo como no conectado
                    ListViewItemTemp = New System.Windows.Forms.ListViewItem(s, 1)
                    ListView1.Items.Add(ListViewItemTemp)
                End If



            End If





        Next s



    End Sub

    Private Function buscar(ByVal Lista As System.Windows.Forms.ListView, ByVal texto As String, ByVal tipo As Integer) As Integer

        For Each elemento As System.Windows.Forms.ListViewItem In Lista.Items
            If elemento.Text = texto And elemento.ImageIndex = tipo Then

                Return elemento.Index

            End If
        Next
        Return -1

    End Function


    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.ListView1.SelectedItems.Item(0).ImageIndex = 0 Then
            'usuario conecatdo
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then
                Dim chatIHC As SalaChat = New SalaChat()
                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                chatIHC.TextBox1.Text = Me.ListView1.SelectedItems.Item(0).Text
                'chatIHC.TextBox1.Text = Me.ListView1.SelectedItem.ToString
                chatIHC.LabelContacto.Text = "Conversando con " & chatIHC.TextBox1.Text
                'fmr3.TextBox1.Text = Me.ListBox2.SelectedItem.ToString
                'fmr3.BackColor = Color.Azure
                'fmr3.Text = fmr3.TextBox1.Text & " (Chat con " & fmr3.TextBox1.Text & ")"
                chatIHC.Text = "Chat con " & chatIHC.TextBox1.Text

                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
        Else
            'usuario desconectado
            If ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 1 Then
                Dim chatIHC As SalaChat = New SalaChat()
                'Dim fmr3 As Form3 = New Form3()
                chatIHC.Show()
                'fmr3.Show()
                'fmr3.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.TextBox1.Text = Me.ListView1.SelectedItems.Item(0).Text
                'chatIHC.TextBox1.Text = Me.ListBox3.SelectedItem.ToString
                chatIHC.LabelContacto.Text = "Conversando con " & chatIHC.TextBox1.Text
                'fmr3.BackColor = Color.Beige
                'fmr3.ForeColor = Color.Red
                chatIHC.Text = "Desconectado!! " & "Conversando con " & chatIHC.TextBox1.Text
                chatIHC.RichTextBox1.Text = "Los mensajes seran entregados la proxima vez que el usuario se conecte."
                'fmr3.Text = fmr3.TextBox1.Text & " Desconectado!!" & " (Chat con " & fmr3.TextBox1.Text & ")"
                'fmr3.user.Text = fmr3.TextBox1.Text
                chatIHC.LabelContacto.Text = chatIHC.TextBox1.Text

                'Si existe una ventana en uso para un usuario, asigno un 0 a ese usuario en la tablaH
                ventanas.Item(Me.ListView1.SelectedItems.Item(0).Text) = 0
                'ventanas.Remove(Me.ListBox2.SelectedItem.ToString)
            End If
        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub


    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Process.Start("c:\Windows\hh.exe", ".\Ayuda.chm::/Bienvenida.htm")
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
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
End Class
