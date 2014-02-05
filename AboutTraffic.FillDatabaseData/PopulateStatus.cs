using System;
using System.Collections.Generic;
using System.Linq;
using ForgetTraffic.DAL.EntitiesManagers;
using ForgetTraffic.DataModel;

namespace ForgetTraffic.FillDatabaseData
{
    /**********************************************************************
        *
        *  Class Name      : PopulateStatus
        *  Description     : 
        * --------------------------------------------------------------------
        *  Date Created    : 16-04-2011
        *  Created By      : Fernando Vaz
         * --------------------------------------------------------------------
        * 
         *  Copyright © 2011 - ISEL,Projecto Final
        *  
         * --------------------------------------------------------------------
        *  Revision History Log
         *  Date   Author          Description
        *  _______ ______________ ___________________________________________
        *  xxxxxxx xxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        * 
        **********************************************************************/

    public class PopulateStatus : ITableOperation
    {
        public static PopulateStatus SINGLETON =
            new PopulateStatus();

        private PopulateStatus()
        {
        }

        #region ITableOperation Members

        public void FillTableData()
        {
            GeneralManager.Initialize();

            var Active = new tblSysState
                             {
                                 Id = ManageeIDs.GetGuidId(),
                                 Code = "A",
                                 Description = "Active"
                             };

            var DeActive = new tblSysState
                               {
                                   Id = ManageeIDs.GetGuidId(),
                                   Code = "X",
                                   Description = "Deactivated"
                               };

            var Blocked = new tblSysState
                              {
                                  Id = ManageeIDs.GetGuidId(),
                                  Code = "B",
                                  Description = "Blocked"
                              };
            var Updating = new tblSysState
                               {
                                   Id = ManageeIDs.GetGuidId(),
                                   Code = "U",
                                   Description = "Updating"
                               };

            StatusManager.AddStatus(Active);
            StatusManager.AddStatus(DeActive);
            StatusManager.AddStatus(Blocked);
            StatusManager.AddStatus(Updating);

            GeneralManager.Commit();

            GeneralManager.Dispose();
        }

        public void UpdateTableData()
        {
            throw new NotImplementedException();
        }

        public void DeleteTableData()
        {
            using (var db = new ForgetTrafficEntities())
            {
                List<tblSysState> query = (from tblSts in db.tblSysState
                                           select tblSts).ToList();

                for (int i = 0; i < query.Count; i++)
                {
                    db.tblSysState.DeleteObject(query[i]);
                }

                db.SaveChanges();
            }
        }

        #endregion
    }
}