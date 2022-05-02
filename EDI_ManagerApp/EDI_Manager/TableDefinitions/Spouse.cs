namespace EDI_Manager.TableDefinitions
{
    public class Spouse: Person
    {
        public int SpouseId { get { return Id; } set { base.Id = value; } }
    }
}
