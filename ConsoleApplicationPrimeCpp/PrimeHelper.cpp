#include "PrimeHelper.h"
#include <cmath>

static bool IsPrime(long long unsigned number) {
  if (number < 2) return false;              // 0 et 1 ne sont pas premiers
  if (number == 2 || number == 3) return true; // 2 et 3 sont premiers
  if (number % 2 == 0) return false;         // tous les pairs > 2 ne sont pas premiers

  // On teste uniquement jusqu'à la racine carrée
  long long unsigned limit = static_cast<long long unsigned>(std::sqrt(number));
  for (long long unsigned i = 3; i <= limit; i += 2) {
    if (number % i == 0) return false;
  }
  return true;
}
