using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Incident;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class IncidentVoteManager
    {
        private static IRepository<tblIncidentVote> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblIncidentVote>>(); }
        }

        /// <summary>
        /// Get number off votes by indicent and user
        /// to test if the user already voting on this incident
        /// </summary>
        /// <param name="incident"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetVoteCountByIncidentAndUser(tblIncident incident , tblUser user)
        {

            return  _repository.GetQuery().Where(x =>  x.UserId == user.UserId &&  x.IncidentId == incident.IncidentID  ).Count();
        }

        public static bool UserIsOwner( tblIncident incident , tblUser user )
        {
            return incident.tblUser.UserId.Equals(user.UserId);
        }

        public static tblIncidentVote VoteIncident(tblUser user, tblIncident incident, String comment, bool confirm)
        {

            tblIncidentVote incidentVote =  new tblIncidentVote()
                                                {
                                                    Comment = comment,
                                                    CreateDate = DateTime.Now,
                                                    IncidentId = incident.IncidentID,
                                                    LastModifyDate = DateTime.Now,
                                                    UserId = user.UserId,
                                                    VoteId = Guid.NewGuid(),
                                                    VoteType = confirm
                                                };

            _repository.Add(incidentVote);

            return incidentVote;

        }



        public static VoteInfo GetVoteInfoWithUserInformation(tblIncident  incidentVote, String loginToken )
        {

            int voteCount = 1;
            tblUser user;

            if (loginToken != null)
            {

                user = ValidationTokenManager.GetUserByValidTokenLogin(loginToken.Trim());

                if (user != null)
                    voteCount = GetVoteCountByIncidentAndUser(incidentVote, user);
            }


            VoteInfo ret = GetVoteCountingByIncident(incidentVote);
            ret.CantVote = voteCount < 1;

            return ret;
        }



        public static VoteInfo GetVoteCountingByIncident(tblIncident  incidentVote  )
        {


            //Sacar o todos os votos para a incidencia de transito
            var queryable =  _repository.GetQuery().Where( x =>  x.IncidentId == incidentVote.IncidentID );

            //Sacar os Votos Positivos
            int positive = queryable.Where(x => x.VoteType).Count();    

            //Sacar is Votos Negativos
            int negative = queryable.Where( x => !x.VoteType ).Count();

            int count = queryable.Count();

            int ratio = 0;

            try
            {
               ratio =  (count / positive) * 100;
            }
            catch (Exception){}
            

            return new VoteInfo()
                       {
                           Negative = negative,
                           Positive = positive,
                           Ratio = ratio 
                       };
        }

        //
    }
}
