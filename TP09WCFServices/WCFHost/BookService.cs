using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFHost;
namespace WCFHost
{
    public class BookService : IBookService
    {
        Book[] books;
        public string GetBooks()
        {
            Console.WriteLine("FetchinBooks");
            books = new Book[] {
            new Book("id1", "title1", "description1"),
            new Book("id2", "title2", "description2"),
            new Book("id3", "title3", "description3"),
        };
            return JsonConvert.SerializeObject(books);
        }
    }
}
