<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="AdminNotes.aspx.cs" Inherits="SamplesRepository.Admin.AdminNotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminContentPlaceHolder" runat="server">
    <asp:Label ID="statusLable" runat="server" Text=""></asp:Label><br />
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" Width="100%" OnRowDeleting="grid_RowDeleting">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RefNumber" HeaderText="RefNumber" ReadOnly="True" SortExpression="RefNumber" />
            <asp:TemplateField HeaderText="BaseColor">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBaseColor" runat="server" Text='<%# Bind("BaseColor") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("BaseColor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DesignDetails">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDesignDetails" runat="server" Text='<%# Bind("DesignDetails") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DesignDetails") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size">
                <EditItemTemplate>
                    <asp:TextBox ID="txtSize" runat="server" Text='<%# Bind("Size") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight">
                <EditItemTemplate>
                    <asp:TextBox ID="txtWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStatus" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ProductionSchedule">
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductionSchedule" runat="server" Text='<%# Bind("ProductionSchedule") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ProductionSchedule") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ETAMarket">
                <EditItemTemplate>
                    <asp:TextBox ID="txtETAMarket" runat="server" Text='<%# Bind("ETAMarket") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ETAMarket") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Color">
                <EditItemTemplate>
                    <asp:TextBox ID="txtColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="KnitWeaveType">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTypeOfKnitWeave" runat="server" Text='<%# Bind("TypeOfKnitWeave") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("TypeOfKnitWeave") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AdditionalNotes">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAdditionalNotes" runat="server" Text='<%# Bind("AdditionalNotes") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("AdditionalNotes") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FullSleeve" SortExpression="FullSleeve">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkFullSleeve" runat="server" Checked='<%# Bind("FullSleeve") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("FullSleeve") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sleeveless" SortExpression="Sleeveless">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkSleeveless" runat="server" Checked='<%# Bind("Sleeveless") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("Sleeveless") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="HeavyWeight" SortExpression="HeavyWeight">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkHeavyWeight" runat="server" Checked='<%# Bind("HeavyWeight") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("HeavyWeight") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MediumWeight" SortExpression="MediumWeight">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkMediumWeight" runat="server" Checked='<%# Bind("MediumWeight") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("MediumWeight") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LightWeight" SortExpression="LightWeight">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkLightWeight" runat="server" Checked='<%# Bind("LightWeight") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("LightWeight") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EmbroideredEmblem" SortExpression="EmbroideredEmblem">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkEmbroideredEmblem" runat="server" Checked='<%# Bind("EmbroideredEmblem") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox6" runat="server" Checked='<%# Bind("EmbroideredEmblem") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VNeckFront" SortExpression="VNeckFront">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkVNeckfront" runat="server" Checked='<%# Bind("VNeckFront") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox7" runat="server" Checked='<%# Bind("VNeckFront") %>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FinishingDetails">
                <EditItemTemplate>
                    <asp:TextBox ID="txtFinishingDetails" runat="server" Text='<%# Bind("FinishingDetails") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label18" runat="server" Text='<%# Bind("FinishingDetails") %>'></asp:Label>
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
    Add Notes:
    <table class="table table-striped table-sm">
        <thead class="thead-inverse">
            <tr><th colspan="2">Additional Notes</th></tr>
        </thead>
        <tbody>
            <tr><td>Base Color:</td><td><asp:TextBox ID="BaseColor" runat="server"></asp:TextBox></td></tr>
            <tr><td>Design Details:</td><td><asp:TextBox ID="DesignDetails" runat="server"></asp:TextBox></td></tr>
            <tr><td>Size:</td><td><asp:TextBox ID="Size" runat="server"></asp:TextBox></td></tr>
            <tr><td>Weight:</td><td><asp:TextBox ID="Weight" runat="server"></asp:TextBox></td></tr>
            <tr><td>Status:</td><td><asp:TextBox ID="Status" runat="server"></asp:TextBox></td></tr>
            <tr><td>Production Schedule:</td><td><asp:TextBox ID="ProductionSchedule" runat="server"></asp:TextBox></td></tr>
            <tr><td>ETA to Market:</td><td><asp:TextBox ID="ETAMarket" runat="server"></asp:TextBox></td></tr>
            <tr><td>Color:</td><td><asp:TextBox ID="Color" runat="server"></asp:TextBox></td></tr>
            <tr><td>Type of KnitWeave:</td><td><asp:TextBox ID="TypeOfKnitWeave" runat="server"></asp:TextBox></td></tr>
            <tr><td>Full Sleeve:</td><td><asp:CheckBox ID="FullSleeve" runat="server"  /></td></tr>
            <tr><td>Sleeveless:</td><td><asp:CheckBox ID="Sleeveless" runat="server"  /></td></tr>
            <tr><td>Heavy Weight:</td><td><asp:CheckBox ID="HeavyWeight" runat="server"  /></td></tr>
            <tr><td>Medium Weight:</td><td><asp:CheckBox ID="MediumWeight" runat="server"  /></td></tr>
            <tr><td>Light Weight:</td><td><asp:CheckBox ID="LightWeight" runat="server"  /></td></tr>
            <tr><td>Additional Notes:</td><td><asp:TextBox ID="AdditionalNotes" runat="server"></asp:TextBox></td></tr>
            <tr><td>Embroidered Emblem:</td><td><asp:CheckBox ID="EmbroideredEmblem" runat="server"  /></td></tr>
            <tr><td>VNeckFront:</td><td><asp:CheckBox ID="VNeckFront" runat="server"  /></td></tr>
            <tr><td>Finishing Details:</td><td><asp:TextBox ID="FinishingDetails" runat="server"></asp:TextBox></td></tr>
            <tr><td colspan="2"><asp:Button ID="createNotes" Text="Add Notes" runat="server" OnClick="createNotes_Click"  /></td></tr>
            
        </tbody>

    </table>
</asp:Content>
