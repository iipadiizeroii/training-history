Public Class HOME

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Employees.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Create_Expert.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Create_training.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Internal_training.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        External_training.Show()

    End Sub

    Private Sub HOME_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.Select()



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RP_PO_internal.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RP_Register.Show()
    End Sub
End Class