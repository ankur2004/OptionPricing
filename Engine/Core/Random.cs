using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;


namespace OptionPricing.Engine.Core
{
    class Random
    {
        /// <summary>
        /// Generates random numbers between 0 and 1.0
        /// </summary>
        /// <param name="number">Number of random numbers needed</param>
        /// <returns></returns>
        public static List<Double> GetRandomNumbers(int number)
        {
            var rndNumbers = new List<Double>();
            var rndMersenneTwister = new MersenneTwister(true);

            rndNumbers.AddRange(rndMersenneTwister.NextDoubles(number));
            return rndNumbers;
        }

        public static double GetRandomNumber()
        {
            return new MersenneTwister(true).NextDouble();
        }

        public static double GetNormalRandomNumber(double mean, double sdev)
        {
            return  Normal.Sample(new MersenneTwister(true), mean, sdev);
        }

        public static double GetStdNormalRandomNumber()
        {
            return GetNormalRandomNumber(0, 1);
        }

    }
}
