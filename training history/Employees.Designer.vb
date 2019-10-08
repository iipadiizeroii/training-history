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
        Me.add_data = New System.Windows.Forms.Button()
        Me.edit_data = New System.Windows.Forms.Button()
        Me.upte_data = New System.Windows.Forms.Button()
        Me.clear_data = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.E2 = New System.Windows.Forms.RadioButton()
        Me.E1 = New System.Windows.Forms.RadioButton()
        Me.Date_start = New System.Windows.Forms.DateTimePicker()
        Me.cancel_data = New System.Windows.Forms.Button()
        Me.datagrid_emp = New System.Windows.Forms.DataGridView()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.OP1 = New System.Windows.Forms.OpenFileDialog()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.datagrid_emp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_emp_id
        '
        Me.txt_emp_id.Location = New System.Drawing.Point(247, 89)
        Me.txt_emp_id.Name = "txt_emp_id"
        Me.txt_emp_id.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_id.TabIndex = 0
        '
        'txt_emp_name
        '
        Me.txt_emp_name.Location = New System.Drawing.Point(247, 116)
        Me.txt_emp_name.MaxLength = 50
        Me.txt_emp_name.Name = "txt_emp_name"
        Me.txt_emp_name.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_name.TabIndex = 0
        '
        'txt_emp_lastname
        '
        Me.txt_emp_lastname.Location = New System.Drawing.Point(247, 142)
        Me.txt_emp_lastname.MaxLength = 50
        Me.txt_emp_lastname.Name = "txt_emp_lastname"
        Me.txt_emp_lastname.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_lastname.TabIndex = 0
        '
        'txt_emp_position
        '
        Me.txt_emp_position.Location = New System.Drawing.Point(247, 199)
        Me.txt_emp_position.MaxLength = 50
        Me.txt_emp_position.Name = "txt_emp_position"
        Me.txt_emp_position.Size = New System.Drawing.Size(165, 20)
        Me.txt_emp_position.TabIndex = 0
        '
        'cmb_emp_degree
        '
        Me.cmb_emp_degree.FormattingEnabled = True
        Me.cmb_emp_degree.Items.AddRange(New Object() {"ป.4", "ป.6", "ม.3", "ม.6", "ปวช.", "ปวส.", "ปริญญาตรี", "ปริญญาโท", "ปริญญาเอก"})
        Me.cmb_emp_degree.Location = New System.Drawing.Point(247, 170)
        Me.cmb_emp_degree.Name = "cmb_emp_degree"
        Me.cmb_emp_degree.Size = New System.Drawing.Size(165, 21)
        Me.cmb_emp_degree.TabIndex = 1
        '
        'cmb_emp_level
        '
        Me.cmb_emp_level.FormattingEnabled = True
        Me.cmb_emp_level.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmb_emp_level.Location = New System.Drawing.Point(247, 225)
        Me.cmb_emp_level.Name = "cmb_emp_level"
        Me.cmb_emp_level.Size = New System.Drawing.Size(165, 21)
        Me.cmb_emp_level.TabIndex = 1
        '
        'cmb_emp_department
        '
        Me.cmb_emp_department.FormattingEnabled = True
        Me.cmb_emp_department.Location = New System.Drawing.Point(548, 194)
        Me.cmb_emp_department.Name = "cmb_emp_department"
        Me.cmb_emp_department.Size = New System.Drawing.Size(189, 21)
        Me.cmb_emp_department.TabIndex = 1
        '
        'txt_emp_division
        '
        Me.txt_emp_division.Location = New System.Drawing.Point(548, 226)
        Me.txt_emp_division.MaxLength = 30
        Me.txt_emp_division.Name = "txt_emp_division"
        Me.txt_emp_division.Size = New System.Drawing.Size(189, 20)
        Me.txt_emp_division.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(158, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "รหัสพนักงาน"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ขื่อ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(186, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "นามสกุล"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(183, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ตำแหน่ง"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(166, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "วุติการศึกษา"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(199, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "ระดับ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(500, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "แผนก"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(512, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 18)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "ฝ่าย"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(281, 261)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 24)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "วันที่เริ่มงาน"
        '
        'add_data
        '
        Me.add_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_data.Location = New System.Drawing.Point(247, 301)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(107, 37)
        Me.add_data.TabIndex = 4
        Me.add_data.Text = "เพิ่ม"
        Me.add_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.edit_data.Location = New System.Drawing.Point(360, 301)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(107, 37)
        Me.edit_data.TabIndex = 4
        Me.edit_data.Text = "แก้ไข"
        Me.edit_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.upte_data.Location = New System.Drawing.Point(473, 301)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(107, 37)
        Me.upte_data.TabIndex = 4
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'clear_data
        '
        Me.clear_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clear_data.Location = New System.Drawing.Point(609, 301)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(107, 37)
        Me.clear_data.TabIndex = 4
        Me.clear_data.Text = "ลบ"
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.E2)
        Me.GroupBox1.Controls.Add(Me.E1)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 348)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ข้อมูลพนักงาน"
        '
        'E2
        '
        Me.E2.AutoSize = True
        Me.E2.Location = New System.Drawing.Point(247, 50)
        Me.E2.Name = "E2"
        Me.E2.Size = New System.Drawing.Size(98, 17)
        Me.E2.TabIndex = 91
        Me.E2.TabStop = True
        Me.E2.Text = "พนักงานรายวัน"
        Me.E2.UseVisualStyleBackColor = True
        '
        'E1
        '
        Me.E1.AutoSize = True
        Me.E1.Location = New System.Drawing.Point(247, 23)
        Me.E1.Name = "E1"
        Me.E1.Size = New System.Drawing.Size(110, 17)
        Me.E1.TabIndex = 90
        Me.E1.TabStop = True
        Me.E1.Text = "พนักงานรายเดือน"
        Me.E1.UseVisualStyleBackColor = True
        '
        'Date_start
        '
        Me.Date_start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_start.Location = New System.Drawing.Point(383, 265)
        Me.Date_start.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Date_start.Name = "Date_start"
        Me.Date_start.Size = New System.Drawing.Size(197, 20)
        Me.Date_start.TabIndex = 89
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cancel_data.Location = New System.Drawing.Point(722, 300)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(82, 38)
        Me.cancel_data.TabIndex = 4
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'datagrid_emp
        '
        Me.datagrid_emp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_emp.Location = New System.Drawing.Point(12, 443)
        Me.datagrid_emp.Name = "datagrid_emp"
        Me.datagrid_emp.Size = New System.Drawing.Size(956, 293)
        Me.datagrid_emp.TabIndex = 6
        '
        'txt_Search
        '
        Me.txt_Search.Location = New System.Drawing.Point(97, 35)
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
        Me.R1.Location = New System.Drawing.Point(6, 15)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(91, 17)
        Me.R1.TabIndex = 7
        Me.R1.TabStop = True
        Me.R1.Text = "ค้นหาด้วยรหัส"
        Me.R1.UseVisualStyleBackColor = True
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Location = New System.Drawing.Point(6, 38)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(85, 17)
        Me.R2.TabIndex = 8
        Me.R2.TabStop = True
        Me.R2.Text = "ค้นหาด้วยชื่อ"
        Me.R2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Controls.Add(Me.txt_Search)
        Me.GroupBox2.Location = New System.Drawing.Point(672, 375)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 62)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ค้นหา"
        '
        'Employees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 709)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.datagrid_emp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Employees"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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

End Class
