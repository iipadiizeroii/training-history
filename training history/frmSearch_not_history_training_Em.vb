Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSearch_not_history_training_Em
    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim at As New DataTable
    Dim savestatus As String

    Private Sub cmb_course()
        sql = "select course_name from Course "
        cmd_object(cmb_course_name)
    End Sub

    Private Sub cmb_department()
        sql = "select department_name from Department "
        cmd_object(cmb_department_name)
    End Sub

    Private Sub frmSearch_not_history_training_Em_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmb_department()
        cmb_course()


    End Sub

    Private Sub cmb_course_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_course_name.SelectedIndexChanged

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        s = "select course_id  from Course where course_name ='" & cmb_course_name.Text & "'"
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "courid")
        For Each dtr In ds.Tables("courid").Rows
            txt_Search_course_id.Text = dtr("course_id")
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click



        Dim cn As New SqlConnection(strConn)

        If cmb_course_name.Text = "" Then
            MsgBox("กรุณาเลือกหลักสูตร", MsgBoxStyle.Critical, "ผลการทำงาน")
            Print_Pr.Enabled = False
            Exit Sub
        End If

        If cmb_department_name.Text = "" Then
            MsgBox("กรุณาเลือกแผนก", MsgBoxStyle.Critical, "ผลการทำงาน")
            Print_Pr.Enabled = False
            Exit Sub
        End If


        If R1.Checked = True Then

            If cmb_department_name.Text = "" Then

                sb = New StringBuilder
                sb.Append("select emp_id,emp_name,emp_lastname,emp_level,emp_position,emp_department,emp_division ")
                sb.Append("from Employees ")
                sb.Append(" where emp_id in ")
                sb.Append("(Select E.emp_id ")
                sb.Append("from Employees E ")
                sb.Append("inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id )")
                sb.Append("inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id )")
                sb.Append(" where IT.course_id = @course_id )")



                With cn
                    If .State = ConnectionState.Open Then .Close()
                    .ConnectionString = strConn
                    .Open()
                End With

                cm = New SqlCommand(sb.ToString, cn)
                With cm.Parameters
                    .Clear()
                    .AddWithValue("@course_id", txt_Search_course_id.Text)

                End With
                dr = cm.ExecuteReader

                Dim dt As New DataTable
                dt.Load(dr)

                dgv_not_history_em.DataSource = dt

               

            Else



                sb = New StringBuilder
                sb.Append("select emp_id,emp_name,emp_lastname,emp_level,emp_position,emp_department,emp_division ")
                sb.Append("from Employees ")
                sb.Append(" where emp_department = @department and emp_id in ")
                sb.Append("(Select E.emp_id ")
                sb.Append("from Employees E ")
                sb.Append("inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id )")
                sb.Append("inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id )")
                sb.Append(" where IT.course_id = @course_id )")



                With cn
                    If .State = ConnectionState.Open Then .Close()
                    .ConnectionString = strConn
                    .Open()
                End With

                cm = New SqlCommand(sb.ToString, cn)
                With cm.Parameters
                    .Clear()
                    .AddWithValue("@course_id", txt_Search_course_id.Text)
                    .AddWithValue("@department", cmb_department_name.Text)
                End With
                dr = cm.ExecuteReader

                Dim dt As New DataTable
                dt.Load(dr)

                dgv_not_history_em.DataSource = dt


            End If

            dgv_not_history_em.AllowUserToAddRows = False

        Else

            If cmb_department_name.Text = "" Then

                sb = New StringBuilder
                sb.Append("select emp_id,emp_name,emp_lastname,emp_level,emp_position,emp_department,emp_division ")
                sb.Append("from Employees ")
                sb.Append("where emp_id not in ")
                sb.Append("(Select E.emp_id ")
                sb.Append("from Employees E ")
                sb.Append("inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id )")
                sb.Append("inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id )")
                sb.Append(" where IT.course_id = @course_id )")



                With cn
                    If .State = ConnectionState.Open Then .Close()
                    .ConnectionString = strConn
                    .Open()
                End With

                cm = New SqlCommand(sb.ToString, cn)
                With cm.Parameters
                    .Clear()
                    .AddWithValue("@course_id", txt_Search_course_id.Text)
                End With
                dr = cm.ExecuteReader

                Dim dt As New DataTable
                dt.Load(dr)

                dgv_not_history_em.DataSource = dt

               


            Else
                sb = New StringBuilder
                sb.Append("select emp_id,emp_name,emp_lastname,emp_level,emp_position,emp_department,emp_division ")
                sb.Append("from Employees ")
                sb.Append(" where  emp_department =  @department and  emp_id not in ")
                sb.Append("(Select E.emp_id ")
                sb.Append("from Employees E ")
                sb.Append("inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id )")
                sb.Append("inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id )")
                sb.Append(" where IT.course_id = @course_id )")



                With cn
                    If .State = ConnectionState.Open Then .Close()
                    .ConnectionString = strConn
                    .Open()
                End With

                cm = New SqlCommand(sb.ToString, cn)
                With cm.Parameters
                    .Clear()
                    .AddWithValue("@course_id", txt_Search_course_id.Text)
                    .AddWithValue("@department", cmb_department_name.Text)
                End With
                dr = cm.ExecuteReader

                Dim dt As New DataTable
                dt.Load(dr)

                dgv_not_history_em.DataSource = dt

            End If

           
            dgv_not_history_em.AllowUserToAddRows = False

           



        End If

        With dgv_not_history_em
            .Columns.Item(0).HeaderText = "รหัสพนักงาน"
            .Columns.Item(0).Width = "110"
            .Columns.Item(1).HeaderText = "ชื่อพนักงาน"
            .Columns.Item(1).Width = "100"
            .Columns.Item(2).HeaderText = "นามสกุล"
            .Columns.Item(2).Width = "100"
            .Columns.Item(3).HeaderText = "ระดับ"
            .Columns.Item(3).Width = "50"
            .Columns.Item(4).HeaderText = "ตำแหน่ง"
            .Columns.Item(4).Width = "130"
            .Columns.Item(5).HeaderText = "แผนก"
            .Columns.Item(5).Width = "130"
            .Columns.Item(6).HeaderText = "ฝ่าย"
            .Columns.Item(6).Width = "130"



            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        End With


        Print_Pr.Enabled = True


    End Sub

    Private Sub Print_Pr_Click(sender As Object, e As EventArgs) Handles Print_Pr.Click

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim x1 As String = ""




        If R1.Checked = True Then
            x1 = "พนักที่เข้ารับการอบรมแล้ว"
        Else
            x1 = "พนักงานที่ไม่ได้เข้ารับการอบรม"
        End If
        '*** Column ***'
        dt.Columns.Add("course_id")
        dt.Columns.Add("course_name")
        dt.Columns.Add("department")
        dt.Columns.Add("type_search")
        dt.Columns.Add("emp_id")
        dt.Columns.Add("emp_name")
        dt.Columns.Add("emp_lastname")
        dt.Columns.Add("emp_level")
        dt.Columns.Add("emp_position")
        dt.Columns.Add("emp_department")


        For Each dgv As DataGridViewRow In dgv_not_history_em.Rows()
            '*** Rows ***'
            dr = dt.NewRow

            dr("course_id") = txt_Search_course_id.Text.ToString
            dr("course_name") = cmb_course_name.Text.ToString
            dr("department") = cmb_department_name.Text.ToString
            dr("type_search") = x1.ToString
            dr("emp_id") = dgv.Cells(0).Value
            dr("emp_name") = dgv.Cells(1).Value
            dr("emp_lastname") = dgv.Cells(2).Value
            dr("emp_level") = dgv.Cells(3).Value
            dr("emp_position") = dgv.Cells(4).Value
            dr("emp_department") = dgv.Cells(5).Value

            dt.Rows.Add(dr)
        Next

        Dim rpt As New ReportDocument()
        Dim directory As String = My.Application.Info.DirectoryPath
        'rpt.Load(directory & "\myCrystalReport1.rpt")
        rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\PR_Search_not_history_training_Em.rpt")
        rpt.SetDataSource(dt)
        test_Print.CrystalReportViewer1.ReportSource = rpt
        test_Print.CrystalReportViewer1.Refresh()

        test_Print.Show()

    End Sub

    Private Sub cmb_course_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_course_name.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmb_department_name_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_department_name.KeyPress
        e.Handled = True
    End Sub
End Class