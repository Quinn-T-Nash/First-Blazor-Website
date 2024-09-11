using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NashComp6.Server.Interfaces;
using NashComp6.Shared.Models;

namespace NashComp6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepo _contactRepo;
        public ContactController(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpGet]
        [Route("{page:int}/{pageSize:int}")]
        public IEnumerable<Contact> GetContacts(int page, int pageSize)
        {
            return _contactRepo.GetContacts(page, pageSize);
        }

        [HttpGet]
        [Route("{id:int}")]
        public Contact? GetContact(int id)
        {
            return _contactRepo.GetContact(id);
        }

        [HttpGet]
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactRepo.GetAllContacts();
        }

        [HttpGet]
        [Route("{page:int}/{pageSize:int}/{test:int}")] //Cannot pass in datetime, so force it to get a date of null by passing in ints and creating a datetiem
        public IEnumerable<Contact> GetAllContacts(int page, int pageSize, int test)
        {
            DateTime? date = null;
            return _contactRepo.GetAllContacts(date);
        }

        [HttpPost]
        public void PostAsset(Contact contact)
        {
            _contactRepo.AddContact(contact);
        }

        [HttpPut]
        public void PutAsset(Contact contact)
        {
            _contactRepo.UpdateContact(contact);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteAsset(int id)
        {
            _contactRepo.DeleteContact(id);
        }
    }
}
