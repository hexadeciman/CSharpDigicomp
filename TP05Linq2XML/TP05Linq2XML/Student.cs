using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05Linq2XML
{
    public class Student
    {
        private string firstName;
        private string lastName;
        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string GetName()
        {
            return $"{firstName} {lastName}";
        }
    }
}
