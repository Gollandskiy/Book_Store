using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store
{
    public class BooksClass
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string NameAuthor { get; set; }
        public string SubnameAuthor { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
