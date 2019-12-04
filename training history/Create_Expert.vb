﻿Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class Create_Expert

    Dim sb As StringBuilder

#Region "ค้นหา"
    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown

        If e.KeyCode = Keys.Enter Then
            '1
            Dim cn As New SqlConnection(strConn)
            '2
            Dim s, s1 As String
            If R1.Checked = True Then
                s1 = " expert_id like @emp_id"
            Else
                s1 = " expert_name like @emp_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
            End If
            s = "select * from Expert where " & s1
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
                    txt_exp_id.Text = .Item(0).ToString
                    txt_exp_name.Text = .Item(1).ToString
                    txt_exp_lastname.Text = .Item(2).ToString
                    txt_exp_position.Text = .Item(3).ToString
                    txt_exp_department.Text = .Item(4).ToString
                    txt_expert_expertise.Text = .Item(5).ToString

                    edit_data.Enabled = True
                    datagrid_exp.DataSource = dt
                End With
            End If


        End If
    End Sub

#End Region


#Region "คลิกเลือกข้อมูลใน datagrid"
    Private Sub datagrid_exp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_exp.CellClick


        Try
            Dim i As Integer = datagrid_exp.CurrentRow.Index
            txt_exp_id.Text = datagrid_exp.Item(0, i).Value
            txt_exp_name.Text = datagrid_exp.Item(1, i).Value
            txt_exp_lastname.Text = datagrid_exp.Item(2, i).Value
            txt_exp_position.Text = datagrid_exp.Item(3, i).Value
            txt_exp_department.Text = datagrid_exp.Item(4, i).Value
            txt_expert_expertise.Text = datagrid_exp.Item(5, i).Value

            Dim aa As String = ""
            aa = txt_exp_id.Text.Substring(0, 1)

            If aa = "" Then
                Exit Sub

            ElseIf aa = "T" Then
                R3.Checked = True
            Else
                R4.Checked = True

            End If

            edit_data.Enabled = True
            clear_data.Enabled = True

        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

        End Try




    End Sub

#End Region

#Region "ลบข้อมูล"
    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click

        If txt_exp_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("DELETE FROM Expert  where expert_id ='" & txt_exp_id.Text & "'")

            If error1 = 1 Then
                error1 = 0
                Exit Sub
            End If

            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            showdata()
            cleardata()
        End If

        R4.Checked = False
        Search_emp.Enabled = False
        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False

    End Sub
#End Region

#Region "Update ข้อมูล"
    Private Sub update_exp()

        If txt_exp_id.Text = "" Then
            MessageBox.Show("กรุณาเพื่มข้อมูลหรือค้นหาก่อน")
            Exit Sub
        End If


        If txt_exp_name.Text = "" Then
            MsgBox("กรุณากรอกชื่อวิทยากร", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_exp_lastname.Text = "" Then
            MsgBox("กรุณากรอกนามสกุลพนักงาน", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_exp_position.Text = "" Then
            MsgBox("กรุณากรอกตำแหน่งวิทยากร", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_exp_department.Text = "" Then
            MsgBox("กรุณากรอกหน่วยงานต้นสังกัด", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_expert_expertise.Text = "" Then
            MsgBox("กรุณากรอกความชำนาญวิทยากร", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim s As String = ""
        If savestatus = "Add" Then
            s = "Insert into  Expert (expert_id,expert_name,expert_lastname,expert_position,expert_department,expert_expertise)"
            s &= "Values (@expert_id,@expert_name,@expert_lastname,@expert_position,@expert_department,@expert_expertise)"


        ElseIf savestatus = "Edit" Then
            s = "Update Expert"
            s &= " set expert_name = @expert_name,"
            s &= "expert_lastname = @expert_lastname,"
            s &= "expert_position = @expert_position,"
            s &= "expert_department = @expert_department,"
            s &= "expert_expertise = @expert_expertise"
            s &= " Where expert_id = @expert_id"


        End If

        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()

            .Parameters.Add("@expert_id", SqlDbType.NVarChar, 50).Value = txt_exp_id.Text
            .Parameters.Add("@expert_name", SqlDbType.NVarChar, 50).Value = txt_exp_name.Text
            .Parameters.Add("@expert_lastname", SqlDbType.NVarChar, 50).Value = txt_exp_lastname.Text
            .Parameters.Add("@expert_position", SqlDbType.NVarChar, 50).Value = txt_exp_position.Text
            .Parameters.Add("@expert_department", SqlDbType.NVarChar, 50).Value = txt_exp_department.Text
            .Parameters.Add("@expert_expertise", SqlDbType.NVarChar, 50).Value = txt_expert_expertise.Text


            .ExecuteNonQuery()

        End With


        MessageBox.Show("บันทึกเรียบร้อย ")
        showdata()
        savestatus = ""
        R4.Checked = False
        Search_emp.Enabled = False


    End Sub
#End Region

#Region "เพิ่มข้อมูล"
    Private Sub add_exp()

        savestatus = "Add"

        If R3.Checked = False Then
            MessageBox.Show("กรุณาติ๊กเลือก วิทยากรภายนอก")
            Exit Sub
        End If

        sb = New StringBuilder
        sb.Append("select max (expert_id) from Expert where expert_id like '%T%' ")


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

        Dim ny As String = Now.Year '2019
        Dim y As String = ny.Substring(2, 2)  '19
        Dim m As String = (Now.Month).ToString("00")  '08

        If y = Lid Then 'ถ้าปีเท่ากัน
            If m = Mid Then 'ถ้าเดือนเท่ากัน
                newid = "T" & y & m & (CInt(Rid) + 1).ToString("000")
            Else   'ถ้าเดือนไม่เท่ากัน
                newid = "T" & y & m & "001"
            End If
        Else    'ถ้าปีไม่เท่ากัน
            newid = "T" & y & m & "001"
        End If

        cleardata()  '--F12
        txt_exp_id.Text = newid
        cn.Close()






        txt_exp_name.Focus()


    End Sub
#End Region

#Region "showdata"
    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from Expert"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "exp")
        '4.'
        datagrid_exp.DataSource = ds.Tables("exp")
        '5'
        cn.Close()

       



        datagrid_exp.AllowUserToAddRows = False
    End Sub

#End Region




    Private Sub edit_exp()
        savestatus = "Edit"
        If txt_exp_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_exp_id.Focus()
            Exit Sub
        End If

        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        Next
        txt_exp_name.Focus()
    End Sub

    Private Sub cleardata()
        txt_exp_department.Text = ""
        txt_exp_id.Text = ""
        txt_exp_name.Text = ""
        txt_exp_lastname.Text = ""
        txt_exp_position.Text = ""
        txt_expert_expertise.Text = ""
        txt_Search.Text = ""
        add_data.Enabled = False

        'R1.Checked = True
        'R2.Checked = False



    End Sub


    Private Sub Create_Expert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With datagrid_exp
            .Columns.Item(0).HeaderText = "รหัสวิทยากร"
            .Columns.Item(0).Width = "90"
            .Columns.Item(1).HeaderText = "ชื่อ"
            .Columns.Item(1).Width = "100"
            .Columns.Item(2).HeaderText = "นามสกุล"
            .Columns.Item(2).Width = "100"
            .Columns.Item(3).HeaderText = "ตำแหน่งวิทยากร"
            .Columns.Item(3).Width = "190"
            .Columns.Item(4).HeaderText = "หน่วยงานต้นสังกัด"
            .Columns.Item(4).Width = "170"
            .Columns.Item(5).HeaderText = "ความชำนาญ"
            .Columns.Item(5).Width = "200"



            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        End With

        showdata()
        R1.Checked = True
        add_data.Enabled = False
        clear_data.Enabled = False
        upte_data.Enabled = False
        edit_data.Enabled = False


    End Sub

    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_exp()
        upte_data.Enabled = True

    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_exp()
        upte_data.Enabled = True
        clear_data.Enabled = True
        add_data.Enabled = False
    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_exp()


        If savestatus = "Add" Then
            upte_data.Enabled = True
        ElseIf savestatus = "Edit" Then
            upte_data.Enabled = True
        Else
            cleardata()
            upte_data.Enabled = False
            cancel_data.Enabled = False
            add_data.Enabled = True
            edit_data.Enabled = False
        End If

       

    End Sub


    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

        R4.Checked = False
        cleardata()
        R4.Checked = False
        Search_emp.Enabled = False
        edit_data.Enabled = False
        upte_data.Enabled = False
        clear_data.Enabled = False
        R3.Checked = True

        showdata()


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Search_emp.Click

        cleardata()
        savestatus = "Add"
        txt_expert_expertise.Focus()

        Dim f As New frmNew_expert_In()
        f.MdiParent = HOMERPOGRAM
        f.StartPosition = FormStartPosition.Manual
        f.Left = 380 : f.Top = 50 : f.Show()

        

        'frmNew_expert_In.Show()

        ''เปิดฟอร์มโดยใช้ tap เป็นตัววางฟอร์ม
        'frmNew_expert_In.TopLevel = False
        'HOMERPOGRAM.TabPage1.Controls.Add(frmNew_expert_In)
        'frmNew_expert_In.Show()
        ''Me.Hide()

        'เปิดฟอร์มใหม่โด้ยการใช้ พาเนลเป็นตัววางฟอร์ม
        'frmNew_expert_In.TopLevel = False
        'HOMERPOGRAM.Panel1.Controls.Add(frmNew_expert_In)
        'frmNew_expert_In.Show()
        'Me.Hide()



    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles R4.CheckedChanged

        add_data.Enabled = False
        Search_emp.Enabled = True

    End Sub

    Private Sub txt_exp_id_TextChanged(sender As Object, e As EventArgs) Handles txt_exp_id.TextChanged


    End Sub

    Private Sub R1_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged

        showdata()
        cleardata()
        txt_Search.Text = ""
        txt_Search.Focus()

    End Sub

    Private Sub R2_CheckedChanged(sender As Object, e As EventArgs) Handles R2.CheckedChanged

        showdata()
        cleardata()
        txt_Search.Text = ""
        txt_Search.Focus()
    End Sub

    Private Sub R3_CheckedChanged(sender As Object, e As EventArgs) Handles R3.CheckedChanged

        Search_emp.Enabled = False
        add_data.Enabled = True


    End Sub

    Private Sub txt_exp_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_name.KeyPress

        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '     e.Handled = True
        ' End If

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

    Private Sub txt_exp_lastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_lastname.KeyPress

        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '    e.Handled = True
        'End If

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

    Private Sub txt_exp_position_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_position.KeyPress

        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '    e.Handled = True
        'End If

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

    Private Sub txt_exp_department_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_department.KeyPress

        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub txt_expert_expertise_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_expert_expertise.KeyPress

        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
        '    e.Handled = True
        'End If

    End Sub

    

    Private Sub txt_exp_name_TextChanged(sender As Object, e As EventArgs) Handles txt_exp_name.TextChanged

    End Sub

    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress

        If R1.Checked = True Then

            Select Case Asc(e.KeyChar)
                Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                    e.Handled = False
                Case 8, 13, 46, 70, 102, 84, 116 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                    e.Handled = False

                Case Else
                    e.Handled = True
                    MessageBox.Show("สามารถกดได้แค่ตัวเลข และ อักษร F, T")
            End Select

            txt_Search.MaxLength = 8

        Else

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
            txt_Search.MaxLength = 50
        End If



    End Sub

    
End Class