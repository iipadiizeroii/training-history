Imports CrystalDecisions.CrystalReports.Engine

Public Class test_PR

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim rpt As New ReportDocument()
        Dim rpt2 As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Expenses_in.rpt")
        rpt.SetParameterValue("trainingdate1", Me.Date_training1.Text)
        rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)

        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.ReportSource = rpt2
        Me.CrystalReportViewer1.Refresh()




    End Sub


    Private Sub test_PR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class