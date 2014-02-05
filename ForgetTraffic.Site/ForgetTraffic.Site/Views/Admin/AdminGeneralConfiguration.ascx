<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<script language="ecmascript" type="text/ecmascript">

    $(function () {
        $("#btGot").button();
        //Get Configuration Information
        $("#btGot").click(function () {

           var loginToken = $.cookie('LoginToken');
            if (loginToken == null) {
                $.jGrowl("You need logon on the website ", { header: 'Important', life: 2000 });
                return;
            }

            var urlDev = $("#urlAdmin").val();
            $.jGrowl("Url do pedido é :  " + urlDev, { header: 'Dev', position: 'bottom-right', theme: 'iphone' });
            //Preencher o filtro para pesquisa de informações no serviço
            var filterItens =
            {
                LoginToken : loginToken,
                Configuration:
                    {
                        AdminInfo: 'true'
                    }
            };
            $.ajax({
                type: "POST",
                url: urlDev,
                contentType: "application/json",
                data: $.toJSON(filterItens),
                success: function (result) {
                    if (result.Error == true)
                        $.jGrowl("Error when get Users for administrator " + result.Description, { header: 'Notification', position: 'bottom-right', theme: 'iphone' });
                    else {
                        $.jGrowl("The info configuration return with sucess", { header: 'Sucess', position: 'bottom-right', theme: 'iphone' });
                        var config = result.Value.Configuration;
                        $("#solveIncidentInterval").val(config.AlgoritmTimeInterval);
                        $("#loginTokenValidate").val(config.LoginTokenValidationTime);
                        $("#numbIncidentHour").val(config.UserSpamRoleForHour);
                        $("#lowRatioWar").val(config.LowRationWarning);
                        $("#lowRatioDisable").val(config.LowRatioUserDisable);
                        $("#negativeWeigth").val(config.NegativeWeigthVotes);
                        //Colocar as severidades
                        $("#severityLow").val(config.Low.Time);
                        $("#severityLowCod").val(config.Low.Cod);

                        $("#severityHigh").val(config.High.Time);
                        $("#severityHighCod").val(config.High.Cod);

                        $("#severityVeryHigh").val(config.VeryHigh.Time);
                        $("#severityVeryHighCod").val(config.VeryHigh.Cod);


                    }
                }
            });

        });

        $("#btUpdateConfig").click(function () {

              var loginToken = $.cookie('LoginToken');
            if (loginToken == null) {
                $.jGrowl("You need logon on the website ", { header: 'Important', life: 2000 });
                return;
            }

            var solverAlgInterval = $("#solveIncidentInterval").val();
            var loginTokenValidate = $("#loginTokenValidate").val();
            var numbIncidentHour = $("#numbIncidentHour").val();
            var lowRatioWar = $("#lowRatioWar").val();
            var lowRatioDisable = $("#lowRatioDisable").val();
            var negativeWeigth = $("#negativeWeigth").val();

            var severityLow = $("#severityLow").val();
            var severityLowCod = $("#severityLowCod").val();

            var severityHigh = $("#severityHigh").val();
            var severityHighCod = $("#severityHighCod").val();

            var severityVeryHigh = $("#severityVeryHigh").val();
            var severityVeryHighCod = $("#severityVeryHighCod").val();

            var updatedProfile =
            {
                LoginToken: loginToken,
                Configuration:
                {
                    AlgoritmTimeInterval: solverAlgInterval,
                    LoginTokenValidationTime: loginTokenValidate,
                    UserSpamRoleForHour: numbIncidentHour,
                    LowRationWarning: lowRatioWar,
                    LowRatioUserDisable: lowRatioDisable,
                    NegativeWeigthVotes: negativeWeigth,
                    Low:
                        {
                            Cod  : severityLowCod,
                            Time: severityLow
                        },
                    High:
                        {
                            Cod  : severityHighCod,
                            Time: severityHigh
                        },
                        VeryHigh:
                        {
                            Cod: severityVeryHighCod,
                            Time: severityVeryHigh
                        }

                }
            };

                var urlDev = $("#urlAdmin").val();

                $.ajax({
                    type: "PUT",
                    url: urlDev,
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


	<fieldset  class="boxBody" >
        <legend> Settings  </legend>



             <button id="btGot" >Get Information </button>
       
       <table width="100%">
        <tr>
            <td style="width:50%;">
                 <p id="form-login-username">
		        <label for="modlgn_username">Solve incident Algoritm time interval (Minutes)</label>
		        <input id="solveIncidentInterval" type="text" name="username" class="txtField" size="10"/>
	        </p>
	        <p id="form-login-password">
		        <label for="modlgn_passwd">Login Token Validation Time (Minutes)</label>
		        <input id="loginTokenValidate" type="text" class="txtField" size="18"/>
	        </p>
		     <p >
		        <label for="modlgn_passwd">Nº Incidents Report for (Hours)</label>
		        <input id="numbIncidentHour" type="text" name="password" class="txtField" size="10"/>
	        </p>
             <p >
		        <label for="modlgn_passwd">Low Ratio -  First Warning Percentage</label>
		        <input id="lowRatioWar" type="text" class="txtField" size="10"/>
	        </p>

              <p >
		        <label for="modlgn_passwd">Low Ration - User Disable Alert Percentage  </label>
		        <input id="lowRatioDisable" type="text" class="txtField" size="10"/>
	        </p>
              <p >
		        <label for="modlgn_passwd">Negative Votes Weigth for Removing  </label>
		        <input id="negativeWeigth" type="text" class="txtField" size="10"/>
	        </p>
            
            </td>
            <td style="width:50%;">
           
            <fieldset class="boxBody">
            <legend> Severity Associate Times (In Minutes)</legend>
                 <p id="P1">
		            <label for="modlgn_username">Low</label>
		            <input id="severityLow" type="text" name="3" class="txtField" size="10"/>
                    <input id="severityLowCod" type="hidden" name="3" class="txtField" size="10"/>
	             </p>
                  <p id="P2">
		            <label for="modlgn_username">High</label>
		            <input id="severityHigh" type="text" name="4" class="txtField" size="10"/>
                     <input id="severityHighCod" type="hidden" name="3" class="txtField" size="10"/>
	             </p>
                  <p id="P3">
		            <label for="modlgn_username">Very High</label>
		            <input id="severityVeryHigh" type="text" name="1" class="txtField" size="10"/>
                     <input id="severityVeryHighCod" type="hidden" name="3" class="txtField" size="10"/>
	             </p>
            </fieldset>
            </td>
        </tr>
       </table>

	       

		    <p><label for="modlgn_passwd"> * Note - All change you make here affect the whole System behavior please be ware     </label></p>

            <p>
                    <input type="submit" value="Update" id="btUpdateConfig" class="btnLogin"  tabindex="4"/>
            </p>

    </fieldset>