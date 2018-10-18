using Microsoft.AspNet.Identity;
using PhoneBookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookProject.Controllers
{
    public class PersonController : Controller
    {
        static int count;
        // GET: Person
        public ActionResult Index()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<PersonViewModel> lists = new List<PersonViewModel>();
            
            
            foreach(Person p in db.People)
            {
               
                if (p.AddedBy == User.Identity.GetUserId())
                {
                    PersonViewModel obj = new PersonViewModel();
                    obj.FirstName = p.FirstName;
                    obj.LastName = p.LastName;
                    obj.MiddleName = p.MiddleName;
                    obj.HomeAddress = p.HomeAddress;
                    obj.HomeCity = p.HomeCity;
                    obj.ImagePath = p.ImagePath;
                    obj.EmailId = p.EmailId;
                    obj.TwitterId = p.TwitterId;
                    obj.LinkedInId = p.LinkedInId;
                    obj.FaceBookAccountId = p.FaceBookAccountId;
                    obj.DateOfBirth = p.DateOfBirth;
                    obj.PersonId = p.PersonId;
                    obj.AddedOn = DateTime.Now;
                    obj.UpdateOn = DateTime.Now;
                    obj.AddedBy = User.Identity.GetUserId();
                    count++;
                    lists.Add(obj);
                }
            }
            return View(lists);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            List<ContactViewModel> contactList = new List<ContactViewModel>();
            foreach(Contact c in db.Contacts)
            {
                if(c.PersonId == id)
                {
                    ContactViewModel v = new ContactViewModel();
                    v.Type = c.Type;
                    v.PersonId = c.PersonId;
                    v.ContactNumber = c.ContactNumber;
                    v.ContactId = c.ContactId;
                    contactList.Add(v);
                }
            }
           

            return View(contactList);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(CreatPersonViewModel obj)
        {
            
                Person p = new Person();
                p.FirstName = obj.FirstName;
                p.MiddleName = obj.MiddleName;
                p.LastName = obj.LastName;
                p.LinkedInId = obj.LinkedInId;
                p.HomeAddress = obj.HomeAddress;
                p.HomeCity = obj.HomeCity;
                p.EmailId = obj.EmailId;
                p.TwitterId = obj.TwitterId;
                p.DateOfBirth = obj.DateOfBirth;
                p.FaceBookAccountId = obj.FaceBookAccountId;
                p.ImagePath = obj.ImagePath;
                p.AddedOn = DateTime.Now;
                p.UpdateOn = DateTime.Now;
                
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                string id = User.Identity.GetUserId();
                p.AddedBy = id;
                db.People.Add(p);
                db.SaveChanges();
           
               
                return RedirectToAction("Index");
           
           
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            EditPersonViewModel obj = new EditPersonViewModel();
            foreach(Person p in db.People)
            {
                if(p.PersonId==id)
                {
                    obj.FirstName = p.FirstName;
                    obj.MiddleName = p.MiddleName;
                    obj.LastName = p.LastName;
                    obj.DateOfBirth = p.DateOfBirth;
                    obj.HomeAddress = p.HomeAddress;
                    obj.HomeCity = p.HomeCity;
                    obj.LinkedInId = p.LinkedInId;
                    obj.TwitterId = p.TwitterId;
                    obj.EmailId = p.EmailId;
                    obj.FaceBookAccountId = p.FaceBookAccountId;
                    obj.ImagePath = p.ImagePath;
                    break;
                }

            }
            
            return View(obj);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditPersonViewModel obj)
        {
            try
            
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                db.People.Find(id).FirstName = obj.FirstName;
                db.People.Find(id).LastName = obj.LastName;
                db.People.Find(id).MiddleName = obj.MiddleName;
                db.People.Find(id).HomeAddress = obj.HomeAddress;
                db.People.Find(id).HomeCity = obj.HomeCity;
                db.People.Find(id).ImagePath = obj.ImagePath;
                db.People.Find(id).TwitterId = obj.TwitterId;
                db.People.Find(id).FaceBookAccountId = obj.FaceBookAccountId;
                db.People.Find(id).EmailId = obj.EmailId;
                db.People.Find(id).DateOfBirth = obj.DateOfBirth;
                db.People.Find(id).LinkedInId = obj.LinkedInId;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();

            foreach (Contact c in db.Contacts)
            {
                if(c.PersonId == id)
                {
                    db.Contacts.Remove(c);
                }
            }
            foreach(Person p in db.People)
            {
                if(p.PersonId == id)
               {

                    db.People.Remove(p);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Person");
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
