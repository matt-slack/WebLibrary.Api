using System.Web.Http;
using WebLibrary.Api.DAL;

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
        public IHttpActionResult GetAllBooks() => 
            Json(_bookAgent.GetBooks());
    }
}