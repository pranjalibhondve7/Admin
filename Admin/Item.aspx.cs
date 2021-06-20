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
    public partial class Item : System.Web.UI.Page
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
                LoadData();
                dropdown();
            }
            //LoadData();
            
        }
        protected void LoadData()
        {
            string cnfg = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            cmd.CommandText = "Select  * from Menu_Item ";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void dropdown()
        {
            SqlConnection con = new SqlConnection(cnfg);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Menu_Category", con);
            cmd.CommandType = CommandType.Text;
            ddlcat.DataSource = cmd.ExecuteReader();
            ddlcat.DataTextField = "Category_Name";
            ddlcat.DataValueField = "Menu_Category_Id";
            ddlcat.DataBind();
            ddlcat.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();
        }        
        protected void btnsave_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter de = new SqlDataAdapter("select Menu_Items from Menu_Item where Menu_Items='" + txtitem.Text + "'", con);
            //DataTable dt = new DataTable();
            //de.Fill(dt);
            ////  con.Open();
            //// int i = cmd.ExecuteNonQuery();
            //if (dt.Rows.Count >= 1)
            //{
            //    Response.Write("<script>alert('Already data exits...!')</script>");

            //}
            //else
            //{
            //    con.Open();
                cmd.CommandText = "Insert Into  Menu_Item(Menu_Category_Id,Menu_Items)values('" + ddlcat.Text + "','"+txtitem.Text+"') ";
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
            LoadData();
        }

        protected void btnupdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            cmd.CommandText = "Update  Menu_Item set Menu_Items='" + txtname.Text + "' where Menu_Id="+id+" ";
            con.Open();
            int index = cmd.ExecuteNonQuery();
            if (index > 0)
            {
                Response.Write("<script>alert('Deleted Data Successfully..........')</script>");
            }
            else
            {
                Response.Write("<script>alert('Deleted Data Failed......')</script>");
            }
            con.Close();
            LoadData();
        }

        protected void btnselect_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from Menu_Item where Menu_Id =" + id + "";
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtitemid.Text = dt.Rows[0]["Menu_Id"].ToString();
                txtid.Text = dt.Rows[0]["Menu_Category_Id"].ToString();
                txtname.Text = dt.Rows[0]["Menu_Items"].ToString();                
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btndelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            cmd.CommandText = "Delete Menu_Item where Menu_Id=" + id + "";
            con.Open();
            int index = cmd.ExecuteNonQuery();
            if (index > 0)
            {
                Response.Write("<script>alert('Deleted Successfully.....')</script>");
            }
            else
            {
                Response.Write("<script>alert('Details Not Deleted .....')</script>");
            }
            con.Close();
            LoadData();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Update Menu_Item set Menu_Category_Id='"+ txtid.Text + "',Menu_Items='" + txtname.Text + "' where Menu_Id='" + txtitemid.Text + "'";
            con.Open();
            int index = cmd.ExecuteNonQuery();
            if (index > 0)
            {
                Response.Write("<script>alert('Details Update Successfully.....')</script>");
            }
            else
            {
                Response.Write("<script>alert('Details Not Update .....')</script>");
            }
            con.Close();
            LoadData();
        }



        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{

        //    cmd.CommandText = "Update  Menu_Item set Menu_Items='" + txtname.Text + "' where Menu_Id=" + id + " ";
        //    con.Open();
        //    int index = cmd.ExecuteNonQuery();
        //    if (index > 0)
        //    {
        //        Response.Write("<script>alert('Updated Data Successfully..........')</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Update Data Failed......')</script>");
        //    }
        //    con.Close();
        //}

        //protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cmd.CommandText = "Select * from Menu_Category";
        //    cmd.CommandType = CommandType.Text;
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    ddlcat.DataSource = dr;
        //    ddlcat.DataValueField = "Menu_Category_Id";
        //    ddlcat.DataTextField = "Category_Name";
        //    ddlcat.DataBind();
        //    //ddlcat.Items.Insert(0, "--Select Category--");
        //    con.Close();
        //}

    }
}