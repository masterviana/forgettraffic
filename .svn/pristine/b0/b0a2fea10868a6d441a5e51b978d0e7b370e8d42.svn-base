using System;
using ForgetTraffic.DAL.Conctracts;
using ForgetTraffic.DataModel;
using StructureMap;

namespace ForgetTraffic.DAL.EntitiesManagers
{
    public class StatusManager
    {
        private static IRepository<tblSysState> _repository
        {
            get { return ObjectFactory.GetInstance<IRepository<tblSysState>>(); }
        }

        public static void AddStatus(tblSysState state)
        {
            _repository.Add(state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeParent"></param>
        /// <returns></returns>
        public static tblSysState GetByCodeAndParent( String code, String codeParent)
        {
            tblSysState _state=  _repository.Single(x => x.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                                    && x.CodeParent.Equals(codeParent, StringComparison.InvariantCultureIgnoreCase));

            return _state;

        }


        public static string Update( String code , String codeType , String OldCode )
        {

            tblSysState state =  _repository.Single(x => x.Code.Equals(OldCode));
            

            if (state == null)
            {
                return "Não existem codigo com essa descrição";
            }

            state.Code = code;
            state.Description = DateTime.Now.ToString();

            return "Foi actualizado";

        }


    }
}