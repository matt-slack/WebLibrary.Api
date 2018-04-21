using System.Collections.Generic;
using System.Web.Http;
using WebLibrary.Api.DAL;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.Controllers
{
    public class LibraryController : ApiController
    {
        private readonly IBookAgent _bookAgent;

        public LibraryController()
        {
            _bookAgent = new BookAgent();
        }

        public LibraryController(IBookAgent bookAgent)
        {
            _bookAgent = bookAgent;
        }

        [Route("books/")]
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            return Json(_bookAgent.GetBooks());
        }
    }
}