<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Employees
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
        Me.txt_emp_id = New System.Windows.Forms.TextBox()
        Me.txt_emp_name = New System.Windows.Forms.TextBox()
        Me.txt_emp_lastname = New System.Windows.Forms.TextBox()
        Me.txt_emp_position = New System.Windows.Forms.TextBox()
        Me.cmb_emp_degree = New System.Windows.Forms.ComboBox()
        Me.cmb_emp_level = New System.Windows.Forms.ComboBox()
        Me.cmb_emp_department = New System.Windows.Forms.ComboBox()
        Me.txt_emp_division = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.E1 = New System.Windows.Forms.RadioButton()
        Me.E2 = New System.Windows.Forms.RadioButton()
        Me.Date_start = New System.Windows.Forms.DateTimePicker()
        Me.clear_data = New System.Windows.Forms.Button()
        Me.cancel_data = New System.Windows.Forms.Button()
        Me.upte_data = New System.Windows.Forms.Button()
        Me.edit_data = New System.Windows.Forms.Button()
        Me.add_data = New System.Windows.Forms.Button()
        Me.datagrid_emp = New System.Windows.Forms.DataGridView()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.OP1 = New System.Windows.Forms.OpenFileDialog()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.datagrid_emp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_emp_id
        '
        Me.txt_emp_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_emp_id.Location = New System.Drawing.Point(247, 91)
        Me.txt_emp_id.Name = "txt_emp_id"
        Me.txt_emp_id.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_id.TabIndex = 0
        '
        'txt_emp_name
        '
        Me.txt_emp_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_emp_name.Location = New System.Drawing.Point(247, 119)
        Me.txt_emp_name.MaxLength = 50
        Me.txt_emp_name.Name = "txt_emp_name"
        Me.txt_emp_name.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_name.TabIndex = 1
        '
        'txt_emp_lastname
        '
        Me.txt_emp_lastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_emp_lastname.Location = New System.Drawing.Point(247, 152)
        Me.txt_emp_lastname.MaxLength = 50
        Me.txt_emp_lastname.Name = "txt_emp_lastname"
        Me.txt_emp_lastname.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_lastname.TabIndex = 2
        '
        'txt_emp_position
        '
        Me.txt_emp_position.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_emp_position.Location = New System.Drawing.Point(247, 214)
        Me.txt_emp_position.MaxLength = 50
        Me.txt_emp_position.Multiline = True
        Me.txt_emp_position.Name = "txt_emp_position"
        Me.txt_emp_position.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_position.TabIndex = 4
        '
        'cmb_emp_degree
        '
        Me.cmb_emp_degree.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_emp_degree.FormattingEnabled = True
        Me.cmb_emp_degree.Items.AddRange(New Object() {"ป.4", "ป.6", "ม.3", "ม.6", "ปวช.", "ปวส.", "ปริญญาตรี", "ปริญญาโท", "ปริญญาเอก"})
        Me.cmb_emp_degree.Location = New System.Drawing.Point(247, 183)
        Me.cmb_emp_degree.Name = "cmb_emp_degree"
        Me.cmb_emp_degree.Size = New System.Drawing.Size(165, 21)
        Me.cmb_emp_degree.TabIndex = 3
        '
        'cmb_emp_level
        '
        Me.cmb_emp_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_emp_level.FormattingEnabled = True
        Me.cmb_emp_level.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmb_emp_level.Location = New System.Drawing.Point(247, 242)
        Me.cmb_emp_level.Name = "cmb_emp_level"
        Me.cmb_emp_level.Size = New System.Drawing.Size(42, 21)
        Me.cmb_emp_level.TabIndex = 5
        '
        'cmb_emp_department
        '
        Me.cmb_emp_department.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmb_emp_department.FormattingEnabled = True
        Me.cmb_emp_department.Location = New System.Drawing.Point(548, 205)
        Me.cmb_emp_department.Name = "cmb_emp_department"
        Me.cmb_emp_department.Size = New System.Drawing.Size(189, 21)
        Me.cmb_emp_department.TabIndex = 6
        '
        'txt_emp_division
        '
        Me.txt_emp_division.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_emp_division.Location = New System.Drawing.Point(548, 242)
        Me.txt_emp_division.MaxLength = 30
        Me.txt_emp_division.Multiline = True
        Me.txt_emp_division.Name = "txt_emp_division"
        Me.txt_emp_division.Size = New System.Drawing.Size(189, 20)
        Me.txt_emp_division.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(165, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "รหัสพนักงาน"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(215, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ขื่อ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(186, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 26)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "นามสกุล"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(187, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 26)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ตำแหน่ง"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(169, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 26)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "วุติการศึกษา"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(201, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 26)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "ระดับ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(501, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 26)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "แผนก"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(510, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 26)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "ฝ่าย"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(304, 282)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 26)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "วันที่เริ่มงาน"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Date_start)
        Me.GroupBox1.Controls.Add(Me.txt_emp_name)
        Me.GroupBox1.Controls.Add(Me.clear_data)
        Me.GroupBox1.Controls.Add(Me.cancel_data)
        Me.GroupBox1.Controls.Add(Me.txt_emp_id)
        Me.GroupBox1.Controls.Add(Me.upte_data)
        Me.GroupBox1.Controls.Add(Me.txt_emp_position)
        Me.GroupBox1.Controls.Add(Me.edit_data)
        Me.GroupBox1.Controls.Add(Me.txt_emp_division)
        Me.GroupBox1.Controls.Add(Me.add_data)
        Me.GroupBox1.Controls.Add(Me.txt_emp_lastname)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmb_emp_degree)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_emp_level)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmb_emp_department)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 371)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "กรอกข้อมูลพนักงาน"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.E1)
        Me.GroupBox3.Controls.Add(Me.E2)
        Me.GroupBox3.Location = New System.Drawing.Point(247, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 74)
        Me.GroupBox3.TabIndex = 92
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ประเภทพนักงาน"
        '
        'E1
        '
        Me.E1.AutoSize = True
        Me.E1.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.E1.Location = New System.Drawing.Point(6, 19)
        Me.E1.Name = "E1"
        Me.E1.Size = New System.Drawing.Size(105, 26)
        Me.E1.TabIndex = 90
        Me.E1.TabStop = True
        Me.E1.Text = "พนักงานรายเดือน"
        Me.E1.UseVisualStyleBackColor = True
        '
        'E2
        '
        Me.E2.AutoSize = True
        Me.E2.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.E2.Location = New System.Drawing.Point(6, 45)
        Me.E2.Name = "E2"
        Me.E2.Size = New System.Drawing.Size(95, 26)
        Me.E2.TabIndex = 91
        Me.E2.TabStop = True
        Me.E2.Text = "พนักงานรายวัน"
        Me.E2.UseVisualStyleBackColor = True
        '
        'Date_start
        '
        Me.Date_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Date_start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_start.Location = New System.Drawing.Point(374, 282)
        Me.Date_start.Margin = New System.Windows.Forms.Padding(4)
        Me.Date_start.Name = "Date_start"
        Me.Date_start.Size = New System.Drawing.Size(159, 20)
        Me.Date_start.TabIndex = 8
        '
        'clear_data
        '
        Me.clear_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clear_data.Image = Global.training_history.My.Resources.Resources.icons8_recycle_bin_32
        Me.clear_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clear_data.Location = New System.Drawing.Point(548, 326)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(84, 39)
        Me.clear_data.TabIndex = 12
        Me.clear_data.Text = "ลบ"
        Me.clear_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cancel_data.Image = Global.training_history.My.Resources.Resources.icons8_cancel_32
        Me.cancel_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel_data.Location = New System.Drawing.Point(638, 326)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(95, 38)
        Me.cancel_data.TabIndex = 13
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.upte_data.Image = Global.training_history.My.Resources.Resources.icons8_add_database_32
        Me.upte_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.upte_data.Location = New System.Drawing.Point(418, 327)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(95, 38)
        Me.upte_data.TabIndex = 11
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.edit_data.Image = Global.training_history.My.Resources.Resources.icons8_edit_32
        Me.edit_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit_data.Location = New System.Drawing.Point(323, 327)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(89, 38)
        Me.edit_data.TabIndex = 10
        Me.edit_data.Text = "แก้ไข"
        Me.edit_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit_data.UseVisualStyleBackColor = True
        '
        'add_data
        '
        Me.add_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_data.Image = Global.training_history.My.Resources.Resources.icons8_add_32
        Me.add_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.add_data.Location = New System.Drawing.Point(233, 327)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(84, 38)
        Me.add_data.TabIndex = 9
        Me.add_data.Text = "เพื่ม"
        Me.add_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.add_data.UseVisualStyleBackColor = True
        '
        'datagrid_emp
        '
        Me.datagrid_emp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_emp.Location = New System.Drawing.Point(12, 479)
        Me.datagrid_emp.Name = "datagrid_emp"
        Me.datagrid_emp.Size = New System.Drawing.Size(956, 266)
        Me.datagrid_emp.TabIndex = 6
        '
        'txt_Search
        '
        Me.txt_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_Search.Location = New System.Drawing.Point(112, 48)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(189, 20)
        Me.txt_Search.TabIndex = 0
        '
        'OP1
        '
        Me.OP1.FileName = "OpenFileDialog1"
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Location = New System.Drawing.Point(6, 23)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(100, 30)
        Me.R1.TabIndex = 2
        Me.R1.TabStop = True
        Me.R1.Text = "ค้นหาด้วยรหัส"
        Me.R1.UseVisualStyleBackColor = True
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Location = New System.Drawing.Point(6, 48)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(93, 30)
        Me.R2.TabIndex = 1
        Me.R2.TabStop = True
        Me.R2.Text = "ค้นหาด้วยชื่อ"
        Me.R2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Controls.Add(Me.txt_Search)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(560, 397)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 77)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ค้นหา"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(307, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 36)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "ค้นหา"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("TH SarabunPSK", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button7.Location = New System.Drawing.Point(0, 435)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(181, 40)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "แสดงข้อมูลพนักงาน"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 754)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.datagrid_emp)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(992, 793)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(992, 793)
        Me.Name = "Employees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.datagrid_emp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_emp_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_emp_lastname As System.Windows.Forms.TextBox
    Friend WithEvents txt_emp_position As System.Windows.Forms.TextBox
    Friend WithEvents cmb_emp_degree As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_emp_level As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_emp_department As System.Windows.Forms.ComboBox
    Friend WithEvents txt_emp_division As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents add_data As System.Windows.Forms.Button
    Friend WithEvents edit_data As System.Windows.Forms.Button
    Friend WithEvents upte_data As System.Windows.Forms.Button
    Friend WithEvents clear_data As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents datagrid_emp As System.Windows.Forms.DataGridView
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents cancel_data As System.Windows.Forms.Button
    Friend WithEvents OP1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Date_start As System.Windows.Forms.DateTimePicker
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_emp_id As System.Windows.Forms.TextBox
    Friend WithEvents E2 As System.Windows.Forms.RadioButton
    Friend WithEvents E1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button

End Class
