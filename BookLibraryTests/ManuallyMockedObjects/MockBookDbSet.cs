using BookLibrary.Data;
using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibraryTests.ManuallyMockedObjects
{
    public class MockBookDbSet : DbSet<Book>
    {
        public override ValueTask<Book> FindAsync(object[] keyValues) { 
            var key = (int)keyValues[0];
            if (key == 1)
            {
                return new ValueTask<Book>(Task.FromResult(new Book()
                {
                    Id = 1,
                    Isbn = 12345,
                    Title = "Lord of the Rings",
                    Description = "Fantasy"
                }));
            }
            else
            {
                return new ValueTask<Book>(Task.FromResult((Book)null));
            }
        }

        //public override EntityEntry<Book> Remove(Book entity)
        //{
        //    if(entity.Id == 1)
        //    {
        //        new InternalEntityEntryFactory().Create()
        //        new EntityEntry<Book>(new InternalEntityEntry()) 
        //    }
        //    return base.Remove(entity);
        //}
    }
}
