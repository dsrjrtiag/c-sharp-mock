using BookLibrary.Controllers;
using BookLibrary.Data;
using BookLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BookLibraryTests
{
    public class BooksControllerGetTests
    {
        //This is a stub, because we aren't verifying anything against it
        private Mock<BookLibraryContext> contextStub = new Mock<BookLibraryContext>();
        //The actual object we are testing, the unit if you will
        BooksController booksController;

        /// <summary>
        /// Set up our mock objects for each test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            //This is also a stub, it is only providing the data needed to run the test
            var bookDbSetStub = new Mock<DbSet<Book>>();
            bookDbSetStub.Setup(x => x.FindAsync(1)).ReturnsAsync(new Book()
            {
                Id = 1,
                Isbn = 12345,
                Title = "Lord of the Rings",
                Description = "Fantasy"
            });

            bookDbSetStub.Setup(x => x.FindAsync(2)).ReturnsAsync((Book)null);

            //Inject a stub into another stub
            contextStub.Setup(x => x.Book).Returns(bookDbSetStub.Object);

            //Inject the stub
            booksController = new BooksController(contextStub.Object);
        }

        /// <summary>
        /// Tests the successful path of returning a book by ID
        /// </summary>
        [Test]
        public void ReturnsBookTest()
        {
            var id = 1;
            var actionResultTask = booksController.GetBook(id);
            var book = actionResultTask.Result.Value;

            Assert.AreEqual(id, book.Id);
        }

        /// <summary>
        /// Tests the failure path of returning null when a book is not found by ID
        /// </summary>
        [Test]
        public void ReturnsNullTest()
        {
            var id = 2;
            var actionResultTask = booksController.GetBook(id);
            var book = actionResultTask.Result.Value;

            Assert.IsNull(book);
            //We can also check that it returns the right kind of response to the client
            Assert.IsInstanceOf(typeof(NotFoundResult), actionResultTask.Result.Result);
        }
    }
}