using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPage_shareWith : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security=True");
        string com = "Select * from upload";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataValueField = "capturedBy";
        DropDownList1.DataBind();
        Label1.Visible = false;
    }

    protected void shareButton_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("select * from upload where capturedBy = '" + DropDownList1.SelectedValue + "'", con);
        SqlDataAdapter Adpt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        Adpt.Fill(dt);
        Label1.Visible = true;
        Label1.Text = "Photo Shared";
        Label1.ForeColor = System.Drawing.Color.Green;
    }
}