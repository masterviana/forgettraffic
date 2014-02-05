using System;
using System.Collections.Generic;
using ForgetTraffic.Autentication;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Incidents;
using ForgetTraffic.ServiceUtils;

namespace ForgetTraffic.TrafficIncidences
{
    public class OccurenceOperations
    {



        #region Put incidents

        public ServiceOutput<Incident> AddIncident(AddIncident incident)
        {
            //Testar à cabeça se os parametros vêem correctamente preenchidos
            ServiceOutput<Incident> _return;
            if ((_return = PutingIncidentIsOk(incident)).Error)
                return _return;

            if (!CheckOcurrenceExistOnSystem(incident))
            {
                return new ServiceOutput<Incident>
                           {
                               Error = true,
                               Description = "This incident already exist on system",
                               Title = "Already Exist"
                           };
            }
            else
            {
                tblUser _user = ValidationTokenManager.GetUserByValidTokenLogin(incident.LoginToken.Trim());
                //tblUser _user = UserManager.GetUser("Master",Guid.Empty);
                if (_user == null)
                {
                    return new ServiceOutput<Incident>
                               {
                                   Error = true,
                                   Description = "LoginToken is invalid, try logon before submit incident",
                                   Title = "Login token invalid"
                               };
                }
                if (!AccountOperations.CheckCredentialsByToken(incident.LoginToken))
                    return new ServiceOutput<Incident>()
                    {
                        Error = true,
                        Description = "You need autentication for this operations please login on the system",
                        Title = "This loggin token are empty/null or is invalid"
                    };

                //Adioncar mais uma incidencia ao total de incidencias perfil do utilizador
                //Coloar o username rasurdo caso seja preciso
                tblUserProfile userProfiler = UserProfileManager.GetUserProfile(_user);
                if (userProfiler != null)
                {
                    userProfiler.SubimtIncidents += 1;
                }


                ServiceOutput<tblIncident> _incident = IncidenceManager.AddIncidence(incident, _user);



                return new ServiceOutput<Incident>
                           {
                               Value = new Incident()
                                           {
                                               Concelho = _incident.Value.tblLocalization.County,
                                               Distrito = _incident.Value.tblLocalization.District,
                                               Localidade = _incident.Value.tblLocalization.Locality,
                                               Coordinates = new Cord()
                                                                 {
                                                                     Latitude = _incident.Value.tblCoordinates.Latitude,
                                                                     Longitude = _incident.Value.tblCoordinates.Longitude
                                                                 },
                                               UserName = _incident.Value.tblUser.UserName,
                                               Description = _incident.Description,
                                               Title = _incident.Title,
                                               EndDate = _incident.Value.EstimatedEndDate,
                                           },
                               Error = false,
                               Title = "Add with sucess on the system"
                           };
            }
        }

        #endregion

        #region Validation Code Region

        /// <summary>
        /// Verifica se esta incidencia já se encontra no sistema!
        /// </summary>
        /// <param name="incident"></param>
        private bool CheckOcurrenceExistOnSystem(AddIncident incident)
        {
            FactoryValidateIncident.SINGLETON().SetIncident(incident);

            return IncidenceManager.Find(
                x => FactoryValidateIncident.SINGLETON().VerifyIfAlreadyExist(x)
                       )
                       .Count == 0;
        }

        /// <summary>
        /// This Method check if the incident information are complety fill;
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        private static ServiceOutput<Incident> PutingIncidentIsOk(AddIncident incident)
        {
            if( incident == null)
                return new ServiceOutput<Incident>()
                           {
                               Error = true,
                               Description = "Incident was Null Please pass a valid incident"
                           };
            //testar as coordenadas da incidencia
            if (incident.Coordinates == null || incident.Coordinates.Latitude == 0 || incident.Coordinates.Longitude == 0)
                return new ServiceOutput<Incident>
                           {
                               Error = true,
                               Description = "Parameter coordinate : are incorrect filled or the cordinates are wrong"
                           };

            //Testar os parametres geograficos
            bool error = false;
            String Descr = "";
            if (String.IsNullOrEmpty(incident.Distrito))
            {
                error = true;
                Descr += "Disctrict can not be empty or null "  + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(incident.Concelho))
            {
                error = true;
                Descr += "County can not be empty or null " + Environment.NewLine; ;
            }
            if (String.IsNullOrEmpty(incident.Pais))
            {
                error = true;
                Descr += "Country can not be empty or null " + Environment.NewLine; ;
            }
            if (String.IsNullOrEmpty(incident.Title))
            {
                error = true;
                Descr += "Title can not be empty or null " + Environment.NewLine; ;
            }
            if (String.IsNullOrEmpty(incident.CodePais))
            {
                error = true;
                Descr += "CodeCountry can not be empty or null " + Environment.NewLine; ;
            }

            if( error)return  new ServiceOutput<Incident>()
                                  {
                                      Error = true,
                                      Title ="Parameters are empty or null",
                                      Description = Descr
                                  };

            //Testar o login token
            if (String.IsNullOrEmpty(incident.LoginToken))
                return new ServiceOutput<Incident>
                           {
                               Error = true,
                               Description = "Parameter login token is required"
                           };

            return new ServiceOutput<Incident>
                       {
                           Error = false
                       };
        }

        #endregion


        #region Votes Operations


        public static ServiceOutput<tblIncidentVote> VoteOnIncident(VoteSubmit vote)
        {

            //Verificar a integridade do utilizador
            tblUser _user = ValidationTokenManager.GetUserByValidTokenLogin(vote.LoginToken.Trim());
            if (_user == null)
            {
                return new ServiceOutput<tblIncidentVote>
                {
                    Error = true,
                    Description = "LoginToken is invalid, try logon before submit incident",
                    Title = "Login token invalid"
                };
            }
            //Verifica se o utilizador tem permissões para fazer este tipo de código
            if (!AccountOperations.CheckCredentialsByToken(vote.LoginToken))
                return new ServiceOutput<tblIncidentVote>()
                        {
                            Error = true,
                            Description = "You need autentication for this operations please login on the system",
                            Title = "This loggin token are empty/null or is invalid"
                        };

            tblIncident occurrence = IncidenceManager.GetIncidentById(vote.CodIncident.Trim());
            if (occurrence == null)
            {
                return new ServiceOutput<tblIncidentVote>()
                           {
                               Error = true,
                               Description = "This incident is no longer available on the system. Your status mybe was change",
                               Title = "Id Incident is no longer available on the system "

                           };
            }
            //Testar se esta este utilizar já votou na incidencia 
            int count = IncidentVoteManager.GetVoteCountByIncidentAndUser(occurrence, _user);
            if (count >= 1)
                return new ServiceOutput<tblIncidentVote>()
                           {
                               Error = true,
                               Description = "This user already vote on this incident",
                               Title = " The user already assigned this incident"
                           };

            //Vou adicionar o voto à incidencia
            IncidentVoteManager.VoteIncident(_user, occurrence, vote.Comment, vote.PositiveVote);

            //Vou Adicionar mais um voto ao perfil
            tblUserProfile userProfile = UserProfileManager.GetUserProfile(_user);
            if (userProfile != null)
                userProfile.VotesCount += 1;

            //Alterar data da ultima actualização da incidência incidencia 
            occurrence.SYS_LAST_MODIFY_DATE = DateTime.Now;

            return new ServiceOutput<tblIncidentVote>()
                       {
                           Error = true,
                           Description = "The vote was added on incident",
                           Title = "Operation Sucess"
                       };
        }
    }


        #endregion
    }
