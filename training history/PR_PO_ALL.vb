Imports CrystalDecisions.CrystalReports.Engine

Public Class PR_PO_ALL

    Private Sub PR_PO_ALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

       
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim directory As String = My.Application.Info.DirectoryPath
        Dim rpt As New ReportDocument()

        If R1.Checked And R3.Checked = True Then


            'rpt.Load(directory & "\myCrystalReport1.rpt")
            'rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_PO_EX_internal_training.rpt")
            rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\PR_PO_EX_internal_training.rpt")

            rpt.SetParameterValue("PR_trainingin_id", TextBox1.Text)
            'rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)
            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()

        ElseIf R1.Checked And R4.Checked = True Then

            'Dim directory As String = My.Application.Info.DirectoryPath

            'rpt.Load(directory & "\myCrystalReport1.rpt")
            'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_PO__EM_internal_training.rpt")
            rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\RP_PO__EM_internal_training.rpt")
            rpt.SetParameterValue("PR_traingin_id", TextBox1.Text)
            'rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)
            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()

        Else

            'Dim directory As String = My.Application.Info.DirectoryPath

            'rpt.Load(directory & "\myCrystalReport1.rpt")
            'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_PO__EM_external_training.rpt")
            rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\RP_PO__EM_external_training.rpt")
            rpt.SetParameterValue("PR_traingEx_id", TextBox1.Text)
            'rpt.SetParameterValue("trainingdate2", Me.Date_training2.Text)
            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()

        End If

    End Sub

    Private Sub R2_CheckedChanged(sender As Object, e As EventArgs) Handles R2.CheckedChanged

        R3.Enabled = False
        R4.Checked = True

    End Sub

    Private Sub R1_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged

        R3.Enabled = True

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        Select Case Asc(e.KeyChar)
        Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
        e.Handled = False
                Case 8, 13, 46 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
        e.Handled = False

                Case Else
        e.Handled = True
        MessageBox.Show("สามารถกดได้แค่ตัวเลข")
            End Select

    End Sub
End Class