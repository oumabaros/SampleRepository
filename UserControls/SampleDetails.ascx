<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleDetails.ascx.cs" Inherits="SamplesRepository.UserControls.SampleDetails" %>
<asp:DataList ID="list" runat="server">
    <ItemTemplate>
        <div class="container">
          <div class="row">
            <div class="col-md-8">
              <b>Sample Tag Details</b>
              <div class="row">
                <div class="col-md-6 col-1">Sample ref. Number:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("RefNumber").ToString()) %></div>
                <div class="col-md-6 col-1">Date Received:</div><div class="col-md-6 col-2"> <%# Eval("DReceived") %></div>
                <div class="col-md-6 col-1">Sample Type:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("SampleType").ToString()) %></div>
                <div class="col-md-6 col-1">Owner's Name:</div><div class="col-md-6 col-2"><%# Eval("OwnersName") %></div>
                <div class="col-md-6 col-1">Region of Origin:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("Origin").ToString()) %></div>
                <div class="col-md-6 col-1">Brought in by:</div><div class="col-md-6 col-2"> <%# Eval("BroughtInBy") %></div>
                <!--<div class="col-md-6 col-1 ">Returnable</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("Returnable").ToString()) %></div>-->
                <div class="col-md-6 col-3">Product Category by:</div><div class="col-md-6"></div>
                <div class="col-md-6 col-1">Division</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("DivisionName").ToString()) %></div>
                <div class="col-md-6 col-1">Gender</div><div class="col-md-6 col-2" > <%# HttpUtility.HtmlEncode(Eval("Gender").ToString()) %></div>
                <div class="col-md-6 col-1">Use:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("Usage").ToString()) %></div>
                <div class="col-md-6 col-3 ">Additional Notes:</div><div class="col-md-6"></div>
                <div class="col-md-6 col-1">Base Colour:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("BaseColor").ToString()) %></div>
                <div class="col-md-6 col-1">Design Details:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("DesignDetails").ToString()) %></div>
                <div class="col-md-6 col-1">Size:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("Size").ToString()) %></div>
                <div class="col-md-6 col-1">Weight:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("Weight").ToString()) %></div>
                <div class="col-md-6 col-1">Status:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("Status").ToString()) %></div>
              </div>
                <div class="row">
                    <div class="col-md-12">
                        <u><asp:HyperLink ID="LinkNotes" runat="server" NavigateUrl='<%#"~/Admin/AdminNotes.aspx?Id="+Eval("Id") %>' Text="Notes"></asp:HyperLink></u>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
    	         <img width="400" border="0" src="<%# SamplesRepository.UserCode.Link.ToProductImage(Eval("ImageUrl").ToString()) %>" 
                                alt ='<%# HttpUtility.HtmlEncode(Eval("RefNumber").ToString())%>' />
            </div>
          </div>
    </div>
    </ItemTemplate>
</asp:DataList>