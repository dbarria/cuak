Imports System.Data.SqlClient
Public Class Form1

    Inherits System.Windows.Forms.Form
    Public x(4) As String
    Public xdc(4) As String
    Public flag As Int16
    Public flagDC As Int16
    Public lista() As String
    Public count As Int16
    Private mensaje As New Hashtable()
    Dim WithEvents WinSockServer As New controladorServidor.servidor
    'Public c As New dao.BD
    Public dao As New dao.BD
    Public NuevosConect As Integer
    Public nuevouser As String
    Public tipomensaje As String
    Public cadenaenviar As String
    Public idserver As Integer
    Public usuarioUno As String
    Public MensajeAUno As String



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tipomensaje = ""
        flag = 0
        flagDC = 0
        count = 0
        NuevosConect = 0
        'inicio la config de la bd
        dao.ini()
        dao.stringC.Open()
        idserver = dao.id
        Dim port As New controladorServidor.config
        With WinSockServer

            'Establezco el puerto donde escuchar
            port.read()
            .PuertoDeEscucha = port.port

            'Comienzo la escucha
            .Escuchar()

        End With

    End Sub

    Sub WinSockServer_NuevaConexion(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.NuevaConexion

        'Muestro quien se conecto
        'MsgBox("Se ha conectado un nuevo cliente desde la IP= " & IDTerminal.Address.ToString & ",Puerto = " & IDTerminal.Port)

    End Sub

    Private Sub WinSockServer_ConexionTerminada(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.ConexionTerminada

        'Muestro con quien se termino la conexion
        'MsgBox("Se ha desconectado el cliente desde la IP= " & IDTerminal.Address.ToString & ",Puerto = " & IDTerminal.Port)
        'Aviso de nuevo mensaje recibido
        'count = count + 1
        'Guardo la IP
        xdc(0) = IDTerminal.Address.ToString
        'Guardo El puerto
        xdc(1) = IDTerminal.Port.ToString
        flagDC = 1
    End Sub

    'Paso 1: Definir la firma del evento a publicar
    Public Delegate Sub FirmaEventoAPublicar(ByVal texto As String)

    'Paso 2: Definir el apuntador para guardar las funciones a invocar
    Public EventoAPublicar As FirmaEventoAPublicar

    Private Sub WinSockServer_DatosRecibidos(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.DatosRecibidos
        'Aviso de nuevo mensaje recibido
        'count = count + 1
        'Guardo el mensaje
        x(0) = WinSockServer.ObtenerDatos(IDTerminal)
        'Guardo la IP
        x(1) = IDTerminal.Address.ToString
        'Guardo El puerto
        x(2) = IDTerminal.Port.ToString
        flag = 1

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        'En caso de que un usuario se desconecto
        '###########################  INICIO Accion cuando se desconecta un usuario  ############################
        If flagDC = 1 Then
            'Timer1.Enabled = False
            Dim comand2 As SqlCommand = New SqlCommand()
            Dim cadenausers As String
            Dim ip2 As String
            Dim puerto2 As String
            Dim usuarioDC As String
            'rescato IP
            TextBox6.Text = xdc(0)
            'Rescato Puerto
            TextBox7.Text = xdc(1)

            ip2 = TextBox6.Text
            puerto2 = TextBox7.Text
            'Agrego un 0 al usuario en la BD en base a la IP y Puerto
            Try
                dao.DesconectarUsuario(ip2, puerto2)
                'Quito usuario del listbox1 de conectados del servidor
                usuarioDC = dao.UserByIpPort(ip2, puerto2)
                ListBox1.Items.Remove(usuarioDC)
            Catch ex As Exception
            End Try


            'Rescato el el nombre del usuario desconectado y 
            'armo el string que se envia a todos los usuarios
            cadenausers = dao.UsuarioDesconectado(ip2, puerto2)
            'tipomensaje = "todos"
            Try
                'si no es desconección de registro
                '// se envia nadie en caso que sea desconeccion de registro
                If cadenausers <> "nadie" Then
                    txtMensaje.Text = cadenausers & "::FIN::::FIN::::FIN::"

                    dao.guardarcadenatoodos(txtMensaje.Text)
                    'Intento enviar el mensaje a todos

                    'WinSockServer.EnviarDatos(txtMensaje.Text)
                End If
            Catch ex As Exception
            End Try

            flagDC = 0
            'Timer1.Enabled = True
        End If
        '###########################  FIN Accion cuando se desconecta un usuario  ############################




        '#####################################################################################################
        '#########################  INICIO RECIBIR DATOS, COMANDOS Y NUEVAS CONEXIONES #######################
        '#####################################################################################################

        '###########################  INICIO Analisis mensje-> rescatando usuario y comando (Acción)  ############################
        If flag = 1 Then
            'Timer1.Enabled = False
            Dim mensaje As String
            Dim ip As String
            Dim puerto As String
            Dim usuarioA As String
            Dim usuarioB As String
            Dim posicion As Integer
            Dim po As Integer
            Dim i As Int16

            Dim comand As SqlCommand = New SqlCommand

            'almaceno el msje recibido
            TextBox1.Text = x(0)
            'almaceno IP
            TextBox2.Text = x(1)
            'almaceno puerto
            TextBox3.Text = x(2)

            'analizando mensaje, rescatando usuario de procedencia, comando y mensaje
            posicion = x(0).IndexOf(":")

            'UsuarioA es el usuario origen
            txtUsuarioA.Text = x(0).Substring(0, posicion)
            po = TextBox1.Text.IndexOf(":")
            ' Almaceno temporalmente string
            TextBox8.Text = TextBox1.Text.Substring(po + 1, TextBox1.Text.Length - 1 - po)


            'rescato el comando
            TextBox5.Text = TextBox1.Text.Substring(po + 2, TextBox1.Text.Length - 2 - po)
            po = TextBox5.Text.IndexOf(":")
            If po > 1 Then
                TextBox5.Text = TextBox5.Text.Substring(0, po)
            End If


            'UsuarioB
            posicion = TextBox8.Text.IndexOf(":")
            'en caso de ser comando, no exite otro ":" y posicion tendra un -1, por lo tanto no existe
            'el UsuarioB, ej: kike:/nueva_conexion
            If posicion <> -1 Then
                'UsuarioB es el Usuario Destino
                txtUsuarioB.Text = TextBox8.Text.Substring(0, posicion)
            End If

            'Mensaje Real enviado entre usuarios, incluye UsuarioA y UsuarioB
            TextBox9.Text = TextBox1.Text

            po = TextBox8.Text.IndexOf(":")

            'Mensaje limpio (sin usuarioA y UsuarioB)enviado entre usuarios, ej:  "Hola"
            'Usado solo para visualizar en Server
            TextBox8.Text = TextBox8.Text.Substring(po + 1, TextBox8.Text.Length - 1 - po)

            '###########################  FIN Analisis mensje-> Ahora se procede a realizar acción (Comando en TextBox5.Text)  ############################


            '###########################  INICIO Envio de Usuarios Conectados cuando hay nueva conexión  ############################
            If TextBox5.Text = "/nueva_conexion" Then

                'Cuento la cantidad de nuevos conectados para utilizarlo en la verificación de colas
                NuevosConect = 1

                ip = TextBox2.Text
                puerto = TextBox3.Text
                usuarioA = txtUsuarioA.Text
                Dim temp1 As String
                Dim temp2 As String
                Dim cadenacola As String
                If dao.ExisteUser(usuarioA) = 1 Then

                    If dao.EstaOnline(usuarioA) = 1 Then
                        dao.guardarcadenatoodos("/Conectado:" & usuarioA & "::FIN::::FIN::::FIN::")
                    Else
                        ' En la Bd agrego un 1 en el estado del usuario
                        dao.estadoUsuario(ip, puerto, usuarioA)

                        'Agrego usuario al listbox1 de conectados del servidor
                        ListBox1.Items.Add(usuarioA)

                        'dao.mostrarConectados me entrega el string con los conectados de la siguiente forma "/con:" & cantuser & cadenausers & ":"
                        temp1 = dao.mostrarConectados

                        'dao.mostrarDesconectados me entrega el string con los NOconectados de la siguiente forma "/descon:" & cantuser & cadenausers & ":"

                        temp2 = dao.mostrarDesconectados

                        cadenacola = dao.MensajesCola(usuarioA)
                        dao.MensajesColaOff(usuarioA)

                        txtMensaje.Text = temp1 & temp2 & cadenacola & "::FIN::::FIN::::FIN::"

                        dao.guardarcadenatoodos(txtMensaje.Text)
                    End If
                Else
                    dao.guardarcadenatoodos("/Noexiste:" & usuarioA & "::FIN::::FIN::::FIN::")

                End If
                'WinSockServer.EnviarDatos(txtMensaje.Text)
                flag = 0
                'Timer1.Enabled = True
            End If




            '###########################  FIN Envio de Usuarios Conectados cuando hay nueva conexión  ############################

            '###########################  INICIO Registrando Usuario  ############################

            If TextBox5.Text = "/registro" Then
                Dim userR As String
                Dim passR As String
                Dim temp As String
                po = TextBox8.Text.IndexOf(":")
                'rescato nombre de nuevo susuaio
                userR = TextBox8.Text.Substring(0, po)
                temp = TextBox8.Text.Substring(po + 1, TextBox8.Text.Length - 1 - po)
                po = temp.IndexOf(":")
                'rescato password de nuevo usuario
                passR = temp.Substring(0, po)
                flag = 0

                If dao.ExisteUser(userR) = 1 Then
                    'si el usuario existe, envio mensaje avisando
                    dao.guardarcadenatoodos("/regisSi:" & userR & "::FIN::::FIN::::FIN::")
                    'WinSockServer.EnviarDatos("/regisSi:" & userR & "::FIN::::FIN::::FIN::")

                Else
                    'si el usuario no existe, procedo con el registro y aviso del exito
                    dao.RegistrarUsuario(userR, passR)
                    dao.guardarcadenatoodos("/regisNo:" & userR & "::FIN::::FIN::::FIN::")
                    'WinSockServer.EnviarDatos("/regisNo:" & userR & "::FIN::::FIN::::FIN::")
                End If


            End If
            '########################### FIN  Registrando Usuario############################



            '###########################  INICIO almacenando y enviando mensajes o dejo en Cola (TextBox5.Text es null) ############################
            'Si no ha pasado por los otros comandos, flag aún es 1
            If flag = 1 Then

                'Timer1.Enabled = False
                'creo un objeto para usar el procedimiento



                mensaje = TextBox1.Text
                ip = TextBox2.Text
                puerto = TextBox3.Text
                usuarioA = txtUsuarioA.Text
                usuarioB = txtUsuarioB.Text
                'guardo el mensaje en la BD -> Cola de mensajes e historial


                '----------aca cambiar el listbox por dao
                If dao.EstaOnline(usuarioB) = 0 Then
                    'si no esta conectado, dejo el mensaje en la cola
                    If TextBox8.Text <> " ::::estoy_escribiendo::::" Then
                        dao.GuardarMsaje(mensaje, ip, puerto, usuarioA, usuarioB, 0)
                    End If

                Else
                    'si esta conectado, almaceno mensaje y envio
                    dao.GuardarMsaje(mensaje, ip, puerto, usuarioA, usuarioB, 1)


                    dao.guardarcadenaUno(usuarioB, TextBox9.Text)

                    'utilizamos dao para rescatar IP y Puerto del usuario que recibira el mensaje



                End If


                'Timer1.Enabled = True
                flag = 0

            End If
            '###########################  FIN almacenando y enviando mensajes o dejo en Cola ############################

        End If

        '#####################################################################################################
        '#########################  FIN RECIBIR DATOS, COMANDOS Y NUEVAS CONEXIONES #######################
        '#####################################################################################################

        tipomensaje = dao.enviarpendiente(idserver)

        If tipomensaje = "todos" Then
            cadenaenviar = dao.cadenatoodos(idserver)
            Try
                WinSockServer.EnviarDatos(cadenaenviar)
            Catch ex As Exception

            End Try


            'tipomensaje = ""
        End If

        If tipomensaje = "uno" Then
            usuarioUno = dao.EviarUnoUser(idserver)
            MensajeAUno = dao.EnviarMensajeAuno(idserver)
            TextBox4.Text = dao.IpUser(usuarioUno)
            TextBox10.Text = dao.PuertoUser(usuarioUno)



            Dim ipB As Net.IPAddress
            ipB = Net.IPAddress.Parse(TextBox4.Text)
            Dim IDClienteB As Net.IPEndPoint = New Net.IPEndPoint(ipB, TextBox10.Text)
            Try
                WinSockServer.EnviarDatos(IDClienteB, MensajeAUno & "::FIN::::FIN::::FIN::")
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub btnEnviarMensaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarMensaje.Click

        'Envio el texto escrito en el textbox txtMensaje a todos los clientes
        ' txtMensaje.Text = txtMensaje.Text & "::FIN::::FIN::::FIN::"
        'WinSockServer.EnviarDatos(txtMensaje.Text)

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
        'Form2.Close()
        'Me.Close()
    End Sub


End Class

