<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.Site.Models.GenericError>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%:Model.PageTitle %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="componentheading"> <%: Model.PageTitle %> </h2>

    <div >
    <br />
    <h4> <%:Model.TypeError %> </h4>
        <p>
            <%:Model.PageDescriction %>
        </p>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LateralMenu" runat="server">
   <%
        Html.RenderPartial("SideBar");%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="LogOnInfo" runat="server">


         <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>

</asp:Content>
