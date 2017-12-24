using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
    public class SecurityRolePoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } 
        [Column("Role")]
        public String Role { get; set; } 
        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; } 
    }
}
