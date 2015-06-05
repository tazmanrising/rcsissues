<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RCSissues.aspx.vb" Inherits="RCSissues.RCSissues"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RCSissues</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Content/bootstrap.min.css" rel="stylesheet" />
        <LINK media="print" href="styles/print.css" type="text/css" rel="stylesheet">
		<LINK media="screen" href="styles/styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="WIDTH: 343px"><asp:label id="Label1" runat="server" Visible="False">Observer Search:</asp:label><asp:textbox id="Search" runat="server" Visible="False"></asp:textbox><asp:button id="Button1" runat="server" Visible="False" Text="Search"></asp:button></TD>
						<TD style="WIDTH: 209px" align="right"><asp:hyperlink id="HyperLink1" runat="server" NavigateUrl="RCSissue.aspx">New Issue</asp:hyperlink><asp:textbox id="sorter" runat="server" Visible="False" Width="24px"></asp:textbox><asp:textbox id="txtNtid" runat="server" Visible="False" Width="24px"></asp:textbox><asp:textbox id="txtSortField" runat="server" Visible="False" Width="24px">id</asp:textbox><asp:textbox id="Textbox1" runat="server" Visible="False" Width="24px">0</asp:textbox>&nbsp;&nbsp;</TD>
						<TD align="right"><asp:label id="Label2" runat="server">Rep</asp:label>&nbsp;
							<asp:dropdownlist id="ddDepartments" runat="server" AutoPostBack="True"></asp:dropdownlist><asp:button id="Button2" runat="server" Text="All"></asp:button></TD>
					</TR>
				</TABLE>
			</P>
			<P><asp:datagrid id="dgTimeCardList" runat="server" Width="95%" AutoGenerateColumns="False" HorizontalAlign="Center"
					Font-Name="Verdana" Font-Size="10pt" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
					CellPadding="3" Font-Names="Verdana" GridLines="Vertical" PageSize="30" OnPageIndexChanged="dgOutlook2_Paged"
					AllowPaging="True" AllowSorting="True" OnSortCommand="SortEventHandler" BackColor="White">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#000084"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="">
							<ItemTemplate>
								<a class="lnk" href='RCSissue.aspx?values=<%# Container.DataItem("ID") %>'>View</a>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:HyperLinkColumn Visible="False" Text="View" Target="_blank" DataNavigateUrlField="ID" DataNavigateUrlFormatString="ViewDetail.aspx?values={0}&amp;id={0}"></asp:HyperLinkColumn>
						<asp:BoundColumn DataField="SendTo" SortExpression="SendTo" HeaderText="Sent To"></asp:BoundColumn>
						<asp:BoundColumn DataField="RepName" SortExpression="RepName" HeaderText="Rep Name"></asp:BoundColumn>
						<asp:BoundColumn DataField="LocID" SortExpression="LocID" HeaderText="Location ID"></asp:BoundColumn>
						<asp:BoundColumn DataField="txtDate" SortExpression="txtDate" HeaderText="txtDate" DataFormatString="{0:MM-dd-yyyy}"></asp:BoundColumn>
						<asp:BoundColumn DataField="Problem" SortExpression="Problem" HeaderText="Problem"></asp:BoundColumn>
						<asp:BoundColumn DataField="Comments" HeaderText="Comments">						
							<ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Super" SortExpression="Super" HeaderText="Supervisor"></asp:BoundColumn>
					</Columns>
					<PagerStyle NextPageText="Next Page &gt;&gt;" PrevPageText="&lt;&lt; Prev. Page" HorizontalAlign="Center"
						ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				</asp:datagrid><asp:label id="lblMessage" runat="server" Font-Name="Verdana" Font-Size="Smaller" Font-Italic="True"></asp:label>&nbsp;&nbsp;</P>
		</form>
	</body>
</HTML>
