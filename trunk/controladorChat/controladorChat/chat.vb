Imports System.IO
Imports System.Xml
Imports System.Reflection
Imports System
Imports System.Threading
Imports System.Net.Sockets
Imports System.Text

Public Class chat

    Public ip As String
    Public port As String
    Public Codigo As String

    Sub config()
        'Dim xml As Xml.XmlText
        Dim m_xmlr As XmlTextReader


        'Creamos el XML Reader
        m_xmlr = New XmlTextReader("ip_port.xml")

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
            'Obtenemos la ip
            ip = m_xmlr.ReadElementString("ip")

            'Obtenemos el puerto
            port = m_xmlr.ReadElementString("port")


        End While

        'Cerramos la lactura del archivo
        m_xmlr.Close()
    End Sub
End Class



Public Class Cliente

#Region "VARIABLES"

    Private Stm As Stream 'Utilizado para enviar datos al Servidor y recibir datos del mismo

    Private m_IPDelHost As String 'Direccion del objeto de la clase Servidor

    Private m_PuertoDelHost As String 'Puerto donde escucha el objeto de la clase Servidor

#End Region



#Region "EVENTOS"

    Public Event ConexionTerminada()

    Public Event DatosRecibidos(ByVal datos As String)

#End Region



#Region "PROPIEDADES"

    Public Property IPDelHost() As String

        Get

            IPDelHost = m_IPDelHost

        End Get



        Set(ByVal Value As String)

            m_IPDelHost = Value

        End Set

    End Property



    Public Property PuertoDelHost() As String

        Get

            PuertoDelHost = m_PuertoDelHost

        End Get

        Set(ByVal Value As String)

            m_PuertoDelHost = Value

        End Set

    End Property

#End Region



#Region "METODOS"

    Public Sub Conectar()

        Dim tcpClnt As TcpClient
        Dim conecto As Int16
        Dim tcpThd As Thread 'Se encarga de escuchar mensajes enviados por el Servidor

        conecto = 0

        tcpClnt = New TcpClient()

        'Me conecto al objeto de la clase Servidor,

        '  determinado por las propiedades IPDelHost y PuertoDelHost
        Try


            tcpClnt.Connect(IPDelHost, PuertoDelHost)





            'Creo e inicio un thread para que escuche los mensajes enviados por el Servidor
            conecto = 1

        Catch ex As Exception
            conecto = 0
        End Try
        If conecto = 1 Then
            Stm = tcpClnt.GetStream()

            tcpThd = New Thread(AddressOf LeerSocket)

            tcpThd.Start()
        End If
    End Sub



    Public Sub EnviarDatos(ByVal Datos As String)

        Dim BufferDeEscritura() As Byte



        BufferDeEscritura = Encoding.ASCII.GetBytes(Datos)



        If Not (Stm Is Nothing) Then

            'Envio los datos al Servidor

            Stm.Write(BufferDeEscritura, 0, BufferDeEscritura.Length)

        End If

    End Sub



#End Region



#Region "FUNCIONES PRIVADAS"

    Private Sub LeerSocket()

        Dim BufferDeLectura() As Byte



        While True

            Try

                BufferDeLectura = New Byte(1000) {}

                'Me quedo esperando a que llegue algun mensaje

                Stm.Read(BufferDeLectura, 0, BufferDeLectura.Length)



                'Genero el evento DatosRecibidos, ya que se han recibido datos desde el Servidor

                RaiseEvent DatosRecibidos(Encoding.ASCII.GetString(BufferDeLectura))

            Catch e As Exception

                Exit While

            End Try

        End While



        'Finalizo la conexion, por lo tanto genero el evento correspondiente

        RaiseEvent ConexionTerminada()

    End Sub

#End Region



End Class