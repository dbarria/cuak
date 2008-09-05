<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.txtPuerto = New System.Windows.Forms.TextBox
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.btnConectar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AgregarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AgregarUsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(12, 30)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(15, 20)
        Me.txtPuerto.TabIndex = 17
        Me.txtPuerto.Visible = False
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(12, 4)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(15, 20)
        Me.txtIP.TabIndex = 16
        Me.txtIP.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Usuario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.txtClave)
        Me.GroupBox1.Controls.Add(Me.btnConectar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 248)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MSN SD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "V. 20"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(68, 66)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 28
        Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(68, 127)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 29
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnConectar
        '
        Me.btnConectar.Location = New System.Drawing.Point(82, 168)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(75, 23)
        Me.btnConectar.TabIndex = 27
        Me.btnConectar.Text = "conectar"
        Me.btnConectar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Clave"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUsuarioToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(342, 24)
        Me.MenuStrip1.TabIndex = 25
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AgregarUsuarioToolStripMenuItem
        '
        Me.AgregarUsuarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUsuarioToolStripMenuItem1})
        Me.AgregarUsuarioToolStripMenuItem.Name = "AgregarUsuarioToolStripMenuItem"
        Me.AgregarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.AgregarUsuarioToolStripMenuItem.Text = "Menú"
        '
        'AgregarUsuarioToolStripMenuItem1
        '
        Me.AgregarUsuarioToolStripMenuItem1.Name = "AgregarUsuarioToolStripMenuItem1"
        Me.AgregarUsuarioToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.AgregarUsuarioToolStripMenuItem1.Text = "Agregar Usuario"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 316)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " MSN-SD"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AgregarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarUsuarioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents btnConectar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
