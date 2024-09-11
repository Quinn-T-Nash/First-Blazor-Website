using NashComp6.Server.Data;
using NashComp6.Server.Interfaces;
using NashComp6.Shared.Models;

namespace NashComp6.Server.Repos
{
    public class ContactRepo : IContactRepo
    {
        //Sends in the context so all methods can access, Dependency Inejction Model
        private ApplicationDbContext _context;

        public ContactRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);

            //Since we made modifications to the database save it
            _context.SaveChanges();

            //Will this asset have the new id field??
            return contact;
        }

        public void DeleteContact(int id)
        {
            Contact? contactRemoving = _context.Contacts.Where(p =>
                p.Id == id).FirstOrDefault();

            if (contactRemoving != null)
            {
                _context.Contacts.Remove(contactRemoving);
            }

            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.OrderByDescending(p => p.RespondedTo);
        }

        public IEnumerable<Contact> GetAllContacts(DateTime? date)
        {
            return _context.Contacts.Where(p => p.RespondedTo != date);
        }

        public IEnumerable<Contact> GetContacts(int page, int pageSize)
        {
            return _context.Contacts.OrderByDescending(p => p.ContactSubmitted).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Contact? GetContact(int id)
        {
            return _context.Contacts.Where(p => p.Id == id).FirstOrDefault();
        }

        public void UpdateContact(Contact contact)
        {
            Contact? currentContact = _context.Contacts.Where(p =>
                p.Id == contact.Id).FirstOrDefault();

            if (currentContact != null)
            {
                currentContact.FirstName = contact.FirstName;
                currentContact.LastName = contact.LastName;
                currentContact.CompanyName = contact.CompanyName;
                currentContact.FinacialAdvice = contact.FinacialAdvice;
                currentContact.FreightForwarding = contact.FreightForwarding;
                currentContact.InventoryAccounting = contact.InventoryAccounting;
                currentContact.Remarks = contact.Remarks;
                currentContact.ContactSubmitted = contact.ContactSubmitted;
                currentContact.Email = contact.Email;
                currentContact.PhoneNumber = contact.PhoneNumber;
                currentContact.Website = contact.Website;
                currentContact.RespondedTo = contact.RespondedTo;
            }

            //remember call save changes
            _context.SaveChanges();
        }
    }
}
