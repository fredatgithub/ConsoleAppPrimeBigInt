#include "PrimeHelper.h"
#include <cmath>
#include <algorithm>
#include <string>

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

static bool IsPrimeOptimized(long long unsigned number) {
  if (number < 2) return false;              // 0 et 1 ne sont pas premiers
  if (number == 2 || number == 3) return true; // 2 et 3 sont premiers
  if (number % 2 == 0 || number % 3 == 0) return false; // élimine les multiples de 2 et 3
  // On teste uniquement jusqu'à la racine carrée
  long long unsigned limit = static_cast<long long unsigned>(std::sqrt(number));
  for (long long unsigned i = 5; i <= limit; i += 6) {
    if (number % i == 0 || number % (i + 2) == 0) return false;
  }
  return true;
}

static bool IsPrimeMillerRabin(long long unsigned n, int k = 5) {
  if (n < 2) return false;
  if (n != 2 && n % 2 == 0) return false;
  long long unsigned s = 0;
  long long unsigned d = n - 1;
  while (d % 2 == 0) {
    d /= 2;
    s++;
  }
  auto modular_exponentiation = [](long long unsigned base, long long unsigned exp, long long unsigned mod) {
    long long unsigned result = 1;
    base = base % mod;
    while (exp > 0) {
      if (exp % 2 == 1) result = (result * base) % mod;
      exp = exp >> 1;
      base = (base * base) % mod;
    }
    return result;
  };
  auto witness = [&](long long unsigned a) {
    long long unsigned x = modular_exponentiation(a, d, n);
    if (x == 1 || x == n - 1) return false;
    for (long long unsigned r = 1; r < s; r++) {
      x = modular_exponentiation(x, 2, n);
      if (x == n - 1) return false;
    }
    return true;
  };
  for (int i = 0; i < k; i++) {
    long long unsigned a = 2 + rand() % (n - 4);
    if (witness(a)) return false;
  }
  return true;
}



// Retourne (a mod b) où a est donné sous forme de string
static unsigned int ModString(const std::string& a, unsigned int b) {
  unsigned long long res = 0;
  for (char c : a) {
    res = (res * 10 + (c - '0')) % b;
  }
  return static_cast<unsigned int>(res);
}

// Vérifie si un string représente un nombre premier
static bool IsBigIntPrime(const std::string& numberStr) {
  // Gérer les cas de base
  if (numberStr == "0" || numberStr == "1") return false;
  if (numberStr == "2" || numberStr == "3") return true;

  // Vérifie si pair
  if ((numberStr.back() - '0') % 2 == 0) return false;

  // Convertir une borne pour la racine carrée : ici approximation en double
  long double approx = std::stold(numberStr);
  unsigned long long limit = static_cast<unsigned long long>(sqrt(approx));

  for (unsigned int i = 3; i <= limit; i += 2) {
    if (ModString(numberStr, i) == 0) {
      return false;
    }
  }
  return true;
}
