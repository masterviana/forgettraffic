<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Community - Forget Traffic 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Community</h2>
    
    <p>Este espaço será reservado para as noticías sobre a nossa comunidade. </p>

</asp:Content>


<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>
