using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ContactManager.Models;
using ContactManager.Parts;

namespace ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepo)
        {
            _contactRepository = contactRepo;
        }

        public Contact[] Get()
        {
            return _contactRepository.GetAllContacts();
        }

        public HttpResponseMessage<Contact> Post(Contact contact)
        {
            this._contactRepository.SaveContact(contact);

            var response = new HttpResponseMessage<Contact>(contact)
                {
                    StatusCode = System.Net.HttpStatusCode.Created
                };

            return response;
        }
    }
}
