#include <iomanip>
#include <iostream>
using namespace std;
int main()
{
    srand(time(nullptr));

    int r, stlobe, stroka;

    cout << "stolbe stroka:";
    cin >> stroka >> stlobe;

    short int** A = new short int* [stroka];
    for (int j = 0; j < stroka; j++)
        A[j] = new short int[stlobe];

    short int** B = new short int* [stlobe];
    for (int j = 0; j < stlobe; j++)
        B[j] = new short int[stroka];


    for (int j = 0; j < stroka; j++)
    {
        for (int k = 0; k < stlobe; k++)
        {
            r = rand() % 1000;

            A[j][k] = r;
            //B[j][k] = r;

            cout << A[j][k] << " \t ";
        }
        cout << endl;
    }

    cout << "\n\n\n\n" << endl;

    for (int i = 0; i < stroka; i++) {
        for (int j = 0; j < stlobe; j++) {
            B[j][stroka - i] = A[i][j];
        }
    }

    for (int i = 0; i < stroka; i++) {
        for (int j = 0; j < stlobe; j++) {
            cout << B[i][j] << " \t ";
        }
        cout << endl;
    }

    return 0;
}
