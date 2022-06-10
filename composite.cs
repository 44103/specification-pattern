public abstract class CompositeSpecification : IEmployeeSpecification
{
  protected IEmployeeSpecification specification1;
  protected IEmployeeSpecification specification2;
  public CompositeSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2)
  {
    specification1 = spec1;
    specification2 = spec2;
  }
  public abstract bool IsSatisfiedBy(Employee employee);
}

public class AndSpecification : CompositeSpecification
{
  public AndSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
  public override bool IsSatisfiedBy(Employee employee)
  {
    return specification1.IsSatisfiedBy(employee) && specification2.IsSatisfiedBy(employee);
  }
}
public class OrSpecification : CompositeSpecification
{
  public OrSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
  public override bool IsSatisfiedBy(Employee employee)
  {
    return specification1.IsSatisfiedBy(employee) || specification2.IsSatisfiedBy(employee);
  }
}
public class NORSpecification : CompositeSpecification
{
  public NORSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
  public override bool IsSatisfiedBy(Employee employee)
  {
    return !(specification1.IsSatisfiedBy(employee) || specification2.IsSatisfiedBy(employee));
  }
}
public class NANDSpecification : CompositeSpecification
{
  public NANDSpecification(IEmployeeSpecification spec1, IEmployeeSpecification spec2) : base(spec1, spec2) { }
  public override bool IsSatisfiedBy(Employee employee)
  {
    return !(specification1.IsSatisfiedBy(employee) && specification2.IsSatisfiedBy(employee));
  }
}
public class NotSpecification : IEmployeeSpecification
{
  private IEmployeeSpecification specification;
  public NotSpecification(IEmployeeSpecification spec)
  {
    specification = spec;
  }
  public bool IsSatisfiedBy(Employee employee)
  {
    return !specification.IsSatisfiedBy(employee);
  }
}
