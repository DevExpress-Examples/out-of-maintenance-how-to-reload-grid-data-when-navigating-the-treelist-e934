<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="SyncWithGridOnUpdatePanel._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v8.1, Version=8.1.4.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.1, Version=8.1.4.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.1, Version=8.1.4.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server" />
	<div>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" OnFocusedNodeChanged="ASPxTreeList1_FocusedNodeChanged">
				</dxwtl:ASPxTreeList>
				<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" OnFocusedRowChanged="ASPxGridView1_FocusedRowChanged">
				</dxwgv:ASPxGridView>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	</form>
</body>
</html>
