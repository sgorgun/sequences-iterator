using System;
using System.Collections;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the sequence of prime numbers. 
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>A sequence of <paramref name="count"/> first prime numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the sequence of prime numbers (see https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
        /// </summary>
        /// <param name="number">Maximum number to search.</param>
        /// <returns>A sequence of all primes less or equal than <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="number"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimes(int number)
        {
            throw new NotImplementedException();
        }
    }
}
