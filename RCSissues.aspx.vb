Imports System.Data
Imports System.Data.SqlClient
'Imports Microsoft.ApplicationBlocks.Data

Public Class RCSissues
    Inherits System.Web.UI.Page
    Protected WithEvents Search As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtNtid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSortField As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddDepartments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents sorter As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents dgTimeCardList As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Len(Page.User.Identity.Name) > 0 Then Me.txtNtid.Text = Right(UCase(Page.User.Identity.Name), Len(Page.User.Identity.Name) - 8)

        If Not Page.IsPostBack Then
            PopulateDepartmentDropDown()
            BindData(0, "txtdate")
        Else
        End If
    End Sub

    Sub PopulateDepartmentDropDown()
        'Response.Write("ONE TIME")
        ddDepartments.Items.Clear()

        Dim ds As New DataSet
        Dim conStrFTIME As String = ConfigurationSettings.AppSettings("conESO")
        Dim DataConn As SqlConnection = New SqlConnection(Session("SqlConn1"))
        Dim dbCommand As SqlCommand
        dbCommand = New SqlCommand("sp_Select_Reps", DataConn)

        dbCommand.CommandType = CommandType.StoredProcedure

        DataConn.Open()
        dbCommand.ExecuteNonQuery()

        Dim myDA As New SqlDataAdapter
        myDA.SelectCommand = dbCommand

        Dim myDS As New DataSet
        myDA.Fill(myDS)
        ddDepartments.DataSource = myDS
        ddDepartments.DataTextField = "RepName"
        ddDepartments.DataValueField = "RepName"
        ddDepartments.DataBind()

    End Sub

    Sub BindData(ByVal flg As Integer, ByVal sortex As String)
        Dim dbCommand As SqlCommand
        Dim SQL, mssg As String
        Dim brd As String
        Dim ds As New DataSet

        Dim conStrFTIME As String = ConfigurationSettings.AppSettings("conESO")
        Dim DataConn As SqlConnection = New SqlConnection(Session("SqlConn1"))
        Dim searchVar As String
        searchVar = Me.Search.Text

        'Response.Write(flg)
        If flg = 0 Then
            dbCommand = New SqlCommand("sp_Select_Issues", DataConn)
            dbCommand.CommandType = CommandType.StoredProcedure
            dbCommand.Parameters.Add(New SqlParameter("@sort", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@sort").Value = sortex
        ElseIf flg = 2 Then
            dbCommand = New SqlCommand("sp_Select_Tailboards2", DataConn)
            dbCommand.CommandType = CommandType.StoredProcedure
            dbCommand.Parameters.Add(New SqlParameter("@Search", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@Search").Value = searchVar
            dbCommand.Parameters.Add(New SqlParameter("@sort", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@sort").Value = sortex
        ElseIf flg = 5 Then
            'dgTimeCardList.CurrentPageIndex = 0
            dbCommand = New SqlCommand("sp_Select_RepName_tblRSCissues", DataConn)
            dbCommand.CommandType = CommandType.StoredProcedure
            dbCommand.Parameters.Add(New SqlParameter("@Search", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@Search").Value = Me.ddDepartments.SelectedItem.Value.ToString
            dbCommand.Parameters.Add(New SqlParameter("@sort", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@sort").Value = sortex
        ElseIf flg = 1 Then
            dgTimeCardList.CurrentPageIndex = 0
            dbCommand = New SqlCommand("sp_Select_Tailboards2", DataConn)
            dbCommand.CommandType = CommandType.StoredProcedure
            dbCommand.Parameters.Add(New SqlParameter("@Search", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@Search").Value = searchVar
            dbCommand.Parameters.Add(New SqlParameter("@sort", SqlDbType.NVarChar, 30))
            dbCommand.Parameters("@sort").Value = sortex
        End If

        DataConn.Open()
        dbCommand.ExecuteNonQuery()

        Dim myDA As New SqlDataAdapter
        myDA.SelectCommand = dbCommand

        Dim myDS As New DataSet
        myDA.Fill(myDS)

        dgTimeCardList.DataSource = myDS
        dgTimeCardList.DataBind()

        Me.lblMessage.Text = "Viewing Page " & dgTimeCardList.CurrentPageIndex + 1 & _
              " of " & dgTimeCardList.PageCount

        If DataConn.State = ConnectionState.Open Then
            DataConn.Close()
        End If

    End Sub

    Sub dgOutlook2_Paged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        dgTimeCardList.CurrentPageIndex = e.NewPageIndex
        If Search.Text > "" Then
            BindData(2, Me.txtSortField.Text)
            Me.Textbox1.Text = 2
        ElseIf ddDepartments.SelectedIndex > 0 Then
            BindData(5, Me.txtSortField.Text)
            Me.Textbox1.Text = 5
        Else
            BindData(0, Me.txtSortField.Text)
            Me.Textbox1.Text = 0
        End If

    End Sub


   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        BindData(1, Me.txtSortField.Text)
        Me.Textbox1.Text = 1

    End Sub

    Private Sub ddDepartments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDepartments.SelectedIndexChanged

        If Left(Me.ddDepartments.SelectedItem.Value.ToString, 4) = "file" Then
            Response.Redirect(ddDepartments.SelectedItem.Value.ToString)
        Else
            dgTimeCardList.CurrentPageIndex = 0
            BindData(5, Me.txtSortField.Text)
            Me.Textbox1.Text = 5
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        BindData(0, Me.txtSortField.Text)
        Me.Textbox1.Text = 0
    End Sub

    Sub SortEventHandler(ByVal sender As Object, ByVal e As DataGridSortCommandEventArgs)
        BindData(CInt(Me.Textbox1.Text), e.SortExpression)
        Me.txtSortField.Text = e.SortExpression
    End Sub

End Class
