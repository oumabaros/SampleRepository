<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Usage.ascx.cs" Inherits="SamplesRepository.UserControls.Usage" %>
<asp:DropDownList ID="lstUsage" runat="server" DataSourceID="dtsUsage" DataTextField="Usg" DataValueField="Id"></asp:DropDownList>
<asp:SqlDataSource ID="dtsUsage" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Usg] FROM [Usage] ORDER BY [Usg]"></asp:SqlDataSource>
