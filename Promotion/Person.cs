using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion
{
    [Serializable]
    class Person
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }
        public DateTime HireDate { get; set; }

        public Person(int id, string name)
        {
            ID = id;
            Name = name;

        }
        
        public static void Promotion(List<Person> employees, DelegatePromoter needPromote)
        {
            foreach (Person employee in employees)
            {
                if (needPromote(employee))
                {
                    Console.WriteLine(employee.Name + " needs to be promoted. " + "New salary: " + employee.Salary * 1,5);
                }
            }
        }

        public static void Hiring(List<Intern> interns, DelegateHiring needHire)
        {
            foreach (Intern intern in interns)
            {
                if (needHire(intern))
                {
                    Console.WriteLine(intern.Name + " is hiring.");
                    
                }
            }
        }
    }
}