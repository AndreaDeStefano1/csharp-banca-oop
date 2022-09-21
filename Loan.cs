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
        Flat = amount / FlatsNumber( end, start); // la rata è uguale a importo diviso numero di rate
        Start = start;
        End = end;
    }

    // calcolo numero di rate
    public static int FlatsNumber(DateTime dateEnd, DateTime dateStart)
    {
        int flatsNumber;
        
        return flatsNumber = ((dateEnd.Year - dateStart.Year) * 12) + (dateEnd.Month - dateStart.Month);
           
    }
}