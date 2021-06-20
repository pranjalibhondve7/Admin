using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class Demo_Grid1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string cnfg = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cnfg);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cnfg);
            con.Open();
            adapt = new SqlDataAdapter("Select * from Menu_Item", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }
        
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //GridView1.EditIndex = -1;
            //ShowData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox c_id = GridView1.Rows[e.RowIndex].FindControl("txt_catid") as TextBox;
            TextBox items = GridView1.Rows[e.RowIndex].FindControl("txt_items") as TextBox;
            TextBox rate = GridView1.Rows[e.RowIndex].FindControl("txt_rate") as TextBox;
            TextBox dis = GridView1.Rows[e.RowIndex].FindControl("txt_dis") as TextBox;
            con = new SqlConnection(cnfg);
            con.Open();
            //updating the record  
            SqlCommand cmd = new SqlCommand("Update Menu_Item set Menu_Category_Id='" + c_id.Text + "',Menu_Items='" + items.Text + "',Price='" + rate.Text + "',Discount='" + dis.Text + "' where Menu_Id=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }
        protected void btndelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            cmd.CommandText = "Delete Menu_Item where Menu_Id=" + id + "";
            con.Open();
            int index = cmd.ExecuteNonQuery();
            if (index > 0)
            {
                Response.Write("<script>alert(' Deleted  Successfully.....')</script>");
            }
            else
            {
                Response.Write("<script>alert('Details Not Deleted .....')</script>");
            }
            con.Close();
            ShowData();
        }
    }
}