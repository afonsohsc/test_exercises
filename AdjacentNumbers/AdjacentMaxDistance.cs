using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacentNumbers
{
    class AdjacentMaxDistance
    {
        private int[] a;
        private int distance;
        private int maxDistance;


        public AdjacentMaxDistance(int[] _a)
        {
            this.a = _a;
        }

        public int Solution()
        {
            if (a.Length == 1)
            {
                return -2;
            }
            else
            {
                Array.Sort(a);

                for (int i = 1; i < a.Length; i++)
                {
                    distance = a[i] - a[i - 1];

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;

                    }
                }

                return maxDistance;

            }
        }
    }
}
