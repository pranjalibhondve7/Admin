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
    
    public partial class Category : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string cnfg = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cnfg);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        protected void LoadData()
        {
            cmd.CommandText = "Select  Menu_Category_Id,Category_Name from Menu_Category ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
       

        protected void btnsave_Click(object sender, EventArgs e)
        {
            SqlDataAdapter de = new SqlDataAdapter("select Category_Name from Menu_Category where Category_Name='" + txtname.Text + "'", con);
            DataTable dt = new DataTable();
            de.Fill(dt);
            //  con.Open();
            // int i = cmd.ExecuteNonQuery();
            if (dt.Rows.Count >= 1)
            {
                Response.Write("<script>alert('Already data exits...!')</script>");
            }
            else
            {
                con.Open();
                cmd.CommandText = "Insert Into  Menu_Category(Category_Name)values('"+txtname.Text+"') ";
                cmd.ExecuteNonQuery();
                con.Close();
                txtname.Text = "";
            //    con.Open();
            //    int index = cmd.ExecuteNonQuery();
            //    if (index > 0)
            //{
                Response.Write("<script>alert('Insert Data Successfully..........')</script>");
            }
            con.Close();
            //else
            //{
            //    Response.Write("<script>alert('Insert Data Failed......')</script>");
            //}
            //con.Close();
            LoadData();
        }
    }
}