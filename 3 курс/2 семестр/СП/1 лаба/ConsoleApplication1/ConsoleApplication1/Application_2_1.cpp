/*#include <stdio.h>
#include <locale.h>

int main() {
    setlocale(0, "Russian");
    double y;
    int x;

    for (x = 1; x <= 9; x++) {
        if (x >= 1 && x < 2) {
            y = 3 * x * x + 2;
        }
        else if (x >= 2 && x < 4) {
            y = x;
        }
        else if (x >= 4 && x <= 9) {
            if (x != 8) {
                y = 5.0 / (x - 8);
            }
            else {
                printf("x не может быть равен 8, тк будет деление на ноль!\n");
                continue;
            }
        }
        printf("x = %d, y = %.2f\n", x, y);
    }

    return 0;
}
*/