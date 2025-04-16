#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <locale.h>

#define SIZE 10

int main() {
    setlocale(0, "russian");
    int X[SIZE][SIZE];
    int i, j;
    int min;

    srand(time(NULL));

    printf("Массив X[10][10]:\n");
    for (i = 0; i < SIZE; i++) {
        for (j = 0; j < SIZE; j++) {
            X[i][j] = rand() % 100;
            printf("%3d ", X[i][j]);

            if (i == 0 && j == 0 || X[i][j] < min) {
                min = X[i][j];
            }
        }
        printf("\n");
    }

    printf("\nМинимальный элемент массива: %d\n", min);

    return 0;
}

