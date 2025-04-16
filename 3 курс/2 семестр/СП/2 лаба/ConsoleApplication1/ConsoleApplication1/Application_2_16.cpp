/*#include <stdio.h>
#include <locale.h>

#define ROWS 7
#define COLS 7

int main() {
    setlocale(0, "russian");
    int A[ROWS][COLS];
    int num = 1;
    int sum = 0;

    for (int i = 0; i < ROWS; i++) {
        for (int j = 0; j < COLS; j++) {
            A[i][j] = num++;
        }
    }

    printf("Массив A(7,7):\n");
    for (int i = 0; i < ROWS; i++) {
        for (int j = 0; j < COLS; j++) {
            printf("%3d ", A[i][j]);
        }
        printf("\n");
    }

    for (int i = 0; i < ROWS; i++) {
        sum += A[i][COLS - 1];
    }

    printf("Сумма элементов в последнем столбце: %d\n", sum);

    return 0;
}*/