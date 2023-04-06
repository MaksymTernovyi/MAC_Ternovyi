using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAC_DLL
{
    public class MAC_Series
    {
        public static double SumOfNumberSeries(int first, int last, Func<int, double> function)
        {
            var sum = 0.0;
            for (int i = first; i < last; i++) sum += function(i);
            return sum;
        }

        public static double SumOfNumberSeriesA(int first, double eps, Func<int, double> function, ref int index)
        {
            var result = 0.0;
            var n = first;

            double a;

            do result += a = function(n++);
            while (Math.Abs(a) >= eps);

            int N = n - first;

            double sum;
            bool flag;
            do
            {
                result += sum = SumOfNumberSeries(n, n + N + 1, function);
                if (flag = Math.Abs(sum) >= eps) n += N + 1;
            } while (flag);

            index = n + N;

            return result;
        }

        public static double SumOfNumberSeriesD(int first, double delta, Func<int, double> function, ref int index)
        {
            var result = 0.0;
            var n = first;

            double a;

            do result += a = function(n++);
            while (Math.Abs(a / result) >= delta);

            int N = n - first;

            double sum;
            bool flag;
            do
            {
                result += sum = SumOfNumberSeries(n, n + N + 1, function);
                if (flag = Math.Abs(sum / result) >= delta) n += N + 1;
            } while (flag);

            index = n + N;

            return result;
        }
    }
}