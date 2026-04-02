using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repository;
using WebApplication5.Models;

[Route("contact")]
public class ContactController : Controller
{
    private readonly IContactRepository _repo;

    public ContactController(IContactRepository repo)
    {
        _repo = repo;
    }

    // LIST
    [HttpGet("")]
    public IActionResult ShowContacts()
    {
        return View(_repo.GetAllContacts());
    }

    // ADD GET
    [HttpGet("add")]
    public IActionResult AddContact()
    {
        ViewBag.Companies = _repo.GetCompanies();
        ViewBag.Departments = _repo.GetDepartments();
        return View();
    }

    // ADD POST
    [HttpPost("add")]
    public IActionResult AddContact(ContactInfo contact)
    {
        _repo.AddContact(contact);
        return RedirectToAction("ShowContacts");
    }

    // EDIT GET
    [HttpGet("edit/{id}")]
    public IActionResult EditContact(int id)
    {
        ViewBag.Companies = _repo.GetCompanies();
        ViewBag.Departments = _repo.GetDepartments();

        var contact = _repo.GetContactById(id);
        return View(contact);
    }

    // EDIT POST
    [HttpPost("edit")]
    public IActionResult EditContact(ContactInfo contact)
    {
        _repo.UpdateContact(contact);
        return RedirectToAction("ShowContacts");
    }

    // DELETE
    [HttpGet("delete/{id}")]
    public IActionResult DeleteContact(int id)
    {
        _repo.DeleteContact(id);
        return RedirectToAction("ShowContacts");
    }
}