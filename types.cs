public class Employee
{
  public string EmployeeID { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Department { get; set; }
  private int _yearOfResumption;
  public int YearOfResumption
  {
    get { return _yearOfResumption; }
    set
    {
      if (value > DateTime.Now.Year)
        _yearOfResumption = DateTime.Now.Year;
      else
        _yearOfResumption = value;
    }
  }
}

public interface IEmployeeSpecification
{
  bool IsSatisfiedBy(Employee employee);
}

public class EmployeeDepartmentSpecification : IEmployeeSpecification
{
  private readonly string _department;

  public EmployeeDepartmentSpecification(string depatrment)
  {
    _department = depatrment;
  }

  public bool IsSatisfiedBy(Employee employee)
  {
    return employee.Department.Equals(_department);
  }
}

public class EmployeeYearSpecification : IEmployeeSpecification
{
  private readonly int _year;

  public EmployeeYearSpecification(int year)
  {
    _year = year;
  }
  public bool IsSatisfiedBy(Employee employee)
  {
    return employee.YearOfResumption.Equals(_year);
  }
}

public class GetEmployee
{
  public static IEnumerable<Employee> GetEmployeeBy(IEmployeeSpecification specification, Employee[] employees)
  {
    return employees.Where(employee => specification.IsSatisfiedBy(employee));
  }
}
