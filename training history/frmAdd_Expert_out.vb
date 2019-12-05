Imports System.IO
Imports System.Data.SqlClient


Public Class frmadd_Expert_out



#Region "showdata"
    Private Sub showdata()
        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Expert where expert_id like '%T%'")
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
            .Columns("expert_department").Width = "160"
            .Columns("expert_expertise").HeaderText = "ความเชี่ยวชาญ"
            .Columns("expert_expertise").Width = "220"

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable


        End With
        dgv_Ex.AllowUserToAddRows = False
    End Sub
#End Region

#Region "ค้นหา"
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
#End Region

#Region "สร้างช่อง CheckBox"
    Private headerCheckBox As CheckBox = New CheckBox()
    Private Sub BindGrid()

        'Add a CheckBox Column to the DataGridView Header Cell.

        'Find the Location of Header Cell.
        Dim headerCellLocation As Point = Me.dgv_Ex.GetCellDisplayRectangle(0, -1, True).Location

        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.White
        headerCheckBox.Size = New Size(18, 18)

        'Assign Click event to the Header CheckBox.
        AddHandler headerCheckBox.Click, AddressOf HeaderCheckBox_Clicked
        dgv_Ex.Controls.Add(headerCheckBox)

        'Add a CheckBox Column to the DataGridView at the first position.
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "checkBoxColumn"
        dgv_Ex.Columns.Insert(0, checkBoxColumn)
        'Assign Click event to the DataGridView Cell.
        AddHandler dgv_Ex.CellContentClick, AddressOf dgv_Ex_CellClick
    End Sub

    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Necessary to end the edit mode of the Cell.
        dgv_Ex.EndEdit()

        'Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        For Each row As DataGridViewRow In dgv_Ex.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
    End Sub

    Private Sub dgv_Ex_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        'Check to ensure that the row CheckBox is clicked.
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then

            'Loop to verify whether all row CheckBoxes are checked or not.
            Dim isChecked As Boolean = True
            For Each row As DataGridViewRow In dgv_Ex.Rows
                If Convert.ToBoolean(row.Cells("checkBoxColumn").EditedFormattedValue) = False Then
                    isChecked = False
                    Exit For
                End If
            Next

            headerCheckBox.Checked = isChecked
        End If
    End Sub

#End Region

#Region "ค้นหา2"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" Then
            MsgBox("กรุณากรอกข้อมูลที่ต้องการค้นหา", MsgBoxStyle.Critical, "ผลการทำงาน")
            TextBox1.Focus()
            Exit Sub
        End If

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
            .Columns("expert_department").Width = "160"
            .Columns("expert_expertise").HeaderText = "ความเชี่ยวชาญ"
            .Columns("expert_expertise").Width = "220"

            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable


        End With

        

    End Sub
#End Region

    Private Sub Add_Expert_out_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()
        BindGrid()

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'For Each item As ListViewItem In External_training.ListView1.Items

        '    num = num + Convert.ToInt32(item.SubItems.Item(1).Text)
        '    Next
        Dim re As String = ""

            For i As Integer = 0 To dgv_Ex.RowCount - 1
            If Convert.ToBoolean(dgv_Ex.Rows(i).Cells("checkBoxColumn").Value) = True Then

                re = ""
                str1 = dgv_Ex.Rows(i).Cells(1).Value.ToString()
                str2 = dgv_Ex.Rows(i).Cells(2).Value.ToString()
                str3 = dgv_Ex.Rows(i).Cells(3).Value.ToString()
                str4 = dgv_Ex.Rows(i).Cells(4).Value.ToString()
                str5 = dgv_Ex.Rows(i).Cells(5).Value.ToString()
                str6 = dgv_Ex.Rows(i).Cells(6).Value.ToString()


                numAEXO = numAEXO + 1

                Dim anydata() As String
                anydata = New String() {numAEXO, str1, str2, str3, str4, str5, str6}

                For ii As Integer = 0 To External_training.ListView1.Items.Count - 1
                    If anydata(1) = External_training.ListView1.Items(ii).SubItems(1).Text Then
                        If MessageBox.Show("วิทยากรซ้ำกับลำดับที่ " & ii + 1, "",
                                           MessageBoxButtons.OK, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then re = 1
                        numAEXO = numAEXO - 1

                    End If

                Next


                If re = "" Then
                    Dim LV As New ListViewItem(anydata)
                    External_training.ListView1.Items.Add(LV)
                    LV = Nothing

                    External_training.ListView1.EnsureVisible(External_training.ListView1.Items.Count - 1)

                End If

            End If

        Next



            Me.Close()



            'Dim x1 As String = ""
            'Dim x2 As String = ""
            'Dim xx As String = ""


            'For i As Integer = 0 To dgv_Ex.RowCount - 1
            '    If Convert.ToBoolean(dgv_Ex.Rows(i).Cells("checkBoxColumn").Value) = True Then
            '        x1 = dgv_Ex.Rows(i).Cells(1).Value.ToString()
            '        x2 = dgv_Ex.Rows(i).Cells(2).Value.ToString()
            '        xx = xx + " Name : " & x1 & " address : " + x2 & " .. .. .. "
            '        Label4.Text = xx
            '    End If


            'Next



            'For i As Integer = 0 To dgv_Ex.Rows.Count() - 1 Step +1

            '    Dim rowAlreadyExist As Boolean = False
            '    Dim check As Boolean = dgv_Ex.Rows(i).Cells(0).Value
            '    Dim row As DataGridViewRow = dgv_Ex.Rows(i)
            '    If check = True Then

            '        If dgv_Ex.Rows.Count() > 0 Then

            '            For j As Integer = 0 To External_training.ListView1.Items.Count() - 1 Step +1
            '                If row.Cells(0).Value.ToString() = External_training.ListView1.Items(j).SubItems(0).Text Then
            '                    rowAlreadyExist = True
            '                    Exit For

            '                End If
            '            Next

            '            If rowAlreadyExist = False Then
            '                External_training.ListView1.Items.Add(row.Cells(1).Value.ToString(), )
            '                External_training.ListView1.Items.Add()


            '            End If

            '        Else
            '            External_training.ListView1.Items.Add(row.Cells(1).Value.ToString(),
            '                                       row.Cells(2).Value.ToString(),
            '                                       row.Cells(3).Value.ToString(),
            '                                       row.Cells(4).Value)
            '        End If


            '    End If







            'Next



            'Dim cm As New SqlCommand
            'cn.Open()

            'For i As Integer = 0 To dgv_Ex.Rows.Count - 1
            '    If dgv_Ex.Rows(i).Cells(0).Value IsNot Nothing Then
            '        Dim id As [String] = dgv_Ex.Rows(i).Cells(1).Value.ToString()
            '        sql = "select * from Expert where expert_id='" & id & "'"

            '        cm.Connection = cn
            '        cm.CommandType = CommandType.Text
            '        cm.CommandText = sql
            '        cm.ExecuteNonQuery()

            '    End If
            'Next
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        Select Case Asc(e.KeyChar)
            Case 48 To 57 ' key โค๊ด ของตัวเลขจะอยู่ระหว่าง48-57ครับ 48คือเลข0 57คือเลข9ตามลำดับ
                e.Handled = False
            Case 8, 13, 46, 84, 116 ' ปุ่ม Backspace = 8,ปุ่ม Enter = 13, ปุ่มDelete = 46
                e.Handled = False

            Case Else
                e.Handled = True
                MessageBox.Show("สามารถกดได้แค่ตัวเลข และ อักษร T")
        End Select

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress

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

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

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


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        showdata()

    End Sub

    
End Class