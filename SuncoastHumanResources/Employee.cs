namespace SuncoastHumanResources
{
  class Employee
  {
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Department { get; set; }
    public int MonthlySalary()
    {
      return Salary / 12;
    }
  }
}
