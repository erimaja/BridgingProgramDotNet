using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }

        [Required]
        [Column("Country_Code")]
        public string Country { get; set; }

        [ForeignKey("Country")]
        public virtual SystemCountryCodePoco SystemCountryCodePoco { get; set; }

        [Column("State_Province_Code")]
        public string Province { get; set; } 

        [Column("Street_Address")]
        public string Street { get; set; } 

        [Column("City_Town")]
        public string City { get; set; } 

        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; } 

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] TimeStamp { get; set; }

        [Column("Login")]
        public Guid Login { get; set; }

        [ForeignKey("Login")]
        public virtual SecurityLoginPoco SecurityLoginPoco { get; set; }

        [Column("Currency")]
        public string Currency { get; set; }
        public virtual ICollection<ApplicantEducationPoco> pplicantEducationPoco { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumePoco { get; set; }
      
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistoryPoco { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplicationPoco { get; set; }

        public virtual ICollection<ApplicantSkillPoco> ApplicantSkillPoco { get; set; }
    }
}
