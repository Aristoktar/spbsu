using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class logistic
    {
        /// <summary>
        /// calculate point of bifurcation
        /// </summary>
        /// <param name="r">parametr lambda</param>
        /// <param name="thresholdParametr"></param>
        /// <param name="iterationsCount"></param>
        /// <param name="x0">initial value of X</param>
        /// <returns></returns>
        public static double[] calc(double r, double x0 = 0.25, double thresholdParametr = 0.8, int iterationsCount = 1000)
        {
            double[] ans = new double[0];
            int threshold = (int)(iterationsCount * thresholdParametr);
            for (int i = 0; i < iterationsCount; i++)
            {
                x0 = r * x0 * (1 - x0);
                if (i == threshold)
                {
                    Array.Resize<double>(ref ans, ans.Length + 1);
                    ans[ans.Length - 1] = x0;
                }
                if(i > threshold)
                {
                    //if (!isArrContain(ans,x0))
                    //{
                        Array.Resize<double>(ref ans, ans.Length + 1);
                        ans[ans.Length - 1] = x0;
                    //}
                }
            }           

            return ans;
        }
        
        private static bool isArrContain(double[] arr, double value)
        {
           double eps = 0.000000000000001;
            foreach (double d in arr)
            {
                double delta = Math.Abs(d - value);
                if (delta < eps)
                    return true;
            }
            return false;
        }
    }
}
