<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


       <div class="moduletable_menu">
					<ul class="menu">
                        <li id="current" class="active item1"> <a href="<%:Url.Action("Index", "Home")%>"><span>Home</span></a> </li>
                        
                        <li class="parent item27"><a href="<%:Url.Action("ViewTraffic", "Home")%>"><span>Verificar Tráfego</span></a></li>
                        <li class="item11"><a href="<%:Url.Action("News", "Home")%>"><span>Novidade</span></a></li>
                        <li class="item37"><a href="<%:Url.Action("Community", "Home")%>"><span>Comunidade</span></a></li>
                        <li class="item41"><a href="<%:Url.Action("Autores", "Information")%>"><span>Autores</span></a></li>
                        <li class="item50"><a href="<%:Url.Action("FAQ", "Information")%>"><span>FAQ</span></a></li>
                        <li class="item48"><a href="<%:Url.Action("API", "Information")%>"><span>API Forget Traffic</span></a></li>
                        <li class="item49"><a href="<%:Url.Action("InterestingLinks", "Information")%>"><span>Links Relacionados</span></a></li>
                        <li class="item49"><a href="<%:Url.Action("Contact", "Information")%>"><span>ContactUs</span></a></li>
                        </ul>		
       </div>

	