<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNew_expert_In
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.txt_Search = New System.Windows.Forms.TextBox()
        Me.datagrid_new_expertin = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        CType(Me.datagrid_new_expertin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.Controls.Add(Me.txt_Search)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 62)
        Me.GroupBox2.TabIndex = 97
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ค้นหา"
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
        'txt_Search
        '
        Me.txt_Search.Location = New System.Drawing.Point(97, 35)
        Me.txt_Search.Name = "txt_Search"
        Me.txt_Search.Size = New System.Drawing.Size(189, 20)
        Me.txt_Search.TabIndex = 0
        '
        'datagrid_new_expertin
        '
        Me.datagrid_new_expertin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_new_expertin.Location = New System.Drawing.Point(12, 79)
        Me.datagrid_new_expertin.Name = "datagrid_new_expertin"
        Me.datagrid_new_expertin.Size = New System.Drawing.Size(562, 150)
        Me.datagrid_new_expertin.TabIndex = 96
        '
        'frmNew_expert_In
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 261)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.datagrid_new_expertin)
        Me.Name = "frmNew_expert_In"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNew_expert_In"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.datagrid_new_expertin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents R2 As System.Windows.Forms.RadioButton
    Friend WithEvents R1 As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Search As System.Windows.Forms.TextBox
    Friend WithEvents datagrid_new_expertin As System.Windows.Forms.DataGridView
End Class
