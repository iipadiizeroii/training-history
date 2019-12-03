Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class HOMERPOGRAM

    Private Sub frm_Employees()

        With Employees
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 220
            .Top = 0
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Create_Expert()

        With Create_Expert
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 380
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Create_training()

        With Create_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 380
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Internal_training()

        With Internal_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_External_training()

        With External_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_frmSearch_history_training_Em()

        With frmSearch_history_training_Em
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 370
            .Top = 50
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_frmSearch_not_history_training_Em()

        With frmSearch_not_history_training_Em
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 370
            .Top = 50
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_all_report()

        With all_report
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 550
            .Top = 50
            .Show()
            .Activate()
        End With
        
    End Sub

    Private Sub HOMERPOGRAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Panel1.AutoScroll = True

        Login_Form.MdiParent = Me
        Login_Form.StartPosition = FormStartPosition.Manual
        Login_Form.Left = 447
        Login_Form.Top = 187
        Login_Form.Show()

        'Button1.Visible = False
        'Button2.Visible = False
        'Button3.Visible = False
        'Button4.Visible = False
        'Button5.Visible = False
        'Button6.Visible = False
        'Button7.Visible = False
        'Button8.Visible = False
        'Button9.Visible = False
        GroupBox1.Visible = False
        MenuStrip1.Visible = False
        StatusStrip1.Visible = False

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frm_Create_Expert()
        'With Create_Expert

        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()

        'End With
        '-------------------------------------------------------------------

        'Dim f As New Create_Expert()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------
        'Create_Expert.MdiParent = Me
        'Create_Expert.StartPosition = FormStartPosition.Manual
        'Create_Expert.Left = 380
        'Create_Expert.Top = 10
        'Create_Expert.Show()
        'Create_Expert.Activate()



        'Create_Expert.Show()


        ''เปิดฟอร์มโดยใช้ tap เป็นตัววางฟอร์ม
        'Create_Expert.TopLevel = False
        'Me.TabPage1.Controls.Add(Create_Expert)
        'Create_Expert.Show()


        'เปิดฟอร์มใหม่โด้ยการใช้ พาเนลเป็นตัววางฟอร์ม
        'Create_Expert.TopLevel = False
        'Me.Panel1.Controls.Add(Create_Expert)
        'Create_Expert.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frm_Employees()
        'With Employees
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 220
        '    .Top = 0
        '    .Show()
        '    .Activate()
        'End With

        '-------------------------------------------------------------------

        'Dim f As New Employees()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()
        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 220 : f.Top = 0
        '    f.Show()
        'End If

        '-------------------------------------------------------------------

        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 220 : f.Top = 0 : f.Show()



        'Employees.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        frm_Create_training()
        'With Create_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New Create_training()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()
        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 380 : f.Top = 50 : f.Show()
        'End If
        '-------------------------------------------------------------------

        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()


        'Create_training.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        frm_Internal_training()
        'With Internal_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Internal_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()
        '-------------------------------------------------------------------
        'Internal_training.MdiParent = Me
        'Internal_training.StartPosition = FormStartPosition.Manual
        'Internal_training.Left = 215
        'Internal_training.Top = 10
        'Internal_training.Show()
        'Internal_training.Activate()


        'Internal_training.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        frm_External_training()
        'With External_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New External_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()
        '-------------------------------------------------------------------

        'External_training.MdiParent = Me
        'External_training.StartPosition = FormStartPosition.Manual
        'External_training.Left = 215
        'External_training.Top = 10
        'External_training.Show()
        'External_training.Activate()

        'External_training.Show()

    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        frm_frmSearch_history_training_Em()
        'With frmSearch_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'frmSearch_history_training_Em.MdiParent = Me
        'frmSearch_history_training_Em.StartPosition = FormStartPosition.Manual
        'frmSearch_history_training_Em.Left = 370
        'frmSearch_history_training_Em.Top = 50
        'frmSearch_history_training_Em.Show()
        'frmSearch_history_training_Em.Activate()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_history_training_Em()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()

        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 370 : f.Top = 50 : f.Show()
        'End If


        '-------------------------------------------------------------------
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        ''f.MdiParent = GroupBox2.Container
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 547 : f.Top = 240 : f.Show()


    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        frm_frmSearch_not_history_training_Em()
        'With frmSearch_not_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        frm_all_report()
        'all_report.MdiParent = Me
        'all_report.StartPosition = FormStartPosition.Manual
        'all_report.Left = 550
        'all_report.Top = 50
        'all_report.Show()
        'all_report.Activate()
        '-------------------------------------------------------------------

        'Dim rpt As New ReportDocument()
        'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_Employees.rpt")
        'test_Print.CrystalReportViewer1.ReportSource = rpt

        'test_Print.Show()


    End Sub

#Region "แถบเมนูด้านบนฟอร์ม"
    Private Sub บนทกขอมลพนกงานToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles บนทกขอมลพนกงานToolStripMenuItem1.Click

        frm_Employees()
        'With Employees
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 220
        '    .Top = 0
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Employees()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 220 : f.Top = 0 : f.Show()

    End Sub

    Private Sub บนทกขอมลวทยากรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกขอมลวทยากรToolStripMenuItem.Click

        frm_Create_Expert()
        'With Create_Expert

        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()

        'End With
        '-------------------------------------------------------------------
        'Create_Expert.MdiParent = Me
        'Create_Expert.StartPosition = FormStartPosition.Manual
        'Create_Expert.Left = 380
        'Create_Expert.Top = 10
        'Create_Expert.Show()

    End Sub

    Private Sub เพมหลกสตรการอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เพมหลกสตรการอบรมToolStripMenuItem.Click

        frm_Create_training()
        'With Create_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Create_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()

    End Sub

    Private Sub จดอบรมภายในToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดอบรมภายในToolStripMenuItem.Click

        frm_Internal_training()
        'With Internal_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Internal_training.MdiParent = Me
        'Internal_training.StartPosition = FormStartPosition.Manual
        'Internal_training.Left = 215
        'Internal_training.Top = 10
        'Internal_training.Show()

    End Sub

    Private Sub จดอบรมภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดอบรมภายนอกToolStripMenuItem.Click

        frm_External_training()
        'With External_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'External_training.MdiParent = Me
        'External_training.StartPosition = FormStartPosition.Manual
        'External_training.Left = 215
        'External_training.Top = 10
        'External_training.Show()


    End Sub

    Private Sub คนหาประวตการอบรมรายบคคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คนหาประวตการอบรมรายบคคลToolStripMenuItem.Click

        frm_frmSearch_history_training_Em()
        'With frmSearch_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New frmSearch_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()


    End Sub

    Private Sub คนหาประวตการอบรมตามแผนกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คนหาประวตการอบรมตามแผนกToolStripMenuItem.Click

        frm_frmSearch_not_history_training_Em()
        'With frmSearch_not_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()


    End Sub

    Private Sub รายงานรายชอพนกงานToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานรายชอพนกงานToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_Employees.rpt")
        'rpt.Load("C:\Users\Duck\Desktop\training-history\training history\RP_Employees.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานรายชอวทยากรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานรายชอวทยากรToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Expert.rpt")
        'rpt.Load("C:\Users\Duck\Desktop\training-history\training history\PR_Expert.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานหลกสตรการอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานหลกสตรการอบรมToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Training.rpt")
        'rpt.Load("C:\Users\Duck\Desktop\training-history\training history\PR_Training.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานแสดงคาใชจายอบรมภายในภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานแสดงคาใชจายอบรมภายในภายนอกToolStripMenuItem.Click


        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 300
            .Top = 35
            .Show()
            .Activate()
        End With


        'RP_Expenses_in_out.MdiParent = Me
        'RP_Expenses_in_out.StartPosition = FormStartPosition.Manual
        'RP_Expenses_in_out.Left = 300
        'RP_Expenses_in_out.Top = 35
        'RP_Expenses_in_out.Show()


    End Sub

    Private Sub เอกสารลงชอพนกงานเขาอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เอกสารลงชอพนกงานเขาอบรมToolStripMenuItem.Click

        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 200
            .Top = 35
            .Show()
            .Activate()
        End With


        'RP_Register.MdiParent = Me
        'RP_Register.StartPosition = FormStartPosition.Manual
        'RP_Register.Left = 200
        'RP_Register.Top = 35
        'RP_Register.Show()


    End Sub

    Private Sub เอกสารอนมตการอบรมภายในภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เอกสารอนมตการอบรมภายในภายนอกToolStripMenuItem.Click


        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 220
            .Top = 35
            .Show()
            .Activate()
        End With


        'PR_PO_ALL.MdiParent = Me
        'PR_PO_ALL.StartPosition = FormStartPosition.Manual
        'PR_PO_ALL.Left = 220
        'PR_PO_ALL.Top = 35
        'PR_PO_ALL.Show()


    End Sub

    Private Sub บนทกขอมลUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกขอมลUserToolStripMenuItem.Click

        With new_admin
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

        'new_admin.MdiParent = Me
        'new_admin.StartPosition = FormStartPosition.Manual
        'new_admin.Left = 215
        'new_admin.Top = 10
        'new_admin.Show()

    End Sub

#End Region

    
End Class