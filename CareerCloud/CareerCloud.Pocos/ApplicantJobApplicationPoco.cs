using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Applicant")]
        public Guid Applicant { get; set; }

        [ForeignKey("Applicant")]
        public virtual ApplicantProfilePoco ApplicantProfilePoco { get; set; }
        [Column("Job")]
        public Guid Job { get; set; }

        [ForeignKey("Job")]
        public virtual CompanyJobPoco CompanyJobPoco { get; set; }

        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] TimeStamp { get; set; }
        
        
    }
}
