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
    interface ICompany
    {
        //CompanyDescription
        [OperationContract]
        void AddCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        List<CompanyDescriptionPoco> GetAllCompanyDescription();
        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescription(string Id);
        [OperationContract]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyDescription(CompanyDescriptionPoco[] items);
        //CompanyJobDescription
        [OperationContract]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();
        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id);
        [OperationContract]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        //CompanyJobEducation
        [OperationContract]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        List<CompanyJobEducationPoco> GetAllCompanyJobEducation();
        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id);
        [OperationContract]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items);
        //CompanyJob
        [OperationContract]
        void AddCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        List<CompanyJobPoco> GetAllCompanyJob();
        [OperationContract]
        CompanyJobPoco GetSingleCompanyJob(string Id);
        [OperationContract]
        void RemoveCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        void UpdateCompanyJob(CompanyJobPoco[] items);
        //CompanyJobSkill
        [OperationContract]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        List<CompanyJobSkillPoco> GetAllCompanyJobSkill();
        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id);
        [OperationContract]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items);
        //CompanyLocation
        [OperationContract]
        void AddCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        List<CompanyLocationPoco> GetAllCompanyLocation();
        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocation(string Id);
        [OperationContract]
        void RemoveCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        void UpdateCompanyLocation(CompanyLocationPoco[] items);
        //CompanyProfile
        [OperationContract]
        void AddCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        List<CompanyProfilePoco> GetAllCompanyProfile();
        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfile(string Id);
        [OperationContract]
        void RemoveCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        void UpdateCompanyProfile(CompanyProfilePoco[] items);
    }
}
