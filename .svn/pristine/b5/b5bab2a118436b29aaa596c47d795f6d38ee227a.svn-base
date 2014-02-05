<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.DataTypes.Authentication.ResendPassword>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ConctaUs
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ConctaUs</h2>

    <fieldset class="boxBody">
        <legend>Fields</legend>
        
         <table width="100%">
            <tr>
                <td style="width:100%;">
                         <p id="form-login-username">
		                <label for="modlgn_username">* Kind Of Contact</label>
                        <p>
		                    <select>
                                <option>Select on operations </option>
                                <option>Bug/Sugestion</option>
                                <option>Problem with User</option>
                            </select>
                        </p>
	                </p>
	                <p id="form-login-password">
		                <label for="modlgn_passwd"> * Subject </label>
		                <input id="loginTokenValidate" type="text" class="txtField" size="30"/>
	                </p>
		             <p >
		                <label for="modlgn_passwd">User Name </label>
		                <input id="numbIncidentHour" type="text" name="password" class="txtField" size="10"/>
	                </p>
                     <p >
		                <label for="modlgn_passwd">Content</label>
		                <textArea style=" resize: none;"  class="txtField" rows="10" cols="50" ></textArea>
	                </p>

                     <%-- <p >
		                <label for="modlgn_passwd">Low Ration - User Disable Alert Percentage  </label>
		                <input id="lowRatioDisable" type="text" class="txtField" size="10"/>
	                </p>--%>
                     
                </td>
              </tr>
           </table>
        
    </fieldset>

      <p><label for="modlgn_passwd">  Note - All the fields mark with (*) are requeired    </label></p>

            <p>
                    <input type="submit" value="Send Mail" id="btUpdateConfig" class="btnLogin"  tabindex="4"/>
            </p>

   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LateralMenu" runat="server">
   <%
        Html.RenderPartial("SideBar");%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LogOnInfo" runat="server">
 <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

