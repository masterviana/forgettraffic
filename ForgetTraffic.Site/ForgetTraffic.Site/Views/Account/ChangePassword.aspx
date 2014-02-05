<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.Site.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
   Change Password
</asp:Content>




<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Password</h2>
    <br />
    <p>
        Use the form below to change your password. 
    </p>
    <%--<p>
        New passwords are required to be a minimum of <%:ViewData["PasswordLength"]%> characters in length.
    </p>--%>
    <br />

    <%
        using (Html.BeginForm())
        {%>
        <%:Html.ValidationSummary(true,
                                                     "Password change was unsuccessful. Please correct the errors and try again.")%>
        <div>
            <fieldset  class="boxBody">
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.OldPassword)%>
                </div>
                <div  >
                    <%:Html.PasswordFor(m => m.OldPassword, new { @class = "txtField" })%>
                    <%:Html.ValidationMessageFor(m => m.OldPassword)%>
                </div>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.NewPassword)%>
                </div>
                <div  >
                    <%:Html.PasswordFor(m => m.NewPassword, new Dictionary<string, object>() { { "class", "txtField" } })%>
                    <%:Html.ValidationMessageFor(m => m.NewPassword)%>
                </div>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.ConfirmPassword)%>
                </div>
                <div >
                    <%:Html.PasswordFor(m => m.ConfirmPassword, new Dictionary<string, object>() { { "class", "txtField" } })%>
                    <%:Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                </div>

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.SecretQuestion)%>
                </div>
                <div  >
                    <%:Html.TextBoxFor(m => m.SecretQuestion, new Dictionary<string, object>() { { "class", "txtField" } })%>
                </div>      

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.SecretAnswer)%>
                </div>
                <div>
                    <%:Html.TextBoxFor(m => m.SecretAnswer, new Dictionary<string, object>() { { "class", "txtField" } })%>
                </div>   
                
                <p>
                    <input type="submit" value="Change Password"  class="btnLogin" />
                </p>
            </fieldset>
        </div>
    <%
        }%>
</asp:Content>
<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>