<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Downloadaspx.aspx.cs" Inherits="WebPage_Downloadaspx" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <link href="../Content/siteExtraStyle.css" rel="stylesheet" />
    <script src="../Scripts/styling.js"></script>
    <link href="../Content/extraStyle.css" rel="stylesheet" />

    <div class="header">
            <a href="Site.aspx">
                <img src="../Images/Background/icons8-home-50.png" />
            </a>
                <br />
                Go Home
                <br />
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" RepeatColumns="4"  HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="2" PageSize="2" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("Name","~/images/upload/{0}") %>'  Width="400px" Height="350px"/>
                        <asp:Button ID="downloadButton" runat="server" OnClick="downloadButton_Click" Text="Download" />
                        &nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
    </div>

</asp:Content>
