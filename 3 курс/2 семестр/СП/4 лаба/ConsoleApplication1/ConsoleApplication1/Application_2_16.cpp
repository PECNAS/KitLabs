#include <stdlib.h>
#include <stdio.h>
#include <locale.h>
#include <string.h>
#include <cstring>

#define S_SIZE 80

void delete_words(char* row, char c) {
	char* p = row;
	char* f = row;
	while (*p != '\0') {
		if (*f == c) {
			while (*p != ' ') {
				*p = '_';
				p++;
				printf("%c", *p);
			}
		}
		f++;
	}
}

int main() {
	setlocale(0, "russian");
	char str[] = "������, ����! ���� �� ���������� ���������������� � ������������ ������ 4 ����� ������� ������� ����� 22 8 7 � 16";
	delete_words(str, '�');
}
