<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	News - Forget Traffic
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>News</h2>
        <p> Aqui vamos apresentar as novidades do nosso projecto. </p>
        <br />
        <ul>
            <li>17-07-2011 - Lançamento do Site, onde já permite o registo do user, visualização e registo de incidências</li>
            <br />
            <li>17-08-2011 - Possibilidade de votação dos utilizadores </li>
            <br />
            <li>18-09-2011 - Inclusão de algoritmos de inserção de incidencias no sistema, e algorimtos de resolção de incidencias , novo aspecto no do site. Passamos a barreira dos 30 utilizadores. </li>
        </ul>                
</asp:Content>

<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>
