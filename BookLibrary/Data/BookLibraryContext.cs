using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Model;
using BookLibrary.Controllers;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<BookLibrary.Model.User> User { get; set; }

        public DbSet<BookLibrary.Model.Author> Author { get; set; }

        public virtual DbSet<BookLibrary.Model.Book> Book { get; set; }

        public DbSet<BookLibrary.Model.BookLoan> BookLoan { get; set; }

        public DbSet<BookLibrary.Model.BookCopy> BookCopy { get; set; }
    }
}
