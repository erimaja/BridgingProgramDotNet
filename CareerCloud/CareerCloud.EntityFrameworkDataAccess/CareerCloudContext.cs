using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<CareerCloudContext>(null);

            //modelBuilder.Entity<SystemCountryCodePoco>()
            //    .HasMany(scc => scc.ApplicantProfilePoco)
            //    .WithRequired(ap => ap.SystemCountryCodePoco)
            //    .HasForeignKey(ap => ap.Country);

            //modelBuilder.Entity<SystemCountryCodePoco>()
            //    .HasMany(scc => scc.ApplicantWorkHistoryPoco)
            //    .WithRequired(ap => ap.SystemCountryCodePoco)
            //    .HasForeignKey(ap => ap.CountryCode);

            base.OnModelCreating(modelBuilder);
        }
        public CareerCloudContext(bool createProxy = true) : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
            //Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.ProxyCreationEnabled = createProxy;
         }

       
      }
}
