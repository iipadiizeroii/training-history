<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Create_Expert
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
        Me.R3 = New System.Windows.Forms.RadioButton()
        Me.txt_expert_expertise = New System.Windows.Forms.TextBox()
        Me.txt_exp_department = New System.Windows.Forms.TextBox()
        Me.txt_exp_position = New System.Windows.Forms.TextBox()
        Me.Search_emp = New System.Windows.Forms.Button()
        Me.txt_exp_lastname = New System.Windows.Forms.TextBox()
        Me.R4 = New System.Windows.Forms.RadioButton()
        Me.txt_exp_name = New System.Windows.Forms.TextBox()
        Me.txt_exp_id = New System.Windows.Forms.TextBox()
        Me.clear_data = New System.Windows.Forms.Button()
        Me.cancel_data = New System.Windows.Forms.Button()
        Me.upte_data = New System.Windows.Forms.Button()
        Me.edit_data = New System.Windows.Forms.Button()
        Me.add_data = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.datagrid_exp = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.OP1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.datagrid_exp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txt_expert_expertise)
        Me.GroupBox1.Controls.Add(Me.txt_exp_department)
        Me.GroupBox1.Controls.Add(Me.txt_exp_position)
        Me.GroupBox1.Controls.Add(Me.Search_emp)
        Me.GroupBox1.Controls.Add(Me.txt_exp_lastname)
        Me.GroupBox1.Controls.Add(Me.txt_exp_name)
        Me.GroupBox1.Controls.Add(Me.txt_exp_id)
        Me.GroupBox1.Controls.Add(Me.clear_data)
        Me.GroupBox1.Controls.Add(Me.cancel_data)
        Me.GroupBox1.Controls.Add(Me.upte_data)
        Me.GroupBox1.Controls.Add(Me.edit_data)
        Me.GroupBox1.Controls.Add(Me.add_data)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 320)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "กรอกข้อมูลวิทยากร"
        '
        'R3
        '
        Me.R3.AutoSize = True
        Me.R3.Font = New System.Drawing.Font("TH SarabunPSK", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.R3.Location = New System.Drawing.Point(6, 18)
        Me.R3.Name = "R3"
        Me.R3.Size = New System.Drawing.Size(109, 27)
        Me.R3.TabIndex = 0
        Me.R3.TabStop = True
        Me.R3.Text = "วิทยากรภายนอก"
        Me.R3.UseVisualStyleBackColor = True
        '
        'txt_expert_expertise
        '
        Me.txt_expert_expertise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_expert_expertise.Location = New System.Drawing.Point(168, 237)
        Me.txt_expert_expertise.MaxLength = 100
        Me.txt_expert_expertise.Name = "txt_expert_expertise"
        Me.txt_expert_expertise.Size = New System.Drawing.Size(172, 20)
        Me.txt_expert_expertise.TabIndex = 7
        '
        'txt_exp_department
        '
        Me.txt_exp_department.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_exp_department.Location = New System.Drawing.Point(168, 209)
        Me.txt_exp_department.MaxLength = 100
        Me.txt_exp_department.Name = "txt_exp_department"
        Me.txt_exp_department.Size = New System.Drawing.Size(172, 20)
        Me.txt_exp_department.TabIndex = 6
        '
        'txt_exp_position
        '
        Me.txt_exp_position.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_exp_position.Location = New System.Drawing.Point(168, 183)
        Me.txt_exp_position.MaxLength = 100
        Me.txt_exp_position.Name = "txt_exp_position"
        Me.txt_exp_position.Size = New System.Drawing.Size(172, 20)
        Me.txt_exp_position.TabIndex = 5
        '
        'Search_emp
        '
        Me.Search_emp.Enabled = False
        Me.Search_emp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Search_emp.Location = New System.Drawing.Point(284, 102)
        Me.Search_emp.Name = "Search_emp"
        Me.Search_emp.Size = New System.Drawing.Size(33, 23)
        Me.Search_emp.TabIndex = 11
        Me.Search_emp.Text = "..."
        Me.Search_emp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Search_emp.UseVisualStyleBackColor = True
        '
        'txt_exp_lastname
        '
        Me.txt_exp_lastname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_exp_lastname.Location = New System.Drawing.Point(168, 157)
        Me.txt_exp_lastname.MaxLength = 50
        Me.txt_exp_lastname.Name = "txt_exp_lastname"
        Me.txt_exp_lastname.Size = New System.Drawing.Size(100, 20)
        Me.txt_exp_lastname.TabIndex = 4
        '
        'R4
        '
        Me.R4.AutoSize = True
        Me.R4.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.R4.Location = New System.Drawing.Point(6, 47)
        Me.R4.Name = "R4"
        Me.R4.Size = New System.Drawing.Size(92, 26)
        Me.R4.TabIndex = 1
        Me.R4.Text = "วิทยากรภายใน"
        Me.R4.UseVisualStyleBackColor = True
        '
        'txt_exp_name
        '
        Me.txt_exp_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_exp_name.Location = New System.Drawing.Point(168, 129)
        Me.txt_exp_name.MaxLength = 50
        Me.txt_exp_name.Name = "txt_exp_name"
        Me.txt_exp_name.Size = New System.Drawing.Size(100, 20)
        Me.txt_exp_name.TabIndex = 3
        '
        'txt_exp_id
        '
        Me.txt_exp_id.Enabled = False
        Me.txt_exp_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_exp_id.Location = New System.Drawing.Point(169, 103)
        Me.txt_exp_id.Name = "txt_exp_id"
        Me.txt_exp_id.Size = New System.Drawing.Size(100, 20)
        Me.txt_exp_id.TabIndex = 2
        '
        'clear_data
        '
        Me.clear_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold)
        Me.clear_data.Image = Global.training_history.My.Resources.Resources.icons8_recycle_bin_32
        Me.clear_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.clear_data.Location = New System.Drawing.Point(444, 277)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(81, 37)
        Me.clear_data.TabIndex = 11
        Me.clear_data.Text = "ลบ"
        Me.clear_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cancel_data.Image = Global.training_history.My.Resources.Resources.icons8_cancel_32
        Me.cancel_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel_data.Location = New System.Drawing.Point(531, 276)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(99, 38)
        Me.cancel_data.TabIndex = 12
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold)
        Me.upte_data.Image = Global.training_history.My.Resources.Resources.icons8_add_database_32
        Me.upte_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.upte_data.Location = New System.Drawing.Point(307, 277)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(99, 37)
        Me.upte_data.TabIndex = 10
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold)
        Me.edit_data.Image = Global.training_history.My.Resources.Resources.icons8_edit_32
        Me.edit_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.edit_data.Location = New System.Drawing.Point(211, 277)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(90, 37)
        Me.edit_data.TabIndex = 9
        Me.edit_data.Text = "แก้ไข"
        Me.edit_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.edit_data.UseVisualStyleBackColor = True
        '
        'add_data
        '
        Me.add_data.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_data.Image = Global.training_history.My.Resources.Resources.icons8_add_32
        Me.add_data.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.add_data.Location = New System.Drawing.Point(119, 277)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(86, 37)
        Me.add_data.TabIndex = 8
        Me.add_data.Text = "เพิ่ม"
        Me.add_data.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.add_data.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label6.Location = New System.Drawing.Point(86, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 26)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "ความชำนาญ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label5.Location = New System.Drawing.Point(59, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 26)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "หน่วยงานต้นสังกัด"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(68, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 26)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "ตำแหน่งวิทยากร"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(107, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 26)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "นามสกุล"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label2.Location = New System.Drawing.Point(136, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ชื่อ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(90, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "รหัสวิทยากร"
        '
        'datagrid_exp
        '
        Me.datagrid_exp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_exp.Location = New System.Drawing.Point(12, 338)
        Me.datagrid_exp.Name = "datagrid_exp"
        Me.datagrid_exp.Size = New System.Drawing.Size(643, 246)
        Me.datagrid_exp.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.txt_Search)
        Me.GroupBox3.Controls.Add(Me.R2)
        Me.GroupBox3.Controls.Add(Me.R1)
        Me.GroupBox3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(661, 338)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(225, 120)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ค้นหา"
        '
        'txt_Search
        '
        Me.txt_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt_Search.Location = New System.Drawing.Point(6, 51)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(213, 20)
        Me.txt_Search.TabIndex = 0
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Location = New System.Drawing.Point(111, 20)
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
        Me.R1.Location = New System.Drawing.Point(6, 20)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(100, 30)
        Me.R1.TabIndex = 1
        Me.R1.TabStop = True
        Me.R1.Text = "ค้นหาด้วยรหัส"
        Me.R1.UseVisualStyleBackColor = True
        '
        'OP1
        '
        Me.OP1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(131, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "ค้นหา"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R4)
        Me.GroupBox2.Controls.Add(Me.R3)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(168, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 79)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ประเภทวิทยากร"
        '
        'Create_Expert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 596)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.datagrid_exp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Create_Expert"
        Me.Text = "Create_Expert"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.datagrid_exp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents R4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents clear_data As System.Windows.Forms.Button
    Friend WithEvents cancel_data As System.Windows.Forms.Button
    Friend WithEvents upte_data As System.Windows.Forms.Button
    Friend WithEvents edit_data As System.Windows.Forms.Button
    Friend WithEvents add_data As System.Windows.Forms.Button
    Friend WithEvents Search_emp As System.Windows.Forms.Button
    Friend WithEvents datagrid_exp As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents txt_exp_department As System.Windows.Forms.TextBox
    Friend WithEvents txt_exp_position As System.Windows.Forms.TextBox
    Friend WithEvents txt_exp_lastname As System.Windows.Forms.TextBox
    Friend WithEvents txt_exp_name As System.Windows.Forms.TextBox
    Friend WithEvents txt_exp_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents OP1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txt_expert_expertise As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents R3 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
