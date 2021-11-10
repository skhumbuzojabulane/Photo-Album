using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class WebPage_Site : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void page_preRender()
    {
        string Folder = Server.MapPath("~/Images/Upload/"); 
        DirectoryInfo dir = new DirectoryInfo(Folder);
        imgList.DataSource = dir.GetFiles();
        imgList.DataBind();
    }

    bool checkFileType(string filename)
    {
        string ext = Path.GetExtension(filename);
        switch (ext.ToLower())
        {
            case".gif":
                return true;
            case ".bmp":
                return true;
            case ".ico":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            case ".tiff":
                return true;
            case ".png":
                return true;
            default:
                return false;
        }
    }

    protected void searchTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        searchTextBox.Focus();
        searchTextBox.Text = "";

        try
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security = True";
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM upload1 WHERE image LIKE '%'+@searchTextBox+'%'";
            cmd.CommandText = sqlQuery;
            cmd.Connection = sqlconn;
            cmd.Parameters.AddWithValue("image", searchTextBox.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            imgList.DataSource = dt;
            imgList.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void imgList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}