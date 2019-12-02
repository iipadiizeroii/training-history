Imports CrystalDecisions.CrystalReports.Engine

Public Class RP_Register

   

    Private Sub RP_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Register.rpt")


        rpt.SetParameterValue("trainingin_id", TextBox1.Text)

        'rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)

        Me.CrystalReportViewer1.ReportSource = rpt
        'Me.CrystalReportViewer1.ReportSource = rpt2
        Me.CrystalReportViewer1.Refresh()

    End Sub
End Class