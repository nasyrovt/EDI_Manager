namespace EDI_Manager.TableDefinitions
{
    public class Employee : Person
    {
        public int EmployeeId { get { return Id; } set { base.Id = value; } }
    }
}
