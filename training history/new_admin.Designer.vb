<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class new_admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.txt_user_id = New System.Windows.Forms.TextBox()
        Me.txt_lastname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_department = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_position = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmd_status = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.clear_data = New System.Windows.Forms.Button()
        Me.cancel_data = New System.Windows.Forms.Button()
        Me.upte_data = New System.Windows.Forms.Button()
        Me.edit_data = New System.Windows.Forms.Button()
        Me.add_data = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_name
        '
        Me.txt_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_name.Location = New System.Drawing.Point(127, 113)
        Me.txt_name.MaxLength = 50
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(165, 20)
        Me.txt_name.TabIndex = 2
        '
        'txt_user_id
        '
        Me.txt_user_id.Enabled = False
        Me.txt_user_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_user_id.Location = New System.Drawing.Point(127, 35)
        Me.txt_user_id.Name = "txt_user_id"
        Me.txt_user_id.Size = New System.Drawing.Size(165, 20)
        Me.txt_user_id.TabIndex = 4
        '
        'txt_lastname
        '
        Me.txt_lastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_lastname.Location = New System.Drawing.Point(127, 139)
        Me.txt_lastname.MaxLength = 50
        Me.txt_lastname.Name = "txt_lastname"
        Me.txt_lastname.Size = New System.Drawing.Size(165, 20)
        Me.txt_lastname.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(66, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 26)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "นามสกุล"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(95, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 26)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ขื่อ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 26)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "UserID"
        '
        'cmb_department
        '
        Me.cmb_department.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_department.FormattingEnabled = True
        Me.cmb_department.Location = New System.Drawing.Point(127, 191)
        Me.cmb_department.Name = "cmb_department"
        Me.cmb_department.Size = New System.Drawing.Size(165, 21)
        Me.cmb_department.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(80, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 26)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "แผนก"
        '
        'txt_position
        '
        Me.txt_position.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_position.Location = New System.Drawing.Point(127, 165)
        Me.txt_position.MaxLength = 50
        Me.txt_position.Multiline = True
        Me.txt_position.Name = "txt_position"
        Me.txt_position.Size = New System.Drawing.Size(165, 20)
        Me.txt_position.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(67, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 26)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "ตำแหน่ง"
        '
        'cmd_status
        '
        Me.cmd_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmd_status.FormattingEnabled = True
        Me.cmd_status.Items.AddRange(New Object() {"ADMIN", "USER"})
        Me.cmd_status.Location = New System.Drawing.Point(127, 218)
        Me.cmd_status.Name = "cmd_status"
        Me.cmd_status.Size = New System.Drawing.Size(102, 21)
        Me.cmd_status.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(80, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 26)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "สถานะ"
        '
        'clear_data
        '
        Me.clear_data.Enabled = False
        Me.clear_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clear_data.Image = Global.training_history.My.Resources.Resources.icons8_recycle_bin_32
        Me.clear_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clear_data.Location = New System.Drawing.Point(427, 165)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(84, 39)
        Me.clear_data.TabIndex = 11
        Me.clear_data.Text = "ลบ"
        Me.clear_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cancel_data.Image = Global.training_history.My.Resources.Resources.icons8_cancel_32
        Me.cancel_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel_data.Location = New System.Drawing.Point(324, 166)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(97, 38)
        Me.cancel_data.TabIndex = 10
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Enabled = False
        Me.upte_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.upte_data.Image = Global.training_history.My.Resources.Resources.icons8_add_database_32
        Me.upte_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.upte_data.Location = New System.Drawing.Point(324, 122)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(97, 38)
        Me.upte_data.TabIndex = 9
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Enabled = False
        Me.edit_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.edit_data.Image = Global.training_history.My.Resources.Resources.icons8_edit_32
        Me.edit_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit_data.Location = New System.Drawing.Point(324, 78)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(97, 38)
        Me.edit_data.TabIndex = 8
        Me.edit_data.Text = "แก้ไข"
        Me.edit_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit_data.UseVisualStyleBackColor = True
        '
        'add_data
        '
        Me.add_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_data.Image = Global.training_history.My.Resources.Resources.icons8_add_32
        Me.add_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.add_data.Location = New System.Drawing.Point(324, 31)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(97, 38)
        Me.add_data.TabIndex = 7
        Me.add_data.Text = "เพื่ม"
        Me.add_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.add_data.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 260)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(499, 210)
        Me.DataGridView1.TabIndex = 12
        '
        'txt_username
        '
        Me.txt_username.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_username.Location = New System.Drawing.Point(127, 61)
        Me.txt_username.MaxLength = 20
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(165, 20)
        Me.txt_username.TabIndex = 0
        '
        'txt_password
        '
        Me.txt_password.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_password.Location = New System.Drawing.Point(127, 87)
        Me.txt_password.MaxLength = 20
        Me.txt_password.Name = "txt_password"
        Me.txt_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txt_password.Size = New System.Drawing.Size(165, 20)
        Me.txt_password.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(57, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 26)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(54, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 26)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Username"
        '
        'new_admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 480)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.clear_data)
        Me.Controls.Add(Me.cancel_data)
        Me.Controls.Add(Me.upte_data)
        Me.Controls.Add(Me.edit_data)
        Me.Controls.Add(Me.add_data)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_position)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmd_status)
        Me.Controls.Add(Me.cmb_department)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.txt_user_id)
        Me.Controls.Add(Me.txt_lastname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "new_admin"
        Me.Text = "new_admin"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_user_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_lastname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_department As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_position As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmd_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents clear_data As System.Windows.Forms.Button
    Friend WithEvents cancel_data As System.Windows.Forms.Button
    Friend WithEvents upte_data As System.Windows.Forms.Button
    Friend WithEvents edit_data As System.Windows.Forms.Button
    Friend WithEvents add_data As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_username As System.Windows.Forms.TextBox
    Friend WithEvents txt_password As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
