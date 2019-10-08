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
        Me.GroupBox1.SuspendLayout()
        CType(Me.datagrid_exp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.R3)
        Me.GroupBox1.Controls.Add(Me.txt_expert_expertise)
        Me.GroupBox1.Controls.Add(Me.txt_exp_department)
        Me.GroupBox1.Controls.Add(Me.txt_exp_position)
        Me.GroupBox1.Controls.Add(Me.Search_emp)
        Me.GroupBox1.Controls.Add(Me.txt_exp_lastname)
        Me.GroupBox1.Controls.Add(Me.R4)
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1165, 369)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "วิทยากร"
        '
        'R3
        '
        Me.R3.AutoSize = True
        Me.R3.Location = New System.Drawing.Point(197, 42)
        Me.R3.Margin = New System.Windows.Forms.Padding(4)
        Me.R3.Name = "R3"
        Me.R3.Size = New System.Drawing.Size(117, 21)
        Me.R3.TabIndex = 16
        Me.R3.TabStop = True
        Me.R3.Text = "วิทยากรภายนอก"
        Me.R3.UseVisualStyleBackColor = True
        '
        'txt_expert_expertise
        '
        Me.txt_expert_expertise.Location = New System.Drawing.Point(224, 250)
        Me.txt_expert_expertise.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_expert_expertise.MaxLength = 100
        Me.txt_expert_expertise.Name = "txt_expert_expertise"
        Me.txt_expert_expertise.Size = New System.Drawing.Size(228, 22)
        Me.txt_expert_expertise.TabIndex = 15
        '
        'txt_exp_department
        '
        Me.txt_exp_department.Location = New System.Drawing.Point(224, 215)
        Me.txt_exp_department.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_exp_department.MaxLength = 100
        Me.txt_exp_department.Name = "txt_exp_department"
        Me.txt_exp_department.Size = New System.Drawing.Size(228, 22)
        Me.txt_exp_department.TabIndex = 15
        '
        'txt_exp_position
        '
        Me.txt_exp_position.Location = New System.Drawing.Point(224, 183)
        Me.txt_exp_position.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_exp_position.MaxLength = 100
        Me.txt_exp_position.Name = "txt_exp_position"
        Me.txt_exp_position.Size = New System.Drawing.Size(228, 22)
        Me.txt_exp_position.TabIndex = 15
        '
        'Search_emp
        '
        Me.Search_emp.Enabled = False
        Me.Search_emp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Search_emp.Location = New System.Drawing.Point(379, 84)
        Me.Search_emp.Margin = New System.Windows.Forms.Padding(4)
        Me.Search_emp.Name = "Search_emp"
        Me.Search_emp.Size = New System.Drawing.Size(52, 28)
        Me.Search_emp.TabIndex = 11
        Me.Search_emp.Text = "..."
        Me.Search_emp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Search_emp.UseVisualStyleBackColor = True
        '
        'txt_exp_lastname
        '
        Me.txt_exp_lastname.Location = New System.Drawing.Point(224, 151)
        Me.txt_exp_lastname.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_exp_lastname.MaxLength = 50
        Me.txt_exp_lastname.Name = "txt_exp_lastname"
        Me.txt_exp_lastname.Size = New System.Drawing.Size(132, 22)
        Me.txt_exp_lastname.TabIndex = 15
        '
        'R4
        '
        Me.R4.AutoSize = True
        Me.R4.Location = New System.Drawing.Point(379, 42)
        Me.R4.Margin = New System.Windows.Forms.Padding(4)
        Me.R4.Name = "R4"
        Me.R4.Size = New System.Drawing.Size(108, 21)
        Me.R4.TabIndex = 0
        Me.R4.Text = "วิทยากรภายใน"
        Me.R4.UseVisualStyleBackColor = True
        '
        'txt_exp_name
        '
        Me.txt_exp_name.Location = New System.Drawing.Point(224, 117)
        Me.txt_exp_name.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_exp_name.MaxLength = 50
        Me.txt_exp_name.Name = "txt_exp_name"
        Me.txt_exp_name.Size = New System.Drawing.Size(132, 22)
        Me.txt_exp_name.TabIndex = 15
        '
        'txt_exp_id
        '
        Me.txt_exp_id.Enabled = False
        Me.txt_exp_id.Location = New System.Drawing.Point(225, 85)
        Me.txt_exp_id.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_exp_id.Name = "txt_exp_id"
        Me.txt_exp_id.Size = New System.Drawing.Size(132, 22)
        Me.txt_exp_id.TabIndex = 15
        '
        'clear_data
        '
        Me.clear_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.clear_data.Location = New System.Drawing.Point(643, 316)
        Me.clear_data.Margin = New System.Windows.Forms.Padding(4)
        Me.clear_data.Name = "clear_data"
        Me.clear_data.Size = New System.Drawing.Size(143, 46)
        Me.clear_data.TabIndex = 10
        Me.clear_data.Text = "ลบ"
        Me.clear_data.UseVisualStyleBackColor = True
        '
        'cancel_data
        '
        Me.cancel_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cancel_data.Location = New System.Drawing.Point(793, 315)
        Me.cancel_data.Margin = New System.Windows.Forms.Padding(4)
        Me.cancel_data.Name = "cancel_data"
        Me.cancel_data.Size = New System.Drawing.Size(109, 47)
        Me.cancel_data.TabIndex = 11
        Me.cancel_data.Text = "ยกเลิก"
        Me.cancel_data.UseVisualStyleBackColor = True
        '
        'upte_data
        '
        Me.upte_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.upte_data.Location = New System.Drawing.Point(461, 316)
        Me.upte_data.Margin = New System.Windows.Forms.Padding(4)
        Me.upte_data.Name = "upte_data"
        Me.upte_data.Size = New System.Drawing.Size(143, 46)
        Me.upte_data.TabIndex = 12
        Me.upte_data.Text = "บันทึก"
        Me.upte_data.UseVisualStyleBackColor = True
        '
        'edit_data
        '
        Me.edit_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.edit_data.Location = New System.Drawing.Point(311, 316)
        Me.edit_data.Margin = New System.Windows.Forms.Padding(4)
        Me.edit_data.Name = "edit_data"
        Me.edit_data.Size = New System.Drawing.Size(143, 46)
        Me.edit_data.TabIndex = 13
        Me.edit_data.Text = "แก้ไข"
        Me.edit_data.UseVisualStyleBackColor = True
        '
        'add_data
        '
        Me.add_data.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.add_data.Location = New System.Drawing.Point(160, 316)
        Me.add_data.Margin = New System.Windows.Forms.Padding(4)
        Me.add_data.Name = "add_data"
        Me.add_data.Size = New System.Drawing.Size(143, 46)
        Me.add_data.TabIndex = 14
        Me.add_data.Text = "เพิ่ม"
        Me.add_data.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(112, 249)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "ความชำนาญ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(71, 212)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 24)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "หน่วยงานต้นสังกัด"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 178)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 24)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "ตำแหน่งวิทยากร"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(143, 148)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 24)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "นามสกุล"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(184, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ชื่อ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(113, 84)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "รหัสวิทยากร"
        '
        'datagrid_exp
        '
        Me.datagrid_exp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_exp.Location = New System.Drawing.Point(16, 391)
        Me.datagrid_exp.Margin = New System.Windows.Forms.Padding(4)
        Me.datagrid_exp.Name = "datagrid_exp"
        Me.datagrid_exp.Size = New System.Drawing.Size(857, 303)
        Me.datagrid_exp.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_Search)
        Me.GroupBox3.Controls.Add(Me.R2)
        Me.GroupBox3.Controls.Add(Me.R1)
        Me.GroupBox3.Location = New System.Drawing.Point(881, 391)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(300, 90)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ค้นหา"
        '
        'txt_Search
        '
        Me.txt_Search.Location = New System.Drawing.Point(8, 52)
        Me.txt_Search.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(283, 22)
        Me.txt_Search.TabIndex = 15
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Location = New System.Drawing.Point(137, 18)
        Me.R2.Margin = New System.Windows.Forms.Padding(4)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(98, 21)
        Me.R2.TabIndex = 8
        Me.R2.TabStop = True
        Me.R2.Text = "ค้นหาด้วยชื่อ"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Location = New System.Drawing.Point(8, 18)
        Me.R1.Margin = New System.Windows.Forms.Padding(4)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(106, 21)
        Me.R1.TabIndex = 7
        Me.R1.TabStop = True
        Me.R1.Text = "ค้นหาด้วยรหัส"
        Me.R1.UseVisualStyleBackColor = True
        '
        'OP1
        '
        Me.OP1.FileName = "OpenFileDialog1"
        '
        'Create_Expert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 704)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.datagrid_exp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Create_Expert"
        Me.Text = "Create_Expert"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.datagrid_exp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
End Class
