using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


    }
}
