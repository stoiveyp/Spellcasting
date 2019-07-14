﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SpellCastingLogic
{
    public class CryptoRandom
    {
        private static RandomNumberGenerator r;

        static CryptoRandom()
        {
            r = RandomNumberGenerator.Create();
        }

        ///<summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name="buffer">An array of bytes to contain random numbers.</param>
        public static void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }
        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public static double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }
        ///<summary>
        /// Returns a random number within the specified range.
        ///</summary>
        ///<param name="minValue">The inclusive lower bound of the random number returned.</param>
        ///<param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        public static int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }
        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public static int Next()
        {
            return Next(0, Int32.MaxValue);
        }
        ///<summary>
        /// Returns a nonnegative random number less than the specified maximum
        ///</summary>
        ///<param name="maxValue">The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        public static int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
