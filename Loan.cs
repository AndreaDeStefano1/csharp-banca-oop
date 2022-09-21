// See https://aka.ms/new-console-template for more information

class Loan
{
    public int Id { get; set; }
    public User User { get; set; }
    public double Amount { get; set; }  
    public double Flat { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public Loan(int id, User user, double amount, double flat, DateTime start, DateTime end)
    {
        Id = id;
        User = user;
        Amount = amount;
        Flat = flat;
        Start = start;
        End = end;
    }
}