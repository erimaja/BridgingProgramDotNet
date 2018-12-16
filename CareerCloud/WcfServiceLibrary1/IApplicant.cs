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
    interface IApplicant
    {
        //ApplicantEducation
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);
        [OperationContract]
        List <ApplicantEducationPoco> GetAllApplicantEducation();
        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string Id);
        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);
        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);

        //ApplicantJobApplication
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();
        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);
        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        //ApplicantProfile
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();
        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string Id);
        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);

        //ApplicantResume
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();
        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string Id);
        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);
        //ApplicantSkill
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantSkill();
        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string Id);
        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);
        //ApplicantWorkHistory
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();
        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);
        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);


    }
}
