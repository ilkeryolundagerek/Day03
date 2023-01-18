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
            /*
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

            Console.WriteLine();
            //LINQ: (Language Integrated Query)

            //Anonim tip (Her hangi bir class'a bağlı olmayan tipler) kullanan koleksiyon oluşturur.
            var new_elements = from x in elements
                               where x.Age < 250
                               select new { x.Id, x.Name };

            //Genel olarak yapısal değişikliklerde yeni oluşacak örnekler için class tanımlaması yapılması tavsiye edilir.
            var agelessActiveElements = from x in elements
                                        where x.Age < 250
                                        select new AgelessActiveElement
                                        {
                                            Id = x.Id,
                                            Name = x.Name
                                        };
            var anonim = new { a = 12, b = 85 };
            new_elements.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            agelessActiveElements.ForEach(x => Console.WriteLine(x));
            */

            var NewElements = Element.GetSamples();
            var ElementPools = ElementPool.GetSamples();

            //Bu yapı List gibi üretilmiş nesnelerle çalıştırılırsa çok fazla yük bindirir.
            var elementPoolsWithElements = from p in ElementPools
                                           join e in NewElements
                                           on p.Id equals e.PoolId
                                           select new
                                           {
                                               PoolId = p.Id,
                                               PoolName = p.Name,
                                               PoolStatus = p.Active,
                                               ElementId = e.Id,
                                               ElementName = e.Name,
                                               ElementStatus = e.Active,
                                               ElementAge = e.Age
                                           };

            var elementPoolsWithElements2 = ElementPools.Join(NewElements, x => x.Id, y => y.PoolId, (p, e) => new { PoolId = p.Id, PoolName = p.Name, PoolStatus = p.Active, ElementId = e.Id, ElementName = e.Name, ElementStatus = e.Active, ElementAge = e.Age });

            Console.WriteLine(elementPoolsWithElements2.Count());
            elementPoolsWithElements2.Filter(x => x.ElementAge < 250).ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //Group By: Verilen kriterlere göre veriyi grupluyor.
            var elementPoolsGroup = elementPoolsWithElements2
                .GroupBy(x => x.PoolId)
                .Select(g => new
                {
                    PoolId = g.Key,
                    ElementCount = g.Count(),
                    AgeAvg = g.Average(x => x.ElementAge)
                });

            var elementPoolsGroup2 = from e in elementPoolsWithElements2
                                     orderby e.PoolId descending
                                     group e by e.PoolId into g
                                     select new
                                     {
                                         PoolId = g.Key,
                                         ElementCount = g.Count(),
                                         AgeAvg = g.Average(x => x.ElementAge),
                                         AgeSum = g.Sum(x=>x.ElementAge),
                                         AgeMax = g.Max(x=>x.ElementAge),
                                         AgeMin = g.Min(x=>x.ElementAge)
                                     };

            elementPoolsGroup2.ForEach(x => Console.WriteLine(x));
        }
    }
}
