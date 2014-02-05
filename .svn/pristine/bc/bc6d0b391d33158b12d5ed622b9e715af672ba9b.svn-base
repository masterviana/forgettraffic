using System;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.ParallelsServices;
using ForgetTraffic.TrafficIncidences.SolveIncidents;

namespace AboutTraffic.Runner
{
    internal class Program
    {


        private static void Main(string[] args)
        {
           ForgetTraffic.InitializeStructure.GeneralInitialize.Initialize();

           ForgetTraffic.ParallelsServices.SolveIncidentService.SINGLETON();

            //GenericService service =  new GenericService();

            //service.Solve(null , null);

           //tblSysState status = ForgetTraffic.DAL.EntitiesManagers.StatusManager.GetByCodeAndParent(SysCodes.StDelete, SysCodes.SysStates);
      

           // Console.WriteLine("Está a correr");

           // SolveIncidentService target = new SolveIncidentService(); // TODO: Initialize to an appropriate value
           // //object snyc = null; // TODO: Initialize to an appropriate value
            //target.Run(snyc);

            Console.ReadLine();


        }

        //private static void Main(string[] args)
        //{
        //    //OccurrenceInfoOptional _op = new OccurrenceInfoOptional();

        //    //_op.Distrito = "Evora";
        //    //_op.Localidade = "Mora";
        //    //_op.Concelho = "Mora";
        //    //_op.Description = "Isto é só para testar";


        //    //WsRequest _request = new WsRequest();


        //    //String JsonProcess = _request.SerializeToJson(_op);
        //    //_request.MakeJsonRequest(JsonProcess);

        //    ////WsService.ConectWsService();


        //    //Console.ReadLine();
        //}


        public static void CreateUser(String userName, String firstName, String lastName, String email, String birthDate)
        {
            using (var entidade = new ForgetTrafficEntities())
            {
                var _user = new tblUser
                                {
                                    CreateDate = DateTime.Now,
                                    Email = email,
                                    FirstName = firstName,
                                    LastName = lastName,
                                    BirthDate = birthDate,
                                    UserId = Guid.NewGuid()
                                };

                entidade.tblUser.AddObject(_user);

                entidade.SaveChanges();
            }
        }
    }
}