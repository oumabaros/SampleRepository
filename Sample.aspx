<%@ Page Title="Design Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="SamplesRepository.Sample" %>
<%@ Register src="UserControls/SampleList.ascx" tagname="SampleList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>:</h1>
                <h2>Sample Repository</h2>
            </hgroup>
            
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:SampleList ID="SampleList1" runat="server" />&nbsp;

</asp:Content>
