using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Numerics;

namespace SequencesTask
{
    /// <summary>
    /// Generator of the sequences.
    /// </summary>
    public static class SequenceGenerator
    {
        /// <summary>
        /// Generates the Fibonacci sequence.
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>The Fibonacci sequence of <paramref name="count"/> first numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<BigInteger> GetFibonacciNumbers(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Can't be less than 1.", nameof(count));
            }

            return GetNumbers();

            IEnumerable<BigInteger> GetNumbers()
            {
                BigInteger previous = 0;
                BigInteger current = 1;
                yield return previous;
                yield return current;

                while (count > 2)
                {
                    BigInteger temp = previous + current;
                    count--;
                    yield return temp;
                    (current, previous) = (temp, current);
                }
            }
        }

        /// <summary>
        /// Generates the sequence of prime numbers.
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>A sequence of <paramref name="count"/> first prime numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Can't be less than 1.", nameof(count));
            }

            return GetNumbers();

            IEnumerable<int> GetNumbers()
            {
                yield return 2;

                for (int i = 3; count > 1; i += 2)
                {
                    if (IsPrime(i))
                    {
                        count--;
                        yield return i;
                    }
                }

                static bool IsPrime(int num)
                {
                    for (int i = 2; i * i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
        }

        /// <summary>
        /// Generates the sequence of prime numbers (see https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
        /// </summary>
        /// <param name="number">Maximum number to search.</param>
        /// <returns>A sequence of all primes less or equal than <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="number"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimes(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("Can't be less than 1.", nameof(number));
            }

            return GetNumbers();

            IEnumerable<int> GetNumbers()
            {
                bool[] numbers = new bool[number + 1];

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = true;
                }

                for (int i = 2; i * i <= number; i++)
                {
                    if (numbers[i])
                    {
                        for (int j = i * i; j <= number; j += i)
                        {
                            numbers[j] = false;
                        }
                    }
                }

                for (int i = 2; i <= number; i++)
                {
                    if (numbers[i])
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
