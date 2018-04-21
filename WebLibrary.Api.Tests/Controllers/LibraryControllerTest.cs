using AutoFixture;
using Moq;
using MyTested.WebApi;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http.Results;
using WebLibrary.Api.Controllers;
using WebLibrary.Api.DAL;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.Tests.Controllers
{
    [TestFixture]
    public class LibraryControllerTest
    {
        [Test]
        public void GetAllBooks_ShouldHaveCorrectRoute()
        {
            MyWebApi.Routes().ShouldMap("/books").To<LibraryController>(x => x.GetAllBooks());
        }

        [Test]
        public void GetAllBooks_ReturnsJSONObject()
        {
            MyWebApi.Controller<LibraryController>().Calling(x => x.GetAllBooks())
                .ShouldReturn().Json().WithResponseModelOfType<List<Book>>();
        }
        
        [Test]
        public void GetAllBooks_CallsBookAgentGetBooks()
        {
            var mockBookAgent = new Mock<IBookAgent>();
            var fixture = new Fixture();
            var books = fixture.CreateMany<Book>();
            mockBookAgent.Setup(x => x.GetBooks()).Returns(books.ToList());
            var controller = new LibraryController(mockBookAgent.Object);

            controller.GetAllBooks();

            mockBookAgent.Verify(x => x.GetBooks());
        }

        [Test]
        public void GetAllBooks_ReturnsBookList_AsJSON()
        {
            var mockBookAgent = new Mock<IBookAgent>();
            var fixture = new Fixture();
            var books = fixture.CreateMany<Book>();
            var enumerable = books.ToList();
            mockBookAgent.Setup(x => x.GetBooks()).Returns(enumerable.ToList());
            var controller = new LibraryController(mockBookAgent.Object);
            var expectedResult = JsonConvert.SerializeObject(enumerable.ToList());

            var actual = controller.GetAllBooks();

            Assert.That(expectedResult, Is.EqualTo(actual));
        }
    }
}
