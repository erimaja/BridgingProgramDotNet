using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [Key]
        [Required]
        [Column("Code")]
        public String Code { get; set; }
        [Column("Name")]
        public String Name { get; set; }
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfilePoco { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistoryPoco { get; set; }
    }
}
