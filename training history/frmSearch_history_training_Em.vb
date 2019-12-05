Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSearch_history_training_Em

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim cn As New SqlConnection(strConn)

        If txt_Search.Text <> "" Then
            sb = New StringBuilder
            sb.Append("select emp_name , emp_department from Employees where emp_id = @empid")


            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With

            cm = New SqlCommand(sb.ToString, cn)
            With cm.Parameters
                .Clear()
                .AddWithValue("@empid", txt_Search.Text)
            End With
            dr = cm.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)

            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                With dt.Rows(0)
                    txt_Search_name.Text = .Item(0).ToString
                    txt_Search_depart.Text = .Item(1).ToString

                End With
            End If
        End If



        '2

        If R1.Checked = True Then
            sb = New StringBuilder
            sb.Append("select C.course_id,C.course_name,f.format_name,g.group_name,T.type_name ")
            sb.Append("from Course C ")
            sb.Append("inner join format_course F on F.format_id = C.format_id ")
            sb.Append("inner join group_course G on G.group_id = C.group_id ")
            sb.Append("inner join type_course T on t.type_id = C.type_id ")
            sb.Append(" where C.course_id in ")
            sb.Append("(select it.course_id ")
            sb.Append("from Internal_training IT ")
            sb.Append("inner join Internal_training_history ITH on (ITH.trainingIn_id = it.trainingIn_id) ")
            sb.Append("inner join Employees E on (ITH.emp_id = E.emp_id) ")
            sb.Append(" where E.emp_id = @empin_id)")



            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With

            cm = New SqlCommand(sb.ToString, cn)
            With cm.Parameters
                .Clear()
                .AddWithValue("@empin_id", txt_Search.Text)
            End With
            dr = cm.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)

            dgv_history_em.DataSource = dt



        Else

            sb = New StringBuilder
            sb.Append("select C.course_id,C.course_name,f.format_name,g.group_name,T.type_name ")
            sb.Append("from Course C ")
            sb.Append("inner join format_course F on F.format_id = C.format_id ")
            sb.Append("inner join group_course G on G.group_id = C.group_id ")
            sb.Append("inner join type_course T on t.type_id = C.type_id ")
            sb.Append(" where C.course_id in ")
            sb.Append("(select ET.course_id ")
            sb.Append("from External_training ET ")
            sb.Append("inner join External_training_history ETH on (ETH.trainingEx_id = Et.trainingEx_id) ")
            sb.Append("inner join Employees E on (ETH.emp_id = E.emp_id) ")
            sb.Append(" where E.emp_id = @empin_id)")





            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With

            cm = New SqlCommand(sb.ToString, cn)
            With cm.Parameters
                .Clear()
                .AddWithValue("@empin_id", txt_Search.Text)
            End With
            dr = cm.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)

            dgv_history_em.DataSource = dt


        End If
        With dgv_history_em
            .Columns("course_id").HeaderText = "รหัสหลักสูตร"
            .Columns("course_id").Width = "100"
            .Columns("course_name").HeaderText = "ชื่อหลักสูตรการอบรม"
            .Columns("course_name").Width = "160"
            .Columns("format_name").HeaderText = "รูปแบบการจัดอบรม"
            .Columns("format_name").Width = "120"
            .Columns("group_name").HeaderText = "กลุ่มหลักสูตร"
            .Columns("group_name").Width = "100"
            .Columns("type_name").HeaderText = "ประเภทการจัดอบรม"
            .Columns("type_name").Width = "130"


            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable


        End With



        dgv_history_em.AllowUserToAddRows = False
        Print_Pr.Enabled = True

    End Sub


#Region "อยู่ใน Panal"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Employees Where emp_id LIKE '%" & txt_Search_id_panal.Text & "%' AND emp_name LIKE '%" & txt_Search_name_panal.Text & "%' AND emp_department LIKE '%" & txt_Search_depart_panal.Text & "%' ")
        With PN_dgv_em
            .DataSource = DataShow
            .Columns("emp_id").HeaderText = "รหัสพนักงาน"
            .Columns("emp_id").Width = "110"
            .Columns("emp_name").HeaderText = "ชื่อพนักงาน"
            .Columns("emp_name").Width = "100"
            .Columns("emp_lastname").HeaderText = "นามสกุล"
            .Columns("emp_lastname").Width = "100"
            .Columns("emp_level").HeaderText = "ระดับ"
            .Columns("emp_level").Width = "50"
            .Columns("emp_position").HeaderText = "ตำแหน่ง"
            .Columns("emp_position").Width = "130"
            .Columns("emp_department").HeaderText = "แผนก"
            .Columns("emp_department").Width = "130"
            .Columns("emp_division").HeaderText = "ฝ่าย"
            .Columns("emp_division").Width = "130"
            .Columns("emp_degree").HeaderText = "การศึกษา"
            .Columns("emp_degree").Width = "130"
            .Columns("emp_date").HeaderText = "วันที่เริ่มงาน"
            .Columns("emp_date").Width = "130"

            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        End With

        PN_dgv_em.AllowUserToAddRows = False


    End Sub

    Private Sub PN_dgv_em_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PN_dgv_em.CellClick

        If e.RowIndex < 0 Then Exit Sub
        With PN_dgv_em.Rows(e.RowIndex)
            txt_Search.Text = .Cells(0).Value.ToString
            txt_Search_name.Text = .Cells(1).Value.ToString
            txt_Search_depart.Text = .Cells(5).Value.ToString

        End With




        Panel1.Visible = False

    End Sub

#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Print_Pr.Enabled = False
        Panel1.Visible = True

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from Employees"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "em")
        '4.'
        PN_dgv_em.DataSource = ds.Tables("em")
        '5'
        cn.Close()

        With PN_dgv_em
            .Columns("emp_id").HeaderText = "รหัสพนักงาน"
            .Columns("emp_id").Width = "110"
            .Columns("emp_name").HeaderText = "ชื่อพนักงาน"
            .Columns("emp_name").Width = "100"
            .Columns("emp_lastname").HeaderText = "นามสกุล"
            .Columns("emp_lastname").Width = "100"
            .Columns("emp_level").HeaderText = "ระดับ"
            .Columns("emp_level").Width = "50"
            .Columns("emp_position").HeaderText = "ตำแหน่ง"
            .Columns("emp_position").Width = "130"
            .Columns("emp_department").HeaderText = "แผนก"
            .Columns("emp_department").Width = "130"
            .Columns("emp_division").HeaderText = "ฝ่าย"
            .Columns("emp_division").Width = "130"
            .Columns("emp_degree").HeaderText = "การศึกษา"
            .Columns("emp_degree").Width = "130"
            .Columns("emp_date").HeaderText = "วันที่เริ่มงาน"
            .Columns("emp_date").Width = "130"



            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable


        End With

        txt_Search_id_panal.Text = ""
        txt_Search_name_panal.Text = ""
        txt_Search_depart_panal.Text = ""
        PN_dgv_em.AllowUserToAddRows = False
        dgv_history_em.DataSource = ds.Tables



    End Sub

    Private Sub frmSearch_history_training_Em_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel1.Visible = False

    End Sub

    Private Sub Print_Pr_Click(sender As Object, e As EventArgs) Handles Print_Pr.Click

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim x1 As String = ""



        If R1.Checked = True Then
            x1 = "การอบรมภายใน"
        Else
            x1 = "การอบรมภายนอก"
        End If
        '*** Column ***'
        dt.Columns.Add("emp_id")
        dt.Columns.Add("emp_name")
        dt.Columns.Add("emp_department")
        dt.Columns.Add("type_training")
        dt.Columns.Add("course_id")
        dt.Columns.Add("course_name")
        dt.Columns.Add("format_name")
        dt.Columns.Add("group_name")
        dt.Columns.Add("type_name")



        For Each dgv As DataGridViewRow In dgv_history_em.Rows()
            '*** Rows ***'
            dr = dt.NewRow

            dr("emp_id") = txt_Search.Text.ToString
            dr("emp_name") = txt_Search_name.Text.ToString
            dr("emp_department") = txt_Search_depart.Text.ToString
            dr("type_training") = x1.ToString
            dr("course_id") = dgv.Cells(0).Value
            dr("course_name") = dgv.Cells(1).Value
            dr("format_name") = dgv.Cells(2).Value
            dr("group_name") = dgv.Cells(3).Value
            dr("type_name") = dgv.Cells(4).Value

            dt.Rows.Add(dr)
        Next

        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\PR_Search_history_training_Em.rpt")
        rpt.SetDataSource(dt)
        test_Print.CrystalReportViewer1.ReportSource = rpt
        test_Print.CrystalReportViewer1.Refresh()

        test_Print.Show()



    End Sub

    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                e.Handled = False
            Case 8, 13, 46, 70, 102, 89, 121 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                e.Handled = False

            Case Else
                e.Handled = True
                MessageBox.Show("สามารถกดได้แค่ตัวเลข และ อักษร F, Y")
        End Select

    End Sub



    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown


        If e.KeyCode = Keys.Enter Then

            'If (txt_Search.MaxLength < 8) Then
            '    MessageBox.Show("กรุณากรอกรหัสพนักงานให้ครบ 8 หลัก")
            '    Exit Sub
            'End If

            sb = New StringBuilder
            sb.Append("select emp_name , emp_department from Employees where emp_id = @empid")


            With cn
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = strConn
                .Open()
            End With

            cm = New SqlCommand(sb.ToString, cn)
            With cm.Parameters
                .Clear()
                .AddWithValue("@empid", txt_Search.Text)
            End With
            dr = cm.ExecuteReader

            Dim dt As New DataTable
            dt.Load(dr)

            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                With dt.Rows(0)
                    txt_Search_name.Text = .Item(0).ToString
                    txt_Search_depart.Text = .Item(1).ToString

                End With
            End If
        End If

    End Sub

    Private Sub txt_Search_id_panal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search_id_panal.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                e.Handled = False
            Case 8, 13, 46, 70, 102, 89, 121 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                e.Handled = False

            Case Else
                e.Handled = True
                MessageBox.Show("สามารถกดได้แค่ตัวเลข และ อักษร F, Y")
        End Select

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Panel1.Visible = False

    End Sub

    Private Sub txt_Search_name_panal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search_name_panal.KeyPress

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

    Private Sub txt_Search_depart_panal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search_depart_panal.KeyPress

        Select Case Asc(e.KeyChar)
            'Case 48 To 57 ' ตรงนี้คือโค๊ดตัวเลขน่ะครับเราตัดโค๊ด58-122ออกไป
            '    e.Handled = False
            Case 8, 13, 46 ' Backspace = 8, Enter = 13, Delete = 46
                e.Handled = False
            Case 161 To 240 ' แล้วมาใส่ตรงนี้เป็นคีย์โค๊ดภาษาไทยรวมทั้งตัวสระ+วรรณยุกต์ด้วยน่ะครับ
                e.Handled = False
            Case Else
                e.Handled = True
                MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาไทย")
        End Select
    End Sub
End Class