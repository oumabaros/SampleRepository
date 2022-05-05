<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Returnable.ascx.cs" Inherits="SamplesRepository.UserControls.Returnable" %>
<asp:DropDownList ID="lstReturnable" runat="server" DataSourceID="dstReturnable" DataTextField="Status" DataValueField="Id"></asp:DropDownList>
<asp:SqlDataSource ID="dstReturnable" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Status] FROM [Returnable] ORDER BY [Status]"></asp:SqlDataSource>
