<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ForgetTraffic.Site.Models.AutoresSet>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Autores
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Autores</h2>

 <table class="blog" cellpadding="0" cellspacing="0">
     <tbody>
         <tr>
            <td valign="top">
                <table class="contentpaneopen" style="width:100%;">
                  <%
                      for (int i = 0; i < ViewData.Model.Authors.Count; i++)
                      {%>
                    <tr>
                   
                        <td style="width:20%;" class="buttonheading" >
                            <img src="<%:Model.Authors[i].Foto%>" alt="" />
                        </td>
                        <td style="width:80%;" class="buttonheading" valign="top" >
                               <table class="contentpaneopen" style="width:100%;">
                               <tr>
                                    <td style="width:30%;" valign="top">
                                     <p> Nome : </p> 
                                    </td>
                                    <td style="width:70%;" valign="top">
                                        <%:Model.Authors[i].Nome%>
                                    </td>
                               </tr>
                                <tr>
                                    <td style="width:30%;" valign="top">
                                     <p>Contacto : </p> 
                                    </td>
                                    <td valign="top">
                                        <a href="mailto:<%:Model.Authors[i].MailContact%>"><%:Model.Authors[i].MailContact%></a>
                                    </td>
                               </tr>
                                
                               </table>
                        </td>
                    </tr>
                     <%
                      }%>
                </table>
            </td>

         </tr>
     </tbody>
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