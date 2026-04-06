using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repository;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        // HOME / LIST
        public IActionResult ShowContacts()
        {
            return View(_repo.GetAllContacts());
        }

        // ADD GET
        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        // ADD POST
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // EDIT GET
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View(contact);
        }

        // EDIT POST  ✅ IMPORTANT
        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        // DELETE
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
        public IActionResult Details(int id)
        {
            var contact = _repo.GetContactById(id);
            return View(contact);
        }
    }
}