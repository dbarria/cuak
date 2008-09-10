<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalaChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalaChat))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabConversacion1 = New System.Windows.Forms.TabPage
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.LabelContacto = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabConversacion2 = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox
        Me.RichTextBox4 = New System.Windows.Forms.RichTextBox
        Me.barraEstado2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.barraEstado = New System.Windows.Forms.Label
        Me.barraEstado3 = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.TabControl1.SuspendLayout()
        Me.TabConversacion1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabConversacion2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabConversacion1)
        Me.TabControl1.Controls.Add(Me.TabConversacion2)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 36)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(422, 470)
        Me.TabControl1.TabIndex = 0
        '
        'TabConversacion1
        '
        Me.TabConversacion1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabConversacion1.BackgroundImage = Global.chatSD.My.Resources.Resources.fondo2
        Me.TabConversacion1.Controls.Add(Me.ListBox1)
        Me.TabConversacion1.Controls.Add(Me.TextBox1)
        Me.TabConversacion1.Controls.Add(Me.LabelContacto)
        Me.TabConversacion1.Controls.Add(Me.Button1)
        Me.TabConversacion1.Controls.Add(Me.RichTextBox3)
        Me.TabConversacion1.Controls.Add(Me.RichTextBox1)
        Me.TabConversacion1.Controls.Add(Me.PictureBox1)
        Me.TabConversacion1.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.TabConversacion1.Location = New System.Drawing.Point(4, 22)
        Me.TabConversacion1.Name = "TabConversacion1"
        Me.TabConversacion1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabConversacion1.Size = New System.Drawing.Size(414, 444)
        Me.TabConversacion1.TabIndex = 0
        Me.TabConversacion1.Text = "Conversación 1"
        Me.TabConversacion1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(289, 333)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(95, 21)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.Visible = False
        '
        'LabelContacto
        '
        Me.LabelContacto.AutoSize = True
        Me.LabelContacto.BackColor = System.Drawing.Color.Transparent
        Me.LabelContacto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.LabelContacto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LabelContacto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelContacto.Location = New System.Drawing.Point(45, 14)
        Me.LabelContacto.Name = "LabelContacto"
        Me.LabelContacto.Size = New System.Drawing.Size(96, 13)
        Me.LabelContacto.TabIndex = 20
        Me.LabelContacto.Text = "Conversacion 1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightYellow
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(286, 359)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Enviar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(6, 224)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.RichTextBox3.Size = New System.Drawing.Size(264, 158)
        Me.RichTextBox3.TabIndex = 1
        Me.RichTextBox3.Text = ""
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 53)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.RichTextBox1.Size = New System.Drawing.Size(264, 155)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.chatSD.My.Resources.Resources.chatEstado1
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 30)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'TabConversacion2
        '
        Me.TabConversacion2.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField
        Me.TabConversacion2.BackColor = System.Drawing.Color.Transparent
        Me.TabConversacion2.BackgroundImage = Global.chatSD.My.Resources.Resources.fondo2
        Me.TabConversacion2.Controls.Add(Me.Label1)
        Me.TabConversacion2.Controls.Add(Me.PictureBox2)
        Me.TabConversacion2.Controls.Add(Me.Button7)
        Me.TabConversacion2.Controls.Add(Me.RichTextBox2)
        Me.TabConversacion2.Controls.Add(Me.RichTextBox4)
        Me.TabConversacion2.Location = New System.Drawing.Point(4, 22)
        Me.TabConversacion2.Name = "TabConversacion2"
        Me.TabConversacion2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabConversacion2.Size = New System.Drawing.Size(414, 444)
        Me.TabConversacion2.TabIndex = 1
        Me.TabConversacion2.Text = "Conversación 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(45, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Conversacion 2"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.chatSD.My.Resources.Resources.chatEstado1
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 30)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.LightYellow
        Me.Button7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button7.Location = New System.Drawing.Point(286, 359)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(100, 23)
        Me.Button7.TabIndex = 21
        Me.Button7.Text = "Enviar"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 224)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.RichTextBox2.Size = New System.Drawing.Size(264, 158)
        Me.RichTextBox2.TabIndex = 20
        Me.RichTextBox2.Text = ""
        '
        'RichTextBox4
        '
        Me.RichTextBox4.Enabled = False
        Me.RichTextBox4.Location = New System.Drawing.Point(6, 51)
        Me.RichTextBox4.Name = "RichTextBox4"
        Me.RichTextBox4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.RichTextBox4.Size = New System.Drawing.Size(264, 158)
        Me.RichTextBox4.TabIndex = 19
        Me.RichTextBox4.Text = ""
        '
        'barraEstado2
        '
        Me.barraEstado2.AutoSize = True
        Me.barraEstado2.BackColor = System.Drawing.Color.Transparent
        Me.barraEstado2.Font = New System.Drawing.Font("Verdana", 12.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barraEstado2.ForeColor = System.Drawing.Color.Transparent
        Me.barraEstado2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.barraEstado2.Location = New System.Drawing.Point(102, 509)
        Me.barraEstado2.Name = "barraEstado2"
        Me.barraEstado2.Size = New System.Drawing.Size(0, 20)
        Me.barraEstado2.TabIndex = 22
        Me.barraEstado2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(-1, 502)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(425, 4)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        '
        'barraEstado
        '
        Me.barraEstado.AutoSize = True
        Me.barraEstado.BackColor = System.Drawing.Color.Transparent
        Me.barraEstado.Font = New System.Drawing.Font("Verdana", 13.0!, System.Drawing.FontStyle.Bold)
        Me.barraEstado.ForeColor = System.Drawing.Color.Transparent
        Me.barraEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.barraEstado.Location = New System.Drawing.Point(78, 509)
        Me.barraEstado.Name = "barraEstado"
        Me.barraEstado.Size = New System.Drawing.Size(231, 22)
        Me.barraEstado.TabIndex = 21
        Me.barraEstado.Text = "Conversación iniciada"
        Me.barraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'barraEstado3
        '
        Me.barraEstado3.AutoSize = True
        Me.barraEstado3.BackColor = System.Drawing.Color.Transparent
        Me.barraEstado3.Font = New System.Drawing.Font("Verdana", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barraEstado3.ForeColor = System.Drawing.Color.Gainsboro
        Me.barraEstado3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.barraEstado3.Location = New System.Drawing.Point(53, 509)
        Me.barraEstado3.Name = "barraEstado3"
        Me.barraEstado3.Size = New System.Drawing.Size(0, 20)
        Me.barraEstado3.TabIndex = 23
        Me.barraEstado3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = Global.chatSD.My.Resources.Resources.exit2
        Me.PictureBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox6.Location = New System.Drawing.Point(5, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 25
        Me.PictureBox6.TabStop = False
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(286, 26)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 22
        Me.ListBox1.Visible = False
        '
        'SalaChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lime
        Me.BackgroundImage = Global.chatSD.My.Resources.Resources.fondo2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(427, 532)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.barraEstado3)
        Me.Controls.Add(Me.barraEstado2)
        Me.Controls.Add(Me.barraEstado)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Name = "SalaChat"
        Me.ShowIcon = False
        Me.Text = "Sistema Mensajeria - Sala de Chat"
        Me.TabControl1.ResumeLayout(False)
        Me.TabConversacion1.ResumeLayout(False)
        Me.TabConversacion1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabConversacion2.ResumeLayout(False)
        Me.TabConversacion2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabConversacion2 As System.Windows.Forms.TabPage
    Friend WithEvents TabConversacion1 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox4 As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents barraEstado As System.Windows.Forms.Label
    Friend WithEvents barraEstado2 As System.Windows.Forms.Label
    Friend WithEvents barraEstado3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelContacto As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
