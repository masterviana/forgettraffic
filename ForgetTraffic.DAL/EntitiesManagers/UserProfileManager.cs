using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class UserProfileManager
    {

        private static IRepository<tblUserProfile> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblUserProfile>>(); }
        }


        public static tblUserProfile  CreateUserProfile(tblUser user)
        {
            tblUser _user = UserManager.GetUser( user.UserName.Trim() , Guid.Empty);
            if (_user == null)
                return null;

            tblUserProfile _profile = new tblUserProfile()
                                          {
                                              CodUser = user.UserId,
                                              CodUserProfile = Guid.NewGuid(),
                                              LoginCount = 0,
                                              ProfilePoints = 0,
                                              SubimtIncidents = 0,
                                              ValidateIncidents = 0,
                                              VotesCount = 0,
                                              HiddenInformation = false,
                                              InvalidatIncidents = 0
                                          };
            _repository.Add(_profile);


            return _profile;
        }

        public static tblUserProfile GetUserProfile(tblUser user)
        {
            tblUserProfile _profile = _repository.Single(x => x.tblUser.UserId == user.UserId);
            if(_profile == null)
            {
                _profile = CreateUserProfile(user);
            }

            return _profile;
        }

        public static void UpdateUserProfile( tblUser user ,  bool hidenUsername )
        {
            tblUserProfile profile =  GetUserProfile(user);

            if( profile != null )
            {
                profile.HiddenInformation = hidenUsername;
            }

            profile.SYS_LAST_MODIFY_DATE = DateTime.Now;
            
        }

    }
}
