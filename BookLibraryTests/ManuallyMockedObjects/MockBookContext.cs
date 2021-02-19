using BookLibrary.Data;
using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryTests.ManuallyMockedObjects
{
    public class MockBookContext : BookLibraryContext
    {
        private readonly MockBookDbSet bookDbSet;

        public MockBookContext(MockBookDbSet bookDbSet)
        {
            this.bookDbSet = bookDbSet;
        }
        public override DbSet<Book> Book { get => bookDbSet; set => base.Book = value; }
    }
}
