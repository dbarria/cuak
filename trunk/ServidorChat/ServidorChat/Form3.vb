Imports System.Data.SqlClient
Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim nuevo As New dao.BD
        Dim x As Integer
        'x = nuevo.estadoUsuario(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        'TextBox4.Text = x
        Dim usuario As String
        Dim clave As String

        usuario = "hola"
        clave = "chao"
        'TextBox5.Text = nuevo.cone
        'TextBox6.Text = nuevo.bd
        nuevo.ini()
        nuevo.stringC.Open()
        nuevo.RegistrarUsuario(usuario, clave)

    
        'stringC.Close()



    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class