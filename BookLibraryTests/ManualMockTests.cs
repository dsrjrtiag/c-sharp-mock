using BookLibrary.Controllers;
using BookLibraryTests.ManuallyMockedObjects;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryTests
{
    public class ManualMockTests
    {
        private BooksController BooksController;

        [SetUp]
        public void SetUp()
        {
            BooksController = new BooksController(new MockBookContext(new MockBookDbSet()));
        }

        [Test]
        public void ReturnsBookTest()
        {
            var id = 1;
            var result = BooksController.GetBook(id);
            var book = result.Result.Value;

            Assert.AreEqual(id, book.Id);
        }

        [Test]
        public void ReturnsNullTest()
        {
            var id = 2;
            var actionResultTask = BooksController.GetBook(id);
            var book = actionResultTask.Result.Value;

            Assert.IsNull(book);
            //We can also check that it returns the right kind of response to the client
            Assert.IsInstanceOf(typeof(NotFoundResult), actionResultTask.Result.Result);
        }
    }
}
