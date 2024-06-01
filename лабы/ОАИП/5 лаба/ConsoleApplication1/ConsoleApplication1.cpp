#include <iostream>
using namespace std;

int calc_pow(int* a, int* b) {
	int i = pow(*a, *b);
	int j = pow(*b, *a);

	*a = i;
	*b = j;

	return 0;
}

int main() {
	setlocale(LC_ALL, "Russian");
	int a, b;

	cout << "Введите число a: ";
	cin >> a;
	cout << "Введите число b: ";
	cin >> b;

	int* ptr_a = &a;
	int* ptr_b = &b;

	calc_pow(ptr_a, ptr_b);
	cout << *ptr_a << endl << *ptr_b;

	return 0;
}