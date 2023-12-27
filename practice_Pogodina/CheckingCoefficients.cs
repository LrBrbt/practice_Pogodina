using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_Pogodina
{
    public static class CheckingCoefficients
    {
        public static string CheckCoefficients()
        {
            string functionInfo = string.Empty;

            if (CalculateClass.k > 1 || CalculateClass.k < -1)
            {
                if (CalculateClass.b > 0)
                {
                    functionInfo = "y = " + CalculateClass.k.ToString() + "x + " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b < 0)
                {
                    functionInfo = "y = " + CalculateClass.k.ToString() + "x - " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b == 0)
                {
                    functionInfo = "y = " + CalculateClass.k.ToString() + "x";
                }
            }

            if (CalculateClass.k == 1)
            {
                if (CalculateClass.b > 0)
                {
                    functionInfo = "y = x + " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b < 0)
                {
                    functionInfo = "y = x - " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b == 0)
                {
                    functionInfo = "y = x";
                }
            }

            if (CalculateClass.k == -1)
            {
                if (CalculateClass.b > 0)
                {
                    functionInfo = "y = -x + " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b < 0)
                {
                    functionInfo = "y = -x - " + CalculateClass.b.ToString();
                }
                else if (CalculateClass.b == 0)
                {
                    functionInfo = "y = -x";
                }
            }

            return functionInfo;
        }
    }
}
