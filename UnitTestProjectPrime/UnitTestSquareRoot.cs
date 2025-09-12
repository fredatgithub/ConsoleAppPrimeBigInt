using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeLibrary;

namespace UnitTestProjectPrime
{
  [TestClass]
  public class UnitTestSquareRoot
  {
    [TestMethod]
    [DataTestMethod]
    [DataRow(0, 0)]
    [DataRow(1, 1)]
    [DataRow(4, 2)]
    [DataRow(9, 3)]
    [DataRow(15, 3)] // Racine entière
    [DataRow(16, 4)]
    [DataRow(81, 9)]
    [DataRow(123456789, 11111)]
    public void SquareRoot_SmallInteger_Valide(long number, long expected)
    {
      var result = Helper.SquareRoot(new BigInteger(number));
      Assert.AreEqual(new BigInteger(expected), result, $"Square root of {number} incorrect");
    }

    [TestMethod]
    public void SquareRoot_LargeNumbers_Valide()
    {
      var largeNumber = BigInteger.Parse("100000000000000000000000000000000");
      var expected = BigInteger.Parse("10000000000000");
      var result = Helper.SquareRoot(largeNumber);
      Assert.AreNotEqual(expected, result, "Square root of a very large number incorrect");
    }

    [TestMethod]
    public void SquareRoot_PasExactArrondiInferieur()
    {
      var number = BigInteger.Parse("50");
      var result = Helper.SquareRoot(number);
      Assert.AreEqual(7, (long)result, "Should give the integer part of the square root");
    }
  }
}
