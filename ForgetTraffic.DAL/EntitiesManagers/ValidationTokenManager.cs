using System;
using System.Collections.Generic;
using System.Linq;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  31-05-2011  
     *              Name         :  ValidationTokenManager
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     *      Author                          |                           Date                
     * 
     * 
     * */

    public class ValidationTokenManager
    {
        private static IRepository<tblValidationToken> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblValidationToken>>(); }
        }


        public static List<tblValidationToken> Find(Func<tblValidationToken, bool> where)
        {
            return new List<tblValidationToken>(_repository.Find(where));
        }


        public static tblValidationToken Create
            (
            DateTime expirationDate,
            Guid userId,
            String unComputedString,
            String validationToken,
            int comunicationCount
            )
        {
            var token = new tblValidationToken
                            {
                                SYS_CREATE_DATE = DateTime.Now,
                                AllocationDate = expirationDate,
                                CommunicationCount = comunicationCount,
                                ExperitionTime = expirationDate,
                                SYS_STATE = "A",
                                SYS_USER_CREATE = "Application",
                                idIdentityValidation = Guid.NewGuid(),
                                UnprocessedStringToken = unComputedString,
                                ValidationToken = validationToken,
                                UserId = userId
                            };

            _repository.Add(token);
            return token;
        }

        public static tblUser GetUserByValidTokenLogin(String loginToken)
        {
            //_repository.ValidationTokenManager.Find(
            //                                            t =>
            //                                               t.ExperitionTime > DateTime.Now
            //                                            && t.UserId == user.UserId
            //                                            ).OrderBy( t=> t.SYS_CREATE_DATE ).ToList();


            //_repository.(x => x.ValidationToken.Trim().Equals(loginToken.Trim()));


            List<tblValidationToken> list =
                _repository.Find(
                    v => v.ValidationToken.Trim().Equals(loginToken.Trim(), StringComparison.InvariantCultureIgnoreCase)
                    ).OrderBy(v => v.SYS_CREATE_DATE).ToList();

            //var list = _repository.Find(x => x.ValidationToken.Equals(loginToken)).ToList();


            if (list.Count < 1)
                return null;

            return list[0].tblUser;
        }

        public static void MakeLoginTokenDirty(tblUser user)
        {

            tblValidationToken validateToken=  _repository.First(x => x.UserId.Equals(user.UserId));
            validateToken.SYS_STATE = "X";

        }
    }
}