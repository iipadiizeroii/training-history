Imports System.Data.SqlClient 'แอดฟังก์ชั่นการเรียกใช้ sql'
Imports training_history.SqlDbConn 'แอดโปรเจค'
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Data.OleDb



Public Class frmAdd_Employees_out

    Dim cn As New SqlConnection(strConn)
    Dim cm As New SqlCommand
    Dim sb As StringBuilder
    Dim tr As SqlTransaction
    Dim ds As New DataSet
    Dim dt As New DataTable

#Region "showdata"
    Private Sub showdata()


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
        Dim dr As SqlDataReader
        cm.Parameters.Clear()

        With cm.Parameters
            .Clear()
            .AddWithValue("@course_id", courseID)
        End With
        dr = cm.ExecuteReader

        Dim dt As New DataTable
        dt.Load(dr)


        

        If (dt.Rows.Count = 0) Then
            MessageBox.Show("ไม่พบข้อมูล")
            Me.Close()
        Else
            With dt.Rows(0)

                dgv_Em.DataSource = dt


            End With

           
        End If

        'ตัดบันทัดสุดท้ายชองดาต้าเบสทิ้งไป
        dgv_Em.AllowUserToAddRows = False


    End Sub


#End Region

#Region "ค้นหา"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Employees Where emp_id LIKE '%" & TextBox1.Text & "%' AND emp_name LIKE '%" & TextBox2.Text & "%' AND emp_department LIKE '%" & TextBox3.Text & "%' ")

        With dgv_Em
            .DataSource = DataShow
            .Columns("emp_id").HeaderText = "รหัสพนักงาน"
            .Columns("emp_id").Width = "80"
            .Columns("emp_name").HeaderText = "ชื่อ"
            .Columns("emp_name").Width = "100"
            .Columns("emp_lastname").HeaderText = "นามสกุล"
            .Columns("emp_lastname").Width = "100"
            .Columns("emp_level").HeaderText = "Level"
            .Columns("emp_level").Width = "50"
            .Columns("emp_position").HeaderText = "ตำแหน่งพนักงาน"
            .Columns("emp_position").Width = "130"
            .Columns("emp_department").HeaderText = "แผนก"
            .Columns("emp_department").Width = "130"
            .Columns("emp_division").HeaderText = "ฝ่าย"
            .Columns("emp_division").Width = "130"

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        End With

    End Sub
#End Region

#Region "สร้างช่อง CheckBox"

    Private headerCheckBox As CheckBox = New CheckBox()
    Private Sub BindGrid()


        'Add a CheckBox Column to the DataGridView Header Cell.

        'Find the Location of Header Cell.
        Dim headerCellLocation As Point = Me.dgv_Em.GetCellDisplayRectangle(0, -1, True).Location

        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.White
        headerCheckBox.Size = New Size(18, 18)

        'Assign Click event to the Header CheckBox.
        AddHandler headerCheckBox.Click, AddressOf HeaderCheckBox_Clicked
        dgv_Em.Controls.Add(headerCheckBox)

        'Add a CheckBox Column to the DataGridView at the first position.
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "checkBoxColumn"
        dgv_Em.Columns.Insert(0, checkBoxColumn)
        'Assign Click event to the DataGridView Cell.
        AddHandler dgv_Em.CellContentClick, AddressOf dgv_Ex_CellClick

    End Sub

    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Necessary to end the edit mode of the Cell.
        dgv_Em.EndEdit()

        'Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        For Each row As DataGridViewRow In dgv_Em.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
    End Sub

    Private Sub dgv_Ex_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        'Check to ensure that the row CheckBox is clicked.
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then

            'Loop to verify whether all row CheckBoxes are checked or not.
            Dim isChecked As Boolean = True
            For Each row As DataGridViewRow In dgv_Em.Rows
                If Convert.ToBoolean(row.Cells("checkBoxColumn").EditedFormattedValue) = False Then
                    isChecked = False
                    Exit For
                End If
            Next

            headerCheckBox.Checked = isChecked
        End If
    End Sub

#End Region

#Region "ฟอร์มโหลด"
    Private Sub frmAdd_Employees_out_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            showdata()
            BindGrid()

            With dgv_Em
                .Columns.Item(1).HeaderText = "รหัสพนักงาน"
                .Columns(1).Width = "120"
                .Columns.Item(2).HeaderText = "ชื่อ"
                .Columns(2).Width = "100"
                .Columns.Item(3).HeaderText = "นามสกุล"
                .Columns(3).Width = "100"
                .Columns.Item(4).HeaderText = "Level"
                .Columns(4).Width = "50"
                .Columns.Item(5).HeaderText = "ตำแหน่งพนักงาน"
                .Columns(5).Width = "130"
                .Columns.Item(6).HeaderText = "แผนก"
                .Columns(6).Width = "130"
                .Columns.Item(7).HeaderText = "ฝ่าย"
                .Columns(7).Width = "130"
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "เกิดข้อผิดพลาด")
        End Try
    End Sub
#End Region

#Region "ดึงข้อมูลไปเก็บไว้ในตัวแปลที่ใช้เก็บค่า ข้ามฟอร์ม"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If emio = "IN" Then
            For i As Integer = 0 To dgv_Em.RowCount - 1
                If Convert.ToBoolean(dgv_Em.Rows(i).Cells("checkBoxColumn").Value) = True Then

                        str1 = dgv_Em.Rows(i).Cells(1).Value.ToString()
                        str2 = dgv_Em.Rows(i).Cells(2).Value.ToString()
                        str3 = dgv_Em.Rows(i).Cells(3).Value.ToString()
                        str4 = dgv_Em.Rows(i).Cells(4).Value.ToString()
                        str5 = dgv_Em.Rows(i).Cells(5).Value.ToString()
                        str6 = dgv_Em.Rows(i).Cells(6).Value.ToString()
                        str7 = dgv_Em.Rows(i).Cells(7).Value.ToString()

                    numAEMO = numAEMO + 1


                    
                    For ii As Integer = 0 To Internal_training.ListView2.Items.Count - 1
                        Dim anydata() As String
                        anydata = New String() {numAEMO, str1, str2, str3, str4, str5, str6, str7}
                        If anydata(str1) = Internal_training.ListView1.Items(ii).SubItems(1).Text Then
                            If MessageBox.Show("สินค้าซ้ำกับลำดับที่ " & i + 1 & " ต้องการเพิ่มจำนวนหรือไม่?", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                   ) = Windows.Forms.DialogResult.No Then Exit Sub

                            Dim LV As New ListViewItem(anydata)
                            Internal_training.ListView2.Items.Add(LV)
                            LV = Nothing



                        End If


                        'เลื่อน listView ไปบันทัดสุดท้าย
                        Internal_training.ListView2.EnsureVisible(Internal_training.ListView2.Items.Count - 1)
                    Next

                    
                End If




            Next



            Else
                For i As Integer = 0 To dgv_Em.RowCount - 1
                    If Convert.ToBoolean(dgv_Em.Rows(i).Cells("checkBoxColumn").Value) = True Then
                        str1 = dgv_Em.Rows(i).Cells(1).Value.ToString()
                        str2 = dgv_Em.Rows(i).Cells(2).Value.ToString()
                        str3 = dgv_Em.Rows(i).Cells(3).Value.ToString()
                        str4 = dgv_Em.Rows(i).Cells(4).Value.ToString()
                        str5 = dgv_Em.Rows(i).Cells(5).Value.ToString()
                        str6 = dgv_Em.Rows(i).Cells(6).Value.ToString()
                        str7 = dgv_Em.Rows(i).Cells(7).Value.ToString()

                        numAEMO = numAEMO + 1
                        Dim anydata() As String
                        anydata = New String() {numAEMO, str1, str2, str3, str4, str5, str6, str7}
                        Dim LV As New ListViewItem(anydata)
                        External_training.ListView2.Items.Add(LV)
                        LV = Nothing

                        External_training.ListView2.EnsureVisible(External_training.ListView2.Items.Count - 1)

                    End If


                Next


            End If


            emio = ""
            Me.Close()
    End Sub

#End Region

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class