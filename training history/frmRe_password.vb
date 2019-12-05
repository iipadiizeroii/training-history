Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class frmRe_password

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim cmm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim res As DialogResult
    Dim savestatus As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txt_password.Text <> txt_password2.Text Then
            MsgBox("รหัสผ่านไม่ตรงกันกรุณากรอกใหม่", MsgBoxStyle.Information, "ผลการทำงาน")
            Exit Sub
        End If

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim s As String = ""

            s = "Update User_Pass "
            s &= " set Password = @Password"
            s &= " Where Username = @Username"

       
        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()
            .Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = HOMERPOGRAM.Status1.Text
            .Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = txt_password.Text
            .ExecuteNonQuery()

        End With

        MsgBox("บันทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txt_password.Text = ""
        txt_password2.Text = ""

    End Sub
End Class