Imports CrystalDecisions.CrystalReports.Engine

Public Class PR_PO_internal_training

    Private Sub PR_PO_internal_training_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim trainingIn_id As String = ""
        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath

        rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_PO__EM_internal_training.rpt")
        rpt.SetParameterValue("PR_traingin_id", TextBox1.Text)


        Me.CrystalReportViewer1.ReportSource = rpt
        Me.CrystalReportViewer1.Refresh()



    End Sub
End Class