#include <iostream>
#include "PrimeHelper.cpp"
using namespace std;

int main()
{
    std::cout << "Calcul de nombre premier en C++\n";
    // d�finir une variable pour stocker le nombre � tester
    int nombre = 321;
    if (IsPrime(nombre))
    {
      cout << nombre << " est premier" << endl;
    }
    else
    {
      cout << nombre << " n'est pas premier" << endl;
    }

    return 0;
}
