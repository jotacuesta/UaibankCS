namespace UaiBank.Models;

public class User
{
    // The id field is a readonly value, it cannot be changed after the instance is created
    public long Id { get; }
    // The others field may be changed over time due to errors in the registration
    public string Name { get; set; }
    public int Age { get; set; }
    public double Balance { get; set; }

    public User(long id, string name, int age, double balance)
    {
        Id = id;
        Name = name;
        Age = age;
        Balance = balance;
    }
}