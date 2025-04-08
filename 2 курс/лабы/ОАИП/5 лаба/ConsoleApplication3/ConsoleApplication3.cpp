# include <iostream>
using namespace std;

int main()
{
    srand(time(NULL));

    setlocale(LC_ALL, "Russian");

    int n, m;
    cout << "Введите количество строк: ";
    cin >> n;
    cout << "Введите количество столбцов: ";
    cin >> m;

    double** arr1 = new double* [n];
    for (int i = 0; i < n; ++i)
        arr1[i] = new double[m];

    double** arr2 = new double* [n];
    for (int i = 0; i < n; ++i)
        arr2[i] = new double[m];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            double r1 = rand() % 10 - rand() % 10;
            double r2 = rand() % 10 - rand() % 10;
            arr1[i][j] = r1 / 10;
            arr2[i][j] = r2 / 10;
        }
    }
    
    cout << "Матрица A: \n";
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << arr1[i][j] << " \t";
        }
        cout << "\n";
    }

    cout << "Матрица B: \n";
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << arr2[i][j] << " \t";
        }
        cout << "\n";
    }

    cout << "Сложение матриц..." << endl;
    cout << "Результат: \n";
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            cout << arr1[i][j] + arr2[i][j] << " \t ";
        }
        cout << endl;
    }
}