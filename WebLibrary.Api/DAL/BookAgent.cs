using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.DAL
{
    public class BookAgent : IBookAgent
    {
        public List<Book> GetBooks()
        {
            return new List<Book>();
        }
    }
}