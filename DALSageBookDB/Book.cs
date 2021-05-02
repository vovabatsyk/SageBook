using System.Collections.Generic;

namespace DALSageBookDB
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public ICollection<Sage> Sages { get; set; }
        public Book()
        {
            Sages = new List<Sage>();
        }

        public override string ToString() => $"Title: {Title}, pages: {Pages.ToString()}";
    }
}
