Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
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
            MsgBox("ลบข้อมูลสำเร็จ", MsgBoxStyle.Information, "ผลการทำงาน")
            showdata()
            cleardata()
        End If

        R4.Checked = False
        Search_emp.Enabled = False

    End Sub
#End Region

#Region "Update ข้อมูล"
    Private Sub update_exp()

        If txt_exp_id.Text = "" Then
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


        R1.Checked = True
        add_data.Enabled = False
        showdata()

    End Sub

    Private Sub add_data_Click(sender As Object, e As EventArgs) Handles add_data.Click

        cleardata()
        add_exp()

    End Sub

    Private Sub edit_data_Click(sender As Object, e As EventArgs) Handles edit_data.Click

        edit_exp()

    End Sub

    Private Sub upte_data_Click(sender As Object, e As EventArgs) Handles upte_data.Click

        update_exp()
        cleardata()


    End Sub


    Private Sub cancel_data_Click(sender As Object, e As EventArgs) Handles cancel_data.Click

        R3.Checked = False
        R4.Checked = False
        cleardata()
        R4.Checked = False
        Search_emp.Enabled = False
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


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles R4.CheckedChanged

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
       If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_exp_lastname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_lastname.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_exp_position_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_position.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_exp_department_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_exp_department.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_expert_expertise_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_expert_expertise.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Then
            e.Handled = True
        End If
    End Sub

    

    Private Sub txt_exp_name_TextChanged(sender As Object, e As EventArgs) Handles txt_exp_name.TextChanged

    End Sub
End Class