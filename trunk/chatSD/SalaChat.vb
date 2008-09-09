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


    Public Sub Wait(ByVal seconds As Single)
        Dim newDate As Date
        newDate = DateAndTime.Now.AddSeconds(seconds)
        While DateAndTime.Now.Second <> newDate.Second
            Application.DoEvents()
        End While
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IngresoContacto.ShowDialog()

        If IngresoContacto.elegido = 0 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Edmundo Leiva a la Conversacion"
        End If
        If IngresoContacto.elegido = 1 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Rodrigo Morales a la Conversacion"
        End If
        If IngresoContacto.elegido = 2 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Patricio Castro a la Conversacion"
        End If
        If IngresoContacto.elegido = 3 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Roberto Vargas a la Conversacion"
        End If
        If IngresoContacto.elegido = 4 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Daniel Barria a la Conversacion"
        End If
        If IngresoContacto.elegido = 5 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Cristian Muñoz a la Conversacion"
        End If
        If IngresoContacto.elegido = 6 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Francia Jimenez a la Conversacion"
        End If
        If IngresoContacto.elegido = 7 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Claudio Sanhueza a la Conversacion"
        End If
        If IngresoContacto.elegido = 8 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Isaias Gonzalez a la Conversacion"
        End If
        If IngresoContacto.elegido = 9 Then
            RichTextBox1.Text = RichTextBox1.Text + "   Se agrego Sebastian Maldonado a la Conversacion"
        End If


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
            Dim Log As IHC.Login = New Login
            Log.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub LabelContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelContacto.Click

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        If (CerrarSistema.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            System.Windows.Forms.Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub
End Class