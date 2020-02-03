using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities.Types
{
    public class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public string Type { get; set; }
        public int BaseCost { get; set; }
        public int LuxuryCost { get; set; }
    }
}