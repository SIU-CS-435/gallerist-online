using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class Shuffler
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source = source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");
            List<T> temp = source.ToList();
            int n = temp.Count();
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(rng.NextDouble() * (n - i));
                T t = temp[r];
                temp[r] = temp[i];
                temp[i] = t;
            }
            return source = temp.AsEnumerable();
        }
    }
}
