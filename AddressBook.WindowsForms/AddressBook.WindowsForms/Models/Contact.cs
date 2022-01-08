using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WindowsForms.Models
{
    public class Contact
    {
        public   Contact(string name, string telephone, string notes)
        {
            Name = name;
            Telephone= telephone;
            Notes = notes;
        }

        public   Contact()
        {
            Name = "";
            Telephone= "";
            Notes = "";
        }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Notes { get;set; }
    }
}
