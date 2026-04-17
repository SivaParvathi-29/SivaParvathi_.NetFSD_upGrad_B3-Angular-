using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactServiceLogic
    {
        private readonly ContactRepository _repository;

        public ContactServiceLogic(ContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Contact>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Contact> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Contact contact)
            => await _repository.AddAsync(contact);

        public async Task UpdateAsync(Contact contact)
            => await _repository.UpdateAsync(contact);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}