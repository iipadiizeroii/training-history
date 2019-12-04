Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class Login_Form

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txt_usermane.Text = "" Then
            MsgBox("กรุณาใส่ Username", MsgBoxStyle.Critical, "ผลการทำงาน")
            txt_usermane.Focus()
            Exit Sub
        End If
        If txt_password.Text = "" Then
            MsgBox("กรุณาใส่ Password", MsgBoxStyle.Critical, "ผลการทำงาน")
            txt_password.Focus()
            Exit Sub
        End If
        Dim login As DataTable = SqlTable(" select Username , Password, status from User_Pass where Username = '" & txt_usermane.Text & "' and Password = '" & txt_password.Text & "'")
        If login.Rows.Count > 0 Then
            HOMERPOGRAM.Status1.Text = login(0)(0)
            HOMERPOGRAM.Status2.Text = login(0)(2)
        Else
            MsgBox("ไม่พบผู้ใช้งานในระบบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If HOMERPOGRAM.Status2.Text = "ADMIN" Then
            HOMERPOGRAM.MenuStrip1.Visible = True
            HOMERPOGRAM.StatusStrip1.Visible = True
            HOMERPOGRAM.GroupBox1.Visible = True
            HOMERPOGRAM.Panel1.Visible = True
            'HOMERPOGRAM.Button1.Visible = True
            'HOMERPOGRAM.Button2.Visible = True
            'HOMERPOGRAM.Button3.Visible = True
            'HOMERPOGRAM.Button4.Visible = True
            'HOMERPOGRAM.Button5.Visible = True
            'HOMERPOGRAM.Button6.Visible = True
            'HOMERPOGRAM.Button7.Visible = True
            'HOMERPOGRAM.Button8.Visible = True
            'HOMERPOGRAM.Button9.Visible = True

        Else
            HOMERPOGRAM.MenuStrip1.Visible = True
            HOMERPOGRAM.บนทกขอมลUserToolStripMenuItem.Enabled = False
            HOMERPOGRAM.StatusStrip1.Visible = True
            HOMERPOGRAM.GroupBox1.Visible = True
            HOMERPOGRAM.Panel1.Visible = True
            'HOMERPOGRAM.Button1.Visible = True
            'HOMERPOGRAM.Button2.Visible = True
            'HOMERPOGRAM.Button3.Visible = True
            'HOMERPOGRAM.Button4.Visible = True
            'HOMERPOGRAM.Button5.Visible = True
            'HOMERPOGRAM.Button6.Visible = True
            'HOMERPOGRAM.Button7.Visible = True
            'HOMERPOGRAM.Button8.Visible = True
            'HOMERPOGRAM.Button9.Visible = True

        End If
        Me.Close()
        HOMERPOGRAM.Show()
    End Sub

   

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txt_usermane.Clear()
        txt_password.Clear()
    End Sub

    Private Sub txt_usermane_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_usermane.KeyDown
        If e.KeyCode = Keys.Enter Then

            If txt_usermane.Text = "" Then
                MsgBox("กรุณาใส่ Username", MsgBoxStyle.Critical, "ผลการทำงาน")
                txt_usermane.Focus()
                Exit Sub
            End If
            If txt_password.Text = "" Then
                MsgBox("กรุณาใส่ Password", MsgBoxStyle.Critical, "ผลการทำงาน")
                txt_password.Focus()
                Exit Sub
            End If
            Dim login As DataTable = SqlTable(" select Username , Password, status from User_Pass where Username = '" & txt_usermane.Text & "' and Password = '" & txt_password.Text & "'")
            If login.Rows.Count > 0 Then
                HOMERPOGRAM.Status1.Text = login(0)(0)
                HOMERPOGRAM.Status2.Text = login(0)(2)
            Else
                MsgBox("ไม่พบผู้ใช้งานในระบบ", MsgBoxStyle.Critical, "ผลการทำงาน")
                Exit Sub
            End If
            If HOMERPOGRAM.Status2.Text = "ADMIN" Then
                HOMERPOGRAM.MenuStrip1.Visible = True
                HOMERPOGRAM.StatusStrip1.Visible = True
                HOMERPOGRAM.GroupBox1.Visible = True
                HOMERPOGRAM.Panel1.Visible = True
                'HOMERPOGRAM.Button1.Visible = True
                'HOMERPOGRAM.Button2.Visible = True
                'HOMERPOGRAM.Button3.Visible = True
                'HOMERPOGRAM.Button4.Visible = True
                'HOMERPOGRAM.Button5.Visible = True
                'HOMERPOGRAM.Button6.Visible = True
                'HOMERPOGRAM.Button7.Visible = True
                'HOMERPOGRAM.Button8.Visible = True
                'HOMERPOGRAM.Button9.Visible = True

            Else
                HOMERPOGRAM.MenuStrip1.Visible = True
                HOMERPOGRAM.บนทกขอมลUserToolStripMenuItem.Enabled = False
                HOMERPOGRAM.StatusStrip1.Visible = True
                HOMERPOGRAM.GroupBox1.Visible = True
                HOMERPOGRAM.Panel1.Visible = True
                'HOMERPOGRAM.Button1.Visible = True
                'HOMERPOGRAM.Button2.Visible = True
                'HOMERPOGRAM.Button3.Visible = True
                'HOMERPOGRAM.Button4.Visible = True
                'HOMERPOGRAM.Button5.Visible = True
                'HOMERPOGRAM.Button6.Visible = True
                'HOMERPOGRAM.Button7.Visible = True
                'HOMERPOGRAM.Button8.Visible = True
                'HOMERPOGRAM.Button9.Visible = True

            End If
            Me.Close()
            HOMERPOGRAM.Show()
        End If
    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown
        If e.KeyCode = Keys.Enter Then


            If txt_usermane.Text = "" Then
                MsgBox("กรุณาใส่ Username", MsgBoxStyle.Critical, "ผลการทำงาน")
                txt_usermane.Focus()
                Exit Sub
            End If
            If txt_password.Text = "" Then
                MsgBox("กรุณาใส่ Password", MsgBoxStyle.Critical, "ผลการทำงาน")
                txt_password.Focus()
                Exit Sub
            End If
            Dim login As DataTable = SqlTable(" select Username , Password, status from User_Pass where Username = '" & txt_usermane.Text & "' and Password = '" & txt_password.Text & "'")
            If login.Rows.Count > 0 Then
                HOMERPOGRAM.Status1.Text = login(0)(0)
                HOMERPOGRAM.Status2.Text = login(0)(2)
            Else
                MsgBox("ไม่พบผู้ใช้งานในระบบ", MsgBoxStyle.Critical, "ผลการทำงาน")
                Exit Sub
            End If
            If HOMERPOGRAM.Status2.Text = "ADMIN" Then
                HOMERPOGRAM.MenuStrip1.Visible = True
                HOMERPOGRAM.StatusStrip1.Visible = True
                HOMERPOGRAM.GroupBox1.Visible = True
                HOMERPOGRAM.Panel1.Visible = True
                'HOMERPOGRAM.Button1.Visible = True
                'HOMERPOGRAM.Button2.Visible = True
                'HOMERPOGRAM.Button3.Visible = True
                'HOMERPOGRAM.Button4.Visible = True
                'HOMERPOGRAM.Button5.Visible = True
                'HOMERPOGRAM.Button6.Visible = True
                'HOMERPOGRAM.Button7.Visible = True
                'HOMERPOGRAM.Button8.Visible = True
                'HOMERPOGRAM.Button9.Visible = True

            Else
                HOMERPOGRAM.MenuStrip1.Visible = True
                HOMERPOGRAM.บนทกขอมลUserToolStripMenuItem.Enabled = False
                HOMERPOGRAM.StatusStrip1.Visible = True
                HOMERPOGRAM.GroupBox1.Visible = True
                HOMERPOGRAM.Panel1.Visible = True
                'HOMERPOGRAM.Button1.Visible = True
                'HOMERPOGRAM.Button2.Visible = True
                'HOMERPOGRAM.Button3.Visible = True
                'HOMERPOGRAM.Button4.Visible = True
                'HOMERPOGRAM.Button5.Visible = True
                'HOMERPOGRAM.Button6.Visible = True
                'HOMERPOGRAM.Button7.Visible = True
                'HOMERPOGRAM.Button8.Visible = True
                'HOMERPOGRAM.Button9.Visible = True

            End If
            Me.Close()
            HOMERPOGRAM.Show()

        End If
    End Sub

    Private Sub Login_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class