Imports System.IO


Public Class Add_Expert_out

#Region "showdata"
    Private Sub showdata()
        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Expert")
        With dgv_Ex
            .DataSource = DataShow
            .Columns("expert_id").HeaderText = "รหัสวิทยากร"
            .Columns("expert_id").Width = "80"
            .Columns("expert_name").HeaderText = "ชื่อวิทยากร"
            .Columns("expert_name").Width = "100"
            .Columns("expert_lastname").HeaderText = "นามสกุล"
            .Columns("expert_lastname").Width = "100"
            .Columns("expert_position").HeaderText = "ต่ำแหน่ง"
            .Columns("expert_position").Width = "200"
            .Columns("expert_department").HeaderText = "หน่วยงานต้นสังกัด"
            .Columns("expert_department").Width = "130"
            .Columns("expert_expertise").HeaderText = "ความเชี่ยวชาญ"
            .Columns("expert_expertise").Width = "130"

            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable


        End With

    End Sub
#End Region

    '#Region "ค้นหา"
    '    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown

    '        If e.KeyCode = Keys.Enter Then
    '            '1

    '            '2
    '            Dim s, s1 As String
    '            If R1.Checked = True Then
    '                s1 = " trainingIn_id like @trainingIn_id"
    '            Else
    '                s1 = " training_name like @training_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
    '            End If
    '            s = "select * from Internal_training where " & s1
    '            '3
    '            With cn
    '                If .State = ConnectionState.Open Then .Close()
    '                .ConnectionString = strConn
    '                .Open()
    '            End With


    '            CM.Parameters.Clear()

    '            If R1.Checked = True Then
    '                CM.Parameters.Add("@trainingIn_id", SqlDbType.NVarChar, 10).Value = txt_Search.Text & "%"
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

    '                datagrid_Intraining.DataSource = dt

    '            End If

    '        End If
    '    End Sub
    '#End Region

    Private Sub Add_Expert_out_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()

    End Sub

    Private Sub dgv_Ex_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Ex.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        

        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Expert Where expert_id LIKE '%" & TextBox1.Text & "%' AND expert_name LIKE '%" & TextBox2.Text & "%' AND expert_expertise LIKE '%" & TextBox3.Text & "%' ")
        With dgv_Ex
            .DataSource = DataShow
            .Columns("expert_id").HeaderText = "รหัสวิทยากร"
            .Columns("expert_id").Width = "80"
            .Columns("expert_name").HeaderText = "ชื่อวิทยากร"
            .Columns("expert_name").Width = "100"
            .Columns("expert_lastname").HeaderText = "นามสกุล"
            .Columns("expert_lastname").Width = "100"
            .Columns("expert_position").HeaderText = "ตำแหน่ง"
            .Columns("expert_position").Width = "200"
            .Columns("expert_department").HeaderText = "หน่วยงานต้นสังกัด"
            .Columns("expert_department").Width = "130"
            .Columns("expert_expertise").HeaderText = "ความเชี่ยวชาญ"
            .Columns("expert_expertise").Width = "130"

            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable


        End With


    End Sub
End Class