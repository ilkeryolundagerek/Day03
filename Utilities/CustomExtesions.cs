using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class CustomExtesions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T,bool> predicate)
        {
            return items.Where(predicate);
        }

        public static IEnumerable<object> Map<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            //Bu kısım için farklı bir geliştirme yapılacak. Predicate bool cevap verir, bizee nesne cevabı vermelidir. Bu haliyle işlemez.
            return items.Select(x=>predicate);
        }

        public static bool HasElements(this ICollection items)
        {
            return items != null && items.Count > 0;
        }

        public static string ToSlug(this String text)
        {
            string result = text.ToLower().Trim();
            result = result
                .Replace('ş', 's')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ü', 'u')
                .Replace('ğ', 'g')
                .Replace('ı', 'i');

            result = Regex.Replace(result, @"[^\w\s]", "");
            result = Regex.Replace(result, @"\s+", " ").Trim();
            return result.Replace(" ", "-");
        }

        public static string ReplaceAll(this String text, char[] actuals, char[] expecteds)
        {
            for (int i = 0; i < actuals.Length; i++)
            {
                text = text.Replace(actuals[i], expecteds[i]);
            }
            return text;
        }
    }
}
