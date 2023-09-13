using Microsoft.EntityFrameworkCore;
using Project_with_Login.Data;


namespace Project_with_Login.Data
{
    public class ContactService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ContactService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        //Get All Contact
        public async Task<List<Contact>> GetAllEmployees()
        {
            return await _applicationDbContext.Contacts.ToListAsync();

        }

        //Add New Contact Record
        public async Task<bool> AddNewContact(Contact contact)
        {
            await _applicationDbContext.Contacts.AddAsync(contact);
            await _applicationDbContext.SaveChangesAsync();
            return true;

        }

        //Get Contact Record By Id
        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _applicationDbContext.Contacts.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return contact;
        }
        //Update Contact Data
        public async Task<bool> UpdateContactDetails(Contact contact)
        {
            _applicationDbContext.Contacts.Update(contact);
            await _applicationDbContext.SaveChangesAsync(true);
            return true;
        }

        //Delete Contact Data
        public async Task<bool> DeleteContact(Contact contact)
        {
            _applicationDbContext.Contacts.Remove(contact);
            await _applicationDbContext.SaveChangesAsync(true);
            return true;
        }
    }
}
