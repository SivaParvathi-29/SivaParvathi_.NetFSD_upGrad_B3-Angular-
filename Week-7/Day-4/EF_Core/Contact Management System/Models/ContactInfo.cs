using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class ContactInfo
    {
        // ✅ PRIMARY KEY
        [Key]
        public int ContactId { get; set; }

        // ✅ BASIC DETAILS
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        public string Designation { get; set; }

        // ✅ FOREIGN KEYS
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // ✅ NAVIGATION PROPERTIES
        public Company Company { get; set; }
        public Department Department { get; set; }
    }
}