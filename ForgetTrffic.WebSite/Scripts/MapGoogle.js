

function Teste() {

    alert("VAi fazer o pedido . . ");

    PutIncident(
        "vviana",
        "um titulo",
        "description",
        "==zsdazsdfa",
        "Mora",
        "Mora",
        "Evora",
        100,
        200,
        0
    );
}


// make a json request to get the map data from the Map action
$(function () {
   // $.getJSON("/Home/GetMapIncidents", initialise)
    $.get("http://194.210.194.95/forgetTraffic2/ForgetTrafficService.svc/GetAllOccurrenceJson", initialise);

    //   Teste();

});

function initialise(mapData) {

    var latlng = new google.maps.LatLng(40.22672332, -8.04863167);
    var myOptions = { zoom: 8, center: latlng, mapTypeId: google.maps.MapTypeId.ROADMAP };
    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

 //   $.each(mapData, function (i, OneIncident) {
    // A Usar o Serviço 
    $.each(mapData.Incident, function (i, OneIncident) {
        setupLocationMarker(OneIncident, i);
    });
}

function setupLocationMarker(OneIncident, pos) {

    var Incident = getIncident(OneIncident);

    var icone = geticon(Incident.Type)


    var latlng = new google.maps.LatLng(Incident.Latitude, Incident.Longitude);
    var marker = new google.maps.Marker({ position: latlng,
        map: map,
        icon: icone,
        title: Incident.Description
    });
    marker.setMap(map);

    var infowindow = new google.maps.InfoWindow({ content: Incident.Description, size: new google.maps.Size(50, 50), position: marker.position });

    google.maps.event.addListener(marker, 'click', function (marker) {

        document.getElementById('rigth_panel').innerHTML = "Titulo: " + Incident.Title + "<p>Descrição: " + Incident.Description + "<p>Utilizador: " + Incident.Username;
    });

}

function getIncident(OneIncident) {

    var Incident = { "Latitude": OneIncident.OccurInfo.Cordenadas.Latitude,
        "Longitude": OneIncident.OccurInfo.Cordenadas.Longitude,
        "Username": OneIncident.OccurInfo.Username,
        "Title": OneIncident.OccurInfo.Title,
        "Description": OneIncident.OccurInfo.Description,
        "Type": OneIncident.OccurInfo.Type
    };
    return Incident; 
}
var addIncidentButtonCarregado = false;

function addIncident() {

    if (addIncidentButtonCarregado == false) {
        addIncidentButtonCarregado = true;
        google.maps.event.addListener(map, 'dblclick', function (event) {            addIncidentInfo(event.latLng);   });
    }
}


function addIncidentInfo(coordenadas) {

    addIncidentDetails(coordenadas);
   // document.getElementById('rigth_panel').innerHTML = coordenadas;
}
function geticon(type) {
    if (type == 1)
        return 'http://dl.dropbox.com/u/3068906/maintenance.png';
    return 'http://dl.dropbox.com/u/3068906/traffic.png';
}

function addIncidentDetails(coordenadas) {

//    alert(coordenadas);
//    alert(coordenadas.Ia);
    var Ha = coordenadas.Ha.toString();
    var Ia = coordenadas.Ia.toString();
    var x = document.getElementById('rigth_panel');
    x.innerHTML = "Titulo: <input type=\"text\" id='title' />";
    x.innerHTML += "Descrição: <input type=\"text\" id='desc' />";
    x.innerHTML += "Localidade: <input type=\"text\" />";
    x.innerHTML += "Latitude: <input type=\"text\" id='lat' size='20'  value='"  + Ha +  "'/>";
    x.innerHTML += "Longitude: <input type=\"text\" id='long' size='20'  value='" + Ia + "'/>";
    x.innerHTML += "<button onClick='clicouNoBotao();'> Adicione </button>";

//    var _divMaster = $('#test');

//    ("<button onClick='clicouNoBotao();'> Adicione </button>").appendTo(_divMaster);


    }


    function clicouNoBotao() {

        var _title = document.getElementById('title').value;
        var _descricao = document.getElementById('desc').value;
        var _lat = document.getElementById('lat').value;
        var _long = document.getElementById('long').value;


            PutIncident(
                "vviana",
                _title,
                _descricao,
                "==zsdazsdfasfd",
                "Mora",
                "Mora",
                "Evora",
                _lat,
                _long,
                0
            );
            

    }