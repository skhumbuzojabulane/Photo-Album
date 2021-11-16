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


public partial class WebPage_Downloadaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.AutoGenerateColumns = false;
        Label1.Visible = false;
    }

    void page_preRender()
    {
        string Folder = Server.MapPath("~/Images/Upload/");
        DirectoryInfo dir = new DirectoryInfo(Folder);
        GridView1.DataSource = dir.GetFiles();
        GridView1.DataBind();
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

    protected void downloadButton_Click(object sender, EventArgs e)
    {
        Button linkdownload = sender as Button;
        GridViewRow gridrow = linkdownload.NamingContainer as GridViewRow;
        string downloadfile = GridView1.DataKeys[gridrow.RowIndex].Value.ToString();
        Response.ContentType = "Image/Upload/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + downloadfile +"\"");
        Response.TransmitFile(Server.MapPath(downloadfile));
        Response.End();
    }

   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Label1.Text = "Displaying Page " + (GridView1.PageIndex + 1).ToString() + " of " + GridView1.PageCount.ToString();
            Label1.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}