Employee employee1 = new Employee { FirstName = "Fidel", Department = "Maths", YearOfResumption = 2017 };
Employee employee2 = new Employee { FirstName = "Francis", Department = "Software", YearOfResumption = 2018 };
Employee employee3 = new Employee { FirstName = "Ahmed", Department = "Maths", YearOfResumption = 2018 };
Employee employee4 = new Employee { FirstName = "Ebuka", Department = "Software", YearOfResumption = 2017 };

Employee[] employees = new Employee[] { employee1, employee2, employee3, employee4 };

Console.WriteLine("Software Department");
IEnumerable<Employee> softwareEmployees = GetEmployee.GetEmployeeBy(
  new EmployeeDepartmentSpecification("Software"), employees);
foreach (var employee in softwareEmployees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.WriteLine("Employed in 2017");
IEnumerable<Employee> employedIn2017 = GetEmployee.GetEmployeeBy(
  new EmployeeYearSpecification(2017), employees);
foreach (var employee in employedIn2017)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

AndSpecification yearAndDepartment = new AndSpecification(
  new EmployeeDepartmentSpecification("Software"),
  new EmployeeYearSpecification(2016));
Console.WriteLine("List of Software Staff Employed in 2016");
IEnumerable<Employee> software2016Employees = GetEmployee.GetEmployeeBy(yearAndDepartment, employees);
foreach (var employee in software2016Employees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.WriteLine("List of Staff either in Software or Employed in 2016");
OrSpecification yearOrDepartment = new OrSpecification(
  new EmployeeDepartmentSpecification("Software"),
  new EmployeeYearSpecification(2016));
IEnumerable<Employee> softwareOr2016Employees = GetEmployee.GetEmployeeBy(yearOrDepartment, employees);
foreach (var employee in softwareOr2016Employees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.WriteLine("List of Staff neither in Software nor Employed in 2016");
NORSpecification yearNorDepartment = new NORSpecification(
  new EmployeeDepartmentSpecification("Software"),
  new EmployeeYearSpecification(2016));
IEnumerable<Employee> softwareNor2016Employees = GetEmployee.GetEmployeeBy(yearNorDepartment, employees);
foreach (var employee in softwareNor2016Employees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.WriteLine("List of Staff who are not in Software or not Employed in 2016 or both");
NANDSpecification yearNandDepartment = new NANDSpecification(
  new EmployeeDepartmentSpecification("Software"),
  new EmployeeYearSpecification(2016));
IEnumerable<Employee> softwareNand2016Employees = GetEmployee.GetEmployeeBy(yearNandDepartment, employees);
foreach (var employee in softwareNand2016Employees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.WriteLine("List of Staff who are not in Software");
NotSpecification notDepartment = new NotSpecification(
  new EmployeeDepartmentSpecification("Software"));
IEnumerable<Employee> notSoftwareEmployees = GetEmployee.GetEmployeeBy(notDepartment, employees);
foreach (var employee in notSoftwareEmployees)
  Console.WriteLine(employee.FirstName);

Console.WriteLine();

Console.ReadKey();
