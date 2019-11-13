<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch_not_history_training_Em
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Search_course_id = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.dgv_not_history_em = New System.Windows.Forms.DataGridView()
        Me.cmb_course_name = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmb_department_name = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_not_history_em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmb_department_name)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmb_course_name)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txt_Search_course_id)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(193, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 114)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 26)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "ชื่อหลักสูตร"
        '
        'txt_Search_course_id
        '
        Me.txt_Search_course_id.Location = New System.Drawing.Point(81, 20)
        Me.txt_Search_course_id.Name = "txt_Search_course_id"
        Me.txt_Search_course_id.Size = New System.Drawing.Size(179, 20)
        Me.txt_Search_course_id.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "รหัสหลักสูตร"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(279, 59)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 37)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "ค้นหา"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(42, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 96)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "รูปแบบการหาข้อมูล"
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.R2.Location = New System.Drawing.Point(6, 60)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(136, 30)
        Me.R2.TabIndex = 12
        Me.R2.TabStop = True
        Me.R2.Text = "พนักงานที่ยังไม่อบรม"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Checked = True
        Me.R1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.R1.Location = New System.Drawing.Point(6, 24)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(130, 30)
        Me.R1.TabIndex = 13
        Me.R1.TabStop = True
        Me.R1.Text = "พนักงานที่อบรมแล้ว"
        Me.R1.UseVisualStyleBackColor = True
        '
        'dgv_not_history_em
        '
        Me.dgv_not_history_em.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_not_history_em.Location = New System.Drawing.Point(12, 141)
        Me.dgv_not_history_em.Name = "dgv_not_history_em"
        Me.dgv_not_history_em.Size = New System.Drawing.Size(648, 307)
        Me.dgv_not_history_em.TabIndex = 16
        '
        'cmb_course_name
        '
        Me.cmb_course_name.FormattingEnabled = True
        Me.cmb_course_name.Location = New System.Drawing.Point(81, 47)
        Me.cmb_course_name.Name = "cmb_course_name"
        Me.cmb_course_name.Size = New System.Drawing.Size(179, 21)
        Me.cmb_course_name.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 26)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "แผนก"
        '
        'cmb_department_name
        '
        Me.cmb_department_name.FormattingEnabled = True
        Me.cmb_department_name.Location = New System.Drawing.Point(81, 75)
        Me.cmb_department_name.Name = "cmb_department_name"
        Me.cmb_department_name.Size = New System.Drawing.Size(179, 21)
        Me.cmb_department_name.TabIndex = 16
        '
        'frmSearch_not_history_training_Em
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 454)
        Me.Controls.Add(Me.dgv_not_history_em)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSearch_not_history_training_Em"
        Me.Text = "frmSearch_not_history_training_Em"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_not_history_em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txt_Search_course_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents dgv_not_history_em As System.Windows.Forms.DataGridView
    Friend WithEvents cmb_course_name As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_department_name As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
