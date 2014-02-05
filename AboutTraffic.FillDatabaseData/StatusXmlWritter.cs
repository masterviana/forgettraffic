using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ForgetTraffic.DataModel;

namespace ForgetTraffic.FillDatabaseData
{
    /**********************************************************************
        *
        *  Class Name      : Templete class
        *  Description     : Class used for exporting like a template class
        * --------------------------------------------------------------------
        *
        *  Date Created    : 28-03-2011
        *  Created By      : Vitor Viana
        * --------------------------------------------------------------------
        * 
        *  Copyright © 2011 - ISEL,Projecto Final
        *  
        * --------------------------------------------------------------------
        *  Revision History Log
        * 
        *  Date   Author          Description
        *  _______ ______________ ___________________________________________
        *  xxxxxxx xxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        * 
        **********************************************************************/

    public class StatusXmlWritter : ITableOperation
    {
        public static StatusXmlWritter SINGLETON = new StatusXmlWritter();

        #region ITableOperation Members

        public void UpdateTableData()
        {
            throw new NotImplementedException();
        }

        public void DeleteTableData()
        {
            XElement element = XElement.Load("");

            List<mercas> _list = (from _item in element.Elements("item")
                                  select new mercas
                                             {
                                                 title = _item.Element("title").Value,
                                             }).ToList();
        }


        void ITableOperation.FillTableData()
        {
            throw new NotImplementedException();
        }

        #endregion

        public void FillTableData()
        {
            String path =
                @"E:\3. I.S.E.L\ISEL 2011\Projecto\ProjectosVS\ForgetTraffic\AboutTraffic.FillDatabaseData\XmlFiles\InitialFill\FillStatusData.xml";

            XElement element = XElement.Load(path);

            List<XElement> list = (from st in element.Elements("status")
                                   select st).ToList();

            int count = list.ToList().Count;

            tblSysState _status;

            using (var dbContext = new ForgetTrafficEntities())
            {
                foreach (XElement st in list)
                {
                    _status = new tblSysState
                                  {
                                      Id = ManageeIDs.GetGuidId(),
                                      Code = st.Element("code").Value,
                                      Description = st.Element("description").Value
                                  };

                    dbContext.tblSysState.AddObject(_status);
                    dbContext.SaveChanges();
                }
            }
        }

        #region Nested type: mercas

        public class mercas
        {
            public String title { get; set; }
        }

        #endregion
    }
}