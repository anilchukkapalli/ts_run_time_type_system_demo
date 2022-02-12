
class Customers{
    public static IEnumerable<Customer> GetFakeCustomers() 
        => Enumerable.Range(1, 10).Select(i => new Customer(
            FirstName: Faker.Name.First(),
            LastName: Faker.Name.Last(),
            Id: $"c{i}",
            Address: new Address
            (
                Street: Faker.Address.StreetAddress(),
                City: Faker.Address.City(),
                State: Faker.Address.UsStateAbbr(),
                Zip: Faker.Address.ZipCode()
            )
        ));
}

record struct Customer(string Id, string FirstName, string LastName, Address Address);

record struct Address(string Street, string City, string State, string Zip);