using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSageBookDB
{
    public class SageBook
    {
        public int Id { get; set; }
        public int IdSage { get; set; }
        public int IdBook { get; set; }

        public virtual Sage Sage { get; set; }
        public virtual Book Book { get; set; }

    }
}
