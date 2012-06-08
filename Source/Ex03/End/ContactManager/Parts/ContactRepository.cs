using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models;

namespace ContactManager.Parts
{
    public interface IContactRepository
    {
        Contact[] GetAllContacts();
        bool SaveContact(Contact contact);
    }

    public class ContactRepository : IContactRepository
    {
        const string cacheKey = "ContactStore";

        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[cacheKey];
            }

            return new Contact[]
	        {
	            new Contact
	            {
	                Id = 0,
	                Name = "Placeholder"
	            }
	        };
        }

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[cacheKey] == null)
                {
                    var contacts = new Contact[]
	            {
	                new Contact
	                {
	                    Id = 1, Name = "Glenn Block"
	                },
	                new Contact
	                {
	                    Id = 2, Name = "Dan Roth"
	                }
	            };

                    ctx.Cache[cacheKey] = contacts;
                }
            }
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    ((Contact[])ctx.Cache[cacheKey]).ToList().Add(contact);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}