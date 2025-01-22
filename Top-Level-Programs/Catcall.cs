// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;

Console.WriteLine("Hello, World!");
string catcall = "Meow";
int meows = 3;

Console.WriteLine($"The cat will meow {meows} times.");

for (int count = 1; count <= meows; count++)
{
    Console.WriteLine("{0}. That's {1}!", catcall, count);
}
