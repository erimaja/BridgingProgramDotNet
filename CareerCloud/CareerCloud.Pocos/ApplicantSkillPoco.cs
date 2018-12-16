using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } 

        [Column("Applicant")]
        public Guid Applicant { get; set; }

        [ForeignKey("Applicant")]
        public virtual ApplicantProfilePoco ApplicantProfilePoco { get; set; }

        [Column("Skill")]
        public String Skill { get; set; } 

        [Column("Skill_Level")]
        public String SkillLevel { get; set; }
        
        [Column("Start_Month")]
        public Byte StartMonth { get; set; }

        [Column("Start_Year")]
        public Int32 StartYear { get; set; } 

        [Column("End_Month")]
        public Byte EndMonth { get; set; } 

        [Column("End_Year")]
        public Int32 EndYear { get; set; } 

        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }

        

    }
}
