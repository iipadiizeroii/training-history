Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb


Public Class HOMERPOGRAM

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim savestatus As String = ""
    Dim num As Integer = 0
    Dim res As DialogResult
    Dim count_em As Integer


    Private Sub frm_Employees()

        With Employees
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 220
            .Top = 0
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Create_Expert()

        With Create_Expert
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 380
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Create_training()

        With Create_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 380
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_Internal_training()

        With Internal_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_External_training()

        With External_training
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_frmSearch_history_training_Em()

        With frmSearch_history_training_Em
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 370
            .Top = 50
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_frmSearch_not_history_training_Em()

        With frmSearch_not_history_training_Em
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 370
            .Top = 50
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub frm_all_report()

        With all_report
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 550
            .Top = 50
            .Show()
            .Activate()
        End With

    End Sub

#Region "panal ใช้มอนิเตอร์ข้อมูล"

    Private Sub cmb_training()
        sql = "select course_name from Course "
        cmd_object(ComboBox1)
    End Sub


    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged


        sql = "select course_id  from Course where course_name ='" & ComboBox1.Text & "'"
        Dim da As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        Dim dtr As DataRow
        da.Fill(ds, "cour")
        For Each dtr In ds.Tables("cour").Rows
            count_em = dtr("course_id")

        Next

        '-----------------------------------------------------------------------------------------
        'เลือกหลักสูตรที่ต้องการแล้วจะแสดงจำนวนพนักงทานที่อบรมไปแล้ว ที่Label13
        sb = New StringBuilder
        sb.Append("Select coalesce(COUNT(emp_id), 0) ")
        sb.Append("from Employees ")
        sb.Append("where emp_id in ")
        sb.Append("(Select E.emp_id from Employees E ")
        sb.Append("inner join Internal_training_history ITH on (E.emp_id = ITH.emp_id) ")
        sb.Append("inner join Internal_training IT  on (IT.trainingIn_id = ITH.trainingIn_id) ")
        sb.Append(" where IT.course_id = @count_em )")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)

        With cm.Parameters
            .Clear()
            .AddWithValue("@count_em", count_em)
        End With

        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read

                Label13.Text = Format(dr.GetInt32(0), "#,###,##0.##")

            Loop

        End If
        cn.Close()


    End Sub

    Private Sub Panel1_show()

        Panel1.Visible = True

        Dim m As String = (Now.Month).ToString("00")  '12
        Dim y As String = Now.Year  '2019
        Dim cn As New SqlConnection(strConn)

        '-----------------------------------------
        'แสดงข้อมูลการอบรมภายในทั้งหมด

        sb = New StringBuilder
        '2.เขียน sql'
        sb.Append("select * from Internal_training where MONTH(date) = @date_in and YEAR(date) = @year_in ")
        '3'
        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@date_in", m)
            .AddWithValue("@year_in", y)
        End With
        dr = cm.ExecuteReader

        numAEMO = 0
        ListView2.Items.Clear()

        If dr.HasRows = True Then
            Do While dr.Read
                Dim LV2 As New ListViewItem
                LV2.UseItemStyleForSubItems = False
                numAEMO = numAEMO + 1
                LV2.Text = numAEMO
                LV2.SubItems.Add(dr.GetString(0))
                LV2.SubItems.Add(dr.GetString(1))
                LV2.SubItems.Add(dr.GetValue(2))
                LV2.SubItems.Add(dr.GetValue(3))
                LV2.SubItems.Add(dr.GetValue(4))
                LV2.SubItems.Add(dr.GetValue(5))
                LV2.SubItems.Add(dr.GetValue(6))
                LV2.SubItems.Add(dr.GetValue(7))
                LV2.SubItems.Add(dr.GetValue(8))
                ListView2.Items.Add(LV2)
                LV2 = Nothing

            Loop

        End If

        

        '--------------------------------------------------------------------
        'แสดงข้อมูลการอบรมภายนอกทั้งหมด


        cn = New SqlConnection(strConn)
        'Dim s As String = ""
        sb = New StringBuilder

        '2.เขียน sql'
        sb.Append("select * from External_training where MONTH(date) = @date_out and YEAR(date) = @year_in ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        With cm.Parameters
            .Clear()
            .AddWithValue("@date_out", m)
            .AddWithValue("@year_in", y)
        End With
        dr = cm.ExecuteReader

        numAEMO = 0
        ListView1.Items.Clear()

        If dr.HasRows = True Then
            Do While dr.Read
                Dim LV1 As New ListViewItem
                LV1.UseItemStyleForSubItems = False
                numAEMO = numAEMO + 1
                LV1.Text = numAEMO
                LV1.SubItems.Add(dr.GetString(0))
                LV1.SubItems.Add(dr.GetString(1))
                LV1.SubItems.Add(dr.GetValue(2))
                LV1.SubItems.Add(dr.GetValue(3))
                LV1.SubItems.Add(dr.GetValue(4))
                LV1.SubItems.Add(dr.GetValue(5))
                LV1.SubItems.Add(dr.GetValue(6))
                LV1.SubItems.Add(dr.GetValue(7))
                LV1.SubItems.Add(dr.GetValue(8))
                ListView1.Items.Add(LV1)
                LV1 = Nothing

            Loop

        End If

        




        '-------------------------------------------------------------------------
        'ค่าใช้จ่ายประจำเดือน จัดอบรมภายใน

        sb = New StringBuilder
        sb.Append("SELECT coalesce(SUM(Total),0) FROM Expenses_in where MONTH(Date_in) = @datetotal_in and YEAR(Date_in) = @yeartotal_in ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)

        With cm.Parameters
            .Clear()
            .AddWithValue("@datetotal_in", m)
            .AddWithValue("@yeartotal_in", y)
        End With

        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                'Label3.Text = dr.GetInt32(0)
                'Label3.Text = "฿ " & CDbl(dr.GetInt32(0)).ToString("#,###.##") & " บาท"
                Label3.Text = "฿ " & Format(dr.GetInt32(0), "#,###,##0.00") & " บาท"
            Loop

        End If


        '-------------------------------------------------------------------------
        'ค่าใช้จ่ายประจำปี จัดอบรมภายใน
        Dim inmony As String = ""
        sb = New StringBuilder
        sb.Append("SELECT coalesce(SUM(Total),0) FROM Expenses_in where YEAR(Date_in) = @yeartotal_in ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)

        With cm.Parameters
            .Clear()
            .AddWithValue("@yeartotal_in", y)
        End With

        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                'Label3.Text = dr.GetInt32(0)
                'Label3.Text = "฿ " & CDbl(dr.GetInt32(0)).ToString("#,###.##") & " บาท"
                Label8.Text = "฿ " & Format(dr.GetInt32(0), "#,###,##0.00") & " บาท"
                inmony = Format(dr.GetInt32(0), "#,###,##0.00")
            Loop

        End If

        '-------------------------------------------------------------------------
        'ค่าใช้จ่ายประจำเดือน อบรมภายนอก
        'Dim m As String = (Now.Month).ToString("00")  '12
        sb = New StringBuilder
        sb.Append("SELECT coalesce(SUM(Total),0) FROM Expenses_out where MONTH(Date_out) = @datetotal_out and YEAR(Date_out) = @yeartotal_out ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)

        With cm.Parameters
            .Clear()
            .AddWithValue("@datetotal_out", m)
            .AddWithValue("@yeartotal_out", y)
        End With

        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                'Label3.Text = dr.GetInt32(0)
                'Label6.Text = "฿ " & CDbl(dr.GetInt32(0)).ToString("#,###.00") & " บาท"
                Label6.Text = "฿ " & Format(dr.GetInt32(0), "#,###,##0.00") & " บาท"


            Loop

        End If

        '-------------------------------------------------------------------------
        'ค่าใช้จ่ายประจำปี อบรมภายนอก
        'Dim m As String = (Now.Month).ToString("00")  '12

        Dim outmony As String = ""
        sb = New StringBuilder
        sb.Append("SELECT coalesce(SUM(Total),0) FROM Expenses_out where YEAR(Date_out) = @yeartotal_out ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)

        With cm.Parameters
            .Clear()
            .AddWithValue("@yeartotal_out", y)
        End With

        dr = cm.ExecuteReader

        If dr.HasRows = True Then
            Do While dr.Read
                'Label3.Text = dr.GetInt32(0)
                'Label6.Text = "฿ " & CDbl(dr.GetInt32(0)).ToString("#,###.00") & " บาท"
                Label10.Text = "฿ " & Format(dr.GetInt32(0), "#,###,##0.00") & " บาท"
                outmony = Format(dr.GetInt32(0), "#,###,##0.00")
            Loop

        End If

        '-------------------------------------------------------------------------------
        'ค่าใช้จ่ายรวมทั้งปี
        Dim inout_total As Integer
        inout_total = CDbl(outmony) + CDbl(inmony)
        Label12.Text = "฿ " & Format(inout_total, "#,###,##0.00") & " บาท"

        '------------------------------------------------------------------------------
        'แสดงจำนวนพนักงานที่อบรมหลักสูตร นั้น ๆ ไปแล้ว
        cmb_training()

        'ดึงหลักสูตรแรกสุดขึ้นมาแสดงตอนโหลดฟอร์ม
        sb = New StringBuilder
        sb.Append(" SELECT TOP 1 course_name from Course ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        dr = cm.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        With dt.Rows(0)
            ComboBox1.Text = .Item(0).ToString
        End With

        cn.Close()

        '------------------------------------------------------------------------------
        'นับจำนวนหลักสูตรทั้งหมดว่ามีเท่าไร
        sb = New StringBuilder
        sb.Append(" SELECT COUNT( course_id ) from Course")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        dr = cm.ExecuteReader
        If dr.HasRows = True Then
            Do While dr.Read

                Label2.Text = Format(dr.GetInt32(0), "#,###,##0.##")

            Loop

        End If


        '------------------------------------------------------------------------------
        'นับจำนวนวิทยากรภายนอกทั้งหมดว่ามีเท่าไร
        sb = New StringBuilder
        sb.Append(" SELECT coalesce (COUNT( expert_id ),0) from Expert  where   expert_id like '%T%' ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        dr = cm.ExecuteReader
        If dr.HasRows = True Then
            Do While dr.Read

                Label19.Text = Format(dr.GetInt32(0), "#,###,##0.##")

            Loop

        End If


        '------------------------------------------------------------------------------
        'นับจำนวนวิทยากรภายในทั้งหมดว่ามีเท่าไร
        sb = New StringBuilder
        sb.Append(" SELECT coalesce (COUNT( expert_id ),0) from Expert  where   expert_id like '%F%' ")

        With cn
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = strConn
            .Open()
        End With

        cm = New SqlCommand(sb.ToString, cn)
        dr = cm.ExecuteReader
        If dr.HasRows = True Then
            Do While dr.Read

                Label21.Text = Format(dr.GetInt32(0), "#,###,##0.##")

            Loop

        End If

    End Sub

#End Region

    Private Sub HOMERPOGRAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load






        Login_Form.MdiParent = Me
        Login_Form.StartPosition = FormStartPosition.Manual
        Login_Form.Left = 447
        Login_Form.Top = 187
        Login_Form.Show()

        With ListView1
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสอบรมภายนอก", 110)
            .Columns.Add("ชื่อ", 200)
            .Columns.Add("สถานที่", 130)
            .Columns.Add("หลักสูตรการอบรม", 90)
            .Columns.Add("ชม : นาที", 90)
            .Columns.Add("วันที่เริ่ม", 90)
            .Columns.Add("เวลาเริ่ม", 60)
            .Columns.Add("วันที่สิ้นสุด", 90)
            .Columns.Add("เวลาสิ้นสุด", 70)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With

        With ListView2
            .Columns.Add("ลำดับ", 50)
            .Columns.Add("รหัสอบรมภายใน", 110)
            .Columns.Add("ชื่อ", 200)
            .Columns.Add("สถานที่", 130)
            .Columns.Add("หลักสูตรการอบรม", 90)
            .Columns.Add("ชม : นาที", 90)
            .Columns.Add("วันที่เริ่ม", 90)
            .Columns.Add("เวลาเริ่ม", 60)
            .Columns.Add("วันที่สิ้นสุด", 90)
            .Columns.Add("เวลาสิ้นสุด", 70)
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
        End With



        'Button1.Visible = False
        'Button2.Visible = False
        'Button3.Visible = False
        'Button4.Visible = False
        'Button5.Visible = False
        'Button6.Visible = False
        'Button7.Visible = False
        'Button8.Visible = False
        'Button9.Visible = False
        Panel1_show()
        GroupBox1.Visible = False
        MenuStrip1.Visible = False
        StatusStrip1.Visible = False
        Panel1.Visible = False




    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Panel1.Visible = False
        frm_Create_Expert()
        'With Create_Expert

        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()

        'End With
        '-------------------------------------------------------------------

        'Dim f As New Create_Expert()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------
        'Create_Expert.MdiParent = Me
        'Create_Expert.StartPosition = FormStartPosition.Manual
        'Create_Expert.Left = 380
        'Create_Expert.Top = 10
        'Create_Expert.Show()
        'Create_Expert.Activate()



        'Create_Expert.Show()


        ''เปิดฟอร์มโดยใช้ tap เป็นตัววางฟอร์ม
        'Create_Expert.TopLevel = False
        'Me.TabPage1.Controls.Add(Create_Expert)
        'Create_Expert.Show()


        'เปิดฟอร์มใหม่โด้ยการใช้ พาเนลเป็นตัววางฟอร์ม
        'Create_Expert.TopLevel = False
        'Me.Panel1.Controls.Add(Create_Expert)
        'Create_Expert.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Panel1.Visible = False
        frm_Employees()

        'With Employees
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 220
        '    .Top = 0
        '    .Show()
        '    .Activate()
        'End With

        '-------------------------------------------------------------------

        'Dim f As New Employees()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()
        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 220 : f.Top = 0
        '    f.Show()
        'End If

        '-------------------------------------------------------------------

        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 220 : f.Top = 0 : f.Show()



        'Employees.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Panel1.Visible = False
        frm_Create_training()
        'With Create_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New Create_training()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()
        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 380 : f.Top = 50 : f.Show()
        'End If
        '-------------------------------------------------------------------

        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()


        'Create_training.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Panel1.Visible = False
        frm_Internal_training()
        'With Internal_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Internal_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()
        '-------------------------------------------------------------------
        'Internal_training.MdiParent = Me
        'Internal_training.StartPosition = FormStartPosition.Manual
        'Internal_training.Left = 215
        'Internal_training.Top = 10
        'Internal_training.Show()
        'Internal_training.Activate()


        'Internal_training.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Panel1.Visible = False
        frm_External_training()
        'With External_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New External_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 215 : f.Top = 50 : f.Show()
        '-------------------------------------------------------------------

        'External_training.MdiParent = Me
        'External_training.StartPosition = FormStartPosition.Manual
        'External_training.Left = 215
        'External_training.Top = 10
        'External_training.Show()
        'External_training.Activate()

        'External_training.Show()

    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Panel1.Visible = False
        frm_frmSearch_history_training_Em()
        'With frmSearch_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'frmSearch_history_training_Em.MdiParent = Me
        'frmSearch_history_training_Em.StartPosition = FormStartPosition.Manual
        'frmSearch_history_training_Em.Left = 370
        'frmSearch_history_training_Em.Top = 50
        'frmSearch_history_training_Em.Show()
        'frmSearch_history_training_Em.Activate()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_history_training_Em()
        'Dim Children = From p In Me.MdiChildren Where p.Text.Contains(f.Text) Select p
        'If Children.Count() <> 0 Then
        '    Children.First().Activate()

        'Else
        '    f.MdiParent = Me
        '    f.StartPosition = FormStartPosition.Manual
        '    f.Left = 370 : f.Top = 50 : f.Show()
        'End If


        '-------------------------------------------------------------------
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        ''f.MdiParent = GroupBox2.Container
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 547 : f.Top = 240 : f.Show()


    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Panel1.Visible = False
        frm_frmSearch_not_history_training_Em()
        'With frmSearch_not_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With

        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Panel1.Visible = False
        frm_all_report()
        'all_report.MdiParent = Me
        'all_report.StartPosition = FormStartPosition.Manual
        'all_report.Left = 550
        'all_report.Top = 50
        'all_report.Show()
        'all_report.Activate()
        '-------------------------------------------------------------------

        'Dim rpt As New ReportDocument()
        'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_Employees.rpt")
        'test_Print.CrystalReportViewer1.ReportSource = rpt

        'test_Print.Show()


    End Sub

#Region "แถบเมนูด้านบนฟอร์ม"
    Private Sub บนทกขอมลพนกงานToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles บนทกขอมลพนกงานToolStripMenuItem1.Click

        Panel1.Visible = False
        frm_Employees()
        'With Employees
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 220
        '    .Top = 0
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Employees()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 220 : f.Top = 0 : f.Show()

    End Sub

    Private Sub บนทกขอมลวทยากรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกขอมลวทยากรToolStripMenuItem.Click

        Panel1.Visible = False
        frm_Create_Expert()
        'With Create_Expert

        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 10
        '    .Show()
        '    .Activate()

        'End With
        '-------------------------------------------------------------------
        'Create_Expert.MdiParent = Me
        'Create_Expert.StartPosition = FormStartPosition.Manual
        'Create_Expert.Left = 380
        'Create_Expert.Top = 10
        'Create_Expert.Show()

    End Sub

    Private Sub เพมหลกสตรการอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เพมหลกสตรการอบรมToolStripMenuItem.Click

        Panel1.Visible = False
        frm_Create_training()
        'With Create_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 380
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New Create_training()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 380 : f.Top = 50 : f.Show()

    End Sub

    Private Sub จดอบรมภายในToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดอบรมภายในToolStripMenuItem.Click

        Panel1.Visible = False
        frm_Internal_training()
        'With Internal_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Internal_training.MdiParent = Me
        'Internal_training.StartPosition = FormStartPosition.Manual
        'Internal_training.Left = 215
        'Internal_training.Top = 10
        'Internal_training.Show()

    End Sub

    Private Sub จดอบรมภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles จดอบรมภายนอกToolStripMenuItem.Click

        Panel1.Visible = False
        frm_External_training()
        'With External_training
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 215
        '    .Top = 10
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'External_training.MdiParent = Me
        'External_training.StartPosition = FormStartPosition.Manual
        'External_training.Left = 215
        'External_training.Top = 10
        'External_training.Show()


    End Sub

    Private Sub คนหาประวตการอบรมรายบคคลToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คนหาประวตการอบรมรายบคคลToolStripMenuItem.Click

        Panel1.Visible = False
        frm_frmSearch_history_training_Em()
        'With frmSearch_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------
        'Dim f As New frmSearch_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()


    End Sub

    Private Sub คนหาประวตการอบรมตามแผนกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles คนหาประวตการอบรมตามแผนกToolStripMenuItem.Click

        Panel1.Visible = False
        frm_frmSearch_not_history_training_Em()
        'With frmSearch_not_history_training_Em
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.Manual
        '    .Left = 370
        '    .Top = 50
        '    .Show()
        '    .Activate()
        'End With
        '-------------------------------------------------------------------

        'Dim f As New frmSearch_not_history_training_Em()
        'f.MdiParent = Me
        'f.StartPosition = FormStartPosition.Manual
        'f.Left = 370 : f.Top = 50 : f.Show()


    End Sub

    Private Sub รายงานรายชอพนกงานToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานรายชอพนกงานToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        'rpt.Load("G:\โปรเจค\training history\training-history\training history\RP_Employees.rpt")
        rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\RP_Employees.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานรายชอวทยากรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานรายชอวทยากรToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        'rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Expert.rpt")
        rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\PR_Expert.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานหลกสตรการอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานหลกสตรการอบรมToolStripMenuItem.Click

        Dim rpt As New ReportDocument()

        'rpt.Load("G:\โปรเจค\training history\training-history\training history\PR_Training.rpt")
        rpt.Load("C:\Users\Duck-Nb\Desktop\training-history\training history\PR_Training.rpt")
        test_Print.CrystalReportViewer1.ReportSource = rpt

        test_Print.Show()

    End Sub

    Private Sub รายงานแสดงคาใชจายอบรมภายในภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานแสดงคาใชจายอบรมภายในภายนอกToolStripMenuItem.Click

        Panel1.Visible = False
        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 300
            .Top = 35
            .Show()
            .Activate()
        End With


        'RP_Expenses_in_out.MdiParent = Me
        'RP_Expenses_in_out.StartPosition = FormStartPosition.Manual
        'RP_Expenses_in_out.Left = 300
        'RP_Expenses_in_out.Top = 35
        'RP_Expenses_in_out.Show()


    End Sub

    Private Sub เอกสารลงชอพนกงานเขาอบรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เอกสารลงชอพนกงานเขาอบรมToolStripMenuItem.Click

        Panel1.Visible = False
        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 200
            .Top = 35
            .Show()
            .Activate()
        End With


        'RP_Register.MdiParent = Me
        'RP_Register.StartPosition = FormStartPosition.Manual
        'RP_Register.Left = 200
        'RP_Register.Top = 35
        'RP_Register.Show()


    End Sub

    Private Sub เอกสารอนมตการอบรมภายในภายนอกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เอกสารอนมตการอบรมภายในภายนอกToolStripMenuItem.Click

        Panel1.Visible = False
        With RP_Expenses_in_out
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 220
            .Top = 35
            .Show()
            .Activate()
        End With


        'PR_PO_ALL.MdiParent = Me
        'PR_PO_ALL.StartPosition = FormStartPosition.Manual
        'PR_PO_ALL.Left = 220
        'PR_PO_ALL.Top = 35
        'PR_PO_ALL.Show()


    End Sub

    Private Sub บนทกขอมลUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles บนทกขอมลUserToolStripMenuItem.Click

        Panel1.Visible = False
        With new_admin
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

        'new_admin.MdiParent = Me
        'new_admin.StartPosition = FormStartPosition.Manual
        'new_admin.Left = 215
        'new_admin.Top = 10
        'new_admin.Show()

    End Sub

#End Region



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Panel1_show()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Panel1_show()
    End Sub

    Private Sub เปลยนรหสผานToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เปลยนรหสผานToolStripMenuItem.Click

        Panel1.Visible = False
        With frmRe_password
            .MdiParent = Me
            .StartPosition = FormStartPosition.Manual
            .Left = 215
            .Top = 10
            .Show()
            .Activate()
        End With

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click


        Login_Form.MdiParent = Me
        Login_Form.StartPosition = FormStartPosition.Manual
        Login_Form.Left = 447
        Login_Form.Top = 187
        Login_Form.Show()

        GroupBox1.Visible = False
        MenuStrip1.Visible = False
        StatusStrip1.Visible = False
        Panel1.Visible = False
        Employees.Close()
        Create_Expert.Close()
        Create_training.Close()
        Internal_training.Close()
        External_training.Close()
        frmSearch_history_training_Em.Close()
        frmSearch_not_history_training_Em.Close()
        all_report.Close()
        test_Print.Close()
        RP_Expenses_in_out.Close()





    End Sub
End Class