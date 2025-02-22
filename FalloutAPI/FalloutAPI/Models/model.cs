using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/*------------------------------------------------
                Enity Models
This is where the shape of the employee entity data 
is defined. This is the model of the data that the 
database and all layers expect to see.
------------------------------------------------*/

namespace FalloutAPI.Models
{
    //Data Model to match the database

    public class SettlementContext: DbContext
    {
        public SettlementContext(DbContextOptions<SettlementContext> options)
            : base(options)
        { }

        public DbSet<Settlement> Settlements { get; set; }
    }

    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }

    public class Settlement
    {
        public long ID {get; set;}
        public string Name {get; set;}
        [Column("numSettlers")]
        public int? NumSettlers {get; set;}
        public bool? Walls {get; set;}
        public bool? Defenses {get; set;}
        public bool? Armored {get; set;}
        public bool? Weaponized {get; set;}
        public string Area {get; set;}
        public bool? Full {get; set;}
    }

    public class Employee 
    { 
        public long ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
    }
}
