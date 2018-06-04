using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] persons = { "Müller", "Meyer", "Schmitt", "MirMohammadi" };

            //Klassisch
            var found = Suche(persons, "r");
            Print(found);

            //Extension
            found = persons.Suche("r");
            Print(found);

            //Func, Action
            Func<string, bool> kriterium = new Func<string, bool>(Suche);
            found = persons.Suche(kriterium);
            Print(found);

            //Lambda
            found = persons.Suche(
                    (string s)
                    =>
                        {
                            return s.Contains("r");
                        }
                );
            Print(found);

            //Lambda Expression
            found = persons.Suche((s)=> s.Contains("m"));
            Print(found);

            //Methods on List<T>
            List<string> personList = new List<string>(persons);
            personList = personList.FindAll(s => s.Contains("r"));

            Print(personList);

            personList.Sort((p1, p2) => p2.CompareTo(p1));

            Print(personList);

            //Extension on IEnumerable<T>
            IEnumerable<string> query = persons.Where(p => p.Contains("r")).OrderByDescending(p => p);
            Print(query);

            IEnumerable<string> query2 = from p in persons
                where p.Contains("r")
                orderby p descending
                select p;
            Print(query2);


        }

        private static List<string> Suche(string[] list, string kriterium)
        {
            List<string> output = new List<string>();
            foreach (string s in list)
            {
                if (s.Contains(kriterium))
                {
                    output.Add(s);
                }
            }
            return output;
        }

        private static bool Suche(string arg)
        {
            return arg.Contains("m");
        }

        private static void Print(IEnumerable<string> list)
        {
            Console.WriteLine("-----------------");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("-----------------");
        }
    }
}
