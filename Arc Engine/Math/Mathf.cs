using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcEngine
{
    // Most functions are simple wrapper methods from System.Math, this ensures that you won't shouldn't need the two libraries as this could cause annoyance at worst.

    public static class Mathf
    {
        /// <summary>
        /// β mathematical constant
        /// </summary>
        public const double Bernstein = 0.280169499023869;
        /// <summary>
        /// e mathematical constant
        /// </summary>
        public const double E = 2.71828182845905;
        /// <summary>
        /// φ mathematical constant
        /// </summary>
        public const double GoldenRatio = 1.61803398874989;
        /// <summary>
        /// Ω mathematical constant
        /// </summary>
        public const double Omega = 0.567143290409783;
        /// <summary>
        /// π mathematical constant
        /// </summary>
        public const double Pi = 3.14159265358979;
        /// <summary>
        /// √2 mathematical constant
        /// </summary>
        public const double Pythagora = 1.41421356237310;
        /// <summary>
        /// τ mathematical constant
        /// </summary>
        public const double Tau = 6.28318530717959;
        /// <summary>
        /// √3 mathematical constant
        /// </summary>
        public const double Theodorus = 1.73205080756888;

        /// <summary>
        /// Degrees to radians multiplicator constant
        /// </summary>
        public const double Deg2Rad = Pi * 2.0 / 360.0;
        /// <summary>
        /// Radians to degrees multiplicator constant
        /// </summary>
        public const double Rad2Deg = 360.0 / (Pi * 2.0);

        private static Random _rnd;

        /// <summary>
        /// Calculates the Fibonacci sequence
        /// </summary>
        public static IEnumerable<uint> Fibonacci
        {
            get
            {
                uint a = 0u;
                uint b = 1u;
                uint index = 0u;
                while (true)
                {
                    if (index <= 1u)
                    {
                        yield return index;
                    }
                    else
                    {
                        uint temp = a;
                        a = b;
                        b = temp + b;

                        if (a > b)
                            break;

                        yield return b;
                    }

                    index++;
                }
            }
        }
        /// <summary>
        /// Calculates the Fibonacci sequence with 64-bit integers
        /// </summary>
        public static IEnumerable<ulong> FibonacciLong
        {
            get
            {
                ulong a = 0ul;
                ulong b = 1ul;
                uint index = 0u;
                while (true)
                {
                    if (index <= 1u)
                    {
                        yield return index;
                    }
                    else
                    {
                        ulong temp = a;
                        a = b;
                        b = temp + b;

                        if (a > b)
                            break;

                        yield return b;
                    }

                    index++;
                }
            }
        }

        /// <summary>
        /// Calculates prime numbers
        /// </summary>
        public static IEnumerable<uint> Primes
        {
            get
            {
                List<uint> primes = new List<uint>();
                for (uint i = 2u; i < uint.MaxValue; i++)
                {
                    bool isPrime = true;

                    foreach (uint prime in primes)
                    {
                        if (prime * prime > i)
                            break;

                        if (i % prime != 0) continue;
                        isPrime = false;
                        break;
                    }

                    if (!isPrime) continue;
                    primes.Add(i);
                    yield return i;
                }
            }
        }
        /// <summary>
        /// Calculates prime numbers with 64-bit integers
        /// </summary>
        public static IEnumerable<ulong> PrimesLong
        {
            get
            {
                List<ulong> primes = new List<ulong>();
                for (ulong i = 2ul; i < ulong.MaxValue; i++)
                {
                    bool isPrime = true;

                    foreach (ulong prime in primes)
                    {
                        if (prime * prime > i)
                            break;

                        if (i % prime != 0) continue;
                        isPrime = false;
                        break;
                    }

                    if (!isPrime) continue;
                    primes.Add(i);
                    yield return i;
                }
            }
        }

        // I use a pre-made list because perfect numbers are quite intensive to compute
        private static readonly long[] _perfectNumbers = {
            6L,
            28L,
            496L,
            8128L,
            33550336L,
            8589869056L,
            137438691328L,
            2305843008139952128L,
        };
        /// <summary>
        /// Returns a list of perfect numbers (Numbers whose all divisor's sums equal the same number)
        /// </summary>
        public static IEnumerable<long> PerfectNumbers => _perfectNumbers;

        private static int _seed;
        /// <summary>
        /// The seed of the random number generator
        /// </summary>
        public static int Seed
        {
            get => _seed;
            set
            {
                _seed = value;
                _rnd = new Random(value);
            }
        }

        static Mathf()
        {
            _seed = (int)DateTime.Now.Ticks;
            _rnd = new Random(_seed);
        }

        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static sbyte Abs(this sbyte value)
        {
            return (sbyte)(value >= 0 ? value : -value);
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static short Abs(this short value)
        {
            return (short)(value >= 0 ? value : -value);
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static int Abs(this int value)
        {
            return value >= 0 ? value : -value;
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static long Abs(this long value)
        {
            return value >= 0L ? value : -value;
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static float Abs(this float value)
        {
            return value >= 0f ? value : -value;
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static double Abs(this double value)
        {
            return value >= 0.0 ? value : -value;
        }
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The absolute value of the number</returns>
        public static decimal Abs(this decimal value)
        {
            return value >= 0m ? value : -value;
        }

        /// <summary>
        /// Returns the angle whose cosine is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose cosine is the specified number</returns>
        public static float Acos(this float value)
        {
            return (float)Math.Acos(value);
        }
        /// <summary>
        /// Returns the angle whose cosine is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose cosine is the specified number</returns>
        public static double Acos(this double value)
        {
            return Math.Acos(value);
        }

        /// <summary>
        /// Returns the angle whose sine is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose sine is the specified number</returns>
        public static float Asin(this float value)
        {
            return (float)Math.Asin(value);
        }
        /// <summary>
        /// Returns the angle whose sine is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose sine is the specified number</returns>
        public static double Asin(this double value)
        {
            return Math.Asin(value);
        }

        /// <summary>
        /// Returns the angle whose tangent is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose tangent is the specified number</returns>
        public static float Atan(this float value)
        {
            return (float)Math.Atan(value);
        }
        /// <summary>
        /// Returns the angle whose tangent is the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The angle whose tangent is the specified number</returns>
        public static double Atan(this double value)
        {
            return Math.Atan(value);
        }

        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers</returns>
        public static float Atan2(this float x, float y)
        {
            return (float)Math.Atan2(x, y);
        }
        /// <summary>
        /// Returns the angle whose tangent is the quotient of two specified numbers
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The angle whose tangent is the quotient of two specified numbers</returns>
        public static double Atan2(this double x, double y)
        {
            return Math.Atan2(x, y);
        }

        /// <summary>
        /// Produces the full product of two 32-bits numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The full product of two 32-bits numbers</returns>
        public static long BigMul(this int a, int b)
        {
            return Math.BigMul(a, b);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number</returns>
        public static float Ceiling(this float value)
        {
            return (float)Math.Ceiling(value);
        }
        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number</returns>
        public static double Ceiling(this double value)
        {
            return Math.Ceiling(value);
        }
        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number</returns>
        public static decimal Ceiling(this decimal value)
        {
            return Math.Ceiling(value);
        }

        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number casted to an integer</returns>
        public static int CeilingToInt(this float value)
        {
            return (int)Math.Ceiling(value);
        }
        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number casted to an integer</returns>
        public static int CeilingToInt(this double value)
        {
            return (int)Math.Ceiling(value);
        }
        /// <summary>
        /// Returns the smallest integral value that is greater or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The smallest integral value that is greater or equal to the specified number casted to an integer</returns>
        public static int CeilingToInt(this decimal value)
        {
            return (int)Math.Ceiling(value);
        }

        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static sbyte Clamp(this sbyte value, sbyte min, sbyte max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static short Clamp(this short value, short min, short max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static int Clamp(this int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static long Clamp(this long value, long min, long max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static byte Clamp(this byte value, byte min, byte max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static ushort Clamp(this ushort value, ushort min, ushort max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static uint Clamp(this uint value, uint min, uint max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static ulong Clamp(this ulong value, ulong min, ulong max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static float Clamp(this float value, float min, float max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static double Clamp(this double value, double min, double max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="min">The minimum value of the range</param>
        /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range</returns>
        public static decimal Clamp(this decimal value, decimal min, decimal max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static sbyte Clamp01(this sbyte value)
        {
            if (value < 0)
                return 0;
            if (value > 1)
                return 1;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static short Clamp01(this short value)
        {
            if (value < 0)
                return 0;
            if (value > 1)
                return 1;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static int Clamp01(this int value)
        {
            if (value < 0)
                return 0;
            if (value > 1)
                return 1;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static long Clamp01(this long value)
        {
            if (value < 0L)
                return 0L;
            if (value > 1L)
                return 1L;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static byte Clamp01(this byte value)
        {
            return value > 1 ? (byte)1 : value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static ushort Clamp01(this ushort value)
        {
            return (ushort)(value > 1 ? 1 : value);
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static uint Clamp01(this uint value)
        {
            return value > 1u ? 1u : value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static ulong Clamp01(this ulong value)
        {
            return value > 1ul ? 1ul : value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static float Clamp01(this float value)
        {
            if (value < 0f)
                return 0f;
            if (value > 1f)
                return 1f;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static double Clamp01(this double value)
        {
            if (value < 0.0)
                return 0.0;
            if (value > 1.0)
                return 1.0;
            return value;
        }
        /// <summary>
        /// Clamps the specified number inside the 0-1 range
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The specified number clamped inside the 0-1 range</returns>
        public static decimal Clamp01(this decimal value)
        {
            if (value < 0m)
                return 0m;
            if (value > 1m)
                return 1m;
            return value;
        }

        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static sbyte ClampMin(this sbyte value, sbyte min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static short ClampMin(this short value, short min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static int ClampMin(this int value, int min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static long ClampMin(this long value, long min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static byte ClampMin(this byte value, byte min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static ushort ClampMin(this ushort value, ushort min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static uint ClampMin(this uint value, uint min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static ulong ClampMin(this ulong value, ulong min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static float ClampMin(this float value, float min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static double ClampMin(this double value, double min)
        {
            return value < min ? min : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the maximum range value is infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="min">The minimum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the maximum range value is infinite</returns>
        public static decimal ClampMin(this decimal value, decimal min)
        {
            return value < min ? min : value;
        }

        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static sbyte ClampMax(this sbyte value, sbyte max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static short ClampMax(this short value, short max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static int ClampMax(this int value, int max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static long ClampMax(this long value, long max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static byte ClampMax(this byte value, byte max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static ushort ClampMax(this ushort value, ushort max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static uint ClampMax(this uint value, uint max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static ulong ClampMax(this ulong value, ulong max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static float ClampMax(this float value, float max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static double ClampMax(this double value, double max)
        {
            return value > max ? max : value;
        }
        /// <summary>
        /// Clamps the specified number inside the specified range where the minimum range value is negatively infinite
        /// </summary>
        /// <param name="value">The number</param>
        /// /// <param name="max">The maximum value of the range</param>
        /// <returns>The specified number clamped inside the specified range where the minimum range value is negatively infinite</returns>
        public static decimal ClampMax(this decimal value, decimal max)
        {
            if (value > max)
                return max;
            return value;
        }

        /// <summary>
        /// Calculates the Collatz Conjecture sequence of a specified number
        /// </summary>
        /// <param name="n">The number</param>
        /// <returns>The Collatz Conjecture sequence of a specified number</returns>
        public static IEnumerable<int> CollatzConjecture(int n)
        {
            if (n < 1)
                throw new Exception("The specified number is inferior to 1");

            while (true)
            {
                yield return n;

                if (n % 2 == 0)
                {
                    n = n / 2;
                }
                else
                {
                    n = n * 3 + 1;
                }
            }
        }
        /// <summary>
        /// Calculates the Collatz Conjecture sequence of a specified number
        /// </summary>
        /// <param name="n">The number</param>
        /// <returns>The Collatz Conjecture sequence of a specified number</returns>
        public static IEnumerable<long> CollatzConjecture(long n)
        {
            if (n < 1L)
                throw new Exception("The specified number is inferior to 1");

            while (true)
            {
                yield return n;

                if (n % 2L == 0L)
                {
                    n = n / 2L;
                }
                else
                {
                    n = n * 3L + 1L;
                }
            }
        }
        /// <summary>
        /// Calculates the Collatz Conjecture sequence of a specified number
        /// </summary>
        /// <param name="n">The number</param>
        /// <returns>The Collatz Conjecture sequence of a specified number</returns>
        public static IEnumerable<float> CollatzConjecture(float n)
        {
            if (n < 1f)
                throw new Exception("The specified number is inferior to 1");

            while (true)
            {
                yield return n;

                if (Math.Abs(Math.Floor(n) % 2f) < float.Epsilon)
                {
                    n = n / 2f;
                }
                else
                {
                    n = n * 3f + 1f;
                }
            }
        }
        /// <summary>
        /// Calculates the Collatz Conjecture sequence of a specified number
        /// </summary>
        /// <param name="n">The number</param>
        /// <returns>The Collatz Conjecture sequence of a specified number</returns>
        public static IEnumerable<double> CollatzConjecture(double n)
        {
            if (n < 1.0)
                throw new Exception("The specified number is inferior to 1");

            while (true)
            {
                yield return n;

                if (Math.Abs(Math.Floor(n) % 2.0) < double.Epsilon)
                {
                    n = n / 2.0;
                }
                else
                {
                    n = n * 3.0 + 1.0;
                }
            }
        }
        /// <summary>
        /// Calculates the Collatz Conjecture sequence of a specified number
        /// </summary>
        /// <param name="n">The number</param>
        /// <returns>The Collatz Conjecture sequence of a specified number</returns>
        public static IEnumerable<decimal> CollatzConjecture(decimal n)
        {
            if (n < 1m)
                throw new Exception("The specified number is inferior to 1");

            while (true)
            {
                yield return n;

                if (Math.Floor(n) % 2 == 0)
                {
                    n = n / 2;
                }
                else
                {
                    n = n * 3 + 1;
                }
            }
        }

        /// <summary>
        /// Returns the cosine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The cosine of the specified angle</returns>
        public static float Cos(this float value)
        {
            return (float)Math.Cos(value);
        }
        /// <summary>
        /// Returns the cosine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The cosine of the specified angle</returns>
        public static double Cos(this double value)
        {
            return Math.Cos(value);
        }

        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The hyperbolic cosine of the specified angle</returns>
        public static float Cosh(this float value)
        {
            return (float)Math.Cosh(value);
        }
        /// <summary>
        /// Returns the hyperbolic cosine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The hyperbolic cosine of the specified angle</returns>
        public static double Cosh(this double value)
        {
            return Math.Cosh(value);
        }

        /// <summary>
        /// Calculates the quotient of two 32-bits, and also returns the remainder in an output parameter
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="remainder">The out parameter for the remainder</param>
        /// <returns>The quotient of two 32-bits, and also returns the remainder in an output parameter</returns>
        public static int DivRem(this int a, int b, out int remainder)
        {
            return Math.DivRem(a, b, out remainder);
        }
        /// <summary>
        /// Calculates the quotient of two 64-bits, and also returns the remainder in an output parameter
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <param name="remainder">The out parameter for the remainder</param>
        /// <returns>The quotient of two 64-bits, and also returns the remainder in an output parameter</returns>
        public static long DivRem(this long a, long b, out long remainder)
        {
            return Math.DivRem(a, b, out remainder);
        }

        /// <summary>
        /// Returns e raised to the specified power
        /// </summary>
        /// <param name="value">The power</param>
        /// <returns>e raised to the specified power</returns>
        public static float Exp(this float value)
        {
            return (float)Math.Exp(value);
        }
        /// <summary>
        /// Returns e raised to the specified power
        /// </summary>
        /// <param name="value">The power</param>
        /// <returns>e raised to the specified power</returns>
        public static double Exp(this double value)
        {
            return Math.Exp(value);
        }

        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static int Factorial(this int a)
        {
            int n = 1;
            for (int i = 1; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }
        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static uint Factorial(this uint a)
        {
            uint n = 1u;
            for (uint i = 1u; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }
        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static long Factorial(this long a)
        {
            long n = 1L;
            for (long i = 1L; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }
        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static ulong Factorial(this ulong a)
        {
            ulong n = 1ul;
            for (ulong i = 1ul; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }
        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static float Factorial(this float a)
        {
            float n = 1f;
            for (float i = 1f; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }
        /// <summary>
        /// Calculates the factorial of a specified number
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>The factorial of the specified number</returns>
        public static double Factorial(this double a)
        {
            double n = 1.0;
            for (double i = 1.0; i <= a; i++)
            {
                n *= i;
            }
            return n;
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number</returns>
        public static float Floor(this float value)
        {
            return (float)Math.Floor(value);
        }
        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number</returns>
        public static double Floor(this double value)
        {
            return Math.Floor(value);
        }
        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number</returns>
        public static decimal Floor(this decimal value)
        {
            return Math.Floor(value);
        }

        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number casted to an integer</returns>
        public static int FloorToInt(this float value)
        {
            return (int)Math.Floor(value);
        }
        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number casted to an integer</returns>
        public static int FloorToInt(this double value)
        {
            return (int)Math.Floor(value);
        }
        /// <summary>
        /// Returns the largest integer less than or equal to the specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The largest integer less than or equal to the specified number casted to an integer</returns>
        public static int FloorToInt(this decimal value)
        {
            return (int)Math.Floor(value);
        }

        /// <summary>
        /// Returns the remainder resulting from the division of a specified number by another specified number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The remainder resulting from the division of a specified number by another specified number</returns>
        public static float IEEERemainder(this float x, float y)
        {
            return (float)Math.IEEERemainder(x, y);
        }
        /// <summary>
        /// Returns the remainder resulting from the division of a specified number by another specified number
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The remainder resulting from the division of a specified number by another specified number</returns>
        public static double IEEERemainder(this double x, double y)
        {
            return Math.IEEERemainder(x, y);
        }

        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant value within the range [from, to]
        /// </summary>
        /// <returns>The linear parameter t that produces the interpolant value within the range [from, to]</returns>
        public static float InverseLerp(float from, float to, float value)
        {
            return (value - from) / (to - from);
        }
        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant value within the range [from, to]
        /// </summary>
        /// <returns>The linear parameter t that produces the interpolant value within the range [from, to]</returns>
        public static double InverseLerp(double from, double to, double value)
        {
            return (value - from) / (to - from);
        }
        /// <summary>
        /// Calculates the linear parameter t that produces the interpolant value within the range [from, to]
        /// </summary>
        /// <returns>The linear parameter t that produces the interpolant value within the range [from, to]</returns>
        public static decimal InverseLerp(decimal from, decimal to, decimal value)
        {
            return (value - from) / (to - from);
        }

        /// <summary>
        /// Determines if the specified number is prime
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is prime, otherwise false</returns>
        public static bool IsPrime(this int a)
        {
            return Primes.TakeWhile(i => i <= a).Contains((uint)a);
        }
        /// <summary>
        /// Determines if the specified number is prime
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is prime, otherwise false</returns>
        public static bool IsPrime(this uint a)
        {
            return Primes.TakeWhile(i => i <= a).Contains(a);
        }
        /// <summary>
        /// Determines if the specified number is prime
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is prime, otherwise false</returns>
        public static bool IsPrime(this long a)
        {
            return PrimesLong.TakeWhile(i => i <= (ulong)a).Contains((ulong)a);
        }
        /// <summary>
        /// Determines if the specified number is prime
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is prime, otherwise false</returns>
        public static bool IsPrime(this ulong a)
        {
            return PrimesLong.TakeWhile(i => i <= a).Contains(a);
        }

        /// <summary>
        /// Determines if the specified number is perfect
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is perfect, otherwise false</returns>
        public static bool IsPerfect(this int a)
        {
            return PerfectNumbers.Contains(a);
        }
        /// <summary>
        /// Determines if the specified number is perfect
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is perfect, otherwise false</returns>
        public static bool IsPerfect(this uint a)
        {
            return PerfectNumbers.Contains(a);
        }
        /// <summary>
        /// Determines if the specified number is perfect
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is perfect, otherwise false</returns>
        public static bool IsPerfect(this long a)
        {
            return PerfectNumbers.Contains(a);
        }
        /// <summary>
        /// Determines if the specified number is perfect
        /// </summary>
        /// <param name="a">The number</param>
        /// <returns>True if the specified number is perfect, otherwise false</returns>
        public static bool IsPerfect(this ulong a)
        {
            return PerfectNumbers.Contains((long)a);
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The natural (base e) logarithm of a specified number</returns>
        public static float Log(this float value)
        {
            return (float)Math.Log(value);
        }
        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number in a specified base
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="newBase">The new base</param>
        /// <returns>The natural (base e) logarithm of a specified number  in a specified base</returns>
        public static float Log(this float value, float newBase)
        {
            return (float)Math.Log(value, newBase);
        }
        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The natural (base e) logarithm of a specified number</returns>
        public static double Log(this double value)
        {
            return Math.Log(value);
        }
        /// <summary>
        /// Returns the natural (base e) logarithm of a specified number in a specified base
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="newBase">The new base</param>
        /// <returns>The natural (base e) logarithm of a specified number in a specified base</returns>
        public static double Log(this double value, double newBase)
        {
            return Math.Log(value, newBase);
        }

        /// <summary>
        /// Returns the base 10 logarithm of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The base 10 logarithm of a specified number</returns>
        public static float Log10(this float value)
        {
            return (float)Math.Log10(value);
        }
        /// <summary>
        /// Returns the base 10 logarithm of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The base 10 logarithm of a specified number</returns>
        public static double Log10(this double value)
        {
            return Math.Log10(value);
        }

        /// <summary>
        /// Linearly interpolates between from and to by t.
        /// </summary>
        /// <returns>The interpolated number result between the two number values.</returns>
        public static float Lerp(float from, float to, float t)
        {
            return from + (to - from) * t;
        }
        /// <summary>
        /// Linearly interpolates between from and to by t.
        /// </summary>
        /// <returns>The interpolated number result between the two number values.</returns>
        public static double Lerp(double from, double to, double t)
        {
            return from + (to - from) * t;
        }
        /// <summary>
        /// Linearly interpolates between from and to by t.
        /// </summary>
        /// <returns>The interpolated number result between the two number values.</returns>
        public static decimal Lerp(decimal from, decimal to, decimal t)
        {
            return from + (to - from) * t;
        }

        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static sbyte Max(this sbyte a, sbyte b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static short Max(this short a, short b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static int Max(this int a, int b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static long Max(this long a, long b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static byte Max(this byte a, byte b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static ushort Max(this ushort a, ushort b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static uint Max(this uint a, uint b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static ulong Max(this ulong a, ulong b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static float Max(this float a, float b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static double Max(this double a, double b)
        {
            return a < b ? b : a;
        }
        /// <summary>
        /// Returns the largest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The largest number between the two specified numbers</returns>
        public static decimal Max(this decimal a, decimal b)
        {
            return a < b ? b : a;
        }

        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static sbyte Min(this sbyte a, sbyte b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static short Min(this short a, short b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static int Min(this int a, int b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static long Min(this long a, long b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static byte Min(this byte a, byte b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static ushort Min(this ushort a, ushort b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static uint Min(this uint a, uint b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static ulong Min(this ulong a, ulong b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static float Min(this float a, float b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static double Min(this double a, double b)
        {
            return a < b ? a : b;
        }
        /// <summary>
        /// Returns the smallest number between the two specified numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The smallest number between the two specified numbers</returns>
        public static decimal Min(this decimal a, decimal b)
        {
            return a < b ? a : b;
        }

        /// <summary>
        /// Returns a specified number raised to the specified power
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>A specified number raised to the specified power</returns>
        public static float Pow(this float x, float y)
        {
            return (float)Math.Pow(x, y);
        }
        /// <summary>
        /// Returns a specified number raised to the specified power
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>A specified number raised to the specified power</returns>
        public static double Pow(this double x, double y)
        {
            return Math.Pow(x, y);
        }

        /// <summary>
        /// Returns a random 32-bit integer
        /// </summary>
        /// <returns>A random 32-bit integer</returns>
        public static int Random()
        {
            return _rnd.Next();
        }
        /// <summary>
        /// Returns a random 32-bit integer with a specified maximum value (exclusive)
        /// </summary>
        /// <param name="max">The maximum value</param>
        /// <returns>A random 32-bit integer with a specified maximum value (exclusive)</returns>
        public static int Random(int max)
        {
            return _rnd.Next(max);
        }
        /// <summary>
        /// Returns a random 32-bit integer with a specified minimum (inclusive) and maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>A random 32-bit integer with a specified minimum (inclusive) and maximum value (exclusive)</returns>
        public static int Random(int min, int max)
        {
            return _rnd.Next(min, max);
        }
        /// <summary>
        /// Returns a random number with a specified minimum (exclusive) and maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>A random number with a specified minimum (exclusive) and maximum value (exclusive)</returns>
        public static float Random(float min, float max)
        {
            return ((float)_rnd.NextDouble()).Remap(0.0f, 1.0f, min, max);
        }
        /// <summary>
        /// Returns a random number with a specified minimum (exclusive) and maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>A random number with a specified minimum (exclusive) and maximum value (exclusive)</returns>
        public static double Random(double min, double max)
        {
            return _rnd.NextDouble().Remap(0.0, 1.0, min, max);
        }
        /// <summary>
        /// Returns a random number with a specified minimum (exclusive) and maximum value (exclusive)
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>A random number with a specified minimum (exclusive) and maximum value (exclusive)</returns>
        // Decimal random isn't perfect, it bases off as a double so precision in the lower numbers is lost.
        public static decimal Random(decimal min, decimal max)
        {
            // Using Convert because recasting detects it as a double.
            return Convert.ToDecimal(_rnd.NextDouble()).Remap(0m, 1m, min, max);
        }

        /// <summary>
        /// Returns a random 32-bit floating point number between 0.0 and 1.0
        /// </summary>
        /// <returns>A random 32-bit floating point number between 0.0 and 1.0</returns>
        public static float RandomFloat()
        {
            return (float)_rnd.NextDouble();
        }
        /// <summary>
        /// Returns a random 64-bit floating point number between 0.0 and 1.0
        /// </summary>
        /// <returns>A random 64-bit floating point number between 0.0 and 1.0</returns>
        public static double RandomDouble()
        {
            return _rnd.NextDouble();
        }

        /// <summary>
        /// Remaps a specified number from a range to another
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="inputMin">The minimum value of the first range</param>
        /// <param name="inputMax">The maximum value of the first range</param>
        /// <param name="outputMin">The minimum value of the second range</param>
        /// <param name="outputMax">The maximum value of the second range</param>
        /// <returns>A specified number remapped from a range to another</returns>
        public static float Remap(this float value, float inputMin, float inputMax, float outputMin, float outputMax)
        {
            return outputMin + (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin);
        }
        /// <summary>
        /// Remaps a specified number from a range to another
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="inputMin">The minimum value of the first range</param>
        /// <param name="inputMax">The maximum value of the first range</param>
        /// <param name="outputMin">The minimum value of the second range</param>
        /// <param name="outputMax">The maximum value of the second range</param>
        /// <returns>A specified number remapped from a range to another</returns>
        public static double Remap(this double value, double inputMin, double inputMax, double outputMin, double outputMax)
        {
            return outputMin + (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin);
        }
        /// <summary>
        /// Remaps a specified number from a range to another
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="inputMin">The minimum value of the first range</param>
        /// <param name="inputMax">The maximum value of the first range</param>
        /// <param name="outputMin">The minimum value of the second range</param>
        /// <param name="outputMax">The maximum value of the second range</param>
        /// <returns>A specified number remapped from a range to another</returns>
        public static decimal Remap(this decimal value, decimal inputMin, decimal inputMax, decimal outputMin, decimal outputMax)
        {
            return outputMin + (value - inputMin) * (outputMax - outputMin) / (inputMax - inputMin);
        }

        /// <summary>
        /// Rounds a number to the nearest integral number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number to the nearest integral number</returns>
        public static float Round(this float value)
        {
            return (float)Math.Round(value);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static float Round(this float value, int digits)
        {
            return (float)Math.Round(value, digits);
        }
        /// <summary>
        /// Rounds a number to the nearest integral number. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to the nearest integral number</returns>
        public static float Round(this float value, MidpointRounding mode)
        {
            return (float)Math.Round(value, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static float Round(this float value, int digits, MidpointRounding mode)
        {
            return (float)Math.Round(value, digits, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to the nearest integral number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number to the nearest integral number</returns>
        public static double Round(this double value)
        {
            return Math.Round(value);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static double Round(this double value, int digits)
        {
            return Math.Round(value, digits);
        }
        /// <summary>
        /// Rounds a number to the nearest integral number. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to the nearest integral number</returns>
        public static double Round(this double value, MidpointRounding mode)
        {
            return Math.Round(value, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static double Round(this double value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to the nearest integral number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number to the nearest integral number</returns>
        public static decimal Round(this decimal value)
        {
            return Math.Round(value);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static decimal Round(this decimal value, int digits)
        {
            return Math.Round(value, digits);
        }
        /// <summary>
        /// Rounds a number to the nearest integral number. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to the nearest integral number</returns>
        public static decimal Round(this decimal value, MidpointRounding mode)
        {
            return Math.Round(value, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to a specified number of fractional digits. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="digits">The amount of digits</param>
        /// <param name="mode">The rounding mode</param>
        /// <returns>A number to a specified number of fractional digits</returns>
        public static decimal Round(this decimal value, int digits, MidpointRounding mode)
        {
            return Math.Round(value, digits, (System.MidpointRounding)mode);
        }

        /// <summary>
        /// Rounds a number to the nearest integer
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this float value)
        {
            return (int)Math.Round(value);
        }

        /// <summary>
        /// Rounds a number to the nearest integer. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The midpoint rounding mode</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this float value, MidpointRounding mode)
        {
            return (int)Math.Round(value, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to the nearest integer
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this double value)
        {
            return (int)Math.Round(value);
        }
        /// <summary>
        /// Rounds a number to the nearest integer. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The midpoint rounding mode</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this double value, MidpointRounding mode)
        {
            return (int)Math.Round(value, (System.MidpointRounding)mode);
        }
        /// <summary>
        /// Rounds a number to the nearest integer
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this decimal value)
        {
            return (int)Math.Round(value);
        }
        /// <summary>
        /// Rounds a number to the nearest integer. A parameter specifies how to round the value if it is midway between two other numbers
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="mode">The midpoint rounding mode</param>
        /// <returns>A number rounded to the nearest integer</returns>
        public static int RoundToInt(this decimal value, MidpointRounding mode)
        {
            return (int)Math.Round(value, (System.MidpointRounding)mode);
        }

        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this sbyte value)
        {
            if (value > 0)
                return 1;
            if (value < 0)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this short value)
        {
            if (value > 0)
                return 1;
            if (value < 0)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this int value)
        {
            if (value > 0)
                return 1;
            if (value < 0)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this long value)
        {
            if (value > 0L)
                return 1;
            if (value < 0L)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this float value)
        {
            if (value > 0f)
                return 1;
            if (value < 0f)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this double value)
        {
            if (value > 0.0)
                return 1;
            if (value < 0.0)
                return -1;
            return 0;
        }
        /// <summary>
        /// Returns the sign of a number. 1 for positive, -1 for negative, 0 for zero
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The sign of a number.</returns>
        public static sbyte Sign(this decimal value)
        {
            if (value > 0m)
                return 1;
            if (value < 0m)
                return -1;
            return 0;
        }

        /// <summary>
        /// Returns the sine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The sine of the specified angle</returns>
        public static float Sin(this float value)
        {
            return (float)Math.Sin(value);
        }
        /// <summary>
        /// Returns the sine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The sine of the specified angle</returns>
        public static double Sin(this double value)
        {
            return Math.Sin(value);
        }

        /// <summary>
        /// Returns the hyperbolic sine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The hyperbolic sine of the specified angle</returns>
        public static float Sinh(this float value)
        {
            return (float)Math.Sinh(value);
        }
        /// <summary>
        /// Returns the hyperbolic sine of the specified angle
        /// </summary>
        /// <param name="value">The angle</param>
        /// <returns>The hyperbolic sine of the specified angle</returns>
        public static double Sinh(this double value)
        {
            return Math.Sinh(value);
        }

        /// <summary>
        /// Returns the square-root of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The square-root of a specified number</returns>
        public static float Sqrt(this float value)
        {
            return (float)Math.Sqrt(value);
        }
        /// <summary>
        /// Returns the square-root of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The square-root of a specified number</returns>
        public static double Sqrt(this double value)
        {
            return Math.Sqrt(value);
        }

        /// <summary>
        /// Returns the tangent of the specified angle
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The tangent of the specified angle</returns>
        public static float Tan(this float value)
        {
            return (float)Math.Tan(value);
        }
        /// <summary>
        /// Returns the tangent of the specified angle
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The tangent of the specified angle</returns>
        public static double Tan(this double value)
        {
            return Math.Tan(value);
        }

        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The hyperbolic tangent of the specified angle</returns>
        public static float Tanh(this float value)
        {
            return (float)Math.Tanh(value);
        }
        /// <summary>
        /// Returns the hyperbolic tangent of the specified angle
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The hyperbolic tangent of the specified angle</returns>
        public static double Tanh(this double value)
        {
            return Math.Tanh(value);
        }

        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static float Truncate(this float value)
        {
            return (float)Math.Truncate(value);
        }
        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static double Truncate(this double value)
        {
            return Math.Truncate(value);
        }
        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static decimal Truncate(this decimal value)
        {
            return Math.Truncate(value);
        }

        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static int TruncateToInt(this float value)
        {
            return (int)Math.Truncate(value);
        }
        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static int TruncateToInt(this double value)
        {
            return (int)Math.Truncate(value);
        }
        /// <summary>
        /// Calculates the integral-part of a specified number
        /// </summary>
        /// <param name="value">The number</param>
        /// <returns>The integral-part of a specified number</returns>
        public static int TruncateToInt(this decimal value)
        {
            return (int)Math.Truncate(value);
        }
    }
}
