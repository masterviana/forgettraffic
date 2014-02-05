

var _url = "http://194.210.194.95/forgetTraffic2/ForgetTrafficService.svc/PutingTest";


function PutIncident
( 
    _username,
    _title,
    _descritpion,
    _loginToken,
    _localidade,
    _concelho,
    _distrito,
    _latitude,
    _longitude,
    _type
)
{

    var input =
    {
        Username: _username,
        Title: _title,
        Description: _descritpion,
        LoginToken: _loginToken,
        Localidade: _localidade,
        concelho: _concelho,
        distrito: _distrito,
        Cordenadas :
            {
                Longitude : _longitude,
                Latitude: _latitude
            }


    };

    alert("Input: " + JSON.stringify(input));

    $.ajax({
        type: "POST",
        url: _url,
        contentType: "application/json",
        data: JSON.stringify(input),
        success: function (result) {
            alert("POST submetido com sucesso " );
        }
    });


}