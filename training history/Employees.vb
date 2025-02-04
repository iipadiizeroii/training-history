﻿Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class Employees
    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""

#Region "showdate"
    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        s = "select * from Employees"
        cn.Open()
        Dim cm As New SqlCommand(s, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        datagrid_emp.DataSource = dt
        cn.Close()


    End Sub
#End Region

#Region "showdata2"
    Private Sub showdata2()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from Employees"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "emp")
        '4.'
        datagrid_emp.DataSource = ds.Tables("emp")
        '5'
        cn.Close()

    End Sub

#End Region


#Region "add"
    Private Sub add_emp()



        savestatus = "Add"

        If E1.Checked = True Then
            sb = New StringBuilder
            sb.Append("select max (emp_id) from employees where emp_id like '%F%' ")
        Else
            sb = New StringBuilder
            sb.Append("select max (emp_id) from employees where emp_id like '%Y%' ")

        End If


        'sb = New StringBuilder
        'sb.Append("Select top 1 emp_id From Employees ")
        'sb.Append(" Order by emp_id DESC")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim cm As New SqlCommand(sb.ToString, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader

        Dim oldid, Lid, Mid, Rid, newid As String
        oldid = ""
        Do While dr.Read
            oldid = dr.GetString(0)   'รหัสสุดท้าย 1908003
        Loop
        Lid = oldid.Substring(1, 2)  '19
        Mid = oldid.Substring(3, 2)  '08
        Rid = oldid.Substring(oldid.Length - 3)   '003

        Dim EE As String = ""

        If E1.Checked = True Then
            EE = "F"
        Else
            EE = "Y"
        End If


        Dim ny As String = Now.Year '2019
        Dim y As String = ny.Substring(2, 2)  '19
        Dim m As String = (Now.Month).ToString("00")  '08

        If y = Lid Then 'ถ้าปีเท่ากัน
            If m = Mid Then 'ถ้าเดือนเท่ากัน
                newid = EE & y & m & (CInt(Rid) + 1).ToString("000")
            Else   'ถ้าเดือนไม่เท่ากัน
                newid = EE & y & m & "001"
            End If
        Else    'ถ้าปีไม่เท่ากัน
            newid = EE & y & m & "001"
        End If

        cleardata()  '--F12
        txt_emp_id.Text = newid
        cn.Close()



        txt_emp_name.Focus()




        'With cn
        '    If .State = ConnectionState.Open Then .Close()
        '    .ConnectionString = strConn
        '    .Open()
        'End With

        'savestatus = "Add"
        'Dim sql As String = ""
        'sql = "select * From Employees Order by emp_id DESC"
        'Dim cm As New SqlCommand(sql, cn)
        'Dim dr As SqlDataReader
        'dr = cm.ExecuteReader

        'cn.Close()
        'txt_emp_id.Focus()


    End Sub
#End Region


    'โค๊ดเกี่ยวกับ Date
    'Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim dt As DateTimeFormatInfo = Thread.CurrentThread.CurrentCulture.DateTimeFormat
    '    Me.Date1.CustomFormat = "dd MMM yyyy"
    '    Me.Date1.Format = DateTimePickerFormat.Custom
    'End Sub 

#Region "บันทัก"
    Private Sub update_emp()

        If txt_emp_id.Text = "" Then
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
            s = "Insert into  Employees (emp_id,emp_name,emp_lastname,emp_level,emp_position,emp_department,emp_division,emp_degree,emp_date)"
            s &= "Values (@emp_id,@emp_name,@emp_lastname,@emp_level,@emp_position,@emp_department,@emp_division,@emp_degree,@emp_date)"



        ElseIf savestatus = "Edit" Then
            s = "Update Employees"
            s &= " set emp_name = @emp_name,"
            s &= "emp_lastname = @emp_lastname,"
            s &= "emp_level = @emp_level,"
            s &= "emp_position = @emp_position,"
            s &= "emp_department = @emp_department,"
            s &= "emp_division = @emp_division,"
            s &= "emp_degree = @emp_degree,"
            s &= "emp_date = @emp_date"
            s &= " Where emp_id = @emp_id"


        End If

        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()

            .Parameters.Add("@emp_id", SqlDbType.NVarChar, 10).Value = txt_emp_id.Text
            .Parameters.Add("@emp_name", SqlDbType.NVarChar, 50).Value = txt_emp_name.Text
            .Parameters.Add("@emp_lastname", SqlDbType.NVarChar, 50).Value = txt_emp_lastname.Text
            .Parameters.Add("@emp_level", SqlDbType.Int).Value = cmb_emp_level.Text
            .Parameters.Add("@emp_position", SqlDbType.NVarChar, 50).Value = txt_emp_position.Text
            .Parameters.Add("@emp_department", SqlDbType.NVarChar, 30).Value = cmb_emp_department.Text
            .Parameters.Add("@emp_division", SqlDbType.NVarChar, 30).Value = txt_emp_division.Text
            .Parameters.Add("@emp_degree", SqlDbType.NVarChar, 10).Value = cmb_emp_degree.Text
            .Parameters.Add("@emp_date", SqlDbType.Date).Value = Date_start.Text
            .ExecuteNonQuery()

        End With




        MessageBox.Show("บันทึกเรียบร้อย ")
        showdata2()

        'Dim bb As Boolean
        'bb = source.StartsWith("c:\Pic")



    End Sub
#End Region

#Region "แก้ไขข้อมูล"
    Private Sub edit_emp()
        savestatus = "Edit"
        If txt_emp_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_emp_id.Focus()
            Exit Sub
        End If

        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        Next
        txt_emp_name.Focus()
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
                s1 = " emp_id like @emp_id"
            Else
                s1 = " emp_name like @emp_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
            End If
            s = "select * from Employees where " & s1
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
                CM.Parameters.Add("@emp_id", SqlDbType.NVarChar, 10).Value = "%" & txt_Search.Text & "%"
            Else
                CM.Parameters.Add("@emp_name", SqlDbType.NVarChar, 50).Value = "%" & txt_Search.Text & "%"
            End If
            DR = CM.ExecuteReader
            Dim dt As New DataTable
            dt.Load(DR)
            '4
            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                With dt.Rows(0)
                    txt_emp_id.Text = .Item(0).ToString
                    txt_emp_name.Text = .Item(1).ToString
                    txt_emp_lastname.Text = .Item(2).ToString
                    cmb_emp_level.Text = .Item(3).ToString
                    txt_emp_position.Text = .Item(4).ToString
                    cmb_emp_department.Text = .Item(5).ToString
                    txt_emp_division.Text = .Item(6).ToString
                    cmb_emp_degree.Text = .Item(7).ToString
                    Date_start.Text = .Item(8).ToString

                    datagrid_emp.DataSource = dt
                End With
            End If


        End If
    End Sub
#End Region

#Region "คลิกเลือกข้อมูลใน datagrid"
    Private Sub datagrid_emp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_emp.CellClick

        Try
            Dim i As Integer = datagrid_emp.CurrentRow.Index
            txt_emp_id.Text = datagrid_emp.Item(0, i).Value
            txt_emp_name.Text = datagrid_emp.Item(1, i).Value
            txt_emp_lastname.Text = datagrid_emp.Item(2, i).Value
            cmb_emp_level.Text = datagrid_emp.Item(3, i).Value
            txt_emp_position.Text = datagrid_emp.Item(4, i).Value
            cmb_emp_department.Text = datagrid_emp.Item(5, i).Value
            txt_emp_division.Text = datagrid_emp.Item(6, i).Value
            cmb_emp_degree.Text = datagrid_emp.Item(7, i).Value
            Date_start.Text = datagrid_emp.Item(8, i).Value

            Dim aa As String = ""
            aa = txt_emp_id.Text.Substring(0, 1)

            If aa = "" Then
                Exit Sub

            ElseIf aa = "F" Then
                E1.Checked = True
            Else
                E2.Checked = True

            End If

        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)



        

        End Try

    End Sub
#End Region

#Region "ลบ"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles clear_data.Click
        If txt_emp_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("DELETE FROM Employees  where emp_id ='" & txt_emp_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            showdata2()
            cleardata()
        End If


    End Sub
#End Region

#Region "cleardata"
    Private Sub cleardata()
        txt_emp_id.Text = ""
        txt_emp_division.Text = ""
        txt_emp_lastname.Text = ""
        txt_emp_name.Text = ""
        txt_emp_position.Text = ""
        cmb_emp_degree.Text = ""
        cmb_emp_department.Text = ""
        cmb_emp_level.Text = ""
        txt_Search.Text = ""
        Date_start.Text = Now.Date
        'R1.Checked = False
        'R2.Checked = False



    End Sub
#End Region

    Private Sub emp_department()
        sql = "select department_name from Department "
        cmd_object(cmb_emp_department)
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata2()
        emp_department()
        R1.Checked = True
        E1.Checked = True
        txt_emp_id.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_emp()

    End Sub




    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_emp.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_emp()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_emp()

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

        cn.Close()
        cleardata()
        showdata2()

    End Sub




    Private Sub R1_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged

        txt_Search.Text = ""
        txt_Search.Focus()
        cleardata()
        showdata2()

    End Sub

    Private Sub R2_CheckedChanged(sender As Object, e As EventArgs) Handles R2.CheckedChanged

        txt_Search.Text = ""
        txt_Search.Focus()
        cleardata()
        showdata2()

    End Sub

    Private Sub cmb_emp_degree_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_emp_degree.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_emp_level_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_emp_level.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_emp_department_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_emp_department.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_emp_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_emp_name.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_emp_lastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_emp_lastname.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_emp_position_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_emp_position.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_emp_division_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_emp_division.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_emp_department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_emp_department.SelectedIndexChanged


        sql = "select Count_unit.count_name from Count_unit INNER JOIN Department on Department.count_id = Count_unit.count_id where Department.department_name =  '" & cmb_emp_department.Text & "'"


        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "co")
        For Each dtr In ds.Tables("co").Rows
            txt_emp_division.Text = dtr("count_name")
        Next

    End Sub

    Private Sub txt_emp_division_TextChanged(sender As Object, e As EventArgs) Handles txt_emp_division.TextChanged

    End Sub

    Private Sub txt_Search_TextChanged(sender As Object, e As EventArgs) Handles txt_Search.TextChanged

    End Sub
End Class
