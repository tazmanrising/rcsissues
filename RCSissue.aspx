<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RCSissue.aspx.vb" Inherits="RCSissues.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RCCS Issues</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Content/bootstrap.min.css" rel="stylesheet" />
		<LINK media="print" href="styles/print.css" type="text/css" rel="stylesheet">
		<LINK media="screen" href="styles/styles.css" type="text/css" rel="stylesheet">

		<style type="text/css">
			.center-block {
			  display: inline-block;
			  margin-left: auto;
			  margin-right: auto;
			}
		</style>

	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;</P>
			<div class="center-block">
			<asp:panel id="Panel1" runat="server" BackColor="WhiteSmoke" Width="499px" Height="318px">
					<TABLE id="Table2" width="60%" border="0">
						<TR>
							<TD width="100%"><FONT color="white">&nbsp; <FONT class="sectionHeader" size="5">RCS ISSUE 
										NOTIFICATION</FONT></FONT></TD>
						</TR>
						<TR>
							<TD width="100%">&nbsp;</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 14px" width="100%">&nbsp;
								<asp:Label id="Label7" runat="server" CssClass="headerLabel">Send To:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:DropDownList id="SendTo" runat="server">
									<asp:ListItem></asp:ListItem>
									<asp:ListItem Value="RCSISSUE">RCSISSUE</asp:ListItem>
									<asp:ListItem Value="$CCSTC">$CCSTC</asp:ListItem>
								</asp:DropDownList></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 14px" width="100%">&nbsp;
								<asp:RadioButton id="rd1" runat="server" CssClass="headerLabel" Text="TFCC" AutoPostBack="True"></asp:RadioButton>&nbsp;&nbsp;
								<asp:RadioButton id="rd2" runat="server" CssClass="headerLabel" Text="REP" AutoPostBack="True"></asp:RadioButton>&nbsp;
								<asp:Label id="Label2" runat="server" CssClass="headerLabel">REP Name</asp:Label>
								<asp:TextBox id="RepName" runat="server" Width="91px" CssClass="text"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Label id="Label3" runat="server" CssClass="headerLabel">Location ID#</asp:Label>
								<asp:TextBox id="LocID" runat="server" Width="103px" CssClass="text"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 23px" width="100%">&nbsp;
								<asp:Label id="Label4" runat="server" CssClass="headerLabel">Date</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:TextBox id="txtdate" runat="server" Width="129px" BackColor="WhiteSmoke" CssClass="text"
									ReadOnly="True"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 13px" width="100%">&nbsp;
								<asp:Label id="Label5" runat="server" CssClass="headerLabel">Problem</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:DropDownList id="Problem" runat="server" CssClass="text">
									<asp:ListItem Value="Undefined" Selected="True">Undefined</asp:ListItem>
									<asp:ListItem Value="Call out record - Should have gone to CI4">Call out record - Should have gone to CI4</asp:ListItem>
									<asp:ListItem Value="Call out record - Should have gone to DFS">Call out record - Should have gone to DFS</asp:ListItem>
									<asp:ListItem Value="Copy/Paste">Copy/Paste</asp:ListItem>
									<asp:ListItem Value="Customer problem">Customer problem</asp:ListItem>
									<asp:ListItem Value="Cut and Pasted from another order">Cut and Pasted from another order</asp:ListItem>
									<asp:ListItem Value="Incorrect type selected">Incorrect type selected</asp:ListItem>
									<asp:ListItem Value="In hold area">In hold area</asp:ListItem>
									<asp:ListItem Value="Invalid Phone Number">Invalid Phone Number</asp:ListItem>
									<asp:ListItem Value="Missing Timeframe">Missing Timeframe</asp:ListItem>
									<asp:ListItem Value="No comments – no initials">No comments – no initials</asp:ListItem>
									<asp:ListItem Value="No comments – with initials">No comments – with initials</asp:ListItem>
									<asp:ListItem Value="No extension given ">No extension given </asp:ListItem>
									<asp:ListItem Value="Not enough information ">Not enough information </asp:ListItem>
									<asp:ListItem Value="No Reprint">No Reprint</asp:ListItem>
									<asp:ListItem Value="RCS rep cancelled trouble call">RCS rep cancelled trouble call</asp:ListItem>
									<asp:ListItem Value="Sent Comments on Closed Call">Sent Comments on Closed Call</asp:ListItem>
									<asp:ListItem Value="Should have gone to design/inspections">Should have gone to design/inspections</asp:ListItem>
									<asp:ListItem Value="Wrong Account">Wrong Account</asp:ListItem>
								</asp:DropDownList></TD>
						</TR>
						<TR>
							<TD width="100%">&nbsp;
								<asp:Label id="Label6" runat="server" CssClass="headerLabel">Additional Information</asp:Label></TD>
						</TR>
						<TR>
							<TD width="100%">&nbsp;
								<asp:TextBox id="Comments" runat="server" Height="111px" Width="478px" CssClass="text" TextMode="MultiLine"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD width="100%">&nbsp;
								<asp:Button id="Button1" runat="server" Text="Submit"></asp:Button>
								<asp:Button id="Button2" runat="server" Text="Update" Visible="False"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="Button3" runat="server" Text="Delete" Visible="False"></asp:Button>
								<asp:Label id="Label1" runat="server" Visible="False" Font-Size="Small" Font-Bold="True">Your Item has been submitted.   Thank you!</asp:Label>
								<asp:TextBox id="NTID" runat="server" Width="77px" Visible="False"></asp:TextBox>
								<asp:TextBox id="Super" runat="server" Width="77px" Visible="False"></asp:TextBox></TD>
						</TR>
					</TABLE>
				</asp:panel>
				</div>
			
		</form>
	</body>
</HTML>
