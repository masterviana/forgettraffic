using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ForgetTraffic.AnsycLibrary;
using ForgetTraffic.DataModel;
using ForgetTraffic.DataTypes;
using ForgetTraffic.DataTypes.Interfaces;
using ForgetTraffic.SapoTraffic;
using ForgetTraffic.TrafficIncidences.SolveIncidents;
using StructureMap;

namespace ForgetTraffic.ParallelsServices
{
   public  class SolveIncidentService : Interfaces.IRunnable<object>
   {

       private static SolveIncidentService _singleton;
 
       public static SolveIncidentService SINGLETON()
       {
           if(_singleton == null)
               _singleton = new SolveIncidentService();

           return _singleton;
       }

        private readonly Object _snyc;
        private IGenericService<tblIncident> _service;
        private GenericTimer<Object> _timer;
        private GenericTimer<Object> _timerSapo;

        //private Timer _timer;

       public SolveIncidentService()
       {
           _snyc = new object();


           _service = ObjectFactory.GetInstance<IGenericService<tblIncident>>();

           _service.Solve(null, null);

           //_timer = new GenericTimer<object>(_snyc, Consts.SolveIncidentInterval, 200, Solve);
           _timerSapo = new GenericTimer<object>(_snyc, Consts.SapoRunnerInterval, 200, RunSapoIncidents);

           //_timer  = new Timer( Run, _snyc,200,10000 );
           
           //_timer.Resume();

       }

      

       public void Solve(Object i, object tInput)
       {

           _service.Solve(null, tInput);
           
           ForgetTraffic.InitializeStructure.GeneralInitialize.Commit();

       }

       public void RunSapoIncidents(Object i, object tInput)
       {
           SapoToService.ContactToService();
           ForgetTraffic.InitializeStructure.GeneralInitialize.Commit();
       }

       public void Run(object snyc)
       {
           throw new NotImplementedException();
       }
   }
}
