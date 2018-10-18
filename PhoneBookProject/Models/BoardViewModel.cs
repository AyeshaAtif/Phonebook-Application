using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookProject.Models
{
    public class BoardViewModel
    {
        public int count { get; set; }

        public List<Person> Birthdays = new List<Person>();

        public int Count()
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            foreach(Person p in db.People)
            {
                count++;
            }
            return count;
        }

    }
}