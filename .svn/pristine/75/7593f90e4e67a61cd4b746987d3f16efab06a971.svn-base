<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.DataTypes.RestTypes.Admin.ListItensSet>" %>
<%@ Import Namespace="ForgetTraffic.Site.Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script  type="text/javascript" >


        $(function () 
        {
            $("#tabs").tabs();
        });
	</script>

    <input type="hidden" value="<%=Consts.BaseAdress + Consts.OpAdministrator  %>" id="urlAdmin" />

    <h2 class="componentheading">Administrator Management</h2>
    <br /><br />
    <div id="tabs">
	<ul>
        <li><a href="#tabs-1">Application Configuration</a></li>
		<li><a href="#tabs-2">Users</a></li>
		<li><a href="#tabs-3">Traffic Incidents</a></li>
	</ul>
    <div id="tabs-1">
		  <%  Html.RenderPartial("AdminGeneralConfiguration");%> 
	</div>
	<div id="tabs-2">
		  <%  Html.RenderPartial("AdminUsers");%> 
	</div>
	<div id="tabs-3">
		  <%  Html.RenderPartial("AdminIncidents");%> 
	</div>
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LateralMenu" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LogOnInfo" runat="server">
</asp:Content>
