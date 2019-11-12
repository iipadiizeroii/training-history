Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

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




    End Sub

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


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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
        dgv_history_em.DataSource = ds.Tables
       


    End Sub

    Private Sub frmSearch_history_training_Em_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel1.Visible = False

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

   
End Class