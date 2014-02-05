using System;
using System.Collections.Generic;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes.Error;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    /*
 * ----------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------
 *              Author       :  Vitor Viana
 *              Date         :  25-05-2011  
 *              Name         :  IRepository
 *              Description  :  Manage the User Entities
 * ----------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------
 *                      Revison List
 *--------------------------------------------------------------------------------------             
 * Author           |       Date                
 * 
 * 
 * */

    public class UserProviderMananger
    {
        private static IRepository<tblUserProvider> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblUserProvider>>(); }
        }

        /// <summary>
        /// Adiconar um provider ao sistema
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="secretQuestion"></param>
        /// <param name="secretAnwser"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static tblUserProvider AddUserProvider(
            Guid userId,
            String pass,
            String secretQuestion,
            String secretAnwser,
            byte[] salt
            )
        {
            // colocar com o estado anulado no caso de já existir um provider para este utilizador!
            tblUserProvider _provider = _repository.Single(x => x.UserId == userId && x.SYS_STATE.Trim().Equals("A"));
            if (_provider != null)
            {
                _provider.SYS_STATE = "X";
                _provider.SYS_LAST_UPDATE_USER = "application";
                _provider.SYS_LAST_UPDATE_DATE = DateTime.Now;
            }


            _provider = new tblUserProvider
                            {
                                UserId =  userId,
                                IdProvider = Guid.NewGuid(),
                                SecretQuestion = secretQuestion,
                                SecretAnwser = secretAnwser,
                                PassHash = pass,
                                IdStatus = "A",
                                Islogged = false,
                                LastLoggegDate = DateTime.Now,
                                PassSalt = salt,
                                SYS_STATE = "A",
                                SYS_USER_CREATE = "application",
                                SYS_CREATE_DATE = DateTime.Now
                            };

            try
            {
                _repository.Add(_provider);

                return _provider;
            }
            catch (Exception ex)
            {
                throw new ForgetTrafficError("Error when try create user provider " ,501, "Create provider error");
            }
        }


        public static void UpdateProvider(
            tblUser user,
            Guid idProvider,
            String password,
            byte [] passSalt,
            String state,
            String secretQuestion,
            String secretAnswer
            )
        {
            tblUserProvider _provider = GetActiveProvider(user, idProvider);
            if (_provider == null)
                throw new Exception(
                    String.Format("Não existe nenhum provider activo para o utilizador com username \"{0}\" ",
                                  user.UserName));

            //A pass não é null nem vazia por isso vou ter de actualiza-la
            if( !String.IsNullOrEmpty(password) )
            {
                if(!String.IsNullOrEmpty(secretQuestion) && !String.IsNullOrEmpty(secretAnswer) )
                {
                    AddUserProvider
                        (
                            _provider.tblUser.UserId,
                            password,
                            secretQuestion,
                            secretAnswer,
                            passSalt
                        );
                }

                if(passSalt ==null || passSalt.Length == 0 )
                    throw  new Exception("The pass salt can't be null or empty for a new password");

                _provider.PassHash = password;
                _provider.PassSalt = passSalt;
            }


            if (!String.IsNullOrEmpty(secretQuestion)) _provider.SecretQuestion = secretQuestion;
            if (!String.IsNullOrEmpty(secretAnswer)) _provider.SecretAnwser= secretAnswer;

            if (!String.IsNullOrEmpty(state)) _provider.SYS_STATE = state;

            _provider.SYS_LAST_UPDATE_DATE = DateTime.Now;
            _provider.SYS_LAST_UPDATE_USER = "application";
        }


        public static tblUserProvider GetActiveProvider
            (
            tblUser user,
            Guid idProvider
            )
        {
            if (user == null && idProvider == Guid.Empty)
                return null;

            if (user != null && idProvider != Guid.Empty)
                _repository.First(
                    x => x.IdProvider == idProvider && x.UserId == user.UserId && x.SYS_STATE.Trim().Equals("A"));

            return user == null
                       ? _repository.First(x => x.IdProvider == idProvider && x.SYS_STATE.Trim().Equals("A"))
                       : _repository.First(x => x.UserId == user.UserId && x.SYS_STATE.Trim().Equals("A"));
        }

        /// <summary>
        /// Retorna uma ICollections com os paremetros passados na funcao de where . . 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static ICollection<tblUserProvider> Find(Func<tblUserProvider, bool> where)
        {
            return new List<tblUserProvider>(_repository.Find(where));
        }

        public static void Delete(tblUserProvider provider)
        {
            _repository.Delete(provider);
        }


        public static tblUser GetUserByToken(String token)
        {
            if (string.IsNullOrEmpty(token)) throw new Exception(String.Format("Doesnt exist one user for this loggin token. Please try logon the user, or contact the Forget Traffic Admistration"));

            tblUser _user =
                _repository.Single(x => x.PassHash.Trim().Equals(token, StringComparison.CurrentCultureIgnoreCase)).
                    tblUser;

            return _user ?? null;
        }
    }
}