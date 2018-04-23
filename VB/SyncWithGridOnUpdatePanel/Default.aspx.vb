Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace SyncWithGridOnUpdatePanel
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			BindTreeList()
			BindGrid()
		End Sub

		Private Sub BindTreeList()
			ASPxTreeList1.DataSource = GetData()
			ASPxTreeList1.KeyFieldName = "ID"

			ASPxTreeList1.ParentFieldName = "ParentID"
			ASPxTreeList1.EnableCallbacks = False
			ASPxTreeList1.SettingsBehavior.AllowFocusedNode = True
			ASPxTreeList1.SettingsBehavior.ProcessFocusedNodeChangedOnServer = True
			If ASPxTreeList1.Columns.Count = 0 Then
				Dim col As New DevExpress.Web.ASPxTreeList.TreeListDataColumn()
				col.FieldName = "Name"
				ASPxTreeList1.Columns.Add(col)
			End If
			ASPxTreeList1.DataBind()
		End Sub
		Private Sub BindGrid()
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.EnableCallBacks = False
			ASPxGridView1.SettingsBehavior.AllowFocusedRow = True
			ASPxGridView1.SettingsBehavior.ProcessFocusedRowChangedOnServer = True
			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				ASPxGridView1.DataBind()
			End If
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("ParentID", GetType(Integer))
			table.Columns.Add("Name", GetType(String))
			For i As Integer = 0 To 9
				table.Rows.Add(i, -1, "Item " & (i + 1).ToString())
			Next i
			Return table
		End Function

		Protected Sub ASPxTreeList1_FocusedNodeChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim key As Object = ASPxTreeList1.FocusedNode.Key
			If key IsNot Nothing Then
				ASPxGridView1.FocusedRowIndex = ASPxGridView1.FindVisibleIndexByKeyValue(key)
			End If
		End Sub

		Protected Sub ASPxGridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim key As Object = ASPxGridView1.GetRowValues(ASPxGridView1.FocusedRowIndex, "ID")
			If key IsNot Nothing Then
				Dim node As DevExpress.Web.ASPxTreeList.TreeListNode = ASPxTreeList1.FindNodeByKeyValue(key.ToString())
				If node IsNot Nothing Then
					node.Focus()
				End If
			End If
		End Sub
	End Class
End Namespace
