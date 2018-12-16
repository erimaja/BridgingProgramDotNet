using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Company")]
        public Guid Company { get; set; }
        [ForeignKey("Company")]
        public virtual CompanyProfilePoco CompanyProfilePoco { get; set; }

        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        public Boolean IsCompanyHidden { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplicationPoco { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducationPoco { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkillPoco { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptionPoco { get; set; }




    }
}
