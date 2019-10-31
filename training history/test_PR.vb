Imports CrystalDecisions.CrystalReports.Engine

Public Class test_PR

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Training.rpt")
        rpt.SetParameterValue("trainingInid1", Me.TextBox1.Text)
        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()


    End Sub


End Class