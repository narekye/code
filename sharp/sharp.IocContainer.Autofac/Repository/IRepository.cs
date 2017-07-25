using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sharp.IocContainer.Autofac.Entity;

namespace sharp.IocContainer.Autofac.Repository
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
