using Microsoft.AspNetCore.Mvc;
using WebApplication5.Repository;

public class HomeController : Controller
{
    private readonly IContactRepository _repo;

    public HomeController(IContactRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var contacts = _repo.GetAllContacts();
        return View(contacts);
    }
}