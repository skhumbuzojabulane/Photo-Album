<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shareWith.aspx.cs" Inherits="WebPage_shareWith" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../Content/add.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap"/>
    <style>
        .footer 
        {
            position: fixed;
            left: 0;
            bottom: 0;
            width: 100%;
            background-color: #ffcccb;
            color: blue;
            text-align: center;
        }
    </style>

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
        <div class="wrapper fadeInDown">
             <div id="formContent">
                 <div>
                     <br />
                     Who would you like to share with?
                     <asp:DropDownList ID="DropDownList1" runat="server" Height="32px" Width="148px"></asp:DropDownList>
                     <br />
                     <br />
                     <asp:Button ID="shareButton" runat="server" Text="Share" />
                 </div>
             </div>
        </div>
        <div class="footer">
            <p>Pwidy Photo Album</p>
        </div>
    </form>
</body>
</html>
