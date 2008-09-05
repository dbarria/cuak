Imports System.Data.SqlClient
Public Class Form2


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim comand As SqlCommand = New SqlCommand
        'creo la conexión la BD
        Dim c As New ado.BD

        Dim x As String
        Dim y As String
        Dim i As Int16
        Dim cadenausers As String
        cadenausers = "/com"
        x = "*"
        y = "Usuario"
        Dim comando As SqlDataAdapter = New SqlDataAdapter("select " & x & " from " & y, c.stringC)
        Dim ds As DataSet = New DataSet()
        comando.Fill(ds, "tabla")
        For i = 0 To ds.Tables.Item(0).Rows.Count - 1

            cadenausers = cadenausers & ":" & ds.Tables.Item(0).Rows(i).Item(0).ToString

        Next
        TextBox1.Text = cadenausers


    End Sub
End Class