using System;
using System.Collections.Generic;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;

public class IncidenceStubs
{
    private static IncidenceStubs _incidenceStubs;
    private readonly IncidentReturnSet _list;
    private int _contagem;

    public IncidenceStubs()
    {
        _contagem = 0;

        var innident = new Incident
                           {
                               CodIncident = Convert.ToString(  _contagem++),
                               Title = "A4 (A3 - Ermesinde)",
                               PublicationDate = Convert.ToDateTime("Mon, 06 Jun 2011 19:21:28 +0100"),
                               Concelho = "Maia",
                               Coordinates = new Cord
                                                 {
                                                     Latitude = 41.19895554,
                                                     Longitude = -8.57801533
                                                 },
                               UserName = "fmlvaz",
                               Description =
                                   "Trânsito lento na A4 no sentido Porto - Amarante entre o nó da A3 e o nó de Ermesinde",
                               Distrito = "Porto",
                               Localidade = "Águas santas",
                               LoginToken = "vvvvvv",
                               Type = 0
                           };

        var incident2 = new Incident
                            {
                                CodIncident = Convert.ToString( _contagem++),
                                Title = "A14 (Tent - Montemor-o-Velho)",
                                PublicationDate = Convert.ToDateTime("Sat, 28 May 2011 10:18:51 +0100"),
                                Concelho = "Montemor-o-Velho",
                                Coordinates = new Cord
                                                  {
                                                      Latitude = 40.25530624,
                                                      Longitude = -8.63806915
                                                  },
                                Description =
                                    "Tr?ito condicionado na A14 no sentido A1 - Coimbra - Figueira da Foz entre o n?? Tent?? e o n?? Montemor-o-Velho. (Motivo: Manutenção - Faixa: Esquerda com desvio de faixa)",
                                UserName = "vviana",
                                Distrito = "Coimbra",
                                Localidade = "Arazede",
                                LoginToken = "vvvvvv",
                                Type = 1
                            };


        _list = new IncidentReturnSet
                    {
                        AddedIncidents = new List<Incident>
                                       {
                                           incident2,
                                           innident
                                       }
                    };
    }

    public static IncidenceStubs IncidenceStubsSingleton()
    {
        if (_incidenceStubs == null)
        {
            _incidenceStubs = new IncidenceStubs();
        }

        return _incidenceStubs;
    }


    public void putIncident(Incident incident)
    {
        incident.CodIncident = Convert.ToString( _contagem++);

        _list.AddedIncidents.Add(incident);
    }

    public IncidentReturnSet GetIncidenceStubs()
    {
        return _list;
    }
}