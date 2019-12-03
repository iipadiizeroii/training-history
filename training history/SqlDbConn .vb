Imports System.Data.SqlClient
Imports System.Data

Module SqlDbConn

    'Public strConn As String = "data source = DUCK-TNT\SQL2012;database = Data_Training;integrated security = true"
    'Public strConn As String = "data source = KT1-PC-164\SQL2012;database = Data_Training;integrated security = true"
    Public strConn As String = "data source = DESKTOP-HUU05QN\SQL2012;database = Data_Training;integrated security = true"

    Public dbconnect As New SqlConnection(strConn)
    Public command As New SqlCommand("", dbconnect)
    Public sqlstring As String

    Friend cn As New SqlConnection(strConn)
    Friend cm As New SqlCommand
    Friend da As New SqlDataAdapter
    Friend ds As New DataSet
    Friend dr As SqlDataReader
    Friend sql As String
    Friend savestatus As String = ""
    Friend emio As String = ""
    Friend courseID As String 'เก็บค่า รหัสของหลักสูตรเพื่อนำไปเปรียบเทียบคนที่ยังไม่ได้เรียนหลักสูตรนี้


    Friend numAEXI As Integer 'ใช้นับลำดับใน เพิ่มรายชื่อวิทยากรภายใน
    Friend numAEXO As Integer 'ใช้นับลำดับใน เพิ่มรายชื่อวิทยากรภายนอก
    Friend numAEMO As Integer 'ใช้นับลำดับใน เพิ่มรายชื่อผู้เข้าอบรม

    
    Friend str0 As String = ""
    Friend str1 As String = ""
    Friend str2 As String = ""
    Friend str3 As String = ""
    Friend str4 As String = ""
    Friend str5 As String = ""
    Friend str6 As String = ""
    Friend str7 As String = ""



    Friend Sub connect()
        If cn.State = ConnectionState.Closed Then cn.Open()
    End Sub

    Friend Sub cmd_object(obj As Object)

        connect()
        cm = New SqlCommand(sql, cn)
        dr = cm.ExecuteReader
        obj.Items.Clear()

        While dr.Read
            obj.Items.Add(dr(0))

        End While
        dr.Close()

    End Sub

    Function SqlTable(sql As String) As DataTable
        Try
            Dim dtAdapter As SqlDataAdapter
            Dim objConn As New SqlConnection
            Dim dt As New DataTable
            objConn.ConnectionString = strConn
            objConn.Open()
            dtAdapter = New SqlDataAdapter(sql, objConn)
            dtAdapter.Fill(dt)
            objConn.Close()
            objConn = Nothing
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "เกิดข้อผิดพลาด")
        End Try
    End Function


End Module


'ตัดบันทัดสุดท้ายชองดาต้าเบสทิ้งไป
'dgv_Em.AllowUserToAddRows = False