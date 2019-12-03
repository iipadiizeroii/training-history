<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Create_training
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.clear_data = New System.Windows.Forms.Button()
        Me.cancel_data = New System.Windows.Forms.Button()
        Me.upte_data = New System.Windows.Forms.Button()
        Me.edit_data = New System.Windows.Forms.Button()
        Me.add_data = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_group_id = New System.Windows.Forms.TextBox()
        Me.txt_type_id = New System.Windows.Forms.TextBox()
        Me.txt_format_id = New System.Windows.Forms.TextBox()
        Me.cmb_group_name = New System.Windows.Forms.ComboBox()
        Me.cmb_type_name = New System.Windows.Forms.ComboBox()
        Me.cmb_format_name = New System.Windows.Forms.ComboBox()
        Me.txt_course_name = New System.Windows.Forms.TextBox()
        Me.txt_course_id = New System.Windows.Forms.TextBox()
        Me.datagrid_course = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.OP1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.datagrid_course, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.clear_data)
        Me.GroupBox1.Controls.Add(Me.cancel_data)
        Me.GroupBox1.Controls.Add(Me.upte_data)
        Me.GroupBox1.Controls.Add(Me.edit_data)
        Me.GroupBox1.Controls.Add(Me.add_data)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmb_group_name)
        Me.GroupBox1.Controls.Add(Me.cmb_type_name)
        Me.GroupBox1.Controls.Add(Me.cmb_format_name)
        Me.GroupBox1.Controls.Add(Me.txt_course_name)
        Me.GroupBox1.Controls.Add(Me.txt_course_id)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 258)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "หลักสูตรการอบรม"
        '
        'clear_data
        '
        Me.clear_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clear_data.Image = Global.training_history.My.Resources.Resources.icons8_recycle_bin_32
        Me.clear_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clear_data.Location = New System.Drawing.Point(411, 212)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(78, 37)
        Me.clear_data.TabIndex = 10
        Me.clear_data.Text = "ลบ"
        Me.clear_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cancel_data.Image = Global.training_history.My.Resources.Resources.icons8_cancel_32
        Me.cancel_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel_data.Location = New System.Drawing.Point(495, 211)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(91, 38)
        Me.cancel_data.TabIndex = 11
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.upte_data.Image = Global.training_history.My.Resources.Resources.icons8_add_database_32
        Me.upte_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.upte_data.Location = New System.Drawing.Point(280, 212)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(95, 37)
        Me.upte_data.TabIndex = 9
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.edit_data.Image = Global.training_history.My.Resources.Resources.icons8_edit_32
        Me.edit_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit_data.Location = New System.Drawing.Point(189, 212)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(85, 37)
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
        Me.add_data.Location = New System.Drawing.Point(98, 212)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(85, 37)
        Me.add_data.TabIndex = 7
        Me.add_data.Text = "เพิ่ม"
        Me.add_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.add_data.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label8.Location = New System.Drawing.Point(119, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 26)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "ชื่อกลุ่มหลักสูตร"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(22, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "รหัสกลุ่มหลักสูตร"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label7.Location = New System.Drawing.Point(99, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 26)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "ชื่อประเภทจัดอบรม"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(2, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 26)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "รหัสประเภทจัดอบรม"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label6.Location = New System.Drawing.Point(103, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 26)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "ชื่อรูปแบบจัดอบรม"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "รหัสรูปแบบจัดอบรม"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(141, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ชื่อหลักสูตร"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(134, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "รหัสหลักสูตร"
        '
        'txt_group_id
        '
        Me.txt_group_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_group_id.Location = New System.Drawing.Point(125, 84)
        Me.txt_group_id.Name = "txt_group_id"
        Me.txt_group_id.Size = New System.Drawing.Size(100, 20)
        Me.txt_group_id.TabIndex = 6
        '
        'txt_type_id
        '
        Me.txt_type_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_type_id.Location = New System.Drawing.Point(125, 54)
        Me.txt_type_id.Name = "txt_type_id"
        Me.txt_type_id.Size = New System.Drawing.Size(100, 20)
        Me.txt_type_id.TabIndex = 5
        '
        'txt_format_id
        '
        Me.txt_format_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_format_id.Location = New System.Drawing.Point(125, 24)
        Me.txt_format_id.Name = "txt_format_id"
        Me.txt_format_id.Size = New System.Drawing.Size(100, 20)
        Me.txt_format_id.TabIndex = 4
        '
        'cmb_group_name
        '
        Me.cmb_group_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_group_name.FormattingEnabled = True
        Me.cmb_group_name.Location = New System.Drawing.Point(215, 168)
        Me.cmb_group_name.Name = "cmb_group_name"
        Me.cmb_group_name.Size = New System.Drawing.Size(121, 21)
        Me.cmb_group_name.TabIndex = 3
        '
        'cmb_type_name
        '
        Me.cmb_type_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_type_name.FormattingEnabled = True
        Me.cmb_type_name.Location = New System.Drawing.Point(215, 137)
        Me.cmb_type_name.Name = "cmb_type_name"
        Me.cmb_type_name.Size = New System.Drawing.Size(121, 21)
        Me.cmb_type_name.TabIndex = 2
        '
        'cmb_format_name
        '
        Me.cmb_format_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_format_name.FormattingEnabled = True
        Me.cmb_format_name.Location = New System.Drawing.Point(215, 106)
        Me.cmb_format_name.Name = "cmb_format_name"
        Me.cmb_format_name.Size = New System.Drawing.Size(121, 21)
        Me.cmb_format_name.TabIndex = 1
        '
        'txt_course_name
        '
        Me.txt_course_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_course_name.Location = New System.Drawing.Point(215, 76)
        Me.txt_course_name.MaxLength = 50
        Me.txt_course_name.Name = "txt_course_name"
        Me.txt_course_name.Size = New System.Drawing.Size(121, 20)
        Me.txt_course_name.TabIndex = 0
        '
        'txt_course_id
        '
        Me.txt_course_id.Enabled = False
        Me.txt_course_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_course_id.Location = New System.Drawing.Point(215, 46)
        Me.txt_course_id.Name = "txt_course_id"
        Me.txt_course_id.Size = New System.Drawing.Size(121, 20)
        Me.txt_course_id.TabIndex = 0
        '
        'datagrid_course
        '
        Me.datagrid_course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_course.Location = New System.Drawing.Point(12, 358)
        Me.datagrid_course.Name = "datagrid_course"
        Me.datagrid_course.Size = New System.Drawing.Size(604, 263)
        Me.datagrid_course.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Controls.Add(Me.txt_Search)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(292, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 78)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ค้นหา"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(218, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "ค้นหา"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.R2.Location = New System.Drawing.Point(112, 19)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(93, 30)
        Me.R2.TabIndex = 2
        Me.R2.TabStop = True
        Me.R2.Text = "ค้นหาด้วยชื่อ"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Checked = True
        Me.R1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.R1.Location = New System.Drawing.Point(6, 19)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(100, 30)
        Me.R1.TabIndex = 1
        Me.R1.TabStop = True
        Me.R1.Text = "ค้นหาด้วยรหัส"
        Me.R1.UseVisualStyleBackColor = True
        '
        'txt_Search
        '
        Me.txt_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_Search.Location = New System.Drawing.Point(6, 50)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(199, 20)
        Me.txt_Search.TabIndex = 0
        '
        'OP1
        '
        Me.OP1.FileName = "OpenFileDialog1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txt_group_id)
        Me.GroupBox3.Controls.Add(Me.txt_type_id)
        Me.GroupBox3.Controls.Add(Me.txt_format_id)
        Me.GroupBox3.Location = New System.Drawing.Point(342, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(256, 123)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "รหัส"
        '
        'Create_training
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 632)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.datagrid_course)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(644, 671)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(644, 671)
        Me.Name = "Create_training"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create_training"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.datagrid_course, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_group_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_type_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_format_id As System.Windows.Forms.TextBox
    Friend WithEvents cmb_group_name As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_type_name As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_format_name As System.Windows.Forms.ComboBox
    Friend WithEvents txt_course_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_course_id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents clear_data As System.Windows.Forms.Button
    Friend WithEvents cancel_data As System.Windows.Forms.Button
    Friend WithEvents upte_data As System.Windows.Forms.Button
    Friend WithEvents edit_data As System.Windows.Forms.Button
    Friend WithEvents add_data As System.Windows.Forms.Button
    Friend WithEvents datagrid_course As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents OP1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
