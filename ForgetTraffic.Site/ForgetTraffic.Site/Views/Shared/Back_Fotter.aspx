<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Back_Fotter.aspx.cs" Inherits="ForgetTraffic.Site.Views.Shared.Back_Fotter" %>


    <div id="footercontainer">
        <div id="footer">
            <div id="footerleft">
                <div class="footerlinks">
                    <h2>
                        Forget Traffic</h2>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li><a href="#">The Project</a></li>
                        <li>
                            <%:Html.ActionLink("The Community", "Community", "Home")%></li>
                        <%--     //<li><a href="#">Our Blog</a></li>--%>
                        <li>
                            <%:Html.ActionLink("Contactos", "Autores", "Information")%></li>
                    </ul>
                </div>
                <div class="footerlinks">
                    <h2>
                        Forget Traffic API</h2>
                    <ul>
                        <li>
                            <%:Html.ActionLink("Support Center", "Autores", "Information")%></li>
                        <li>
                            <%:Html.ActionLink("Forget Traffic API", "API", "Information")%></li>
                        <!--<li><a href="#">Press</a></li>-->
                    </ul>
                </div>
                <div class="footerlinks">
     <%--              <h2>
                        Follow Us</h2>
                    <ul>
                        <li><a href="http://www.facebook.com/">Facebook</a></li>
                        <li><a href="http://www.twitter.com/">Twitter</a></li>
                    </ul>
                    --%>  
                </div>
                <div class="footerlinks">
                    <h2>
                        Site Info</h2>
                    <ul>
            <%--           <li><a href="#">Terms of Service</a></li>--%>  
                        <li><%:Html.ActionLink("Privacy Policy", "PrivacyPolicy", "Information")%></li>
                    </ul>
                </div>
            </div>
            <div id="footerright">
                <img src="<%=Url.Content("~/Content/images/FtBannerSmallWithoutBack.png")%>" alt=""
                    id="footerlogo">
                <p>
                    © 2011 ISEL</p>
        <%--        <h3>
                    Languages</h3>
                <ul class="footer-languages">
                         <li><a href="#">
                    <img src="<%=Url.Content("~/Content/images/english.jpg")%>" alt="English"/>English</a></li> >
                      <li><a href="#">
                           <img src="<%=Url.Content("~/Content/images/portugal.jpg")%>" alt="Português"/>Português</a></li> 
                </ul> --%>
            </div>
        </div>
    </div>