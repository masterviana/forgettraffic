<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>


        <h3>Identificação</h3>
    <% 
        var action = Url.Action("LogOn","Account");
        var cookie = Request.Cookies["InfoUser"];
           if(cookie == null || cookie.Value==String.Empty)
           {
               if (Request.Cookies["LoginToken"] != null) Request.Cookies["LoginToken"].Expires = DateTime.MinValue;
%>
            
            <p >Para se registar clique <a href="<%:Url.Action("Register", "Account")%>"> aqui</a> </p>
             

<form action="<%=action %>" method="post" name="login" id="form-login" >
		<fieldset class="boxBody">
	        <p id="form-login-username">
		        <label for="modlgn_username">Utilizador</label><br>
		        <input id="modlgn_username" type="text" name="username" class="txtField" size="18"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	        </p>
	        <p id="form-login-password">
		        <label for="modlgn_passwd">Palavra-Passe</label><br>
		        <input id="modlgn_passwd" type="password" name="password" class="txtField" size="18"/>
	        </p>
		    <p id="form-login-remember">
		        <%--<label for="modlgn_remember">Lembrar</label>
		        <input id="modlgn_remember" type="checkbox" name="remember" class="inputbox" value="yes" />--%>
	        </p>
		 
              <p>
                    <input type="submit" value="Log On" class="btnLogin"  tabindex="4"/>
                </p>

	     </fieldset>
</form>


    <%} else {%>
    
    <fieldset>
        
        <div class="display-label">User Name: &nbsp; <%:cookie["UserName"]%> </div><br />
        <div class="display-label">First Name: &nbsp;<%:cookie["FirstName"]%></div><br />
        <div class="display-label">Last Name: &nbsp; <%:cookie["LastName"]%></div><br />
        &nbsp;<br/>
        <div><%:Html.ActionLink("LogOff", "LogOff", "Account")%></div>
        <div><%:Html.ActionLink("Update Profile", "UpdateRegister", "Account")%></div>

    </fieldset>
<%} %>
