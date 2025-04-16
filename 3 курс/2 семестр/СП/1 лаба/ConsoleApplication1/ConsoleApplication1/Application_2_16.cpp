/*#include <stdio.h>
#include <locale.h>

int main() {
    setlocale(0, "russian");
    int N, i, number, count = 0;

    printf("Введите количество элементов (N): ");
    scanf_s("%d", &N);

    printf("Введите %d целых чисел:\n", N);
    for (i = 0; i < N; i++) {
        scanf_s("%d", &number);
        if (number > -1 && number < 45) {
            count++;
        }
    }

    printf("Количество элементов в интервале от -1 до 45: %d\n", count);

    return 0;
}
*/