using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }

        private static Random random = new Random();
        public static List<Element> GetSamples()
        {
            var list = new List<Element>();

            for (int i = 1; i <= 100; i++)
            {
                Element temp = new Element
                {
                    Id = i,
                    Name = $"Element_{random.Next(100, 1000)}",
                    Age = random.Next(1, 1000),
                    Active = random.Next(2) == 1
                };
                list.Add(temp);
            }

            return list;
        }

        public override string ToString()
        {
            return $"{Id} ({Active}): {Name} ({Age})";
        }
    }
}
