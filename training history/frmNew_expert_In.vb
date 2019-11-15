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
        '5'
        cn.Close()

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
                MessageBox.Show("ไม่พบข้อมูล")
            Else
                

                datagrid_new_expertin.DataSource = dt

            End If


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
    End Sub



End Class