using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using TP03Dynamics;

internal class TP03Prog
{
    private static void Main(string[] args)
    {
        var x = 1;
        dynamic y = 1;

        Console.WriteLine($"x type: {x.GetType()}"); 
        Console.WriteLine($"y type: {y.GetType()}");

        /* try
        {
            x = "X";
        } catch {
            Console.WriteLine("Can't assign new type to var");
        }
        */
        y = "y";
        Console.WriteLine($"y type: {y.GetType()}");

        y = new Dog();
        Console.WriteLine(y.Bark("Who let the dogs out ?"));

        dynamic d = new ExpandoObject();

        ((INotifyPropertyChanged)d).PropertyChanged += (d, args) =>
        {
            Console.WriteLine($"Property {args.PropertyName} changed");
            dynamic obj = d;

            switch (args.PropertyName)
            {
                case "FirstName":
                    //You Code
                    Console.WriteLine($"value of FirstName: {obj.FirstName}");
                    break;
            }
        };

        d.FirstName = "Jean Marc";
        d.LastName = "Chasselas";
        d.PrintFullName = new Func<string>(() => $"{d.FirstName} {d.LastName}");
        Action printFNAction = () => Console.WriteLine($"del: {d.FirstName} {d.LastName}");
        d.DelPrint = printFNAction;
        d.DelPrint();

    }
}