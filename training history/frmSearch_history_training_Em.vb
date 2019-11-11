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

#Region "showdata"
    Private Sub showdata()


        sb = New StringBuilder
        sb.Append("select C.course_id,C.course_name,f.format_name,g.group_name,T.type_name ")
        sb.Append("from Course C")
        sb.Append("inner join format_course F on F.format_id = C.format_id ")
        sb.Append("inner join group_course G on G.group_id = C.group_id ")
        sb.Append("inner join type_course T on t.type_id = C.type_id ")
        sb.Append("where C.course_id in ")
        sb.Append("(select it.course_id ")
        sb.Append("from Internal_training IT ")
        sb.Append("inner join Internal_training_history ITH on (ITH.trainingIn_id = it.trainingIn_id)")
        sb.Append("inner join Employees E on (ITH.emp_id = E.emp_id)")
        sb.Append(" where E.emp_id = @emp_id )")


        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        Dim dr As SqlDataReader
        cm.Parameters.Clear()

        With cm.Parameters
            .Clear()
            .AddWithValue("@emp_id", txt_Search.Text)
        End With
        dr = cm.ExecuteReader

        Dim dt As New DataTable
        dt.Load(dr)




        If (dt.Rows.Count = 0) Then
            MessageBox.Show("ไม่พบข้อมูล")
            Me.Close()
        Else
            With dt.Rows(0)

                dgv_history_em.DataSource = dt


            End With


        End If

        'ตัดบันทัดสุดท้ายชองดาต้าเบสทิ้งไป
        dgv_history_em.AllowUserToAddRows = False


    End Sub


#End Region



    Private Sub frmSearch_history_training_Em_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        showdata()
    End Sub
End Class