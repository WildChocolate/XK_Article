using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Text;

namespace XkAarticle.Administrate.Verify
{
    public partial class FrmQueryUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["RoleList"] = BindRole();
            if (!IsPostBack)
            {
                var userBLL = new UserBLL();
                var userList = userBLL.GetAll(new User(),"");
                UserGridView.DataSource = userList;
                UserGridView.DataBind();
                
            }
            
        }
        public List<Role> RoleList
        {
            get { return ViewState["RoleList"] as List<Role>; }
        }
        public List<Role> BindRole()
        {
            var roleBLL = new RoleBLL();
            var roleList = roleBLL.GetAll(new Role(), "");
            return roleList;
        }

        

        
        protected void UserGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var idx = e.Row.RowIndex;
                var ddl = e.Row.FindControl("ddlRole") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = RoleList;
                    ddl.DataBind();
                    var userDataSource = UserGridView.DataSource as List<User>;
                    if (userDataSource != null)
                    {
                        ddl.SelectedValue = userDataSource[e.Row.RowIndex ].RoleID + "";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb=new StringBuilder ();
            foreach (GridViewRow row in UserGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    var chkBox = row.Cells[0].FindControl("ChkUser") as CheckBox;
                    if (chkBox.Checked)
                    {
                        string ID = UserGridView.DataKeys[row.RowIndex].Value+"";
                        var ddl = row.Cells[row.Cells.Count - 1].FindControl("ddlRole") as DropDownList;
                        var val = ddl.SelectedValue;
                        sb.AppendLine(string.Format("update XK_User set RoleID=" + val + " where ID="+ID));
                    }
                }
            }
            if (sb.Length > 0)
            {
                var userBLL = new UserBLL();
                var result = userBLL.UpdateByCommandString(sb.ToString(), "");
                if (result>0)
                {
                    lbTip.Text = "修改成功！！！";
                    
                    var userList = userBLL.GetAll(new User(), "");
                    UserGridView.DataSource = userList;
                    UserGridView.DataBind();
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string whereString = "";
            foreach (GridViewRow row in UserGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    var chkBox = row.Cells[0].FindControl("ChkUser") as CheckBox;
                    if (chkBox.Checked)
                    {
                        string ID = UserGridView.DataKeys[row.RowIndex].Value + "";
                        whereString+=ID+",";
                    }
                }
            }
            if (whereString.Length > 0)
            {
                whereString = " where ID in(" + whereString.TrimEnd(',') + ")";
                var userBLL = new UserBLL();
                var result = userBLL.UpdateByCommandString("delete from XK_User "+whereString ,"");
                if (result > 0)
                {
                    lbTip.Text = "删除成功！！！";
                    
                    var userList = userBLL.GetAll(new User(), "");
                    UserGridView.DataSource = userList;
                    UserGridView.DataBind();
                }
            }
            
        }

        
    }
}