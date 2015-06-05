Imports System.Data
Imports System.Web.Mail
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents RepName As System.Web.UI.WebControls.TextBox
    Protected WithEvents LocID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Problem As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Comments As System.Web.UI.WebControls.TextBox
    Protected WithEvents NTID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents SendTo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Super As System.Web.UI.WebControls.TextBox
    Protected WithEvents rd1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rd2 As System.Web.UI.WebControls.RadioButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("values") > "" Then
                Button1.Visible = False
                Button3.Visible = True
                Button2.Visible = True
                '1. Create a connection
                Dim myConnection1 As SqlConnection
                myConnection1 = New SqlConnection(Session("SqlConn1"))
                '2. Create the command object, passing in the SQL string
                Dim values As String
                Dim strSQL1 As String = "select * from tblRCSIssues WHERE ID =" & Request.QueryString("values")
                Dim myCommand1 As New SqlCommand(strSQL1, myConnection1)

                Dim SQLDataReader As SqlDataReader
                myConnection1.Open()
                SQLDataReader = myCommand1.ExecuteReader()

                Do While SQLDataReader.Read() = True
                    RepName.Text = SQLDataReader("RepName").ToString
                    SendTo.SelectedItem.Value = SQLDataReader("SendTo").ToString
                    NTID.Text = SQLDataReader("ntid").ToString
                    LocID.Text = SQLDataReader("LocID").ToString
                    Comments.Text = SQLDataReader("Comments").ToString
                    txtdate.Text = SQLDataReader("txtdate").ToString
                    Problem.SelectedItem.Value = SQLDataReader("Problem").ToString
                Loop
                SQLDataReader.Close()

            Else

                Me.txtdate.Text = FormatDateTime(Now(), DateFormat.ShortDate)
				Dim strTemp As Array

				Try
					strTemp = Split(Request.ServerVariables("REMOTE_USER"), "\")
					Me.NTID.Text = UCase(strTemp(1))
				Catch ex As Exception
					strTemp = Split(System.Security.Principal.WindowsIdentity.GetCurrent().Name, "\")
					Me.NTID.Text = UCase(strTemp(1))
				End Try




            End If



        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dbCommand1 As SqlCommand
        Dim SQL1, mssg1 As String
        Dim brd1 As String
        Dim ds1 As New DataSet

        Dim conStrStop1 As String = Session("SqlConn2")
        Dim DataConn1 As SqlConnection = New SqlConnection(conStrStop1)
        'All of the params
        dbCommand1 = New SqlCommand("sp_Select_tblRegister", DataConn1)
        dbCommand1.CommandType = CommandType.StoredProcedure

        dbCommand1.Parameters.Add(New SqlParameter("@RepName", SqlDbType.NVarChar, 10))
        dbCommand1.Parameters("@RepName").Value = Me.RepName.Text
        DataConn1.Open()
        dbCommand1.ExecuteNonQuery()
        Dim SQLDataReader1 As SqlDataReader
        SQLDataReader1 = dbCommand1.ExecuteReader()
        Do While SQLDataReader1.Read() = True
            Me.Super.Text = SQLDataReader1("manager").ToString
        Loop

        If DataConn1.State = ConnectionState.Open Then
            DataConn1.Close()
        End If


        Dim dbCommand As SqlCommand
        Dim SQL, mssg As String
        Dim brd As String
        Dim ds As New DataSet

        Dim conStrStop As String = Session("SqlConn1")
        Dim DataConn As SqlConnection = New SqlConnection(conStrStop)
        'All of the params
        dbCommand = New SqlCommand("sp_Insert_tblRCSissues", DataConn)
        dbCommand.CommandType = CommandType.StoredProcedure

        dbCommand.Parameters.Add(New SqlParameter("@SendTo", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@SendTo").Value = Me.SendTo.SelectedItem.Value

        dbCommand.Parameters.Add(New SqlParameter("@NTID", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@NTID").Value = Me.NTID.Text

        dbCommand.Parameters.Add(New SqlParameter("@RepName", SqlDbType.NVarChar, 20))
        dbCommand.Parameters("@RepName").Value = UCase(Me.RepName.Text)

        dbCommand.Parameters.Add(New SqlParameter("@LocID", SqlDbType.NVarChar, 15))
        dbCommand.Parameters("@LocID").Value = Me.LocID.Text

        dbCommand.Parameters.Add(New SqlParameter("@txtDate", SqlDbType.DateTime))
        dbCommand.Parameters("@txtDate").Value() = CDate(Me.txtdate.Text)

        dbCommand.Parameters.Add(New SqlParameter("@Problem", SqlDbType.NVarChar, 50))
        dbCommand.Parameters("@Problem").Value = Me.Problem.SelectedItem.Value

        dbCommand.Parameters.Add(New SqlParameter("@Comments", SqlDbType.NText))
        dbCommand.Parameters("@Comments").Value = Me.Comments.Text & vbCrLf & vbCrLf & "Submitted by:" & NTID.Text

        dbCommand.Parameters.Add(New SqlParameter("@Super", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@Super").Value = UCase(Me.Super.Text)

        DataConn.Open()
        dbCommand.ExecuteNonQuery()


        'Close the Connection
        If DataConn.State = ConnectionState.Open Then
            DataConn.Close()
        End If

        If Me.SendTo.SelectedItem.Text > "" Then
            Dim objMM As New MailMessage

            'Set the properties
            Dim strTemp2
            strTemp2 = Split(Request.ServerVariables("REMOTE_USER"), "\")
            objMM.To = UCase(strTemp2(1)) & "@srpnet.com"
            If Me.SendTo.SelectedItem.Text = "RCSISSUE" Then
				objMM.To = "tom.stickel@srpnet.com"	' "jlhungat@srpnet.com"
            Else
                objMM.To = "$CCSTC@srpnet.com"
            End If

            'objMM.From = UCase(strTemp2(1)) & "@srpnet.com"
            objMM.From = "OPCOORDS@srpnet.com"

            'If you want to CC this email to someone else...
            'objMM.Cc = "someone2@someaddress.com"

            'If you want to BCC this email to someone else...

            'objMM.Bcc = "JLHUNGAT@srpexc00.srp.gov"
            'objMM.Bcc = "MXANDERS@srpnet.com"
            'Send the email in text format
            objMM.BodyFormat = MailFormat.Text
            '(to send HTML format, change MailFormat.Text to MailFormat.Html)

            'Set the priority - options are High, Low, and Normal
            objMM.Priority = MailPriority.Normal

            'Set the subject
            objMM.Subject = "RCS Issue: " & UCase(Super.Text) & " / " & UCase(RepName.Text) & "-" & LocID.Text

            'Set the body - use VbCrLf to insert a carriage return
            Dim bbstring As String
            'ddCC.SelectedItem.Text

            'bbstring = "DATE: " & txtdate.Text & vbCrLf & "COST CENTER: " & txtCC.Text & vbCrLf & "CREW: " & txtCrew.Text & vbCrLf & "SHIFT: " & ddShift.SelectedItem.Text
            ' bbstring = bbstring & vbCrLf & "AREA: " & CCdesc.Text & vbCrLf & "NOTES: " & txtNotes.Text
            '        If ddEmplyee.SelectedItem.Text > "" Then bbstring = bbstring & vbCrLf & vbCrLf & "EMPLOYEE 1: " & ddEmplyee.SelectedItem.Text
            '       If txtHours1.Text > "" Then bbstring = bbstring & vbCrLf & txtFRFM_FIS_CHRG_N1.Text & Space(CInt(23 - Len(txtFRFM_FIS_CHRG_N1.Text))) & txtHours1.Text & Space(CInt(9 - (Len(txtHours1.Text)))) & drpET_C1.SelectedItem.Text & Space(5) & drpOT1.SelectedItem.Text & Space(CInt(7 - Len(drpOT1.SelectedItem.Text))) & drpMOA1.SelectedItem.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "-------------------------------------------------------------"
            bbstring = bbstring & vbCrLf & "Rep Name:     " & RepName.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "Location ID:  " & LocID.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "Date:         " & txtdate.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "Problem:      " & Problem.SelectedItem.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "Comments:     " & Comments.Text
            'bbstring = bbstring & vbCrLf & vbCrLf & "Submitted by:" & NTID.Text
            bbstring = bbstring & vbCrLf & vbCrLf & "-------------------------------------------------------------"
            objMM.Body = bbstring
            'Now, to send the message, use the Send method of the SmtpMail class
            SmtpMail.SmtpServer = "Mail.srp.gov"
            SmtpMail.Send(objMM)

        Else
        End If
        If Me.NTID.Text = "MXANDERS" Or Me.NTID.Text = "JLHUNGAT" Then
            Response.Redirect("RCSissues.aspx")
        Else
            'Me.SendTo.SelectedItem.Text = ""
            'Me.RepName.Text = ""
            'Me.LocID.Text = ""
            'Me.Problem.SelectedItem.Text = ""
            'Me.Comments.Text = ""
            'Me.Super.Text = ""
            Response.Redirect("RCSissue.aspx")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dbCommand As SqlCommand
        Dim SQL, mssg As String
        Dim brd As String
        Dim ds As New DataSet

        Dim conStrStop As String = Session("SqlConn1")
        Dim DataConn As SqlConnection = New SqlConnection(conStrStop)
        'All of the params
        dbCommand = New SqlCommand("sp_update_tblRCSissues", DataConn)
        dbCommand.CommandType = CommandType.StoredProcedure

        dbCommand.Parameters.Add(New SqlParameter("@SendTo", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@SendTo").Value = Me.SendTo.SelectedItem.Value

        dbCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.BigInt))
        dbCommand.Parameters("@ID").Value = Request.QueryString("values")

        dbCommand.Parameters.Add(New SqlParameter("@NTID", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@NTID").Value = Me.NTID.Text

        dbCommand.Parameters.Add(New SqlParameter("@RepName", SqlDbType.NVarChar, 20))
        dbCommand.Parameters("@RepName").Value = Me.RepName.Text

        dbCommand.Parameters.Add(New SqlParameter("@LocID", SqlDbType.NVarChar, 15))
        dbCommand.Parameters("@LocID").Value = Me.LocID.Text

        dbCommand.Parameters.Add(New SqlParameter("@txtDate", SqlDbType.DateTime))
        dbCommand.Parameters("@txtDate").Value() = CDate(Me.txtdate.Text)

        dbCommand.Parameters.Add(New SqlParameter("@Problem", SqlDbType.NVarChar, 50))
        dbCommand.Parameters("@Problem").Value = Me.Problem.SelectedItem.Value

        dbCommand.Parameters.Add(New SqlParameter("@Comments", SqlDbType.NText))
        dbCommand.Parameters("@Comments").Value = Me.Comments.Text

        dbCommand.Parameters.Add(New SqlParameter("@Super", SqlDbType.NVarChar, 10))
        dbCommand.Parameters("@Super").Value = Me.Super.Text

        DataConn.Open()
        dbCommand.ExecuteNonQuery()

        If DataConn.State = ConnectionState.Open Then
            DataConn.Close()
        End If

        'Close the Connection
        If DataConn.State = ConnectionState.Open Then
            DataConn.Close()
        End If
        Response.Redirect("RCSissues.aspx")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dbCommandd As SqlCommand
        Dim SQLd, mssgd As String
        Dim brdd As String
        Dim dsbegd As New DataSet
        Dim conStrFTIMEd As String = Session("SqlConn1")
        Dim DataConnd As SqlConnection = New SqlConnection(conStrFTIMEd)
        'All of the params
        dbCommandd = New SqlCommand("Delete_tblRCSissues", DataConnd)
        dbCommandd.CommandType = CommandType.StoredProcedure

        dbCommandd.Parameters.Add(New SqlParameter("@id", SqlDbType.NVarChar, 50))
        dbCommandd.Parameters("@id").Value = Request.QueryString("values")
        'Try
        'Open the connection and execute the Command
        DataConnd.Open()
        dbCommandd.ExecuteNonQuery()
        If DataConnd.State = ConnectionState.Open Then
            DataConnd.Close()
        End If
        Response.Redirect("RCSissues.aspx")
    End Sub

    Private Sub Problem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Problem.SelectedIndexChanged

    End Sub

    Private Sub rd1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd1.CheckedChanged
        Me.rd2.Checked = False
        Me.RepName.Enabled = False
        Me.RepName.Text = "TFCC"
    End Sub

    Private Sub rd2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd2.CheckedChanged
        Me.rd1.Checked = False
        Me.RepName.Enabled = True
        Me.RepName.Text = ""
    End Sub
End Class
