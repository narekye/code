using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sharp.IocContainer.Ninject.Entity;

namespace sharp.IocContainer.Ninject.Repository
{
    public interface IRepository : IDisposable
    {
        List<Contact> GetContacts();
        List<EmailList> GetEmailLists();
        Task AddContactAsync(Contact contact);
        void SaveChanges();
        bool DetectChanges();
    }
}
