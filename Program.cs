// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");
Banca B = new Banca();


Menu:
Console.WriteLine("Azioni:");
Console.WriteLine("1. Aggiungi Utente:");
Console.WriteLine("2. Modifica Utente:");
Console.WriteLine("3. Cerca Utente");
Console.WriteLine();
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
        Console.WriteLine("Inserisc il codicer fiascale dell utente da modificare");
        string inputFiscalCode = Console.ReadLine();
        B.ModifyUser(B.GetUser(inputFiscalCode));
        goto Menu;
    case 3:
        
        goto Menu;
}
   

class Banca
{
    List<User> users = new List<User>();
    List<Loan> loans = new List<Loan>();    

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

    public void SetLoan(int id, User user, double amount, double flat, DateTime start, DateTime end)
    {
        Loan l = new Loan(id, user, amount, flat, start, end);
    }

    public Loan GetLoan(string fiscalCode)
    {
        foreach (Loan loan in loans)
        {
            if (loan.User.FiscalCode.Contains(fiscalCode))
            {
                return loan;
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
    }public void Print(Loan  user)
    {
        Console.WriteLine("Nome: {0}", user.Name);
        Console.WriteLine("Cognome: {0}", user.Surname);
        Console.WriteLine("Codice Fiscale: {0}", user.FiscalCode);
        Console.WriteLine("Stipendio: {0}", user.Salary);
    }
}