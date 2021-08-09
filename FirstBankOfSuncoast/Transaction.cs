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
  }
}