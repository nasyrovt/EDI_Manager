namespace EDI_Manager.TableDefinitions
{
    public class Child : Person
    {
        public int ChildId { get { return Id; } set { base.Id = value; } }
    }
}
