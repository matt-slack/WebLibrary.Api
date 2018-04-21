using System.Collections.Generic;
using WebLibrary.Api.Models;

namespace WebLibrary.Api.DAL
{
    public interface IBookAgent
    {
        BookSupply GetBooks();
    }
}