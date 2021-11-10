<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addphoto.aspx.cs" Inherits="WebPage_addphoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../Content/add.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap"/>

    </head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <a href="Site.aspx">
                <img src="../Images/Background/icons8-home-50.png" />
            </a>
                <br />
                Go Home
                <br />
        </div>
        <div id="load"></div>
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#66CCFF" BorderStyle="Ridge" CssClass="offset-sm-0" Width="340px" />
                    <br />
                    <br />
                    <label for="captureDate">Capture Date</label>
                    <input type="date" name="Capture Date" id="captureDate"/>
                    <br />
                    <br />
                    Captured By:
                    <asp:TextBox ID="captureTextBox" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Geolocation:
                    <asp:TextBox ID="geolocation" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="addPhotoButton" runat="server" OnClick="Button1_Click" Text="Add Photo " Style="margin:0px"  BorderColor="#66CCFF" BorderStyle="Ridge"/>
                    &nbsp;<br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
        <div class="footer">
            <p>Pwidy Photo Album</p>
        </div>
    </form>
</body>
</html>

