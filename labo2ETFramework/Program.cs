using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo2ETFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 0;
            TetsEntities contexte = new TetsEntities();
            foreach (Student s in contexte.Student)
            {
                foreach(Course c in contexte.Course)
                {
                    if (id != s.Id)
                    {
                        Console.Write(s.FullName + "\n");
                    }
                    Console.Write(c.Description +"\n");
                    id = (int)s.Id;
                }
                
            }
            Console.ReadKey();
        }
    }
}
