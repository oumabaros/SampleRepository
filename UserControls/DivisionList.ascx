<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivisionList.ascx.cs" Inherits="SamplesRepository.UserControls.DivisionList" %>
<asp:DataList ID="list" runat="server" Width="200px">
    <HeaderStyle CssClass="#" />
    <HeaderTemplate>
        <h5>Divisions</h5>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl='<%# SamplesRepository.UserCode.Link.ToDivision(Eval("Id").ToString())%>' 
            Text='<%# HttpUtility.HtmlEncode(Eval("DivisionName").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("DivisionName").ToString()) %>'
            CssClass='<%# Eval("Id").ToString() == Request.QueryString["Id"] ? "DivisionSelected" :"DivisionUnselected" %>'>
            

        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>

