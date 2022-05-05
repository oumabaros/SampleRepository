<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="SamplesRepository.UserControls.UserInfo" %>
<section id="login">
    <asp:LoginView runat="server" ViewStateMode="Disabled" ID="loginView1">
        <AnonymousTemplate>
            <ul>
                <li><a id="registerLink" runat="server" href="~/Account/Register">Register</a></li>
                <li><a id="loginLink" runat="server" href="~/Account/Login">Log in</a></li>
            </ul>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <p>
                Hello, <a runat="server" class="username" href="~/Account/Manage" title="Manage your account">
                    <asp:LoginName runat="server" CssClass="username" /></a>!
                <a runat="server" class="username" href="~/Admin/AdminSamples" title="Manage Samples">Admin</a>,
                <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
            </p>
        </LoggedInTemplate>
    </asp:LoginView>
</section>