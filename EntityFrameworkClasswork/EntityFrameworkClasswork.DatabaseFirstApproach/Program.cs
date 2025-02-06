// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Data;
using ConsoleApp1.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        ForkDbContext context = new ForkDbContext();

        Console.WriteLine(context.Users.Count());
    }
}