﻿namespace MotoApp.Data.Entities
{
    internal class Manager : Employee
    {
        public override string ToString()
        {
            return base.ToString() + " (Manager)";
        }
    }
}
