/*#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <locale.h>

#define SIZE 10

int main() {
    setlocale(0, "russian");
    int A[SIZE];
    int sum = 0;
    float average;
    int count = 0;

    srand(time(NULL));

    for (int i = 0; i < SIZE; i++) {
        A[i] = rand() % 100;
        sum += A[i];
        printf("%d ", A[i]);
    }
    printf("\n");

    average = (float)sum / SIZE;
    printf("Среднее арифметическое: %.2f\n", average);

    for (int i = 0; i < SIZE; i++) {
        if (A[i] < average) {
            count++;
        }
    }

    printf("Количество элементов, меньших среднего арифметического: %d\n", count);

    return 0;
}
*/