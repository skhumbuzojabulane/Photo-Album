using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class WebPage_Site : System.Web.UI.Page
{
    string constr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security=True";
    public SqlConnection conn;
    public DataSet ds;
    public SqlDataAdapter adapter;

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
            case ".gif":
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
            String sql;
            conn = new SqlConnection(constr);
            conn.Open();
            sql = @"SELECT * FROM Upload WHERE capturedBy LIKE '" + searchTextBox.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string Folder = Server.MapPath("~/Images/Upload/");
            DirectoryInfo dir = new DirectoryInfo(Folder);
            imgList.DataSource = dir.GetFiles();
            imgList.DataBind(); ;
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Downloadaspx.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("shareWith.aspx");
    }

    protected void button2_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string filename = e.CommandArgument.ToString();
            var folderPath = Server.MapPath("~/Images/Upload");
            System.IO.DirectoryInfo folderInfo = new DirectoryInfo(folderPath);

            foreach (FileInfo file in folderInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in folderInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void Button3_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Button linkdownload = sender as Button;
            GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
            string downloadfile = imgList.DataKeys[gridrow.RowIndex].ToString();
            Response.ContentType = "Image/Upload/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile + "\"");
            Response.TransmitFile(Server.MapPath(downloadfile));
            Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }



       
    }
}