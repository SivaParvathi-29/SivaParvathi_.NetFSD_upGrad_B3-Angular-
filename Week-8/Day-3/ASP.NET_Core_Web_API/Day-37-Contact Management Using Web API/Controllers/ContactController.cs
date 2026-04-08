using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repo.GetAllContactsAsync();
            return Ok(contacts);
        }

        // GET: api/contacts/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetContactByIdAsync(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            if (contact == null)
                return BadRequest();

            var created = await _repo.AddContactAsync(contact);

            return CreatedAtAction(nameof(GetById), new { id = created.ContactId }, created);
        }

        // PUT: api/contacts/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            var result = await _repo.UpdateContactAsync(id, contact);

            if (!result)
                return NotFound();

            return Ok("Updated Successfully");
        }

        // DELETE: api/contacts/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteContactAsync(id);

            if (!result)
                return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}