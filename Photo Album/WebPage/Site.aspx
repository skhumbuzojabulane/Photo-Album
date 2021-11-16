<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Site.aspx.cs" Inherits="WebPage_Site" Async="true"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <link href="../Content/siteExtraStyle.css" rel="stylesheet" />
    <script src="../Scripts/styling.js"></script>
    <link href="../Content/extraStyle.css" rel="stylesheet" />
    
    
    <div>
        <a href="addphoto.aspx">
            <img src="../Images/SiteMenu/photo.png" />
        </a>
            Click To Add Photo
                 <br />
            </div>
    <br />
        <asp:TextBox ID="searchTextBox" runat="server" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search Record" />

            <br />
            <br />
    <asp:DataList ID="imgList" runat="server" RepeatColumns="4" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both" >
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
        <ItemTemplate>
            <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("Name","~/images/upload/{0}") %>'  Width="285px" Height="250px"/>

            <asp:Button ID="button2" CommandName="delete" runat="server" OnClientClick="return confirm('Are you sure To Delete')" Text="  Delete  " OnCommand="button2_Command" ></asp:Button>
             <asp:Image runat="server" height="20" width="20" ImageUrl="~/Images/Background/icons8-delete-64.png"/>
            <!--<asp:LinkButton ID="LinkButton1" runat="server" Text="Download Photo"></asp:LinkButton>-->
            <asp:Button ID="Button3" runat="server" OnClientClick="return confirm('Happy Downloading!')" Text="  Download  " OnClick="Button3_Click" OnCommand="Button3_Command"></asp:Button>
            <asp:Image runat="server" height="20" width="20" ImageUrl="~/Images/Background/download.gif"/>  
            <asp:Button ID="Button4" runat="server" OnClientClick="return confirm('Enjoy Sharing With Friends And Famalies!')" Text="  Share  " OnClick="Button4_Click"></asp:Button>
            <asp:Image runat="server" height="20" width="20" ImageUrl="~/Images/Background/37730-200.png"/>   
            <br />
            <table class="nav-justified">
                <tr>
                    <td style="width: 104px">Geolocation:</td>
                 
                </tr>
                <tr>
                    <td style="width: 104px">Tags: </td>
                </tr>
                <tr>
                    <td style="width: 104px">Captured date: </td>
                    
                </tr>
                <tr>
                    <td style="width: 104px">Captured by:</td>
             
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <div>
  
</div>
</asp:Content>

