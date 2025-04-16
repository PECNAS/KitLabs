/*#include <stdio.h>
#include <string.h>
#include <locale.h>


char* my_strrchr(const char* str, int c) {
    char* last = NULL;
    const char* current = str;

    while (*current != '\0') {
        if (*current == c) {
            last = (char*)current;
        }
        current++;
    }

    return last;
}

int main() {
    setlocale(0, "russian");
    char str[] = "Викаи";
    char ch = 'и';

    char* res = my_strrchr(str, ch);
    printf("%s", res);

    return 0;
}*/