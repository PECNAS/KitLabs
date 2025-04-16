/*#include <iostream>
#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	setlocale(LC_ALL, "Rus");
	int x;
	while (true) {
		printf("Введите возраст: ");
		scanf_s("%d", &x);
		if ((x > 0 && x <= 3) || (x > 21 && x <= 24)) {
			printf("ходит в ясли");
		}
		else if (x > 3 && x < 7)
		{
			printf("ходит в детский сад");
		}

		else if (x >= 7 && x < 19)
		{
			printf("ходит в школу");
		}

		else if (x > 17 && x < 22)
		{
			printf("окончил школу");
		}
		else if ((x < 1))
		{
			printf("Возраст не может быть меньше 1!");
		}

		printf("\r\n");
	}
}

*/