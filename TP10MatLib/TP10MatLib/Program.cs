// See https://aka.ms/new-console-template for more information
using CalcLib;

Console.WriteLine("Hello, World!");
Console.WriteLine(Calculator.Add(1, 2));

try
{
    Console.WriteLine(Calculator.Div(1, 0));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}