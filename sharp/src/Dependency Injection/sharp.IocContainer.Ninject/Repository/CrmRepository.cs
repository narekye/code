using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using sharp.IocContainer.Ninject.Entity;

namespace sharp.IocContainer.Ninject.Repository
{
    public class CrmRepository : IRepository
    {
        private readonly CrmEntities db;

        public CrmRepository(CrmEntities db)
        {
            if (this.db == null)
            {
                this.db = db;
            }
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<Contact> GetContacts()
        {
            var result = db.Contacts.ToListAsync();
            return result.Result;
        }

        public List<EmailList> GetEmailLists()
        {
            var result = db.EmailLists.ToListAsync();
            return result.Result;
        }

        public Task AddContactAsync(Contact contact)
        {
            db.Contacts.Add(contact);
            SaveChanges();
            return Task.FromResult(true);
        }

        public void SaveChanges()
        {
            db.SaveChangesAsync();
        }

        public bool DetectChanges()
        {
            throw new Exception();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}