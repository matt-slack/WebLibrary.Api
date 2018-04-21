using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary.Api.Models
{
    public class BookSupply
    {
        public bool InStock { get; set; }
        public int StockCount { get; set; }
        public List<Book> Books { get; set; }
    }
}
