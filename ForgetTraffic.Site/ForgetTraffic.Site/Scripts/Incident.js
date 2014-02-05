

function PutIncident
(
    _loginToken,
    _title,
    _descritpion,
    _localidade,
    _concelho,
    _distrito,
    _latitude,
    _longitude,
    _type,
    _severity,
    _codPais,
    _pais,
    _CodPostal
)
{
    var urlRequest = $("#urlIncident").val();
    var input =
    {
        LoginToken: _loginToken,
        Title: _title,
        Description: _descritpion,
        Localidade: _localidade,
        Concelho: _concelho,
        Distrito: _distrito,
        Type: _type,
        Coordinates:
            {
                Longitude : _longitude,
                Latitude: _latitude
            },
        Severity: _severity,
        CodePais: _codPais,
        CodePostal: _CodPostal,
        Pais: _pais
        };

        $.ajax({
            type: "POST",
            url: urlRequest,
            contentType: "application/json",
            data: $.toJSON(input),
            dataType: 'json',
            success: function (result) {
                if (result.Error == true) {
                    if (result.StatusCode == 472) {
                        $("#spam_error").dialog({
                            modal: true,
                            buttons: {
                                Ok: function () {
                                    $(this).dialog("close");
                                }
                            }
                        });
                    }
                    var title = $("#vhCustomerErrorTitle").html(result.Title);
                    var descr = $("#vhCustomerErrorDescr").html(result.Description);
                    $("#idCustomError").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
                else {
                    TimerCallback();
                    $.jGrowl("Your incident are sucess submited", { header: 'Notification', position: 'bottom-right', theme: 'smoke' });
                }

            }
        });


}



