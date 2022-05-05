<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleList.ascx.cs" Inherits="SamplesRepository.UserControls.SampleList" %>
<%@ Register Src="~/UserControls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>

<uc1:Pager runat="server" ID="topPager" Visible="False" />

<asp:DataList ID="list" runat="server" RepeatColumns="2">
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

<uc1:Pager runat="server" ID="bottomPager" Visible="False" />
