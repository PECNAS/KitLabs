/*#include <stdio.h>
#include <stdlib.h>
#include <locale.h>

int M;
int N;
int max;
int min;

int main() {
    setlocale(0, "russian");

    printf("Введите число N: ");
    (void)scanf_s("%d", &N);
    printf("Введите число M: ");
    (void)scanf_s("%d", &M);
    printf("Введите число min: ");
    (void)scanf_s("%d", &min);
    printf("Введите число max: ");
    (void)scanf_s("%d", &max);

    int* A;
    A = (int*)malloc(N * sizeof(int)); // выделение памяти для массива
    int* B;
    B = (int*)malloc(M * sizeof(int)); // выделение памяти для массива
    int* a; // указатель на массив
    a = (int*)malloc(N + M  * sizeof(int)); // выделение памяти для массива

    for (int i = 0; i < N; i++) {
        A[i] = (rand() % (max - min + 1) + min);
        printf("%d ", A[i]);
    }
    printf("\n\n");
    for (int i = 0; i < M; i++) {
        B[i] = (rand() % (max - min + 1) + min);
        printf("%d ", B[i]);
    }
    printf("\n\n");
    int counter = 0;
    for (int i = 0; i < M; i++) {
        bool flag = false;
        for (int j = 0; j < N; j++) {
            if (B[i] == A[j])
            {
                flag = true;
                break;
            }
        }
        if (flag == false) {
            a[counter] = B[i];
            counter++;
        }
    }

    for (int i = 0; i < counter; i++) {
        printf("%d ", a[i]);
    }
    free(a);

    return 0;
}
*/