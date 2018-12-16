using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; } 

        [Column("Job")]
        public Guid Job { get; set; }

        [ForeignKey("Job")]
        public virtual CompanyJobPoco CompanyJobPoco { get; set; }

        [Column("Skill")]
        public String Skill { get; set; } 

        [Column("Skill_Level")]
        public String SkillLevel { get; set; } 

        [Column("Importance")]
        public Int32 Importance { get; set; } 

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
        
    }
}
