using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToList();
        }

        public ContactInfo GetContactById(int id)
        {
            return _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefault(c => c.ContactId == id);
        }

        public void AddContact(ContactInfo contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // 🔥 REAL ERROR WILL SHOW HERE
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void UpdateContact(ContactInfo contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                var contact = _context.Contacts.Find(id);

                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public List<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}