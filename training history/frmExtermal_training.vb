Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb

Public Class frmExtermal_training

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable

#Region "เชื่อต่อ Data"

    Private Sub showdata()

        Dim cn As New SqlConnection(strConn)
        Dim s As String = ""
        '2.เขียน sql'
        s = "select * from External_training"
        '3'
        Dim da As New SqlDataAdapter(s, cn)
        Dim ds As New DataSet
        da.Fill(ds, "extra")
        '4.'
        datagrid_Extraining.DataSource = ds.Tables("extra")
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
                datagrid_Extraining.DataSource = dt

            End If

        End If
    End Sub
#End Region

#Region "cleardata"
    Private Sub cleardata()
        
        str1 = ""
        str2 = ""
        str3 = ""
        str4 = ""
        str5 = ""
        str6 = ""

        'R1.Checked = False
        'R2.Checked = False



    End Sub
#End Region

    Private Sub frmExtermal_training_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        External_training.txt_trainingOut_id.Text = str1
        External_training.txt_trainingOut_name.Text = str2
        External_training.Date_training.Text = str3
        External_training.txt_training_location.Text = str4
        External_training.txt_course_id.Text = str5
        External_training.txt_long_term.Text = str6

    End Sub

    Private Sub frmExtermal_training_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cleardata()
        showdata()

    End Sub

    Private Sub datagrid_Extraining_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_Extraining.CellClick

        If e.RowIndex < 0 Then Exit Sub
        With datagrid_Extraining.Rows(e.RowIndex)
            str1 = .Cells(0).Value.ToString
            str2 = .Cells(1).Value.ToString
            str3 = .Cells(2).Value.ToString
            str4 = .Cells(3).Value.ToString
            str5 = .Cells(4).Value.ToString
            str6 = .Cells(5).Value.ToString

        End With
        Me.Close()

    End Sub

    
End Class