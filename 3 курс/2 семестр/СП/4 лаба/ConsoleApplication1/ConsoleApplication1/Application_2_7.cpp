/*#include <stdlib.h>
#include <stdio.h>
#include <locale.h>
#include <string.h>
#include <cstring>

#define S_SIZE 80

int get_sum(char* row) {
	int i = 0;
	int sum = 0;
	char str[S_SIZE];
	int counter = 0;
	while (row[i] != '\0') {
		if (row[i] == ' ') {
			sum += atoi(str);
			memset(str, 0, sizeof(str));
			counter = 0;
		}
		else {
			str[counter] = row[i];
			counter++;
		}
		i++;
	}

	return sum;
}

int main() {
	setlocale(0, "russian");
	char str[] = "������, ����! ���� �� ���������� ���������������� � ������������ ������ 4 ����� ������� ������� ����� 22 8 7 � 16 ";
	printf("%d ", get_sum(str));
}

*/