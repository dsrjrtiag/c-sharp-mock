using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    public class Book
    {
        public int Id { get; set; }
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}
