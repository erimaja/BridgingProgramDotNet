using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Job")]
        public Guid Job { get; set; }

        [ForeignKey("Job")]
        public virtual CompanyJobPoco CompanyJobPoco { get; set; }

        [Column("Major")]
        public String Major { get; set; }

        [Column("Importance")]
        public Int16 Importance { get; set; }

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
       
    }
}
