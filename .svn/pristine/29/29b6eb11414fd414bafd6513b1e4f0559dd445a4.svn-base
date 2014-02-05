using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.Incident;
using ForgetTraffic.DataTypes.RestTypes.Incidents;
using ForgetTraffic.DataTypes.RestTypes.Users;

namespace ForgetTraffic.DataTypes.RestTypes
{
    /*
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *              Author       :  Vitor Viana
     *              Date         :  25-05-2011  
     *              Name         :  IForgetTraffic
     *              Description  :  Manage the User Entities
     * ----------------------------------------------------------------------------------------
     * ----------------------------------------------------------------------------------------
     *                      Revison List
     *--------------------------------------------------------------------------------------             
     * Author           |       Date                
     * 
     * 
     * */

    [ServiceContract]
    public interface IForgetTraffic
    {
        #region Administration Region

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        ServiceOutput<UserInfo> LogOn(String userName, String password);


        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<CdoUserProfile> AddUser(CdoUserProfile userProfile);


        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<CdoUserProfile> GetUserProfile(String loginToken);

       
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        ServiceOutput<UserInfo> EmailConfirmation(String token);


        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        String Geting();


        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        String ConcurrenyTest(String code, String oldCode);


        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<CdoUserProfile> UpdateUserProfile(CdoUserProfile userProfile);

        #endregion

        #region Traffic Ocurrence Manage

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceOutput<Incident.Incident> PutIncidentJson(Incident.Incident occur);



        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Xml)]
        void PutIncidentXml(Incident.Incident occur);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void PutingTest(Incident.Incident occur);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<IncidentReturnSet> GetIncidents(String distrito, String concelho, String localidade, long lastVerifyDate);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceOutput<String> VoteIncident(VoteSubmit vote);


        #endregion

        #region New Rest Operation

        //[OperationContract(Name = EndPoints.AddUser)]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.User)]
        //ServiceOutput<ResponseUser> User( AddUser user );

        //[OperationContract(Name = EndPoints.UpdateUser)]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.User)]
        //ServiceOutput<ResponseUser> User(UpdateUser user);

        //[OperationContract(Name = EndPoints.DeleteUser)]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.User)]
        //ServiceOutput<ResponseUser> User(DeleteUser user);

        //[OperationContract(Name = EndPoints.GetUser)]
        //[WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    ResponseFormat = WebMessageFormat.Json,
        //    RequestFormat = WebMessageFormat.Json)]
        //ServiceOutput<ResponseUser> User(String loginToken);


        #endregion 
    }
}