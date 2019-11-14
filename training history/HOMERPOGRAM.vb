Public Class HOMERPOGRAM

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HOMERPOGRAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim f As New Create_Expert()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 380 : f.Top = 50 : f.Show()


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

        Dim f As New Internal_training()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 215 : f.Top = 50 : f.Show()

        'Internal_training.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim f As New External_training()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 215 : f.Top = 50 : f.Show()

        'External_training.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click





    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        Dim f As New frmSearch_history_training_Em()
        f.MdiParent = Me
        f.StartPosition = FormStartPosition.Manual
        f.Left = 370 : f.Top = 50 : f.Show()


        'Dim f As New frmSearch_not_history_training_Em()
        ''f.MdiParent = GroupBox2.Container
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 547 : f.Top = 240 : f.Show()


    End Sub

    Private Sub บนทกขอมลพนกงานToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกขอมลพนกงานToolStripMenuItem.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class