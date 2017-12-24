using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } 
        [Column("Job")]
        public Guid Job { get; set; } 
        [Column("Job_Name")]
        public String JobName { get; set; } 
        [Column("Job_Descriptions")]
        public String JobDescriptions { get; set; } 
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; private set; } 
    }
}
