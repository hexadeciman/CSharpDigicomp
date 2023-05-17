using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace WCFHost
{
    public class Book
    {
        public string id;
        public string title;
        public string description;
        public Book(string _id, string _title, string _description)
        {
            this.id = _id;
            this.title = _title;
            this.description = _description;
        }
    }
}