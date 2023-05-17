using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace MVCCSharp.Models
{
    /*
     * Package Manager Console
     * Add-Migration InitialCreate
     * Update-Database
     */
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Book()
        {
            Random r = new Random();
            string t = "testTitle";
        }

    }
}
