using System;

namespace Challenges
{
    public static class CircularArrayRotation
    {
        public static int[] Rotation(int[] a, int k, int[] q)
        {
            if(k >= a.Length)  k = k % a.Length;

            for (int i = 0; i < q.Length; i++)
            {
                if(q[i] - k >= 0) q[i] = a[q[i] - k];
                else q[i] = a[a.Length - Math.Abs(q[i] - k)];
            }

            return q;
        }
    }
}