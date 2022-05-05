<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminSamples.aspx.cs" Inherits="SamplesRepository.Admin.AdminSamples" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/Gender.ascx" TagPrefix="uc1" TagName="Gender" %>
<%@ Register Src="~/UserControls/DivList.ascx" TagPrefix="uc1" TagName="DivList" %>
<%@ Register Src="~/UserControls/Returnable.ascx" TagPrefix="uc1" TagName="Returnable" %>
<%@ Register Src="~/UserControls/Usage.ascx" TagPrefix="uc1" TagName="Usage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    Manage Samples <br />

    <asp:Label ID="statusLabel" runat="server" Text="" CssClass="AdminError"></asp:Label>
    <br />
    
    <asp:GridView ID="grid" runat="server" DataKeyNames="Id" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowDeleting="grid_RowDeleting" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Ref. " SortExpression="RefNumber">
                <EditItemTemplate>
                    <asp:TextBox ID="txtRefNumber" runat="server" Text='<%# Bind("RefNumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RefNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <EditItemTemplate>
                    <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Eval("ImageUrl") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl", "/SampleImgs/{0}") %>' Width="50" Height="50"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DateReceived" SortExpression="DateReceived">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDateReceived" runat="server" Text='<%# Bind("DateReceived") %>' TextMode="DateTimeLocal" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("DateReceived") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="SampleType">
                <EditItemTemplate>
                    <asp:TextBox ID="txtType" runat="server" Text='<%# Bind("SampleType") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("SampleType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Owner" SortExpression="OwnersName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtOwner" runat="server" Text='<%# Bind("OwnersName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("OwnersName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Origin" SortExpression="Origin">
                <EditItemTemplate>
                    <asp:TextBox ID="txtOrigin" runat="server" Text='<%# Bind("Origin") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Origin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BroughtBy" SortExpression="BroughtInBy">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBrought" runat="server" Text='<%# Bind("BroughtInBy") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("BroughtInBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Returnable" SortExpression="Returnable">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkReturnable" runat="server" Checked='<%# Bind("Returnable") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Returnable") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Division" SortExpression="DivisionName">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDivision" runat="server" Text='<%# Bind("DivisionName") %>'></asp:TextBox>
                    <asp:DropDownList ID="divisionList" runat="server" DataSourceID="dvList" DataTextField="DivisionName" DataValueField="Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="dvList" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [DivisionName] FROM [Division] ORDER BY [DivisionName]"></asp:SqlDataSource>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DivisionName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                <EditItemTemplate>
                    <asp:TextBox ID="txtGender" runat="server" Text='<%# Bind("Gender") %>'></asp:TextBox>
                    <asp:DropDownList ID="lstGender" runat="server" DataSourceID="dtsGender" DataTextField="Gen" DataValueField="Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="dtsGender" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Gen] FROM [Gender] ORDER BY [Id], [Gen]"></asp:SqlDataSource>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usage" SortExpression="Usage">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Usage") %>'></asp:TextBox>
                    <asp:DropDownList ID="lstUsage" runat="server" DataSourceID="dtsUsage" DataTextField="Usg" DataValueField="Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="dtsUsage" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Usg] FROM [Usage] ORDER BY [Usg]"></asp:SqlDataSource>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Usage") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Notes">
                <ItemTemplate>
                    <asp:HyperLink ID="LinkNotes" runat="server" NavigateUrl='<%#"AdminNotes.aspx?Id="+Eval("Id") %>' Text="Notes"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:ButtonField CommandName="Delete" Text="Delete" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />

    <p>Create a new sample:</p>
    <p>Reference Number:</p>
    <asp:TextBox ID="txtRefNumber" runat="server" Width="400px" />
    <p>Date Received:</p>
    <asp:TextBox ID="txtDate" runat="server" Width="400px" TextMode="DateTimeLocal" />
    <p>Sample Type:</p>
    <asp:TextBox ID="txtType" runat="server" Width="400px" />
    <p>Owner's Name:</p>
    <asp:TextBox ID="txtOwner" runat="server" Width="400px" />
    <p>Origin:</p>
    <asp:TextBox ID="txtOrigin" runat="server" Width="400px" />
    <p>Brought In By:</p>
    <asp:TextBox ID="txtBrought" runat="server" Width="400px" />
    <p>Image:</p>
    <asp:TextBox ID="txtImage" runat="server" Width="400px" Visible="False" />
    <p>Image File:
    <asp:Label ID="Image1Label" runat="server" />
    <asp:FileUpload ID="image1FileUpload" runat="server" />
    <asp:Button ID="upload1Button" runat="server" Text="Upload" OnClick="upload1Button_Click" /><br />
    <asp:Image ID="image1" runat="server" />
    </p>
    <p>Division:</p>
    <asp:DropDownList ID="cboDivision" runat="server" DataSourceID="SqlDataSource1" DataTextField="DivisionName" DataValueField="Id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [DivisionName] FROM [Division]"></asp:SqlDataSource>
    <p>Gender:</p>
    <asp:DropDownList ID="cboGender" runat="server" DataSourceID="SqlDataSource2" DataTextField="Gen" DataValueField="Id"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Gen] FROM [Gender]"></asp:SqlDataSource>
    <p>Returnable:</p>
    <asp:CheckBox ID="chkReturnable" runat="server" />
    <p>Usage</p>
    <asp:DropDownList ID="cboUsage" runat="server" DataSourceID="SqlDataSource3" DataTextField="Usg" DataValueField="Id"></asp:DropDownList>
    
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SampleRepo %>" SelectCommand="SELECT [Id], [Usg] FROM [Usage]"></asp:SqlDataSource>
    
    <p><asp:Button ID="createSample" Text="Create Sample" runat="server" OnClick="createSample_Click" /></p>
</asp:Content>

