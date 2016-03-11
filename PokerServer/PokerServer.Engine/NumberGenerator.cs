using System;
using System.Security.Cryptography;

namespace PokerServer.Engine
{
    public class NumberGenerator : INumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _rngCsp;

        static NumberGenerator()
        {
            _rngCsp = new RNGCryptoServiceProvider();
        }

        public NumberGenerator()
        {
            
        }

        public byte GenerateRandomByte(byte min, byte max)
        {
            var randomNumber = new byte[1];

            do
            {
              _rngCsp.GetBytes(randomNumber);  
            } while (IsBetweenMinMax(randomNumber[0], min, max) == false);
            

            return Convert.ToByte(randomNumber[0]);
        }

        public double GenerateRandomDouble(double min, double max)
        {
            var random = new Random();
            return random.NextDouble()*(max - min) + min;
        }

        private bool IsBetweenMinMax(byte value, byte min, byte max)
        {
            return value >= min && value <= max;
        }
    }
}