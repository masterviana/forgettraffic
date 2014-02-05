<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="ForgetTraffic.Site.Business" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View Traffic
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="<%: Url.Content("~/Content/GoogleObjects.css")%>" rel="stylesheet" type="text/css" />

     
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&language=pt"> </script>
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/Incident.js")%>"> </script> 
    <script type="text/javascript" src="<%=Url.Content("~/Scripts/MapGoogle.js")%>"> </script> 

     <script  type="text/javascript">
        
         //URL's PARA PRODUÇÂO
//        var policeIcon = <%:Url.Content("/docs/traffic/police.png") %>;
//          var slowIcon = <%:Url.Content("/docs/traffic/slow.png") %>;
//            var maintenceIcon = <%:Url.Content("/docs/traffic/maintenance_loc.png") %>;
         //              var accidentIcon= <%:Url.Content("/docs/traffic/accident.png") %>;

        var policeIcon = 'http://dl.dropbox.com/u/3343576/ft_Icones/police.png';
        var slowIcon = 'http://dl.dropbox.com/u/3343576/ft_Icones/slow.png';
        var maintenceIcon = 'http://dl.dropbox.com/u/3343576/ft_Icones/maintenance_loc.png';
        var accidentIcon = 'http://dl.dropbox.com/u/3343576/ft_Icones/accident.png';

       

     </script>
      
     <h3 class="componentheading">	Real Time traffic Incidents </h3>

     <br />
    <table width="100%">
        <tr>
            <td style="width: 100%;">
                <div id="map_canvas" class="map_canvas">
                </div>
            </td>

        </tr>
    </table>
     <br /> 
   <div>
         <input type="button"  class="btAddIncident" id="incidentAdd" onclick="addIncident();" value="Add Incident" />
          <p > * <a href="javascript:displayError();">To</a> add an incident in the system click on button 'Add Incident', and click on map location where wish post the incident  </p>
    </div>
    <br />   

    <div id="addIncidentPanel" style="display:none" >
    <fieldset  class="boxBody"  >
        <legend> Incident Information </legend>
        <table width="100%">
            <tr>
                <td  >
                     <p id="form-login-username">
		                <label for="modlgn_username">Title</label>
		                <input type="text" id="title" class="txtField" size="10"/>
	                </p>
                </td>
                 <td  >
                     <p id="P1">
		                <label for="modlgn_username">Desciption</label>
		                <input  type="text" id="desc" class="txtField" size="40"/>
	                </p>
                </td>
                 <td>
                     <p id="P2">
		                <label for="modlgn_username">Kind Of</label>
		                <select class="cjComboBox small" id="type" >
                            <option value="0">Slow Traffic</option>
                            <option value="1">Maintence Street</option>
                            <option value="2">Police Trap</option>
                            <option value="3">Accident</option>
                        </select>
	                </p>
                </td>
                 <td>
                     <p id="P3">
		                <label for="modlgn_username">Severity</label>
		                <select class="cjComboBox small"  id="severity" >
                            <option value="0">Low</option>
                            <option value="1">High</option>
                            <option value="2">Very High</option>
                        </select>
	                </p>
                </td>
            </tr>
            <tr>
                <td>
                    <p id="P4">
		                <label for="modlgn_username">Country</label>
		                <input id="country" type="text" name="username" class="txtField" size="20"/>
	                </p>
                </td>
                <td>
                    <p id="P5">
		                <label for="modlgn_username">Disctrict</label>
		                <input id="distrito" type="text" name="username" class="txtField" size="20"/>
	                </p>
                </td>
                 <td>
                    <p id="P6">
		                <label for="modlgn_username">County</label>
		                <input id="concelho" type="text" name="username" class="txtField" size="20"/>
	                </p>
                </td>
                <td>
                    <p id="P7">
		                <label for="modlgn_username">Locality</label>
		                <input id="localidade" type="text" class="txtField" size="20"/>
	                </p>
                </td>
              
            </tr>
            <tr>
                <td>
                    <p >
		              <span>Latitude :  <label for="modlgn_username"  id="lat"  ></label> </span> 
	                </p>
                </td>
                <td>
                    <p>
                          <span>Longitude:  <label id="long"></label> </span>
	                </p>
                </td>
                <td></td>
            </tr>
        </table>
        </fieldset>
        <br />
         <input type="button" id="tbCancel" value="Cancel" class="btAddIncident"  />
        <input type="button" id="tbSubmitIncident" value="Submit" class="btAddIncident"  />
       
    </div>

    <div id="vote_error" title="Error -  StatusCode : 470"  style="display:none" >
    <br />
    <p>When try submit the vote</p><br />
        <p> The user already vote on this incident! </p>
    </div>

    <div id="spam_error" title="Error -  StatusCode : 472" style="display:none">
    <br />
            <p>  Limited reach </p><br />
            <p> You've reach the number of incident limited per hour </p>
    </div>

    <div id="own_vote" title="Error -  StatusCode : 473" style="display:none">
    <br />
            <p>  Can´t Vote</p><br />
            <p> Can't vote on  your Incident </p>
    </div>
   
   <div id="idCustomError" title="Error" style="display:none">
     <br />
          <p id="vhCustomerErrorTitle"> </p>
          <p id="vhCustomerErrorDescr"> </p>
   </div>

    <input id="urlIncident" type="hidden" value="<%= Consts.BaseAdress + Consts.OpIncident%>"  />

</asp:Content>

<asp:Content ID="LogOnContent" ContentPlaceHolderID="LogOnInfo" runat="server">
   <%
       Html.RenderPartial("~/Views/ForgetTrafficAccount/LogState.ascx");%>
</asp:Content>

<asp:Content ID="LateralMenuContent" ContentPlaceHolderID="LateralMenu" runat="server">
    <%
        Html.RenderPartial("SideBar");%>
</asp:Content>

<%-- <td style="width: 20%" valign="top">
                <div id="InfoPanel">
                    <input type="button"  class="btnLogin" onclick="addIncident();" value="Add Incident" /><br /><br />
                    
                    <p> Para adicionar uma incidência, carregue no botão, e selecione o ponto no mapa que deseja reportar. </p>
                </div>
            </td>--%>