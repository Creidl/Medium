namespace MotoApp.Entities
{
    internal class Manager: Employee
    {
        public override string ToString()
        {
            return base.ToString() + " (Manager)";
        }
    }
}
