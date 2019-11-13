Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

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



        End If

    End Sub
End Class