using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion
{
    [Serializable]
    public class Addition
    {
        void NewIntern(List<Intern> interns)
        {
        Console.WriteLine("Name of new employee?: "); 
        var newname = Console.ReadLine();
        Console.WriteLine("New ID? ");
        int newid = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Education Level? Bachelor, Specialist or Master? ");
        var neweducation = Console.ReadLine();
        Console.WriteLine("Do you want to hire that person? write true or false");
        bool newhire = Convert.ToBoolean(Console.ReadLine());

        var newint = new Intern(newid,newname,neweducation, newhire);
        interns.Add(newint);  
        }
    }
}
/*
 * если интерн принят то добавить его в список работников при этом id сделать "последний человек + 1"
 * добавить дату принятия на работу
*/