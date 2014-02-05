

var map;
var markersArray = [];

var urlUpdateIncident;
//var urlSubmitVote = "http://localhost/ForgetTraffic.Service/ForgetTrafficService.svc/Incident";

var LastVerifyDate;
var MarkerCreateIncident;


var loginToken ;


function initialize() {

//    var haightAshbury = new google.maps.LatLng(40.22672332, -8.04863167);
    var haightAshbury = new google.maps.LatLng(38.22672332, -9.04863167);
    var mapOptions = {
        zoom: 8,
        center: haightAshbury,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    LastVerifyDate = 0;

    //    google.maps.event.addListener(map, 'click', function (event) {
    //        //addMarker(event.latLng);
    //        alert("Clicou no maps");
    //    });
//     var marker = new google.maps.Marker({
//         position: haightAshbury,
//         title: "Hello World!"
//     });
//     marker.setMap(map);

}

function displayError() {}



$(function () {

    urlUpdateIncident = $("#urlIncident").val(); 
    $("#incidentAdd").button(AddIncidentClick);
    $("#tbSubmitIncident").button();
    $("#tbCancel").button();


    $("#incidentAdd").click(AddIncidentClick);
    $("#tbCancel").click(HiddinIncidentPanel);
    $("#tbSubmitIncident").click(RegisterIncidentNew);

    initialize();

    $.get(urlUpdateIncident, initialise, 'json');

    

});

//Calback incident click
function AddIncidentClick() {
    GetLoginToken();

    if (loginToken == null) {
        $.jGrowl("Login required ", { header: 'Note', position: 'bottom-right', theme: 'iphone' });
        return;
    }

    $("#addIncidentPanel").css("display", "inline");
}
//Insert incident panel 
// (*) Cancel
function HiddinIncidentPanel() {
    google.maps.event.removeListener(dragListener);
    MarkerCreateIncident.setMap(null);
    $("#addIncidentPanel").css("display", "none");
    addIncidentButtonCarregado = false;
    MarkerCreateIncident = null;
    clearIncidenPanel();
 }

 function clearIncidenPanel() 
 {
     $('#title').val("");
     $('#desc').val("");
     $('#lat').val("");
     $('#long').val("");
     $('#localidade').val("");
     $('#concelho').val("");
     $('#distrito').val("");
     $('#severity').val("0");
     $('#type').val("0");
     $('#country').val("");
 }


 function initialise(incidentReturnSet) {

//    incidentReturnSet = eval('(' + incidentReturnSet + ')');

    processResponse(incidentReturnSet);

    var timer = $(this).everyTime(30000, TimerCallback, 50000);

}


function processResponse(incidentReturnSet) {

  
  
    LastVerifyDate = incidentReturnSet.Value.LastVerifyDate;

    $.each(incidentReturnSet.Value.AddedIncidents, function (i, OneIncident) {
                    setupLocationMarker(OneIncident, i);
                   // $.jGrowl("ADICIONOU INCIDENT ", { header: 'Important', life: 20000 });
                }
     );

    //UpDated Incidents
    $.each(incidentReturnSet.Value.UpdatedIncidents, function (i, OneIncident) {
            UpdatedIncidents(OneIncident, i);
            //$.jGrowl("UPDATE INCIDENT ", { header: 'Important', life: 20000 });
            }

      );

    //Deleted Incidents
    $.each(incidentReturnSet.Value.RemovedIncidents, function (i, OneIncident) {
        DeletedIncidents(OneIncident, i);
        //$.jGrowl("DELETE INCIDENT ", { header: 'Important', life: 20000 });
    }
         );
    
 }



//Updated incidents
function UpdatedIncidents(updateIncident, pos) {

    markersArray = $.grep(markersArray, function (marker, pos) {
        if (marker.incident.CodIncident == updateIncident.CodIncident) {
//            marker.incident = updateIncident;

            markersArray[pos].setMap(null);
            return false;
        }

        return true;
    });

    setupLocationMarker(updateIncident, pos);

}

 //Updated incidents
 function DeletedIncidents(updateIncident, pos) {

    markersArray =  $.grep(markersArray, function (marker, pos) {
         if (marker.incident.CodIncident == updateIncident.CodIncident) {
             markersArray[pos].setMap(null);
             return false;
         }

         return true;
     });
 }


function setupLocationMarker(OneIncident, pos) {
    

       var Incident = getIncident(OneIncident);
       var haightAshbury = new google.maps.LatLng(Incident.Latitude, Incident.Longitude);
       var icone = geticon(Incident.Type);

       var marker = new google.maps.Marker({
                                                position: haightAshbury,
                                                icon: geticon(Incident.Type),
                                                map: map,
                                                title: Incident.Description
//                                                ,animation: google.maps.Animation.DROP
        });

                                            marker.setMap(map);
                                            //Adicionar a incidencia
                                            marker.incident = OneIncident;

                                            markersArray.push(marker);
//     UpdateIfExist(OneIncident);

    google.maps.event.addListener(marker, 'click', function (marker) {

        var infowindow = new google.maps.InfoWindow({ content: createInfoWindow(Incident), size: new google.maps.Size(50, 50), position: haightAshbury });
            activateInfoWindows(infowindow); 
        });
}


function UpdateIfExist(Incident) {

    $.each(markersArray, function (i, marker) {

        if (marker.incident.CodIncident == Incident.CodIncident) 
        {

           // alert("A incidencia é igual" + marker.incident.CodIncident);

         }

    });

}


var activeInfoWindow;

function activateInfoWindows(infowindow) {
    if (activeInfoWindow != null) {
        activeInfoWindow.close(map);
        }
    activeInfoWindow = infowindow;
    activeInfoWindow.open(map);
}

function getIncident(OneIncident) {


    var Incident = { "Latitude": OneIncident.Coordinates.Latitude,
        "Longitude": OneIncident.Coordinates.Longitude,
        "UserName": OneIncident.UserName,
        "Title": OneIncident.Title,
        "PublicationDate": OneIncident.PublicationDateString,
        "Description": OneIncident.Description,
        "Type": OneIncident.Type,
        "CodIncident": OneIncident.CodIncident,
        "Ratio" : OneIncident.Votes.Ratio,
        "Positives" : OneIncident.Votes.Positive,
        "Negatives" : OneIncident.Votes.Negative,
        "UserRatio": OneIncident.UserRatio,
        "Severity": OneIncident.Severity
    }

    return Incident;
}
var addIncidentButtonCarregado = false;

function addIncident() {

    if (addIncidentButtonCarregado == false) {
        addIncidentButtonCarregado = true;
        google.maps.event.addListener(map, 'click', function (event) { addIncidentInfo(event.latLng); });
    }
    else {
        addIncidentButtonCarregado = false;
    }
}




function TimerCallback() {
    //alert('Disparou o timer no jquery ');
    $.getJSON(urlUpdateIncident + "?LastVerifyDate=" + LastVerifyDate, processResponse);
 };


// Actualiza as labels Localidade, concelho, distrito e coordenadas 
function updateLabelsIncident(coordendas, infoLocal) {

    document.getElementById('lat').value = coordendas.lat();
    document.getElementById('long').value = coordendas.lng();
    $("#long").html(coordendas.lng());
    $("#lat").html(coordendas.lat());
    if (infoLocal != null) {
        document.getElementById('localidade').value = infoLocal.Localidade;
        document.getElementById('concelho').value = infoLocal.Concelho;
        document.getElementById('distrito').value = infoLocal.Distrito;
        document.getElementById('country').value = infoLocal.Pais;
    }
}

function GetLoginToken()
{

    loginToken = $.cookie('LoginToken');

    if (loginToken == null) {
        $.jGrowl("You need logon on the website ", { header: 'Important', life: 2000 });
        return;
    }
}

var dragListener;
function addIncidentInfo(coordenadas) {


    if (MarkerCreateIncident == null) {
        MarkerCreateIncident = new google.maps.Marker({
            map: map,
            draggable: true,
            position: coordenadas
        });

        dragListener = google.maps.event.addListener(MarkerCreateIncident, 'dragend', function (event) {
            codeLatLng(event.latLng);
        });

//        var x = document.getElementById('InfoPanel');
//        x.innerHTML += "<table><tr><td style='width:100px;'></td><td style='width:100px;'></td></tr>"
//        x.innerHTML += "Titulo:&nbsp;<input type=\"text\" id='title' /></br>";
//        x.innerHTML += "Descrição: <input type=\"text\" id='desc' /></br>";
//        x.innerHTML += "Localidade: <input type=\"text\" id='localidade'/></br>";
//        x.innerHTML += "Concelho:&nbsp; <input type=\"text\" id='concelho'/</br>>";
//        x.innerHTML += "Distrito: <input type=\"text\" id='distrito'/></br>";
//        x.innerHTML += "Latitude: <input type=\"text\" id='lat' size='20'  value='" + coordenadas.lat() + "' readonly='readonly' /></br>";
//        x.innerHTML += "Longitude: <input type='text' id=long size=20  value='" + coordenadas.lng() + "' readonly='readonly' /></br>";
//        x.innerHTML += "Type of:&nbsp; <select id=type><option value='0'>Slow Traffic</option><option value='1'>Maintence Street</option><option value='2'>Police Trap</option><option value='3'>Accident</option></select><br/>";
//        x.innerHTML += "Severity: <select id=severity><option value='0'>Low</option><option value='1'>High</option><option value='2'>Very High</option></select></br><br/><br/>";
//        x.innerHTML += "<p><button onClick='RegisterIncidentNew();' class='btnLogin'> Adicione </button></p>";
    }
    else {
        MarkerCreateIncident.position = coordenadas;
    }
    // ACtualiza o campo do distrito, etc... 
    codeLatLng(coordenadas);
}




function RegisterIncidentNew() {

    var _loginToken = $.cookie('LoginToken');
    if (_loginToken == null) {
        $.jGrowl("You need logon on the website ", { header: 'Important', life: 20000 });
        return;
    }

    var _title = $('#title').val(); // document.getElementById('title').value;
    var _descricao = $('#desc').val(); // document.getElementById('desc').value;
    var _lat = $('#lat').val(); // document.getElementById('lat').value;
    var _long = $('#long').val();  //document.getElementById('long').value;


    var _localidade = $('#localidade').val(); // document.getElementById('localidade').value;
    var _concelho = $('#concelho').val();  // document.getElementById('concelho').value;
    var _distrito = $('#distrito').val();  //document.getElementById('distrito').value;

    var _severity = $('#severity').val();

    var _type = $('#type').val(); // document.getElementById('type').value;

    var codPais = locationInfo.CodigoPais;
    var pais = locationInfo.Pais;
    var CodPostal = locationInfo.CodigoPostal;


    PutIncident(
                _loginToken,
                _title,
                _descricao,
                _localidade,
                _concelho,
                _distrito,
                _lat,
                _long,
                _type,
                _severity,
                codPais,
                pais,
                CodPostal
            );

    //Limpar as cenas
    HiddinIncidentPanel();
}


function ExtractLocalInformation(arryAdresses) 
{

    locationInfo = {};
    locationInfo.Pais = arryAdresses[arryAdresses.length - 1].address_components[0].long_name;
    locationInfo.CodigoPais = arryAdresses[arryAdresses.length - 1].address_components[0].short_name;

    locationInfo.Distrito = arryAdresses[arryAdresses.length - 2].address_components[0].long_name;

    var i = arryAdresses.length;
         if (arryAdresses[i - 3 ].address_components[0] != null) {
             locationInfo.Concelho = arryAdresses[i - 3 ].address_components[0].long_name;
         }
         else {
             locationInfo.Concelho = 'NA';
          }
         if ( arryAdresses[i - 4] !=null &&  arryAdresses[i - 4].address_components[0] != null) {
             locationInfo.CodigoPostal = arryAdresses[i - 4].address_components[0].long_name;
         }
         else {
             locationInfo.Localidade = 'NA';
         }
         if (arryAdresses[i - 5 ] != null && arryAdresses[i - 5].address_components[0] != null) {
             locationInfo.Localidade = arryAdresses[i - 5 ].address_components[0].long_name;
         }
         else {
             locationInfo.CodigoPostal = 'NA';
         }
 }

// vai buscar a Localidade, Concelho e Distrito;
var locationInfo;
function codeLatLng(coordenadas) {

    var geocoder = geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'latLng': coordenadas }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (results[1]) {
                ExtractLocalInformation(results);
              
            }
        } else {
            $.jGrowl("Impossible getting the local information", { header: 'Important', life: 4000 });
        }
        updateLabelsIncident(coordenadas, locationInfo);
    });
}


function geticon(type) {
    if (type == 1)
        return maintenceIcon;
    if (type == 2)
        return policeIcon;
    if (type == 3)
        return accidentIcon;

    return slowIcon;
}


function GetDescrIncidentType(type) {
    if (type == 0)
        return 'Slow Traffic';
    if (type == 1)
        return 'Maintenance Street';
    if (type == 2)
        return 'Police Trap';
    if (type == 3)
        return 'Accident';

}
function GetSeveriry(tipo) 
{
    if(tipo == 0)
    return 'Low';
    if (tipo == 1)
        return 'High';
    if (tipo == 2)
        return 'Very High';

}

function createInfoWindow(Incident) {


    var likePath = 'http://dl.dropbox.com/u/3343576/Projecto/icones/ftLike_36x44.png';
    var dislikePath = 'http://dl.dropbox.com/u/3343576/Projecto/icones/ftDislike_36x44.png';

    // Creating the content   
    var content = '<div class="infoIncident">'
    + '<p ><img src="' + geticon(Incident.Type) + '" alt="Figure Incident" /> <b>Type :</b> ' + GetDescrIncidentType(Incident.Type) + '  </p><p>Severity: ' +GetSeveriry( Incident.Severity) + '</p>'
    + '<p class=\"divInfo\"  ><b>Title:</b> ' + Incident.Title + '</p> ' +
    '<p class=\"divInfo\" > <b>Desciption:</b> ' + Incident.Description + '</p> ' +
    '<p class=\"divInfo\" ><b>User: </b> ' + Incident.UserName + '&nbsp;&nbsp; <b> ['+Incident.UserRatio+'%] </p>' +
    '<p class=\"divInfo\">Publication Date : </b>' + Incident.PublicationDate + ' </p>'+
    '<div style=" margin-left: auto;   margin-right: auto;   width: 8em; "> ' +
    '<br/>    [' + Incident.Positives + ']<a alt=\'Agree\' onClick="votelike(true, ' + "'" + Incident.CodIncident + "'" + ' )"><img src="' + likePath + '" alt="Vote Positive" /></a> ' +
    '  &nbsp; [' + Incident.Negatives + ']<a alt=\'Disagree\' onClick="votelike(false , ' + "'" + Incident.CodIncident + "'" + ')"><img src="' + dislikePath + '" alt="Vote Negative" /></a> &nbsp;' +
    '</div></div>';

    return content;
}


function votelike( tipo, codIncident) {
      SubmitVote(codIncident, tipo)
}
function SubmitVote(codIncident , tipo) {

    GetLoginToken();
    

    if (loginToken == null) {
            alert("Error Geting login Token, submit the vote not possible,  please make new login");
        return;
    }
    var submitVote =
    {
                "CodIncident": codIncident,
                "LoginToken": loginToken,
                "PositiveVote": tipo,
                "Comment": "From Site"
    };

    var urlRequest = $("#urlIncident").val();
    activeInfoWindow.close(map);

    $.ajax({
        type: "PUT",
        url: urlRequest,
        data: $.toJSON(submitVote),
        dataType: 'json',
        contentType: "application/json;",
        success: function (result) {
            if (result.Error == true) {
                //Owner of incident
                if (result.StatusCode == 473) {
                    $("#own_vote").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                }
                //already vote
                if (result.StatusCode == 470) {
                    $("#vote_error").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).dialog("close");
                            }
                        }
                    });
               }
            }
            else {
                $.jGrowl("Your vote was submitted", { header: 'Sucess', position: 'bottom-right', theme: 'iphone' });
                TimerCallback();
            }
        }
    });

	
}





