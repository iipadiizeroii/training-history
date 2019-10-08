Imports System.IO
Imports System.Data.SqlClient

Public Class frmAdd_Expert_in

#Region "showdata"
    Private Sub showdata()
        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Expert")
        With dgv_In
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

            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable


        End With
        dgv_In.AllowUserToAddRows = False
    End Sub
#End Region

#Region "สร้างช่อง CheckBox"
    Private headerCheckBox As CheckBox = New CheckBox()
    Private Sub BindGrid()

        'Add a CheckBox Column to the DataGridView Header Cell.

        'Find the Location of Header Cell.
        Dim headerCellLocation As Point = Me.dgv_In.GetCellDisplayRectangle(0, -1, True).Location

        'Place the Header CheckBox in the Location of the Header Cell.
        headerCheckBox.Location = New Point(headerCellLocation.X + 8, headerCellLocation.Y + 2)
        headerCheckBox.BackColor = Color.White
        headerCheckBox.Size = New Size(18, 18)

        'Assign Click event to the Header CheckBox.
        AddHandler headerCheckBox.Click, AddressOf HeaderCheckBox_Clicked
        dgv_In.Controls.Add(headerCheckBox)

        'Add a CheckBox Column to the DataGridView at the first position.
        Dim checkBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "checkBoxColumn"
        dgv_In.Columns.Insert(0, checkBoxColumn)
        'Assign Click event to the DataGridView Cell.
        AddHandler dgv_In.CellContentClick, AddressOf dgv_In_CellClick
    End Sub

    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Necessary to end the edit mode of the Cell.
        dgv_In.EndEdit()

        'Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
        For Each row As DataGridViewRow In dgv_In.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("checkBoxColumn"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
    End Sub

    Private Sub dgv_In_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        'Check to ensure that the row CheckBox is clicked.
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then

            'Loop to verify whether all row CheckBoxes are checked or not.
            Dim isChecked As Boolean = True
            For Each row As DataGridViewRow In dgv_In.Rows
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



        Dim DataShow As DataTable = SqlTable(" SELECT * FROM Expert Where expert_id LIKE '%" & TextBox1.Text & "%' AND expert_name LIKE '%" & TextBox2.Text & "%' AND expert_expertise LIKE '%" & TextBox3.Text & "%' ")
        With dgv_In
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
#End Region

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub frmAdd_Expert_in_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        showdata()
        BindGrid()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i As Integer = 0 To dgv_In.RowCount - 1
            If Convert.ToBoolean(dgv_In.Rows(i).Cells("checkBoxColumn").Value) = True Then
                str1 = dgv_In.Rows(i).Cells(1).Value.ToString()
                str2 = dgv_In.Rows(i).Cells(2).Value.ToString()
                str3 = dgv_In.Rows(i).Cells(3).Value.ToString()
                str4 = dgv_In.Rows(i).Cells(4).Value.ToString()
                str5 = dgv_In.Rows(i).Cells(5).Value.ToString()
                str6 = dgv_In.Rows(i).Cells(6).Value.ToString()


                numAEXI = numAEXI + 1
                Dim anydata() As String
                anydata = New String() {numAEXI, str1, str2, str3, str4, str5, str6}
                Dim LV As New ListViewItem(anydata)
                Internal_training.ListView1.Items.Add(LV)
                LV = Nothing

                Internal_training.ListView1.EnsureVisible(Internal_training.ListView1.Items.Count - 1)

            End If


        Next


        Me.Close()

    End Sub
End Class