<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultPageSamples.ascx.cs" Inherits="SamplesRepository.UserControls.DefaultPageSamples" %>

<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>


<uc1:Pager ID="topPager" runat="server" Visible="False" />
<asp:DataList ID="list" runat="server">
    <ItemTemplate>
    <table class="table table-striped">
        <thead>
            <tr>

            </tr>
        </thead>
        <tbody>
            
            <tr>
                <td colspan="2">
                    <a href="<%# SamplesRepository.UserCode.Link.ToImageDetail(Eval("Id").ToString()) %>">
                    <img width="100" border="0" src="<%# SamplesRepository.UserCode.Link.ToProductImage(Eval("ImageUrl").ToString()) %>" 
                        alt ='<%# HttpUtility.HtmlEncode(Eval("RefNumber").ToString())%>' />
                    </a>
                    <br />
                    <a href="<%# SamplesRepository.UserCode.Link.ToSampleDetails(Eval("Id").ToString()) %>">
                    <%# HttpUtility.HtmlEncode(Eval("RefNumber").ToString()) %>
                    </a>
                </td>
            </tr>
            
        </tbody>

    </table>
  </ItemTemplate>
</asp:DataList>
<uc1:Pager ID="bottomPager" runat="server" Visible="False" />


