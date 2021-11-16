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
        /*SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security=True");
        string sqlquery = "select * from upload";
        SqlCommand cmd = new SqlCommand(sqlquery, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        imgList.DataSource = ds;
        imgList.DataBind();
        con.Close();*/
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

    protected void Button2_Click(object sender, EventArgs e)
    {

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

        /*
        try
        {
            string filePath = (sender as Button).CommandArgument;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachement; filename=" + Path.GetFileName(filePath));
            Response.TransmitFile(Server.MapPath("~/Images/Upload/" + filePath));
            Response.End();*/

        /*FileInfo fileInfo = new FileInfo("Images/");
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.Flush();
        Response.WriteFile(fileInfo.FullName);
        Response.End();

        string filePath = "Images/Upload";//+ imgList.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "gif/png/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();

        string filePath = (sender as Button).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachement; filename=" + Path.GetFileName("Images/Upload/"));
        Response.WriteFile(filePath);
        Response.End();


        Button btn = sender as Button;
        DataList gvrow = btn.NamingContainer as DataList;
        string downloadfile = imgList.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "Images/Upload/jpg";
        Response.AppendHeader("Content-Disposition", "attachement;filename=\"" + downloadfile + "\"");
        Response.TransmitFile(Server.MapPath(downloadfile));
        Response.End();

    }
    catch (Exception ex)
    {
        throw ex;
    }*/
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("shareWith.aspx");
    }


    protected void imgList_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            /*try
            {
                string filePath = Convert.ToString(e.CommandArgument);
                File.Delete(filePath);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
        }

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
        //string filename = e.CommandArgument.ToString();
        //File.Delete(Server.MapPath(filename));
        //FileInfo finfo;
        //finfo = new FileInfo(filename);
        //finfo.Delete();
        //imgList.DataBind();

        /*string filename = e.CommandArgument;
        filename = Server.MapPath(filename);
        File.Delete(filename);*/
    }



    protected void Button3_Command(object sender, CommandEventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }



        /*
          * 
          * String filename = @"~/Images/Upload/";
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }

        FileInfo fileInfo = new FileInfo("~Images/Upload");
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.Flush();
        Response.WriteFile(fileInfo.FullName);
        Response.End();*/
    }

    protected void imgList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
    }
}