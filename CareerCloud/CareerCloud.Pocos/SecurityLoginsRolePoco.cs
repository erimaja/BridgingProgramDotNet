using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("Login")]
        public Guid Login { get; set; }
        [ForeignKey("Login")]
        public virtual SecurityLoginPoco SecurityLoginPoco { get; set; }
        [Column("Role")]
        public Guid Role { get; set; }
        [ForeignKey("Role")]
        public virtual SecurityRolePoco SecurityRolePoco { get; set; }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
        
        
    }
}
