using System;

namespace ForgetTraffic.ServiceUtils
{
    /**********************************************************************
        *
        *  Class Name      : ManageeIDs
        *  
        *  Description     : Managee Guid operations
        * --------------------------------------------------------------------
        *
        *  Date Created    : 30-03-2011
        *  Created By      : Vitor Viana 
        *  
        * --------------------------------------------------------------------
        * 
        *  Copyright © 2011 - ISEL,Projecto Final
        * --------------------------------------------------------------------
        *  Revision History Log
        * 
        *  Date   Author          Description
        *  _______ ______________ ___________________________________________
        *  xxxxxxx xxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        * 
        **********************************************************************/

    public class ManageeIDs
    {
        /// <summary>
        /// Parse the GUID to string whitout internal parameters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Guid GetGuidId()
        {
            Guid id = Guid.NewGuid();
            String ret = "";


            String guid = id.ToString();

            var sp = new[] {'-'};
            String[] trb = guid.Split(sp);

            foreach (String token in trb)
            {
                ret += token;
            }

            return id;
        }
    }
}