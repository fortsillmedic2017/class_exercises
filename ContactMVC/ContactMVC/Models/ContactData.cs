using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMVC.Models
{
    public class ContactData
    {
        public static List<Contact>contacts = new List<Contact>();

        //GetAll
        public static List<Contact> GetAll()
        {
            return contacts;
        }

        //Add to List
        public static void Add(Contact newContact)
        {
            contacts.Add(newContact);
        }

        //GetById
        public static Contact GetById(int id)
        {
            return contacts.Single(x => x.ContactId == id);
        }
       
        //Remove form List
        public static void Remove(int id)
        {
            Contact contactToRemove = GetById(id);
            contacts.Remove(contactToRemove);
        }
    }
}
