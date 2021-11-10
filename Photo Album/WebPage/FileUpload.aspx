<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="WebPage_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/sitecss.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 637px;
            height: 164px;
            position: absolute;
            top: -98px;
            left: -99px;
            z-index: 1;
            margin-bottom: 99px;
        }
    </style>
</head>
<body style="width: 583px; z-index: 1; height: 147px; position: relative; top: 99px; left: 785px">
    <form id="form1" runat="server">
        <div class="auto-style1" >
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="PhotoUpload"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Label ID="displayLabel" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;
            <asp:Button ID="uploadButton" runat="server" Text="Upload Image" OnClick="uploadButton_Click" />
            <asp:Button ID="Reset" runat="server" Text="Reset" />        
        </div>
    </form>
</body>
</html>

