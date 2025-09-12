using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeLibrary;

namespace UnitTestProjectPrime
{
  [TestClass]
  public class UnitTestPrimes
  {
    [TestMethod]
    public void TestMethod_number_5()
    {
      Assert.IsTrue(Helper.IsPrime(5));
    }

    [TestMethod]
    public void TestMethod_number_4()
    {
      Assert.IsFalse(Helper.IsPrime(4));
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(6)]
    [DataRow(100)]
    [DataRow(100000000000)]
    public void IsPrime_NumberNotPrime_ReturnFalse(long number)
    {
      Assert.IsFalse(Helper.IsPrime(new BigInteger(number)), $"{number} is not prime");
    }

    [DataTestMethod]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(5)]
    [DataRow(7)]
    [DataRow(13)]
    [DataRow(967)]
    public void IsPrime_SmallPrimeNumber_ReturnTrue(long number)
    {
      Assert.IsTrue(Helper.IsPrime(new BigInteger(number)), $"{number} is prime");
    }

    [TestMethod]
    public void IsPrime_BigNumberPrime_ReturnTrue()
    {
      // 32416190071 is prime (11 digits)
      BigInteger number = BigInteger.Parse("32416190071");
      Assert.IsTrue(Helper.IsPrime(number), $"{number} is prime");
    }

    [TestMethod]
    public void IsPrime_BigNumberNotPrime_ReturnFalse()
    {
      // 32416190070 is not prime
      BigInteger number = BigInteger.Parse("32416190070");
      Assert.IsFalse(Helper.IsPrime(number), $"{number} is not prime");
    }

    [DataTestMethod]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(5, true)]
    [DataRow(7, true)]
    [DataRow(13, true)]
    [DataRow(967, true)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(6, false)]
    [DataRow(100, false)]
    [DataRow(100000000000, false)]
    [DataRow(32416190071, true)]  // Big prime number
    [DataRow(32416190070, false)] // Big non-prime number
    [DataRow(2147483647, true)] // int.MaxValue, which is prime
    [DataRow(2147483646, false)] // int.MaxValue - 1, which is not prime
    [DataRow(2305843009213693951, true)] // A known Mersenne prime (2^61 - 1)
    [DataRow(2305843009213693950, false)] // Just below the Mersenne prime
    [DataRow(9999999967, true)] // A large prime number
    [DataRow(9999999968, false)] // Just above the large prime number
    [DataRow(10000000019, true)] // A large prime number
    [DataRow(10000000020, false)] // Just above the large prime number
    [DataRow(67280421310721, true)] // 2^26 + 1, which is prime
    [DataRow(67280421310722, false)] // Just above the prime number
    [DataRow(9223372036854775807, false)] // long.MaxValue, which is prime
    public void IsPrime_SmallPrimeNumbers_ReturnTrue(long number, bool result)
    {
      Assert.AreEqual(result, Helper.IsPrime(new BigInteger(number)), $"{number} is prime");
    }
  }
}
