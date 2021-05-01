using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace DALSageBookDB
{
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public ICollection<Book> Books { get; set; }
        public Sage()
        {
            Books = new List<Book>();
        }

    }

}
