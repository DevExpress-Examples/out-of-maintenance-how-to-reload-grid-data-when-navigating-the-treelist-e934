using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SyncWithGridOnUpdatePanel {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            BindTreeList();
            BindGrid();
        }

        private void BindTreeList() {
            ASPxTreeList1.DataSource = GetData();
            ASPxTreeList1.KeyFieldName = "ID";

            ASPxTreeList1.ParentFieldName = "ParentID";
            ASPxTreeList1.EnableCallbacks = false;
            ASPxTreeList1.SettingsBehavior.AllowFocusedNode = true;
            ASPxTreeList1.SettingsBehavior.ProcessFocusedNodeChangedOnServer = true;
            if(ASPxTreeList1.Columns.Count == 0) {
                DevExpress.Web.ASPxTreeList.TreeListDataColumn col = new DevExpress.Web.ASPxTreeList.TreeListDataColumn();
                col.FieldName = "Name";
                ASPxTreeList1.Columns.Add(col);
            }
            ASPxTreeList1.DataBind();
        }
        private void BindGrid() {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.EnableCallBacks = false;
            ASPxGridView1.SettingsBehavior.AllowFocusedRow = true;
            ASPxGridView1.SettingsBehavior.ProcessFocusedRowChangedOnServer = true;
            if(!IsPostBack && !IsCallback)
                ASPxGridView1.DataBind();
        }

        private DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ParentID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            for(int i = 0; i < 10; i++) {
                table.Rows.Add(i, -1, "Item " + (i + 1).ToString());
            }
            return table;
        }

        protected void ASPxTreeList1_FocusedNodeChanged(object sender, EventArgs e) {
            object key = ASPxTreeList1.FocusedNode.Key;
            if(key != null)
                ASPxGridView1.FocusedRowIndex = ASPxGridView1.FindVisibleIndexByKeyValue(key);
        }

        protected void ASPxGridView1_FocusedRowChanged(object sender, EventArgs e) {
            object key = ASPxGridView1.GetRowValues(ASPxGridView1.FocusedRowIndex, "ID");
            if(key != null) {
                DevExpress.Web.ASPxTreeList.TreeListNode node = ASPxTreeList1.FindNodeByKeyValue(key.ToString());
                if(node != null)
                    node.Focus();
            }
        }
    }
}
