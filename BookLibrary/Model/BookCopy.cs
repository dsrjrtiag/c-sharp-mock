using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    public class BookCopy
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public User Owner { get; set; }
    }
}
