<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ForgetTraffic.Site.Business" %>


<script language="ecmascript" type="text/ecmascript">

    $(function () {

        var urlSearchUsers = $("#urlAdmin").val(); // <%= Consts.BaseAdress + Consts.OpAdministrator %>;

        $("#btSubmit").button();
        $("#radio").buttonset();
        //Search for user
        $("#btSubmit").click(function () {

            var loginToken = $.cookie('LoginToken');
            if (loginToken == null) {
                $.jGrowl("You need logon on the website ", { header: 'Important', life: 2000 });
                return;
            }
         

            var userSearch = $('#txtUser').val();
            $.jGrowl("Get search by " + userSearch, { header: 'Sucess', position: 'bottom-right' });

           
            var filterItens =
            {
                LoginToken: loginToken,
                Users:
                    {
                        Username: userSearch
                    }
                };

            $.ajax({
                type: "POST",
                url: urlSearchUsers,
                contentType: "application/json",
                data: $.toJSON(filterItens),
                success: function (result) {
                    if (result.Error == true)
                        $.jGrowl("Error when get Users for adminnistrator " + result.Description, { header: 'Notification', position: 'bottom-right', theme: 'iphone' });
                    else {

                        var user = result.Value.Users[0];

                        $('#vhUsername').val(user.UserName);
                        $('#vhFirstName').val(user.FirstName);
                        $('#vhEmail').val(user.Email);

                        $('#vhRoles').val(user.CodUserRole);
                        if (user.CodUserRole == 0)
                            $('#vhRoles').val(9);

                        $('#states').val(user.CodState);

                        $.jGrowl("User are available on the System. ", { header: 'Sucess', position: 'bottom-right', theme: 'iphone' });

                    }
                }
            });
        });

        $("#btUpdateProfile").click(function () {

            var loginToken = $.cookie('LoginToken');
            if (loginToken == null) {
                $.jGrowl("You need logon on the website ", { header: 'Important', life: 2000 });
                return;
            }
            

            var username = $('#vhUsername').val();
            var newCodRole = $('#vhRoles').val();
            var newCodStatus = $('#states').val();

            var updatedProfile =
            {
                LoginToken: loginToken,
                User:
                    [
                        {
                            UserName: username,
                            CodNewRole: newCodRole,
                            CodNewStatus: newCodStatus
                        }
                    ],
                Incident:
                  []
            };

            $.ajax({
                type: "PUT",
                url: urlSearchUsers,
                contentType: "application/json",
                data: $.toJSON(updatedProfile),
                success: function (result) {
                    if (result.Error == true)
                        $.jGrowl("Error when get Users for adminnistrator " + result.Description, { header: 'Notification', position: 'bottom-right', theme: 'iphone' });
                    else {

                        var user = result.Value;
                        $.jGrowl("User Profile are Updated", { header: 'Sucess', position: 'bottom-right', theme: 'iphone' });

                    }
                }
            });

        });


    });
  
</script>


<table >
<tr>
    <td style="width:170px"> User Name </td>
    <td  style="width:30px;">Pesquisar</td>
</tr>

<tr>
    <td > <input type="text"  id="txtUser" name="foo" class="txtField"  /> </td>
    <td > <button id="btSubmit" >Search </button></td>
</tr>

</table>

 <div class="editor-label">
      <label> User Name  </label>  
 </div>
 
 

	<fieldset class="boxBody">
    <legend> User Info</legend>
         <div> <label>Username</label> </div>
	    <div>  <input disabled="disabled"  class="txtField" type="text" id="vhUsername"/> </div> 

        <div> <label>First Name</label> </div>
	    <div>  <input disabled="disabled"   class="txtField"  type="text"   id="vhFirstName"/> </div> 

        <div> <label>Email</label> </div>
	    <div>  <input disabled="disabled"  class="txtField"  type="text"  id="vhEmail" maxlength="100" size="50"/> </div> 
    
        <div> <label>Role</label> </div>
	    <div>  
            <select name="roles" id="vhRoles" class="cjComboBox" >
                <option value='5'>Admininstrator</option>
                <option value='9'>Users</option>
                <option value='10'>Services</option>
            </select>
        </div> 

         <div> <label>User State</label> </div>
	    <div>  
            <select name="states" id="states" class="cjComboBox">
                <option value='A'>Active</option>
                <option value='X'>Disable</option>
                <option value='W'>Waiting Confirmation</option>
            </select>
        </div> 
	  
	</fieldset>
    
    <input type="submit" class="btnLogin" value="Update" id="btUpdateProfile" tabindex="4"/>


