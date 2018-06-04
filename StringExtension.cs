using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpression
{
    public static class StringExtension
    {
        public static List<string> Suche(this IEnumerable<string> list, string kriterium)
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

        public static List<string> Suche(this IEnumerable<string> list, Func<string, bool> kriterium)
        {
            List<string> output = new List<string>();
            foreach (string s in list)
            {
                if (kriterium.Invoke(s))
                {
                    output.Add(s);
                }
            }
            return output;
        }
    }
}
