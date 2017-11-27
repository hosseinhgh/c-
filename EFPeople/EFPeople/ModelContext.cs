using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class ModelContext : DbContext
    {
        public ModelContext() : base("name=SecretDatabase2")
        {           
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
