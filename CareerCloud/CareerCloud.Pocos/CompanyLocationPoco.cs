using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Company")]
        public Guid Company { get; set; }

        [ForeignKey("Company")]
        public virtual CompanyProfilePoco CompanyProfilePoco { get; set; }

        [Column("Country_Code")]
        [StringLength(10)]
        [Required]
        public string CountryCode { get; set; }

        string _province;
        [Column("State_Province_Code")]
        [StringLength(10)]
        public string Province
        {
            get
            {
                return _province?.PadRight(10);
            }

            set
            {
                _province = value;
            }
        }
       

        [Column("Street_Address")]
        public string Street { get; set; }

        [Column("City_Town")]
        public string City { get; set; }

        string _zipCode;
        [Column("Zip_Postal_Code")]
        [StringLength(20)]
        public string PostalCode
        {
            get
            {
                return _zipCode?.PadRight(20);
            }

            set
            {
                _zipCode = value;
            }
        }

        [Column(name: "Time_Stamp",TypeName ="timestamp")]
        [MaxLength(8)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
        
    }
}
