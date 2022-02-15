namespace Demo.Core.Entities;
public class Customer
{
    public Customer(Guid customerId, string firstName, string lastName, DateTime dateOfBirth)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public Guid CustomerId { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public DateTime DateOfBirth { get; init; }
}