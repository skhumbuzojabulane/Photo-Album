﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Site.aspx.cs" Inherits="WebPage_Site" Async="true"%>


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
    <asp:DataList ID="imgList" runat="server" RepeatColumns="4" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both" OnSelectedIndexChanged="imgList_SelectedIndexChanged">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <ItemStyle ForeColor="#000066" />
        <ItemTemplate>
            <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("Name","~/images/upload/{0}") %>'  Width="285px" Height="250px"/>
            <asp:Button ID="cmdDelete" runat="server" OnClientClick="return confirm('Are you sure To Delete')" Text="Delete" CommandName="Delete" />
             <asp:Image runat="server" height="20" width="20" ImageUrl="~/Images/Background/icons8-delete-64.png"/>
            <!--<asp:LinkButton ID="LinkButton1" runat="server" Text="Download Photo"></asp:LinkButton>-->
            <asp:Button ID="Button2" runat="server" OnClientClick="return confirm('Thank You For Downloading!')" Text="Download Photo" OnClick="Button2_Click"></asp:Button>
            <asp:Image runat="server" height="20" width="20" ImageUrl="~/Images/Background/download.gif"/>  
            <br />
            <table class="nav-justified">
                <tr>
                    <td>Geolocation:</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Tags: </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Captured date: </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Captured by:</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
    <div>
  
</div>
</asp:Content>

