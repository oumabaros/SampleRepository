<%@ Page Title="Design Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SampleImage.aspx.cs" Inherits="SamplesRepository.SampleImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>:</h1>
                <h2>Sample Repository</h2>
            </hgroup>
            <p>
                
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DataList ID="list" runat="server">
        <ItemTemplate>
            <img width="400" height="400" border="0" src="<%# SamplesRepository.UserCode.Link.ToProductImage(Eval("ImageUrl").ToString()) %>" 
                        alt ='Image' />
        </ItemTemplate>

    </asp:DataList>
    
</asp:Content>
