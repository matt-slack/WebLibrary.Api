using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibrary.Api.Models;
using System.Net.Http;

namespace WebLibrary.Api.DAL
{
    public interface IParser
    {
        BookSupply Parse(HttpResponseMessage message);
    }
}
