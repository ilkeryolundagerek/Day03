using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "ilker", "ilkay", "bardak", "tabak" };
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            words.ForEach(word =>
            {
                if (word.Length > 5)
                {
                    Console.WriteLine(word);
                }
            });

            List<Element> elements = Element.GetSamples();
            List<Element> empty_elements = new List<Element>();

            var first_element = empty_elements.HasElements() ? empty_elements.FirstOrDefault() : null;

            //Func<T,bool>: x.Age<250 ifadesidir.
            elements.Where(x => x.Age < 250).ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            elements.ForEach(x => { if (x.Age < 250) Console.WriteLine(x); });
            Console.WriteLine();

            elements.Filter(x => x.Age < 250).ForEach(x => Console.WriteLine(x));
        }
    }
}
