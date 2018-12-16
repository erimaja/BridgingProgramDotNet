using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CareerCloud.Pocos;

namespace CareerCloud.UnitTests.Assignment5
{
    [TestClass]
    public class Assignment5Marking
    {
        private SystemCountryCodePoco _systemCountry;
        private ApplicantEducationPoco _applicantEducation;
        private ApplicantProfilePoco _applicantProfile;
        private ApplicantJobApplicationPoco _applicantJobApplication;
        private CompanyJobPoco _companyJob;
        private CompanyProfilePoco _companyProfile;
        private CompanyDescriptionPoco _companyDescription;
        private SystemLanguageCodePoco _systemLangCode;
        private ApplicantResumePoco _applicantResume;
        private ApplicantSkillPoco _applicantSkills;
        private ApplicantWorkHistoryPoco _appliantWorkHistory;
        private CompanyJobEducationPoco _companyJobEducation;
        private CompanyJobSkillPoco _companyJobSkill;
        private CompanyJobDescriptionPoco _companyJobDescription;
        private CompanyLocationPoco _companyLocation;
        private SecurityLoginPoco _securityLogin;
        private SecurityLoginsLogPoco _securityLoginLog;
        private SecurityRolePoco _securityRole;
        private SecurityLoginsRolePoco _securityLoginRole;

        [TestInitialize]
        public void Init_Pocos()
        {
            SystemCountry_Init();
            CompanyProfile_Init();
            SystemLangCode_Init();
            CompanyDescription_Init();
            CompanyJob_Init();
            CompanyJobEducation_Init();
            CompanyJobSkill_Init();
            CompanyJobDescription_Init();
            CompanyLocation_Init();
            SecurityLogin_Init();
            ApplicantProfile_Init();
            SecurityLoginLog_Init();
            SecurityRole_Init();
            SecurityLoginRole_Init();
            ApplicantEducation_Init();
            ApplicantResume_Init();
            ApplicantSkills_Init();
            AappliantWorkHistory_Init();
            ApplicantJobApplication_Init();
        }

        #region PocoInitialization
        private void ApplicantJobApplication_Init()
        {
            _applicantJobApplication = new ApplicantJobApplicationPoco()
            {
                Id = Guid.NewGuid(),
                ApplicationDate = Faker.Date.Recent(),
                Applicant = _applicantProfile.Id,
                Job = _companyJob.Id
            };
        }

        private void AappliantWorkHistory_Init()
        {
            _appliantWorkHistory = new ApplicantWorkHistoryPoco()
            {
                Id = Guid.NewGuid(),
                Applicant = _applicantProfile.Id,
                CompanyName = Truncate(Faker.Lorem.Sentence(), 150),
                CountryCode = _systemCountry.Code,
                EndMonth = 12,
                EndYear = 1999,
                JobDescription = Truncate(Faker.Lorem.Sentence(), 500),
                JobTitle = Truncate(Faker.Lorem.Sentence(), 50),
                Location = Faker.Address.StreetName(),
                StartMonth = 1,
                StartYear = 1999
            };
        }

        private void ApplicantSkills_Init()
        {
            _applicantSkills = new ApplicantSkillPoco()
            {
                Applicant = _applicantProfile.Id,
                Id = Guid.NewGuid(),
                EndMonth = 12,
                EndYear = 1999,
                Skill = Truncate(Faker.Lorem.Sentence(), 100),
                SkillLevel = Truncate(Faker.Lorem.Sentence(), 10),
                StartMonth = 1,
                StartYear = 1999
            };
        }

        private void ApplicantResume_Init()
        {
            _applicantResume = new ApplicantResumePoco()
            {
                Applicant = _applicantProfile.Id,
                Id = Guid.NewGuid(),
                Resume = Faker.Lorem.Paragraph(),
                LastUpdated = Faker.Date.Recent()
            };
        }

        private void ApplicantEducation_Init()
        {
            _applicantEducation = new ApplicantEducationPoco()
            {
                Id = Guid.NewGuid(),
                Applicant = _applicantProfile.Id,
                Major = Faker.Education.Major(),
                CertificateDiploma = Faker.Education.Major(),
                StartDate = Faker.Date.Past(3),
                CompletionDate = Faker.Date.Forward(1),
                CompletionPercent = (byte)Faker.Number.RandomNumber(1)
            };
        }

        private void SecurityLoginRole_Init()
        {
            _securityLoginRole = new SecurityLoginsRolePoco()
            {
                Id = Guid.NewGuid(),
                Login = _securityLogin.Id,
                Role = _securityRole.Id
            };
        }

        private void SecurityRole_Init()
        {
            _securityRole = new SecurityRolePoco()
            {
                Id = Guid.NewGuid(),
                IsInactive = true,
                Role = Truncate(Faker.Company.Industry(), 50)

            };
        }

        private void SecurityLoginLog_Init()
        {
            _securityLoginLog = new SecurityLoginsLogPoco()
            {
                Id = Guid.NewGuid(),
                IsSuccesful = true,
                Login = _securityLogin.Id,
                LogonDate = Faker.Date.PastWithTime(),
                SourceIP = Faker.Internet.IPv4().PadRight(15)
            };
        }

        private void ApplicantProfile_Init()
        {
            _applicantProfile = new ApplicantProfilePoco
            {
                Id = Guid.NewGuid(),
                Login = _securityLogin.Id,
                City = Faker.Address.CityPrefix(),
                Country = _systemCountry.Code,
                Currency = "CAN".PadRight(10),
                CurrentRate = 71.25M,
                CurrentSalary = 67500,
                Province = Truncate(Faker.Address.Province(), 10).PadRight(10),
                Street = Truncate(Faker.Address.StreetName(), 100),
                PostalCode = Truncate(Faker.Address.CanadianZipCode(), 20).PadRight(20)
            };
        }

        private void SecurityLogin_Init()
        {
            _securityLogin = new SecurityLoginPoco()
            {
                Login = Faker.User.Email(),
                AgreementAccepted = Faker.Date.PastWithTime(),
                Created = Faker.Date.PastWithTime(),
                EmailAddress = Faker.User.Email(),
                ForceChangePassword = false,
                FullName = Faker.Name.FullName(),
                Id = Guid.NewGuid(),
                IsInactive = false,
                IsLocked = false,
                Password = "SoMePassWord#&@",
                PasswordUpdate = Faker.Date.Forward(),
                PhoneNumber = "555-416-9889",
                PrefferredLanguage = "EN".PadRight(10)
            };
        }

        private void CompanyLocation_Init()
        {
            _companyLocation = new CompanyLocationPoco()
            {
                Id = Guid.NewGuid(),
                City = Faker.Address.CityPrefix(),
                Company = _companyProfile.Id,
                CountryCode = _systemCountry.Code,
                Province = Faker.Address.ProvinceAbbreviation(),
                Street = Faker.Address.StreetName(),
                PostalCode = Faker.Address.CanadianZipCode()
            };
        }

        private void CompanyJobDescription_Init()
        {
            _companyJobDescription = new CompanyJobDescriptionPoco()
            {
                Id = Guid.NewGuid(),
                Job = _companyJob.Id,
                JobDescriptions = Truncate(Faker.Lorem.Paragraph(), 999),
                JobName = Truncate(Faker.Lorem.Sentence(), 99)
            };
        }

        private void CompanyJobSkill_Init()
        {
            _companyJobSkill = new CompanyJobSkillPoco()
            {
                Id = Guid.NewGuid(),
                Importance = 2,
                Job = _companyJob.Id,
                Skill = Truncate(Faker.Lorem.Sentence(), 100),
                SkillLevel = String.Concat(Faker.Lorem.Letters(10))
            };
        }

        private void CompanyJobEducation_Init()
        {
            _companyJobEducation = new CompanyJobEducationPoco()
            {
                Id = Guid.NewGuid(),
                Importance = 2,
                Job = _companyJob.Id,
                Major = Truncate(Faker.Lorem.Sentence(), 100)
            };
        }

        private void CompanyJob_Init()
        {
            _companyJob = new CompanyJobPoco()
            {
                Id = Guid.NewGuid(),
                Company = _companyProfile.Id,
                IsCompanyHidden = false,
                IsInactive = false,
                ProfileCreated = Faker.Date.Past()
            };
        }

        private void CompanyDescription_Init()
        {
            _companyDescription = new CompanyDescriptionPoco()
            {
                Id = Guid.NewGuid(),
                CompanyDescription = Faker.Company.CatchPhrase(),
                CompanyName = Faker.Company.CatchPhrasePos(),
                LanguageId = _systemLangCode.LanguageID,
                Company = _companyProfile.Id
            };
        }

        private void SystemLangCode_Init()
        {
            _systemLangCode = new SystemLanguageCodePoco()
            {
                LanguageID = String.Concat(Faker.Lorem.Letters(10)),
                NativeName = Truncate(Faker.Lorem.Sentence(), 50),
                Name = Truncate(Faker.Lorem.Sentence(), 50)
            };
        }

        private void CompanyProfile_Init()
        {
            _companyProfile = new CompanyProfilePoco()
            {
                CompanyWebsite = "www.humber.ca",
                ContactName = Faker.Name.FullName(),
                ContactPhone = "416-555-8799",
                RegistrationDate = Faker.Date.Past(),
                Id = Guid.NewGuid(),
                CompanyLogo = new byte[10]
            };
        }

        private void SystemCountry_Init()
        {
            _systemCountry = new SystemCountryCodePoco
            {
                Code = String.Concat(Faker.Lorem.Letters(10)),
                Name = Truncate(Faker.Name.FullName(), 50)
            };
        }

        #endregion PocoInitialization

        [TestMethod]
        public void Assignment5_DeepDive_CRUD_Test()
        {
            SystemCountryCodeAdd();
            SystemCountryCodeCheck();
            SystemCountryCodeUpdate();
            SystemCountryCodeCheck();

            SystemLanguageCodeAdd();
            SystemLanguageCodeCheck();
            SystemLanguageCodeUpdate();
            SystemLanguageCodeCheck();

            CompanyProfileAdd();
            CompanyProfileCheck();
            CompanyProfileUpdate();
            CompanyProfileCheck();

            CompanyDescriptionAdd();
            CompanyDescriptionCheck();
            CompanyDescriptionUpdate();
            CompanyDescriptionCheck();

            CompanyJobAdd();
            CompanyJobCheck();
            CompanyJobUpdate();
            CompanyJobCheck();

            CompanyJobDescriptionAdd();
            CompanyJobDescriptionCheck();
            CompanyJobDescriptionUpdate();
            CompanyJobDescriptionCheck();

            CompanyLocationAdd();
            CompanyLocationCheck();
            CompanyLocationUpdate();
            CompanyLocationCheck();

            CompanyJobEducationAdd();
            CompanyJobEducationCheck();
            CompanyJobEducationUpdate();
            CompanyJobEducationCheck();

            CompanyJobSkillAdd();
            CompanyJobSkillCheck();
            CompanyJobSkillUpdate();
            CompanyJobSkillCheck();

            SecurityLoginAdd();
            SecurityLoginCheck();
            SecurityLoginUpdate();
            SecurityLoginCheck();

            SecurityLoginLogAdd();
            SecurityLoginLogCheck();
            SecurityLoginLogUpdate();
            SecurityLoginLogCheck();

            SecurityRoleAdd();
            SecurityRoleCheck();
            SecurityRoleUpdate();
            SecurityRoleCheck();

            SecurityLoginRoleAdd();
            SecurityLoginRoleCheck();

            ApplicantProfileAdd();
            ApplicantProfileCheck();
            ApplicantProfileUpdate();
            ApplicantProfileCheck();

            ApplicantEducationAdd();
            ApplicantEducationCheck();
            ApplicantEducationUpdate();
            ApplicantEducationCheck();

            ApplicantJobApplicationAdd();
            ApplicantJobApplicationCheck();
            ApplicantJobApplicationUpdate();
            ApplicantJobApplicationCheck();

            ApplicantResumeAdd();
            ApplicantResumeCheck();
            ApplicantResumeUpdate();
            ApplicantResumeCheck();

            ApplicantSkillAdd();
            ApplicantSkillCheck();
            ApplicantSkillUpdate();
            ApplicantSkillCheck();

            ApplicantWorkHistoryAdd();
            ApplicantWorkHistoryCheck();
            ApplicantWorkHistoryUpdate();
            ApplicantWorkHistoryCheck();

            #region Cleanup
            ApplicantWorkHistoryRemove();
            ApplicantSkillRemove();
            ApplicantResumeRemove();

            ApplicantJobApplicationRemove();
            ApplicantEducationRemove();
            ApplicantProfileRemove();

            SecurityLoginRoleRemove();
            SecurityRoleRemove();
            SecurityLoginLogRemove();
            SecurityLoginRemove();

            CompanyJobSkillRemove();
            CompanyJobEducationRemove();
            CompanyLocationRemove();
            CompanyJobDescRemove();
            CompanyJobRemove();
            CompanyDescriptionRemove();
            CompanyProfileRemove();

            SystemLanguageCodeRemove();
            SystemCountryCodeRemove();
            #endregion Cleanup
        }

        #region AddImplementation
        private void ApplicantWorkHistoryAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantWorkHistory(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
            }
        }

        private void ApplicantSkillAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantSkill(new ApplicantSkillPoco[] { _applicantSkills });
            }
        }

        private void ApplicantResumeAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantResume(new ApplicantResumePoco[] { _applicantResume });
            }
        }

        private void ApplicantJobApplicationAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantJobApplication(new ApplicantJobApplicationPoco[] { _applicantJobApplication });
            }
        }

        private void ApplicantEducationAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantEducation(new ApplicantEducationPoco[] { _applicantEducation });
            }
        }

        private void ApplicantProfileAdd()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.AddApplicantProfile(new ApplicantProfilePoco[] { _applicantProfile });
            }

        }

        private void SecurityLoginRoleAdd()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.AddSecurityLoginsRole(new SecurityLoginsRolePoco[] { _securityLoginRole });
            }
        }

        private void SecurityRoleAdd()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.AddSecurityRole(new SecurityRolePoco[] { _securityRole });
            }

        }

        private void SecurityLoginLogAdd()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.AddSecurityLoginsLog(new SecurityLoginsLogPoco[] { _securityLoginLog });
            }

        }

        private void SecurityLoginAdd()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.AddSecurityLogin(new SecurityLoginPoco[] { _securityLogin });
            }

        }

        private void CompanyJobSkillAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyJobSkill(new CompanyJobSkillPoco[] { _companyJobSkill });
            }
        }

        private void CompanyJobEducationAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyJobEducation(new CompanyJobEducationPoco[] { _companyJobEducation });
            }
        }

        private void CompanyLocationAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyLocation(new CompanyLocationPoco[] { _companyLocation });
            }

        }

        private void CompanyJobDescriptionAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyJobDescription(new CompanyJobDescriptionPoco[] { _companyJobDescription });
            }
        }

        private void CompanyJobAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyJob(new CompanyJobPoco[] { _companyJob });
            }

        }

        private void CompanyDescriptionAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyDescription(new CompanyDescriptionPoco[] { _companyDescription });
            }
        }

        private void CompanyProfileAdd()
        {
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.AddCompanyProfile(new CompanyProfilePoco[] { _companyProfile });
            }
        }

        private void SystemLanguageCodeAdd()
        {
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.AddSystemLanguageCode(new SystemLanguageCodePoco[] { _systemLangCode });
            }
        }

        private void SystemCountryCodeAdd()
        {
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.AddSystemCountryCode(new SystemCountryCodePoco[] { _systemCountry });
            }
        }


        #endregion AddImplementation

        #region CheckImplementation
        private void ApplicantSkillCheck()
        {
            ApplicantSkillPoco applicantSkillPoco = GetApplicantSkill(_applicantSkills.Id.ToString());

            Assert.IsNotNull(applicantSkillPoco);
            Assert.AreEqual(_applicantSkills.Id, applicantSkillPoco.Id);
            Assert.AreEqual(_applicantSkills.Applicant, applicantSkillPoco.Applicant);
            Assert.AreEqual(_applicantSkills.Skill, applicantSkillPoco.Skill);
            Assert.AreEqual(_applicantSkills.SkillLevel, applicantSkillPoco.SkillLevel);
            Assert.AreEqual(_applicantSkills.StartMonth, applicantSkillPoco.StartMonth);
            Assert.AreEqual(_applicantSkills.StartYear, applicantSkillPoco.StartYear);
            Assert.AreEqual(_applicantSkills.EndMonth, applicantSkillPoco.EndMonth);
            Assert.AreEqual(_applicantSkills.EndYear, applicantSkillPoco.EndYear);
        }

        private void ApplicantResumeCheck()
        {
            ApplicantResumePoco applicantResumePoco = GetApplicantResume(_applicantResume.Id.ToString());

            Assert.IsNotNull(applicantResumePoco);
            Assert.AreEqual(_applicantResume.Id, applicantResumePoco.Id);
            Assert.AreEqual(_applicantResume.Applicant, applicantResumePoco.Applicant);
            Assert.AreEqual(_applicantResume.Resume, applicantResumePoco.Resume);
            Assert.AreEqual(_applicantResume.LastUpdated.Value.Date, applicantResumePoco.LastUpdated.Value.Date);
        }

        private void ApplicantJobApplicationCheck()
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco = GetApplicantJobApplication(_applicantJobApplication.Id.ToString());

            Assert.IsNotNull(applicantJobApplicationPoco);
            Assert.AreEqual(_applicantJobApplication.Id, applicantJobApplicationPoco.Id);
            Assert.AreEqual(_applicantJobApplication.Applicant, applicantJobApplicationPoco.Applicant);
            Assert.AreEqual(_applicantJobApplication.Job, applicantJobApplicationPoco.Job);
            Assert.AreEqual(_applicantJobApplication.ApplicationDate.Date, applicantJobApplicationPoco.ApplicationDate.Date);
        }


        private void ApplicantEducationCheck()
        {
            ApplicantEducationPoco applicantEducationPoco = GetApplicantEducation(_applicantEducation.Id.ToString());

            Assert.IsNotNull(applicantEducationPoco);
            Assert.AreEqual(_applicantEducation.Id, applicantEducationPoco.Id);
            Assert.AreEqual(_applicantEducation.Applicant, applicantEducationPoco.Applicant);
            Assert.AreEqual(_applicantEducation.Major, applicantEducationPoco.Major);
            Assert.AreEqual(_applicantEducation.CertificateDiploma, applicantEducationPoco.CertificateDiploma);
            Assert.AreEqual(_applicantEducation.StartDate.Value.Date, applicantEducationPoco.StartDate.Value.Date);
            Assert.AreEqual(_applicantEducation.CompletionDate.Value.Date, applicantEducationPoco.CompletionDate.Value.Date);
            Assert.AreEqual(_applicantEducation.CompletionPercent, applicantEducationPoco.CompletionPercent);
        }

        private void ApplicantProfileCheck()
        {
            ApplicantProfilePoco applicantProfilePoco = GetApplicantProfile(_applicantProfile.Id.ToString());

            Assert.IsNotNull(applicantProfilePoco);
            Assert.AreEqual(_applicantProfile.Id, applicantProfilePoco.Id);
            Assert.AreEqual(_applicantProfile.Login, applicantProfilePoco.Login);
            Assert.AreEqual(_applicantProfile.CurrentSalary, applicantProfilePoco.CurrentSalary);
            Assert.AreEqual(_applicantProfile.CurrentRate, applicantProfilePoco.CurrentRate);
            Assert.AreEqual(_applicantProfile.Currency, applicantProfilePoco.Currency);
            Assert.AreEqual(_applicantProfile.Country, applicantProfilePoco.Country);
            Assert.AreEqual(_applicantProfile.Province, applicantProfilePoco.Province);
            Assert.AreEqual(_applicantProfile.Street, applicantProfilePoco.Street);
            Assert.AreEqual(_applicantProfile.City, applicantProfilePoco.City);
            Assert.AreEqual(_applicantProfile.PostalCode, applicantProfilePoco.PostalCode);
        }

        private void SecurityLoginRoleCheck()
        {
            SecurityLoginsRolePoco securityLoginsRolePoco = GetSecurityLoginsRole(_securityLoginRole.Id.ToString());

            Assert.IsNotNull(securityLoginsRolePoco);
            Assert.AreEqual(_securityLoginRole.Id, securityLoginsRolePoco.Id);
            Assert.AreEqual(_securityLoginRole.Login, securityLoginsRolePoco.Login);
            Assert.AreEqual(_securityLoginRole.Role, securityLoginsRolePoco.Role);
        }

        private void SecurityRoleCheck()
        {
            SecurityRolePoco securityRolePoco = GetSecurityRole(_securityRole.Id.ToString());

            Assert.IsNotNull(securityRolePoco);
            Assert.AreEqual(_securityRole.Id, securityRolePoco.Id);
            Assert.AreEqual(_securityRole.Role, securityRolePoco.Role);
            Assert.AreEqual(_securityRole.IsInactive, securityRolePoco.IsInactive);
        }

        private void SecurityLoginLogCheck()
        {
            SecurityLoginsLogPoco securityLoginsLogPoco = GetSecurityLoginsLog(_securityLoginLog.Id.ToString());

            Assert.IsNotNull(securityLoginsLogPoco);
            Assert.AreEqual(_securityLoginLog.Id, securityLoginsLogPoco.Id);
            Assert.AreEqual(_securityLoginLog.Login, securityLoginsLogPoco.Login);
            Assert.AreEqual(_securityLoginLog.SourceIP, securityLoginsLogPoco.SourceIP);
            Assert.AreEqual(_securityLoginLog.LogonDate.Date, securityLoginsLogPoco.LogonDate.Date);
        }

        private void SecurityLoginCheck()
        {
            SecurityLoginPoco securityLoginPoco = GetSecurityLogin(_securityLogin.Id.ToString());

            // Fields changed by SecurityLoginLogic commented out
            Assert.IsNotNull(securityLoginPoco);
            Assert.AreEqual(_securityLogin.Id, securityLoginPoco.Id);
            Assert.AreEqual(_securityLogin.Login, securityLoginPoco.Login);
            // ########## Not checked because the logic layer overwrites these properties
            //Assert.AreEqual(_securityLogin.Password, securityLoginPoco.Password);
            //Assert.AreEqual(_securityLogin.Created.Date, securityLoginPoco.Created.Date);
            //Assert.AreEqual(_securityLogin.PasswordUpdate, securityLoginPoco.PasswordUpdate);
            Assert.AreEqual(_securityLogin.AgreementAccepted.Value.Date, securityLoginPoco.AgreementAccepted.Value.Date);
            // ########## Not checked because the logic layer overwrites these properties
            //Assert.AreEqual(_securityLogin.IsLocked, securityLoginPoco.IsLocked);
            //Assert.AreEqual(_securityLogin.IsInactive, securityLoginPoco.IsInactive);
            Assert.AreEqual(_securityLogin.EmailAddress, securityLoginPoco.EmailAddress);
            Assert.AreEqual(_securityLogin.PhoneNumber, securityLoginPoco.PhoneNumber);
            Assert.AreEqual(_securityLogin.FullName, securityLoginPoco.FullName);
            // ########## Not checked because the logic layer overwrites these properties
            //Assert.AreEqual(_securityLogin.ForceChangePassword, securityLoginPoco.ForceChangePassword);
            Assert.AreEqual(_securityLogin.PrefferredLanguage, securityLoginPoco.PrefferredLanguage);
        }

        private void CompanyJobSkillCheck()
        {
            CompanyJobSkillPoco companyJobSkillPoco = GetCompanyJobSkill(_companyJobSkill.Id.ToString());

            Assert.IsNotNull(companyJobSkillPoco);
            Assert.AreEqual(_companyJobSkill.Id, companyJobSkillPoco.Id);
            Assert.AreEqual(_companyJobSkill.Job, companyJobSkillPoco.Job);
            Assert.AreEqual(_companyJobSkill.Skill, companyJobSkillPoco.Skill);
            Assert.AreEqual(_companyJobSkill.SkillLevel, companyJobSkillPoco.SkillLevel);
            Assert.AreEqual(_companyJobSkill.Importance, companyJobSkillPoco.Importance);
        }


        private void CompanyJobEducationCheck()
        {
            CompanyJobEducationPoco companyJobEducationPoco = GetCompanyJobEducation(_companyJobEducation.Id.ToString());

            Assert.IsNotNull(companyJobEducationPoco);
            Assert.AreEqual(_companyJobEducation.Id, companyJobEducationPoco.Id);
            Assert.AreEqual(_companyJobEducation.Job, companyJobEducationPoco.Job);
            Assert.AreEqual(_companyJobEducation.Major, companyJobEducationPoco.Major);
            Assert.AreEqual(_companyJobEducation.Importance, companyJobEducationPoco.Importance);
        }

        private void CompanyLocationCheck()
        {
            CompanyLocationPoco companyLocationPoco = GetCompanyLocation(_companyLocation.Id.ToString());

            Assert.IsNotNull(companyLocationPoco);
            Assert.AreEqual(_companyLocation.Id, companyLocationPoco.Id);
            Assert.AreEqual(_companyLocation.Company, companyLocationPoco.Company);
            Assert.AreEqual(_companyLocation.CountryCode.PadRight(10), companyLocationPoco.CountryCode);
            Assert.AreEqual(_companyLocation.Province.PadRight(10), companyLocationPoco.Province);
            Assert.AreEqual(_companyLocation.Street, companyLocationPoco.Street);
            Assert.AreEqual(_companyLocation.City, companyLocationPoco.City);
            Assert.AreEqual(_companyLocation.PostalCode.PadRight(20), companyLocationPoco.PostalCode);
        }

        private void CompanyJobDescriptionCheck()
        {
            CompanyJobDescriptionPoco companyJobDescPoco = GetCompanyJobDescription(_companyJobDescription.Id.ToString());

            Assert.IsNotNull(companyJobDescPoco);
            Assert.AreEqual(_companyJobDescription.Id, companyJobDescPoco.Id);
            Assert.AreEqual(_companyJobDescription.Job, companyJobDescPoco.Job);
            Assert.AreEqual(_companyJobDescription.JobDescriptions, companyJobDescPoco.JobDescriptions);
            Assert.AreEqual(_companyJobDescription.JobName, companyJobDescPoco.JobName);
        }

        private void CompanyJobCheck()
        {
            CompanyJobPoco companyJobPoco = GetCompanyJob(_companyJob.Id.ToString());

            Assert.IsNotNull(companyJobPoco);
            Assert.AreEqual(_companyJob.Id, companyJobPoco.Id);
            Assert.AreEqual(_companyJob.Company, companyJobPoco.Company);
            Assert.AreEqual(_companyJob.ProfileCreated, companyJobPoco.ProfileCreated);
            Assert.AreEqual(_companyJob.IsInactive, companyJobPoco.IsInactive);
            Assert.AreEqual(_companyJob.IsCompanyHidden, companyJobPoco.IsCompanyHidden);
        }

        private void CompanyDescriptionCheck()
        {
            CompanyDescriptionPoco companyDescriptionPoco = GetCompanyDescription(_companyDescription.Id.ToString());

            Assert.IsNotNull(companyDescriptionPoco);
            Assert.AreEqual(_companyDescription.Id, companyDescriptionPoco.Id);
            Assert.AreEqual(_companyDescription.CompanyDescription, companyDescriptionPoco.CompanyDescription);
            Assert.AreEqual(_companyDescription.CompanyName, companyDescriptionPoco.CompanyName);
            Assert.AreEqual(_companyDescription.LanguageId, companyDescriptionPoco.LanguageId);
            Assert.AreEqual(_companyDescription.Company, companyDescriptionPoco.Company);
        }


        public void CompanyProfileCheck()
        {
            CompanyProfilePoco companyProfilePoco = GetCompanyProfile(_companyProfile.Id.ToString());

            Assert.IsNotNull(companyProfilePoco);
            Assert.AreEqual(_companyProfile.CompanyWebsite, companyProfilePoco.CompanyWebsite);
            Assert.AreEqual(_companyProfile.ContactName, companyProfilePoco.ContactName);
            Assert.AreEqual(_companyProfile.ContactPhone, companyProfilePoco.ContactPhone);
            Assert.AreEqual(_companyProfile.RegistrationDate, companyProfilePoco.RegistrationDate);
            Assert.AreEqual(_companyProfile.Id, companyProfilePoco.Id);
        }

        private void ApplicantWorkHistoryCheck()
        {
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco = GetApplicantWorkHistory(_appliantWorkHistory.Id.ToString());

            Assert.IsNotNull(applicantWorkHistoryPoco);
            Assert.AreEqual(_appliantWorkHistory.Id, applicantWorkHistoryPoco.Id);
            Assert.AreEqual(_appliantWorkHistory.Applicant, applicantWorkHistoryPoco.Applicant);
            Assert.AreEqual(_appliantWorkHistory.CompanyName, applicantWorkHistoryPoco.CompanyName);
            Assert.AreEqual(_appliantWorkHistory.CountryCode, applicantWorkHistoryPoco.CountryCode);
            Assert.AreEqual(_appliantWorkHistory.Location, applicantWorkHistoryPoco.Location);
            Assert.AreEqual(_appliantWorkHistory.JobTitle, applicantWorkHistoryPoco.JobTitle);
            Assert.AreEqual(_appliantWorkHistory.JobDescription, applicantWorkHistoryPoco.JobDescription);
            Assert.AreEqual(_appliantWorkHistory.StartMonth, applicantWorkHistoryPoco.StartMonth);
            Assert.AreEqual(_appliantWorkHistory.StartYear, applicantWorkHistoryPoco.StartYear);
            Assert.AreEqual(_appliantWorkHistory.EndMonth, applicantWorkHistoryPoco.EndMonth);
            Assert.AreEqual(_appliantWorkHistory.EndYear, applicantWorkHistoryPoco.EndYear);
        }

        public void SystemCountryCodeCheck()
        {
            SystemCountryCodePoco systemCountryCodePoco = GetSystemCountryCode(_systemCountry.Code);

            Assert.IsNotNull(systemCountryCodePoco);
            Assert.AreEqual(_systemCountry.Code, systemCountryCodePoco.Code);
            Assert.AreEqual(_systemCountry.Name, systemCountryCodePoco.Name);
        }

        private void SystemLanguageCodeCheck()
        {
            SystemLanguageCodePoco systemLanguageCodePoco = GetSystemLanguageCode(_systemLangCode.LanguageID);

            Assert.IsNotNull(systemLanguageCodePoco);
            Assert.AreEqual(systemLanguageCodePoco.LanguageID, _systemLangCode.LanguageID);
            Assert.AreEqual(systemLanguageCodePoco.NativeName, _systemLangCode.NativeName);
            Assert.AreEqual(systemLanguageCodePoco.Name, _systemLangCode.Name);
        }


        #endregion CheckImplementation

        #region UpdateImplementation
        public void CompanyProfileUpdate()
        {
            _companyProfile.TimeStamp = GetCompanyProfile(_companyProfile.Id.ToString()).TimeStamp;

            _companyProfile.CompanyWebsite = "www.humber.com";
            _companyProfile.ContactName = Faker.Name.FullName();
            _companyProfile.ContactPhone = "999-555-8799";
            _companyProfile.RegistrationDate = Faker.Date.Past();
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyProfile(new CompanyProfilePoco[] { _companyProfile });
            }
        }

        public void CompanyDescriptionUpdate()
        {
            _companyDescription.TimeStamp = GetCompanyDescription(_companyDescription.Id.ToString()).TimeStamp;

            _companyDescription.CompanyDescription = Faker.Company.CatchPhrase();
            _companyDescription.CompanyName = Faker.Company.CatchPhrasePos();
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyDescription(new CompanyDescriptionPoco[] { _companyDescription });
            }
        }

        public void SecurityRoleUpdate()
        {
            _securityRole.IsInactive = true;
            _securityRole.Role = Truncate(Faker.Company.Industry(), 50);
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.UpdateSecurityRole(new SecurityRolePoco[] { _securityRole });
            }
        }

        public void CompanyJobUpdate()
        {
            _companyJob.TimeStamp = GetCompanyJob(_companyJob.Id.ToString()).TimeStamp;

            _companyJob.IsCompanyHidden = true;
            _companyJob.IsInactive = true;
            _companyJob.ProfileCreated = Faker.Date.Past();
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyJob(new CompanyJobPoco[] { _companyJob });
            }

        }

        public void CompanyJobDescriptionUpdate()
        {
            _companyJobDescription.TimeStamp = GetCompanyJobDescription(_companyJobDescription.Id.ToString()).TimeStamp;

            _companyJobDescription.JobDescriptions = Truncate(Faker.Lorem.Paragraph(), 999);
            _companyJobDescription.JobName = Truncate(Faker.Lorem.Sentence(), 99);
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyJobDescription(new CompanyJobDescriptionPoco[] { _companyJobDescription });
            }
        }

        public void CompanyLocationUpdate()
        {
            _companyLocation.TimeStamp = GetCompanyLocation(_companyLocation.Id.ToString()).TimeStamp;

            _companyLocation.City = Faker.Address.CityPrefix();
            _companyLocation.CountryCode = _systemCountry.Code;
            _companyLocation.Province = Faker.Address.ProvinceAbbreviation();
            _companyLocation.Street = Faker.Address.StreetName();
            _companyLocation.PostalCode = Faker.Address.CanadianZipCode();
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyLocation(new CompanyLocationPoco[] { _companyLocation });
            }
        }

        public void CompanyJobEducationUpdate()
        {
            _companyJobEducation.TimeStamp = GetCompanyJobEducation(_companyJobEducation.Id.ToString()).TimeStamp;

            _companyJobEducation.Importance = 1;
            _companyJobEducation.Major = Truncate(Faker.Lorem.Sentence(), 100);
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyJobEducation(new CompanyJobEducationPoco[] { _companyJobEducation });
            }
        }

        public void CompanyJobSkillUpdate()
        {
            _companyJobSkill.TimeStamp = GetCompanyJobSkill(_companyJobSkill.Id.ToString()).TimeStamp;

            _companyJobSkill.Importance = 1;
            _companyJobSkill.Skill = Truncate(Faker.Lorem.Sentence(), 100);
            _companyJobSkill.SkillLevel = String.Concat(Faker.Lorem.Letters(10));
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.UpdateCompanyJobSkill(new CompanyJobSkillPoco[] { _companyJobSkill });
            }
        }

        public void SecurityLoginUpdate()
        {
            _securityLogin.TimeStamp = GetSecurityLogin(_securityLogin.Id.ToString()).TimeStamp;

            _securityLogin.Login = Faker.User.Email();
            _securityLogin.AgreementAccepted = Faker.Date.PastWithTime();
            _securityLogin.Created = Faker.Date.PastWithTime();
            _securityLogin.EmailAddress = Faker.User.Email();
            _securityLogin.ForceChangePassword = true;
            _securityLogin.FullName = Faker.Name.FullName();
            _securityLogin.IsInactive = true;
            _securityLogin.IsLocked = true;
            _securityLogin.Password = "SoMePassWord@&@";
            _securityLogin.PasswordUpdate = Faker.Date.Forward();
            _securityLogin.PhoneNumber = "416-416-9889";
            _securityLogin.PrefferredLanguage = "FR".PadRight(10);
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.UpdateSecurityLogin(new SecurityLoginPoco[] { _securityLogin });
            }
        }

        public void SecurityLoginLogUpdate()
        {
            _securityLoginLog.IsSuccesful = false;
            _securityLoginLog.LogonDate = Faker.Date.PastWithTime();
            _securityLoginLog.SourceIP = Faker.Internet.IPv4().PadRight(15);
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.UpdateSecurityLoginsLog(new SecurityLoginsLogPoco[] { _securityLoginLog });
            }
        }

        public void ApplicantProfileUpdate()
        {
            _applicantProfile.TimeStamp = GetApplicantProfile(_applicantProfile.Id.ToString()).TimeStamp;

            _applicantProfile.City = Faker.Address.CityPrefix();
            _applicantProfile.Currency = "US".PadRight(10);
            _applicantProfile.CurrentRate = 61.25M;
            _applicantProfile.CurrentSalary = 77500;
            _applicantProfile.Province = Truncate(Faker.Address.Province(), 10).PadRight(10);
            _applicantProfile.Street = Truncate(Faker.Address.StreetName(), 100);
            _applicantProfile.PostalCode = Truncate(Faker.Address.CanadianZipCode(), 20).PadRight(20);
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantProfile(new ApplicantProfilePoco[] { _applicantProfile });
            }
        }

        public void ApplicantEducationUpdate()
        {
            _applicantEducation.TimeStamp = GetApplicantEducation(_applicantEducation.Id.ToString()).TimeStamp;

            _applicantEducation.Major = Faker.Education.Major();
            _applicantEducation.CertificateDiploma = Faker.Education.Major();
            _applicantEducation.StartDate = Faker.Date.Past(3);
            _applicantEducation.CompletionDate = Faker.Date.Forward(1);
            _applicantEducation.CompletionPercent = (byte)Faker.Number.RandomNumber(1);
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantEducation(new ApplicantEducationPoco[] { _applicantEducation });
            }

        }
        public void ApplicantJobApplicationUpdate()
        {
            _applicantJobApplication.TimeStamp = GetApplicantJobApplication(_applicantJobApplication.Id.ToString()).TimeStamp;

            _applicantJobApplication.ApplicationDate = Faker.Date.Recent();
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantJobApplication(new ApplicantJobApplicationPoco[] { _applicantJobApplication });
            }
        }

        public void ApplicantResumeUpdate()
        {
            _applicantResume.Resume = Faker.Lorem.Paragraph();
            _applicantResume.LastUpdated = Faker.Date.Recent();
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantResume(new ApplicantResumePoco[] { _applicantResume });
            }
        }

        private void ApplicantSkillUpdate()
        {
            _applicantSkills.TimeStamp = GetApplicantSkill(_applicantSkills.Id.ToString()).TimeStamp;

            _applicantSkills.EndMonth = 12;
            _applicantSkills.EndYear = 1999;
            _applicantSkills.Skill = Truncate(Faker.Lorem.Sentence(), 100);
            _applicantSkills.SkillLevel = Truncate(Faker.Lorem.Sentence(), 10);
            _applicantSkills.StartMonth = 1;
            _applicantSkills.StartYear = 1999;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantSkill(new ApplicantSkillPoco[] { _applicantSkills });
            }
        }

        private void ApplicantWorkHistoryUpdate()
        {
            _appliantWorkHistory.TimeStamp = GetApplicantWorkHistory(_appliantWorkHistory.Id.ToString()).TimeStamp;

            _appliantWorkHistory.CompanyName = Truncate(Faker.Lorem.Sentence(), 150);
            _appliantWorkHistory.EndMonth = 01;
            _appliantWorkHistory.EndYear = 2001;
            _appliantWorkHistory.JobDescription = Truncate(Faker.Lorem.Sentence(), 500);
            _appliantWorkHistory.JobTitle = Truncate(Faker.Lorem.Sentence(), 50);
            _appliantWorkHistory.Location = Faker.Address.StreetName();
            _appliantWorkHistory.StartMonth = 2;
            _appliantWorkHistory.StartYear = 1989;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.UpdateApplicantWorkHistory(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
            }
        }

        private void SystemCountryCodeUpdate()
        {
            _systemCountry.Name = Truncate(Faker.Name.FullName(), 50);
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.UpdateSystemCountryCode(new SystemCountryCodePoco[] { _systemCountry });
            }
        }

        private void SystemLanguageCodeUpdate()
        {
            _systemLangCode.NativeName = Truncate(Faker.Lorem.Sentence(), 50);
            _systemLangCode.Name = Truncate(Faker.Lorem.Sentence(), 50);
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.UpdateSystemLanguageCode(new SystemLanguageCodePoco[] { _systemLangCode });
            }

        }
        #endregion UpdateImplementation

        #region RemoveImplementation
        private void SystemLanguageCodeRemove()
        {
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.RemoveSystemLanguageCode(new SystemLanguageCodePoco[] { _systemLangCode });
                Assert.IsNull(client.GetSingleSystemCountryCode(_systemLangCode.LanguageID));
            }
        }

        private void CompanyProfileRemove()
        {
            _companyProfile.TimeStamp = GetCompanyProfile(_companyProfile.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyProfile(new CompanyProfilePoco[] { _companyProfile });
                Assert.IsNull(client.GetSingleCompanyProfile(_companyProfile.Id.ToString()));
            }
        }

        private void CompanyDescriptionRemove()
        {
            _companyDescription.TimeStamp = GetCompanyDescription(_companyDescription.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyDescription(new CompanyDescriptionPoco[] { _companyDescription });
                Assert.IsNull(client.GetSingleCompanyDescription(_companyDescription.Id.ToString()));
            }
        }

        private void CompanyJobRemove()
        {
            _companyJob.TimeStamp = GetCompanyJob(_companyJob.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyJob(new CompanyJobPoco[] { _companyJob });
                Assert.IsNull(client.GetSingleCompanyJob(_companyJob.Id.ToString()));
            }
        }

        private void CompanyJobDescRemove()
        {
            _companyJobDescription.TimeStamp = GetCompanyJobDescription(_companyJobDescription.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyJobDescription(new CompanyJobDescriptionPoco[] { _companyJobDescription });
                Assert.IsNull(client.GetSingleCompanyJobDescription(_companyJobDescription.Id.ToString()));
            }
        }

        private void CompanyLocationRemove()
        {
            _companyLocation.TimeStamp = GetCompanyLocation(_companyLocation.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyLocation(new CompanyLocationPoco[] { _companyLocation });
                Assert.IsNull(client.GetSingleCompanyLocation(_companyLocation.Id.ToString()));
            }
        }

        private void CompanyJobEducationRemove()
        {
            _companyJobEducation.TimeStamp = GetCompanyJobEducation(_companyJobEducation.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyJobEducation(new CompanyJobEducationPoco[] { _companyJobEducation });
                Assert.IsNull(client.GetSingleCompanyJobEducation(_companyJobEducation.Id.ToString()));
            }
        }

        private void CompanyJobSkillRemove()
        {
            _companyJobSkill.TimeStamp = GetCompanyJobSkill(_companyJobSkill.Id.ToString()).TimeStamp;

            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                client.RemoveCompanyJobSkill(new CompanyJobSkillPoco[] { _companyJobSkill });
                Assert.IsNull(client.GetSingleCompanyJobSkill(_companyJobSkill.Id.ToString()));
            }
        }

        private void SystemCountryCodeRemove()
        {
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                client.RemoveSystemCountryCode(new SystemCountryCodePoco[] { _systemCountry });
                Assert.IsNull(client.GetSingleSystemCountryCode(_systemCountry.Code));
            }
        }

        private void SecurityLoginRemove()
        {
            _securityLogin.TimeStamp = GetSecurityLogin(_securityLogin.Id.ToString()).TimeStamp;

            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.RemoveSecurityLogin(new SecurityLoginPoco[] { _securityLogin });
                Assert.IsNull(client.GetSingleSecurityLogin(_securityLogin.Id.ToString()));
            }
        }

        private void SecurityLoginLogRemove()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.RemoveSecurityLoginsLog(new SecurityLoginsLogPoco[] { _securityLoginLog });
                Assert.IsNull(client.GetSingleSecurityLogin(_securityLoginLog.Id.ToString()));
            }
        }

        private void SecurityRoleRemove()
        {
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.RemoveSecurityRole(new SecurityRolePoco[] { _securityRole });
                Assert.IsNull(client.GetSingleSecurityRole(_securityRole.Id.ToString()));
            }
        }

        private void SecurityLoginRoleRemove()
        {
            _securityLoginRole.TimeStamp = GetSecurityLoginsRole(_securityLoginRole.Id.ToString()).TimeStamp;

            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                client.RemoveSecurityLoginsRole(new SecurityLoginsRolePoco[] { _securityLoginRole });
                Assert.IsNull(client.GetSingleSecurityRole(_securityLoginRole.Id.ToString()));
            }
        }

        private void ApplicantProfileRemove()
        {
            _applicantProfile.TimeStamp = GetApplicantProfile(_applicantProfile.Id.ToString()).TimeStamp;

            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantProfile(new ApplicantProfilePoco[] { _applicantProfile });
                Assert.IsNull(client.GetSingleApplicantProfile(_applicantProfile.Id.ToString()));
            }
        }

        private void ApplicantEducationRemove()
        {
            _applicantEducation.TimeStamp = GetApplicantEducation(_applicantEducation.Id.ToString()).TimeStamp;

            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantEducation(new ApplicantEducationPoco[] { _applicantEducation });
                Assert.IsNull(client.GetSingleApplicantProfile(_applicantEducation.Id.ToString()));
            }
        }

        private void ApplicantJobApplicationRemove()
        {
            _applicantJobApplication.TimeStamp = GetApplicantJobApplication(_applicantJobApplication.Id.ToString()).TimeStamp;

            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantJobApplication(new ApplicantJobApplicationPoco[] { _applicantJobApplication });
                Assert.IsNull(client.GetSingleApplicantProfile(_applicantJobApplication.Id.ToString()));
            }
        }

        private void ApplicantResumeRemove()
        {
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantResume(new ApplicantResumePoco[] { _applicantResume });
                Assert.IsNull(client.GetSingleApplicantProfile(_applicantResume.Id.ToString()));
            }
        }

        private void ApplicantSkillRemove()
        {
            _applicantSkills.TimeStamp = GetApplicantSkill(_applicantSkills.Id.ToString()).TimeStamp;

            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantSkill(new ApplicantSkillPoco[] { _applicantSkills });
                Assert.IsNull(client.GetSingleApplicantProfile(_applicantSkills.Id.ToString()));
            }
        }

        private void ApplicantWorkHistoryRemove()
        {
            _appliantWorkHistory.TimeStamp = GetApplicantWorkHistory(_appliantWorkHistory.Id.ToString()).TimeStamp;

            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                client.RemoveApplicantWorkHistory(new ApplicantWorkHistoryPoco[] { _appliantWorkHistory });
                Assert.IsNull(client.GetSingleApplicantProfile(_appliantWorkHistory.Id.ToString()));
            }
        }

        #endregion RemoveImplementation
        private string Truncate(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return str.Length <= maxLength ? str : str.Substring(0, maxLength);
        }

        #region GetPocoById
        private ApplicantSkillPoco GetApplicantSkill(string Id)
        {
            ApplicantSkillPoco applicantSkillPoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantSkillPoco = client.GetSingleApplicantSkill(Id);
            }
            return applicantSkillPoco;
        }

        private ApplicantResumePoco GetApplicantResume(string Id)
        {
            ApplicantResumePoco applicantResumePoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantResumePoco = client.GetSingleApplicantResume(Id);
            }
            return applicantResumePoco;
        }

        private ApplicantJobApplicationPoco GetApplicantJobApplication(string Id)
        {
            ApplicantJobApplicationPoco applicantJobApplicationPoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantJobApplicationPoco = client.GetSingleApplicantJobApplication(Id);
            }
            return applicantJobApplicationPoco;
        }


        private ApplicantEducationPoco GetApplicantEducation(string Id)
        {
            ApplicantEducationPoco applicantEducationPoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantEducationPoco = client.GetSingleApplicantEducation(Id);
            }
            return applicantEducationPoco;
        }

        private ApplicantProfilePoco GetApplicantProfile(string Id)
        {
            ApplicantProfilePoco applicantProfilePoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantProfilePoco = client.GetSingleApplicantProfile(Id);
            }
            return applicantProfilePoco;
        }

        private SecurityLoginsRolePoco GetSecurityLoginsRole(string Id)
        {
            SecurityLoginsRolePoco securityLoginsRolePoco;
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                securityLoginsRolePoco = client.GetSingleSecurityLoginsRole(Id);
            }
            return securityLoginsRolePoco;
        }

        private SecurityRolePoco GetSecurityRole(string Id)
        {
            SecurityRolePoco securityRolePoco;
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                securityRolePoco = client.GetSingleSecurityRole(Id);
            }
            return securityRolePoco;
        }

        private SecurityLoginsLogPoco GetSecurityLoginsLog(string Id)
        {
            SecurityLoginsLogPoco securityLoginsLogPoco;
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                securityLoginsLogPoco = client.GetSingleSecurityLoginsLog(Id);
            }
            return securityLoginsLogPoco;
        }

        private SecurityLoginPoco GetSecurityLogin(string Id)
        {
            SecurityLoginPoco securityLoginPoco;
            using (SecurityService.SecurityClient client = new SecurityService.SecurityClient())
            {
                securityLoginPoco = client.GetSingleSecurityLogin(Id);
            }
            return securityLoginPoco;
        }

        private CompanyJobSkillPoco GetCompanyJobSkill(string Id)
        {
            CompanyJobSkillPoco companyJobSkillPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyJobSkillPoco = client.GetSingleCompanyJobSkill(Id);
            }
            return companyJobSkillPoco;
        }


        private CompanyJobEducationPoco GetCompanyJobEducation(string Id)
        {
            CompanyJobEducationPoco companyJobEducationPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyJobEducationPoco = client.GetSingleCompanyJobEducation(Id);
            }
            return companyJobEducationPoco;
        }

        private CompanyLocationPoco GetCompanyLocation(string Id)
        {
            CompanyLocationPoco companyLocationPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyLocationPoco = client.GetSingleCompanyLocation(Id);
            }
            return companyLocationPoco;
        }


        private CompanyJobDescriptionPoco GetCompanyJobDescription(string Id)
        {
            CompanyJobDescriptionPoco companyJobDescPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyJobDescPoco = client.GetSingleCompanyJobDescription(Id);
            }
            return companyJobDescPoco;
        }

        private CompanyJobPoco GetCompanyJob(string Id)
        {
            CompanyJobPoco companyJobPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyJobPoco = client.GetSingleCompanyJob(Id);
            }
            return companyJobPoco;
        }

        private CompanyDescriptionPoco GetCompanyDescription(string Id)
        {
            CompanyDescriptionPoco companyDescriptionPoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyDescriptionPoco = client.GetSingleCompanyDescription(Id);
            }
            return companyDescriptionPoco;
        }

        public CompanyProfilePoco GetCompanyProfile(string Id)
        {
            CompanyProfilePoco companyProfilePoco;
            using (CompanyService.CompanyClient client = new CompanyService.CompanyClient())
            {
                companyProfilePoco = client.GetSingleCompanyProfile(Id);
            }
            return companyProfilePoco;
        }

        private ApplicantWorkHistoryPoco GetApplicantWorkHistory(string Id)
        {
            ApplicantWorkHistoryPoco applicantWorkHistoryPoco;
            using (ApplicantService.ApplicantClient client = new ApplicantService.ApplicantClient())
            {
                applicantWorkHistoryPoco = client.GetSingleApplicantWorkHistory(Id);
            }
            return applicantWorkHistoryPoco;
        }

        public SystemCountryCodePoco GetSystemCountryCode(string Id)
        {
            SystemCountryCodePoco systemCountryCodePoco;
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                systemCountryCodePoco = client.GetSingleSystemCountryCode(Id);
            }
            return systemCountryCodePoco;
        }

        private SystemLanguageCodePoco GetSystemLanguageCode(string Id)
        {
            SystemLanguageCodePoco systemLanguageCodePoco;
            using (SystemService.SystemClient client = new SystemService.SystemClient())
            {
                systemLanguageCodePoco = client.GetSingleSystemLanguageCode(Id);
            }
            return systemLanguageCodePoco;
        }
        #endregion
    }
}
