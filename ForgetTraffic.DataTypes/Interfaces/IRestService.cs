using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using ForgetTraffic.DataTypes.Authentication;
using ForgetTraffic.DataTypes.RestTypes;
using ForgetTraffic.DataTypes.RestTypes.Admin;
using ForgetTraffic.DataTypes.RestTypes.Incidents;
using ForgetTraffic.DataTypes.RestTypes.Users;
using ForgetTraffic.DataTypes.Incident;

namespace ForgetTraffic.DataTypes.Interfaces
{
    [ServiceContract]
    public interface IRestService
    {
        #region User Operations

        [OperationContract(Name = EndPoints.AddUser)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.User)]
        ServiceOutput<ResponseUser> User(AddUser user);

        [OperationContract(Name = EndPoints.UpdateUser)]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.User)]
        ServiceOutput<ResponseUser> User(UpdateUser user);


        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<ResponseUser> User(String loginToken);


        #endregion

        #region Incident management

        
        [OperationContract(Name = EndPoints.AddIncident)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.Incidencia)]
        ServiceOutput<ForgetTraffic.DataTypes.Incident.Incident> Incident(AddIncident incident);

        [OperationContract(Name = EndPoints.UpdateIncident)]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.Incidencia)]
        ServiceOutput<String> Incident(VoteSubmit vote);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        ServiceOutput<IncidentReturnSet> Incident(String distrito, String concelho, String localidade, long lastVerifyDate);


        #endregion

        #region Administration management

        [OperationContract(Name = EndPoints.AdminManager)]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.Administracao)]
        ServiceOutput<String> User(UpdateAdministrator updateItens);


        [OperationContract(Name = EndPoints.ListItens)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.Administracao)]
        ServiceOutput<ListItensSet> User(FilterItens criteria);


        #endregion

        #region operations

        [OperationContract(Name = EndPoints.LogonToken)]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.LogOn)]
        ServiceOutput<UserInfo> LogOn(LoginInfo login);

        [OperationContract(Name = EndPoints.ResendPassword)]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = EndPoints.LogOn)]
        ServiceOutput<String> LogOn(ResendPassword infoResend);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        ServiceOutput<UserInfo> EmailConfirmation(String token);

        [OperationContract(Name = "Resend")]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "EmailConfirmation")]
        void EmailConfirmation(EmailOperations op);

        #endregion
    }
}
