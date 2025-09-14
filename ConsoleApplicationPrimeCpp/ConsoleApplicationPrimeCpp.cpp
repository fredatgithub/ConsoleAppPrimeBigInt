#include <iostream>
#include "PrimeHelper.cpp"
#include <chrono>
using namespace std;

int main()
{
    std::cout << "Calcul de nombre premier en C++\n";
    long long unsigned nombre = 1844674407371371507;
    cout << "Test si " << nombre << " est premier..." << endl;
    if (IsPrime(nombre))
    {
      cout << nombre << " est premier" << endl;
    }
    else
    {
      cout << nombre << " n'est pas premier" << endl;
    }

    string bigIntNumber = "18446744073713715001";
    cout << endl << "Test si " << bigIntNumber << " est premier..." << endl;

    auto start = std::chrono::high_resolution_clock::now();
    bool result = IsBigIntPrime(bigIntNumber);
    auto end = std::chrono::high_resolution_clock::now();
    std::chrono::duration<double> elapsed = end - start;
    std::cout << "Temps écoulé : " << elapsed.count() << " secondes\n";
    
    if (IsBigIntPrime(bigIntNumber))
    {
      cout << bigIntNumber << " est premier" << endl;
    }
    else
    {
      cout << bigIntNumber << " n'est pas premier" << endl;
    }
    return 0;
}
