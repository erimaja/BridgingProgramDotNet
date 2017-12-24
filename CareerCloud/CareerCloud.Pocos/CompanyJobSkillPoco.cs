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
        [Column("Id")]
        public Guid Id { get; set; } 
        [Column("Job")]
        public Guid Job { get; set; } 
        [Column("Skill")]
        public String Skill { get; set; } 
        [Column("Skill_Level")]
        public String SkillLevel { get; set; } 
        [Column("Importance")]
        public Int32 Importance { get; set; } 
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; private set; } 
    }
}
