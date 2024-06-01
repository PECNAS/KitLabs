#include <iostream>
using namespace std;

auto calc(int *ind, int arr_len) {
	for (int i = 0; i < arr_len; i++) {
		if (*ind > 0) {
			*ind *= *ind;
		}
		ind++;
	}
	return 0;
}

int main() {
	setlocale(LC_ALL, "Russian");
	cout << "Программа получает на вход длину массива L, после чего вводятся L элементов.\nНа выходе получается массив, где все элементы > 0 возведены в квадрат";

	int arr_len;
	cout << endl << "Введите длину массива: ";
	cin >> arr_len;

	int* arr = new int[arr_len];

	for (int i = 0; i < arr_len;i++) {
		cout << "Введите " << i + 1 << " элемент массива: ";
		cin >> arr[i];
	}

	calc(&arr[0], arr_len);
	cout << "Результат: ";
	for (int i = 0; i < arr_len; i++) {
		cout << arr[i] << "  ";
	}
	
	cout << "\n\n\n\n" << endl;
	return 0;
}