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
 

    <%
        using (Html.BeginForm())
        {%>
        <%:Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.")%>
        <div>

        <table  style="border-collapse: collapse;" > 

        <tr>
     
            <td style="width:60%;padding-right:70px;" >
                       <fieldset class="boxBody" >
                        <legend>Account Information</legend>
                            <div class="editor-label">
                                <%:Html.LabelFor(m => m.UserName)%> 
                            </div>
                            <div >
                                <%:Html.TextBoxFor(m => m.UserName, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>

                            <div class="editor-label">
                                <%:Html.LabelFor(m => m.FirstName)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.FirstName, new Dictionary<string, object>() { { "class", "txtField" } })%>
                            </div>                

                            <div class="editor-label">
                                <%:Html.LabelFor(m => m.LastName)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.LastName, new Dictionary<string, object>() { { "class", "txtField" } })%>
                            </div>      

                            <div class="editor-label">
                                <%:Html.LabelFor(m => m.Email)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.Email,new Dictionary<string, object>() { { "readonly", "true"} ,  { "class", "txtField" } })%>
                                <%:Html.ValidationMessageFor(m => m.Email)%>
                            </div>
                
                            <div class="editor-label">
                                <%:Html.LabelFor(m => m.BirthDate)%>
                            </div>
                            <div class="editor-field">
                                <%:Html.TextBoxFor(m => m.BirthDate, new Dictionary<string, object>() { { "class", "txtField" } })%>
                            </div>  

                              <div  class="editor-label">
                                <%:Html.LabelFor(m => m.HidenUserName)%>
                            </div>
                            <div  >
                                <%: Html.CheckBox("HidenUserName", Model.HidenUserName)%>
                            </div>  
                          </fieldset>

                    </td>
                                                                    
                    <td style="width:40%;" valign="top">
                    <fieldset  class="boxBody">
                                            <legend>User Iterations</legend>
                      <div class="editor-label">
                                <%:Html.LabelFor(m => m.PostIncidents)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.PostIncidents, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>  
                             <div class="editor-label">
                                <%:Html.LabelFor(m => m.ValidadeIncidents)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.ValidadeIncidents, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>  
                             <div class="editor-label">
                                <%:Html.LabelFor(m => m.InvalideIncident)%>
                            </div>
                            <div  >
                                <%:Html.TextBoxFor(m => m.InvalideIncident, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>  
                               <div class="editor-label">
                                <%:Html.LabelFor(m => m.PostVotes)%>
                            </div>
                            <div >
                                <%:Html.TextBoxFor(m => m.PostVotes, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>  

                                  <div class="editor-label">
                                <%:Html.LabelFor(m => m.Ratio)%>
                            </div>
                            <div >
                                <%:Html.TextBoxFor(m => m.Ratio, new Dictionary<string, object>() { { "readonly", "true" }, { "class", "txtField" } })%>
                            </div>  
                        
                    </fieldset>
                    </td>

            </tr>
            </table>
                            <p>To change password or Secret Question click <%:
                                                                               Html.ActionLink("here", "ChangePassword", "Account")%></p>         
                
                            <p>
                                <input type="submit" class="btnLogin"  value="<%: "Update" %>" />
                            </p>

        </div>
    <%
        }%>
</asp:Content>
