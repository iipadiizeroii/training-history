Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class HOMERPOGRAM

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HOMERPOGRAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Panel1.AutoScroll = True


    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Dim f As New Create_Expert()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()


        Create_Expert.MdiParent = Me
        Create_Expert.StartPosition = FormStartPosition.Manual
        Create_Expert.Left = 380
        Create_Expert.Top = 50
        Create_Expert.Show()



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

        Dim f As New Employees()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 220 : f.Top = 50 : f.Show()

        'Employees.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim f As New Create_training()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 380 : f.Top = 50 : f.Show()

        'Create_training.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Dim f As New Internal_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()

        Internal_training.MdiParent = Me
        Internal_training.StartPosition = FormStartPosition.Manual
        Internal_training.Left = 215
        Internal_training.Top = 50
        Internal_training.Show()

        'Internal_training.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        'Dim f As New External_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()

        External_training.MdiParent = Me
        External_training.StartPosition = FormStartPosition.Manual
        External_training.Left = 215
        External_training.Top = 50
        External_training.Show()


        'External_training.Show()

    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        Dim f As New frmSearch_history_training_Em()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 370 : f.Top = 50 : f.Show()



        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()



        'Dim f As New frmSearch_not_history_training_Em()
        ''f.MdiParent = GroupBox2.Container
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 547 : f.Top = 240 : f.Show()


    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim f As New frmSearch_not_history_training_Em()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 370 : f.Top = 50 : f.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        all_report.MdiParent = Me
        all_report.StartPosition = FormStartPosition.Manual
        all_report.Left = 550
        all_report.Top = 50
        all_report.Show()


        'Dim rpt As New ReportDocument()
        'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_Employees.rpt")
        'test_Print.CrystalReportViewer1.ReportSource = rpt

        'test_Print.Show()


    End Sub
End Class