using System;
using System.Numerics;
using PrimeLibrary;

namespace ConsoleAppPrimeBigInt
{
  internal class Program
  {
    static void Main()
    {
      //Console.Write("Entrez un nombre entier (même très grand) : ");
      //string input = Console.ReadLine();
      string input = "123456789123";
      if (BigInteger.TryParse(input, out BigInteger n))
      {
        if (Helper.IsPrime(n))
          Console.WriteLine($"{n} est un nombre premier.");
        else
          Console.WriteLine($"{n} n'est pas un nombre premier.");
      }
      else
      {
        Console.WriteLine("Entrée invalide.");
      }

      Console.WriteLine("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
