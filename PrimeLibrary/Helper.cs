using System;
using System.Collections.Generic;
using System.Numerics;

namespace PrimeLibrary
{
  public static class Helper
  {
    public static bool IsPrime(BigInteger nombre)
    {
      if (nombre < 2) return false;
      if (nombre == 2) return true;
      if (nombre.IsEven) return false;

      BigInteger limite = SquareRoot(nombre);
      for (BigInteger i = 3; i <= limite; i += 2)
      {
        if (nombre % i == 0)
        {
          return false;
        }
      }

      return true;
    }

    public static BigInteger SquareRoot(BigInteger number)
    {
      if (number == 0) return 0;
      BigInteger a = number;
      BigInteger b = (number >> 1) + 1;
      while (b < a)
      {
        a = b;
        b = ((number / b) + b) >> 1;
      }

      return a;
    }

    public static List<long> GetDivisors(long number)
    {
      List<long> divisors = new List<long>();

      long squareRoot = (long)Math.Sqrt(number);
      for (long i = 1; i <= squareRoot; i++)
      {
        if (number % i == 0)
        {
          divisors.Add(i);

          long other = number / i;
          if (other != i) // skip duplicate when n is a perfect square
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
