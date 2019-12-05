Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class frmNew_expert_In

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String

#Region "เชื่อต่อ Data"

    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select emp_id,emp_name,emp_lastname,emp_position,emp_department from Employees"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "emtra")
        '4.'
        datagrid_new_expertin.DataSource = ds.Tables("emtra")

        datagrid_new_expertin.AllowUserToAddRows = False
        '5'
        cn.Close()

        With datagrid_new_expertin
            .Columns.Item(0).HeaderText = "รหัสวิทยากร"
            .Columns.Item(0).Width = "90"
            .Columns.Item(1).HeaderText = "ชื่อ"
            .Columns.Item(1).Width = "100"
            .Columns.Item(2).HeaderText = "นามสกุล"
            .Columns.Item(2).Width = "100"
            .Columns.Item(3).HeaderText = "ตำแหน่งวิทยากร"
            .Columns.Item(3).Width = "190"
            .Columns.Item(4).HeaderText = "หน่วยงานต้นสังกัด"
            .Columns.Item(4).Width = "170"
           



            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
     
        End With



    End Sub
#End Region

#Region "ค้นหา"
    Private Sub txt_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Search.KeyDown

        If e.KeyCode = Keys.Enter Then

            If txt_Search.Text = "" Then
                MsgBox("กรุณากรอกหรัสหรือชื่อที่ต้องการค้นหา", MsgBoxStyle.Critical, "ผลการทำงาน")
                Exit Sub
            End If

            '1
            Dim cn As New SqlConnection(strConn)
            '2
            Dim s, s1 As String
            If R1.Checked = True Then
                s1 = " emp_id like @emp_id"
            Else
                s1 = " emp_name like @emp_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
            End If
            s = "select * from Employees where " & s1
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
                MsgBox("ไม่พบข้อมูล", MsgBoxStyle.Critical, "ผลการทำงาน")
            Else


                datagrid_new_expertin.DataSource = dt

            End If


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txt_Search.Text = "" Then
            MsgBox("กรุณากรอกหรัสหรือชื่อที่ต้องการค้นหา", MsgBoxStyle.Critical, "ผลการทำงาน")
            Exit Sub
        End If

        '1
        Dim cn As New SqlConnection(strConn)
        '2
        Dim s, s1 As String
        If R1.Checked = True Then
            s1 = " emp_id like @emp_id"
        Else
            s1 = " emp_name like @emp_name" 'like พิมพ์อักษรตัวเดียวก็ขึ้น
        End If
        s = "select * from Employees where " & s1
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
            MsgBox("ไม่พบข้อมูล", MsgBoxStyle.Critical, "ผลการทำงาน")
        Else


            datagrid_new_expertin.DataSource = dt

        End If

    End Sub
#End Region

    Private Sub frmNew_expertin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()

    End Sub


    Private Sub frmNew_expertin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Create_Expert.txt_exp_id.Text = str1
        Create_Expert.txt_exp_name.Text = str2
        Create_Expert.txt_exp_lastname.Text = str3
        Create_Expert.txt_exp_position.Text = str4
        Create_Expert.txt_exp_department.Text = str5




    End Sub

    Private Sub datagrid_new_expertin_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_new_expertin.CellClick

        If e.RowIndex < 0 Then Exit Sub
        With datagrid_new_expertin.Rows(e.RowIndex)
            str1 = .Cells(0).Value.ToString
            str2 = .Cells(1).Value.ToString
            str3 = .Cells(2).Value.ToString
            str4 = .Cells(3).Value.ToString
            str5 = .Cells(4).Value.ToString

        End With

        Create_Expert.upte_data.Enabled = True
        Me.Close()

        'Create_Expert.Show()

    End Sub



    Private Sub txt_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Search.KeyPress


        If R1.Checked = True Then

            Select Case Asc(e.KeyChar)
                Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                    e.Handled = False
                Case 8, 13, 46, 70, 102, 89, 121 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                    e.Handled = False

                Case Else
                    e.Handled = True
                    MessageBox.Show("สามารถกดได้แค่ตัวเลข และ อักษร F, Y")
            End Select

            txt_Search.MaxLength = 8

        Else

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
            txt_Search.MaxLength = 50
        End If

    End Sub

   
End Class