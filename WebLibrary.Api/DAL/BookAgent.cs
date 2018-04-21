using System.Collections.Generic;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.DAL
{
    public class BookAgent : IBookAgent
    {
        private readonly IProxy _proxy;
        private readonly IParser _parser;

        public BookAgent()
        {
            _proxy = new Proxy();
            _parser = new Parser();
        }

        public BookAgent(IProxy proxy, IParser parser)
        {
            _proxy = proxy;
            _parser = parser;            
        }

        public BookSupply GetBooks()
        {
            return _parser.Parse(_proxy.FetchData());
        }
    }
}