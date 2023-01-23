
//
// Задача 58: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
//
// Изменим ввод на ввод строки чисел с разделителем - запятая и пробел(ы) и с разделителем пробл(ы), без запятой
// Т. к., при вводе большого количества чисел, вводить запятую не всегда бывает удобно
//

// Ввод чисел.Разделитель между числами или пробел(ы)
// Возвращает строку двух целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input two digits of integers. This is matrix dimentione M x N(as example: 4 5");
    Console.Write("\n --- The number separator is a space!");

    Console.Write("\nInput digits, please: ");

    string? strArray = Console.ReadLine();
    if( String.IsNullOrEmpty(strArray) == true)
        strArray = "";

    // Из строки, которая может иметь значение NULL, делаем строку без NULL. Чтобы не использовать string?
    string str = string.Concat("", strArray);
    return str;
}

// Получает на входе строку чисел из консоли ввода.
// Если разделителем чисел была запятая ",", то удаляем ее.
// Возвращает строку целых чисел, где разделитель между числами - пробел
string GetNormilizeStrOfIntegers(string strArray)
{
    return strArray.Replace(",", "");
}

// Конвертирует строку целых чисел в массив строк целых чисел
// Возвращает массив слов, где каждый элемент массива целое число в виде строки.
string[] GetStrArrayOfNumvers(string strDigits)
{
    return strDigits.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
}

// Конвертирует массив строк целых чисел в массив целых чисел
// Пример: string "3 4" => int[3 4]
// Возвращает массив целых чисел, масив состоит из двух чисел, это кол-во строк
int[] GetConvertStrArrayToArrayInt(string[] wordsOfNumbers)
{
    int[] array = new int[3];
    array[0] = Convert.ToInt32(wordsOfNumbers[0]);
    array[1] = Convert.ToInt32(wordsOfNumbers[1]);

    return array;
}

// Сщздает и возвращает матрицу целых чисел, размером row на col
// Возвращает матрицу целых чисел
int[,] GetMatrixInt(int row, int col)
{
    int[,] matrix = new int[row, col];

    var rand = new Random();

    for(int i = 0; i < row; ++i)
    {
        for(int j = 0; j < col; ++j)
        {
            matrix[i, j] = rand.Next(20);
        }
    }

    return matrix;
}

// Печатаем матрицу целых чисел
void PrintMatrix(int row, int col, int[,] matrix)
{
    Console.WriteLine($"\nYou create matrix. Size matrix is: {row} x {col}");
    for(int i = 0; i < row; ++i)
    {
        Console.WriteLine();
        for(int j = 0; j < col; ++j)
        {
            Console.Write("{0,4:N0}  ", matrix[i, j]);

        }
    }
    Console.WriteLine("\n");
}

// Считает сумму элементов в каждой строке матрицы и выдаёт номер строки с наименьшей суммой элементов
// Возврат: номер строки с наименьшей суммой элементов
int GetRowMin(int row, int col, int[,] matrix)
{

    int rowMin = 0;
    int sumOfElementsMin = 0;

    for(int j = 0; j < col; ++j)
    {
        sumOfElementsMin = sumOfElementsMin + matrix[0, j];
    }

    int sumOfElements = 0;

    for(int i = 0; i < row; ++i)
    {
        sumOfElements = 0;
        for(int j = 0; j < col; ++j)
        {
            sumOfElements = sumOfElements + matrix[i, j];
        }

        if(sumOfElements < sumOfElementsMin) {
            sumOfElementsMin = sumOfElements;
            rowMin = i;
        }
    }

    return rowMin;
}

// Печатаем результат. Номер строки матрицы, где наименьшая сумма элементов по строке
void PrintRezult(int rowMinSum)
{
    Console.WriteLine("Founded row (the first row begins with one (1)) is: \n");
    Console.Write("{0,8}  ", rowMinSum + 1);
    Console.WriteLine("\n");
}

void main()
{
    Console.WriteLine(" ------- Task-50 -------");

    // Получить строку ввода целых чисел. Это строка вида: "N M" задает размер матрицы
    // Пример : " 5 4 17", матрица размером 5 на 4
    string strDigits = InputIntegerDigitsAsString();
    Console.WriteLine($"\n You input digits: {strDigits}");

    // Если были введены целые числа с разделителем запятая "," то заменяем запятую на пробел " "
    strDigits = GetNormilizeStrOfIntegers(strDigits);

    // Получим массив строк, где строка - целое число в виде строки
    string[] wordsOfNumbers = GetStrArrayOfNumvers(strDigits);

    // Конвертируем массив строк в массив целых числех
    int[] arrayOfDigits = GetConvertStrArrayToArrayInt(wordsOfNumbers);

    int row = arrayOfDigits[0];
    int col = arrayOfDigits[1];

    // Создать квадратную матрицу вещественных чисел и заполнить ее
    int[,] matrix = GetMatrixInt(row, col);

    // Печатаем матрицу
    PrintMatrix(row, col, matrix);

    // Получим массив среднеарифмитических чисел. Размер массива - row на col
    int rowMinSum = GetRowMin(row, col, matrix);

    // Печатаем результат (красиво), количество введенных чисел больше нуля
    PrintRezult(rowMinSum);
}

main();


