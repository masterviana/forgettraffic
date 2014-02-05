<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="ForgetTraffic.Site.Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	API Service - Forget Traffic
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Forget Traffic Opertion API</h1>
    <br />

   <table width="100%" style="height:100%;width:100%;" >
       <tr>
            <td>
                <iframe src="<%= Consts.BaseAdress + Consts.HelpApi %>" width="100%" height="100%"> </iframe>
            </td>
        </tr>
    </table>
    

</asp:Content>

<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>