// See https://aka.ms/new-console-template for more information
class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    public double Salary { get; set; }

    public User(string name, string surname, string fiscalCode, double salary)
    {
        Name = name;
        Surname = surname;
        FiscalCode = fiscalCode;
        Salary = salary;
    }
}
