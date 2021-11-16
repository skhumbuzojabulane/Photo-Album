using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class WebPage_addphoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        geolocation.Text = "";
        TextBox2.Text = "";
        Label1.Visible = false;
        TextBox1.Focus();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\savePhotos.mdf;Integrated Security=True");

        if (FileUpload1.HasFile)
        {
            string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (extension == ".bmp" || extension == ".ico" || extension == ".jpeg" || extension == ".jpg" || extension == ".gif" || extension == ".tiff" || extension == ".png")
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/Upload/" + "/" + str));
                string imgpath = "~/Images/Upload/" + "/" + str.ToString();
                SqlCommand cmd = new SqlCommand("insert into upload(captureDate,capturedBy,geolocation,imagePath) values(@captureDate, @capturedBy, @geolocation, @imagePath)", con);
                cmd.Parameters.AddWithValue("@captureDate", TextBox1.Text);
                cmd.Parameters.AddWithValue("@capturedBy", TextBox2.Text);
                cmd.Parameters.AddWithValue("@geolocation", geolocation.Text);
                cmd.Parameters.AddWithValue("@imagePath", imgpath);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Visible = true;
                TextBox2.Text = "";
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Image Uploaded successfully";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "This format is not accepted! Please try bmp, ico, jpeg, jpg, gif, till or png";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Oops! Something went wrong, please upload a photo!";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}