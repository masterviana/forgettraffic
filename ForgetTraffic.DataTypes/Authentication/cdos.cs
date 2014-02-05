using System;
using System.Runtime.Serialization;

namespace ForgetTraffic.DataTypes.Authentication
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  cdo
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    /// <summary>
    /// Usado como tipo standand para retorno de serviços!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class ServiceOutput<T>
    {
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public T Value { get; set; }
        [DataMember]
        public bool Error { get; set; }
        [DataMember]
        public int StatusCode { get; set; }
    }
}