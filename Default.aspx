<%@ Page Title="Design Team" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SamplesRepository._Default" %>

<%@ Register Src="~/UserControls/SampleList.ascx" TagPrefix="uc1" TagName="SampleList" %>
<%@ Register Src="~/UserControls/DefaultPageSamples.ascx" TagPrefix="uc1" TagName="DefaultPageSamples" %>



<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
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
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3></h3>
    <uc1:DefaultPageSamples runat="server" id="DefaultPageSamples" />
</asp:Content>
