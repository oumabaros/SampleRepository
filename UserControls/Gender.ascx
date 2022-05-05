<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Gender.ascx.cs" Inherits="SamplesRepository.UserControls.Gender" %>


<asp:DropDownList ID="lstGender" runat="server" DataSourceID="dtsGender" DataTextField="Gen" DataValueField="Id"></asp:DropDownList>
<asp:SqlDataSource ID="dtsGender" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Gen] FROM [Gender] ORDER BY [Id], [Gen]"></asp:SqlDataSource>
