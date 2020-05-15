using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using SequencesTask;

namespace SequencesTask.Tests
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        private static IEnumerable<TestCaseData> FibonacciTestCases
        {
            get
            {
                yield return new TestCaseData(3, new BigInteger[] {0, 1, 1});
                yield return new TestCaseData(10, new BigInteger[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34});
                yield return new TestCaseData(
                    44,
                    new BigInteger[]
                    {
                        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
                        17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578,
                        5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296,
                        433494437
                    });
                yield return new TestCaseData(
                    69,
                    new BigInteger[]
                    {
                        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946,
                        17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578,
                        5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296,
                        433494437, 701408733, 1134903170, 1836311903, 2971215073, 4807526976, 7778742049, 12586269025,
                        20365011074, 32951280099, 53316291173, 86267571272, 139583862445, 225851433717, 365435296162,
                        591286729879, 956722026041, 1548008755920, 2504730781961, 4052739537881, 6557470319842,
                        10610209857723, 17167680177565, 27777890035288, 44945570212853, 72723460248141
                    });
            }
        }

        private static IEnumerable<TestCaseData> PrimeNumbersTestCases
        {
            get
            {
                yield return new TestCaseData(5, new[] {2, 3, 5, 7, 11});
                yield return new TestCaseData(10, new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29});
                yield return new TestCaseData(
                    50,
                    new[]
                    {
                        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
                        101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193,
                        197, 199, 211, 223, 227, 229,
                    });
                yield return new TestCaseData(
                    100,
                    new[]
                    {
                        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
                        101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193,
                        197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307,
                        311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421,
                        431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541
                    });
            }
        }

        [TestCaseSource(nameof(FibonacciTestCases))]
        public void GetFibonacciNumbersTests(int count, BigInteger[] expected)
        {
            var actual = SequenceGenerator.GetFibonacciNumbers(count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(1_000)]
        [TestCase(1_000_000)]
        public void FibonacciSequence_LongSequenceTests(int count)
        {
            var sequence = SequenceGenerator.GetFibonacciNumbers(count);
            Assert.IsTrue(sequence.Count() == count);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-234)]
        public void GetFibonacciNumbers_LengthOfSequenceLessThanOne_ThrowArgumentException(int count)
            => Assert.Throws<ArgumentException>(() => SequenceGenerator.GetFibonacciNumbers(count),
                message: "Method throws ArgumentException in case length of the sequence is less than 1.");

        [TestCaseSource(nameof(PrimeNumbersTestCases))]
        public void GetPrimeNumbersTests(int count, int[] expected)
        {
            var actual = SequenceGenerator.GetPrimeNumbers(count);
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestCase(1_000)]
        [TestCase(1_000_000)]
        public void GetPrimeNumbers_LongSequenceTests(int count)
        {
            var sequence = SequenceGenerator.GetFibonacciNumbers(count);
            Assert.IsTrue(sequence.Count() == count);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-90)]
        public void GetPrimeNumbers_LengthOfSequenceLessThanOne_ThrowArgumentException(int count)
            => Assert.Throws<ArgumentException>(() => SequenceGenerator.GetPrimeNumbers(count),
                message: "Method throws ArgumentException in case length of the sequence is less than 1.");
    }
}