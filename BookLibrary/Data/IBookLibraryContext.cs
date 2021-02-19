using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class IBookLibraryContext : DbContext
    {
        private DbContextOptions<BookLibraryContext> options;

        public virtual DbSet<BookLibrary.Model.User> User { get; set; }

        public virtual DbSet<BookLibrary.Model.Author> Author { get; set; }

        public virtual DbSet<BookLibrary.Model.Book> Book { get; set; }

        public virtual DbSet<BookLibrary.Model.BookLoan> BookLoan { get; set; }

        public virtual DbSet<BookLibrary.Model.BookCopy> BookCopy { get; set; }
    }
}
