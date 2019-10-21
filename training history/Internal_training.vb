Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class Internal_training
    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""
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
    '        s = "select * from Internal_training"
    '        '3'
    '        Dim da As New SqlDataAdapter(s, cn)
    '        Dim ds As New DataSet
    '        da.Fill(ds, "intra")
    '        '4.'
    '        datagrid_Intraining.DataSource = ds.Tables("intra")
    '        '5'
    '        cn.Close()

    '    End Sub
    '#End Region

#Region "เพิ่มข้อมูล"

    Private Sub add_trainning()

        savestatus = "Add"

        sb = New StringBuilder
        sb.Append("Select top 1 trainingIn_id From Internal_training ")
        sb.Append(" Order by trainingIn_id DESC")
        'sql = "Select top 1 trainingIn_id From Internal_training Order by trainingIn_id DESC "

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
                txt_trainingIn_id.Text = newid
            Loop
        Else
            txt_trainingIn_id.Text = y & m & "001"
        End If

        dr.Close()
        cn.Close()
        txt_trainingIn_id.Focus()


    End Sub
#End Region

#Region "แก้ไขข้อมูล"
    Private Sub edit_trainning()

        savestatus = "Edit"

        myMsg("ต้องการแก้ไขข้อมูลใช่หรือไม่", "ยืนยัน")
        If (res = Windows.Forms.DialogResult.No) Then Exit Sub


        If txt_trainingIn_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_Search.Focus()
            Exit Sub
        End If

        'Dim ctrl As Control
        'For Each ctrl In Me.Controls
        '    If ctrl.GetType Is GetType(TextBox) Then
        '        CType(ctrl, TextBox).ReadOnly = False
        '    End If
        'Next


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        '---ลบรายการใน Expert_detail_in
        sb = New StringBuilder
        sb.Append("Delete From Expert_detail_in Where trainingIn_id= @trainingIn_id")
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingIn_id", txt_trainingIn_id.Text)
        End With
        cm.ExecuteNonQuery()

        '---ลบรายการใน Internal_training_history
        sb = New StringBuilder
        sb.Append("Delete From Internal_training_history Where trainingIn_id= @trainingIn_id")
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingIn_id", txt_trainingIn_id.Text)
        End With
        cm.ExecuteNonQuery()



    End Sub
#End Region

#Region "อัปเดตข้อมูล"
    Private Sub update_training()

        If txt_trainingIn_id.Text = "" Then
            MessageBox.Show("กรุณาเพื่มข้อมูลหรือค้นหาก่อน")
            Exit Sub
        End If
        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        sb = New StringBuilder


        If savestatus = "Add" Then
            sb.Append("Insert into  Internal_training (trainingIn_id,training_name,date,training_location,course_id,training_date)")
            sb.Append("Values (@trainingIn_id,@training_name,@date,@training_location,@course_id,@training_date)")

        ElseIf savestatus = "Edit" Then
            sb.Append("Update Internal_training")
            sb.Append(" set training_name = @training_name,")
            sb.Append("date = @date,")
            sb.Append("training_location = @training_location,")
            sb.Append("course_id = @course_id,")
            sb.Append("training_date = @training_date ")
            sb.Append(" Where trainingIn_id = @trainingIn_id")

        End If


        Dim cm As New SqlCommand
        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .Add("@trainingIn_id", SqlDbType.NVarChar, 10).Value = txt_trainingIn_id.Text
            .Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_trainingIn_name.Text
            .Add("@date", SqlDbType.Date).Value = Date_training.Text
            .Add("@training_location", SqlDbType.NVarChar, 50).Value = cmb_training_location.Text
            .Add("@course_id", SqlDbType.Int).Value = txt_course_id.Text
            .Add("@training_date", SqlDbType.NVarChar, 20).Value = txt_long_term.Text

        End With
        cm.ExecuteNonQuery()

        'บันทึกข้อมูลเข้า รายละเอียดวิทยากรภายนอก
        For i As Integer = 0 To ListView1.Items.Count - 1
            '--2.SQL
            sb = New StringBuilder
            sb.Append("Insert into Expert_detail_in(trainingIn_id,expert_id)")
            sb.Append("Values (@trainingIn_id,@expert_id)")
            '--3.ส่งค่า
            cm = New SqlCommand(sb.ToString, cn)
            Dim lvRow As ListViewItem = ListView1.Items(i)
            With cm.Parameters
                .Clear()
                .Add("@trainingIn_id", SqlDbType.NVarChar, 10).Value = txt_trainingIn_id.Text
                .Add("@expert_id", SqlDbType.NVarChar, 10).Value = lvRow.SubItems(1).Text

            End With
            '--4.รัน
            cm.ExecuteNonQuery()

        Next

        For i As Integer = 0 To ListView2.Items.Count - 1
            '--2.SQL
            sb = New StringBuilder
            sb.Append("Insert into Internal_training_history(trainingIn_id,emp_id)")
            sb.Append("Values (@trainingIn_id,@emp_id)")
            '--3.ส่งค่า
            cm = New SqlCommand(sb.ToString, cn)
            Dim lvRow As ListViewItem = ListView2.Items(i)
            With cm.Parameters
                .Clear()
                .Add("@trainingIn_id", SqlDbType.NVarChar, 10).Value = txt_trainingIn_id.Text
                .Add("@emp_id", SqlDbType.NVarChar, 10).Value = lvRow.SubItems(1).Text

            End With
            '--4.รัน
            cm.ExecuteNonQuery()

        Next
        MsgBox("บัยทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
        'showdata()





    End Sub
#End Region



#Region "cleardata"
    Private Sub cleardata()

        txt_trainingIn_id.Text = ""
        txt_trainingIn_name.Text = ""
        txt_course_id.Text = ""
        txt_long_term.Text = ""
        txt_Search.Text = ""
        cmb_course_name.Text = ""
        cmb_training_location.Text = ""
        numAEXI = 0
        numAEMO = 0
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        R1.Checked = False
        R2.Checked = False



    End Sub
#End Region

    '#Region "คลิกเลือกข้อมูลใน datagrid"
    '    Private Sub datagrid_Intraining_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    '        Try
    '            Dim i As Integer = datagrid_Intraining.CurrentRow.Index
    '            txt_trainingIn_id.Text = datagrid_Intraining.Item(0, i).Value
    '            txt_trainingIn_name.Text = datagrid_Intraining.Item(1, i).Value
    '            Date_training.Text = datagrid_Intraining.Item(2, i).Value
    '            cmb_training_location.Text = datagrid_Intraining.Item(3, i).Value
    '            txt_course_id.Text = datagrid_Intraining.Item(4, i).Value
    '            txt_long_term.Text = datagrid_Intraining.Item(5, i).Value

    '        Catch ex As Exception
    '            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

    '        End Try



    '    End Sub
    '#End Region



    Private Sub Internal_training_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With ListView1
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสวิทยากร", 80)
            .Columns.Add("ชื่อ", 100)
            .Columns.Add("นามสกุล", 100)
            .Columns.Add("ตำแหน่งวิทยากร", 120)
            .Columns.Add("หน่วยงานต้นสังกัด", 120)
            .Columns.Add("ความชำนาญ", 130)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With

        With ListView2
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสพนักงาน", 80)
            .Columns.Add("ชื่อ", 100)
            .Columns.Add("นามสกุล", 100)
            .Columns.Add("Level", 50)
            .Columns.Add("ตำแหน่งพนักงาน", 120)
            .Columns.Add("แผนก", 130)
            .Columns.Add("ฝ่าย", 130)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With

        'showdata()
        cmb_course()

        'test

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_trainning()
        upte_data.Enabled = True

    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_trainning()
        upte_data.Enabled = True
    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_training()
        upte_data.Enabled = False
        numAEMO = 0
        numAEXI = 0

    End Sub

    Private Sub cmb_course_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_course_name.SelectedIndexChanged

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        s = "select course_id  from Course where course_name ='" & cmb_course_name.Text & "'"
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "courid")
        For Each dtr In ds.Tables("courid").Rows
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

    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click

        If txt_trainingIn_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("Delete From Expert_detail_in Where trainingIn_id ='" & txt_trainingIn_id.Text & "'")
            SqlTable("Delete From Internal_training_history Where trainingIn_id ='" & txt_trainingIn_id.Text & "'")
            SqlTable("DELETE FROM Internal_training  where trainingIn_id ='" & txt_trainingIn_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            'showdata()
            cleardata()
        End If

    End Sub

    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

        cleardata()
        cn.Close()
        'showdata()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frmInternal_training.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmAdd_Expert_in.Show()

    End Sub

    Private Sub add_data_emp_Click(sender As Object, e As EventArgs) Handles add_data_emp.Click


        courseID = txt_course_id.Text
        emio = "IN"
        frmAdd_Employees_out.Show()


    End Sub

#Region "ลบข้อมูลจาก Listview"
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            ListView1.Items.Remove(lvi)
        Next
        numAEXI = 0
        For j As Integer = 0 To ListView1.Items.Count - 1
            numAEXI = numAEXI + 1
            ListView1.Items(j).SubItems(0).Text = numAEXI
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


#End Region

    Private Sub search_expert()

        '--2.SQL
        sb = New StringBuilder
        sb.Append("Select * ")
        sb.Append("From Expert_detail_in EDI ")
        sb.Append("INNER JOIN Internal_training IT  ON (IT.trainingIn_id = EDI.trainingIn_id) ")
        sb.Append("INNER JOIN Expert EX  ON (EX.expert_id = EDI.expert_id) ")
        sb.Append("where EDI.trainingIn_id = @trainingIn_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingIn_id", txt_Search.Text)
        End With
        dr = cm.ExecuteReader

        numAEXO = 0
        ListView1.Items.Clear()


        If dr.HasRows = True Then
            Do While dr.Read
                txt_trainingIn_id.Text = dr.GetString(2)
                txt_trainingIn_name.Text = dr.GetString(3)
                Date_training.Text = dr.GetDateTime(4)
                cmb_training_location.Text = dr.GetString(5)
                txt_course_id.Text = dr.GetString(6)
                txt_long_term.Text = dr.GetString(7)



                Dim LV1 As New ListViewItem
                LV1.UseItemStyleForSubItems = False
                numAEXO = numAEXO + 1
                LV1.Text = numAEXO
                LV1.SubItems.Add(dr.GetString(8))
                LV1.SubItems.Add(dr.GetString(9))
                LV1.SubItems.Add(dr.GetValue(10))
                LV1.SubItems.Add(dr.GetValue(11))
                LV1.SubItems.Add(dr.GetValue(12))
                LV1.SubItems.Add(dr.GetValue(13))
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
        sb.Append("From Internal_training_history ITH ")
        sb.Append("INNER JOIN Internal_training IT  ON (IT.trainingIn_id = ITH.trainingIn_id)")
        sb.Append("INNER JOIN Employees E  ON (E.emp_id = ITH.emp_id)")
        sb.Append("where ITH.trainingIn_id = @trainingIn_id")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@trainingIn_id", txt_Search.Text)
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

    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown


        If e.KeyCode = Keys.Enter Then


            search_expert()
            search_employees()

            edit_data.Enabled = True
            cancel_data.Enabled = True
            clear_data.Enabled = True

        End If


        For i As Integer = 0 To ListView1.Items.Count
            numAEXI = i
        Next

        For ii As Integer = 0 To ListView2.Items.Count
            numAEMO = ii
        Next

        


    End Sub

    
End Class