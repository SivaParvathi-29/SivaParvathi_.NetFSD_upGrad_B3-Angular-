using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        // In-memory list
        static List<ContactInfo> contacts = new List<ContactInfo>();

        // 1. Show all contacts
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }

        // 2. Get contact by ID
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            return View(contact);
        }

        // 3. Add Contact (GET)
        public IActionResult AddContact()
        {
            return View();
        }

        // 4. Add Contact (POST)
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            contacts.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}
