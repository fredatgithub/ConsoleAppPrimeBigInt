using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectPrime
{
  [TestClass]
  public class UnitTestGetDivisors
  {
    [TestMethod]
    public void GetDivisors_Number1_Returns1()
    {
      var expected = new List<long> { 1 };
      var actual = GetDivisors(1);

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetDivisors_PrimeNumber_Returns1AndNumber()
    {
      var expected = new List<long> { 1, 13 };
      var actual = GetDivisors(13);

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetDivisors_CompositeNumber_ReturnsAllDivisors()
    {
      var expected = new List<long> { 1, 2, 4, 5, 10, 20 };
      var actual = GetDivisors(20);

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetDivisors_PerfectSquare_ReturnsNoDuplicates()
    {
      var expected = new List<long> { 1, 2, 4, 8, 16 };
      var actual = GetDivisors(16);

      CollectionAssert.AreEqual(expected, actual);
    }

    private static List<long> GetDivisors(long number)
    {
      List<long> divisors = new List<long>();

      long squareRoot = (long)Math.Sqrt(number);
      for (long i = 1; i <= squareRoot; i++)
      {
        if (number % i == 0)
        {
          divisors.Add(i);

          long other = number / i;
          if (other != i) // skip duplicate when the number is a perfect square
          {
            divisors.Add(other);
          }
        }
      }

      divisors.Sort();
      return divisors;
    }
  }
}
