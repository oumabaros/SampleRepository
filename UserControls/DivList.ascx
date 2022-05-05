<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DivList.ascx.cs" Inherits="SamplesRepository.UserControls.DivList" %>
<asp:DropDownList ID="divisionList" runat="server" DataSourceID="dvList" DataTextField="DivisionName" DataValueField="Id"></asp:DropDownList>
<asp:SqlDataSource ID="dvList" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [DivisionName] FROM [Division] ORDER BY [DivisionName]"></asp:SqlDataSource>
