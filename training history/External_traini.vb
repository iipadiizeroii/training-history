Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class External_traini

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""

    Private Sub cmb_course()
        sql = "select course_name from Course "
        cmd_object(cmb_course_name)
    End Sub



#Region "เชื่อต่อ Data"

    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from External_training"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "exter")
        '4.'
        datagrid_Extraining.DataSource = ds.Tables("exter")
        '5'
        cn.Close()

    End Sub
#End Region

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

        Dim s As String = ""
        If savestatus = "Add" Then
            s = "Insert into  External_training (trainingEx_id,training_name,date,training_location,course_id,training_date)"
            s &= "Values (@trainingEx_id,@training_name,@date,@training_location,@course_id,@training_date)"

        ElseIf savestatus = "Edit" Then
            s = "Update External_training"
            s &= " set training_name = @training_name,"
            s &= "date = @date,"
            s &= "training_location = @training_location,"
            s &= "course_id = @course_id,"
            s &= "training_date = @training_date "
            s &= " Where trainingEx_id = @trainingEx_id"

        End If

        Dim cm As New SqlCommand

        With cm
            .CommandType = CommandType.Text
            .CommandText = s
            .Connection = cn
            .Parameters.Clear()
            .Parameters.Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_trainingOut_id.Text
            .Parameters.Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_trainingOut_name.Text
            .Parameters.Add("@date", SqlDbType.Date).Value = Date_training.Text
            .Parameters.Add("@training_location", SqlDbType.NVarChar, 50).Value = txt_training_location.Text
            .Parameters.Add("@course_id", SqlDbType.Int).Value = txt_course_id.Text()
            .Parameters.Add("@training_date", SqlDbType.NVarChar, 20).Value = txt_long_term.Text


            .ExecuteNonQuery()

        End With

        MsgBox("บัยทึกข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
        showdata()





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
        R1.Checked = False
        R2.Checked = False



    End Sub
#End Region

#Region "คลิกเลือกข้อมูลใน datagrid"
    Private Sub datagrid_Extraining_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_Extraining.CellClick

        Try
            Dim i As Integer = datagrid_Extraining.CurrentRow.Index
            txt_trainingOut_id.Text = datagrid_Extraining.Item(0, i).Value
            txt_trainingOut_name.Text = datagrid_Extraining.Item(1, i).Value
            Date_training.Text = datagrid_Extraining.Item(2, i).Value
            txt_training_location.Text = datagrid_Extraining.Item(3, i).Value
            txt_course_id.Text = datagrid_Extraining.Item(4, i).Value
            txt_long_term.Text = datagrid_Extraining.Item(5, i).Value

        Catch ex As Exception
            MessageBox.Show("ไม่พบข้อมูล" & ex.Message)

        End Try



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

            If R1.Checked = True Then
                CM.Parameters.Add("@trainingEx_id", SqlDbType.NVarChar, 10).Value = txt_Search.Text & "%"
            Else
                CM.Parameters.Add("@training_name", SqlDbType.NVarChar, 100).Value = txt_Search.Text & "%"
            End If
            DR = CM.ExecuteReader
            Dim dt As New DataTable
            dt.Load(DR)
            '4
            If (dt.Rows.Count = 0) Then
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                With dt.Rows(0)
                    txt_trainingOut_id.Text = .Item(0).ToString
                    txt_trainingOut_name.Text = .Item(1).ToString
                    Date_training.Text = .Item(2).ToString
                    txt_training_location.Text = .Item(3).ToString
                    txt_course_id.Text = .Item(4).ToString
                    txt_long_term.Text = .Item(5).ToString



                    datagrid_Extraining.DataSource = dt
                End With
            End If

        End If
    End Sub
#End Region

    Private Sub External_traini_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'showdata()
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
            showdata()
            cleardata()
        End If
    End Sub


    Private Sub cmb_course_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_course_name.SelectedIndexChanged

        sql = "select course_id  from Course where course_name ='" & cmb_course_name.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "cour")
        For Each dtr In ds.Tables("cour").Rows
            txt_course_id.Text = dtr("course_id")
        Next


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
        showdata()

    End Sub



    Private Sub txt_course_name_TextChanged(sender As Object, e As EventArgs) Handles txt_course_id.TextChanged

        sql = "select course_name  from Course where course_id ='" & txt_course_id.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "cour")
        For Each dtr In ds.Tables("cour").Rows
            cmb_course_name.Text = dtr("course_name")
        Next


    End Sub
End Class