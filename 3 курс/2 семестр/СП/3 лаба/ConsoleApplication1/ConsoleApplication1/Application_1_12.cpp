/*#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <math.h>
#include <time.h>

int min;
int max;

int main() {
	setlocale(0, "russian");
	srand(time(0));
	int N;

	printf("¬ведите количство элементов массива: ");
	(void)scanf_s("%d", &N);
	printf("¬ведите число min: ");
	(void)scanf_s("%d", &min);
	printf("¬ведите число max: ");
	(void)scanf_s("%d", &max);

	int* m;
	m = (int*)malloc(N * sizeof(int));

	int num;
	for (int i = 0; i < N; i++) {
		num = rand() % (max - min + 1) + min;
		m[i] = num;
	}

	for (int i = 0; i < N; i++) {
		printf("%d  ", m[i]);
		if ((int)sqrt(m[i]) == sqrt(m[i])) {
			m[i] = (int)sqrt(m[i]);
		}
	}
	printf("\n\n\n");
	for (int i = 0; i < N; i++) {
		printf("%d  ", m[i]);
	}
}


*/