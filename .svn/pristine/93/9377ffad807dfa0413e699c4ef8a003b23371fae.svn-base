<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.Site.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register - Forget Traffic 
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">

<script >
    $(function () {
        $("#BirthDate").datepicker();
    });
	</script>

    <h2><%: ViewData["Title"] %></h2>
    <p>
        <%: ViewData["subTitle"]%>
    </p>
   <%-- <p>
        Passwords are required to be a minimum of <%:ViewData["PasswordLength"]%> characters in length.
    </p>
--%>
    <%
        using (Html.BeginForm())
        {%>
        <%:Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.")%>
        <div>
        <br />
            <fieldset>
                <legend>Account Information</legend>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.UserName)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.UserName, new { @class = "txtField" } )%>
                    <%:Html.ValidationMessageFor(m => m.UserName)%>
                </div>

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.FirstName)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.FirstName, new { @class = "txtField" })%>
                </div>                

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.LastName)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.LastName, new { @class = "txtField" })%>
                </div>      

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.Email)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.Email, new { @class = "txtField" })%>
                    <%:Html.ValidationMessageFor(m => m.Email)%>
                </div>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.Password)%>
                </div>
                <div>
                    <%:Html.PasswordFor(m => m.Password, new { @class = "txtField" })%>
                    <%:Html.ValidationMessageFor(m => m.Password)%>
                </div>
                
                <div class="editor-label">
                    <%:Html.LabelFor(m => m.ConfirmPassword)%>
                </div>
                <div >
                    <%:Html.PasswordFor(m => m.ConfirmPassword, new { @class = "txtField" })%>
                    <%:Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                </div>

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.BirthDate)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.BirthDate, new { @class = "txtField" })%>
                </div>  

                <%--<div class="editor-label">
                    <%:Html.LabelFor(m => m.SecretQuestion)%>
                </div>
                <div >
                    <%:Html.TextBoxFor(m => m.SecretQuestion, new { @class = "txtField" })%>
                </div>      

                <div class="editor-label">
                    <%:Html.LabelFor(m => m.SecretAnswer)%>
                </div>
                <div>
                    <%:Html.TextBoxFor(m => m.SecretAnswer, new { @class = "txtField" })%>
                </div>   --%>       
                
                <p>
                    <input type="submit" value="<%: "Register" %>"  class="btnLogin" />
                </p>
            </fieldset>
        </div>
    <%
        }%>
</asp:Content>
