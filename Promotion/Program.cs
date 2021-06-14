using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;

namespace Promotion
{
    delegate bool DelegatePromoter(Person emp);
    delegate bool DelegateHiring(Intern internship);
    
    [Serializable]
    class Promotion
    {
        public static void Main()
        {
            List<Person> employees = new List<Person>();
            employees.Add(new Person(name: "John", id: 1) {HireDate = DateTime.Now, Salary = 2500, Experience = 5});
            employees.Add(new Person(name: "John", id: 2) {HireDate = DateTime.Now, Salary = 8500, Experience = 9});
            employees.Add(new Person(name: "Ronald", id: 3) {HireDate = DateTime.Now, Salary = 6500, Experience = 4});
            employees.Add(new Person(name: "Mary", id: 4) {HireDate = DateTime.Now, Salary = 3500, Experience = 2});
            employees.Add(new Person(name: "Randy", id: 5) {HireDate = DateTime.Now, Salary = 1000, Experience = 1});

            List<Intern> interns = new List<Intern>();
            interns.Add(new Intern(name: "Tony", id: 1, education: "Bachelor", hire: true));
            interns.Add(new Intern(name: "Rory", id: 2, education: "Master", hire: false));
            interns.Add(new Intern(name: "Barbara", id: 3, education: "Specialist", hire: true));

            DelegatePromoter prom = new DelegatePromoter(Promote);
            Person.Promotion(employees, prom);

            DelegateHiring hir = new DelegateHiring(Hiring);
            Intern.Hiring(interns, hir);
            
            Serializer();

            static async void Serializer()//ну оно записывает...
            {
                using (FileStream fs = new FileStream("interns.json", FileMode.OpenOrCreate))
                {
                    Intern jack = new Intern(name: "Jack", education: "Bachelor", hire: true, id: 9);
                    await JsonSerializer.SerializeAsync<Intern>(fs, jack);
                    Console.WriteLine("Data has been save to file");
                }

                using (FileStream fs = new FileStream("interns.json", FileMode.OpenOrCreate))
                {
                    Intern restoredIntern = await JsonSerializer.DeserializeAsync<Intern>(fs);
                    Console.WriteLine($"Name: {restoredIntern.Name}  Age: {restoredIntern.EducationLvl}");
                }
            }

        }
        
        public static bool Promote(Person worker)
        {
            if (worker.Salary < 4000 && worker.Experience >= 2) 
            {
                return true;
            }
            return false;

        }

        public static bool Hiring(Intern worker)
        {
            if (worker.Hire)
            {
                return true;
            }

            return false;
        }
    }


    
}