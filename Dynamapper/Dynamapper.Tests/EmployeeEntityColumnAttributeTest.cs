using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamapper.Tests
{
    public class EmployeeEntityColumnAttributeTest
    {
        public int Id { get; set; }

        [Column("Name")]
        public string EmployeeName { get; set; }

        [Column("Age")]
        public int? EmployeeAge { get; set; }

        [Column("Salary")]
        public decimal EmployeeSalary { get; set; }
    }
}
