﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; } 
        [Column("Company")]
        public Guid Company { get; set; }

        [ForeignKey("Company")]
        public virtual CompanyProfilePoco CompanyProfilePoco { get; set; }

        [Column("LanguageID")]
        public String LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public virtual SystemLanguageCodePoco SystemLanguageCodePoco { get; set; }

        [Column("Company_Name")]
        public String CompanyName { get; set; } 

        [Column("Company_Description")]
        public String CompanyDescription { get; set; }
        
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
        
    }
}
