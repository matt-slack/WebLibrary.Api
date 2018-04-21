using AutoFixture;
using Moq;
using MyTested.WebApi;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebLibrary.Api.Controllers;
using WebLibrary.Api.DAL;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.Tests.Controllers
{
    [TestFixture]
    public class LibraryControllerTest
    {
        private Fixture _fixture;
        private Mock<IBookAgent> _mockBookAgent;
        private BookSupply _books;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockBookAgent = new Mock<IBookAgent>();
            _books = _fixture.Create<BookSupply>();
            _mockBookAgent.Setup(x => x.GetBooks())
                .Returns(_books);
        }

        [Test]
        public void GetAllBooks_ShouldHaveCorrectRoute()
        {
            MyWebApi.Routes().ShouldMap("/books")
                .To<LibraryController>(x => x.GetAllBooks());
        }

        [Test]
        public void GetAllBooks_ReturnsJSONObject()
        {
            MyWebApi.Controller<LibraryController>()
                .Calling(x => x.GetAllBooks())
                .ShouldReturn()
                .Json()
                .WithResponseModelOfType<BookSupply>();
        }

        [Test]
        public void GetAllBooks_ReturnsBookList_AsJSON()
        {
            MyWebApi.Controller(() => new LibraryController(_mockBookAgent.Object))
                .Calling(x => x.GetAllBooks())
                .ShouldReturn()
                .Json()
                .WithResponseModel(_books);
        }

        [Test]
        public void GetAllBooks_CallsBookAgentGetBooks()
        {
            var controller = new LibraryController(_mockBookAgent.Object);

            controller.GetAllBooks();

            _mockBookAgent.Verify(x => x.GetBooks());
        }
    }
}
