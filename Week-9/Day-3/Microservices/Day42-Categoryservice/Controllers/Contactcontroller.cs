using Microsoft.AspNetCore.Mvc;
using ContactService.Models;
using ContactService.Services;

namespace ContactService.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactServiceLogic _service;

        public ContactController(ContactServiceLogic service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            await _service.AddAsync(contact);
            return Ok(contact);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            await _service.UpdateAsync(contact);
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}