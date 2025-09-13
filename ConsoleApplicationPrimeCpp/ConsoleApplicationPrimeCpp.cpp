#include <iostream>
#include "PrimeHelper.cpp"
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

    string grandNombre = "18446744073713715001";
    cout << endl << "Test si " << grandNombre << " est premier..." << endl;
    if (IsBigIntPrime(grandNombre))
    {
      cout << grandNombre << " est premier" << endl;
    }
    else
    {
      cout << grandNombre << " n'est pas premier" << endl;
    }
    return 0;
}
