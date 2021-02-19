using BookLibrary.Controllers;
using BookLibrary.Data;
using BookLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryTests
{
    /// <summary>
    /// Test class for the BooksController DeleteBook method 
    /// Uses Mocks as Mocks, to verify books are found and deleted in the DbContext
    /// </summary>
    public class BooksControllerDeleteTests
    {
        //This is still a stub, we aren't asserting anything against it
        public Mock<BookLibraryContext> contextStub = new Mock<BookLibraryContext>();
        //This IS a mock, we will be asserting against it
        public Mock<DbSet<Book>> mockBookDbSet;
        public BooksController booksController;

        /// <summary>
        /// Set up our mock objects for each test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            mockBookDbSet = new Mock<DbSet<Book>>();
            mockBookDbSet.Setup(x => x.FindAsync(1)).ReturnsAsync(new Book()
            {
                Id = 1,
                Isbn = 12345,
                Title = "Lord of the Rings",
                Description = "Fantasy"
            });

            mockBookDbSet.Setup(x => x.FindAsync(2)).ReturnsAsync((Book)null);

            contextStub.Setup(x => x.Book).Returns(mockBookDbSet.Object);

            //Inject the Mock
            booksController = new BooksController(contextStub.Object);
        }

        [Test]
        public void DeleteExistingBookTest()
        {
            mockBookDbSet.Setup(x => x.Remove(It.Is<Book>(b => b.Id == 1))).Verifiable();

            //mockBookDbSet.Setup(x => x.Remove(It.IsAny<Book>())).Callback<Book>(b =>
            //   {
            //       Assert.AreEqual(b.Id, 1);
            //   }
            //);

            var deletedBook = booksController.DeleteBook(1);

            //Verify checks that any Setup marked Verifiable actually happened
            mockBookDbSet.Verify();
        }

        [Test]
        public void DeleteNonExistentBookTest()
        {
            var deletedResult = booksController.DeleteBook(2);

            //The book didn't exist so the return should be NotFoundResult with a null value
            Assert.IsInstanceOf(typeof(NotFoundResult), deletedResult.Result.Result);
            Assert.IsNull(deletedResult.Result.Value);

            //Verify can also do an inline check on how many times the method executed
            mockBookDbSet.Verify(x => x.Remove(It.IsAny<Book>()), Times.Never);
        }
    }
}
