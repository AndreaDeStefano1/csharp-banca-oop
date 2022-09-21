// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");
Banca B = new Banca();


Menu:
Console.WriteLine("Azioni:");
Console.WriteLine("1. Aggiungi Utente:");
Console.WriteLine("2. Modifica Utente:");
Console.WriteLine("3. Cerca Utente");
Console.WriteLine("4. Aggiungi Prestito");
Console.WriteLine("5. Cerca Prestito");
Console.WriteLine("11 test");
int input = Convert.ToInt32(Console.ReadLine());
switch(input){
    case 1:
        Console.WriteLine("Inserisci il nome:");
        string name = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome");
        string surname = Console.ReadLine();    
        Console.WriteLine("Inserisci il codice fiscale");
        string fiscalcode = Console.ReadLine().ToUpper();

        Console.WriteLine("Inserisci lo stipendio");
        double salary = Convert.ToDouble(Console.ReadLine());   
        B.SetUser(name, surname,fiscalcode,salary);
        goto Menu;

    case 2:
        Console.WriteLine("Inserisc il codicer fiascale dell'utente da modificare");
        string inputFiscalCode = Console.ReadLine();
        B.ModifyUser(B.GetUser(inputFiscalCode));
        goto Menu;

    case 3:
        Console.WriteLine("Inserisc il codice fiscale dell'utente da cercare");
        string inputSearch = Console.ReadLine();
        B.Print(B.GetUser(inputSearch));
        goto Menu;

    case 4:
        Console.WriteLine("Per quale utente vuoi inserire il prestito? Inserisci il codice Fiscale");
        string fiscalCode = Console.ReadLine().ToUpper();
        User userToLoan = B.GetUser(fiscalCode);
        Console.WriteLine("Importo prestito: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Inizio prestito (YYYY/MM/DD)");
        DateTime start = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Fine prestito (YYYY/MM/DD)");
        DateTime end = Convert.ToDateTime(Console.ReadLine());
        B.SetLoan(userToLoan, amount, start, end);
        goto Menu;

    case 5:
        Console.WriteLine("inserisci il codice fiscale dell'utente");
        fiscalCode = Console.ReadLine().ToUpper();
        B.Print(B.GetLoan(fiscalCode));
        break;
    
    case 11:

        break;
}
   

class Banca
{
    List<User> users = new List<User>();
    public static List<Loan> loans = new List<Loan>();    

    public void SetUser(string name, string surname, string fiscalCode, double salary)
    {
        User u = new User(name, surname, fiscalCode, salary);   
        users.Add(u);   
    }

    
    public User GetUser(string fiscalCode)
    {
        foreach (User user in users)
        {
            if (user.FiscalCode.Contains(fiscalCode))
            {
                return user;
            }
        }
        return null;
    }

    
    public void ModifyUser(User user)
    {
        users.IndexOf(user);
        
        Console.WriteLine("Vuoi modificare");

        Console.Write("Nome [{0}] (1 = si) (2 = no)", user.Name);
        int userInput = Convert.ToInt32(Console.ReadLine());
        if(userInput == 1)
        {
            user.Name = Console.ReadLine();
        }

        Console.WriteLine("Cognome [{0}] (1 = si) (2 = no) ", user.Surname);
        userInput = Convert.ToInt32(Console.ReadLine());
        if (userInput == 1)
        {
            user.Surname = Console.ReadLine();
        }

        Console.WriteLine("Codice Fiscale [{0}] (1 = si) (2 = no) ", user.FiscalCode);
        userInput = Convert.ToInt32(Console.ReadLine());
        if (userInput == 1)
        {
            user.FiscalCode = Console.ReadLine().ToUpper();
        }

        Console.WriteLine("Stipendio [{0}] (1 = si) (2 = no) ", user.Salary);
        userInput = Convert.ToInt32(Console.ReadLine());
        if (userInput == 1)
        {
            user.Salary = Convert.ToDouble(Console.ReadLine());
        }
    }

    
    public void SetLoan( User user, double amount, DateTime start, DateTime end)
    {
        Loan l = new Loan( user, amount, start, end);
        loans.Add(l);
    }

   
    public List<Loan> GetLoan(string fiscalCode)
    {
        List<Loan> loans = new List<Loan>();
        foreach (Loan loan in Banca.loans)
        {
            if (loan.User.FiscalCode.Contains(fiscalCode))
            {
                loans.Add(loan);
                return loans;
            }
        }
        return null;
    }
    
    
    public void Print(User user)
    {
        Console.WriteLine("Nome: {0}", user.Name);
        Console.WriteLine("Cognome: {0}", user.Surname);
        Console.WriteLine("Codice Fiscale: {0}", user.FiscalCode);
        Console.WriteLine("Stipendio: {0}", user.Salary);
    }
    
    
    public void Print(List<Loan> loans)
    {
        if (loans.Count == 0)
        {
            Console.WriteLine("vuoto");
        }
        foreach (Loan loan in loans)
        {
            Console.WriteLine();
            Console.WriteLine("ID: {0}", loan.Id);
            Console.WriteLine("Nome e cognome: {0}", loan.User.Name + " " + loan.User.Surname);
            Console.WriteLine("Importo del prestito: {0}", loan.Amount);
            Console.WriteLine("Importo rate: {0}", Math.Round(loan.Flat,2));
            Console.WriteLine("Data sottoscrizione: {0}", loan.Start);
            Console.WriteLine("Data di scadenza: {0}", loan.End);
            Console.WriteLine("Numero rate: {0}", Loan.FlatsNumber(loan.End, loan.Start));
            Console.WriteLine("---------------");
        }
    }



}