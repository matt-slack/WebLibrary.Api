using System;
using System.Collections.Generic;

namespace WebLibrary.Api.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal RentPrice { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}