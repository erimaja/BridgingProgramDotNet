using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using CareerCloud.Pocos;

namespace CareerCloud.WCF//WcfServiceLibrary1
{
    [ServiceContract]
    interface ISystem
    {
        //SystemCountryCode
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] items);
        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode();
        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string Id);
        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] items);
        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] items);
        //SystemLanguageCode
        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] items);
        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();
        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id);
        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items);
        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items);
    }
}
