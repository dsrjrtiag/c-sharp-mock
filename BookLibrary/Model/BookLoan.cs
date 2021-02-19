using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    public class BookLoan
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
