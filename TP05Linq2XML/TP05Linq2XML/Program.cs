using System.Xml;
using System.Xml.Linq;
using TP05Linq2XML;

internal class Program
{
    private static void Main(string[] args)
    {
        XElement root = XElement.Load("Students.xml");
        var students = root.Descendants("student")
            .Select(student => {
                    string firstName = student.Attribute("FirstName").Value;
                    string lastName = student.Attribute("LastName").Value;
                    return new Student(firstName, lastName);
                });
            // .Where(student => student.StartsWith("T"))
            // .OrderBy(student => student)
            // .ToList();
        
        foreach(Student student in students)
        {
            Console.WriteLine(student.GetName());
        }
        
        Console.ReadLine();

    }
} 