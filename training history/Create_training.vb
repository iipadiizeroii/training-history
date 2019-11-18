Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class Create_training
    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""

    Public con As New OleDbConnection



    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from Course"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "cou")
        '4.'
        datagrid_course.DataSource = ds.Tables("cou")
        '5'
        cn.Close()

        datagrid_course.AllowUserToAddRows = False

    End Sub


    'Private Sub combo_con()
    '    con.ConnectionString = strConn
    '    If con.State = ConnectionState.Closed Then con.Open()
    'End Sub

#Region "เพิ่มข้อมูลกรอกเอง"
    'Private Sub add_cou()

    '    With cn
    '        If .State = ConnectionState.Open Then .Close()
    '        .ConnectionString = strConn
    '        .Open()
    '    End With

    '    savestatus = "Add"
    '    sql = "select * From Course Order by course_id DESC"
    '    Dim cm As New SqlCommand(sql, cn)
    '    Dim dr As SqlDataReader
    '    dr = cm.ExecuteReader

    '    cn.Close()
    '    txt_course_id.Focus()


    'End Sub
#End Region


#Region "เพิ่มข้อมูล"

    Private Sub add_cou()

        savestatus = "Add"

        'If R3.Checked = False Then
        '    MessageBox.Show("กรุณาติ๊กเลือก วิทยากรภายนอก")
        '    Exit Sub
        'End If

        sb = New StringBuilder
        sb.Append("Select top 1 course_id From Course ")
        sb.Append(" Order by course_id DESC")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim cm As New SqlCommand(sb.ToString, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader

        Dim ny As String = Now.Year '2019
        Dim oldid, Lid, Rid, newid As String
        oldid = ""

        Do While dr.Read
            oldid = dr.GetString(0)   'รหัสสุดท้าย 1908003
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
        txt_course_id.Text = newid
        cn.Close()

        txt_course_name.Focus()


    End Sub
#End Region


    Private Sub edit_cou()

        savestatus = "Edit"
        If txt_course_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_course_name.Focus()
            Exit Sub
        End If

        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        Next

    End Sub

    Private Sub update_cou()

        If txt_course_id.Text = "" Then
            MessageBox.Show("กรุณาเพื่มข้อมูลหรือค้นหาก่อน")
            Exit Sub
        End If
        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim s As String = ""
        If savestatus = "Add" Then
            s = "Insert into  Course (course_id,course_name,format_id,type_id,group_id)"
            s &= "Values (@course_id,@course_name,@format_id,@type_id,@group_id)"

        ElseIf savestatus = "Edit" Then
            s = "Update Course"
            s &= " set course_name = @course_name,"
            s &= "format_id = @format_id,"
            s &= "type_id = @type_id,"
            s &= "group_id = @group_id"
            s &= " Where course_id = @course_id"

        End If

        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()
            .Parameters.Add("@course_id", SqlDbType.NVarChar, 5).Value = txt_course_id.Text
            .Parameters.Add("@course_name", SqlDbType.NVarChar, 50).Value = txt_course_name.Text
            .Parameters.Add("@format_id", SqlDbType.Int).Value = txt_format_id.Text
            .Parameters.Add("@type_id", SqlDbType.Int).Value = txt_type_id.Text
            .Parameters.Add("@group_id", SqlDbType.Int).Value = txt_group_id.Text

            .ExecuteNonQuery()

        End With

        MsgBox("บัยทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
        showdata()





    End Sub

    Private Sub cleardata()

        txt_course_id.Text = ""
        txt_course_name.Text = ""
        txt_format_id.Text = ""
        txt_group_id.Text = ""
        txt_type_id.Text = ""
        cmb_group_name.Text = ""
        cmb_type_name.Text = ""
        cmb_format_name.Text = ""
        txt_Search.Text = ""
        R1.Checked = True
        R2.Checked = False



    End Sub

    Private Sub cmb_format()
        sql = "select format_name from format_course "
        cmd_object(cmb_format_name)
    End Sub

    Private Sub cmb_type()
        sql = "select type_name from type_course "
        cmd_object(cmb_type_name)
    End Sub

    Private Sub cmb_group()
        sql = "select group_name from group_course "
        cmd_object(cmb_group_name)
    End Sub

    Private Sub Create_training_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()
        cmb_format()
        cmb_type()
        cmb_group()
        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False



    End Sub

    Private Sub cmb_format_id_MouseClick(sender As Object, e As MouseEventArgs) Handles cmb_format_name.MouseClick

        'sql = "select format_id from format_course "
        'cmd_object(cmb_format_id)


    End Sub


    Private Sub cmb_format_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_format_name.SelectedIndexChanged

        sql = "select format_id  from format_course where format_name ='" & cmb_format_name.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "for")
        For Each dtr In ds.Tables("for").Rows
            txt_format_id.Text = dtr("format_id")
        Next

    End Sub


    Private Sub cmb_type_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_type_name.SelectedIndexChanged

        sql = "select type_id  from type_course where type_name ='" & cmb_type_name.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "ty")
        For Each dtr In ds.Tables("ty").Rows
            txt_type_id.Text = dtr("type_id")
        Next

    End Sub

    Private Sub cmb_group_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_group_name.SelectedIndexChanged

        sql = "select group_id  from group_course where group_name ='" & cmb_group_name.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "gro")
        For Each dtr In ds.Tables("gro").Rows
            txt_group_id.Text = dtr("group_id")
        Next

    End Sub

    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_cou()
        upte_data.Enabled = True
        add_data.Enabled = False
        edit_data.Enabled = False
        clear_data.Enabled = False


    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_cou()
        txt_course_name.Focus()
        upte_data.Enabled = True

    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_cou()
        upte_data.Enabled = False
        add_data.Enabled = True
        edit_data.Enabled = False
        clear_data.Enabled = False

    End Sub

#Region "คลิกเลือกข้อมูลใน datagrid"
    Private Sub datagrid_course_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_course.CellClick

        Try
            Dim i As Integer = datagrid_course.CurrentRow.Index
            txt_course_id.Text = datagrid_course.Item(0, i).Value
            txt_course_name.Text = datagrid_course.Item(1, i).Value
            txt_format_id.Text = datagrid_course.Item(2, i).Value
            txt_type_id.Text = datagrid_course.Item(3, i).Value
            txt_group_id.Text = datagrid_course.Item(4, i).Value

        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

        End Try

        edit_data.Enabled = True
        clear_data.Enabled = True


    End Sub
#End Region

#Region "ค้นหา"
    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown

        If e.KeyCode = Keys.Enter Then
            '1
            Dim cn As New SqlConnection(strConn)
            '2
            Dim s, s1 As String
            If R1.Checked = True Then
                s1 = " course_id like @course_id"
            Else
                s1 = " course_name like @course_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
            End If
            s = "select * from Course where " & s1
            '3
            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With
            Dim CM As New SqlCommand(s, cn)
            Dim DR As SqlDataReader
            CM.Parameters.Clear()
            If R1.Checked = True Then
                CM.Parameters.Add("@course_id", SqlDbType.NVarChar, 10).Value = txt_Search.Text & "%"
            Else
                CM.Parameters.Add("@course_name", SqlDbType.NVarChar, 50).Value = txt_Search.Text & "%"
            End If
            DR = CM.ExecuteReader
            Dim dt As New DataTable
            dt.Load(DR)
            '4
            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                With dt.Rows(0)
                    txt_course_id.Text = .Item(0).ToString
                    txt_course_name.Text = .Item(1).ToString
                    txt_format_id.Text = .Item(2).ToString
                    txt_type_id.Text = .Item(3).ToString
                    txt_group_id.Text = .Item(4).ToString


                    datagrid_course.DataSource = dt
                End With
            End If


        End If
    End Sub
#End Region

#Region "ลบข้อมูล"
    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click
        If txt_course_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("DELETE FROM Course  where course_id ='" & txt_course_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            showdata()
            cleardata()
        End If
    End Sub
#End Region



    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click


        cleardata()
        cn.Close()
        showdata()
        add_data.Enabled = True
        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False


    End Sub


    Private Sub txt_format_name_TextChanged(sender As Object, e As EventArgs) Handles txt_format_id.TextChanged

        sql = "select format_name  from format_course where format_id ='" & txt_format_id.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "for")
        For Each dtr In ds.Tables("for").Rows
            cmb_format_name.Text = dtr("format_name")
        Next

    End Sub

    Private Sub txt_type_neam_TextChanged(sender As Object, e As EventArgs) Handles txt_type_id.TextChanged

        sql = "select type_name  from type_course where type_id ='" & txt_type_id.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "ty")
        For Each dtr In ds.Tables("ty").Rows
            cmb_type_name.Text = dtr("type_name")
        Next

    End Sub

    Private Sub txt_group_name_TextChanged(sender As Object, e As EventArgs) Handles txt_group_id.TextChanged

        sql = "select group_name  from group_course where group_id ='" & txt_group_id.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "gro")
        For Each dtr In ds.Tables("gro").Rows
            cmb_group_name.Text = dtr("group_name")
        Next
    End Sub

    Private Sub txt_course_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_course_name.KeyPress
        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub cmb_format_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_format_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_format_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_format_id.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_type_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_type_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_type_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_type_id.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_group_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_group_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_group_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_group_id.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress

        If R1.Checked = True Then


            Select Case Asc(e.KeyChar)
                Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                    e.Handled = False
                Case 8, 13, 46 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                    e.Handled = False

                Case Else
                    e.Handled = True
                    MessageBox.Show("สามารถกดได้แค่ตัวเลข")
            End Select

            txt_Search.MaxLength = 5

        Else


            Select Case Asc(e.KeyChar)
                Case 48 To 122 ' ตรงนี้คือโค๊ดตัวเลขน่ะครับเราตัดโค๊ด58-122ออกไป
                    e.Handled = False
                Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                    e.Handled = False
                Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                    e.Handled = False
                Case Else
                    e.Handled = True
                    MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย")
            End Select
            txt_Search.MaxLength = 50
        End If

    End Sub

    Private Sub R1_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged
        txt_Search.Text = ""
    End Sub

    Private Sub R2_CheckedChanged(sender As Object, e As EventArgs) Handles R2.CheckedChanged
        txt_Search.Text = ""
    End Sub

    
End Class