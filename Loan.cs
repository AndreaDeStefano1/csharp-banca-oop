// See https://aka.ms/new-console-template for more information

class Loan
{
    public static int lastId = 1;
    public int Id { get; set; }
    public User User { get; set; }
    public double Amount { get; set; }  
    public double Flat { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public Loan( User user, double amount, DateTime start, DateTime end)
    {
        Id = Loan.lastId++;
        User = user;
        Amount = amount;
        Flat = amount / FlatsNumber(Banca.loans, user); // la rata è uguale a importo diviso numero di rate
        Start = start;
        End = end;
    }

    // calcolo numero di rate
    public static int FlatsNumber(List<Loan> loans, User user)
    {
        int flatsNumber = -1;
        foreach (Loan loan in loans)
        {
            if (loan.User == user)
            {
                DateTime date2 = loan.Start;
                DateTime date1 = loan.End;


                return flatsNumber = ((date1.Year - date2.Year) * 12) + (date1.Month - date2.Month);
            }
        }
        return flatsNumber;
    }
}