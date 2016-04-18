using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROPOT_System
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Creating role");
                Role role = new Role();
                Console.Write("Enter role name: ");
                role.Name = Console.ReadLine();
                Console.Write("Enter role description: ");
                role.Description = Console.ReadLine();
                db.Roles.Add(role);
                db.SaveChanges();

                var query = from r in db.Roles
                            select r;

                Console.WriteLine("Role from localdb: ");
                foreach(var item in query)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Name: " + item.Name);
                    Console.WriteLine("Description: " + item.Description);
                }
            }
        }
    }
}
