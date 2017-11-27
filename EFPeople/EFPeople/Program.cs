using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Person p = new Person { Name = "Jerry", Age = rand.Next(1,150) };
            using (ModelContext ctx = new ModelContext()) // connect to database
            {
                ctx.People.Add(p); // schedule Person to be Inserted into table
                ctx.SaveChanges(); // execute all changes done up to that point
                Console.WriteLine("Person persisted");

                var people = (from r in ctx.People select r).ToList<Person>();

                foreach (var pp in people)
                {
                    Console.WriteLine("P({0}): {1}, {2}", pp.PersonId, pp.Name, pp.Age);
                }
                // Update
                int newAge = rand.Next(1, 150);
                Console.WriteLine("Updating age of first Person to {0}", newAge);
                Person p1 = people[0];
                p1.Age = newAge;
                ctx.SaveChanges();
                // Delete method 1: fetch then delete
                var ptdList = (from r in ctx.People where r.PersonId == 2 select r).ToArray<Person>();
                if (ptdList.Length != 0)
                {
                    Person ptd = ptdList.First<Person>();
                    Console.WriteLine("PTD({0}): {1}, {2}", ptd.PersonId, ptd.Name, ptd.Age);
                    ctx.People.Remove(ptd); // schedule record for removal
                    ctx.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Record to delete not found");
                }
            }

            using (ModelContext ctx = new ModelContext()) // connect to database
            { 
                // Delete method 2: attach then delete
                Person ptd2 = new Person { PersonId = 3 };
                ctx.People.Attach(ptd2);
                ctx.People.Remove(ptd2);
                if (ctx.Entry(ptd2).State != System.Data.Entity.EntityState.Deleted)
                {                    
                    ctx.SaveChanges();
                } else
                {
                    Console.WriteLine("Record to delete not found (method 2)");
                }
            }
            Console.ReadKey();
        }
    }
}
