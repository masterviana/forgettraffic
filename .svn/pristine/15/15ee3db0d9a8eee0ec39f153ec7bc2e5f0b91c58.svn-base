<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<h3>Identificação</h3>

            <p>Para se registar clique <a href="<%:Url.Action("Register", "Account")%>"> aqui</a> </p>

<form action="/Account/LogOn" method="post" name="login" id="form-login">
		<fieldset class="input">
	        <p id="form-login-username">
		        <label for="modlgn_username">Utilizador</label><br>
		        <input id="modlgn_username" type="text" name="username" class="inputbox" alt="username" size="18"/>
	        </p>
	        <p id="form-login-password">
		        <label for="modlgn_passwd">Palavra-Passe</label><br>
		        <input id="modlgn_passwd" type="password" name="password" class="inputbox" size="18" alt="password"/>
	        </p>
		    <p id="form-login-remember">
		        <label for="modlgn_remember">Lembrar</label>
		        <input id="modlgn_remember" type="checkbox" name="remember" class="inputbox" value="yes" alt="Remember Me">
	        </p>
		    <input type="submit" name="Submit" class="button" value="Login"><br />

            <a href="#">
			Esqueceu Palavra-Passe</a>
            <a href="#">
			Esqueceu-se Utilizador</a>
	     </fieldset>
</form>