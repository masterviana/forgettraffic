

namespace ForgetTraffic.GoogleRequest
{



    class Geocoding
    {
        // System.String initialRequest = "http://maps.googleapis.com/maps/api/geocode/json?address=Toledo&sensor=false&region=es";

        public void BuildUrlGetCoordenates(  )
        {
            


        }
        

    }




    // Examplo de um pedido HHTP: http://maps.googleapis.com/maps/api/geocode/json?address=Toledo&sensor=false&region=es   O region define o País a que se encontra para limitar a busca...
 
    /*You can set the Geocoding API to return results biased to a particular region using the region parameter. 
     * This parameter takes a ccTLD (country code top-level domain) argument specifying the region bias. 
     * Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. 
     * For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" 
     * (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").*/





    /*
     * # Returns
#
{
  "status": "OK",
  "results": [ {
    "types": [ "locality", "political" ],
    "formatted_address": "Toledo, España",
    "address_components": [ {
      "long_name": "Toledo",
      "short_name": "Toledo",
      "types": [ "locality", "political" ]
    }, {
      "long_name": "Toledo",
      "short_name": "TO",
      "types": [ "administrative_area_level_2", "political" ]
    }, {
      "long_name": "Castilla-La Mancha",
      "short_name": "CM",
      "types": [ "administrative_area_level_1", "political" ]
    }, {
      "long_name": "España",
      "short_name": "ES",
      "types": [ "country", "political" ]
    } ],
    "geometry": {
      "location": {
        "lat": 39.8567775,
        "lng": -4.0244759
      },
      "location_type": "APPROXIMATE",
      "viewport": {
        "southwest": {
          "lat": 39.7882200,
          "lng": -4.1525353
        },
        "northeast": {
          "lat": 39.9252666,
          "lng": -3.8964165
        }
      },
      "bounds": {
        "southwest": {
          "lat": 39.8105550,
          "lng": -4.1796354
        },
        "northeast": {
          "lat": 39.9250920,
          "lng": -3.8147915
        }
      }
    }
  } ]
}
*/
}
