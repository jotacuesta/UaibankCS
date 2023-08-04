// See https://aka.ms/new-console-template for more information

using UaiBank.Models;
using UaiBank.Services;

BankService bankMainService = new BankService();
string command = "";

Console.WriteLine("\t\t _     _       _ _                 _     ");
Console.WriteLine("\t\t| |   | |     (_) |               | |    ");
Console.WriteLine("\t\t| |   | | ____ _| | _   ____ ____ | |  _ ");
Console.WriteLine("\t\t| |   | |/ _  | | || \\ / _  |  _ \\| | / )");
Console.WriteLine("\t\t| |___| ( ( | | | |_) | ( | | | | | |< ( ");
Console.WriteLine("\t\t \\______|\\_||_|_|____/ \\_||_|_| |_|_| \\_)");
Console.WriteLine("\nWelcome to UaiBank !!\n\n");
do
{
    Console.WriteLine("How can we assist you today?");
    Console.WriteLine("\t - Type 1 to register a user");
    Console.WriteLine("\t - Type 2 to register multiple users");
    Console.WriteLine("\t - Type 3 to search for a user");
    Console.WriteLine("\t - Type 4 to delete a user");
    Console.WriteLine("\t - Type 5 to perform a transfer between two clients");
    Console.WriteLine("\t - Type 6 to export the database to a file");
    Console.WriteLine("\t - Type 0 to exit");
    
    command = Console.ReadLine();

    switch (command)
    {
        case "1" : 
            Console.WriteLine("1");
            break;
        case "0" :
            Console.WriteLine("Bye bye");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }

} while (!command.Equals("0"));

