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

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        savestatus = "Add"
        sql = "select * From External_training Order by trainingEx_id DESC"
        Dim cm As New SqlCommand(sql, cn)
        Dim dr As SqlDataReader
        dr = cm.ExecuteReader

        cn.Close()
        txt_trainingOut_id.Focus()


    End Sub
#End Region

#Region "แก้ไขข้อมูล"
    Private Sub edit_trainningOut()

        savestatus = "Edit"
        If txt_trainingOut_id.Text.Trim = "" Then
            MessageBox.Show("กรุณาค้นหารหัสที่ต้องการก่อน")
            txt_trainingOut_name.Focus()
            Exit Sub
        End If

        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If ctrl.GetType Is GetType(TextBox) Then
                CType(ctrl, TextBox).ReadOnly = False
            End If
        Next

    End Sub
#End Region

#Region "อัปเดตข้อมูล"
    Private Sub update_trainingOut()

        If txt_trainingOut_id.Text = "" Then
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
            sb.Append("Insert into  External_training (trainingEx_id,training_name,date,training_location,course_id,training_date)")
            sb.Append("Values (@trainingEx_id,@training_name,@date,@training_location,@course_id,@training_date)")

        ElseIf savestatus = "Edit" Then
            sb.Append("Update External_training")
            sb.Append(" set training_name = @training_name,")
            sb.Append("date = @date,")
            sb.Append("training_location = @training_location,")
            sb.Append("course_id = @course_id,")
            sb.Append("training_date = @training_date ")
            sb.Append(" Where trainingEx_id = @trainingEx_id")

        End If

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

        End With
        cm.ExecuteNonQuery()

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
        MsgBox("บัยทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")


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
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        R1.Checked = False
        R2.Checked = False



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

        cmb_course()
        


    End Sub

    Private Sub clear_data_Click(sender As Object, e As EventArgs) Handles clear_data.Click
        If txt_trainingOut_id.Text = "" Then
            MsgBox("กรุณาเลือกข้อมูลที่ต้องการลบ", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If
        If MessageBox.Show("ต้องการลบข้อมูลใช่หรือไม่ ? ", "ยืนยันการลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SqlTable("DELETE FROM External_training  where trainingEx_id ='" & txt_trainingOut_id.Text & "'")
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            'showdata()
            cleardata()
        End If
    End Sub



    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_trainningOut()

    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_trainningOut()

    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_trainingOut()

    End Sub

    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frmExtermal_training.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmadd_Expert_out.Show()

    End Sub

    
    Private Sub add_data_emp_Click(sender As Object, e As EventArgs) Handles add_data_emp.Click


        frmAdd_Employees_out.Show()

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

   
    Private Sub datagrid_ExtrainingNew_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_ExtrainingNew.CellClick


        If e.RowIndex < 0 Then Exit Sub
        With datagrid_ExtrainingNew.Rows(e.RowIndex)
            txt_trainingOut_id.Text = .Cells(0).Value.ToString
            txt_trainingOut_name.Text = .Cells(1).Value.ToString
            Date_training.Text = .Cells(2).Value.ToString
            txt_training_location.Text = .Cells(3).Value.ToString
            txt_course_id.Text = .Cells(4).Value.ToString
            txt_long_term.Text = .Cells(5).Value.ToString
            txt_Search.Text = .Cells(0).Value.ToString
        End With


        Panel1.Visible = False

    End Sub

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
                Date_training.Text = dr.GetDateTime(4)
                txt_training_location.Text = dr.GetString(5)
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

    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown





        If e.KeyCode = Keys.Enter Then



            search_expert()
            search_employees()

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

    


End Class