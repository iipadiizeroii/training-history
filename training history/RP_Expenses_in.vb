Imports CrystalDecisions.CrystalReports.Engine

Public Class RP_Expenses_in

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim date_in As String = ""
        Dim date_out As String = ""
        Dim rpt As New ReportDocument()
        Dim rpt2 As New ReportDocument()

        Dim directory As String = My.Application.Info.DirectoryPath
        date_in = Date_training1.Value.ToString("yyyy-MM-dd")
        date_out = Date_training2.Value.ToString("yyyy-MM-dd")
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Expenses_in.rpt")


        rpt.SetParameterValue("startDate", date_in)
        rpt.SetParameterValue("endDate", date_out)
        'rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)

        Me.CrystalReportViewer1.ReportSource = rpt
        'Me.CrystalReportViewer1.ReportSource = rpt2
        Me.CrystalReportViewer1.Refresh()


    End Sub


    Private Sub test_PR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class