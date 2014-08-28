using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPricing.Engine.Core
{
    class Random
    {
        /// <summary>
        /// Generates random numbers between 0 and 1.0
        /// </summary>
        /// <param name="number">Number of random numbers needed</param>
        /// <returns></returns>
        public static List<Double> GetRandomNumers(int number)
        {
            var rnd = new System.Random();
            var rndNumbers = new List<Double>();

            for (int i = 0; i < number; i++)
            {
                rndNumbers.Add(rnd.NextDouble());
            }

            return rndNumbers;
        }
    }
}
