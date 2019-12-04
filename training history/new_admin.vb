Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class new_admin

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim cmm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim res As DialogResult
    Dim savestatus As String = ""

#Region "showdata"
    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select UserID,Username,name,lastname,position,department,status from User_Pass"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "admin")
        '4.'
        DataGridView1.DataSource = ds.Tables("admin")
        '5'
        cn.Close()

        With DataGridView1
            .Columns.Item(0).HeaderText = "UserID"
            .Columns.Item(0).Width = "80"
            .Columns.Item(1).HeaderText = "Username"
            .Columns.Item(1).Width = "110"
            .Columns.Item(2).HeaderText = "ชื่อ"
            .Columns.Item(2).Width = "100"
            .Columns.Item(3).HeaderText = "นามสกุล"
            .Columns.Item(3).Width = "100"
            .Columns.Item(4).HeaderText = "ตำแหน่ง"
            .Columns.Item(4).Width = "160"
            .Columns.Item(5).HeaderText = "แผนก"
            .Columns.Item(5).Width = "160"
            .Columns.Item(6).HeaderText = "STATUS"
            .Columns.Item(6).Width = "70"


            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable


        End With

        DataGridView1.AllowUserToAddRows = False

    End Sub
#End Region

#Region "เพิ่มข้อมูล"

    Private Sub add_cou()

        savestatus = "Add"


        sb = New StringBuilder
        sb.Append("Select top 1 UserID From User_Pass ")
        sb.Append(" Order by UserID DESC")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim cm As New SqlCommand(sb.ToString, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader

        Dim ny As String = Now.Year '2019
        Dim oldid, Lid, Rid As String
        Dim newid As Integer
        oldid = ""

        Do While dr.Read
            oldid = dr.GetInt32(0)   'รหัสสุดท้าย 19003
        Loop

        Lid = oldid.Substring(0, 2)  '19
        Rid = oldid.Substring(oldid.Length - 3)   '003


        Dim y As String = ny.Substring(2, 2)  '19

        If y = Lid Then 'ถ้าปีเท่ากัน
            newid = y & (CInt(Rid) + 1).ToString("000")
        Else   'ถ้าปีไม่เท่ากัน
            newid = y & "001"
        End If

        cleardata()  '--F12
        txt_user_id.Text = newid
        cn.Close()

        txt_username.Focus()
        upte_data.Enabled = True
        edit_data.Enabled = False
        clear_data.Enabled = False

    End Sub
#End Region

#Region "เคลียร์ข้อมูล"
    Private Sub cleardata()

        txt_user_id.Text = ""
        txt_username.Text = ""
        txt_password.Text = ""
        txt_name.Text = ""
        txt_lastname.Text = ""
        txt_position.Text = ""
        cmb_department.Text = ""
        cmd_status.Text = ""




    End Sub
#End Region

#Region "ข้อความเตือน"
    Private Sub myMsg(msg As String, cap As String)
        Dim btn As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim ico As MessageBoxIcon = MessageBoxIcon.Question
        res = MessageBox.Show(msg, cap, btn, ico)
    End Sub
#End Region

#Region "แก้ไขข้อมูล"
    Private Sub edit_admin()


        If txt_user_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_username.Focus()
            Exit Sub
        End If

        If HOMERPOGRAM.Status1.Text = txt_username.Text Then
            MsgBox("กรุณาเลือกข้อมูลใหม่ ไม่สามารถแก้ไข Username ที่กำลังใช้งานได้", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

            myMsg("ต้องการแก้ไขใช่หรือไม่", "ยืนยัน")
            If res = Windows.Forms.DialogResult.No Then Exit Sub

        savestatus = "Edit"


        upte_data.Enabled = True
        clear_data.Enabled = True
        add_data.Enabled = False


            'Dim ctrl As Control
            'For Each ctrl In Me.Controls
            '    If ctrl.GetType Is GetType(TextBox) Then
            '        CType(ctrl, TextBox).ReadOnly = False
            '    End If
            'Next

    End Sub
#End Region

#Region "บันทึกข้อมูล"
    Private Sub update_admin()


        If txt_user_id.Text = "" Then
            MessageBox.Show("กรุณาเพื่มข้อมูลหรือค้นหาก่อน")
            Exit Sub
        End If


        If txt_username.Text = "" Then
            MsgBox("กรุณากรอก username", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_password.Text = "" Then
            MsgBox("กรุณากรอก password", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_name.Text = "" Then
            MsgBox("กรุณากรอกชื่อ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        If txt_lastname.Text = "" Then
            MsgBox("กรุณากรอกนามสกุล", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_position.Text = "" Then
            MsgBox("กรุณากรอกต่ำแหน่ง", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If cmb_department.Text = "" Then
            MsgBox("กรุณากรอกแผนก", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If cmd_status.Text = "" Then
            MsgBox("กรุณาเลือกสถานะ ADMIN หรือ USER", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        ' ตรวจสอบค่า userneam ที่ซ้ำในระบบ
        If txt_username.Text <> "" And savestatus = "Add" Then

            Dim cn As New SqlConnection(strConn)
            Dim ss As String

            ss = "select * from User_Pass where Username like @user_name "

            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With

            Dim cmm As New SqlCommand(ss, cn)
            Dim DR As SqlDataReader
            cmm.Parameters.Clear()
            cmm.Parameters.Add("@user_name", SqlDbType.NVarChar, 20).Value = txt_username.Text
            DR = cmm.ExecuteReader

            Dim dt As New DataTable
            dt.Load(DR)

            If (dt.Rows.Count <> 0) Then
                MsgBox("Username นี้ถูกใช้งานแล้วกรุณากรอกใหม่", MsgBoxStyle.Critical, "ผลการทำงาน")
                txt_username.Focus()
                Exit Sub
            End If

            cn.Close()
        End If

        ' สิ้นสุดโค้ดที่ตรวจสอบค่าซ้ำ


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim s As String = ""
        If savestatus = "Add" Then
            s = "Insert into  User_Pass (UserID,Username,Password,name,lastname,position,department,status )"
            s &= "Values (@UserID,@Username,@Password,@name,@lastname,@position,@department,@status)"

        ElseIf savestatus = "Edit" Then
            s = "Update User_Pass "
            s &= " set Username = @Username,"
            s &= "Password = @Password,"
            s &= "name = @name,"
            s &= "lastname = @lastname,"
            s &= "position = @position,"
            s &= "department = @department,"
            s &= "status = @status "
            s &= " Where UserID = @UserID"

        End If

        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()
            .Parameters.Add("@UserID", SqlDbType.Int).Value = txt_user_id.Text
            .Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = txt_username.Text
            .Parameters.Add("@Password", SqlDbType.NVarChar, 20).Value = txt_password.Text
            .Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = txt_name.Text
            .Parameters.Add("@lastname", SqlDbType.NVarChar, 50).Value = txt_lastname.Text
            .Parameters.Add("@position", SqlDbType.NVarChar, 50).Value = txt_position.Text
            .Parameters.Add("@department", SqlDbType.NVarChar, 30).Value = cmb_department.Text
            .Parameters.Add("@status", SqlDbType.NVarChar, 5).Value = cmd_status.Text



            .ExecuteNonQuery()

        End With

        MsgBox("บันทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
        showdata()
        savestatus = ""



    End Sub

#End Region

#Region "ลบข้อมูล"
    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click
        If txt_user_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If HOMERPOGRAM.Status1.Text = txt_username.Text Then
            MsgBox("กรุณาเลือกข้อมูลใหม่ ไม่สามารถลบ Username ที่กำลังใช้งานได้", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("DELETE FROM User_Pass  where UserID ='" & txt_user_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            showdata()
            cleardata()
        End If

        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False

    End Sub


#End Region

#Region "เลือกข้อมูลจากดาด้ากริด"
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            Dim i As Integer = DataGridView1.CurrentRow.Index
            txt_user_id.Text = DataGridView1.Item(0, i).Value
            txt_username.Text = DataGridView1.Item(1, i).Value
            'txt_password.Text = DataGridView1.Item(2, i).Value
            txt_name.Text = DataGridView1.Item(2, i).Value
            txt_lastname.Text = DataGridView1.Item(3, i).Value
            txt_position.Text = DataGridView1.Item(4, i).Value
            cmb_department.Text = DataGridView1.Item(5, i).Value
            cmd_status.Text = DataGridView1.Item(6, i).Value
            txt_password.Text = "●●●●●●●●●●●"
        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

        End Try

        edit_data.Enabled = True
        clear_data.Enabled = True
        upte_data.Enabled = False

    End Sub

#End Region


    Private Sub emp_department()
        sql = "select department_name from Department "
        cmd_object(cmb_department)
    End Sub
   
    Private Sub new_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()
        emp_department()

    End Sub

    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        add_cou()
        

    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_admin()

        If savestatus = "Add" Then
            upte_data.Enabled = True

        ElseIf savestatus = "Edit" Then
            upte_data.Enabled = True
        Else
            upte_data.Enabled = False
            edit_data.Enabled = False
            clear_data.Enabled = False
            add_data.Enabled = True

        End If

    End Sub



    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_admin()
       

    End Sub

    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click


        cn.Close()
        cleardata()
        showdata()
        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False
        add_data.Enabled = True


    End Sub

#Region "code กันไม่ใช้คีย์ขอมูลผิดประเภท"

    Private Sub txt_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_name.KeyPress

        Select Case Asc(e.KeyChar)
            Case 58 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย และ ภาษาอังกฤษ")
        End Select

    End Sub

    Private Sub txt_lastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_lastname.KeyPress

        Select Case Asc(e.KeyChar)
            Case 58 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย และ ภาษาอังกฤษ")
        End Select

    End Sub

    Private Sub txt_position_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_position.KeyPress

        Select Case Asc(e.KeyChar)
            Case 58 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย และ ภาษาอังกฤษ")
        End Select

    End Sub

    Private Sub txt_username_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_username.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นตัวเลข และ ภาษาอังกฤษ")
        End Select

    End Sub

    Private Sub txt_password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_password.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นตัวเลข และ ภาษาอังกฤษ")
        End Select

    End Sub

    Private Sub cmb_department_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_department.KeyPress

        e.Handled = True

    End Sub

    Private Sub cmd_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmd_status.KeyPress

        e.Handled = True

    End Sub


#End Region

    Private Sub txt_password_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_password.MouseDown
        txt_password.Text = ""
    End Sub
End Class