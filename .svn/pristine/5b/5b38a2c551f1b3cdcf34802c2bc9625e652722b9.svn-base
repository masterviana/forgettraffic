using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using StructureMap;


namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class ActionManager
    {

        private static IRepository<tblConfirmActions> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblConfirmActions>>();  }
        }


        public static tblConfirmActions AddConfirmaAction(
                                                    tblUser userToAction,
                                                    tblSysState actionType, 
                                                    String token,
                                                    DateTime validationEndTime
            )
        {
             
            tblConfirmActions actions = new tblConfirmActions()
                                            {
                                                IdConfirmActions =  Guid.NewGuid(),
                                                ValidateEndTime =  validationEndTime,
                                                tblUser = userToAction,
                                                tblSysState = actionType,
                                                Token = token,
                                                SYS_CREATE_DATE = DateTime.Now,
                                                SYS_LAST_MODIFY_DATE = DateTime.Now
                                            };

            try
            {
                _repository.Add(actions);
            }
            catch (Exception exception)
            {

                throw exception;
            }

            return actions;
        }


        public static tblConfirmActions FindByTokenId( String id  )
        {

            try
            {

              tblConfirmActions ret = _repository.Single(x => x.IdConfirmActions.ToString().ToLower().Equals(id.Trim().ToLower(),StringComparison.InvariantCultureIgnoreCase)) ;

              if( ret == null)
              {
                  //log.Logger.SINGLETON.writeEvent("Não existe nenhum token na tabela tblConfirmActions " + id  ,WriteType.Error);
                  return null;
              }

                return ret;

            }
            catch (Exception  ex)
            {
                throw ex;
            }

        }

    }
}
