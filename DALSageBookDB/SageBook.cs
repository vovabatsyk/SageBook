namespace DALSageBookDB
{
    public class SageBook
    {
        public int Id { get; set; }
        public int IdSage { get; set; }
        public int IdBook { get; set; }

        public virtual Sage Sage { get; set; }
        public virtual Book Book { get; set; }

        public override string ToString()
        {
            return $"Sage_name : {Sage.Name}, sage_age: {Sage.Age}, book_title: {Book.Title}, book_pages: {Book.Pages}";
        }
    }
}
