namespace UaiBank.Models;

// The main class of the program, it will store the list of clients from which we'll perform the tasks
public class Bank
{
    public List<User> Clients { get; set; }

    public Bank()
    {
        Clients = new List<User>();
    }
}