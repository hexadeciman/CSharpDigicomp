using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * (?<atLeast8Char>.{9,}) 
             * (?<atLeast2Upper>^(.*?[A-Z]){2,}.*$)
             * (?<atLeast2ConsecutiveLower>\b\w*[a-z]{2}\w*\b)
             * (?<atLeast2Numbers>^(.*?\d){2,}.*$)
             * (?<atLeast1SpecialChar>.*[!@#$%^&*(),.?:{}|<>~].*)
             * (?<noSpace>^[^\s]*$)");
             */
            string input = "abBDefghi!jkl78";
            Regex regex = new Regex(@"(?=^(.*?[A-Z]){2,}.*$)(?=.{9,})(?=\b\w*[a-z]{2}\w*\b)(?=^(.*?\d){2,}.*$)(?=.*[!@#$%^&*(),.?:{}|<>~].*)(?=^[^\s]*$).*$");
            checkRegex(input, regex);
            Console.ReadLine();
        }

        static void checkRegex(string input, Regex r)
        {
            GroupCollection groups2 = r.Match(input).Groups;
            foreach (string groupName in r.GetGroupNames())
            {
                Console.WriteLine(
                   "Group: {0}, Value: {1}",
                   groupName,
                   groups2[groupName].Value);
            }
        }
    }
}
