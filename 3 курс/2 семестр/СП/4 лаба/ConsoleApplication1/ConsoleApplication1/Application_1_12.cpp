/*#include <stdio.h>
#include <string.h>
#include <locale.h>

char* my_strncpy(char* from, char* to, int n) {
    for (int i = 0; i < n; i++) {
        to[i] = from[i];
    }
    return to;
}

int main() {
    setlocale(0, "russian");
    char from[] = "Виктория Владимировна лучший преподаватель КАИ";
    const int n = 25;
    char to[n];

    my_strncpy(from, to, n);

    int i = 0;
    for (int i = 0; i < n; i++) {
        printf("%c", to[i]);
    }
}
*/