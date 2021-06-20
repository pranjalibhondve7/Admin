using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class Add_Item : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string cnfg = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cnfg);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                //LoadData();
                dropdown();
            }
        }
        protected void dropdown()
        {
            SqlConnection con = new SqlConnection(cnfg);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Menu_Category", con);
            //cmd.CommandType = CommandType.Text;
            ddlcat.DataSource = cmd.ExecuteReader();
            ddlcat.DataTextField = "Category_Name";
            ddlcat.DataValueField = "Menu_Category_Id";
            ddlcat.DataBind();
            ddlcat.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Insert Into  Menu_Item(Menu_Category_Id,Menu_Items,Price,Discount)values('" + ddlcat.Text + "','" + txtname.Text + "','"+ txtrate.Text + "','"+ txtdis.Text + "') ";
            con.Open();
            int index = cmd.ExecuteNonQuery();
            if (index > 0)
            {
                Response.Write("<script>alert('Insert Data Successfully..........')</script>");
            }
            else
            {
                Response.Write("<script>alert('Insert Data Failed......')</script>");
            }
            con.Close();
        }
    }
}