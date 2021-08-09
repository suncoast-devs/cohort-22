namespace FirstBankOfSuncoast
{
  public class Transaction
  {
    // Checking or Savings
    public string Account { get; set; }

    // How much
    public int Amount { get; set; }

    // Deposit or Withdraw
    public string Type { get; set; }

    // Behavior
    //
    // Name:     Description
    // Input:    nothing? (we have everything as properties)
    // Output:   string (containing the description)
    // Work:     Combine the properties into a description string
    // Access:   Does the outside world need to access this? true
    //           We want our PROGRAM to be able to call for a TRANSACTION Description
    public string Description()
    {
      return Bannerize($"{Type} of ${Amount} to {Account}");
    }

    // Behavior
    //
    // Name:     Bannerize (not bruce/Hunk, but with stars)
    // Input:    string
    // Output:   string (but with stars)
    // Work:     Make a string of stars then the input then more stars
    // Access:   Does the outside world need to access this? false
    private string Bannerize(string message)
    {
      return "********************************\n" + message + "********************************\n";
    }
  }
}