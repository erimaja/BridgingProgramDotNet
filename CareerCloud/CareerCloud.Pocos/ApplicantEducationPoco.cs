using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Applicant")]
        public Guid Applicant { get; set; }

        [ForeignKey("Applicant")]
        public virtual ApplicantProfilePoco ApplicantProfilePoco { get; set; }

        [Column("Major")]
        public String Major { get; set; }

        [Column("Certificate_Diploma")]
        public String CertificateDiploma { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")]
        public DateTime? CompletionDate { get; set; } 

        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] TimeStamp { get; set; }
    }
}
