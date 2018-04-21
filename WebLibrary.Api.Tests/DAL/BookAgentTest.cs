using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using MyTested.WebApi;
using Newtonsoft.Json;
using NUnit.Framework;
using WebLibrary.Api.DAL;
using WebLibrary.Api.Models;
using System.Net.Http;

namespace WebLibrary.Api.Tests.DAL
{
    [TestFixture]
    public class BookAgentTest
    {
        private Mock<IParser> _mockParser;
        private Mock<IProxy> _mockProxy;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockParser = new Mock<IParser>();
            _mockProxy = new Mock<IProxy>();
            _mockParser.Setup(x => x.Parse(It.IsAny<HttpResponseMessage>())).Returns(new BookSupply());
            _mockProxy.Setup(x => x.FetchData()).Returns(new HttpResponseMessage());
        }

        [Test]
        public void GetBooks_CallsDataProxy_Once()
        {

            var bookAgent = new BookAgent(_mockProxy.Object, _mockParser.Object);

            bookAgent.GetBooks();

            _mockProxy.Verify(x => x.FetchData());
        }

        [Test]
        public void GetBooks_CallsParser_Once()
        {
            var bookAgent = new BookAgent(_mockProxy.Object, _mockParser.Object);

            bookAgent.GetBooks();

            _mockParser.Verify(x => x.Parse(It.IsAny<HttpResponseMessage>()));
        }

        [Test]
        public void GetBooks_WhenParserIsCalled_UsesProxyDataResponse()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("My Content in here")
            };
            var bookSupply = _fixture.Create<BookSupply>();

            _mockParser.Setup(x => x.Parse(httpResponseMessage)).Returns(bookSupply);
            _mockProxy.Setup(x => x.FetchData()).Returns(httpResponseMessage);

            var bookAgent = new BookAgent(_mockProxy.Object, _mockParser.Object);

            bookAgent.GetBooks();

            _mockParser.Verify(x => x.Parse(httpResponseMessage));
        }

        [Test]
        public void GetBooks_GivenValidData_ReturnsPopulatedBookSupply()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("My Content in here")
            };

            var bookSupply = _fixture.Create<BookSupply>();

            _mockParser.Setup(x => x.Parse(httpResponseMessage)).Returns(bookSupply);
            _mockProxy.Setup(x => x.FetchData()).Returns(httpResponseMessage);

            var bookAgent = new BookAgent(_mockProxy.Object, _mockParser.Object);

            var actual = bookAgent.GetBooks();

            Assert.AreEqual(actual, bookSupply);
        }
    }
}
