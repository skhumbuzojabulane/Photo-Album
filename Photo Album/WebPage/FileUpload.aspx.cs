using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPage_Add : System.Web.UI.Page
{
    public SqlConnection conn;
    public DataSet ds;
    public SqlDataAdapter adapter;
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf; Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        displayLabel.Visible = false;
    }

    protected void uploadButton_Click(object sender, EventArgs e)
    {
        try
        {
            string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (FileUpload1.HasFile)
            {
                if(extension == "bmp" || extension == "ico" || extension == "jpeg" || extension == "jpg" || extension == "gif" || extension == "tiff" || extension == "png")
                {
                    displayLabel.Visible = true;
                    displayLabel.Text = "This format is not accepte, Please try bmp, ico, jpeg, jpg, gif, till and png";
                }
                else
                {
                    string strname = FileUpload1.FileName.ToString();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/upload/") + strname);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into upload1 values('" + TextBox1.Text + "','" + strname + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label1.Visible = true;
                    Label1.Text = "Image Uploaded successfully";
                    TextBox1.Text = "";
                }

            }
            else
            {
                displayLabel.Visible = true;
                displayLabel.Text = "Plz upload the image!!!!";
            }
           
        }catch(Exception ex)
        {
            throw ex;
        }

    }
}