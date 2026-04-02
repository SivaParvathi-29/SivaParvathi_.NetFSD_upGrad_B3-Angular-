using System.Security.Cryptography.Pkcs;

namespace WebApplication5.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public List<ContactInfo> Contacts { get; set; }
    }
}