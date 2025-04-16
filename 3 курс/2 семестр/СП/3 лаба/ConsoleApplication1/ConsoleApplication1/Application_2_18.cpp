#include <stdio.h>
#include <stdlib.h>
#include <locale.h>

void calc (int a, int b, int* res1, int* res2) {
	*res1 = a + b;
	*res2 = (a + b) / 2;
}


int main() {
	setlocale(0, "russian");
	int a;
	int b;
	int res1;
	int res2;

	printf("¬ведите значение a: ");
	(void)scanf_s("%d", &a);
	printf("\n¬ведите значение b: ");
	(void)scanf_s("%d", &b);
	calc(a, b, &res1, &res2);

	printf("—умма a и b: %d", res1);
	printf("\n—реднее арифметическое a и b: %d\n\n", res2);
}