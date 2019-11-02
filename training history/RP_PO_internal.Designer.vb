<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RP_PO_internal
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Date_training1 = New System.Windows.Forms.DateTimePicker()
        Me.Date_training2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(486, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "พิมพ์"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "รหัสจัดอบรม"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(14, 49)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(972, 525)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Date_training1
        '
        Me.Date_training1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_training1.Location = New System.Drawing.Point(87, 13)
        Me.Date_training1.Margin = New System.Windows.Forms.Padding(4)
        Me.Date_training1.Name = "Date_training1"
        Me.Date_training1.Size = New System.Drawing.Size(165, 20)
        Me.Date_training1.TabIndex = 5
        '
        'Date_training2
        '
        Me.Date_training2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Date_training2.Location = New System.Drawing.Point(312, 13)
        Me.Date_training2.Margin = New System.Windows.Forms.Padding(4)
        Me.Date_training2.Name = "Date_training2"
        Me.Date_training2.Size = New System.Drawing.Size(165, 20)
        Me.Date_training2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ถึง"
        '
        'test_PR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 586)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_training2)
        Me.Controls.Add(Me.Date_training1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "test_PR"
        Me.Text = "test_PR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Date_training1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date_training2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
