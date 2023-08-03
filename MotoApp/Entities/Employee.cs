namespace MotoApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString() => $"Employee {Id} Name: {FirstName}";
    }
}
