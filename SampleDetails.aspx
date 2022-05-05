<%@ Page Title="Design Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SampleDetails.aspx.cs" Inherits="SamplesRepository.SampleDetails" %>
<%@ Register src="UserControls/SampleDetails.ascx" tagname="SampleDetails" tagprefix="uc1" %>
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
    <uc1:SampleDetails ID="SampleDetails1" runat="server" />
&nbsp;
</asp:Content>
