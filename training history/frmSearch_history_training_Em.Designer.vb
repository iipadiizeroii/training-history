<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch_history_training_Em
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgv_history_em = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.PN_dgv_em = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Search_depart_panal = New System.Windows.Forms.TextBox()
        Me.txt_Search_name_panal = New System.Windows.Forms.TextBox()
        Me.txt_Search_id_panal = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Print_Pr = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Search_depart = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Search_name = New System.Windows.Forms.TextBox()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.dgv_history_em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PN_dgv_em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 26)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "รหัสพนักงาน"
        '
        'txt_Search
        '
        Me.txt_Search.Location = New System.Drawing.Point(81, 20)
        Me.txt_Search.MaxLength = 8
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(179, 20)
        Me.txt_Search.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(266, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(84, 37)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "ค้นหา"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgv_history_em
        '
        Me.dgv_history_em.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_history_em.Location = New System.Drawing.Point(25, 141)
        Me.dgv_history_em.Name = "dgv_history_em"
        Me.dgv_history_em.Size = New System.Drawing.Size(648, 269)
        Me.dgv_history_em.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.PN_dgv_em)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_Search_depart_panal)
        Me.Panel1.Controls.Add(Me.txt_Search_name_panal)
        Me.Panel1.Controls.Add(Me.txt_Search_id_panal)
        Me.Panel1.Location = New System.Drawing.Point(57, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(589, 293)
        Me.Panel1.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = Global.training_history.My.Resources.Resources.icons8_shutdown_32
        Me.Button6.Location = New System.Drawing.Point(544, 1)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(38, 39)
        Me.Button6.TabIndex = 98
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PN_dgv_em
        '
        Me.PN_dgv_em.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PN_dgv_em.Location = New System.Drawing.Point(13, 117)
        Me.PN_dgv_em.Name = "PN_dgv_em"
        Me.PN_dgv_em.Size = New System.Drawing.Size(564, 164)
        Me.PN_dgv_em.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.training_history.My.Resources.Resources.icons8_search_32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(346, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 37)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "ค้นหา"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(117, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 26)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "แผนก"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "ชื่อพนักงาน"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 26)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "รหัสพนักงาน"
        '
        'txt_Search_depart_panal
        '
        Me.txt_Search_depart_panal.Location = New System.Drawing.Point(164, 80)
        Me.txt_Search_depart_panal.MaxLength = 30
        Me.txt_Search_depart_panal.Name = "txt_Search_depart_panal"
        Me.txt_Search_depart_panal.Size = New System.Drawing.Size(176, 20)
        Me.txt_Search_depart_panal.TabIndex = 0
        '
        'txt_Search_name_panal
        '
        Me.txt_Search_name_panal.Location = New System.Drawing.Point(164, 54)
        Me.txt_Search_name_panal.MaxLength = 50
        Me.txt_Search_name_panal.Name = "txt_Search_name_panal"
        Me.txt_Search_name_panal.Size = New System.Drawing.Size(176, 20)
        Me.txt_Search_name_panal.TabIndex = 0
        '
        'txt_Search_id_panal
        '
        Me.txt_Search_id_panal.BackColor = System.Drawing.Color.White
        Me.txt_Search_id_panal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Search_id_panal.Location = New System.Drawing.Point(164, 28)
        Me.txt_Search_id_panal.MaxLength = 8
        Me.txt_Search_id_panal.Name = "txt_Search_id_panal"
        Me.txt_Search_id_panal.Size = New System.Drawing.Size(176, 20)
        Me.txt_Search_id_panal.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(31, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Print_Pr)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_Search_depart)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_Search_name)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txt_Search)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(176, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 114)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Print_Pr
        '
        Me.Print_Pr.Font = New System.Drawing.Font("TH SarabunPSK", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Print_Pr.Location = New System.Drawing.Point(377, 65)
        Me.Print_Pr.Name = "Print_Pr"
        Me.Print_Pr.Size = New System.Drawing.Size(84, 37)
        Me.Print_Pr.TabIndex = 15
        Me.Print_Pr.Text = "พิมพ์"
        Me.Print_Pr.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 26)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "แผนก"
        '
        'txt_Search_depart
        '
        Me.txt_Search_depart.Enabled = False
        Me.txt_Search_depart.Location = New System.Drawing.Point(81, 78)
        Me.txt_Search_depart.Name = "txt_Search_depart"
        Me.txt_Search_depart.Size = New System.Drawing.Size(179, 20)
        Me.txt_Search_depart.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 26)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "ชื่อพนักงาน"
        '
        'txt_Search_name
        '
        Me.txt_Search_name.Enabled = False
        Me.txt_Search_name.Location = New System.Drawing.Point(81, 49)
        Me.txt_Search_name.Name = "txt_Search_name"
        Me.txt_Search_name.Size = New System.Drawing.Size(179, 20)
        Me.txt_Search_name.TabIndex = 11
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.R2.Location = New System.Drawing.Point(6, 60)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(102, 30)
        Me.R2.TabIndex = 12
        Me.R2.TabStop = True
        Me.R2.Text = "อบรมภายนอก"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Checked = True
        Me.R1.Font = New System.Drawing.Font("TH SarabunPSK", 14.25!)
        Me.R1.Location = New System.Drawing.Point(6, 24)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(93, 30)
        Me.R1.TabIndex = 13
        Me.R1.TabStop = True
        Me.R1.Text = "อบรมภายใน"
        Me.R1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Font = New System.Drawing.Font("TH SarabunPSK", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(61, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(109, 96)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ประเภทการอบรม"
        '
        'frmSearch_history_training_Em
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 414)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv_history_em)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(716, 453)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(716, 453)
        Me.Name = "frmSearch_history_training_Em"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSearch_history_training_Em"
        CType(Me.dgv_history_em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PN_dgv_em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dgv_history_em As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_Search_id_panal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Search_depart_panal As System.Windows.Forms.TextBox
    Friend WithEvents txt_Search_name_panal As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PN_dgv_em As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Search_name As System.Windows.Forms.TextBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Search_depart As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Print_Pr As System.Windows.Forms.Button
End Class
