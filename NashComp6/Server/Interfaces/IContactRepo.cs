using NashComp6.Shared.Models;

namespace NashComp6.Server.Interfaces
{
    public interface IContactRepo
    {
        IEnumerable<Contact> GetContacts(int page, int pageSize);

        IEnumerable<Contact> GetAllContacts();

        IEnumerable<Contact> GetAllContacts(DateTime? date);

        Contact? GetContact(int id);

        Contact AddContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(int id);
    }
}
