using System;
using Domain.Entities.Types;

namespace Domain.Entities.Persons
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public virtual Fief Fief { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Resources { get; set; }
        public int Loyalty { get; set; }
        public int Age { get; set; }
    }
}