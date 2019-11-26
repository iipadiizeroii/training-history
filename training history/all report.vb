Imports CrystalDecisions.CrystalReports.Engine
Public Class all_report

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim rpt As New ReportDocument()
        rpt.Load("C:\Users\Duck\Desktop\training-history\training history\RP_Employees.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim rpt As New ReportDocument()
        rpt.Load("C:\Users\Duck\Desktop\training-history\training history\PR_Expert.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim rpt As New ReportDocument()
        rpt.Load("C:\Users\Duck\Desktop\training-history\training history\PR_Training.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        RP_Expenses_in_out.MdiParent = HOMERPOGRAM
        RP_Expenses_in_out.StartPosition = FormStartPosition.Manual
        RP_Expenses_in_out.Left = 220
        RP_Expenses_in_out.Top = 35

        RP_Expenses_in_out.Show()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        RP_Register.MdiParent = HOMERPOGRAM
        RP_Register.StartPosition = FormStartPosition.Manual
        RP_Register.Left = 200
        RP_Register.Top = 35

        RP_Register.Show()

    End Sub
End Class