<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	FAQ
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>FAQ</h2>

    <p> Será criado uma secção de perguntas e respostas.</p>
</asp:Content>

<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>