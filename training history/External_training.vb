Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class External_training

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""
    Dim num As Integer = 0
    Dim res As DialogResult

    Private Sub myMsg(msg As String, cap As String)
        Dim btn As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim ico As MessageBoxIcon = MessageBoxIcon.Question
        res = MessageBox.Show(msg, cap, btn, ico)
    End Sub


    Private Sub cmb_course()
        sql = "select course_name from Course "
        cmd_object(cmb_course_name)
    End Sub



    '#Region "เชื่อต่อ Data"

    '    Private Sub showdata()

    '        Dim cn As New SqlConnection(strConn)
    '        Dim s As String = ""
    '        '2.เขียน sql'
    '        s = "select * from External_training"
    '        '3'
    '        Dim da As New SqlDataAdapter(s, cn)
    '        Dim ds As New DataSet
    '        da.Fill(ds, "exter")
    '        '4.'
    '        datagrid_Extraining.DataSource = ds.Tables("exter")
    '        '5'
    '        cn.Close()

    '    End Sub
    '#End Region

#Region "เพิ่มข้อมูล"
    Private Sub add_trainningOut()


        savestatus = "Add"

        sb = New StringBuilder
        sb.Append("Select top 1 trainingEx_id From External_training ")
        sb.Append(" Order by trainingEx_id DESC")
        'sql = "select * From External_training Order by trainingEx_id DESC"

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        Dim cm As New SqlCommand(sb.ToString, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader

        Dim ny As String = Now.Year '2019
        Dim y As String = ny.Substring(2, 2)  '19
        Dim m As String = (Now.Month).ToString("00")  '08


        If dr.HasRows Then
            Do While (dr.Read())
                Dim oldid, Lid, Mid, Rid, newid As String

                'oldid = CStr(dr("trainingIn_id")) 'รหัสสุดท้าย 1908003 ทำได้สองแบบ

                oldid = dr.GetString(0)   'รหัสสุดท้าย 1908003
                Lid = oldid.Substring(0, 2)  '19
                Mid = oldid.Substring(2, 2)  '08
                Rid = oldid.Substring(oldid.Length - 3)   '003


                If y = Lid Then 'ถ้าปีเท่ากัน
                    If m = Mid Then 'ถ้าเดือนเท่ากัน
                        newid = y & m & (CInt(Rid) + 1).ToString("000")
                    Else   'ถ้าเดือนไม่เท่ากัน
                        newid = y & m & "001"
                    End If
                Else    'ถ้าปีไม่เท่ากัน
                    newid = y & m & "001"
                End If
                cleardata()
                txt_trainingOut_id.Text = newid
            Loop
        Else
            txt_trainingOut_id.Text = y & m & "001"
        End If


        dr.Close()
        cn.Close()
        'txt_trainingOut_id.Focus()


    End Sub
#End Region

#Region "แก้ไขข้อมูล"
    Private Sub edit_trainningOut()

        savestatus = "Edit"

        myMsg("ต้องการแก้ไขข้อมูลใช่หรือไม่", "ยืนยัน")
        If (res = Windows.Forms.DialogResult.No) Then Exit Sub


        If txt_trainingOut_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_trainingOut_name.Focus()
            Exit Sub
        End If

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        '---ลบรายการใน Expert_detail_in
        sb = New StringBuilder
        sb.Append("Delete From Expert_detail_out Where trainingEx_id= @trainingEx_id")
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_trainingOut_id.Text)
        End With
        cm.ExecuteNonQuery()

        '---ลบรายการใน Internal_training_history
        sb = New StringBuilder
        sb.Append("Delete From External_training_history Where trainingEx_id= @trainingEx_id")
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_trainingOut_id.Text)
        End With
        cm.ExecuteNonQuery()


        'Dim ctrl As Control
        'For Each ctrl In Me.Controls
        '    If ctrl.GetType Is GetType(TextBox) Then
        '        CType(ctrl, TextBox).ReadOnly = False
        '    End If
        'Next

    End Sub
#End Region

#Region "อัปเดตข้อมูล"
    Private Sub update_trainingOut()

        If txt_trainingOut_id.Text = "" Then
            MessageBox.Show("กรุณาเพื่มข้อมูลหรือค้นหาก่อน")
            Exit Sub
        End If

        If txt_trainingOut_name.Text = "" Then
            MsgBox("กรุณากรอกชื่อการจัดอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If cmb_course_name.Text = "" Then
            MsgBox("กรุณาเลือกหลักสูตรจัดอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        If txt_training_location.Text = "" Then
            MsgBox("กรุณากรอกสถานที่จัดอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If txt_long_term.Text = "" Then
            MsgBox("กรุณากรอกจำนวนวันอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If ListView1.Items.Count <= 0 Then
            MsgBox("กรุณาเลือกวิทยากรเข้าอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        If ListView2.Items.Count <= 0 Then
            MsgBox("กรุณาเลือกพนักงานเข้ารับการอบรม", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        If TextBox1.Text And TextBox2.Text And TextBox3.Text = "" Then
            MsgBox("กรุณากรอกค่าใช้จ่ายให้ครบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        If TextBox4.Text = "" Then
            MsgBox("กรุณากดคำนวนค่าใช้จ่ายทั้งหมด", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        sb = New StringBuilder

        If savestatus = "Add" Then
            sb.Append("Insert into  External_training (trainingEx_id,training_name,date,training_location,course_id,training_date,date_end,time_start,time_end)")
            sb.Append("Values (@trainingEx_id,@training_name,@date,@training_location,@course_id,@training_date,@date_end,@time_start,@time_end)")

        ElseIf savestatus = "Edit" Then
            sb.Append("Update External_training")
            sb.Append(" set training_name = @training_name,")
            sb.Append("date = @date,")
            sb.Append("training_location = @training_location,")
            sb.Append("course_id = @course_id,")
            sb.Append("training_date = @training_date,")
            sb.Append("date_end = @date_end,")
            sb.Append("time_start = @time_start,")
            sb.Append("time_end = @time_end ")
            sb.Append(" Where trainingEx_id = @trainingEx_id")

        End If

        Dim timest As String = ""
        Dim timeen As String = ""

        timest = cmd_start1.Text & ":" & cmd_start2.Text
        timeen = cmd_end1.Text & ":" & cmd_end2.Text


        Dim cm As New SqlCommand
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_trainingOut_id.Text
            .Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_trainingOut_name.Text
            .Add("@date", SqlDbType.Date).Value = Date_training.Text
            .Add("@training_location", SqlDbType.NVarChar, 50).Value = txt_training_location.Text
            .Add("@course_id", SqlDbType.Int).Value = txt_course_id.Text()
            .Add("@training_date", SqlDbType.NVarChar, 20).Value = txt_long_term.Text

            'ปรับเพิ่มวันเวลาที่ทำการไปอบรมเข้าไป
            .Add("@date_end", SqlDbType.Date).Value = Date_training_end.Text
            .Add("@time_start", SqlDbType.NVarChar, 5).Value = timest
            .Add("@time_end", SqlDbType.NVarChar, 5).Value = timeen
            cm.ExecuteNonQuery()
        End With


        'บันทึกข้อมูลเข้า รายละเอียดวิทยากรภายนอก
        For i As Integer = 0 To ListView1.Items.Count - 1
            '--2.SQL
            sb = New StringBuilder
            sb.Append("Insert into Expert_detail_out(trainingEx_id,expert_id)")
            sb.Append("Values (@trainingEx_id,@expert_id)")
            '--3.ส่งค่า
            cm = New SqlCommand(sb.ToString, cn)
            Dim lvRow As ListViewItem = ListView1.Items(i)
            With cm.Parameters
                .Clear()
                .Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_trainingOut_id.Text
                .Add("@expert_id", SqlDbType.NVarChar, 10).Value = lvRow.SubItems(1).Text
                
            End With
            '--4.รัน
            cm.ExecuteNonQuery()

        Next

        For i As Integer = 0 To ListView2.Items.Count - 1
            '--2.SQL
            sb = New StringBuilder
            sb.Append("Insert into External_training_history(trainingEx_id,emp_id)")
            sb.Append("Values (@trainingEx_id,@emp_id)")
            '--3.ส่งค่า
            cm = New SqlCommand(sb.ToString, cn)
            Dim lvRow As ListViewItem = ListView2.Items(i)
            With cm.Parameters
                .Clear()
                .Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_trainingOut_id.Text
                .Add("@emp_id", SqlDbType.NVarChar, 10).Value = lvRow.SubItems(1).Text

            End With
            '--4.รัน
            cm.ExecuteNonQuery()

        Next
        update_Expenses()
        savestatus = ""


    End Sub


    Private Sub update_Expenses()

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        sb = New StringBuilder

        If savestatus = "Add" Then
            sb.Append("Insert into  Expenses_out (trainingEx_id,Expert,Course,Travel_expenses,Total,Date_out)")
            sb.Append("Values (@trainingEx_id,@Expert,@Course,@Travel_expenses,@Total,@Date_out)")

        ElseIf savestatus = "Edit" Then
            sb.Append("Update Expenses_out")
            sb.Append(" set Expert = @Expert,")
            sb.Append("Course = @Course,")
            sb.Append("Travel_expenses = @Travel_expenses,")
            sb.Append("Total = @Total, ")
            sb.Append("Date_out = @Date_out ")
            sb.Append(" Where trainingEx_id = @trainingEx_id")

        End If


        Dim cmm As New SqlCommand
        cmm = New SqlCommand(sb.ToString, cn)
        With cmm.Parameters
            .Clear()
            .Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_trainingOut_id.Text
            .Add("@Expert", SqlDbType.Int).Value = TextBox1.Text
            .Add("@Course", SqlDbType.Int).Value = TextBox2.Text
            .Add("@Travel_expenses", SqlDbType.Int).Value = TextBox3.Text
            .Add("@Total", SqlDbType.Int).Value = TextBox4.Text
            .Add("@Date_out", SqlDbType.Date).Value = Date_training.Text
            cmm.ExecuteNonQuery()
        End With

        MsgBox("บันทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")

    End Sub






#End Region

#Region "cleardata"
    Private Sub cleardata()


        txt_trainingOut_id.Text = ""
        txt_trainingOut_name.Text = ""
        txt_course_id.Text = ""
        txt_long_term.Text = ""
        txt_Search.Text = ""
        cmb_course_name.Text = ""
        txt_training_location.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        'ปรับเพิ่มวันที่เวลาการอบรม
        Date_training.Text = Now.Date
        cmd_start1.Text = ""
        cmd_start2.Text = ""
        Date_training_end.Text = Now.Date
        cmd_end1.Text = ""
        cmd_end2.Text = ""

        ListView1.Items.Clear()
        ListView2.Items.Clear()
        numAEXO = 0
        numAEMO = 0
        



    End Sub
#End Region

    '#Region "คลิกเลือกข้อมูลใน datagrid"
    '    Private Sub datagrid_Extraining_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    '        Try
    '            Dim i As Integer = datagrid_Extraining.CurrentRow.Index
    '            txt_trainingOut_id.Text = datagrid_Extraining.Item(0, i).Value
    '            txt_trainingOut_name.Text = datagrid_Extraining.Item(1, i).Value
    '            Date_training.Text = datagrid_Extraining.Item(2, i).Value
    '            txt_training_location.Text = datagrid_Extraining.Item(3, i).Value
    '            txt_course_id.Text = datagrid_Extraining.Item(4, i).Value
    '            txt_long_term.Text = datagrid_Extraining.Item(5, i).Value

    '        Catch ex As Exception
    '            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

    '        End Try



    '    End Sub
    '#End Region

    '#Region "ค้นหา"
    '    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown

    '        If e.KeyCode = Keys.Enter Then
    '            '1
    '            Dim cn As New SqlConnection(strConn)
    '            '2
    '            Dim s, s1 As String
    '            If R1.Checked = True Then
    '                s1 = " trainingEx_id like @trainingEx_id"
    '            Else
    '                s1 = " training_name like @training_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
    '            End If
    '            s = "select * from External_training where " & s1
    '            '3
    '            With cn
    '                If .State = ConnectionState.Open Then .Close()
    '                .ConnectionString = strConn
    '                .Open()
    '            End With
    '            Dim CM As New SqlCommand(s, cn)
    '            Dim DR As SqlDataReader
    '            CM.Parameters.Clear()

    '            If R1.Checked = True Then
    '                CM.Parameters.Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_Search.Text & "%"
    '            Else
    '                CM.Parameters.Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_Search.Text & "%"
    '            End If
    '            DR = CM.ExecuteReader
    '            Dim dt As New DataTable
    '            dt.Load(DR)
    '            '4
    '            If (dt.Rows.Count = 0) Then
    '                MessageBox.Show("ไม่พบข้อมูล")
    '            Else
    '                With dt.Rows(0)
    '                    txt_trainingOut_id.Text = .Item(0).ToString
    '                    txt_trainingOut_name.Text = .Item(1).ToString
    '                    Date_training.Text = .Item(2).ToString
    '                    txt_training_location.Text = .Item(3).ToString
    '                    txt_course_id.Text = .Item(4).ToString
    '                    txt_long_term.Text = .Item(5).ToString



    '                    datagrid_Extraining.DataSource = dt
    '                End With
    '            End If

    '        End If
    '    End Sub
    '#End Region

    Private Sub External_traini_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With ListView1
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสวิทยากร", 80)
            .Columns.Add("ชื่อ", 100)
            .Columns.Add("นามสกุล", 100)
            .Columns.Add("ตำแหน่งวิทยากร", 140)
            .Columns.Add("หน่วยงานต้นสังกัด", 170)
            .Columns.Add("ความชำนาญ", 320)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With

        With ListView2
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสพนักงาน", 80)
            .Columns.Add("ชื่อ", 130)
            .Columns.Add("นามสกุล", 130)
            .Columns.Add("Level", 50)
            .Columns.Add("ตำแหน่งพนักงาน", 170)
            .Columns.Add("แผนก", 190)
            .Columns.Add("ฝ่าย", 160)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With

        'TextBox1.Text = ""
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        TextBox4.Text = ""
        upte_data.Enabled = False
        edit_data.Enabled = False
        cmb_course()
        'numAEXO = 0
        'numAEMO = 0



    End Sub

    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click
        If txt_trainingOut_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("Delete From Expert_detail_out Where trainingEx_id ='" & txt_trainingOut_id.Text & "'")
            SqlTable("Delete From External_training_history Where trainingEx_id ='" & txt_trainingOut_id.Text & "'")
            SqlTable("DELETE FROM Expenses_out  where trainingEx_id ='" & txt_trainingOut_id.Text & "'")
            SqlTable("DELETE FROM External_training  where trainingEx_id ='" & txt_trainingOut_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            'showdata()
            cleardata()
        End If

        upte_data.Enabled = False
        edit_data.Enabled = False
        clear_data.Enabled = False
        Button2.Enabled = False
        add_data_emp.Enabled = False

    End Sub



    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_trainningOut()
        upte_data.Enabled = True
        cancel_data.Enabled = True
        edit_data.Enabled = False
        add_data.Enabled = False
        Button2.Enabled = True
        add_data_emp.Enabled = True


    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_trainningOut()
        upte_data.Enabled = True
        edit_data.Enabled = False
        cancel_data.Enabled = False
        add_data.Enabled = False
        Button2.Enabled = True
        add_data_emp.Enabled = True


    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_trainingOut()
        'update_Expenses()

        If savestatus = "Add" Then
            upte_data.Enabled = True

        ElseIf savestatus = "Edit" Then
            upte_data.Enabled = True
        Else
            add_data_emp.Enabled = False
            Button2.Enabled = False
            upte_data.Enabled = False
            edit_data.Enabled = True
            add_data.Enabled = True
            cancel_data.Enabled = True
            numAEMO = 0
            numAEXO = 0
            
        End If
        


    End Sub

    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

        add_data_emp.Enabled = False
        Button2.Enabled = False
        upte_data.Enabled = False
        edit_data.Enabled = False
        clear_data.Enabled = False
        add_data.Enabled = True
        cleardata()
        cn.Close()
        'showdata()

    End Sub

    Private Sub cmb_course_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_course_name.SelectedIndexChanged


        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        s = "select course_id  from Course where course_name ='" & cmb_course_name.Text & "'"
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "cour")
        For Each dtr In ds.Tables("cour").Rows
            txt_course_id.Text = dtr("course_id")
        Next


    End Sub

    Private Sub txt_course_name_TextChanged(sender As Object, e As EventArgs) Handles txt_course_id.TextChanged

        
        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        s = "select course_name  from Course where course_id ='" & txt_course_id.Text & "'"
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "cour")
        For Each dtr In ds.Tables("cour").Rows
            cmb_course_name.Text = dtr("course_name")
        Next



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        frmExtermal_training.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmadd_Expert_out.MdiParent = HOMERPOGRAM
        frmadd_Expert_out.StartPosition = FormStartPosition.Manual
        frmadd_Expert_out.Left = 290
        frmadd_Expert_out.Top = 140
        frmadd_Expert_out.Show()

        'frmadd_Expert_out.Show()

    End Sub

    
    Private Sub add_data_emp_Click(sender As Object, e As EventArgs) Handles add_data_emp.Click

        courseID = txt_course_id.Text

        frmAdd_Employees_out.MdiParent = HOMERPOGRAM
        frmAdd_Employees_out.StartPosition = FormStartPosition.Manual
        frmAdd_Employees_out.Left = 290
        frmAdd_Employees_out.Top = 140
        frmAdd_Employees_out.Show()

        'frmAdd_Employees_out.Show()

    End Sub


#Region "ลบรายการสินค้าใน Listview"
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            ListView1.Items.Remove(lvi)
        Next
        numAEXO = 0
        For j As Integer = 0 To ListView1.Items.Count - 1
            numAEXO = numAEXO + 1
            ListView1.Items(j).SubItems(0).Text = numAEXO
        Next

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            ListView1.Items.Remove(lvi)
        Next


        numAEXO = 0
        For j As Integer = 0 To ListView1.Items.Count - 1
            numAEXO = numAEXO + 1
            ListView1.Items(j).SubItems(0).Text = numAEXO
        Next

    End Sub


    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick

        For i As Integer = 0 To ListView2.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView2.SelectedItems(i)
            ListView2.Items.Remove(lvi)
        Next
        numAEMO = 0
        For j As Integer = 0 To ListView2.Items.Count - 1
            numAEMO = numAEMO + 1
            ListView2.Items(j).SubItems(0).Text = numAEMO
        Next

    End Sub


    Private Sub clear_data_emp_Click(sender As Object, e As EventArgs) Handles clear_data_emp.Click

        For i As Integer = 0 To ListView2.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView2.SelectedItems(i)
            ListView2.Items.Remove(lvi)
        Next
        numAEMO = 0
        For j As Integer = 0 To ListView2.Items.Count - 1
            numAEMO = numAEMO + 1
            ListView2.Items(j).SubItems(0).Text = numAEMO
        Next

    End Sub

#End Region


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Panel1.Visible = True


        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from External_training"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "extra")
        '4.'
        datagrid_ExtrainingNew.DataSource = ds.Tables("extra")
        '5'
        cn.Close()

        With datagrid_ExtrainingNew
            .Columns.Item(0).HeaderText = "รหัสจัดอบรมภายใน"
            .Columns.Item(0).Width = "110"
            .Columns.Item(1).HeaderText = "ชื่อ"
            .Columns.Item(1).Width = "130"
            .Columns.Item(2).HeaderText = "สถานที่"
            .Columns.Item(2).Width = "130"
            .Columns.Item(3).HeaderText = "หลักสูตรการอบรม"
            .Columns.Item(3).Width = "90"
            .Columns.Item(4).HeaderText = "จำนวนวัน"
            .Columns.Item(4).Width = "90"

            .Columns.Item(5).HeaderText = "วันที่เริ่ม"
            .Columns.Item(5).Width = "110"
            .Columns.Item(6).HeaderText = "เวลาเริ่ม"
            .Columns.Item(6).Width = "110"
            .Columns.Item(7).HeaderText = "วันที่สิ้นสุด"
            .Columns.Item(7).Width = "110"
            .Columns.Item(8).HeaderText = "เวลาสิ้นสุด"
            .Columns.Item(8).Width = "110"

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

        End With


        datagrid_ExtrainingNew.AllowUserToAddRows = False
        txt_Search_panal.Text = ""
        RP1.Checked = True
        ''2.SQL
        'Dim s As String = ""
        's = "select * from External_training"
        ''3.Exe cm+dr
        'cn.Open()
        'Dim cm As New SqlCommand(s, cn)
        'Dim dr As SqlDataReader
        'dr = cm.ExecuteReader
        'Dim dt As New DataTable
        'dt.Load(dr)
        ''4.ดึง
        'datagrid_ExtrainingNew.DataSource = dt
        ''--5.ปิด
        'cn.Close()
    End Sub

#Region "ค้นหาจากพาเนล"
    Private Sub search_expert_panal()

        '--2.SQL
        sb = New StringBuilder
        sb.Append("Select * ")
        sb.Append("From Expert_detail_out EDO ")
        sb.Append("INNER JOIN External_training ET  ON (ET.trainingEx_id = EDO.trainingEx_id) ")
        sb.Append("INNER JOIN Expert EX  ON (EX.expert_id = EDO.expert_id) ")
        sb.Append("where EDO.trainingEx_id = @trainingEx_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_trainingOut_id.Text)
        End With
        dr = cm.ExecuteReader

        numAEXO = 0
        ListView1.Items.Clear()



        If dr.HasRows = True Then
            Do While dr.Read


                Dim LV1 As New ListViewItem
                LV1.UseItemStyleForSubItems = False
                numAEXO = numAEXO + 1
                LV1.Text = numAEXO
                LV1.SubItems.Add(dr.GetString(11))
                LV1.SubItems.Add(dr.GetString(12))
                LV1.SubItems.Add(dr.GetValue(13))
                LV1.SubItems.Add(dr.GetValue(14))
                LV1.SubItems.Add(dr.GetValue(15))
                LV1.SubItems.Add(dr.GetValue(16))
                ListView1.Items.Add(LV1)
                LV1 = Nothing


            Loop

        End If
    End Sub

    Private Sub search_employees_panal()

        '--2.SQL
        sb = New StringBuilder
        sb.Append("Select E.emp_id,E.emp_name,E.emp_lastname,emp_level,E.emp_position,")
        sb.Append("E.emp_department,E.emp_division ")
        sb.Append("From External_training_history ETH ")
        sb.Append("INNER JOIN External_training ET  ON (ET.trainingEx_id = ETH.trainingEx_id)")
        sb.Append("INNER JOIN Employees E  ON (E.emp_id = ETH.emp_id)")
        sb.Append("where ETH.trainingEx_id = @trainingEx_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_trainingOut_id.Text)
        End With
        dr = cm.ExecuteReader


        numAEMO = 0
        ListView2.Items.Clear()

        If dr.HasRows = True Then
            Do While dr.Read
                Dim LV2 As New ListViewItem
                LV2.UseItemStyleForSubItems = False
                numAEMO = numAEMO + 1
                LV2.Text = numAEMO
                LV2.SubItems.Add(dr.GetString(0))
                LV2.SubItems.Add(dr.GetString(1))
                LV2.SubItems.Add(dr.GetValue(2))
                LV2.SubItems.Add(dr.GetValue(3))
                LV2.SubItems.Add(dr.GetValue(4))
                LV2.SubItems.Add(dr.GetValue(5))
                LV2.SubItems.Add(dr.GetValue(6))
                ListView2.Items.Add(LV2)
                LV2 = Nothing


            Loop
        Else

            MessageBox.Show("ไม่พบข้อมูล")
            txt_Search.Clear()
        End If
    End Sub

    Private Sub search_Expenses_out_panal()

        sb = New StringBuilder
        sb.Append("select EO.Expert,EO.Course,EO.Travel_expenses,EO.Total ")
        sb.Append("from Expenses_out EO inner join External_training ET on EO.trainingEx_id = ET.trainingEx_id ")
        sb.Append(" where EO.trainingEx_id = @trainingEx_id")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_trainingOut_id.Text)
        End With
        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                TextBox1.Text = dr.GetInt32(0)
                TextBox2.Text = dr.GetInt32(1)
                TextBox3.Text = dr.GetInt32(2)
                TextBox4.Text = dr.GetInt32(3)




            Loop
        Else

            MessageBox.Show("ไม่พบข้อมูลค่าใช้จ่าย")
            txt_Search.Clear()
        End If


    End Sub


    Private Sub datagrid_ExtrainingNew_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_ExtrainingNew.CellClick


        If e.RowIndex < 0 Then Exit Sub
        With datagrid_ExtrainingNew.Rows(e.RowIndex)
            txt_trainingOut_id.Text = .Cells(0).Value.ToString
            txt_Search.Text = .Cells(0).Value.ToString
            txt_trainingOut_name.Text = .Cells(1).Value.ToString
            txt_training_location.Text = .Cells(2).Value.ToString
            txt_course_id.Text = .Cells(3).Value.ToString
            txt_long_term.Text = .Cells(4).Value.ToString

            'ปรับเพิ่มวันเวลาในการอบรม
            Date_training.Text = .Cells(5).Value.ToString
            cmd_start1.Text = .Cells(6).Value.Substring(0, 2)
            cmd_start2.Text = .Cells(6).Value.Substring(3, 2)
            Date_training_end.Text = .Cells(7).Value.ToString
            cmd_end1.Text = .Cells(8).Value.Substring(0, 2)
            cmd_end2.Text = .Cells(8).Value.Substring(3, 2)

        End With

        search_expert_panal()
        search_employees_panal()
        search_Expenses_out_panal()
        Panel1.Visible = False

        edit_data.Enabled = True
        clear_data.Enabled = True

    End Sub


#End Region


#Region "search"

    Private Sub search_expert()

        '--2.SQL
        sb = New StringBuilder
        sb.Append("Select * ")
        sb.Append("From Expert_detail_out EDO ")
        sb.Append("INNER JOIN External_training ET  ON (ET.trainingEx_id = EDO.trainingEx_id) ")
        sb.Append("INNER JOIN Expert EX  ON (EX.expert_id = EDO.expert_id) ")
        sb.Append("where EDO.trainingEx_id = @trainingEx_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_Search.Text)
        End With
        dr = cm.ExecuteReader

        numAEXO = 0
        ListView1.Items.Clear()


        If dr.HasRows = True Then
            Do While dr.Read
                txt_trainingOut_id.Text = dr.GetString(2)
                txt_trainingOut_name.Text = dr.GetString(3)
                txt_training_location.Text = dr.GetString(4)
                txt_course_id.Text = dr.GetString(5)
                txt_long_term.Text = dr.GetString(6)

                Date_training.Text = dr.GetDateTime(7)
                cmd_start1.Text = dr.GetString(8).Substring(0, 2)
                cmd_start2.Text = dr.GetString(8).Substring(3, 2)
                Date_training_end.Text = dr.GetDateTime(9)
                cmd_end1.Text = dr.GetString(10).Substring(0, 2)
                cmd_end2.Text = dr.GetString(10).Substring(3, 2)

                Dim LV1 As New ListViewItem
                LV1.UseItemStyleForSubItems = False
                numAEXO = numAEXO + 1
                LV1.Text = numAEXO
                LV1.SubItems.Add(dr.GetString(11))
                LV1.SubItems.Add(dr.GetString(12))
                LV1.SubItems.Add(dr.GetValue(13))
                LV1.SubItems.Add(dr.GetValue(14))
                LV1.SubItems.Add(dr.GetValue(15))
                LV1.SubItems.Add(dr.GetValue(16))
                ListView1.Items.Add(LV1)
                LV1 = Nothing


            Loop

        End If
    End Sub

    Private Sub search_employees()

        '--2.SQL
        sb = New StringBuilder
        sb.Append("Select E.emp_id,E.emp_name,E.emp_lastname,emp_level,E.emp_position,")
        sb.Append("E.emp_department,E.emp_division ")
        sb.Append("From External_training_history ETH ")
        sb.Append("INNER JOIN External_training ET  ON (ET.trainingEx_id = ETH.trainingEx_id)")
        sb.Append("INNER JOIN Employees E  ON (E.emp_id = ETH.emp_id)")
        sb.Append("where ETH.trainingEx_id = @trainingEx_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_Search.Text)
        End With
        dr = cm.ExecuteReader


        numAEMO = 0
        ListView2.Items.Clear()

        If dr.HasRows = True Then
            Do While dr.Read
                Dim LV2 As New ListViewItem
                LV2.UseItemStyleForSubItems = False
                numAEMO = numAEMO + 1
                LV2.Text = numAEMO
                LV2.SubItems.Add(dr.GetString(0))
                LV2.SubItems.Add(dr.GetString(1))
                LV2.SubItems.Add(dr.GetValue(2))
                LV2.SubItems.Add(dr.GetValue(3))
                LV2.SubItems.Add(dr.GetValue(4))
                LV2.SubItems.Add(dr.GetValue(5))
                LV2.SubItems.Add(dr.GetValue(6))
                ListView2.Items.Add(LV2)
                LV2 = Nothing


            Loop
        Else

            MessageBox.Show("ไม่พบข้อมูล")
            txt_Search.Clear()
        End If
    End Sub


    Private Sub search_Expenses_out()

        sb = New StringBuilder
        sb.Append("select EO.Expert,EO.Course,EO.Travel_expenses,EO.Total ")
        sb.Append("from Expenses_out EO inner join External_training ET on EO.trainingEx_id = ET.trainingEx_id ")
        sb.Append(" where EO.trainingEx_id = @trainingEx_id")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingEx_id", txt_Search.Text)
        End With
        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                TextBox1.Text = dr.GetInt32(0)
                TextBox2.Text = dr.GetInt32(1)
                TextBox3.Text = dr.GetInt32(2)
                TextBox4.Text = dr.GetInt32(3)




            Loop
        Else

            MessageBox.Show("ไม่พบข้อมูลค่าใช้จ่าย")
            txt_Search.Clear()
        End If


    End Sub

    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown





        If e.KeyCode = Keys.Enter Then



            search_expert()
            search_employees()
            search_Expenses_out()
            edit_data.Enabled = True
            cancel_data.Enabled = True
            clear_data.Enabled = True
            ''--2.SQL
            'sb = New StringBuilder
            'sb.Append("Select * ")
            'sb.Append("From Expert_detail_out EDO ")
            'sb.Append("INNER JOIN External_training ET  ON (ET.trainingEx_id=EDO.trainingEx_id) ")
            'sb.Append("INNER JOIN Expert EX  ON (EX.expert_id=EDO.expert_id) ")
            'sb.Append("where EDO.trainingEx_id = @trainingEx_id")


            'With cn
            '    If .State = ConnectionState.Open Then .Close()
            '    .ConnectionString = strConn
            '    .Open()
            '    End With

            'cm = New SqlCommand(sb.ToString, cn)
            'With cm.Parameters
            '    .Clear()
            '    .AddWithValue("@trainingEx_id", txt_Search.Text)
            '    End With
            'dr = cm.ExecuteReader

            'numAEXO = 0
            'numAEMO = 0
            'ListView1.Items.Clear()
            'ListView2.Items.Clear()

            'If dr.HasRows = True Then
            '    Do While dr.Read
            '        txt_trainingOut_id.Text = dr.GetString(2)
            '        txt_trainingOut_name.Text = dr.GetString(3)
            '        Date_training.Text = dr.GetDateTime(4)
            '        txt_training_location.Text = dr.GetString(5)
            '        txt_course_id.Text = dr.GetString(6)
            '        txt_long_term.Text = dr.GetString(7)



            '        Dim LV1 As New ListViewItem
            '        LV1.UseItemStyleForSubItems = False
            '        numAEXO = numAEXO + 1
            '        LV1.Text = numAEXO
            '        LV1.SubItems.Add(dr.GetString(8))
            '        LV1.SubItems.Add(dr.GetString(9))
            '        LV1.SubItems.Add(dr.GetValue(10))
            '        LV1.SubItems.Add(dr.GetValue(11))
            '        LV1.SubItems.Add(dr.GetValue(12))
            '        LV1.SubItems.Add(dr.GetValue(13))
            '        ListView1.Items.Add(LV1)
            '        LV1 = Nothing


            '    Loop
            'Else

            '    MessageBox.Show("ไม่พบข้อมูล")
            '    txt_Search.Clear()

            'End If


            cn.Close()

        End If

    End Sub

#End Region



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        Dim x1, x2, x3 As Integer

        If TextBox1.Text = "" Then
            TextBox1.Text = 0
        Else
            x1 = TextBox1.Text
        End If

        If TextBox2.Text = "" Then
            TextBox2.Text = 0
        Else
            x2 = TextBox2.Text
        End If

        If TextBox3.Text = "" Then
            TextBox3.Text = 0
        Else
            x3 = TextBox3.Text
        End If



        'x1 = TextBox1.Text
        'x2 = TextBox2.Text
        'x3 = TextBox3.Text

        TextBox4.Text = x1 + x2 + x3

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Visible = False
    End Sub

    Private Sub txt_Search_panal_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search_panal.KeyDown

        If e.KeyCode = Keys.Enter Then
            '1
            Dim cn As New SqlConnection(strConn)
            '2
            Dim s, s1 As String
            If RP1.Checked = True Then
                s1 = " trainingEx_id like @trainingEx_id"
            Else
                s1 = " training_name like @training_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
            End If
            s = "select * from External_training where " & s1
            '3
            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With
            Dim CM As New SqlCommand(s, cn)
            Dim DR As SqlDataReader
            CM.Parameters.Clear()

            If RP1.Checked = True Then
                CM.Parameters.Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_Search_panal.Text & "%"
            Else
                CM.Parameters.Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_Search_panal.Text & "%"
            End If
            DR = CM.ExecuteReader
            Dim dt As New DataTable
            dt.Load(DR)
            '4
            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                datagrid_ExtrainingNew.DataSource = dt

            End If

        End If


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from External_training"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "extra")
        '4.'
        datagrid_ExtrainingNew.DataSource = ds.Tables("extra")
        '5'
        cn.Close()

        txt_Search_panal.Text = ""

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        search_expert()
        search_employees()
        search_Expenses_out()
        edit_data.Enabled = True
        cancel_data.Enabled = True
        clear_data.Enabled = True

        cn.Close()

    End Sub

    
    Private Sub cmb_course_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_course_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_course_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_course_id.KeyPress
        e.Handled = True
    End Sub

    Private Sub txt_long_term_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_long_term.KeyPress

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

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

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

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

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

    Private Sub txt_Search_panal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search_panal.KeyPress

        If RP1.Checked = True Then


            Select Case Asc(e.KeyChar)

                Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                    e.Handled = False
                Case 8, 13, 46 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                    e.Handled = False

                Case Else
                    e.Handled = True
                    MessageBox.Show("สามารถกดได้แค่ตัวเลข")
            End Select

            txt_Search.MaxLength = 7

        Else

            Select Case Asc(e.KeyChar)

                Case 48 To 122 ' โค๊ดภาษาอังกฤษ์ตามจริงจะอยู่ที่ 58ถึง122 แต่ที่เอา 48มาเพราะเราต้องการตัวเลข
                    e.Handled = False
                Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                    e.Handled = False
                Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                    e.Handled = False
                Case Else
                    e.Handled = True
                    MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย")
            End Select
            txt_Search.MaxLength = 100
        End If

    End Sub

    Private Sub RP1_CheckedChanged(sender As Object, e As EventArgs) Handles RP1.CheckedChanged

        txt_Search_panal.Text = ""

    End Sub

    Private Sub RP2_CheckedChanged(sender As Object, e As EventArgs) Handles RP2.CheckedChanged

        txt_Search_panal.Text = ""

    End Sub

    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress

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

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick

        If TextBox1.Text = "" Then
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox1.Text = 0 Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick

        If TextBox2.Text = "" Then
            TextBox2.Focus()
            Exit Sub
        End If

        If TextBox2.Text = 0 Then
            TextBox2.Text = ""
        End If

    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick

        If TextBox3.Text = "" Then
            TextBox3.Focus()
            Exit Sub
        End If

        If TextBox3.Text = 0 Then
            TextBox3.Text = ""
        End If

    End Sub
End Class