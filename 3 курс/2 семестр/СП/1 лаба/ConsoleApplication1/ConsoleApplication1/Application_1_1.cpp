#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	int value, a, b, c, d, result;

	system("chcp 1251");
	system("cls");

	printf("Введите число: ");
	(void)scanf_s("%d", &value);

	a = value / 1000 % 10;
	b = value / 100 % 10;
	c = value / 10 % 10;
	d = value % 10;

	result = a + b + c + d;

	printf("Сумма цифр равна = %d\n", result);
}