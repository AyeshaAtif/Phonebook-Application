using PhoneBookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<ContactViewModel> contactList = new List<ContactViewModel>();
            foreach (Contact c in db.Contacts)
            {
                ContactViewModel contact = new ContactViewModel();
                contact.ContactNumber = c.ContactNumber;
                contact.ContactId = c.ContactId;
                contact.Type = c.Type;
                contact.PersonId = c.PersonId;
                contactList.Add(contact);
            }

            return View(contactList);
        }
          
        

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id, ContactViewModel obj)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();


                Contact c = new Contact();
                c.ContactNumber = obj.ContactNumber;
                c.Type = obj.Type;
                c.PersonId = id;
                db.Contacts.Add(c);
                db.SaveChanges();


                return RedirectToAction("Index", "Person");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();

            ContactViewModel contact = new ContactViewModel();
            foreach (Contact c in db.Contacts)
            {
                if (c.PersonId == id)
                {
                    contact.ContactNumber = c.ContactNumber;
                    contact.Type = c.Type;
                }
            }
            return View(contact);
           
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ContactViewModel obj)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.Contacts.Find(id).ContactNumber = obj.ContactNumber;
                db.Contacts.Find(id).Type = obj.Type;

                db.SaveChanges();

                return RedirectToAction("Details", "Person", new { id = db.Contacts.Find(id).PersonId });
                // TODO: Add update logic here

               
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                foreach (Contact c in db.Contacts)
                {
                    if (c.ContactId == id)
                    {
                        db.Contacts.Remove(c);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Details", "Person", new { id = id });

            }
            catch (Exception ex)
            {
                throw (ex);
            }
           

           
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {


                return RedirectToAction("Index");

               
            }
            catch
            {
                return View();
            }
        }
    }
}
