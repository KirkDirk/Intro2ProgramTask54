// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] CreateArray2DimRandom(int row, int column, int maxEl)
{
    int[,] array = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = new Random().Next(1, maxEl);
        }
    }
    return array;
}
void PrintArray2Dim(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }
}
int[,] Permutation(int[,] array, int numberRow)
{
    for (int j = 0; j < array.GetLength(1) - 1; j++)
    {
        int temp = array[numberRow, j];
        if (array[numberRow, j] <= array[numberRow, j + 1])
        {
            array[numberRow, j] = array[numberRow, j + 1];
            array[numberRow, j + 1] = temp;
        }
    }
    return array;
}
bool ValidDecreasingSequence(int[,] array, int numberRow)
{
    for (int j = 0; j < array.GetLength(1) - 1; j++)
    {
        if (array[numberRow, j] < array[numberRow, j + 1]) return false;
    }
    return true;
}

Console.Clear();
int valueMaxElArray = new Random().Next(4, 10);
int rowArray = new Random().Next(4, valueMaxElArray);
int columnArray = new Random().Next(4, valueMaxElArray);
int[,] someArray = CreateArray2DimRandom(rowArray, columnArray, valueMaxElArray);

Console.WriteLine($"Массив {rowArray}x{columnArray}, значения от 1 до {valueMaxElArray}:");
PrintArray2Dim(someArray);

for (int i = 0; i < rowArray; i++)
{
    while (ValidDecreasingSequence(someArray, i) == false) Permutation(someArray, i);
}

Console.WriteLine($"Упорядоченный массив:");
PrintArray2Dim(someArray);