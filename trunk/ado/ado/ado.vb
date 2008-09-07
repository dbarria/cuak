Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Reflection
Public Class BD

    Public stringC As New SqlConnection
    Public cone As String
    Public server As String
    Public bd As String
    Public Codigo As String
    Public id As Integer

    Sub ini()
        'Dim xml As Xml.XmlText
        Dim m_xmlr As XmlTextReader


        'Creamos el XML Reader
        m_xmlr = New XmlTextReader("config_BD.xml")

        'Desabilitamos las lineas en blanco,
        'ya no las necesitamos
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None

        'Leemos el archivo y avanzamos al tag de usuarios
        m_xmlr.Read()

        'Leemos el tag usuarios
        m_xmlr.Read()
        'm_xmlr.Read()

        'Creamos la secuancia que nos permite
        'leer el archivo
        While Not m_xmlr.EOF
            'Avanzamos al siguiente tag
            m_xmlr.Read()

            'si no tenemos el elemento inicial
            'debemos salir del ciclo
            If Not m_xmlr.IsStartElement() Then
                Exit While
            End If

            'Obtenemos el elemento codigo
            Codigo = m_xmlr.GetAttribute("codigo")

            m_xmlr.Read()

            'Obtenemos el host
            id = m_xmlr.ReadElementString("id")
            'Obtenemos el host
            server = m_xmlr.ReadElementString("server")

            'Obtenemos el puerto
            bd = m_xmlr.ReadElementString("bd")


            cone = "Data Source=" & server & ";Initial Catalog=" & bd & ";Integrated Security=True"
            stringC.ConnectionString = cone
        End While

        'Cerramos la lactura del archivo
        m_xmlr.Close()
    End Sub


    Sub guardarcadenatoodos(ByVal cadenamsje As String)
        Dim comand As SqlCommand = New SqlCommand

        'preparo el procedimiento almacenado que almacena mesje, ip y puerto de cada msje recibido
        'le indico el nombre el procd
        comand.CommandText = "GuardaMsjeaTodos"
        'le indico q es un procd
        comand.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand.Connection = stringC
        'stringC.Open()
        'asigno las variables a enviar a las variables del procedimiento
        comand.Parameters.AddWithValue("@Msje", cadenamsje)
        comand.ExecuteNonQuery()
        'stringC.Close()
    End Sub

    Sub guardarcadenaUno(ByVal usuarioDestino As String, ByVal texto As String)
        Dim comand As SqlCommand = New SqlCommand

        'preparo el procedimiento almacenado que almacena mesje, ip y puerto de cada msje recibido
        'le indico el nombre el procd
        comand.CommandText = "GuardaMsjeaUno"
        'le indico q es un procd
        comand.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand.Connection = stringC
        'stringC.Open()
        'asigno las variables a enviar a las variables del procedimiento
        comand.Parameters.AddWithValue("@usuarioD", usuarioDestino)
        comand.Parameters.AddWithValue("@Msje", texto)
        comand.ExecuteNonQuery()
        'stringC.Close()
    End Sub

    Sub estadoUsuario(ByVal ip As String, ByVal puerto As String, ByVal usuarioA As String)
        'ini()
        Dim comand As SqlCommand = New SqlCommand
        'preparo el procedimiento actualiza el estado, la ip y el puerto de un usuario
        'le indico el nombre el procd
        comand.CommandText = "usuarioStatus"
        'le indico q es un procd
        comand.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand.Connection = stringC

        'asigno las variables a enviar a las variables del procedimiento
        comand.Parameters.AddWithValue("@conectado", "1")
        comand.Parameters.AddWithValue("@Ip", ip)
        comand.Parameters.AddWithValue("@Puerto", puerto)
        comand.Parameters.AddWithValue("@Usuario", usuarioA)


        'se ejecuta el procd
        comand.ExecuteNonQuery()

    End Sub

    Sub DesconectarUsuario(ByVal ip2 As String, ByVal puerto2 As String)
        'ini()
        Dim comand2 As SqlCommand = New SqlCommand
        'creo la conexión la BD

        'preparo el procedimiento almacenado que almacena mesje, ip y puerto de cada msje recibido
        'le indico el nombre el procd
        comand2.CommandText = "usuarioStatusDesc"
        'le indico q es un procd
        comand2.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand2.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand2.Connection = stringC

        'asigno las variables a enviar a las variables del procedimiento
        comand2.Parameters.AddWithValue("@conectado", "0")
        comand2.Parameters.AddWithValue("@Ip", ip2)
        comand2.Parameters.AddWithValue("@Puerto", puerto2)


        'abro la conexión
        'stringC.Open()
        'se ejecuta el procd
        comand2.ExecuteNonQuery()
        'stringC.Close()

    End Sub

    Function UsuarioDesconectado(ByVal ip2 As String, ByVal puerto2 As String)
        'ini()
        Dim cadenausers As String
        Dim comando As New SqlCommand("Select usuario from Usuarios where Ip=@ip and Puerto=@Puerto", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim x As Int16
        comando.Parameters.AddWithValue("@Ip", ip2)
        comando.Parameters.AddWithValue("@Puerto", puerto2)
        'stringC.Open()
        adap.Fill(tabla)
        ' en caso que la desconeccion sea de un usuario no logueado, por ejemplo:
        'desconexion de registro, el numero de filas x, es igual a 0
        x = tabla.Rows.Count
        'stringC.Close()
        'si existen filas, añado a la cadena, en caso contrario, devuelvo la palabra nadie
        If x <> 0 Then
            cadenausers = tabla.Rows(0)("usuario")
            cadenausers = "/des:" & cadenausers & ":"

        Else
            cadenausers = "nadie"
        End If
        Return cadenausers

    End Function



    Function ExisteUser(ByVal user As String)
        'ini()
        Dim comando As New SqlCommand("Select usuario from Usuarios where usuario=@usuario", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim x As Int16
        comando.Parameters.AddWithValue("@usuario", user)

        'stringC.Open()
        adap.Fill(tabla)
        'rescato la cantidad de filas que genera la consulta
        x = tabla.Rows.Count
        'si hay filas, retorno un 1
        If x <> 0 Then
            Return 1
        Else
            Return 0
        End If

    End Function


    Function UserEstaConectado(ByVal user As String)
        'ini()
        Dim comando As New SqlCommand("Select usuario from Usuarios where usuario=@usuario and conectado=1", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim x As Int16
        comando.Parameters.AddWithValue("@usuario", user)

        'stringC.Open()
        adap.Fill(tabla)
        'rescato la cantidad de filas que genera la consulta
        x = tabla.Rows.Count
        'si hay filas, retorno un 1
        If x <> 0 Then
            Return 1
        Else
            Return 0
        End If

    End Function


    Sub GuardarMsaje(ByVal mensaje As String, ByVal ip As String, _
    ByVal puerto As String, ByVal usuarioA As String, _
    ByVal usuarioB As String, ByVal entregado As Int16)
        Dim comand As SqlCommand = New SqlCommand

        'preparo el procedimiento almacenado que almacena mesje, ip y puerto de cada msje recibido
        'le indico el nombre el procd
        comand.CommandText = "GuardaMsje"
        'le indico q es un procd
        comand.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand.Connection = stringC
        'stringC.Open()
        'asigno las variables a enviar a las variables del procedimiento
        comand.Parameters.AddWithValue("@Mensaje", mensaje)
        comand.Parameters.AddWithValue("@Ip", ip)
        comand.Parameters.AddWithValue("@Puerto", puerto)
        comand.Parameters.AddWithValue("@UsuarioA", usuarioA)
        comand.Parameters.AddWithValue("@UsuarioB", usuarioB)
        comand.Parameters.AddWithValue("@entreg", entregado)

        comand.ExecuteNonQuery()
        'stringC.Close()
    End Sub


    Sub RegistrarUsuario(ByVal usuario As String, ByVal clave As String)
        Dim comand As SqlCommand = New SqlCommand
        Dim conectado As String
        Dim ip As String
        Dim puerto As String
        ip = "0"
        puerto = "0"
        conectado = "0"
        'preparo el procedimiento almacenado que almacena mesje, ip y puerto de cada msje recibido
        'le indico el nombre el procd
        comand.CommandText = "RegistrarUser"
        'le indico q es un procd
        comand.CommandType = CommandType.StoredProcedure
        'limipio en caso de haber enviado variables antes
        comand.Parameters.Clear()
        'el comando que cree va a usar esta conexión
        comand.Connection = stringC
        'stringC.Open()
        'asigno las variables a enviar a las variables del procedimiento
        comand.Parameters.AddWithValue("@Usuario", usuario)
        comand.Parameters.AddWithValue("@Ip", ip)
        comand.Parameters.AddWithValue("@Puerto", puerto)
        comand.Parameters.AddWithValue("@conectado", conectado)
        comand.Parameters.AddWithValue("@clave", clave)

        comand.ExecuteNonQuery()
        'stringC.Close()
    End Sub


    Function EstaOnline(ByVal user As String)
        'ini()
        Dim comando As New SqlCommand("Select conectado from Usuarios where usuario=@usuario", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim conect As String
        comando.Parameters.AddWithValue("@usuario", user)


        adap.Fill(tabla)
        ' rescato ip de la tabla
        conect = tabla.Rows(0)("conectado")


        Return conect


    End Function


    Function IpUser(ByVal user As String)
        'ini()
        Dim comando As New SqlCommand("Select ip from Usuarios where usuario=@usuario", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim ip As String
        comando.Parameters.AddWithValue("@usuario", user)


        adap.Fill(tabla)
        ' rescato ip de la tabla
        ip = tabla.Rows(0)("IP")


        Return ip


    End Function

    Function cadenatoodos(ByVal id As Integer)
        'ini()
        Dim comando As New SqlCommand("Select cadena from Enviar where identificador=@identif", stringC)
        Dim comando2 As New SqlCommand("Update Enviar set pendientes='nada' where identificador=@identif", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim caden As String
        comando.Parameters.AddWithValue("@identif", id)
        comando2.Parameters.AddWithValue("@identif", id)
        adap.Fill(tabla)
        ' rescato puerto de la tabla
        caden = tabla.Rows(0)("cadena")

        comando2.ExecuteScalar()
        Return caden


    End Function


    Function EviarUnoUser(ByVal id As Integer)
        'ini()
        Dim comando As New SqlCommand("Select Usuario from Enviar where identificador=@identif", stringC)
        'Dim comando2 As New SqlCommand("Update Enviar set pendientes='nada' where identificador=@identif", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim UsuarioD As String
        comando.Parameters.AddWithValue("@identif", id)
        'comando2.Parameters.AddWithValue("@identif", id)
        adap.Fill(tabla)
        ' rescato puerto de la tabla
        UsuarioD = tabla.Rows(0)("Usuario")

        'comando2.ExecuteScalar()
        Return UsuarioD


    End Function


    Function EnviarMensajeAuno(ByVal id As Integer)
        'ini()
        Dim comando As New SqlCommand("Select cadena from Enviar where identificador=@identif", stringC)
        Dim comando2 As New SqlCommand("Update Enviar set pendientes='nada' where identificador=@identif", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim caden As String
        comando.Parameters.AddWithValue("@identif", id)
        comando2.Parameters.AddWithValue("@identif", id)
        adap.Fill(tabla)
        ' rescato puerto de la tabla
        caden = tabla.Rows(0)("cadena")

        comando2.ExecuteScalar()
        Return caden


    End Function


    Function enviarpendiente(ByVal id As Integer)
        'ini()
        Dim comando As New SqlCommand("Select pendientes from Enviar where identificador=@identif", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim pendiente As String
        comando.Parameters.AddWithValue("@identif", id)

        adap.Fill(tabla)
        ' rescato puerto de la tabla
        pendiente = tabla.Rows(0)("pendientes")


        Return pendiente


    End Function

    Function PuertoUser(ByVal user As String)
        'ini()
        Dim comando As New SqlCommand("Select Puerto from Usuarios where usuario=@usuario", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim puerto As String
        comando.Parameters.AddWithValue("@usuario", user)

        adap.Fill(tabla)
        ' rescato puerto de la tabla
        puerto = tabla.Rows(0)("Puerto")


        Return puerto


    End Function

    Function UserByIpPort(ByVal ip As String, ByVal puerto As String)
        'ini()
        Dim comando As New SqlCommand("Select usuario from Usuarios where Puerto=@puerto and ip=@ip", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)
        Dim usuario As String
        comando.Parameters.AddWithValue("@ip", ip)
        comando.Parameters.AddWithValue("@puerto", puerto)

        adap.Fill(tabla)
        ' usuario
        usuario = tabla.Rows(0)("usuario")


        Return usuario
    End Function


    Function mostrarConectados()
        Dim cadenausers As String
        cadenausers = ""
        Dim cantuser As Integer
        Dim i As Integer
        Dim comando As SqlDataAdapter = New SqlDataAdapter("exec mostrarconectados", stringC)
        Dim ds As DataSet = New DataSet()

        comando.Fill(ds, "tabla")


        For i = 0 To ds.Tables.Item(0).Rows.Count - 1
            cadenausers = cadenausers & ":" & ds.Tables.Item(0).Rows(i).Item(0).ToString
        Next
        cantuser = i
        cadenausers = "/con:" & cantuser & cadenausers & ":"
        Return cadenausers

    End Function

    Function MensajesCola(ByVal user As String)
        Dim cadena As String
        cadena = ""
        Dim cantidad As Int16
        Dim cantuser As Integer
        Dim i As Integer

        Dim comando As New SqlCommand("select texto from Mensajes where entregado=0 and usuarioB=@user", stringC)
        Dim tabla As New DataTable
        Dim adap As New SqlDataAdapter(comando)

        comando.Parameters.AddWithValue("@user", user)

        Dim ds As DataSet = New DataSet()

        adap.Fill(ds, "tabla")

        cantidad = ds.Tables.Item(0).Rows.Count
        If cantidad > 0 Then
            For i = 0 To ds.Tables.Item(0).Rows.Count - 1
                cadena = cadena & ":" & ds.Tables.Item(0).Rows(i).Item(0).ToString
            Next
            cantuser = i
            cadena = "/cola:" & cantuser & cadena & ":"
            Return cadena
        Else

            Return "NO"
        End If



    End Function

    Sub MensajesColaOff(ByVal user As String)

        Dim comando As New SqlCommand("Update Mensajes set entregado=1   where  usuarioB=@user", stringC)

        comando.Parameters.AddWithValue("@user", user)
        comando.ExecuteScalar()

    End Sub
    Function mostrarDesconectados()
        Dim cadenausers As String
        cadenausers = ""
        Dim cantidad As Int16
        Dim cantuser As Integer
        Dim i As Integer
        Dim comando As SqlDataAdapter = New SqlDataAdapter("exec mostrarNoconectados", stringC)
        Dim ds As DataSet = New DataSet()

        comando.Fill(ds, "tabla")

        cantidad = ds.Tables.Item(0).Rows.Count
        If cantidad > 0 Then
            For i = 0 To ds.Tables.Item(0).Rows.Count - 1
                cadenausers = cadenausers & ":" & ds.Tables.Item(0).Rows(i).Item(0).ToString
            Next
            cantuser = i
            cadenausers = "/descon:" & cantuser & cadenausers & ":"
            Return cadenausers
        Else

            Return "NO:"
        End If



    End Function

End Class
