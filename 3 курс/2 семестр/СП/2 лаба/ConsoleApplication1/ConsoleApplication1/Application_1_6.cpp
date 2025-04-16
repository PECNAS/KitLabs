/*#include <iostream>
#include <stdlib.h>
#include <time.h>

int main()
{
    setlocale(0, "Russian");
    int A[10];
    int count = 0;

    srand(time(0));

    for (int i = 0; i < 10; i++) {
        A[i] = rand() % 101;
    }

    printf("Сгенерированный массив: ");
    for (int i = 0; i < 10; i++) {
        printf("%d ", A[i]);
    }

    for (int i = 0; i < 10; i++) {
        if (A[i] % 2 != 0) {
            count++;
        }
    }
    printf("\n\n");
    printf("Количество нечетных элементов массива : %d", count);
    return 0;
}
*/